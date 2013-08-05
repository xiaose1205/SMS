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
public partial class SmsOperatorInfo: BaseEntity
{
    public SmsOperatorInfo(){
         base.SetIni(this,"sms_operator","ID");
    }
    /// <summary>
    ///    
    /// </summary>
    [Column(IsKeyProperty = true,AutoIncrement=true)]
    public int ID {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public string OperatorName {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public string Introduction {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public string OperatorArea {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public string ContactNmae {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public string Telphone {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public string Remark {get; set;}

    public static class Columns 
    { 
        public const string ID = "ID";
        public const string OperatorName = "OperatorName";
        public const string Introduction = "Introduction";
        public const string OperatorArea = "OperatorArea";
        public const string ContactNmae = "ContactNmae";
        public const string Telphone = "Telphone";
        public const string Remark = "Remark";
    }
}
