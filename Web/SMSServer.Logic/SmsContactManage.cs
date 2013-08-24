#region Version Info
/* ========================================================================
* 【本类功能概述】
* 
* 作者：王军 时间：2013/8/23 23:14:39
* 文件名：SmsContactManage
* 版本：V1.0.1
* 联系方式：511522329  
*
* 修改者： 时间： 
* 修改说明：
* ========================================================================
*/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloData.FrameWork.Data;

namespace SMSService.Logic
{
    public class SmsContactManage : BaseManager<SmsContactManage, SmsContactInfo>
    {
        public PageList<SmsContactInfo> getList(int pageindex, int pagesize, int gid, string name, string phone)
        {
            using (SelectAction action = new SelectAction(this.Entity))
            {
                if (gid != 0)
                    action.SqlWhere(SmsContactInfo.Columns.GroupID, gid);
                if (!string.IsNullOrEmpty(name))
                    action.SqlWhere(SmsContactInfo.Columns.Name, name, RelationEnum.Like);
                if (!string.IsNullOrEmpty(phone))
                    action.SqlWhere(SmsContactInfo.Columns.Mobile, phone, RelationEnum.Like);
                action.SqlPageParms(pagesize);
                return action.QueryPage<SmsContactInfo>(pageindex);
            }
        }

        public SmsContactInfo GetContact(int id)
        {
            using (SelectAction action = new SelectAction(this.Entity))
            {
                action.SqlWhere(SmsContactInfo.Columns.ID, id);
                return action.QueryEntity<SmsContactInfo>();
            }
        }

        public void DeleteContact(string ids)
        {
            using (DeleteAction action = new DeleteAction(this.Entity))
            {
                action.SqlWhere(SmsContactInfo.Columns.ID, ids, ConditionEnum.And, RelationEnum.In);
                action.Excute();
            }
        }
    }
}
