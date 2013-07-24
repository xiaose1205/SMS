using System;
using SMSServer.Models;

namespace SMSServer.Wcf.Response
{
    /// <summary>
    /// 操作的结果码
    /// </summary>
    public class BaseResponse
    {
        public BaseResponse()
        {
            ADateTime = DateTime.Now;
            Code = (int) ResponseCodeEnum.SUCCESS;
            Message = string.Empty;
        }
        /// <summary>
        /// 结果码
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// 错误的信息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 错误处理时间
        /// </summary>
        public DateTime ADateTime { get; set; }
    }
}
