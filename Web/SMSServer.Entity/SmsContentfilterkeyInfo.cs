/*
以下代码为python3.0自动生成的代码，请不要擅自修改
生成时间:2013-08-04 00:47:32
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
    public int? OperatorID {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public string Key {get; set;}

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
        public const string OperatorID = "OperatorID";
        public const string Key = "Key";
        public const string Keytype = "Keytype";
        public const string CreateTime = "CreateTime";
    }
}
