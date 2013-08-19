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
using System.Web;
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
            HttpCookie cookie = new HttpCookie("userid", user.ID.ToString());
            cookie.Expires = expriseTime;

            HttpContext.Current.Request.Cookies.Add(cookie);
            cookie = new HttpCookie("account", user.Account);
            cookie.Expires = expriseTime;
            HttpContext.Current.Request.Cookies.Add(cookie);
        }
        /// <summary>
        /// 获取当前的用户的iD跟UserName
        /// </summary>
        /// <returns></returns>
        public SmsAccountInfo GetCurrentUser()
        {
            var httpCookie1 = HttpContext.Current.Request.Cookies["userid"];
            if (httpCookie1 != null && !string.IsNullOrEmpty(httpCookie1.Value))
            {
                SmsAccountInfo user = new SmsAccountInfo();
                var httpCookie = HttpContext.Current.Request.Cookies["userid"];
                if (httpCookie != null)
                    user.ID = int.Parse(httpCookie.Value);
                var cookie = HttpContext.Current.Request.Cookies["account"];
                if (cookie != null)
                    user.Account = cookie.Value;
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
    }
}
