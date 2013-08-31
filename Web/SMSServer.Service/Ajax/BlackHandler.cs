#region Version Info
/* ========================================================================
* 【本类功能概述】
* 
* 作者：王军 时间：2013/8/18 22:28:25
* 文件名：BlackService
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
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using HelloData.FWCommon;
using HelloData.FrameWork.Data;
using HelloData.Web;
using HelloData.Web.AppHandlers;
using SMSServer.Logic;

namespace SMSServer.Service.Ajax
{
    public class BlackHandler : BaseHandler
    {
        public override HelloData.AppHandlers.IAppHandler CreateInstance()
        {
            return new BlackHandler();
        }

        public override string HandlerName
        {
            get { return "black"; }
        }

        public SmsBlackphoneInfo GetBlackInfo(int id)
        {
            if (id <= 0)
                return null;
            else
            {
                return SmsBlackPhoneManage.Instance.GetInfo(id);
            }
        }

        public HandlerResponse AddBlack()
        {
            SmsBlackphoneInfo info = new SmsBlackphoneInfo();
            info.EnterpriseID = AppContent.Current.GetCurrentUser().EnterpriseID;
            info.Phone = Request.Params["phone"];
            info.CreateTime = DateTime.Now;
            SmsBlackPhoneManage.Instance.AddBlack(info);
            return CreateHandler(1, "添加成功");

        }
        public HandlerResponse EditBlack()
        {
            SmsBlackphoneInfo info = new SmsBlackphoneInfo();
            info.EnterpriseID = AppContent.Current.GetCurrentUser().EnterpriseID;
            info.Phone = Request.Params["phone"];
            info.CreateTime = DateTime.Now;
            info.ID = Convert.ToInt32(Request.Params["id"]);
            SmsBlackPhoneManage.Instance.EditBlack(info);
            return CreateHandler(1, "修改成功");

        }
        public HandlerResponse Delete()
        {
            string ids = Request.Params["ids"];
            if (string.IsNullOrEmpty(ids))
                return CreateHandler(0, "删除失败");
            SmsBlackPhoneManage.Instance.DeleteBlack(ids.TrimEnd(','));
            return CreateHandler(1, "删除成功");

        }
        public HandlerResponse Clear()
        {
            int EnterpriseID = AppContent.Current.GetCurrentUser().EnterpriseID;
            SmsBlackPhoneManage.Instance.ClearBlack(EnterpriseID);
            return CreateHandler(1, "清除成功");

        }

        public HandlerResponse GetList()
        {
            int PageIndex = int.Parse(Request.Params["PageIndex"]);
            int PageSize = int.Parse(Request.Params["PageSize"]);
            PageList<SmsBlackphoneInfo> infos = SmsBlackPhoneManage.Instance.GetList(PageIndex, PageSize,AppContent.Current.GetCurrentUser().EnterpriseID);

            JsonFlexiGridData data = new JsonFlexiGridData();
            data.rows = new List<FlexiGridRow>();
            foreach (var item in infos)
            {
                FlexiGridRow row = new FlexiGridRow();
                row.id = item.ID.ToString();
                row.cell = new Dictionary<string, object>();
                row.cell.Add("id", item.ID);
                row.cell.Add("phone", item.Phone);
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
                    var dt = FileUtily.ReadDataTable(dirPath, 0, spilter,isheader);
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        return CreateHandler(0, "导入错误");
                    }
                    else
                    {
                        List<SmsBlackphoneInfo> blacks = new List<SmsBlackphoneInfo>();
                        foreach (DataRow dr in dt.Rows)
                        {
                            SmsBlackphoneInfo black = new SmsBlackphoneInfo();
                            black.Phone = dr[int.Parse(filearr[0])].ToString();
                            if(!AppContent.isPhone(black.Phone))
                                continue; 
                            black.CreateTime = DateTime.Now;
                            black.EnterpriseID = AppContent.Current.GetCurrentUser().EnterpriseID;
                            blacks.Add(black);
                        }
                        SmsBlackPhoneManage.Instance.ImportList(blacks);
                    }
                }
                return CreateHandler(1, "导入成功");
            }
        }
    }
}
