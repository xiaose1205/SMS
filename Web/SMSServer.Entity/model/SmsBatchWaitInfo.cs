/*
以下代码为python3.0自动生成的代码，请不要擅自修改
生成时间:2013-08-09 21:48:23
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
public partial class SmsBatchWaitInfo: BaseEntity
{
    public SmsBatchWaitInfo(){
         base.SetIni(this,"sms_batch_wait","ID");
    }
    /// <summary>
    ///    
    /// </summary>
    [Column(IsKeyProperty = true,AutoIncrement=true)]
    public int ID {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public int? MtID {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public int? BatchID {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public DateTime? CreateTime {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public int? AccountID {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public int? MsgCount {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public string MsgPack {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public int MsgType {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public int EnterPriseID {get; set;}

    public static class Columns 
    { 
        public const string ID = "ID";
        public const string MtID = "MtID";
        public const string BatchID = "BatchID";
        public const string CreateTime = "CreateTime";
        public const string AccountID = "AccountID";
        public const string MsgCount = "MsgCount";
        public const string MsgPack = "MsgPack";
        public const string MsgType = "MsgType";
        public const string EnterPriseID = "EnterPriseID";
    }
}
