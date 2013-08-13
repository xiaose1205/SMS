﻿#region Version Info
/* ========================================================================
* 【本类功能概述】
* 
* 作者：王军 时间：2013/8/13 22:07:44
* 文件名：SMSPack
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

    public class SMSDetial
    {
        public string phone { get; set; }
        public string content { get; set; }
    }

    public class SMSGroup
    {
        public List<SMSDetial> detials { get; set; }
    }

    public class SMSMass
    {
        public string content { get; set; }
        public List<string> phones { get; set; }
    }

    public enum SMSEnum
    {
        Group = 0,
        Mass = 1
    }
}
