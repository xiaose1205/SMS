using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMSServer.Service.Ajax;

namespace SMSServer.Web.Info
{
    public partial class EditKeyword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                KeyWordHandler handler = new KeyWordHandler();
                SmsContentfilterkeyInfo info = handler.GetKeywordInfo(id);
                keyword.Value = info.Key;
                keywordid.Value = info.ID.ToString();

            }
        }
    }
}