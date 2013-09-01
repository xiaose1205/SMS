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
                    action.AddJoin(ViewJoinEnum.innerjoin, "sms_account", "sms_mo", field);
                }
                action.SqlWhere(SmsAccountInfo.Columns.Account, username);
                action.SqlWhere(SmsAccountInfo.Columns.Password, password);
                action.PageSize = 20;
                return action.QueryPage<SmsMoInfo>(1);
            }
        }

        public PageList<SmsMoInfo> GetList(int PageIndex, int PageSize, string phone, string content, string starttime, string endtime,int eid)
        {
            using (SelectAction action = new SelectAction(this.Entity))
            {
               
                if (!string.IsNullOrEmpty(phone))
                    action.SqlWhere(SmsMoInfo.Columns.Phone, phone, ConditionEnum.And, RelationEnum.Like);
                if (!string.IsNullOrEmpty(content))
                    action.SqlWhere(SmsMoInfo.Columns.Content, content, ConditionEnum.And, RelationEnum.Like);
                if (!string.IsNullOrEmpty(starttime) && string.IsNullOrEmpty(endtime))
                    action.SqlWhere(SmsMoInfo.Columns.ReceiveTime, starttime, ConditionEnum.And, RelationEnum.LargeThen);
                if (!string.IsNullOrEmpty(endtime) && string.IsNullOrEmpty(starttime))
                    action.SqlWhere(SmsMoInfo.Columns.ReceiveTime, endtime, ConditionEnum.And, RelationEnum.LessThen);
                if (!string.IsNullOrEmpty(endtime) && !string.IsNullOrEmpty(starttime))
                    action.SqlWhere(SmsMoInfo.Columns.ReceiveTime, starttime, endtime, ConditionEnum.And, RelationEnum.Between);
                action.PageSize = PageSize;
                action.SqlOrderBy(SmsMoInfo.Columns.CreateTime, OrderByEnum.Desc);
                return action.QueryPage<SmsMoInfo>(PageIndex); 
            }
        }
    }
}
