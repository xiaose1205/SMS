using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HelloData.FrameWork.Data;
using SMSServer.Service.Ajax;

namespace SMSServer.Web.Account
{
    public partial class AddAccount : System.Web.UI.Page
    {
        public string enterpise;
        protected void Page_Load(object sender, EventArgs e)
        {
            Enterprisehandler handler = new Enterprisehandler();
            PageList<SmsEnterpriseInfo> infos = handler.GetAllList();
            foreach (SmsEnterpriseInfo smsEnterpriseInfo in infos)
            {
                enterpise += "   <option value='" + smsEnterpriseInfo.ID + "'>" + smsEnterpriseInfo.EnterpriseName + "</option>";
            }
            Page.DataBind();
        }
    }
}