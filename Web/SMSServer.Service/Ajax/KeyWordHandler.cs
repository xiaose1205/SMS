#region Version Info
/* ========================================================================
* 【本类功能概述】
* 
* 作者：王军 时间：2013/8/20 23:58:56
* 文件名：KeyWordHandler
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
using System.Data;
using System.IO;
using System.Web.Script.Serialization;
using HelloData.FWCommon;
using HelloData.FrameWork.Data;
using HelloData.Web;
using HelloData.Web.AppHandlers;
using SMSServer.Logic;

namespace SMSServer.Service.Ajax
{
    public class KeyWordHandler : BaseHandler
    {
        public override HelloData.AppHandlers.IAppHandler CreateInstance()
        {
            return new KeyWordHandler();
        }

        public override string HandlerName
        {
            get { return "keyword"; }
        }

        public SmsContentfilterkeyInfo GetKeywordInfo(int id)
        {
            if (id <= 0)
                return null;
            else
            {
                return SmsContentfilterkeyManage.Instance.GetInfo(id);
            }
        }

        public HandlerResponse AddKeyword()
        {
            SmsContentfilterkeyInfo info = new SmsContentfilterkeyInfo();
            info.EnterpriseID = AppContent.Current.GetCurrentUser().EnterpriseID;
            info.Keyword = Request.Params["keyword"];
            info.CreateTime = DateTime.Now;
            SmsContentfilterkeyManage.Instance.AddKeyword(info);
            return CreateHandler(1, "添加成功");

        }
        public HandlerResponse EditKeyword()
        {
            SmsContentfilterkeyInfo info = new SmsContentfilterkeyInfo();
            info.EnterpriseID = AppContent.Current.GetCurrentUser().EnterpriseID;
            info.Keyword = Request.Params["keyword"];
            info.CreateTime = DateTime.Now;
            info.ID = Convert.ToInt32(Request.Params["id"]);
            SmsContentfilterkeyManage.Instance.EditKeyword(info);
            return CreateHandler(1, "修改成功");

        }
        public HandlerResponse Delete()
        {
            string ids = Request.Params["ids"];
            if (string.IsNullOrEmpty(ids))
                return CreateHandler(0, "删除失败");
            SmsContentfilterkeyManage.Instance.DeleteKeyword(ids.TrimEnd(','));
            return CreateHandler(1, "删除成功");

        }
        public HandlerResponse Clear()
        {
            int EnterpriseID = AppContent.Current.GetCurrentUser().EnterpriseID;
            SmsContentfilterkeyManage.Instance.ClearKeyword(EnterpriseID);
            return CreateHandler(1, "清除成功");

        }

        public HandlerResponse GetList()
        {
            int PageIndex = int.Parse(Request.Params["PageIndex"]);
            int PageSize = int.Parse(Request.Params["PageSize"]);
            PageList<SmsContentfilterkeyInfo> infos = SmsContentfilterkeyManage.Instance.GetList(PageIndex, PageSize);

            JsonFlexiGridData data = new JsonFlexiGridData();
            data.rows = new List<FlexiGridRow>();
            foreach (var item in infos)
            {
                FlexiGridRow row = new FlexiGridRow();
                row.id = item.ID.ToString();
                row.cell = new Dictionary<string, object>();
                row.cell.Add("id", item.ID);
                row.cell.Add("keyword", item.Keyword);
                row.cell.Add("createtime", DateTostr(item.CreateTime));
                data.rows.Add(row);
            }
            data.page = PageIndex;
            data.total = infos.TotalCount;
            return CreateHandler(101, new JavaScriptSerializer().Serialize(data));
        }

        public HandlerResponse upload()
        {
            string url = Request.Params["filename"].ToLower().Replace("master", "");
            String dirPath = Path.Combine(Path.Combine(Request.PhysicalApplicationPath, "uplpod"), url);
            bool isheader = Request.Params["header"] == "1";
            string spilter = Request.Params["spilter"];
            string[] filearr = Request.Params["filearr"].TrimEnd('|').Split('|');
            if (string.IsNullOrEmpty(dirPath))
            {
                return CreateHandler(0, "导入错误");
            }
            else
            {
                if (System.IO.File.Exists(dirPath))
                {
                    var dt = FileUtily.ReadDataTable(dirPath, 0, spilter);
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        return CreateHandler(0, "导入错误");
                    }
                    else
                    {
                        List<SmsContentfilterkeyInfo> keys = new List<SmsContentfilterkeyInfo>();
                        foreach (DataRow dr in dt.Rows)
                        {
                            SmsContentfilterkeyInfo key = new SmsContentfilterkeyInfo();
                            key.Keyword = dr[int.Parse(filearr[0])].ToString();
                            key.CreateTime = DateTime.Now;
                            key.EnterpriseID = AppContent.Current.GetCurrentUser().EnterpriseID;
                            keys.Add(key);
                        }
                        SmsContentfilterkeyManage.Instance.ImportList(keys);
                    }
                }
                return CreateHandler(1, "导入成功");
            }
        }
    }

}
