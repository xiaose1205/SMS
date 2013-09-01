using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMSServer.Service;

namespace SMSServer.Web
{
    public partial class MainPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (AppContent.Current.GetCurrentUser() == null)
                Response.Redirect("Login.aspx");
            account.InnerHtml = AppContent.Current.GetCurrentUser().Account;
            SmsEnterpriseInfo inf =
                new EnterpriseService().GetEnterpriseInfo(AppContent.Current.GetCurrentUser().EnterpriseID);
            enterprise.InnerHtml = inf.EnterpriseName;
            smsprice.InnerHtml = inf.Capital.ToString()+"元";
            myname.InnerHtml = AppContent.Current.GetCurrentUser().Account;
            state.InnerHtml = AppContent.Current.GetCurrentUser().State == 0 ? "禁用" : "正常";

        }
    }
}