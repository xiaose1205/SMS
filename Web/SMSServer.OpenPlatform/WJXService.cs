using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMSServer.OpenPlatform
{
    /// <summary>
    /// 无极限接口实现
    /// </summary>
    public class WJXService : BaseMethod
    {
       
       /// <summary>
       /// 短信发送
       /// </summary>
       /// <param name="us"></param>
       /// <returns></returns>
        public override string SendSMS(SendUser usr)
        {
            HttpHelper Sendhttp = new HttpHelper();
            Sendhttp.WEncoding = Encoding.UTF8;
            return Sendhttp.ParMTReport(Sendhttp.ResultPamrs(Sendhttp.GetWebServiceStr(usr.url, usr.method, Sendhttp.CreateSoap(usr)), usr.method)).ToString();
        }

        /// <summary>
        /// 状态报告
        /// </summary>
        /// <param name="us"></param>
        /// <returns></returns>
        public override string GetStatusreport(SendUser us)
        {
            throw new NotImplementedException();
        }

        public override string Getbalance(SendUser us)
        {
            return "无极限没有提供该接口";
        }
        /// <summary>
        /// 获取上行
        /// </summary>
        /// <param name="us"></param>
        /// <returns></returns>
        public override string Getascending(SendUser us)
        {
            throw new NotImplementedException();
        }
    }
}
