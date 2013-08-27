using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloData.FrameWork.Data;

namespace SMSServer.Logic
{
    public class SmsEnterpriseManage : BaseManager<SmsEnterpriseManage, SmsEnterpriseInfo>
    {
        public void AddEnterprise(SmsEnterpriseInfo info)
        {
            base.Add(info);
        }

        public void EditEnterprise(SmsEnterpriseInfo info)
        {
            base.Save(info);
        }

        public void DeleteEnterprise(string ids)
        {
            using (DeleteAction action = new DeleteAction(this.Entity))
            {
                action.SqlWhere(SmsEnterpriseInfo.Columns.ID, ids, ConditionEnum.And, RelationEnum.In);
                action.Excute();
            }
        }

        public PageList<SmsEnterpriseInfo> GetList(int PageIndex, int PageSize)
        {
            using (SelectAction action = new SelectAction(this.Entity))
            {
                action.SqlPageParms(PageSize);
                return action.QueryPage<SmsEnterpriseInfo>(PageIndex);
            }
        }
    }
}
