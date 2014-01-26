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
using SMSServer.Service;
using SMSServer.WcfHost.Batch;
using SMSServer.WcfHost.Mo;

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
            AppCons.SetDefaultConnect(new MySqlHelper(), ConfigurationManager.AppSettings["ConnectionString"]);
            AppCons.IsParmes = bool.Parse(ConfigurationManager.AppSettings["SqlParms"]);
            Logger.CurrentLog.Info("Service_STARTING");
            AppCons.IsOpenCache = bool.Parse(ConfigurationManager.AppSettings["OpenCache"]);
            AppCons.CurrentCache = new WebCache();

            //注册发送的信道
            ServicesFactory.RegisterApp(new DemoService());
            //YMService ym = new YMService();
            //ym.SendUser = new SendUser();
            //ym.SendUser.serialNumber = ConfigurationManager.AppSettings["ymsn"];
            //ym.SendUser.passwd = ConfigurationManager.AppSettings["ympwd"];
            //ym.SendUser.sdkKey = ConfigurationManager.AppSettings["ymsdkkey"];
            //ym.SendUser.tefuhao = ConfigurationManager.AppSettings["ymtefuhao"];

            //ServicesFactory.RegisterApp(ym);


            DemoService demo = new DemoService();
            demo.SendUser = new SendUser();
            demo.SendUser.serialNumber = ConfigurationManager.AppSettings["ymsn"];
            demo.SendUser.passwd = ConfigurationManager.AppSettings["ympwd"];
            demo.SendUser.sdkKey = ConfigurationManager.AppSettings["ymsdkkey"];
            demo.SendUser.tefuhao = ConfigurationManager.AppSettings["ymtefuhao"];

            ServicesFactory.RegisterApp(demo);

            AppContent.ReadBatch = int.Parse(ConfigurationManager.AppSettings["ReadBatch"]);
            AppContent.ReadTask = int.Parse(ConfigurationManager.AppSettings["ReadTask"]);

            AppContent.ReadSender = int.Parse(ConfigurationManager.AppSettings["ReadSender"]);
            AppContent.ReadBatchCount = int.Parse(ConfigurationManager.AppSettings["ReadBatchCount"]);

            AppContent.SendPackCount = int.Parse(ConfigurationManager.AppSettings["SendPackCount"]);

            AppContent.SendMtCount = int.Parse(ConfigurationManager.AppSettings["SendMtCount"]);
            AppContent.IsMoReceive = int.Parse(ConfigurationManager.AppSettings["isMo"]) == 1;
            AppContent.MoReceive = int.Parse(ConfigurationManager.AppSettings["MoRev"]);
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
                BatchReadService readService = new BatchReadService();
                BatchSendService sendService = new BatchSendService();
                ReadMoService moService = new ReadMoService();
                moService.Star();
                readService.Star();
                sendService.Star();
                //Logger.CurrentLog.Info("WCF_STARTING");
                //ServiceHost host = new ServiceHost(typeof(SMSServerWcf));
                //if (host.Description.Behaviors.Find<System.ServiceModel.Description.ServiceMetadataBehavior>() == null)
                //{
                //    BindingElement metaElement = new TcpTransportBindingElement();
                //    CustomBinding metaBind = new CustomBinding(metaElement);
                //    host.Description.Behaviors.Add(new System.ServiceModel.Description.ServiceMetadataBehavior());
                //    host.AddServiceEndpoint(typeof(System.ServiceModel.Description.IMetadataExchange), metaBind, "MEX");
                //}
                //host.Open();
                Logger.CurrentLog.Info("状态normal");

                Console.ReadLine();
            }
        }
    }
}
