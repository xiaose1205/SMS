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
    }
}
