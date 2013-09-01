using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMSServer.Service;

namespace SMSServer.Web.Account
{
    public partial class EditEnterprise : System.Web.UI.Page
    {
        public string name;
        public string introduction;
        public string capital;
        protected void Page_Load(object sender, EventArgs e)
        {
            EnterpriseService service = new EnterpriseService();
            SmsEnterpriseInfo info = service.GetEnterpriseInfo(int.Parse(Request.QueryString["id"]));
            name = info.EnterpriseName;
            introduction = info.Introduction;
            capital = info.Capital.ToString();
            Page.DataBind();
        }
    }
}