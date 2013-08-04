/*
以下代码为python3.0自动生成的代码，请不要擅自修改
生成时间:2013-08-04 23:18:00
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
public partial class SmsEnterpriseInfo: BaseEntity
{
    public SmsEnterpriseInfo(){
         base.SetIni(this,"sms_enterprise","ID");
    }
    /// <summary>
    ///    
    /// </summary>
    [Column(IsKeyProperty = true,AutoIncrement=true)]
    public int ID {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public string EnterpriseName {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public string Introduction {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public int? AvailFlag {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public DateTime? CreateTime {get; set;}

    public static class Columns 
    { 
        public const string ID = "ID";
        public const string EnterpriseName = "Enterprise_Name";
        public const string Introduction = "Introduction";
        public const string AvailFlag = "AvailFlag";
        public const string CreateTime = "CreateTime";
    }
}
