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
                        SmsEnterpriseCfgInfo configmodel = config.GetModelWithKey("chinamobile", item.ID);
                        string keyvalue = configmodel.CfgValue;
                        foreach (int i in config.GetChannels(configmodel))
                        {
                            smsMoInfos.AddRange(changeMos(ServicesFactory.Execute(i).GetMo(), users));
                        }
                        configmodel = config.GetModelWithKey("union", item.ID);
                        string ukeyvalue = configmodel.CfgValue;
                        if (keyvalue != configmodel.CfgValue)
                        {
                            foreach (int i in config.GetChannels(configmodel))
                            {
                                smsMoInfos.AddRange(changeMos(ServicesFactory.Execute(i).GetMo(), users));
                            }
                        }
                        configmodel = config.GetModelWithKey("cdma", item.ID);
                        if (keyvalue != configmodel.CfgValue && ukeyvalue != configmodel.CfgValue)
                        {
                            foreach (int i in config.GetChannels(configmodel))
                            {
                                smsMoInfos.AddRange(changeMos(ServicesFactory.Execute(i).GetMo(), users));
                            }
                        }
                        InsertMo(smsMoInfos);
                        Thread.Sleep(AppContent.MoReceive);
                    }

                }
                catch (Exception ex)
                {
                    Print(ex.Message, ex);
                }
            }
        }

        public List<SmsMoInfo> changeMos(List<MoInfo> infos, List<SmsEnterpriseInfo> enterpriseInfos)
        {
            List<SmsMoInfo> smsMoInfos = new List<SmsMoInfo>();
            foreach (var moInfo in infos)
            {
                SmsMoInfo info = new SmsMoInfo();
                SmsEnterpriseInfo smsEnterpriseInfo = enterpriseInfos.Find(n => n.ExtendNum == moInfo.ExtraNub);
                if (smsEnterpriseInfo != null)
                    info.EnterpriseID = smsEnterpriseInfo.ID;
                else
                {
                    info.EnterpriseID = 1;
                }
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
