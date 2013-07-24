using SMSServer.Wcf.Models;

namespace SMSServer.Wcf.Response
{
    public class GetAccountInfoResponse : BaseResponse
    {
        /// <summary>
        /// 执行结果
        /// </summary>
        public AccountModel AccountInfo { get; set; }
    }
}
