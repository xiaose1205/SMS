using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HelloData.FrameWork;

namespace SMSServer.Web.Master
{
    public partial class Sysinfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Expires = 0;
            Response.CacheControl = "no-cache"; //51^aspx
            if (!Page.IsPostBack)
            {

                //取得页面执行开始时间
                DateTime stime = DateTime.Now;


                //取得服务器相关信息
                servername.Text = Server.MachineName;
                serverip.Text = Request.ServerVariables["LOCAL_ADDR"];
                server_name.Text = Request.ServerVariables["SERVER_NAME"];

                char[] de = { ';' };
                string allhttp = Request.ServerVariables["HTTP_USER_AGENT"].ToString();
                string[] myFilename = allhttp.Split(de);
                servernet.Text = myFilename[myFilename.Length - 1].Replace(")", " ");
                if (myFilename.Length > 2)
                    serverms.Text = myFilename[2];
                if (myFilename.Length > 1)
                    serverie.Text = myFilename[1];

                serversoft.Text = Request.ServerVariables["SERVER_SOFTWARE"];

                serverlan.Text = Request.ServerVariables["HTTP_ACCEPT_LANGUAGE"];
                servertime.Text = DateTime.Now.ToString();

                servers.Text = Session.Contents.Count.ToString();
                servera.Text = Application.Contents.Count.ToString();

                if (AppCons.Connection != null)
                {
                    sqltype.Text = "mysql";
                    sqlname.Text = AppCons.Connection.Database;

                }
            }
        }


    }
}