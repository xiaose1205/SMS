using System.Collections.Generic;
using SMSServer.Wcf.Models;

namespace SMSServer.Wcf.Response
{
    public class GetResponseResponse : BaseResponse
    {   
        /// <summary>
        /// 执行结果
        /// </summary>
        public List<ResponseModel> ReportModels { get; set; }
    }
}
