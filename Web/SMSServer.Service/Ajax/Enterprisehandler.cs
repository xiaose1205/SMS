#region Version Info
/* ========================================================================
* 【本类功能概述】
* 
* 作者：王军 时间：2013/8/27 23:37:25
* 文件名：Enterprisehandler
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
    public class Enterprisehandler : BaseHandler
    {
        public override HelloData.AppHandlers.IAppHandler CreateInstance()
        {
            return new BlackHandler();
        }

        public override string HandlerName
        {
            get { return "enterprise"; }
        }
        public HandlerResponse AddEnterprise()
        {
            SmsEnterpriseInfo info = new SmsEnterpriseInfo();
            info.EnterpriseName = Request.Params["name"];
            info.Introduction = Request.Params["introduction"];
            info.Capital = float.Parse(Request.Params["capital"]);
            info.CreateTime = DateTime.Now;
            int eid = SmsEnterpriseManage.Instance.AddEnterprise(info);
            if (eid > 0)
                SmsContactGroupManage.Instance.AddGroup(new SmsContactgroupInfo()
                    {
                        CreateTime = DateTime.Now,
                        EnterPriseID = eid,
                        GroupCode = "1.1",
                        Name = info.EnterpriseName,
                        ParentCode = "0",
                        ParentGroupID = 0
                    });
            return CreateHandler(1, "添加成功");
        }
        public HandlerResponse EditEnterprise()
        {
            SmsEnterpriseInfo info = new SmsEnterpriseInfo();
            info.EnterpriseName = Request.Params["name"];
            info.Introduction = Request.Params["introduction"];
            info.Capital = float.Parse(Request.Params["capital"]);
            info.CreateTime = DateTime.Now;
            info.ID = Convert.ToInt32(Request.Params["id"]);
            SmsEnterpriseManage.Instance.EditEnterprise(info);
            return CreateHandler(1, "修改成功");

        }


        public HandlerResponse EnterpriseCfg()
        {
            List<SmsEnterpriseCfgInfo> infos = new List<SmsEnterpriseCfgInfo>();
            SmsEnterpriseCfgInfo cfgInfo = new SmsEnterpriseCfgInfo();

            cfgInfo.CfgKey = "smsprice";
            cfgInfo.CfgValue = Request.Params["smsprice"];
            cfgInfo.CreateTime = DateTime.Now;
            cfgInfo.EnterpriseID = int.Parse(Request.Params["enterpriseid"]);

            infos.Add(cfgInfo);
            cfgInfo = new SmsEnterpriseCfgInfo();
            cfgInfo.CfgKey = "chinamobile";
            cfgInfo.CfgValue = Request.Params["chinamobile"];
            cfgInfo.CreateTime = DateTime.Now;
            cfgInfo.EnterpriseID = int.Parse(Request.Params["enterpriseid"]);
            infos.Add(cfgInfo); cfgInfo = new SmsEnterpriseCfgInfo();
            cfgInfo.CfgKey = "union";
            cfgInfo.CfgValue = Request.Params["union"];
            cfgInfo.CreateTime = DateTime.Now;
            cfgInfo.EnterpriseID = int.Parse(Request.Params["enterpriseid"]);
            infos.Add(cfgInfo); cfgInfo = new SmsEnterpriseCfgInfo();
            cfgInfo.CfgKey = "cdma";
            cfgInfo.CfgValue = Request.Params["cdma"];
            cfgInfo.CreateTime = DateTime.Now;
            cfgInfo.EnterpriseID = int.Parse(Request.Params["enterpriseid"]);
            infos.Add(cfgInfo); cfgInfo = new SmsEnterpriseCfgInfo();
            cfgInfo.CfgKey = "smslength";
            cfgInfo.CfgValue = Request.Params["smslength"];
            cfgInfo.CreateTime = DateTime.Now;
            cfgInfo.EnterpriseID = int.Parse(Request.Params["enterpriseid"]);
            infos.Add(cfgInfo);
            SmsEnterpriseCfgManage.Instance.AddList(infos);
            return CreateHandler(1, "修改成功");
        }

        public HandlerResponse Delete()
        {
            string ids = Request.Params["ids"];
            if (string.IsNullOrEmpty(ids))
                return CreateHandler(0, "删除失败");
            SmsEnterpriseManage.Instance.DeleteEnterprise(ids.TrimEnd(','));
            return CreateHandler(1, "删除成功");

        }
        public HandlerResponse GetList()
        {
            int PageIndex = int.Parse(Request.Params["PageIndex"]);
            int PageSize = int.Parse(Request.Params["PageSize"]);
            PageList<SmsEnterpriseInfo> infos = SmsEnterpriseManage.Instance.GetList(PageIndex, PageSize);

            JsonFlexiGridData data = new JsonFlexiGridData();
            data.rows = new List<FlexiGridRow>();
            foreach (var item in infos)
            {
                FlexiGridRow row = new FlexiGridRow();
                row.id = item.ID.ToString();
                row.cell = new Dictionary<string, object>();
                row.cell.Add("id", item.ID);
                row.cell.Add("name", item.EnterpriseName);
                row.cell.Add("introduction", item.Introduction);
                row.cell.Add("smsprice", item.SmsPrice);
                row.cell.Add("chinamobile", item.ChinaMobile);
                row.cell.Add("union", item.Union);
                row.cell.Add("cdma", item.Cdma);
                row.cell.Add("capital", item.Capital);
                row.cell.Add("smslength", item.SmsLength);
                row.cell.Add("createtime", DateTostr(item.CreateTime));
                data.rows.Add(row);
            }
            data.page = PageIndex;
            data.total = infos.TotalCount;
            return CreateHandler(101, new JavaScriptSerializer().Serialize(data));
        }


        public List<SmsEnterpriseCfgInfo> getCfgList(int enterpriseId)
        {
            return SmsEnterpriseCfgManage.Instance.getCfgInfos(enterpriseId);
        }

        public PageList<SmsEnterpriseInfo> GetAllList()
        {
            PageList<SmsEnterpriseInfo> infos = SmsEnterpriseManage.Instance.GetList(0, -1);
            return infos;

        }
    }
}
