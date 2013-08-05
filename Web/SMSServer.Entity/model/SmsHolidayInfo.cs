/*
以下代码为python3.0自动生成的代码，请不要擅自修改
生成时间:2013-08-05 22:46:09
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
public partial class SmsHolidayInfo: BaseEntity
{
    public SmsHolidayInfo(){
         base.SetIni(this,"sms_holiday","ID");
    }
    /// <summary>
    ///    
    /// </summary>
    [Column(IsKeyProperty = true,AutoIncrement=true)]
    public int ID {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public string Name {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public DateTime? Time {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public int? TimeType {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public int? EnterPriseID {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public DateTime? CreateTime {get; set;}

    public static class Columns 
    { 
        public const string ID = "ID";
        public const string Name = "Name";
        public const string Time = "Time";
        public const string TimeType = "TimeType";
        public const string EnterPriseID = "EnterPriseID";
        public const string CreateTime = "CreateTime";
    }
}
