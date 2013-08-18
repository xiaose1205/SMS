using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMSServer.OpenPlatform
{
    /// <summary>
    /// 无极限接口实现
    /// </summary>
    public class WJXService : BaseService
    {
       
       /// <summary>
       /// 短信发送
       /// </summary>
       /// <param name="us"></param>
       /// <returns></returns>
        public override int SendSMS(SendUser usr,SMSMassInfo smsInfos)
        {
            HttpHelper Sendhttp = new HttpHelper();
            Sendhttp.WEncoding = Encoding.UTF8;
             Sendhttp.ParMTReport(Sendhttp.ResultPamrs(Sendhttp.GetWebServiceStr(usr.url, usr.method, Sendhttp.CreateSoap(usr)), usr.method)).ToString();
           return 0;
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

        public override SendUser GetUser()
        {
            throw new NotImplementedException();
        }

        public override int GetSignNum()
        {
            throw new NotImplementedException();
        }

        public override List<MoInfo> GetMo()
        {
            throw new NotImplementedException();
        }

        public override int MassCount()
        {
            throw new NotImplementedException();
        }

        public override int GroupCount()
        {
            throw new NotImplementedException();
        }

        public override int SendSMS(SendUser us, SMSGroupInfo smsInfos)
        {
            throw new NotImplementedException();
        }
    }
}
