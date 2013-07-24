using System;

namespace SMSServer.Wcf.Models
{
    public class ReportModel
    {
        /// <summary>
        /// 记录ID
        /// </summary>
        public string ID
        {
            get;
            set;
        }
        /// <summary>
        /// 状态描述
        /// </summary>
        public string Status
        {
            get;
            set;
        }

        /// <summary>
        /// 接收时间
        /// </summary>
        public DateTime ReceiveTime
        {
            get;
            set;
        }
        /// <summary>
        /// 入库时间
        /// </summary>
        public DateTime DoneTime
        {
            get;
            set;
        }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string Phone
        {
            get;
            set;
        }
        /// <summary>
        /// 账号名
        /// </summary>
        public string Account
        {
            get;
            set;
        }
        /// <summary>
        /// 保留字段
        /// </summary>
        public string Reserve
        {
            get;
            set;
        }
    }
}
