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
        public List< SendingBatchModel> GetReadyBatch(int batchCount)
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
        public List<SmsBatchWaitInfo> GetReadyMt(int p1, string p2)
        {
            throw new NotImplementedException();
        }

        public bool CheckUser(int p)
        {
            throw new NotImplementedException();
        }

        public void UpdateBatchState(SMSService.Entity.BatchState batchState, int p)
        {
            throw new NotImplementedException();
        }

        public void RemoveToMt(SmsBatchWaitInfo model, SMSService.Entity.SendingBatchModel sendingmodel, SMSService.Entity.SendResultEnum sendResultEnum)
        {
            throw new NotImplementedException();
        }

        public void WriteBatchDetial(List<string> phones, string content)
        {
            throw new NotImplementedException();
        }
    }
}
