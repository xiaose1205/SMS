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
public partial class SmsBlackphoneInfo: BaseEntity
{
    public SmsBlackphoneInfo(){
         base.SetIni(this,"sms_blackphone","ID");
    }
    /// <summary>
    ///    
    /// </summary>
    [Column(IsKeyProperty = true,AutoIncrement=true)]
    public int ID {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public string Phone {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public DateTime? CreateTime {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public int EnterpriseID { get; set; }
 

    /// <summary>
    ///    
    /// </summary>
    public string Comment {get; set;}

    public static class Columns 
    { 
        public const string ID = "ID";
        public const string Phone = "Phone";
        public const string CreateTime = "CreateTime";
        public const string EnterpriseID = "EnterpriseID"; 
        public const string Comment = "Comment";
    }
}
