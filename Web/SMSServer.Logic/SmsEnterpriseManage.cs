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
            using (SelectAction action = new SelectAction("`sms_enterprise` AS e"))
            {
                action.SqlClomns = "e.*,(select CfgValue from sms_enterprise_cfg WHERE CfgKey='smsprice' AND enterpriseid=e.`ID`) AS SmsPrice," +
                                   "(select CfgValue from sms_enterprise_cfg WHERE CfgKey='chinamobile' AND enterpriseid=e.`ID`) AS chinamobile," +
                                     "(select CfgValue from sms_enterprise_cfg WHERE CfgKey='union' AND enterpriseid=e.`ID`) AS `union`," +
                                       "(select CfgValue from sms_enterprise_cfg WHERE CfgKey='cdma' AND enterpriseid=e.`ID`) AS cdma," +
                                         "(select CfgValue from sms_enterprise_cfg WHERE CfgKey='smslength' AND enterpriseid=e.`ID`) AS smslength" +
                                   "";
                action.SqlPageParms(PageSize);
                return action.QueryPage<SmsEnterpriseInfo>(PageIndex);
            }
        }

        public void UpdatePrice(int enterpriseid, float prices)
        {
            if (prices > 0)
                using (TradAction action = new TradAction())
                {
                    string sql = "update sms_enterprise set Capital=Capital-" + prices + " where id=" + enterpriseid + "";
                    action.Excute(sql);
                }
        }
    }
}
