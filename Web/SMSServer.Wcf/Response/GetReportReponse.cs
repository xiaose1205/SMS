using System.Collections.Generic;
using SMSServer.Wcf.Models;

namespace SMSServer.Wcf.Response
{
    public class GetReportReponse : BaseResponse
    {
        /// <summary>
        /// 执行结果
        /// </summary>
        public List<ReportModel> reportModels { get; set; }
    }
}
