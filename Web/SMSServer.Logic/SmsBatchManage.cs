using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloData.FrameWork.Data;
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
    }
}
