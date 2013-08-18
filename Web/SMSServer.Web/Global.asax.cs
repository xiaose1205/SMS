using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using HelloData.AppHandlers;
using HelloData.FWCommon.Cache;
using HelloData.FWCommon.Logging;
using HelloData.FrameWork;
using HelloData.FrameWork.Data;
using SMSServer.Service.Ajax;

namespace SMSServer.Web
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            //启动日志模块
            Logger.Current.SetLogger = new LogNet();
            Logger.Current.IsOpenLog = true;
            Logger.CurrentLog.Info("INSTALLING");

            //设置数据库连接执行状况
            AppCons.LogSqlExcu = true;
            //设置第一个数据库
            AppCons.SetDefaultConnect(new MySqlHelper(), ConfigurationManager.AppSettings["ConnectionString"]);
            //是否需要数据库全局参数化
            AppCons.IsParmes = false;
            //是否数据库操作的缓存
            AppCons.IsOpenCache = false;
            //使用第三方的分布式缓存
            //AppCons.CurrentCache =new  RedisCache();
            //使用内置的webcache缓存
            AppCons.CurrentCache = new WebCache();
            //注册ajax
            AppHandlerManager.RegisterAppHandler(new BlackHandler()); 
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}