﻿using System;
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
        public PageList<SmsBatchDetailsMoreInfo> GetList(int PageIndex, int PageSize, string phone, string state, string starttime, string endtime,int eid)
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
                if(eid!=1)
                    action.SqlWhere("_sms_batch."+SmsBatchInfo.Columns.EnterPriseID, eid);
                if (!string.IsNullOrEmpty(phone))
                    action.SqlWhere(SmsBatchDetailsInfo.Columns.Phone, phone,RelationEnum.Like);
                if (!string.IsNullOrEmpty(state) && int.Parse(state) > 0)
                    action.SqlWhere(SmsBatchDetailsInfo.Columns.State, state);
                if (!string.IsNullOrEmpty(starttime) && string.IsNullOrEmpty(endtime))
                    action.SqlWhere(SmsBatchDetailsInfo.Columns.SubmitTime, starttime, ConditionEnum.And, RelationEnum.LargeThen);
                if (!string.IsNullOrEmpty(endtime) && string.IsNullOrEmpty(starttime))
                    action.SqlWhere(SmsBatchDetailsInfo.Columns.SubmitTime, endtime, ConditionEnum.And, RelationEnum.LessThen);
                if (!string.IsNullOrEmpty(endtime) && !string.IsNullOrEmpty(starttime))
                    action.SqlWhere(SmsBatchDetailsInfo.Columns.SubmitTime, starttime, endtime, ConditionEnum.And, RelationEnum.Between);
                action.SqlOrderBy("_sms_batch_details.SubmitTime", OrderByEnum.Desc);
                action.PageSize = PageSize;
                return action.QueryPage<SmsBatchDetailsMoreInfo>(PageIndex);
            }
        }

        public void AddList(List<SmsBatchDetailsInfo> infos)
        {
            using (TradAction action = new TradAction())
            {
                List<string> sqls = new List<string>();
                foreach (var info in infos)
                {
                    InserAction inserAction = new InserAction(info);
                    sqls.Add(inserAction.CreateSql(OperateEnum.Insert));

                }
                action.ExecuteSqlTran(sqls); 
            }
        }
    }
}
