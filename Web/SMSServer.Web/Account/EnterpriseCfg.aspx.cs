using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMSServer.Service.Ajax;

namespace SMSServer.Web.Account
{
    public partial class EnterpriseCfg : System.Web.UI.Page
    {
        public string smsprice;
        public string chinamobile;
        public string union;

        public string cdma;
        public string smslength;
        public string enterpriseid;

        protected void Page_Load(object sender, EventArgs e)
        {
            Enterprisehandler enterprisehandler = new Enterprisehandler();
            List<SmsEnterpriseCfgInfo> infos = enterprisehandler.getCfgList(int.Parse(Request.Params["eid"]));
            enterpriseid = Request.Params["eid"];
            foreach (SmsEnterpriseCfgInfo smsEnterpriseCfgInfo in infos)
            {
                if (smsEnterpriseCfgInfo.CfgKey == "smsprice")
                    smsprice = smsEnterpriseCfgInfo.CfgValue;
                if (smsEnterpriseCfgInfo.CfgKey == "chinamobile")
                    chinamobile = smsEnterpriseCfgInfo.CfgValue;
                if (smsEnterpriseCfgInfo.CfgKey == "union")
                    union = smsEnterpriseCfgInfo.CfgValue;
                if (smsEnterpriseCfgInfo.CfgKey == "cdma")
                    cdma = smsEnterpriseCfgInfo.CfgValue;
                if (smsEnterpriseCfgInfo.CfgKey == "smslength")
                    smslength = smsEnterpriseCfgInfo.CfgValue;
            }
            Page.DataBind();
        }
    }
}