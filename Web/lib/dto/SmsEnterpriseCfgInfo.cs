/*
以下代码为python3.0自动生成的代码，请不要擅自修改
生成时间:2013-08-27 23:40:27
生成机器：wangjun
author：xiaose
*/
using System;
using System.Collections.Generic; 
using System.Text;
using HelloData.FrameWork.Data;
/// <summary>
///    
/// </summary>
[Serializable]
public partial class SmsEnterpriseCfgInfo: BaseEntity
{
    public SmsEnterpriseCfgInfo(){
         base.SetIni(this,"sms_enterprise_cfg","ID");
    }
    /// <summary>
    ///    
    /// </summary>
    [Column(IsKeyProperty = true,AutoIncrement=true)]
    public int ID {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public int? EnterpriseID {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public string CfgKey {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public string CfgValue {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public DateTime? CreateTime {get; set;}

    public static class Columns 
    { 
        public const string ID = "ID";
        public const string EnterpriseID = "EnterpriseID";
        public const string CfgKey = "CfgKey";
        public const string CfgValue = "CfgValue";
        public const string CreateTime = "CreateTime";
    }
}
