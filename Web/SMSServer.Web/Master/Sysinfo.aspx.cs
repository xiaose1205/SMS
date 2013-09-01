using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HelloData.FrameWork;
using SMSServer.Service;

namespace SMSServer.Web.Master
{
    public partial class Sysinfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            account.InnerHtml = AppContent.Current.GetCurrentUser().Account;
            SmsEnterpriseInfo inf =
                new EnterpriseService().GetEnterpriseInfo(AppContent.Current.GetCurrentUser().EnterpriseID);
            enterprise.InnerHtml = inf.EnterpriseName;
            smsprice.InnerHtml = inf.Capital.ToString() + "元";
            state.InnerHtml = AppContent.Current.GetCurrentUser().State == 0 ? "禁用" : "正常";

        }

    }
}