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
public partial class SmsChannelInfo: BaseEntity
{
    public SmsChannelInfo(){
         base.SetIni(this,"sms_channel","ID");
    }
    /// <summary>
    ///    
    /// </summary>
    [Column(IsKeyProperty = true,AutoIncrement=true)]
    public int ID {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public int OperatorID {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public int? ChannelType {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public string ChannelName {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public string ChannelNum {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public int? AvailFlag {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public string HostName {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public string Port {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public bool? Issignal {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public string Identity {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public bool? Ismms {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public bool? Issms {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public bool? IslongSms {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public bool? Iswappush {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public bool? IsstateReport {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public bool? IsmassCommit {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public bool? IsMo {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public bool? IsExpand {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public int? MaxExpand {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public int? MaxOnelength {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public int? MaxLength {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public int? MouthMax {get; set;}

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
    public string Communicatetype {get; set;}

    public static class Columns 
    { 
        public const string ID = "ID";
        public const string OperatorID = "OperatorID";
        public const string ChannelType = "ChannelType";
        public const string ChannelName = "ChannelName";
        public const string ChannelNum = "ChannelNum";
        public const string AvailFlag = "AvailFlag";
        public const string HostName = "HostName";
        public const string Port = "Port";
        public const string Issignal = "Issignal";
        public const string Identity = "Identity";
        public const string Ismms = "Ismms";
        public const string Issms = "Issms";
        public const string IslongSms = "Islong_sms";
        public const string Iswappush = "Iswappush";
        public const string IsstateReport = "Isstate_report";
        public const string IsmassCommit = "Ismass_commit";
        public const string IsMo = "IsMo";
        public const string IsExpand = "IsExpand";
        public const string MaxExpand = "Max_Expand";
        public const string MaxOnelength = "Max_onelength";
        public const string MaxLength = "Max_length";
        public const string MouthMax = "MouthMax";
        public const string Account = "Account";
        public const string Password = "Password";
        public const string Communicatetype = "Communicatetype";
    }
}
