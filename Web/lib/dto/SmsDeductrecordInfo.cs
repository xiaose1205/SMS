/*
以下代码为python3.0自动生成的代码，请不要擅自修改
生成时间:2013-08-05 23:25:44
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
public partial class SmsDeductrecordInfo: BaseEntity
{
    public SmsDeductrecordInfo(){
         base.SetIni(this,"sms_deductrecord","ID");
    }
    /// <summary>
    ///    
    /// </summary>
    [Column(IsKeyProperty = true,AutoIncrement=true)]
    public int ID {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public int AccountID {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public int? BatchID {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public float? Price {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public DateTime? DeductTime {get; set;}

    public static class Columns 
    { 
        public const string ID = "ID";
        public const string AccountID = "AccountID";
        public const string BatchID = "BatchID";
        public const string Price = "Price";
        public const string DeductTime = "Deduct_time";
    }
}
