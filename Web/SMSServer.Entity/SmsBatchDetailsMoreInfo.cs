#region Version Info
/* ========================================================================
* 【本类功能概述】
* 
* 作者：王军 时间：2013/8/21 23:35:44
* 文件名：SmsBatchDetailsMoreInfo
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
    public class SmsBatchDetailsMoreInfo:SmsBatchDetailsInfo
    {
        public string BatchName { get; set; }
    }
}
