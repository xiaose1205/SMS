using System;
using System.Collections.Generic;
using System.Threading;
using SMSServer.Service;
using SMSService.Entity;


namespace SMSServer.WcfHost.Batch
{
    /// <summary>
    /// 批次处理
    /// </summary>
    public class BatchReadService : BaseService<BatchReadService>
    {
        public BatchReadService()
        {
            base.IsStop = false;
            base.SleepSpan = AppContent.ReadBatch;
            this.ServiceName = "批次读取";
        }

        BatchService batchmrg = new BatchService();
        public override void WorkHandle()
        {
            try
            {
                Thread.Sleep(base.SleepSpan);
                List<SendingBatchModel> batchlists = batchmrg.GetReadyBatch(AppContent.ReadBatchCount);
                Print("读取下待发批次队列：" + batchlists.Count + "");
                string batchids = string.Empty;
                foreach (SendingBatchModel item in batchlists)
                {
                    #region 检查发送用户是否已不存在

                    if (!batchmrg.CheckUser(item.AccountID))
                    {
                        batchmrg.UpdateBatchState(BatchState.Complete, item.ID);
                        continue;
                    }
                    #endregion

                    batchids += item.ID + ",";
                    AppContent.SendingBatchs.Add(item);
                }
                if (!string.IsNullOrEmpty(batchids))
                {
                    List<SmsBatchWaitInfo> mtlists = batchmrg.GetReadyMt(AppContent.ReadBatchCount, batchids.TrimEnd(','));
                    foreach (SmsBatchWaitInfo item in mtlists)
                    {
                        #region 获取当前账号发送所走的信道
                        EnterpriseService config = new EnterpriseService();
                        SmsEnterpriseCfgInfo configmodel = config.GetModelWithKey("channels", item.EnterPriseID);

                        string[] channels;
                        if (configmodel == null)
                        {
                            Print("当前企业的没有选择信道为空：" + item.EnterPriseID + "");

                        }
                        else
                        {
                            channels = configmodel.CfgValue.Split(',');   
                            Print("加入队列：" + item.BatchID + "");
                            foreach (var batch in AppContent.SendingBatchs)
                            {
                                if (batch.ID == item.BatchID)
                                {
                                    item.Channels = channels;
                                }
                            }
                        }
                        AppContent.SendingMts.Enqueue(item);
                        #endregion
                    }

                }
            }
            catch (Exception ex)
            {
                Print(ex.Message);
            }
        }

    }
}
