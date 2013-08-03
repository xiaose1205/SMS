using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using HelloData.FrameWork.Data;
using HelloData.Web;

namespace SMSServer.Web.demo
{
    /// <summary>
    /// ajax 的摘要说明
    /// </summary>
    public class ajax : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
           
            List<User> users = new List<User>();
            for (int i = 0; i < 15; i++)
            {
                User user = new User();
                user.id = i;
                user.name = Guid.NewGuid().ToString();
                users.Add(user);
            }
            JsonFlexiGridData data = new JsonFlexiGridData();
            data.rows = new List<FlexiGridRow>();
            foreach (var item in users)
            {
                FlexiGridRow row = new FlexiGridRow();
                row.id = item.id.ToString();
                row.cell = new Dictionary<string, object>();
                row.cell.Add("id", item.id);
                row.cell.Add("name", item.name);
                row.cell.Add("identity", item.identity);
                data.rows.Add(row);
            }
            data.page = 1;
            data.total = users.Count;
            context.Response.Write(new JavaScriptSerializer().Serialize(data));
        }

        public class User
        {
            public int id { get; set; }
            public string name { get; set; }
            public string identity { get; set; }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}