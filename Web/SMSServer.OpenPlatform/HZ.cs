﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMSServer.OpenPlatform
{
    /// <summary>
    /// 合众接口实现
    /// </summary>
    public class HZ : AbstractMethod
    {
       
        public static string ResultString(string url)
        {
            HttpHelper Sendhttp = new HttpHelper();
            Sendhttp.WEncoding = Encoding.UTF8;
            Sendhttp.IniStalling();
            return Sendhttp.MethodGetHttpStr(url);
        }
        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="usr"></param>
        /// <returns></returns>
        public override string SendSMS(user usr)
        {
            //http://61.143.160.139:8080/smshttp?act=sendmsg&unitid=826&username=DGHK&passwd=123456&msg=测试&phone=13533597705

            string url = "http://61.143.160.139:8080/smshttp?act=sendmsg&";
            url += "unitid=" + usr.unitid + "&username=" + usr.username + "&passwd=" + usr.passwd + "&msg=" + usr.msg + "&phone=" + usr.phone;
            return ResultString(url);
        }
        /// <summary>
        /// 状态报告
        /// </summary>
        /// <param name="usr"></param>
        /// <returns></returns>
        public override string GetStatusreport(user usr)
        {
            //http://61.143.160.139:8080/smshttp?act=getstatue&unitid=826&username=DGHK&passwd=123456

            string url = "http://61.143.160.139:8080/smshttp?act=getstatue&";
            url += "unitid=" + usr.unitid + "&username=" + usr.username + "&passwd=" + usr.passwd;
            return ResultString(url);
        }
        /// <summary>
        /// 获取余额
        /// </summary>
        /// <param name="usr"></param>
        /// <returns></returns>
        public override string Getbalance(user usr)
        {
            //http://61.143.160.139:8080/smshttp?act=getbalance&unitid=826&username=DGHK&passwd=123456

            string url = "http://61.143.160.139:8080/smshttp?act=getbalance&";
            url += "unitid=" + usr.unitid + "&username=" + usr.username + "&passwd=" + usr.passwd;
            return ResultString(url);
        }


        /// <summary>
        /// 获取上行
        /// </summary>
        /// <param name="usr"></param>
        /// <returns></returns>ascending
        public override string Getascending(user usr)
        {
            //http://61.143.160.139:8080/smshttp?act=smsrecord&unitid=826&username=DGHK&passwd=123456

            string url = "http://61.143.160.139:8080/smshttp?act=smsrecord&";
            url += "unitid=" + usr.unitid + "&username=" + usr.username + "&passwd=" + usr.passwd;
            return ResultString(url);
        }
    }
}
