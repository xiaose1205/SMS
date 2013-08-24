/*
以下代码为python3.0自动生成的代码，请不要擅自修改
生成时间:2013-08-24 01:55:32
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
public partial class SmsContactgroupInfo: BaseEntity
{
    public SmsContactgroupInfo(){
         base.SetIni(this,"sms_contactgroup","ID");
    }
    /// <summary>
    ///    
    /// </summary>
    [Column(IsKeyProperty = true,AutoIncrement=true)]
    public int ID {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public int EnterPriseID {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public string Name {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public string GroupCode {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public string ParentCode {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public int? GroupOrder {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public int AvailFlag {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public DateTime CreateTime {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public int? ParentGroupID {get; set;}

    public static class Columns 
    { 
        public const string ID = "ID";
        public const string EnterPriseID = "EnterPriseID";
        public const string Name = "Name";
        public const string GroupCode = "GroupCode";
        public const string ParentCode = "ParentCode";
        public const string GroupOrder = "GroupOrder";
        public const string AvailFlag = "AvailFlag";
        public const string CreateTime = "CreateTime";
        public const string ParentGroupID = "ParentGroupID";
    }
}
