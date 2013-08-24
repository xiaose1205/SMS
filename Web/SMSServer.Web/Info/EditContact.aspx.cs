using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMSServer.Service.Ajax;

namespace SMSServer.Web.Info
{
    public partial class EditContact : System.Web.UI.Page
    {
        public string name;
        public string phone;
        public string birthday;
        public string remark;
        public string sex;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                ContactHandler handler = new ContactHandler();
                SmsContactInfo info = handler.GetContact(id);
                name = info.Name;
                phone = info.Mobile;
                birthday = handler.DateTostr(info.Birthday);
                remark = info.Comment;
                string st0 = "", st1 = "", st2 = "";
                switch (info.Sex)
                {
                    case 0:
                        st0 = "selected='selected'";
                        break;
                    case 1:
                        st1 = "selected='selected'";
                        break;
                    case 2:
                        st2 = "selected='selected'";
                        break;
                }

                sex = "  <option value='0' " + st0 + ">保密</option>"
                      + " <option value='1' " + st1 + ">男</option>"
                       + " <option value='2' " + st2 + ">女</option>";
                Page.DataBind();
            }
        }
    }
}