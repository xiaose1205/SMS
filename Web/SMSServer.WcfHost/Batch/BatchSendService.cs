using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;
using Newtonsoft.Json;
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
                if (model.Channels.Length == 0)
                {
                    // CompleteMt(model, (int)SendResultEnum.CONTACT_ERROR);
                    return;
                }
                if ((SMSEnum)model.MsgType == SMSEnum.Group)
                {
                    SMSGroup gGroup = JsonConvert.DeserializeObject<SMSGroup>(model.MsgPack);

                }
                else
                {
                    SMSMass mMass = JsonConvert.DeserializeObject<SMSMass>(model.MsgPack);
                }

                lock (lockobj)
                    SendingMtCount--;
            }
        }
        ///// <summary>
        ///// 转换messageitem  to  wait_mtmodel
        ///// </summary>
        ///// <param name="item"></param>
        ///// <returns></returns>
        //public SmsBatchWaitInfo ConvertItemTOMtmodel(MessageItem item)
        //{
        //    SmsBatchWaitInfo model = new SmsBatchWaitInfo();
        //    model.BatchID = item.BatchID;
        //    model.EnterPriseID = item.EnterPriseID;
        //    model.MsgCount = item.MsgCount;
        //    model.Msgpack = item.MessageBytes;
        //    model.Mtid = item.Mtid;
        //    model.MsgType = item.SendType;
        //    return model;
        //}
        ///// <summary>
        ///// 处理已经发送过的wait_mt
        ///// </summary>
        ///// <param name="model"></param>
        //public void CompleteMt(SmsBatchWaitInfo model, int result)
        //{
        //    Print("发送" + model.BatchID + "结果：" + result);
        //    SendingBatchModel sendingmodel = null;
        //    foreach (SendingBatchModel batchmodel in AppContent.SendingBatchs)
        //    {
        //        if (batchmodel.BatchID == model.BatchID)
        //        {
        //            try
        //            {
        //                sendingmodel = batchmodel;
        //                batchmodel.SendCount++;
        //                if (batchmodel.SendCount == batchmodel.MtCount)
        //                {
        //                    Print("发送完成：" + batchmodel.BatchID + "");
        //                    //更新状态为完成
        //                    mrg.UpdateBatchState(BatchState.Complete, batchmodel.BatchID);
        //                    AppContent.SendingBatchs.Remove(batchmodel);
        //                    if (model.TaskID != Guid.Empty.ToString() && !string.IsNullOrEmpty(model.TaskID))
        //                    {
        //                        TaskManage taskmrg = new TaskManage();
        //                        //sql语句里面判断是否为一次性的任务，否则就是继续执行。
        //                        taskmrg.UpdateTaskBySended((int)TaskState.Stop, model.TaskID.ToString());
        //                    }
        //                }
        //                break;
        //            }
        //            catch (Exception ex)
        //            {
        //                Print(ex.Message);
        //            }
        //        }

        //    }
        //    mrg.RemoveToMt(model, sendingmodel, (SendResultEnum)Enum.ToObject(typeof(SendResultEnum), result));
        //}
    }
}
