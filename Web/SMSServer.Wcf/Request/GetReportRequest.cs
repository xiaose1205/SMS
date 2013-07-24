using System;

namespace SMSServer.Wcf.Request
{
    public class GetReportRequest
    {
        public GetReportRequest()
        {
            GetCount = 0;
            StartTime = 0;
            EndTime = 0;
        }

        /// <summary>
        /// 获取的数目
        /// </summary>
        public Nullable<int> GetCount { get; set; }

        /// <summary>
        /// 起始时间
        /// </summary>
        public Nullable<int> StartTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public Nullable<int> EndTime { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string Mobile { get; set; }
    }
}
