 

/*
	以下代码为T4自动生成的代码，请不要擅自修改
	生成时间:2013-08-05 22:26:04.6318
	生成机器：WANGJUN
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
    public partial class sms_account: BaseEntity
    {
	  
	    /// <summary>
		///	
		/// </summary>
        [Column(IsKeyProperty = true,AutoIncrement=true)]
		public int ID { get; set; }	
		public  sms_account()
        {
            base.SetIni(this,"sms_account","ID");
        }	
	    /// <summary>
		///	
		/// </summary>
 		public int EnterpriseID { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public string Account { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public string Password { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public string Signature { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public int? Level { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public int? State { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public float? wappush_price { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public float sms_price { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public float? mms_price { get; set; }		
				
		public static class Columns
		{
			public const string ID="ID";					
			public const string EnterpriseID="EnterpriseID";					
			public const string Account="Account";					
			public const string Password="Password";					
			public const string Signature="Signature";					
			public const string Level="Level";					
			public const string State="State";					
			public const string wappush_price="wappush_price";					
			public const string sms_price="sms_price";					
			public const string mms_price="mms_price";					
		}
				 
	}
				 
    /// <summary>
	///	
	/// </summary>
	[Serializable]
    public partial class sms_account_channel: BaseEntity
    {
	  
	    /// <summary>
		///	
		/// </summary>
        [Column(IsKeyProperty = true,AutoIncrement=true)]
		public int ID { get; set; }	
		public  sms_account_channel()
        {
            base.SetIni(this,"sms_account_channel","ID");
        }	
	    /// <summary>
		///	
		/// </summary>
 		public int AccountID { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public int ChannelID { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public int? Channeltype { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public int? Sendproportion { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public DateTime? CreateTime { get; set; }		
				
		public static class Columns
		{
			public const string ID="ID";					
			public const string AccountID="AccountID";					
			public const string ChannelID="ChannelID";					
			public const string Channeltype="Channeltype";					
			public const string Sendproportion="Sendproportion";					
			public const string CreateTime="CreateTime";					
		}
				 
	}
				 
    /// <summary>
	///	
	/// </summary>
	[Serializable]
    public partial class sms_addrecord: BaseEntity
    {
	  
	    /// <summary>
		///	
		/// </summary>
        [Column(IsKeyProperty = true,AutoIncrement=true)]
		public int ID { get; set; }	
		public  sms_addrecord()
        {
            base.SetIni(this,"sms_addrecord","ID");
        }	
	    /// <summary>
		///	
		/// </summary>
 		public int AccountID { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public float? BeforeAdd { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public float? AddMount { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public float? AfterAdd { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public DateTime? CreateTime { get; set; }		
				
		public static class Columns
		{
			public const string ID="ID";					
			public const string AccountID="AccountID";					
			public const string BeforeAdd="BeforeAdd";					
			public const string AddMount="AddMount";					
			public const string AfterAdd="AfterAdd";					
			public const string CreateTime="CreateTime";					
		}
				 
	}
				 
    /// <summary>
	///	
	/// </summary>
	[Serializable]
    public partial class sms_batch: BaseEntity
    {
	  
	    /// <summary>
		///	批次ID
		/// </summary>
        [Column(IsKeyProperty = true,AutoIncrement=true)]
		public int ID { get; set; }	
		public  sms_batch()
        {
            base.SetIni(this,"sms_batch","ID");
        }	
	    /// <summary>
		///	帐号ID
		/// </summary>
 		public int AccountID { get; set; }		
	    /// <summary>
		///	信息状态	0:未发送1:已发送2:暂停发送3:正在发送4:停止发送
		/// </summary>
 		public int? MessageState { get; set; }		
	    /// <summary>
		///	信息内容
		/// </summary>
 		public string SmsContent { get; set; }		
	    /// <summary>
		///	包含条数
		/// </summary>
 		public int? Msgcount { get; set; }		
	    /// <summary>
		///	信息类型	短信:1彩信:2WAPPUSH:3
		/// </summary>
 		public int? Msg_type { get; set; }		
	    /// <summary>
		///	优先级	1最低，5最高
		/// </summary>
 		public int? Level { get; set; }		
	    /// <summary>
		///	是否需要状态报告
		/// </summary>
 		public bool? State_report { get; set; }		
	    /// <summary>
		///	客户扩展码
		/// </summary>
 		public string Custom_num { get; set; }		
	    /// <summary>
		///	发送时间段开始时间
		/// </summary>
 		public DateTime? Begin_time { get; set; }		
	    /// <summary>
		///	发送时间段结束时间
		/// </summary>
 		public DateTime? End_time { get; set; }		
	    /// <summary>
		///	处理完成时间
		/// </summary>
 		public DateTime? Commit_time { get; set; }		
	    /// <summary>
		///	提交时间
		/// </summary>
 		public DateTime? Post_time { get; set; }		
	    /// <summary>
		///	批次状态	0：初始状态1：处理完成
		/// </summary>
 		public int? BatchState { get; set; }		
				
		public static class Columns
		{
			public const string ID="ID";					
			public const string AccountID="AccountID";					
			public const string MessageState="MessageState";					
			public const string SmsContent="SmsContent";					
			public const string Msgcount="Msgcount";					
			public const string Msg_type="Msg_type";					
			public const string Level="Level";					
			public const string State_report="State_report";					
			public const string Custom_num="Custom_num";					
			public const string Begin_time="Begin_time";					
			public const string End_time="End_time";					
			public const string Commit_time="Commit_time";					
			public const string Post_time="Post_time";					
			public const string BatchState="BatchState";					
		}
				 
	}
				 
    /// <summary>
	///	
	/// </summary>
	[Serializable]
    public partial class sms_batch_amount: BaseEntity
    {
	  
	    /// <summary>
		///	
		/// </summary>
        [Column(IsKeyProperty = true,AutoIncrement=true)]
		public int ID { get; set; }	
		public  sms_batch_amount()
        {
            base.SetIni(this,"sms_batch_amount","ID");
        }	
	    /// <summary>
		///	过滤后入库的号码数
		/// </summary>
 		public int? BatchID { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public int? RealAmount { get; set; }		
	    /// <summary>
		///	提交成功数
		/// </summary>
 		public int? SendAmount { get; set; }		
	    /// <summary>
		///	网关收到的成功
		/// </summary>
 		public int? SuccessAmount { get; set; }		
	    /// <summary>
		///	如果是长短信，分段发送时的计划条数，非长短信等于文件记录总数
		/// </summary>
 		public int? PlanSendCount { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public DateTime? CreateTime { get; set; }		
				
		public static class Columns
		{
			public const string ID="ID";					
			public const string BatchID="BatchID";					
			public const string RealAmount="RealAmount";					
			public const string SendAmount="SendAmount";					
			public const string SuccessAmount="SuccessAmount";					
			public const string PlanSendCount="PlanSendCount";					
			public const string CreateTime="CreateTime";					
		}
				 
	}
				 
    /// <summary>
	///	
	/// </summary>
	[Serializable]
    public partial class sms_batch_details: BaseEntity
    {
	  
	    /// <summary>
		///	
		/// </summary>
        [Column(IsKeyProperty = true,AutoIncrement=true)]
		public int ID { get; set; }	
		public  sms_batch_details()
        {
            base.SetIni(this,"sms_batch_details","ID");
        }	
	    /// <summary>
		///	
		/// </summary>
 		public int BatchID { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public string Msg_id { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public int? Sms_type { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public int? ChannelID { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public string phone { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public int? State { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public string State_report { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public DateTime? Submit_time { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public DateTime? Report_time { get; set; }		
				
		public static class Columns
		{
			public const string ID="ID";					
			public const string BatchID="BatchID";					
			public const string Msg_id="Msg_id";					
			public const string Sms_type="Sms_type";					
			public const string ChannelID="ChannelID";					
			public const string phone="phone";					
			public const string State="State";					
			public const string State_report="State_report";					
			public const string Submit_time="Submit_time";					
			public const string Report_time="Report_time";					
		}
				 
	}
				 
    /// <summary>
	///	
	/// </summary>
	[Serializable]
    public partial class sms_batch_mt: BaseEntity
    {
	  
	    /// <summary>
		///	批次ID
		/// </summary>
        [Column(IsKeyProperty = true,AutoIncrement=true)]
		public int ID { get; set; }	
		public  sms_batch_mt()
        {
            base.SetIni(this,"sms_batch_mt","ID");
        }	
	    /// <summary>
		///	帐号ID
		/// </summary>
 		public int AccountID { get; set; }		
	    /// <summary>
		///	信息状态0:未发送1:已发送2:暂停发送3:正在发送4:停止发送
		/// </summary>
 		public int? MessageState { get; set; }		
	    /// <summary>
		///	信息内容
		/// </summary>
 		public string SmsContent { get; set; }		
	    /// <summary>
		///	包含条数
		/// </summary>
 		public int? Msgcount { get; set; }		
	    /// <summary>
		///	信息类型短信:1彩信:2WAPPUSH:3
		/// </summary>
 		public int? Msg_type { get; set; }		
	    /// <summary>
		///	优先级1最低，5最高
		/// </summary>
 		public int? Level { get; set; }		
	    /// <summary>
		///	是否需要状态报告
		/// </summary>
 		public bool? State_report { get; set; }		
	    /// <summary>
		///	客户扩展码
		/// </summary>
 		public string Custom_num { get; set; }		
	    /// <summary>
		///	发送时间段开始时间
		/// </summary>
 		public DateTime? Begin_time { get; set; }		
	    /// <summary>
		///	发送时间段结束时间
		/// </summary>
 		public DateTime? End_time { get; set; }		
	    /// <summary>
		///	处理完成时间
		/// </summary>
 		public DateTime? Commit_time { get; set; }		
	    /// <summary>
		///	提交时间
		/// </summary>
 		public DateTime? Post_time { get; set; }		
	    /// <summary>
		///	批次状态0：初始状态1：处理完成
		/// </summary>
 		public int? BatchState { get; set; }		
				
		public static class Columns
		{
			public const string ID="ID";					
			public const string AccountID="AccountID";					
			public const string MessageState="MessageState";					
			public const string SmsContent="SmsContent";					
			public const string Msgcount="Msgcount";					
			public const string Msg_type="Msg_type";					
			public const string Level="Level";					
			public const string State_report="State_report";					
			public const string Custom_num="Custom_num";					
			public const string Begin_time="Begin_time";					
			public const string End_time="End_time";					
			public const string Commit_time="Commit_time";					
			public const string Post_time="Post_time";					
			public const string BatchState="BatchState";					
		}
				 
	}
				 
    /// <summary>
	///	
	/// </summary>
	[Serializable]
    public partial class sms_blackphone: BaseEntity
    {
	  
	    /// <summary>
		///	
		/// </summary>
        [Column(IsKeyProperty = true,AutoIncrement=true)]
		public int ID { get; set; }	
		public  sms_blackphone()
        {
            base.SetIni(this,"sms_blackphone","ID");
        }	
	    /// <summary>
		///	
		/// </summary>
 		public string Phone { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public DateTime? CreateTime { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public int? OperatorID { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public int? Blacktype { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public string Comment { get; set; }		
				
		public static class Columns
		{
			public const string ID="ID";					
			public const string Phone="Phone";					
			public const string CreateTime="CreateTime";					
			public const string OperatorID="OperatorID";					
			public const string Blacktype="Blacktype";					
			public const string Comment="Comment";					
		}
				 
	}
				 
    /// <summary>
	///	
	/// </summary>
	[Serializable]
    public partial class sms_channel: BaseEntity
    {
	  
	    /// <summary>
		///	
		/// </summary>
        [Column(IsKeyProperty = true,AutoIncrement=true)]
		public int ID { get; set; }	
		public  sms_channel()
        {
            base.SetIni(this,"sms_channel","ID");
        }	
	    /// <summary>
		///	
		/// </summary>
 		public int OperatorID { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public int? ChannelType { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public string ChannelName { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public string ChannelNum { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public int? AvailFlag { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public string HostName { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public string Port { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public bool? Issignal { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public string Identity { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public bool? Ismms { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public bool? Issms { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public bool? Islong_sms { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public bool? Iswappush { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public bool? Isstate_report { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public bool? Ismass_commit { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public bool? IsMo { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public bool? IsExpand { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public int? Max_Expand { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public int? Max_onelength { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public int? Max_length { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public int? MouthMax { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public string Account { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public string Password { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public string Communicatetype { get; set; }		
				
		public static class Columns
		{
			public const string ID="ID";					
			public const string OperatorID="OperatorID";					
			public const string ChannelType="ChannelType";					
			public const string ChannelName="ChannelName";					
			public const string ChannelNum="ChannelNum";					
			public const string AvailFlag="AvailFlag";					
			public const string HostName="HostName";					
			public const string Port="Port";					
			public const string Issignal="Issignal";					
			public const string Identity="Identity";					
			public const string Ismms="Ismms";					
			public const string Issms="Issms";					
			public const string Islong_sms="Islong_sms";					
			public const string Iswappush="Iswappush";					
			public const string Isstate_report="Isstate_report";					
			public const string Ismass_commit="Ismass_commit";					
			public const string IsMo="IsMo";					
			public const string IsExpand="IsExpand";					
			public const string Max_Expand="Max_Expand";					
			public const string Max_onelength="Max_onelength";					
			public const string Max_length="Max_length";					
			public const string MouthMax="MouthMax";					
			public const string Account="Account";					
			public const string Password="Password";					
			public const string Communicatetype="Communicatetype";					
		}
				 
	}
				 
    /// <summary>
	///	
	/// </summary>
	[Serializable]
    public partial class sms_contact: BaseEntity
    {
	  
	    /// <summary>
		///	
		/// </summary>
        [Column(IsKeyProperty = true,AutoIncrement=true)]
		public int ID { get; set; }	
		public  sms_contact()
        {
            base.SetIni(this,"sms_contact","ID");
        }	
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
				
		public static class Columns
		{
			public const string ID="ID";					
			public const string Name="Name";					
			public const string Sex="Sex";					
			public const string Birthday="Birthday";					
			public const string Mobile="Mobile";					
			public const string Comment="Comment";					
			public const string AvailFlag="AvailFlag";					
			public const string IDCard="IDCard";					
			public const string CreateTime="CreateTime";					
		}
				 
	}
				 
    /// <summary>
	///	
	/// </summary>
	[Serializable]
    public partial class sms_contact_group_mapping: BaseEntity
    {
	  
	    /// <summary>
		///	
		/// </summary>
        [Column(IsKeyProperty = true,AutoIncrement=true)]
		public int ID { get; set; }	
		public  sms_contact_group_mapping()
        {
            base.SetIni(this,"sms_contact_group_mapping","ID");
        }	
	    /// <summary>
		///	
		/// </summary>
 		public int ContactpersonID { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public int ContactGroupID { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public string GroupCode { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public int AvailFlag { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public DateTime CreateTime { get; set; }		
				
		public static class Columns
		{
			public const string ID="ID";					
			public const string ContactpersonID="ContactpersonID";					
			public const string ContactGroupID="ContactGroupID";					
			public const string GroupCode="GroupCode";					
			public const string AvailFlag="AvailFlag";					
			public const string CreateTime="CreateTime";					
		}
				 
	}
				 
    /// <summary>
	///	
	/// </summary>
	[Serializable]
    public partial class sms_contactgroup: BaseEntity
    {
	  
	    /// <summary>
		///	
		/// </summary>
        [Column(IsKeyProperty = true,AutoIncrement=true)]
		public int ID { get; set; }	
		public  sms_contactgroup()
        {
            base.SetIni(this,"sms_contactgroup","ID");
        }	
	    /// <summary>
		///	
		/// </summary>
 		public int EnterPriseID { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public string Name { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public string GroupCode { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public string ParentCode { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public int? GroupOrder { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public int AvailFlag { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public DateTime CreateTime { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public int? ParentGroupID { get; set; }		
				
		public static class Columns
		{
			public const string ID="ID";					
			public const string EnterPriseID="EnterPriseID";					
			public const string Name="Name";					
			public const string GroupCode="GroupCode";					
			public const string ParentCode="ParentCode";					
			public const string GroupOrder="GroupOrder";					
			public const string AvailFlag="AvailFlag";					
			public const string CreateTime="CreateTime";					
			public const string ParentGroupID="ParentGroupID";					
		}
				 
	}
				 
    /// <summary>
	///	
	/// </summary>
	[Serializable]
    public partial class sms_contentfilterkey: BaseEntity
    {
	  
	    /// <summary>
		///	
		/// </summary>
        [Column(IsKeyProperty = true,AutoIncrement=true)]
		public int ID { get; set; }	
		public  sms_contentfilterkey()
        {
            base.SetIni(this,"sms_contentfilterkey","ID");
        }	
	    /// <summary>
		///	
		/// </summary>
 		public int? OperatorID { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public string Key { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public int? Keytype { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public DateTime? CreateTime { get; set; }		
				
		public static class Columns
		{
			public const string ID="ID";					
			public const string OperatorID="OperatorID";					
			public const string Key="Key";					
			public const string Keytype="Keytype";					
			public const string CreateTime="CreateTime";					
		}
				 
	}
				 
    /// <summary>
	///	
	/// </summary>
	[Serializable]
    public partial class sms_deductrecord: BaseEntity
    {
	  
	    /// <summary>
		///	
		/// </summary>
        [Column(IsKeyProperty = true,AutoIncrement=true)]
		public int ID { get; set; }	
		public  sms_deductrecord()
        {
            base.SetIni(this,"sms_deductrecord","ID");
        }	
	    /// <summary>
		///	
		/// </summary>
 		public int AccountID { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public int? BatchID { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public float? Price { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public DateTime? Deduct_time { get; set; }		
				
		public static class Columns
		{
			public const string ID="ID";					
			public const string AccountID="AccountID";					
			public const string BatchID="BatchID";					
			public const string Price="Price";					
			public const string Deduct_time="Deduct_time";					
		}
				 
	}
				 
    /// <summary>
	///	
	/// </summary>
	[Serializable]
    public partial class sms_enterprise: BaseEntity
    {
	  
	    /// <summary>
		///	
		/// </summary>
        [Column(IsKeyProperty = true,AutoIncrement=true)]
		public int ID { get; set; }	
		public  sms_enterprise()
        {
            base.SetIni(this,"sms_enterprise","ID");
        }	
	    /// <summary>
		///	
		/// </summary>
 		public string Enterprise_Name { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public string Introduction { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public int? AvailFlag { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public DateTime? CreateTime { get; set; }		
				
		public static class Columns
		{
			public const string ID="ID";					
			public const string Enterprise_Name="Enterprise_Name";					
			public const string Introduction="Introduction";					
			public const string AvailFlag="AvailFlag";					
			public const string CreateTime="CreateTime";					
		}
				 
	}
				 
    /// <summary>
	///	
	/// </summary>
	[Serializable]
    public partial class sms_holiday: BaseEntity
    {
	  
	    /// <summary>
		///	
		/// </summary>
        [Column(IsKeyProperty = true,AutoIncrement=true)]
		public int ID { get; set; }	
		public  sms_holiday()
        {
            base.SetIni(this,"sms_holiday","ID");
        }	
	    /// <summary>
		///	
		/// </summary>
 		public string Name { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public DateTime? Time { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public short? TimeType { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public int? EnterPriseID { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public DateTime? CreateTime { get; set; }		
				
		public static class Columns
		{
			public const string ID="ID";					
			public const string Name="Name";					
			public const string Time="Time";					
			public const string TimeType="TimeType";					
			public const string EnterPriseID="EnterPriseID";					
			public const string CreateTime="CreateTime";					
		}
				 
	}
				 
    /// <summary>
	///	
	/// </summary>
	[Serializable]
    public partial class sms_mo: BaseEntity
    {
	  
	    /// <summary>
		///	
		/// </summary>
        [Column(IsKeyProperty = true,AutoIncrement=true)]
		public int ID { get; set; }	
		public  sms_mo()
        {
            base.SetIni(this,"sms_mo","ID");
        }	
	    /// <summary>
		///	
		/// </summary>
 		public int? AccountID { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public string ReceiveSpid { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public string Phone { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public string Content { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public DateTime? ReceiveTime { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public int? Readed { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public int? Responsed { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public DateTime? CreateTime { get; set; }		
				
		public static class Columns
		{
			public const string ID="ID";					
			public const string AccountID="AccountID";					
			public const string ReceiveSpid="ReceiveSpid";					
			public const string Phone="Phone";					
			public const string Content="Content";					
			public const string ReceiveTime="ReceiveTime";					
			public const string Readed="Readed";					
			public const string Responsed="Responsed";					
			public const string CreateTime="CreateTime";					
		}
				 
	}
				 
    /// <summary>
	///	
	/// </summary>
	[Serializable]
    public partial class sms_operator: BaseEntity
    {
	  
	    /// <summary>
		///	
		/// </summary>
        [Column(IsKeyProperty = true,AutoIncrement=true)]
		public int ID { get; set; }	
		public  sms_operator()
        {
            base.SetIni(this,"sms_operator","ID");
        }	
	    /// <summary>
		///	
		/// </summary>
 		public string OperatorName { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public string Introduction { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public string OperatorArea { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public string ContactNmae { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public string Telphone { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public string Remark { get; set; }		
				
		public static class Columns
		{
			public const string ID="ID";					
			public const string OperatorName="OperatorName";					
			public const string Introduction="Introduction";					
			public const string OperatorArea="OperatorArea";					
			public const string ContactNmae="ContactNmae";					
			public const string Telphone="Telphone";					
			public const string Remark="Remark";					
		}
				 
	}
				 
    /// <summary>
	///	
	/// </summary>
	[Serializable]
    public partial class sms_teleseg: BaseEntity
    {
	  
	    /// <summary>
		///	
		/// </summary>
        [Column(IsKeyProperty = true,AutoIncrement=true)]
		public int ID { get; set; }	
		public  sms_teleseg()
        {
            base.SetIni(this,"sms_teleseg","ID");
        }	
	    /// <summary>
		///	
		/// </summary>
 		public string Phone { get; set; }		
	    /// <summary>
		///	
		/// </summary>
 		public int? Carrier_ID { get; set; }		
				
		public static class Columns
		{
			public const string ID="ID";					
			public const string Phone="Phone";					
			public const string Carrier_ID="Carrier_ID";					
		}
				 
	}
				 

