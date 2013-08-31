using System.ServiceModel;
using System.ServiceProcess;
using System.ServiceModel.Channels;
using HelloData.FWCommon.Logging;
 
using SMSServer.WcfHost.Batch;

namespace SMSServer.WcfHost
{
    public partial class WcfService : ServiceBase
    {
        public WcfService()
        {
            InitializeComponent();
        }

        BatchReadService readService = new BatchReadService();
        BatchSendService sendService = new BatchSendService();
        protected override void OnStart(string[] args)
        {
        
            readService.Star();
           
            sendService.Star();
            Logger.CurrentLog.Info("ServiceHost Opening!");
        }

        protected override void OnStop()
        {
            readService.Stop();
            sendService.Stop();
            Logger.CurrentLog.Info("ServiceHost Closing!");
        }
    }
}
