using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;
using SMSServer.Service;
using SMSService.Entity;

namespace SMSServer.WcfHost.Batch
{
    public class BatchSendService : BaseService<BatchSendService>
    {
        public BatchSendService()
        {
            base.IsStop = false;
            base.SleepSpan = AppContent.ReadSender;
            this.ServiceName = "批次发送";
        }

        BatchService mrg = new BatchService();
        int SendingMtCount = 0;
        object lockobj = new object();
        public override void WorkHandle()
        {
            Thread.Sleep(base.SleepSpan);
            while (SendingMtCount < AppContent.SendMtCount)
            {

                if (AppContent.SendingMts.Count == 0)
                    break;
                SmsBatchWaitInfo model = AppContent.SendingMts.Dequeue();
                Print("发送：" + model.BatchID + "");
                ThreadPool.QueueUserWorkItem(new WaitCallback(Sendmt), model);
                Thread.Sleep(base.SleepSpan / AppContent.SendMtCount);
                lock (lockobj)
                    SendingMtCount++;
            }
        }

        void Sendmt(object sender)
        {
            SmsBatchWaitInfo model = sender as SmsBatchWaitInfo;
            if (model != null)
            {
                if (string.IsNullOrEmpty(model.GateUser))
                {
                    CompleteMt(model, (int)SendResultEnum.INVALID_ACCOUNT); 
                    return;
                }
                PostMsg post = PostServers.Current.GetFormPool();
                post.SetAccount(model.GateUser, model.GatePwd);
                MessageItem item = new MessageItem();
                item.BatchID = model.BatchID;
                item.MessageBytes = model.Msgpack;
                item.MsgCount = Convert.ToInt32(model.MsgCount);
                item.Mtid = model.Mtid;
                item.SendType = Convert.ToInt32(model.MsgType);
                item.EnterPriseID = model.EnterPriseID;
                int result = post.Post(item, false);
                if (result == (int)SendResultEnum.CONTACT_ERROR)
                {
                    Thread.Sleep(100);
                    result = post.Post(item, true);
                }
                else if (result == (int)SendResultEnum.TOO_LARGE_PACK)
                {
                    Print("包过大分解包重新发送：" + item.Mtid + "");
                    //包过大分解包重新发送
                    foreach (var miniitem in post.SendWithLarge(model))
                    {
                        result = post.Post(miniitem, false);
                        CompleteMt(ConvertItemTOMtmodel(miniitem), result);
                        Thread.Sleep(100);
                    }
                    mrg.ClearWaitWithMtID(model.Mtid);
                    return;
                }
                CompleteMt(model, result);
                mrg.ClearWaitWithMtID(model.Mtid);
                lock (lockobj)
                    SendingMtCount--;
            }
        }
        /// <summary>
        /// 转换messageitem  to  wait_mtmodel
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public SmsBatchWaitInfo ConvertItemTOMtmodel(MessageItem item)
        {
            SmsBatchWaitInfo model = new SmsBatchWaitInfo();
            model.BatchID = item.BatchID;
            model.EnterPriseID = item.EnterPriseID;
            model.MsgCount = item.MsgCount;
            model.Msgpack = item.MessageBytes;
            model.Mtid = item.Mtid;
            model.MsgType = item.SendType;
            return model;
        }
        /// <summary>
        /// 处理已经发送过的wait_mt
        /// </summary>
        /// <param name="model"></param>
        public void CompleteMt(SmsBatchWaitInfo model, int result)
        {
            Print("发送" + model.BatchID + "结果：" + result);
            SendingBatchModel sendingmodel = null;
            foreach (SendingBatchModel batchmodel in AppContent.SendingBatchs)
            {
                if (batchmodel.BatchID == model.BatchID)
                {
                    try
                    {
                        sendingmodel = batchmodel;
                        batchmodel.SendCount++;
                        if (batchmodel.SendCount == batchmodel.MtCount)
                        {
                            Print("发送完成：" + batchmodel.BatchID + "");
                            //更新状态为完成
                            mrg.UpdateBatchState(BatchState.Complete, batchmodel.BatchID);
                            AppContent.SendingBatchs.Remove(batchmodel);
                            if (model.TaskID != Guid.Empty.ToString() && !string.IsNullOrEmpty(model.TaskID))
                            {
                                TaskManage taskmrg = new TaskManage();
                                //sql语句里面判断是否为一次性的任务，否则就是继续执行。
                                taskmrg.UpdateTaskBySended((int)TaskState.Stop, model.TaskID.ToString());
                            }
                        }
                        break;
                    }
                    catch (Exception ex)
                    {
                        Print(ex.Message);
                    }
                }

            }
            mrg.RemoveToMt(model, sendingmodel, (SendResultEnum)Enum.ToObject(typeof(SendResultEnum), result));
        }
    }
}
