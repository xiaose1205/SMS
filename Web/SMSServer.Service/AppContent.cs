#region Version Info
/* ========================================================================
* 【本类功能概述】
* 
* 作者：王军 时间：2013/8/5 21:52:55
* 文件名：AppContent
* 版本：V1.0.1
* 联系方式：511522329  
*
* 修改者： 时间： 
* 修改说明：
* ========================================================================
*/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using HelloData.Util;
using SMSService.Entity;

namespace SMSServer.Service
{
    public class AppContent
    {
        /// <summary>
        /// 读取批次表的时间间隔
        /// </summary>
        public static int ReadBatch { get; set; }
        /// <summary>
        /// 读取任务表的时间间隔
        /// </summary>
        public static int ReadTask { get; set; }

        /// <summary>
        /// 读取发送队列的时间间隔
        /// </summary>
        public static int ReadSender { get; set; }

        /// <summary>
        /// 每次读取批次的数量
        /// </summary>
        public static int ReadBatchCount { get; set; }
        /// <summary>
        /// 每次打包的数量
        /// </summary>
        public static int SendPackCount { get; set; }

        /// <summary>
        /// 发送mt包的数量
        /// </summary>
        public static int SendMtCount { get; set; }

        /// <summary>
        /// 是否启动debug
        /// </summary>
        public static bool Debug { get; set; }
        /// <summary>
        /// 待发中的批次
        /// </summary>
        public static List<SendingBatchModel> SendingBatchs = new List<SendingBatchModel>();
        /// <summary>
        /// 待发中的mt
        /// </summary>
        public static Queue<SmsBatchWaitInfo> SendingMts = new Queue<SmsBatchWaitInfo>();

        public static string InfoWay { get; set; }
        public static int InfoWayPort { get; set; }
        public static string GateWay { get; set; }
        public static int GateWayPort { get; set; }


        public static int MoReceive { get; set; }
        public static bool IsMoReceive { get; set; }
        /// <summary>
        /// 发送的参数
        /// </summary>
        public static List<ContentParms> ParmsList
        {
            get;
            set;
        }
        public static int SmsSendMaxThreads
        {
            get;
            set;
        }

        //public static string ParmsModel = "#{0}#";
        public static string ParmsModel = "@{0}";

        /// <summary>
        /// 唯一实例
        /// </summary>
        class Currentset
        {
            static Currentset()
            {
            }
            internal static readonly AppContent Instance = new AppContent();
        }
        public static AppContent Current
        {
            get { return Currentset.Instance; }
        }
        /// <summary>
        /// 用户的登录处理
        /// </summary>
        /// <param name="user"></param>
        /// <param name="expriseTime"></param>
        public void LoginUser(SmsAccountInfo user, DateTime expriseTime)
        {
            Cookie.SaveCookie("userid", user.ID.ToString(), 20);
            Cookie.SaveCookie("account", user.Account, 20);

        }
        /// <summary>
        /// 获取当前的用户的iD跟UserName
        /// </summary>
        /// <returns></returns>
        public SmsAccountInfo GetCurrentUser()
        {

            if (!string.IsNullOrEmpty(Cookie.GetCookie("userid")))
            {
                SmsAccountInfo user = new SmsAccountInfo();
                var httpCookie = Cookie.GetCookie("userid");
                if (httpCookie != null)
                    user.ID = int.Parse(httpCookie);
                var cookie = Cookie.GetCookie("account");
                if (cookie != null)
                    user.Account = cookie;
                user.EnterpriseID = 1;
                return user;
            }
            return null;

        }
        /// <summary>
        /// 退出登录
        /// </summary>
        /// <param name="user"></param>
        public void LogoutUser()
        {
            HttpContext.Current.Request.Cookies.Remove("userID");
            HttpContext.Current.Request.Cookies.Remove("userName");
        }

        public static bool isPhone(string phone)
        {
            Regex objRegExp = new Regex(@"^1(3[0-9]|5[0-9]|8[0-9])\d{8}$", RegexOptions.IgnoreCase);
            return objRegExp.IsMatch(phone);

        }
    }
}
