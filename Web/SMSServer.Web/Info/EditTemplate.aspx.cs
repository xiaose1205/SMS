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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                TemplateHandler handler = new TemplateHandler();
                SmsTemplateInfo info = handler.GetTemplateInfo(id);
                template.Value = info.SmsContent;
                templateid.Value = info.ID.ToString();

            }
        }
    }
}