#region Version Info
/* ========================================================================
* 【本类功能概述】
* 
* 作者：王军 时间：2013/8/23 23:06:33
* 文件名：ContactHandler
* 版本：V1.0.1
* 联系方式：511522329  
*
* 修改者： 时间： 
* 修改说明：
* ========================================================================
*/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using HelloData.FWCommon;
using HelloData.FrameWork.Data;
using HelloData.Web;
using HelloData.Web.AppHandlers;
using SMSService.Logic;

namespace SMSServer.Service.Ajax
{
    public class ContactHandler : BaseHandler
    {
        public override HelloData.AppHandlers.IAppHandler CreateInstance()
        {
            return new BlackHandler();
        }

        public override string HandlerName
        {
            get { return "contact"; }
        }
        public HandlerResponse getList()
        {
            int gid = int.Parse(Request.Params["gid"]);
            string name = Request.Params["name"];
            string phone = Request.Params["phone"];
            int PageIndex = int.Parse(Request.Params["PageIndex"]);
            int PageSize = int.Parse(Request.Params["PageSize"]);
            PageList<SmsContactInfo> infos = SmsContactManage.Instance.getList(PageIndex, PageSize, gid, name, phone);

            JsonFlexiGridData data = new JsonFlexiGridData();
            data.rows = new List<FlexiGridRow>();
            foreach (var item in infos)
            {
                FlexiGridRow row = new FlexiGridRow();
                row.id = item.ID.ToString();
                row.cell = new Dictionary<string, object>();
                row.cell.Add("id", item.ID);
                row.cell.Add("phone", item.Mobile);
                row.cell.Add("name", item.Name);
                row.cell.Add("comment", item.Comment);
                row.cell.Add("sex", item.Sex);
                row.cell.Add("birthday", item.Birthday);
                row.cell.Add("createtime", DateTostr(item.CreateTime));
                data.rows.Add(row);
            }
            data.page = PageIndex;
            data.total = infos.TotalCount;
            return CreateHandler(101, new JavaScriptSerializer().Serialize(data));

        }

        public HandlerResponse addContact()
        {
            string name = Request.Params["name"];
            string phone = Request.Params["phone"];
            string sex = Request.Params["sex"];
            string birthday = Request.Params["birthday"];
            string remark = Request.Params["remark"];
            string gid = Request.Params["gid"];
            SmsContactInfo info = new SmsContactInfo();
            info.Mobile = phone;
            info.Name = name;
            info.GroupID = int.Parse(gid);
            info.Sex = int.Parse(sex);
            info.Comment = remark;
            info.CreateTime = DateTime.Now;
            info.EnterpriseId = AppContent.Current.GetCurrentUser().EnterpriseID;
            SmsContactManage.Instance.Add(info);
            return CreateHandler(1, "添加成功");
        }
    }
}
