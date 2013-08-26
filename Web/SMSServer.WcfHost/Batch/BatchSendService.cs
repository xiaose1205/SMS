using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;
using Newtonsoft.Json;
using SMSServer.OpenPlatform;
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
        EnterpriseService config = new EnterpriseService();

        void Sendmt(object sender)
        {
            SmsBatchWaitInfo model = sender as SmsBatchWaitInfo;
            if (model != null)
            {
                if (model.Channels.Length == 0)
                {
                    CompleteMt(model);
                    return;
                }
                if ((SMSEnum)model.MsgType == SMSEnum.Group)
                {//群发
                    SMSGroup gGroup = JsonConvert.DeserializeObject<SMSGroup>(model.MsgPack);

                }
                else
                {//组发
                    SMSMass mMass = JsonConvert.DeserializeObject<SMSMass>(model.MsgPack);
                    foreach (string chanelid in model.Channels)
                    {
                        BaseService service = ServicesFactory.Execute(int.Parse(chanelid));
                        int count = service.MassCount();
                        for (int i = 0; i < (mMass.phones.Count / count + (mMass.phones.Count % count > 0 ? 1 : 0)); i++)
                        {
                            List<string> readyphones = new List<string>();
                            if (mMass.phones.Count - i * count >= count)
                                readyphones = mMass.phones.GetRange(i * count, count);
                            else
                                readyphones = mMass.phones.GetRange(i * count, mMass.phones.Count - i * count);

                            int result = service.SendSMS(service.GetUser(), GetFromDetails(readyphones, mMass.content));
                            WriteBatchDetial(readyphones, mMass.content, (SendResultEnum)Enum.ToObject(typeof(SendResultEnum), result));

                        }
                    }
                    CompleteMt(model);

                }

                lock (lockobj)
                    SendingMtCount--;
            }
        }
        /// <summary>
        /// 写入号码详情表
        /// </summary>
        /// <param name="phones"></param>
        /// <param name="content"></param>
        public void WriteBatchDetial(List<string> phones, string content, SendResultEnum eEnum)
        {
            mrg.WriteBatchDetial(phones, content);
        }

        public SMSSDKMassInfo GetFromDetails(List<string> phones, string content)
        {
            SMSSDKMassInfo info = new SMSSDKMassInfo();
            info.Content = content;
            info.Phones = phones;
            return info;
        }

        /// <summary>
        /// 处理已经发送过的wait_mt
        /// </summary>
        /// <param name="model"></param>
        public void CompleteMt(SmsBatchWaitInfo model)
        {
            foreach (SendingBatchModel batchmodel in AppContent.SendingBatchs)
            {
                if (batchmodel.ID == model.BatchID)
                {
                    try
                    {
                        //sendingmodel = batchmodel;
                        batchmodel.SendCount++;
                        if (batchmodel.SendCount == batchmodel.MtCount)
                        {
                            Print("发送完成：" + batchmodel.ID + "");
                            //更新状态为完成
                            mrg.UpdateBatchState(BatchState.Complete, batchmodel.ID);
                            AppContent.SendingBatchs.Remove(batchmodel);
                        }
                    }
                    catch (Exception ex)
                    {
                        Print(ex.Message);
                    }
                    break;
                }

            }
            // mrg.RemoveToMt(model, sendingmodel, (SendResultEnum)Enum.ToObject(typeof(SendResultEnum), result));
        }
    }
}
