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
public partial class SmsAddrecordInfo: BaseEntity
{
    public SmsAddrecordInfo(){
         base.SetIni(this,"sms_addrecord","ID");
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
    public float? BeforeAdd {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public float? AddMount {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public float? AfterAdd {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public DateTime? CreateTime {get; set;}

    public static class Columns 
    { 
        public const string ID = "ID";
        public const string AccountID = "AccountID";
        public const string BeforeAdd = "BeforeAdd";
        public const string AddMount = "AddMount";
        public const string AfterAdd = "AfterAdd";
        public const string CreateTime = "CreateTime";
    }
}
