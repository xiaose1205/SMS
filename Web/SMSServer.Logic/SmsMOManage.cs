using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloData.FrameWork.Data;
using HelloData.FrameWork.Data.Enum;

namespace SMSServer.Logic
{
    public class SmsMOManage : BaseManager<SmsMOManage, SmsMoInfo>
    {

        public List<SmsMoInfo> GetUserMo(string username, string password)
        {
            using (SelectAction action = new SelectAction(""))
            {
                action.SqlClomns = "_SmsMoInfo.*";
                {
                    //添加视图的关联关系
                    List<QueryField> field = new List<QueryField>();
                    field.Add(new QueryField()
                    {
                        Value = SmsMoInfo.Columns.AccountID,
                        Condition = ConditionEnum.And,
                        FiledName = SmsAccountInfo.Columns.ID
                    });
                    action.AddJoin(ViewJoinEnum.innerjoin, "SmsAccountInfo", "SmsMoInfo", field);
                }
                action.SqlWhere(SmsAccountInfo.Columns.Account, username);
                action.SqlWhere(SmsAccountInfo.Columns.Password, password);
                action.PageSize = 20;
                return action.QueryPage<SmsMoInfo>(1);
            }
        }
    }
}
