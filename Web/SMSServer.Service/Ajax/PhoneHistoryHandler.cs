#region Version Info
/* ========================================================================
* 【本类功能概述】
* 
* 作者：王军 时间：2013/8/21 23:10:19
* 文件名：PhoneHistoryHandler
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
using SMSService.Entity;

namespace SMSServer.Service.Ajax
{
    public class PhoneHistoryHandler : BaseHandler
    {
        public override HelloData.AppHandlers.IAppHandler CreateInstance()
        {
            return new MoHandler();
        }

        public override string HandlerName
        {
            get { return "phonehistory"; }
        }
        public HandlerResponse GetList()
        {
            int PageIndex = int.Parse(Request.Params["PageIndex"]);
            int PageSize = int.Parse(Request.Params["PageSize"]);
            string phone = Request.Params["phone"];
            string state = Request.Params["state"];
            string starttime = Request.Params["starttime"];
            string endtime = Request.Params["endtime"];
            PageList<SmsBatchDetailsMoreInfo> infos = SmsBatchDetailsManage.Instance.GetList(PageIndex, PageSize
                , phone, state, starttime, endtime);

            JsonFlexiGridData data = new JsonFlexiGridData();
            data.rows = new List<FlexiGridRow>();
            foreach (var item in infos)
            {
                FlexiGridRow row = new FlexiGridRow();
                row.id = item.ID.ToString();
                row.cell = new Dictionary<string, object>();
                row.cell.Add("id", item.ID);
                row.cell.Add("phone", item.Phone);
                row.cell.Add("content", item.Content);
                row.cell.Add("batchname",item.BatchName);
                row.cell.Add("state", item.State);
                row.cell.Add("stateremark", item.StateReport);
                row.cell.Add("posttime", DateTostr(item.SubmitTime));
                data.rows.Add(row);
            }
            data.page = PageIndex;
            data.total = infos.TotalCount;
            return CreateHandler(101, new JavaScriptSerializer().Serialize(data));
        }
    }
}
