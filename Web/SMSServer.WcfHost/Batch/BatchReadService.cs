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
                    TaskManage mrg = new TaskManage();
                    if (!mrg.CheckUser(item.UploadUserID))
                    {
                        batchmrg.UpdateBatchState(BatchState.Complete, item.BatchID);
                        continue;
                    }
                    #endregion

                    batchids += item.BatchID + ",";
                    AppContent.SendingBatchs.Add(item);
                }
                if (!string.IsNullOrEmpty(batchids))
                {
                    List<SmsBatchWaitInfo> mtlists = batchmrg.GetReadyMt(AppContent.ReadBatchCount, batchids.TrimEnd(','));
                    foreach (SmsBatchWaitInfo item in mtlists)
                    {
                        #region 获取发送账号及密码
                        EnterpriseService config = new EnterpriseService();
                        SmsEnterpriseCfgInfo configmodel = config.GetModelWithKey("GateWayUser", item.EnterPriseID);
                        string username = string.Empty;
                        string password = string.Empty;
                        if (configmodel == null)
                        {
                            Print("当前企业的账号为空：" + item.EnterPriseID + "");

                        }
                        else
                        {
                            username = configmodel.CfgValue;
                        }
                        #endregion
                        
                        configmodel = config.GetModelWithKey("GateWayPwd", item.EnterPriseID);
                        if (configmodel == null)
                        {
                            Print("当前企业的密码为空：" + item.EnterPriseID + "");

                        }
                        else
                        {
                            password = configmodel.CfgValue;
                        }  
                        Print("加入队列：" + item.BatchID + "");
                        foreach (var batch in AppContent.SendingBatchs)
                        {
                            if (batch.ID == item.BatchID)
                            {
                              //  item.TaskID = batch.TaskID;
                                item.GatePwd = password;
                                item.GateUser = username;
                            }
                        }
                        AppContent.SendingMts.Enqueue(item);
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
