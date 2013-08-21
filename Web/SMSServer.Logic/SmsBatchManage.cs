using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloData.FrameWork.Data;
using HelloData.FrameWork.Data.Enum;
using SMSService.Entity;

namespace SMSServer.Logic
{
    public class SmsBatchManage : BaseManager<SmsBatchManage, SmsBatchInfo>
    { 
        public List<SendingBatchModel> GetReadyBatch(int batchCount)
        {
            List<SendingBatchModel> models = new List<SendingBatchModel>();
            using (SelectAction action = new SelectAction(this.Entity))
            {
                action.PageSize = batchCount;
                action.SqlWhere(SmsBatchInfo.Columns.BatchState, (int)BatchState.Waiting);
                models = action.QueryPage<SendingBatchModel>(1);
            }
            string ids = "";
            foreach (var sendingBatchModel in models)
            {
                ids += sendingBatchModel.ID + ",";
            }
            using (UpdateAction update = new UpdateAction(this.Entity))
            {
                update.SqlWhere(SmsBatchInfo.Columns.ID, ids.TrimEnd(','), ConditionEnum.And, RelationEnum.In);
                update.SqlKeyValue(SmsBatchInfo.Columns.BatchState, (int) BatchState.Sending);
                update.Excute();
            }
            return models;
        }

        public PageList<BatchMoreInfo> GetList(int PageIndex, int PageSize, string batchname, string state, string starttime, string endtime)
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
                if (!string.IsNullOrEmpty(batchname))
                    action.SqlWhere(SmsBatchDetailsInfo.Columns.Phone, batchname);
                if (!string.IsNullOrEmpty(state) && int.Parse(state) > 0)
                    action.SqlWhere(SmsBatchDetailsInfo.Columns.State, state);
                if (!string.IsNullOrEmpty(starttime) && string.IsNullOrEmpty(endtime))
                    action.SqlWhere(SmsBatchDetailsInfo.Columns.SubmitTime, starttime, ConditionEnum.And, RelationEnum.LargeThen);
                if (string.IsNullOrEmpty(endtime) && string.IsNullOrEmpty(starttime))
                    action.SqlWhere(SmsBatchDetailsInfo.Columns.SubmitTime, endtime, ConditionEnum.And, RelationEnum.LessThen);
                if (!string.IsNullOrEmpty(endtime) && string.IsNullOrEmpty(starttime))
                    action.SqlWhere(SmsBatchDetailsInfo.Columns.SubmitTime, starttime, endtime, ConditionEnum.And, RelationEnum.Between);

                action.PageSize = 20;
                return action.QueryPage<BatchMoreInfo>(PageIndex);
            }
        }
    }
}
