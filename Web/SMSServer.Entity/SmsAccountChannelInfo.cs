/*
以下代码为python3.0自动生成的代码，请不要擅自修改
生成时间:2013-08-04 00:47:32
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
public partial class SmsAccountChannelInfo: BaseEntity
{
    public SmsAccountChannelInfo(){
         base.SetIni(this,"sms_account_channel","ID");
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
    public int ChannelID {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public int? Channeltype {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public int? Sendproportion {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public DateTime? CreateTime {get; set;}

    public static class Columns 
    { 
        public const string ID = "ID";
        public const string AccountID = "AccountID";
        public const string ChannelID = "ChannelID";
        public const string Channeltype = "Channeltype";
        public const string Sendproportion = "Sendproportion";
        public const string CreateTime = "CreateTime";
    }
}
