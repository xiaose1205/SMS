using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Threading;
using BLL;
namespace SMSServer.WcfHost.Mo
{
    public class MoService : BaseService<MoService>
    {
        public MoService()
        {
            base.IsStop = false;
            base.SleepSpan = AppContent.MoReceive;
            this.ServiceName = "获取上行";
        }

        EnterpriseService bll = new EnterpriseService();
        BLL.MO Mobll = new BLL.MO();
        public override void WorkHandle()
        {
            if (!AppContent.IsMoReceive)
                this.Stop();
            else
            {
                try
                {
                    List<Model.GateWay.GateUser> users = bll.GetUserFromConfig();
                    foreach (var item in users)
                    {
                        PostMsg post = PostServers.Current.GetFormPool();
                        List<MoObj> molists = post.GetMo(item.UserName, item.PassWord);
                        Thread.Sleep(1000);
                    }
                }
                catch (Exception ex)
                {
                    Print(ex.Message, ex);
                }
            }
        }
        public void InsertMo(List<MoObj> molists, string enterpriseid)
        {
            try
            {
                List<Model.MOModel> models = new List<MOModel>();
                foreach (var item in molists)
                {
                    models.Add(new MOModel()
                    {
                        Content = item.MsgContent,
                        CreateTime = DateTime.Now,
                        EnterPriseID = enterpriseid,
                        MOID = Guid.NewGuid().ToString(),
                        Phone = item.Phone,
                        ReceiveTime = item.ReceiveDate,
                        Responsed = 0
                    });
                }
                Mobll.Add(models);
            }
            catch (Exception ex)
            {
                Print(ex.Message, ex);
            }
        }
    }
}
