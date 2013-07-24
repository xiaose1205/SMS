using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloData.FrameWork.Data;
using HelloData.FrameWork.Data.Enum;

namespace SMSServer.Logic
{
    public class Sms_AddRecordManage : BaseManager<Sms_AddRecordManage, Sms_AddRecord>
    {
        /// <summary>
        /// 获取账号的基本信息
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Sms_AddRecord GetAccountInfo(string username, string password)
        {
            using (SelectAction action = new SelectAction(Entity))
            {
                action.SqlClomns = "_Sms_AddRecord.*";
                {
                    //添加视图的关联关系
                    List<WhereField> field = new List<WhereField>();
                    field.Add(new WhereField()
                    {
                        FiledName = Sms_AddRecord.Columns.AccountID,
                        Condition = ConditionEnum.And,
                        Value = Sms_Account.Columns.ID
                    });
                    action.AddJoin(ViewJoinEnum.leftjoin, "Sms_Account", "Sms_AddRecord", field);
                }
                action.SqlWhere(Sms_Account.Columns.Account, username);
                action.SqlWhere(Sms_Account.Columns.Password, password);
                action.SqlOrderBy("_Sms_AddRecord." + Sms_AddRecord.Columns.CreateTime, OrderByEnum.Desc);
                return action.QueryEntity<Sms_AddRecord>();
            }
        }
    }
}
