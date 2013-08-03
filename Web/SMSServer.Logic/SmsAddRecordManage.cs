using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloData.FrameWork.Data;
using HelloData.FrameWork.Data.Enum;

namespace SMSServer.Logic
{
    public class SmsAddRecordManage : BaseManager<SmsAddRecordManage, SmsAddrecordInfo>
    {
        /// <summary>
        /// 获取账号的基本信息
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public SmsAddrecordInfo GetAccountInfo(string username, string password)
        {
            using (SelectAction action = new SelectAction(Entity))
            {
                action.SqlClomns = "_Sms_AddRecord.*";
                {
                    //添加视图的关联关系
                    List<QueryField> field = new List<QueryField>();
                    field.Add(new QueryField()
                    {
                        FiledName = SmsAddrecordInfo.Columns.AccountID,
                        Condition = ConditionEnum.And,
                        Value = SmsAccountInfo.Columns.ID
                    });
                    action.AddJoin(ViewJoinEnum.leftjoin, "SmsAccountInfo", "Sms_AddRecord", field);
                }
                action.SqlWhere(SmsAccountInfo.Columns.Account, username);
                action.SqlWhere(SmsAccountInfo.Columns.Password, password);
                action.SqlOrderBy("_Sms_AddRecord." + SmsAddrecordInfo.Columns.CreateTime, OrderByEnum.Desc);
                return action.QueryEntity<SmsAddrecordInfo>();
            }
        }
    }
}
