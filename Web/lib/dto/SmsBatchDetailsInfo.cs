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
public partial class SmsBatchDetailsInfo: BaseEntity
{
    public SmsBatchDetailsInfo(){
         base.SetIni(this,"sms_batch_details","ID");
    }
    /// <summary>
    ///    
    /// </summary>
    [Column(IsKeyProperty = true,AutoIncrement=true)]
    public int ID {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public int BatchID {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public string MsgId {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public int? SmsType {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public int? ChannelID {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public string phone {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public int? State {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public string StateReport {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public DateTime? SubmitTime {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public DateTime? ReportTime {get; set;}

    public static class Columns 
    { 
        public const string ID = "ID";
        public const string BatchID = "BatchID";
        public const string MsgId = "Msg_id";
        public const string SmsType = "Sms_type";
        public const string ChannelID = "ChannelID";
        public const string phone = "phone";
        public const string State = "State";
        public const string StateReport = "State_report";
        public const string SubmitTime = "Submit_time";
        public const string ReportTime = "Report_time";
    }
}
