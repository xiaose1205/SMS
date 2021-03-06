﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMSServer.Service.Ajax;

namespace SMSServer.Web.Info
{
    public partial class EditBlack : System.Web.UI.Page
    {
        public string phone = "";
        public string bid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                BlackHandler handler = new BlackHandler();
                SmsBlackphoneInfo info = handler.GetBlackInfo(id);
                phone  = info.Phone;
                bid = info.ID.ToString();
                Page.DataBind();
            }
        }
    }
}