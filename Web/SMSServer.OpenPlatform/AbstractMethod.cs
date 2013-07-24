using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMSServer.OpenPlatform
{
    public abstract class AbstractMethod 
    {
        /// <summary>
        /// 发送短信
        /// </summary>
        /// <returns></returns>
        public abstract string SendSMS(user us);
        /// <summary>
        /// 获取状态报告
        /// </summary>
        /// <returns></returns>
        public abstract string GetStatusreport(user us);
        /// <summary>
        /// 获取余额
        /// </summary>
        /// <returns></returns>
        public abstract string Getbalance(user us);

        /// <summary>
        /// 获取上行
        /// </summary>
        /// <returns></returns>
        public abstract string Getascending(user us);

    }
}
