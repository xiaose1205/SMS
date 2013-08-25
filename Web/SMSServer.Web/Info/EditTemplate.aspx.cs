using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMSServer.Service.Ajax;

namespace SMSServer.Web.Info
{
    public partial class EditTemplate : System.Web.UI.Page
    {
        public string template = "";
        public string tid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                TemplateHandler handler = new TemplateHandler();
                SmsTemplateInfo info = handler.GetTemplateInfo(id);
                template = info.SmsContent;
                tid = info.ID.ToString();
                Page.DataBind();

            }
        }
    }
}