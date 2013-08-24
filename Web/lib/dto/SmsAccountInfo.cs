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
public partial class SmsAccountInfo: BaseEntity
{
    public SmsAccountInfo(){
         base.SetIni(this,"sms_account","ID");
    }
    /// <summary>
    ///    
    /// </summary>
    [Column(IsKeyProperty = true,AutoIncrement=true)]
    public int ID {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public int EnterpriseID {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public string Account {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public string Password {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public string Signature {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public int? Level {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public int? State {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public float? WappushPrice {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public float SmsPrice {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public float? MmsPrice {get; set;}

    public static class Columns 
    { 
        public const string ID = "ID";
        public const string EnterpriseID = "EnterpriseID";
        public const string Account = "Account";
        public const string Password = "Password";
        public const string Signature = "Signature";
        public const string Level = "Level";
        public const string State = "State";
        public const string WappushPrice = "wappush_price";
        public const string SmsPrice = "sms_price";
        public const string MmsPrice = "mms_price";
    }
}
