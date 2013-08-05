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
public partial class SmsMoInfo: BaseEntity
{
    public SmsMoInfo(){
         base.SetIni(this,"sms_mo","ID");
    }
    /// <summary>
    ///    
    /// </summary>
    [Column(IsKeyProperty = true,AutoIncrement=true)]
    public int ID {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public int? AccountID {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public string ReceiveSpid {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public string Phone {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public string Content {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public DateTime? ReceiveTime {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public int? Readed {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public int? Responsed {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public DateTime? CreateTime {get; set;}

    public static class Columns 
    { 
        public const string ID = "ID";
        public const string AccountID = "AccountID";
        public const string ReceiveSpid = "ReceiveSpid";
        public const string Phone = "Phone";
        public const string Content = "Content";
        public const string ReceiveTime = "ReceiveTime";
        public const string Readed = "Readed";
        public const string Responsed = "Responsed";
        public const string CreateTime = "CreateTime";
    }
}
