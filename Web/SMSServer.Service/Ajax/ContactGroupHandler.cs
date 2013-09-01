#region Version Info
/* ========================================================================
* 【本类功能概述】
* 
* 作者：王军 时间：2013/8/23 23:06:50
* 文件名：ContactGroupHandler
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
using HelloData.FWCommon;
using HelloData.Web.AppHandlers;
using SMSService.Logic;

namespace SMSServer.Service.Ajax
{
    public class ContactGroupHandler : BaseHandler
    {
        public class Tree
        {
            public int id { get; set; }
            public int pid { get; set; }
            public string name { get; set; }
            public bool isParent = true;
        }

        public override HelloData.AppHandlers.IAppHandler CreateInstance()
        {
            return new BlackHandler();
        }

        public override string HandlerName
        {
            get { return "contactgroup"; }
        }

        public HandlerResponse getList()
        {
            string parentid = Request.Params["id"];
            int pid = 0;
            int.TryParse(parentid, out pid);
            List<SmsContactgroupInfo> infos = SmsContactGroupManage.Instance.getList(pid,AppContent.Current.GetCurrentUser().EnterpriseID);
            List<Tree> trees = new List<Tree>();
            foreach (SmsContactgroupInfo smsContactgroupInfo in infos)
            {
                Tree tree = new Tree();
                tree.id = smsContactgroupInfo.ID;
                tree.pid = smsContactgroupInfo.ParentGroupID.HasValue ? smsContactgroupInfo.ParentGroupID.Value : 0;
                tree.name = smsContactgroupInfo.Name;
                trees.Add(tree);
            }
            string result = JsonHelper.SerializeObject(trees);

            return CreateHandler(101, result);

        }

        public HandlerResponse delete()
        {
            int id = int.Parse(Request.Params["id"]);
            SmsContactGroupManage.Instance.DelGroup(id);
            return CreateHandler(1, "删除成功");
        }

        public HandlerResponse add()
        {
            int pid = int.Parse(Request.Params["pid"]);
            string name = Request.Params["name"];
            SmsContactgroupInfo info = new SmsContactgroupInfo();
            info.ParentGroupID = pid;
            info.Name = name;
            info.EnterPriseID = AppContent.Current.GetCurrentUser().EnterpriseID;
            info.AvailFlag = 1;
            info.CreateTime = DateTime.Now;
            int id = SmsContactGroupManage.Instance.AddGroup(info);
            return CreateHandler(1, id);
        }
        public HandlerResponse update()
        {
            int id = int.Parse(Request.Params["id"]);
            string name = Request.Params["name"];
            SmsContactgroupInfo info = new SmsContactgroupInfo();
            info.ID = id;
            info.Name = name;
            SmsContactGroupManage.Instance.UpdateGroup(info);
            return CreateHandler(1, "更新成功");
        }
    }
}
