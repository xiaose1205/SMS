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
                    CompleteMt(model, 0, 0);
                    return;
                }
                SmsEnterpriseCfgInfo configmodel = config.GetModelWithKey("smsprice", model.EnterPriseID);
                SmsEnterpriseInfo info = config.GetEnterpriseInfo(model.EnterPriseID);
                float smsprice = float.Parse(configmodel.CfgValue);
                int result = 3;
                int sendCount = 0;
                if ((SMSEnum)model.MsgType == SMSEnum.Group)
                {//群发
                    SMSGroupInfo gGroup = JsonConvert.DeserializeObject<SMSGroupInfo>(model.MsgPack);
                    bool hasMoney = !(info.Capital * 1000 - smsprice * 10 * gGroup.groupInfos.Count < 0);
                    foreach (string chanelid in model.Channels)
                    {
                        BaseService service = ServicesFactory.Execute(int.Parse(chanelid));
                        int count = service.MassCount();
                        for (int i = 0; i < (gGroup.groupInfos.Count / count + (gGroup.groupInfos.Count % count > 0 ? 1 : 0)); i++)
                        {
                            List<SDKGroupInfo> readyphones = new List<SDKGroupInfo>();
                            if (gGroup.groupInfos.Count - i * count >= count)
                            {
                                List<GroupInfo> groupInfos = gGroup.groupInfos.GetRange(i * count, count);
                                foreach (GroupInfo smsDetial in groupInfos)
                                {
                                    readyphones.Add(new SDKGroupInfo()
                                        {
                                            Phone = smsDetial.Phone,
                                            Content = smsDetial.Content
                                        });
                                }

                            }
                            else
                            {
                                List<GroupInfo> groupInfos = gGroup.groupInfos.GetRange(i * count, gGroup.groupInfos.Count - i * count);
                                foreach (GroupInfo smsDetial in groupInfos)
                                {
                                    readyphones.Add(new SDKGroupInfo()
                                  {
                                      Phone = smsDetial.Phone,
                                      Content = smsDetial.Content
                                  });
                                }
                            }

                            if (hasMoney)
                            {
                                result = service.SendSMS(service.GetUser(), readyphones);
                                if (result == 1) sendCount += readyphones.Count;
                            }
                            WriteBatchDetial(readyphones, (SendResultEnum)Enum.ToObject(typeof(SendResultEnum), result), model, chanelid);

                        }
                    }
                }
                else
                {//组发
                    SMSMassInfo mMass = JsonConvert.DeserializeObject<SMSMassInfo>(model.MsgPack);
                    bool hasMoney = !(info.Capital * 1000 - smsprice * 10 * mMass.Phones.Count < 0);
                    foreach (string chanelid in model.Channels)
                    {
                        BaseService service = ServicesFactory.Execute(int.Parse(chanelid));
                        int count = service.MassCount();
                        for (int i = 0; i < (mMass.Phones.Count / count + (mMass.Phones.Count % count > 0 ? 1 : 0)); i++)
                        {
                            List<string> readyphones = new List<string>();
                            if (mMass.Phones.Count - i * count >= count)
                                readyphones = mMass.Phones.GetRange(i * count, count);
                            else
                                readyphones = mMass.Phones.GetRange(i * count, mMass.Phones.Count - i * count);

                            if (hasMoney)
                            {
                                result = service.SendSMS(service.GetUser(), GetFromDetails(readyphones, mMass.Content));
                                if (result == 1) sendCount += readyphones.Count;
                            }
                            WriteBatchDetial(readyphones, mMass.Content, (SendResultEnum)Enum.ToObject(typeof(SendResultEnum), result), model, chanelid);

                        }
                    }

                }
                CompleteMt(model, smsprice, sendCount);
                lock (lockobj)
                    SendingMtCount--;
            }
        }
        /// <summary>
        /// 写入号码详情表
        /// </summary>
        /// <param name="phones"></param>
        /// <param name="content"></param>
        public void WriteBatchDetial(List<SDKGroupInfo> groupInfos, SendResultEnum eEnum, SmsBatchWaitInfo info, string channelId)
        {
            List<SmsBatchDetailsInfo> infos = new List<SmsBatchDetailsInfo>();
            foreach (SDKGroupInfo sdkGroupInfo in groupInfos)
            {
                infos.Add(new SmsBatchDetailsInfo()
                    {
                        AccountID = info.AccountID,
                        BatchID = info.BatchID.Value,
                        ChannelID = int.Parse(channelId),
                        Content = sdkGroupInfo.Content,
                        Phone = sdkGroupInfo.Phone,
                        SmsType = info.MsgType,
                        State = (int)eEnum,
                        SubmitTime = DateTime.Now

                    });
            }
            mrg.WriteBatchDetial(infos);
        }
        /// <summary>
        /// 写入号码详情表
        /// </summary>
        /// <param name="phones"></param>
        /// <param name="content"></param>
        public void WriteBatchDetial(List<string> phones, string content, SendResultEnum eEnum, SmsBatchWaitInfo info, string channelId)
        {
            List<SmsBatchDetailsInfo> infos = new List<SmsBatchDetailsInfo>();

            foreach (string phone in phones)
            {
                infos.Add(new SmsBatchDetailsInfo()
                {
                    AccountID = info.AccountID,
                    BatchID = info.BatchID.Value,
                    ChannelID = int.Parse(channelId),
                    Content = content,
                    Phone = phone,
                    SmsType = info.MsgType,
                    State = (int)eEnum,
                    SubmitTime = DateTime.Now

                });
            }
            mrg.WriteBatchDetial(infos);
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
        public void CompleteMt(SmsBatchWaitInfo model, float sendPrice, int count)
        {
            mrg.UpdatePrice(model.EnterPriseID, sendPrice * count);
            mrg.UpdateSuccessCount(model.BatchID.Value, count);
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
            mrg.RemoveToMt(model);
        }
    }
}
