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
        public abstract int SendSMS( SMSSDKMassInfo smsInfos, string extendNub);
        /// <summary>
        /// 发送短信
        /// </summary>
        /// <returns></returns>
        public abstract int SendSMS( List<SDKGroupInfo> smsInfos, string extendNub);
        /// <summary>
        /// 获取状态报告
        /// </summary>
        /// <returns></returns>
        public abstract string GetStatusreport();
        /// <summary>
        /// 获取余额
        /// </summary>
        /// <returns></returns>
        public abstract string Getbalance();

        /// <summary>
        /// 获取上行
        /// </summary>
        /// <returns></returns>
        public abstract string Getascending();



        public abstract SendUser SendUser { get; set; }

        public abstract int GetSignNum();

        public abstract List<MoInfo> GetMo();
        /// <summary>
        /// mass的发送大小
        /// </summary>
        /// <returns></returns>
        public abstract int MassCount();
        /// <summary>
        /// group发送大小
        /// </summary>
        /// <returns></returns>
        public abstract int GroupCount();
    }
}
