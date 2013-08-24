/*
以下代码为python3.0自动生成的代码，请不要擅自修改
生成时间:2013-08-24 16:47:10
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
public partial class SmsContactInfo : BaseEntity
{
    public SmsContactInfo()
    {
        base.SetIni(this, "sms_contact", "ID");
    }
    /// <summary>
    ///    
    /// </summary>
    [Column(IsKeyProperty = true, AutoIncrement = true)]
    public int ID { get; set; }

    /// <summary>
    ///    
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    ///    
    /// </summary>
    public int Sex { get; set; }

    /// <summary>
    ///    
    /// </summary>
    public DateTime Birthday { get; set; }

    /// <summary>
    ///    
    /// </summary>
    public string Mobile { get; set; }

    /// <summary>
    ///    
    /// </summary>
    public string Comment { get; set; }

    /// <summary>
    ///    
    /// </summary>
    public int AvailFlag { get; set; }

    /// <summary>
    ///    
    /// </summary>
    public string IDCard { get; set; }

    /// <summary>
    ///    
    /// </summary>
    public DateTime CreateTime { get; set; }

    /// <summary>
    ///    
    /// </summary>
    public int? GroupID { get; set; }

    /// <summary>
    ///    
    /// </summary>
    public string GroupCode { get; set; }

    /// <summary>
    ///    
    /// </summary>
    public int? EnterpriseId { get; set; }

    public static class Columns
    {
        public const string ID = "ID";
        public const string Name = "Name";
        public const string Sex = "Sex";
        public const string Birthday = "Birthday";
        public const string Mobile = "Mobile";
        public const string Comment = "Comment";
        public const string AvailFlag = "AvailFlag";
        public const string IDCard = "IDCard";
        public const string CreateTime = "CreateTime";
        public const string GroupID = "GroupID";
        public const string GroupCode = "GroupCode";
        public const string EnterpriseId = "EnterpriseId";
    }
}
