#region Version Info
/* ========================================================================
* 【本类功能概述】
* 
* 作者：王军 时间：2013/8/5 22:51:46
* 文件名：BatchService
* 版本：V1.0.1
* 联系方式：511522329  
*
* 修改者： 时间： 
* 修改说明：
* ========================================================================
*/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMSServer.Logic;
using SMSService.Entity;

namespace SMSServer.Service
{
    public class BatchService
    {
        public List<SendingBatchModel> GetReadyBatch(int batchCount)
        {
            List<SendingBatchModel> infos = SmsBatchManage.Instance.GetReadyBatch(batchCount);
            return infos;
        }
        /// <summary>
        /// 获取待发的批次
        /// 
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public List<SmsBatchWaitInfo> GetReadyMt(int batchWaitCount, string batchids)
        {
            return SmsBatchManage.Instance.GetReadyMt(batchWaitCount, batchids);
        }

        public bool CheckUser(int accountId)
        {
            SmsAccountInfo info = SmsAccountManage.Instance.FindById(accountId);
            if (info == null || info.State == 0)
                return false;
            return true;
        }

        public void UpdateBatchState(BatchState batchState, int batchid)
        {
            SmsBatchManage.Instance.UpdateState(batchid, batchState,-1);
        }

        public void RemoveToMt(SmsBatchWaitInfo model)
        {
            SmsBatchManage.Instance.deleteMt(model.ID);
        }



        public void WriteBatchDetial(List<SmsBatchDetailsInfo> infos)
        {
            SmsBatchDetailsManage.Instance.AddList(infos);
        }
    }
}
