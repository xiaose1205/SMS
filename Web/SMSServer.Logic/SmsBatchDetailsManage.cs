using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloData.FrameWork.Data;
using HelloData.FrameWork.Data.Enum;
using SMSService.Entity;

namespace SMSServer.Logic
{
    public class SmsBatchDetailsManage : BaseManager<SmsBatchDetailsManage, SmsBatchDetailsInfo>
    {
        public PageList<SmsBatchDetailsMoreInfo> GetList(int PageIndex, int PageSize, string phone, string state, string starttime, string endtime)
        {
            using (SelectAction action = new SelectAction(""))
            {
                action.SqlClomns = "_sms_batch_details.*,_sms_batch.batchname";
                {
                    //添加视图的关联关系
                    List<QueryField> field = new List<QueryField>();
                    field.Add(new QueryField()
                    {
                        Value = SmsBatchDetailsInfo.Columns.BatchID,
                        Condition = ConditionEnum.And,
                        FiledName = SmsBatchInfo.Columns.ID
                    });
                    action.AddJoin(ViewJoinEnum.innerjoin, "sms_batch", "sms_batch_details", field);
                }
                if (!string.IsNullOrEmpty(phone))
                    action.SqlWhere(SmsBatchDetailsInfo.Columns.Phone, phone);
                if (!string.IsNullOrEmpty(state) && int.Parse(state) > 0)
                    action.SqlWhere(SmsBatchDetailsInfo.Columns.State, state);
                if (!string.IsNullOrEmpty(starttime) && string.IsNullOrEmpty(endtime))
                    action.SqlWhere(SmsBatchDetailsInfo.Columns.SubmitTime, starttime, ConditionEnum.And, RelationEnum.LargeThen);
                if (!string.IsNullOrEmpty(endtime) && string.IsNullOrEmpty(starttime))
                    action.SqlWhere(SmsBatchDetailsInfo.Columns.SubmitTime, endtime, ConditionEnum.And, RelationEnum.LessThen);
                if (!string.IsNullOrEmpty(endtime) && !string.IsNullOrEmpty(starttime))
                    action.SqlWhere(SmsBatchDetailsInfo.Columns.SubmitTime, starttime, endtime, ConditionEnum.And, RelationEnum.Between);

                action.PageSize = PageSize;
                return action.QueryPage<SmsBatchDetailsMoreInfo>(PageIndex);
            }
        }
    }
}
