#region Version Info
/* ========================================================================
* 【本类功能概述】
* 
* 作者：王军 时间：2013/8/23 23:14:39
* 文件名：SmsContactManage
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
using HelloData.FrameWork.Data;

namespace SMSService.Logic
{
    public class SmsContactManage : BaseManager<SmsContactManage, SmsContactInfo>
    {
        public PageList<SmsContactInfo> getList(int pageindex, int pagesize, int gid, string name, string phone, int enterpriseId)
        {
            using (SelectAction action = new SelectAction(this.Entity))
            {
                if (gid != 0)
                    action.SqlWhere(SmsContactInfo.Columns.GroupID, gid);
                else
                {
                    action.SqlWhere(SmsContactInfo.Columns.EnterpriseId, enterpriseId);
                }
                if (!string.IsNullOrEmpty(name))
                    action.SqlWhere(SmsContactInfo.Columns.Name, name, RelationEnum.Like);
                if (!string.IsNullOrEmpty(phone))
                    action.SqlWhere(SmsContactInfo.Columns.Mobile, phone, RelationEnum.Like);
                action.SqlPageParms(pagesize);
                return action.QueryPage<SmsContactInfo>(pageindex);
            }
        }

        public SmsContactInfo GetContact(int id)
        {
            using (SelectAction action = new SelectAction(this.Entity))
            {
                action.SqlWhere(SmsContactInfo.Columns.ID, id);
                return action.QueryEntity<SmsContactInfo>();
            }
        }

        public void DeleteContact(string ids)
        {
            using (DeleteAction action = new DeleteAction(this.Entity))
            {
                action.SqlWhere(SmsContactInfo.Columns.ID, ids, ConditionEnum.And, RelationEnum.In);
                action.Excute();
            }
        }

        public void ImportList(List<SmsContactInfo> contacts, int groupid)
        {
            if (contacts.Count > 0)
            {
                using (TradAction action = new TradAction())
                {
                    List<string> sqls = new List<string>();
                    foreach (var filterkey in contacts)
                    {
                        InserAction inserAction = new InserAction(filterkey);
                        sqls.Add(inserAction.CreateSql(OperateEnum.Insert));

                    }
                    action.ExecuteSqlTran(sqls);

                }
                string ids = "";
                using (SelectAction action = new SelectAction(this.Entity))
                {
                    action.SqlClomns = " min(id) as id ";
                    action.SqlGroupBy("Mobile,EnterpriseID,GroupID HAVING COUNT(1)>1");
                    action.SqlWhere("EnterpriseID", contacts[0].EnterpriseId);
                    if (groupid > 0)
                        action.SqlWhere("GroupID", groupid);
                    action.SqlPageParms(-1);
                    List<SmsBlackphoneInfo> idlist = action.QueryPage<SmsBlackphoneInfo>(0);

                    foreach (SmsBlackphoneInfo info in idlist)
                    {
                        ids += info.ID + ",";
                    }

                }
                using (DeleteAction taction = new DeleteAction(this.Entity))
                {
                    taction.SqlWhere(SmsBlackphoneInfo.Columns.ID, ids.TrimEnd(','), ConditionEnum.And,
                                     RelationEnum.In);
                    taction.SqlWhere(SmsBlackphoneInfo.Columns.EnterpriseID, contacts[0].EnterpriseId);

                    taction.Excute();
                }
            }
        }

        public List<SmsContactInfo> GetContacts(List<string> cids, int enterpriseId)
        {
            List<SmsContactInfo> infos = new List<SmsContactInfo>();
            string ids = "";
            int index = 0;
            foreach (string id in cids)
            {
                index++;
                ids += id + ",";
                if (index % 100 == 0 || index == cids.Count)
                {
                    using (SelectAction action = new SelectAction(this.Entity))
                    {
                        action.SqlWhere(SmsContactInfo.Columns.ID, ids.TrimEnd(','), ConditionEnum.And, RelationEnum.In);
                        action.SqlWhere(SmsContactInfo.Columns.EnterpriseId, enterpriseId);
                        action.SqlPageParms(-1);
                        List<SmsContactInfo> result = action.QueryPage<SmsContactInfo>(0);
                        if (result != null && result.Count > 0)
                            infos.AddRange(result);

                    }
                }

            }
            return infos;
        }
    }
}
