/*
以下代码为python3.0自动生成的代码，请不要擅自修改
生成时间:2013-08-24 01:55:32
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
public partial class SmsTemplateInfo: BaseEntity
{
    public SmsTemplateInfo(){
         base.SetIni(this,"sms_template","ID");
    }
    /// <summary>
    ///    
    /// </summary>
    [Column(IsKeyProperty = true,AutoIncrement=true)]
    public string ID {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public string EnterpriseID {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public string SmsContent {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public DateTime? CreateTime {get; set;}

    public static class Columns 
    { 
        public const string ID = "ID";
        public const string EnterpriseID = "EnterpriseID";
        public const string SmsContent = "SmsContent";
        public const string CreateTime = "CreateTime";
    }
}
