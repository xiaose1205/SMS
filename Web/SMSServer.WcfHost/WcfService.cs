using System.ServiceModel;
using System.ServiceProcess;
using System.ServiceModel.Channels;
using HelloData.FWCommon.Logging;
using SMSServer.Wcf;

namespace SMSServer.WcfHost
{
    public partial class WcfService : ServiceBase
    {
        public WcfService()
        {
            InitializeComponent();
        }
        ServiceHost host = new ServiceHost(typeof(SMSServerWcf));
        
        protected override void OnStart(string[] args)
        {
             if (host.Description.Behaviors.Find<System.ServiceModel.Description.ServiceMetadataBehavior>() == null)
            {
                BindingElement metaElement = new TcpTransportBindingElement();
                CustomBinding metaBind = new CustomBinding(metaElement);
                host.Description.Behaviors.Add(new System.ServiceModel.Description.ServiceMetadataBehavior());
                host.AddServiceEndpoint(typeof(System.ServiceModel.Description.IMetadataExchange), metaBind, "MEX");
            }
            host.Open();
            Logger.CurrentLog.Info("ServiceHost Opening!");
        }

        protected override void OnStop()
        {
            host.Abort();
            host.Close();
            Logger.CurrentLog.Info("ServiceHost Closing!");
        }
    }
}
