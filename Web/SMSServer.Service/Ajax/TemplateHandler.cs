#region Version Info
/* ========================================================================
* 【本类功能概述】
* 
* 作者：王军 时间：2013/8/20 23:59:12
* 文件名：TemplateHandler
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
using SMSServer.Logic;
using SMSService.Logic;

namespace SMSServer.Service.Ajax
{
    public class TemplateHandler : BaseHandler
    {
        public override HelloData.AppHandlers.IAppHandler CreateInstance()
        {
            return new TemplateHandler();
        }

        public override string HandlerName
        {
            get { return "template"; }
        }
        public SmsTemplateInfo GetTemplateInfo(int id)
        {
            if (id <= 0)
                return null;
            else
            {
                return SmsTemplateManage.Instance.GetInfo(id);
            }
        }

        public HandlerResponse AddTemplate()
        {
            SmsTemplateInfo info = new SmsTemplateInfo();
            info.EnterpriseID = AppContent.Current.GetCurrentUser().EnterpriseID;
            info.SmsContent = Request.Params["template"];
            info.CreateTime = DateTime.Now;
            SmsTemplateManage.Instance.AddTemplate(info);
            return CreateHandler(1, "添加成功");

        }
        public HandlerResponse EditTemplate()
        {
            SmsTemplateInfo info = new SmsTemplateInfo();
            info.EnterpriseID = AppContent.Current.GetCurrentUser().EnterpriseID;
            info.SmsContent = Request.Params["template"];
            info.CreateTime = DateTime.Now;
            info.ID = Convert.ToInt32(Request.Params["id"]);
            SmsTemplateManage.Instance.EditTemplate(info);
            return CreateHandler(1, "修改成功");

        }
        public HandlerResponse Delete()
        {
            string ids = Request.Params["ids"];
            if (string.IsNullOrEmpty(ids))
                return CreateHandler(0, "删除失败");
            SmsTemplateManage.Instance.DeleteTemplate(ids.TrimEnd(','));
            return CreateHandler(1, "删除成功");

        }
        public HandlerResponse Clear()
        {
            int EnterpriseID = AppContent.Current.GetCurrentUser().EnterpriseID;
            SmsTemplateManage.Instance.ClearTemplate(EnterpriseID);
            return CreateHandler(1, "清除成功");

        }

        public HandlerResponse GetList()
        {
            int PageIndex = int.Parse(Request.Params["PageIndex"]);
            int PageSize = int.Parse(Request.Params["PageSize"]);
            PageList<SmsTemplateInfo> infos = SmsTemplateManage.Instance.GetList(PageIndex, PageSize);

            JsonFlexiGridData data = new JsonFlexiGridData();
            data.rows = new List<FlexiGridRow>();
            foreach (var item in infos)
            {
                FlexiGridRow row = new FlexiGridRow();
                row.id = item.ID.ToString();
                row.cell = new Dictionary<string, object>();
                row.cell.Add("id", item.ID);
                row.cell.Add("content", item.SmsContent);
                row.cell.Add("createtime", DateTostr(item.CreateTime));
                data.rows.Add(row);
            }
            data.page = PageIndex;
            data.total = infos.TotalCount;
            return CreateHandler(101, new JavaScriptSerializer().Serialize(data));
        }

    }
}
