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
public partial class SmsContactGroupMappingInfo: BaseEntity
{
    public SmsContactGroupMappingInfo(){
         base.SetIni(this,"sms_contact_group_mapping","ID");
    }
    /// <summary>
    ///    
    /// </summary>
    [Column(IsKeyProperty = true,AutoIncrement=true)]
    public int ID {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public int ContactpersonID {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public int ContactGroupID {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public string GroupCode {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public int AvailFlag {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public DateTime CreateTime {get; set;}

    public static class Columns 
    { 
        public const string ID = "ID";
        public const string ContactpersonID = "ContactpersonID";
        public const string ContactGroupID = "ContactGroupID";
        public const string GroupCode = "GroupCode";
        public const string AvailFlag = "AvailFlag";
        public const string CreateTime = "CreateTime";
    }
}
