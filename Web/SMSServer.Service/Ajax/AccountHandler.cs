#region Version Info
/* ========================================================================
* 【本类功能概述】
* 
* 作者：王军 时间：2013/8/27 23:37:07
* 文件名：AccountHandler
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

namespace SMSServer.Service.Ajax
{
    public class AccountHandler : BaseHandler
    {
        public override HelloData.AppHandlers.IAppHandler CreateInstance()
        {
            return new AccountHandler();
        }

        public override string HandlerName
        {
            get { return "account"; }
        }
        public HandlerResponse AddAccount()
        {
            SmsAccountInfo info = new SmsAccountInfo();
            info.EnterpriseID = int.Parse(Request.Params["enterpriseid"]);
            info.Account = Request.Form["account"];
            info.Password = "123456";
            info.Signature = Request.Params["signature"];
            info.Createtime = DateTime.Now;
            info.State = 1;
            SmsAccountManage.Instance.AddAccount(info);
            return CreateHandler(1, "添加成功");
        }
        public HandlerResponse EditAccount()
        {
            SmsAccountInfo info = new SmsAccountInfo();
            info.Account = Request.Form["account"];
            info.Signature = Request.Params["signature"];
            info.ID = Convert.ToInt32(Request.Params["id"]);
            SmsAccountManage.Instance.EditAccount(info);
            return CreateHandler(1, "修改成功");

        }

        public HandlerResponse EditPassword()
        {
            if (Request.Params["pwd"] != Request.Params["repwd"])
                return CreateHandler(0, "两次密码输入不正确");
            if (string.IsNullOrEmpty(Request.Params["aid"]))
                return CreateHandler(0, "企业账号不能为空");
            SmsAccountManage.Instance.UpdatePwd(Request.Params["pwd"], Request.Params["aid"]);
            return CreateHandler(1, "修改成功");

        }
        public HandlerResponse EditMyPassword()
        {
            if (string.IsNullOrEmpty(Request.Params["oldpwd"]))
                return CreateHandler(0, "旧密码不能为空");
            if (Request.Params["pwd"] != Request.Params["repwd"])
                return CreateHandler(0, "两次密码输入不正确");
            if (string.IsNullOrEmpty(Request.Params["aid"]))
                return CreateHandler(0, "企业账号不能为空");
            if(SmsAccountManage.Instance.UpdateMyPwd(Request.Params["pwd"], Request.Params["aid"],Request.Params["oldpwd"]))
            return CreateHandler(1, "修改成功");
            else
            {
                return CreateHandler(0, "修改失败，旧密码可能错误");
            }

        }
        public HandlerResponse SetState()
        {
            string ids = Request.Params["ids"].TrimEnd(',');
            int state = int.Parse(Request.Params["state"]);
            SmsAccountManage.Instance.SetStae(ids, state);
            return CreateHandler(1, "修改成功");

        }
        public HandlerResponse Delete()
        {
            string ids = Request.Params["ids"];
            if (string.IsNullOrEmpty(ids))
                return CreateHandler(0, "删除失败");
            SmsAccountManage.Instance.DeleteAccount(ids.TrimEnd(','));
            return CreateHandler(1, "删除成功");

        }
        public HandlerResponse GetList()
        {
            int PageIndex = int.Parse(Request.Params["PageIndex"]);
            int PageSize = int.Parse(Request.Params["PageSize"]);
            PageList<SmsAccountInfo> infos = SmsAccountManage.Instance.GetList(PageIndex, PageSize);

            JsonFlexiGridData data = new JsonFlexiGridData();
            data.rows = new List<FlexiGridRow>();
            foreach (var item in infos)
            {
                FlexiGridRow row = new FlexiGridRow();
                row.id = item.ID.ToString();
                row.cell = new Dictionary<string, object>();
                row.cell.Add("id", item.ID);
                row.cell.Add("account", item.Account);
                row.cell.Add("createtime", DateTostr(item.Createtime));
                row.cell.Add("logintime", DateTostr(item.LoginTime));
                row.cell.Add("state", item.State.Value == 0 ? "禁用" : "正常");
                row.cell.Add("eid", item.EnterpriseID);
                row.cell.Add("signature", item.Signature);
                data.rows.Add(row);
            }
            data.page = PageIndex;
            data.total = infos.TotalCount;
            return CreateHandler(101, new JavaScriptSerializer().Serialize(data));
        }

        public SmsAccountInfo GetAccount(int id)
        {
            return SmsAccountManage.Instance.GetAccount(id);
        }
    }
}
