#region Version Info
/* ========================================================================
* 【本类功能概述】
* 
* 作者：王军 时间：2013/8/21 23:51:42
* 文件名：BatchMoreInfo
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

namespace SMSService.Entity
{
    public class BatchMoreInfo : SmsBatchInfo
    {
        /// <summary>
        ///    
        /// </summary>
        public int? RealAmount { get; set; }

        /// <summary>
        /// ?????   
        /// </summary>
        public int? SendAmount { get; set; }

        /// <summary>
        /// ???????   
        /// </summary>
        public int? SuccessAmount { get; set; }

        /// <summary>
        /// ??????????????????????????????   
        /// </summary>
        public int? PlanSendCount { get; set; }

        /// <summary>
        ///    
        /// </summary>
        public DateTime? CreateTime { get; set; }
    }
}
