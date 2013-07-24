using System.Collections.Generic;
using SMSServer.Wcf.Models;

namespace SMSServer.Wcf.Response
{
    public class ChargeResponse : BaseResponse
    {
        /// <summary>
        /// 执行结果
        /// </summary>
        public List<MoModel> MoModels { get; set; }
    }
}
