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
public partial class SmsBatchInfo: BaseEntity
{
    public SmsBatchInfo(){
         base.SetIni(this,"sms_batch","ID");
    }
    /// <summary>
    /// ??ID   
    /// </summary>
    [Column(IsKeyProperty = true,AutoIncrement=true)]
    public int ID {get; set;}

    /// <summary>
    /// ??ID   
    /// </summary>
    public int AccountID {get; set;}

    /// <summary>
    /// ????	0:??? 1:??? 2:???? 3:???? 4:????   
    /// </summary>
    public int? MessageState {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public string BatchName {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public string Remark {get; set;}

    /// <summary>
    /// ????   
    /// </summary>
    public string SmsContent {get; set;}

    /// <summary>
    /// ????   
    /// </summary>
    public int? Msgcount {get; set;}

    /// <summary>
    /// ????	??: 1??: 2WAPPUSH: 3   
    /// </summary>
    public int? Msgtype {get; set;}

    /// <summary>
    /// ???	1???5??   
    /// </summary>
    public int? Level {get; set;}

    /// <summary>
    /// ????????   
    /// </summary>
    public bool? Statereport {get; set;}

    /// <summary>
    /// ?????   
    /// </summary>
    public string Customnum {get; set;}

    /// <summary>
    /// ????? ????   
    /// </summary>
    public DateTime? Begintime {get; set;}

    /// <summary>
    /// ????? ????   
    /// </summary>
    public DateTime? Endtime {get; set;}

    /// <summary>
    /// ??????   
    /// </summary>
    public DateTime? Committime {get; set;}

    /// <summary>
    /// ????   
    /// </summary>
    public DateTime? Posttime {get; set;}

    /// <summary>
    /// ????	0? ????1? ????   
    /// </summary>
    public int? BatchState {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public int? MtCount {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public int? EnterPriseID {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public DateTime? Createtime {get; set;}

    public static class Columns 
    { 
        public const string ID = "ID";
        public const string AccountID = "AccountID";
        public const string MessageState = "MessageState";
        public const string BatchName = "BatchName";
        public const string Remark = "Remark";
        public const string SmsContent = "SmsContent";
        public const string Msgcount = "Msgcount";
        public const string Msgtype = "Msgtype";
        public const string Level = "Level";
        public const string Statereport = "Statereport";
        public const string Customnum = "Customnum";
        public const string Begintime = "Begintime";
        public const string Endtime = "Endtime";
        public const string Committime = "Committime";
        public const string Posttime = "Posttime";
        public const string BatchState = "BatchState";
        public const string MtCount = "MtCount";
        public const string EnterPriseID = "EnterPriseID";
        public const string Createtime = "Createtime";
    }
}
