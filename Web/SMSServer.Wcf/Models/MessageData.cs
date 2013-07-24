using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMSServer.Wcf.Models
{
    /// <summary>
    /// 单条发送内容
    /// </summary>
    public class MessageData
    {
        /// <summary>
        /// 手机号码
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 发送内容
        /// </summary>
        public string Content { get; set; }
        public MessageData()
        {
        }
        public MessageData(string mobile, string content)
        {
            this.Mobile = mobile;
            this.Content = content;
        }
    }
}
