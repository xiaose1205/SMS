using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMSServer.Wcf.Models
{
    /// <summary>
    /// 上行信息获取
    /// </summary>
    public class MoModel
    {
        public string Mobile { get; set; }
        public DateTime RecTime { get; set; }
        public string Content { get; set; }
        public long MsgID { get; set; }
    }
}
