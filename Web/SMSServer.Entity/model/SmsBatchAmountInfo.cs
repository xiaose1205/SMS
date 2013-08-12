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
public partial class SmsBatchAmountInfo: BaseEntity
{
    public SmsBatchAmountInfo(){
         base.SetIni(this,"sms_batch_amount","ID");
    }
    /// <summary>
    ///    
    /// </summary>
    [Column(IsKeyProperty = true,AutoIncrement=true)]
    public int ID {get; set;}

    /// <summary>
    /// ?????????   
    /// </summary>
    public int? BatchID {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public int? RealAmount {get; set;}

    /// <summary>
    /// ?????   
    /// </summary>
    public int? SendAmount {get; set;}

    /// <summary>
    /// ???????   
    /// </summary>
    public int? SuccessAmount {get; set;}

    /// <summary>
    /// ??????????????????????????????   
    /// </summary>
    public int? PlanSendCount {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public DateTime? CreateTime {get; set;}

    public static class Columns 
    { 
        public const string ID = "ID";
        public const string BatchID = "BatchID";
        public const string RealAmount = "RealAmount";
        public const string SendAmount = "SendAmount";
        public const string SuccessAmount = "SuccessAmount";
        public const string PlanSendCount = "PlanSendCount";
        public const string CreateTime = "CreateTime";
    }
}
