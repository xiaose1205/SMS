#region Version Info
/* ========================================================================
* 【本类功能概述】
* 
* 作者：王军 时间：2013/8/5 22:49:55
* 文件名：ContentParms
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
    public class ContentParms
    {
        /// <summary>
        /// 文件对应索引，联系人对应字段列名
        /// </summary>
        public object Key { get; set; }
        /// <summary>
        /// 切换的参数
        /// </summary>
        public string Value { get; set; }
    }
}
