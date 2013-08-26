#region Version Info
/* ========================================================================
* 【本类功能概述】
* 
* 作者：王军 时间：2013/8/21 23:10:01
* 文件名：BatchHistoryHandler
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
    public class BatchHistoryHandler : BaseHandler
    {
        public override HelloData.AppHandlers.IAppHandler CreateInstance()
        {
            return new MoHandler();
        }

        public override string HandlerName
        {
            get { return "batchhistory"; }
        }
        public HandlerResponse GetList()
        {
            int PageIndex = int.Parse(Request.Params["PageIndex"]);
            int PageSize = int.Parse(Request.Params["PageSize"]);
            string batchname = Request.Params["batchname"];
            string state = Request.Params["state"];
            string starttime = Request.Params["starttime"];
            string endtime = Request.Params["endtime"];
            PageList<BatchMoreInfo> infos = SmsBatchManage.Instance.GetList(PageIndex, PageSize
                , batchname, state, starttime, endtime);

            JsonFlexiGridData data = new JsonFlexiGridData();
            data.rows = new List<FlexiGridRow>();
            foreach (var item in infos)
            {
                FlexiGridRow row = new FlexiGridRow();
                row.id = item.ID.ToString();
                row.cell = new Dictionary<string, object>();
                row.cell.Add("id", item.ID);
                row.cell.Add("batchname", item.BatchName);
                row.cell.Add("content", item.SmsContent);
                string batchstate = "提交中";
                if (item.BatchState != null)
                    switch (item.BatchState.Value)
                    {
                        case 1: batchstate = "检核中";
                            break;
                        case 2: batchstate = "等待中";
                            break;
                        case 3: batchstate = "发送中";
                            break;
                        case 4: batchstate = "完成";
                            break;
                    }
                row.cell.Add("state", batchstate);
                row.cell.Add("sendamount", item.SendAmount);
                row.cell.Add("successamount", item.SuccessAmount);
                row.cell.Add("posttime", DateTostr(item.PostTime));
                row.cell.Add("createtime", DateTostr(item.CreateTime));
                 data.rows.Add(row);
            }
            data.page = PageIndex;
            data.total = infos.TotalCount;
            return CreateHandler(101, new JavaScriptSerializer().Serialize(data));
        }
    }
}
