using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloData.FrameWork.Data;
using HelloData.FrameWork.Data.Enum;

namespace SMSServer.Logic
{
    public class Sms_MOManage : BaseManager<Sms_MOManage, Sms_MO>
    {

        public List<Sms_MO> GetUserMo(string username, string password)
        {
            using (SelectAction action = new SelectAction(""))
            {
                action.SqlClomns = "_Sms_MO.*";
                {
                    //添加视图的关联关系
                    List<QueryField> field = new List<QueryField>();
                    field.Add(new QueryField()
                    {
                        Value = Sms_MO.Columns.AccountID,
                        Condition = ConditionEnum.And,
                        FiledName = Sms_Account.Columns.ID
                    });
                    action.AddJoin(ViewJoinEnum.innerjoin, "Sms_Account", "Sms_MO", field);
                }
                action.SqlWhere(Sms_Account.Columns.Account, username);
                action.SqlWhere(Sms_Account.Columns.Password, password);
                action.PageSize = 20;
                return action.QueryPage<Sms_MO>(1);
            }
        }
    }
}
