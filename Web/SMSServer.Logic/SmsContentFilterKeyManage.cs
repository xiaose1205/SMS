using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloData.FrameWork.Data;

namespace SMSServer.Logic
{
    public class SmsContentfilterkeyManage : BaseManager<SmsContentfilterkeyManage, SmsContentfilterkeyInfo>
    {
        public PageList<SmsContentfilterkeyInfo> GetList(int PageIndex, int PageSize)
        {
            using (SelectAction action = new SelectAction(this.Entity))
            {
                action.SqlPageParms(PageSize);
                return action.QueryPage<SmsContentfilterkeyInfo>(PageIndex);
            }
        }

        public void AddKeyword(SmsContentfilterkeyInfo info)
        {
            base.Add(info);
        }

        public void EditKeyword(SmsContentfilterkeyInfo info)
        {
            base.Save(info);
        }

        public void DeleteKeyword(string ids)
        {
            using (DeleteAction action = new DeleteAction(this.Entity))
            {
                action.SqlWhere(SmsContentfilterkeyInfo.Columns.ID, ids, ConditionEnum.And, RelationEnum.In);
                action.Excute();
            }
        }

        public void ClearKeyword(int EnterpriseID)
        {
            using (DeleteAction action = new DeleteAction(this.Entity))
            {
                action.SqlWhere(SmsContentfilterkeyInfo.Columns.EnterpriseID, EnterpriseID);
                action.Excute();
            }
        }

        public SmsContentfilterkeyInfo GetInfo(int id)
        {
            using (SelectAction action = new SelectAction(this.Entity))
            {
                action.SqlWhere(SmsContentfilterkeyInfo.Columns.ID, id);
                return action.QueryEntity<SmsContentfilterkeyInfo>();
            }
        }
    }
}
