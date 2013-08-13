#region Version Info
/* ========================================================================
* 【本类功能概述】
* 
* 作者：王军 时间：2013/8/6 23:39:33
* 文件名：BatchState
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
    /// <summary>
    /// 批次状态 0提交中  1:检核中  2:等待中 3发送中  4完成
    /// </summary>
    public enum BatchState
    {
        /// <summary>
        /// 提交中
        /// </summary>
        Submit = 0,
        /// <summary>
        /// 检核中
        /// </summary>
        Checking = 1,
        /// <summary>
        /// 等待中
        /// </summary>
        Waiting = 2,
        /// <summary>
        /// 发送中
        /// </summary>
        Sending = 3,
        /// <summary>
        /// 完成
        /// </summary>
        Complete = 4
    }
}
