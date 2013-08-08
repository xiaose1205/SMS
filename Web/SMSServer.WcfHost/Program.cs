using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceProcess;
using HelloData.FWCommon.Cache;
using HelloData.FWCommon.Logging;
using HelloData.FrameWork;
using HelloData.FrameWork.Data;
using System.Configuration;
using SMSServer.OpenPlatform;
using SMSServer.Wcf;

namespace SMSServer.WcfHost
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main()
        {
            bool debugLog = bool.Parse(ConfigurationManager.AppSettings["Debug"].ToString());
            if (debugLog)
            {
                //启动日志模块
                Logger.Current.SetLogger = new ConsoleLog();
                Logger.Current.IsOpenLog = true;
                Logger.CurrentLog.Info("INSTALLING");
            }
            else
            {
                Logger.Current.SetLogger = new LogNet();
                Logger.Current.IsOpenLog = true;
                Logger.CurrentLog.Info("INSTALLING");
            }

            //设置数据库连接模块
            AppCons.LogSqlExcu = bool.Parse(ConfigurationManager.AppSettings["LogSqlExcu"].ToString());
            //设置第一个数据库
            AppCons.SetSecondConnect(new MsSqlHelper(), ConfigurationManager.AppSettings["ConnectionString"]);
            AppCons.IsParmes = bool.Parse(ConfigurationManager.AppSettings["SqlParms"].ToString());
            Logger.CurrentLog.Info("Service_STARTING");
            AppCons.IsOpenCache = bool.Parse(ConfigurationManager.AppSettings["OpenCache"].ToString());
            AppCons.CurrentCache = new WebCache();

            //注册发送的信道
            ServicesFactory.RegisterAppHandler(new HZService());
            ServicesFactory.RegisterAppHandler(new WJXService());
            ServicesFactory.RegisterAppHandler(new YMService());


            if (!debugLog)
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                                    {
                                        new WcfService()
                                    };
                ServiceBase.Run(ServicesToRun);
            }
            else
            {
                Logger.CurrentLog.Info("WCF_STARTING");
                ServiceHost host = new ServiceHost(typeof(SMSServerWcf));
                if (host.Description.Behaviors.Find<System.ServiceModel.Description.ServiceMetadataBehavior>() == null)
                {
                    BindingElement metaElement = new TcpTransportBindingElement();
                    CustomBinding metaBind = new CustomBinding(metaElement);
                    host.Description.Behaviors.Add(new System.ServiceModel.Description.ServiceMetadataBehavior());
                    host.AddServiceEndpoint(typeof(System.ServiceModel.Description.IMetadataExchange), metaBind, "MEX");
                }
                host.Open();
                Logger.CurrentLog.Info("wcf状态" + host.State.ToString());

                Console.ReadLine();
            }
        }
    }
}
