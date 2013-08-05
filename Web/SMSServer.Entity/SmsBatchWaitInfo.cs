#region Version Info
/* ========================================================================
* 【本类功能概述】
* 
* 作者：王军 时间：2013/8/5 23:27:31
* 文件名：SmsBatchWaitInfo
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
using HelloData.FrameWork.Data;


public partial class SmsBatchWaitInfo
{
    [Column(NoSqlProperty = true)]
    public string GatePwd { get; set; }
    [Column(NoSqlProperty = true)]
    public string GateUser { get; set; }
}
