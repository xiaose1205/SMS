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

namespace SMSServer.Service
{
    public class BatchService
    {
        public List<SMSService.Entity.SendingBatchModel> GetReadyBatch(int p)
        {
            throw new NotImplementedException();
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
    }
}
