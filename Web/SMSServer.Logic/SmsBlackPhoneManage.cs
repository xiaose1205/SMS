using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloData.FrameWork.Data;

namespace SMSServer.Logic
{
    public class SmsBlackPhoneManage : BaseManager<SmsBlackPhoneManage, SmsBlackphoneInfo>
    {
        public PageList<SmsBlackphoneInfo> GetList(int PageIndex, int PageSize, int enterpriseId)
        {
            using (SelectAction action = new SelectAction(this.Entity))
            {
                action.SqlWhere(SmsBlackphoneInfo.Columns.EnterpriseID, enterpriseId);
                action.SqlPageParms(PageSize);
                return action.QueryPage<SmsBlackphoneInfo>(PageIndex);
            }
        }

        public void AddBlack(SmsBlackphoneInfo info)
        {
            base.Add(info);
        }

        public void EditBlack(SmsBlackphoneInfo info)
        {
            base.Save(info);
        }

        public void DeleteBlack(string ids)
        {
            using (DeleteAction action = new DeleteAction(this.Entity))
            {
                action.SqlWhere(SmsBlackphoneInfo.Columns.ID, ids, ConditionEnum.And, RelationEnum.In);
                action.Excute();
            }
        }

        public void ClearBlack(int EnterpriseID)
        {
            using (DeleteAction action = new DeleteAction(this.Entity))
            {
                action.SqlWhere(SmsBlackphoneInfo.Columns.EnterpriseID, EnterpriseID);
                action.Excute();
            }
        }

        public SmsBlackphoneInfo GetInfo(int id)
        {
            using (SelectAction action = new SelectAction(this.Entity))
            {
                action.SqlWhere(SmsBlackphoneInfo.Columns.ID, id);
                return action.QueryEntity<SmsBlackphoneInfo>();
            }
        }

        public void ImportList(List<SmsBlackphoneInfo> blacks)
        {
            if (blacks.Count > 0)
            {
                using (TradAction action = new TradAction())
                {
                    List<string> sqls = new List<string>();
                    foreach (var filterkey in blacks)
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
                    action.SqlGroupBy("Phone,EnterpriseID HAVING COUNT(1)>1");
                    action.SqlWhere("EnterpriseID", blacks[0].EnterpriseID);
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
                    taction.SqlWhere(SmsBlackphoneInfo.Columns.EnterpriseID, blacks[0].EnterpriseID);

                    taction.Excute();
                }
            }
        }
    }
}
