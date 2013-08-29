using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMSServer.Service.Ajax;

namespace SMSServer.Web.Account
{
    public partial class EditAccount : System.Web.UI.Page
    {
        public string account;
        public string sign;
        protected void Page_Load(object sender, EventArgs e)
        {
            AccountHandler handler = new AccountHandler();
            SmsAccountInfo info = handler.GetAccount(int.Parse(Request.QueryString["id"]));
            if (info != null)
            {
                account = info.Account;
                sign = info.Signature;
            }
            Page.DataBind(); 

        }
    }
}