﻿#region Version Info
/* ========================================================================
* 【本类功能概述】
* 
* 作者：王军 时间：2013/8/13 21:36:23
* 文件名：SMSInfo
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

namespace SMSServer.OpenPlatform
{
    public class SMSSDKGroupInfo
    {
        public List<SDKGroupInfo> groupInfos { get; set; }
    }

    public class SDKGroupInfo
    {
        public string Phone { get; set; }
        public string Content { get; set; }
    }


    public class SMSSDKMassInfo
    {
        public List<string> Phones { get; set; }
        public string Content { get; set; }
    }
}
