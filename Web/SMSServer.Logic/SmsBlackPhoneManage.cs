using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloData.FrameWork.Data;

namespace SMSServer.Logic
{
    public class SmsBlackPhoneManage : BaseManager<SmsBlackPhoneManage, SmsBlackphoneInfo>
    {
        public PageList<SmsBlackphoneInfo> GetList(int PageIndex, int PageSize)
        {
            using (SelectAction action = new SelectAction(this.Entity))
            {
                action.SqlPageParms(PageSize);
                return action.QueryPage<SmsBlackphoneInfo>(PageIndex);
            }
        }

        public void AddBlack(SmsBlackphoneInfo info)
        {
            base.Add(info);
        }

        public void EditBlack(SmsBlackphoneInfo info)
        {
            base.Save(info);
        }

        public void DeleteBlack(string ids)
        {
            using (DeleteAction action = new DeleteAction(this.Entity))
            {
                action.SqlWhere(SmsBlackphoneInfo.Columns.ID, ids,ConditionEnum.And,RelationEnum.In);
                action.Excute();
            }
        }

        public void ClearBlack(int EnterpriseID)
        {
            using (DeleteAction action = new DeleteAction(this.Entity))
            {
                action.SqlWhere(SmsBlackphoneInfo.Columns.EnterpriseID, EnterpriseID);
                action.Excute();
            }
        }

        public SmsBlackphoneInfo GetInfo(int id)
        {
            using (SelectAction action = new SelectAction(this.Entity))
            {
                action.SqlWhere(SmsBlackphoneInfo.Columns.ID, id);
                return action.QueryEntity<SmsBlackphoneInfo>();
            }
        }
    }
}
