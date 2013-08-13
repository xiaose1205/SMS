using System;
using System.Collections.Generic;
using System.Threading;
using SMSServer.OpenPlatform;
using SMSServer.Service;

namespace SMSServer.WcfHost.Mo
{
    public class ReadMoService : BaseService<ReadMoService>
    {
        public ReadMoService()
        {
            base.IsStop = false;
            base.SleepSpan = AppContent.MoReceive;
            this.ServiceName = "获取上行";
        }

        EnterpriseService config = new EnterpriseService();
        MoService moService = new MoService();
        public override void WorkHandle()
        {
            if (!AppContent.IsMoReceive)
                this.Stop();
            else
            {
                try
                {
                    List<SmsEnterpriseInfo> users = config.GetEnterprise();
                    foreach (var item in users)
                    {
                        List<SmsMoInfo> smsMoInfos = new List<SmsMoInfo>();
                        SmsEnterpriseCfgInfo configmodel = config.GetModelWithKey("channels", item.ID);
                        foreach (int i in config.GetChannels(configmodel))
                        {
                            smsMoInfos.AddRange(changeMos(ServicesFactory.Execute(i).GetMo(), item.ID));
                        }
                        Thread.Sleep(1000);
                    }
                }
                catch (Exception ex)
                {
                    Print(ex.Message, ex);
                }
            }
        }

        public List<SmsMoInfo> changeMos(List<MoInfo> infos, int enterpriseId)
        {
            List<SmsMoInfo> smsMoInfos = new List<SmsMoInfo>();
            foreach (var moInfo in infos)
            {
                SmsMoInfo info = new SmsMoInfo();
                info.EnterpriseID = enterpriseId;
                info.Content = moInfo.Content;
                info.Phone = moInfo.Phone;
                info.ReceiveTime = moInfo.MoTime;
                info.CreateTime = DateTime.Now;
                smsMoInfos.Add(info);
            }
            return smsMoInfos;
        }

        public void InsertMo(List<SmsMoInfo> molists)
        {
            try
            {
                moService.AddMos(molists);
            }
            catch (Exception ex)
            {
                Print(ex.Message, ex);
            }
        }

       
    }
}
