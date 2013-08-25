/*
以下代码为python3.0自动生成的代码，请不要擅自修改
生成时间:2013-08-20 23:56:34
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
public partial class SmsContentfilterkeyInfo: BaseEntity
{
    public SmsContentfilterkeyInfo(){
         base.SetIni(this,"sms_contentfilterkey","ID");
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
    public string Keyword { get; set; }

    /// <summary>
    ///    
    /// </summary>
    public int? Keytype {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public DateTime? CreateTime {get; set;}

    public static class Columns 
    { 
        public const string ID = "ID";
        public const string EnterpriseID = "EnterpriseID";
        public const string Keyword = "Keyword";
        public const string Keytype = "Keytype";
        public const string CreateTime = "CreateTime";
    }
}
