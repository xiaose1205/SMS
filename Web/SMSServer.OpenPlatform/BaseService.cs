using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMSServer.OpenPlatform
{
    public abstract class BaseService
    {
        /// <summary>
        /// 发送短信
        /// </summary>
        /// <returns></returns>
        public abstract string SendSMS(SendUser us, List<SMSInfo> smsInfos);
        /// <summary>
        /// 获取状态报告
        /// </summary>
        /// <returns></returns>
        public abstract string GetStatusreport(SendUser us);
        /// <summary>
        /// 获取余额
        /// </summary>
        /// <returns></returns>
        public abstract string Getbalance(SendUser us);

        /// <summary>
        /// 获取上行
        /// </summary>
        /// <returns></returns>
        public abstract string Getascending(SendUser us);



        public abstract SendUser GetUser();

        public abstract int GetSignNum();

        public abstract List<MoInfo> GetMo();
    }
}
