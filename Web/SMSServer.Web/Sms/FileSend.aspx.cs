using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMSServer.Service;
using SMSServer.Service.Ajax;

namespace SMSServer.Web.Sms
{
    public partial class FileSend : System.Web.UI.Page
    {
        public string smslength = "70";
        public string signature = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Enterprisehandler handler = new Enterprisehandler();
            List<SmsEnterpriseCfgInfo> infos = handler.getCfgList(AppContent.Current.GetCurrentUser().EnterpriseID);
            foreach (SmsEnterpriseCfgInfo smsEnterpriseCfgInfo in infos)
            {
                if (smsEnterpriseCfgInfo.CfgKey == "smslength")
                {
                    smslength = smsEnterpriseCfgInfo.CfgValue;
                    break;
                    ;
                }

            }
            signature = AppContent.Current.GetCurrentUser().Signature;
            Page.DataBind();
        }
    }
}