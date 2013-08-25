using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloData.FrameWork.Data;

namespace SMSServer.Logic
{
    public class SmsContentfilterkeyManage : BaseManager<SmsContentfilterkeyManage, SmsContentfilterkeyInfo>
    {
        public PageList<SmsContentfilterkeyInfo> GetList(int PageIndex, int PageSize)
        {
            using (SelectAction action = new SelectAction(this.Entity))
            {
                action.SqlPageParms(PageSize);
                return action.QueryPage<SmsContentfilterkeyInfo>(PageIndex);
            }
        }

        public void AddKeyword(SmsContentfilterkeyInfo info)
        {
            base.Add(info);
        }

        public void EditKeyword(SmsContentfilterkeyInfo info)
        {
            base.Save(info);
        }

        public void DeleteKeyword(string ids)
        {
            using (DeleteAction action = new DeleteAction(this.Entity))
            {
                action.SqlWhere(SmsContentfilterkeyInfo.Columns.ID, ids, ConditionEnum.And, RelationEnum.In);
                action.Excute();
            }
        }

        public void ClearKeyword(int EnterpriseID)
        {
            using (DeleteAction action = new DeleteAction(this.Entity))
            {
                action.SqlWhere(SmsContentfilterkeyInfo.Columns.EnterpriseID, EnterpriseID);
                action.Excute();
            }
        }

        public SmsContentfilterkeyInfo GetInfo(int id)
        {
            using (SelectAction action = new SelectAction(this.Entity))
            {
                action.SqlWhere(SmsContentfilterkeyInfo.Columns.ID, id);
                return action.QueryEntity<SmsContentfilterkeyInfo>();
            }
        }

        public void ImportList(List<SmsContentfilterkeyInfo> keys)
        {
            if (keys.Count > 0)
            {
                using (TradAction action = new TradAction())
                {
                    List<string> sqls = new List<string>();
                    foreach (var filterkey in keys)
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
                    action.SqlGroupBy("keyword,EnterpriseID HAVING COUNT(1)>1");
                    action.SqlWhere("EnterpriseID", keys[0].EnterpriseID);
                    action.SqlPageParms(-1);
                    List<SmsContentfilterkeyInfo> idlist = action.QueryPage<SmsContentfilterkeyInfo>(0);

                    foreach (SmsContentfilterkeyInfo info in idlist)
                    {
                        ids += info.ID + ",";
                    }
                   
                }
                using (DeleteAction taction = new DeleteAction(this.Entity))
                {
                    taction.SqlWhere(SmsContentfilterkeyInfo.Columns.ID, ids.TrimEnd(','), ConditionEnum.And,
                                    RelationEnum.In);
                    taction.SqlWhere(SmsContentfilterkeyInfo.Columns.EnterpriseID, keys[0].EnterpriseID);

                    taction.Excute();
                }
            }

        }
    }
}
