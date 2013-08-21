#region Version Info
/* ========================================================================
* 【本类功能概述】
* 
* 作者：王军 时间：2013/8/21 00:00:14
* 文件名：SmsTemplateManage
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
using SMSServer.Logic;

namespace SMSService.Logic
{
    public class SmsTemplateManage : BaseManager<SmsTemplateManage, SmsTemplateInfo>
    {
        public PageList<SmsTemplateInfo> GetList(int PageIndex, int PageSize)
        {
            using (SelectAction action = new SelectAction(this.Entity))
            {
                action.SqlPageParms(PageSize);
                return action.QueryPage<SmsTemplateInfo>(PageIndex);
            }
        }

        public void AddTemplate(SmsTemplateInfo info)
        {
            base.Add(info);
        }

        public void EditTemplate(SmsTemplateInfo info)
        {
            base.Save(info);
        }

        public void DeleteTemplate(string ids)
        {
            using (DeleteAction action = new DeleteAction(this.Entity))
            {
                action.SqlWhere(SmsTemplateInfo.Columns.ID, ids, ConditionEnum.And, RelationEnum.In);
                action.Excute();
            }
        }

        public void ClearTemplate(int EnterpriseID)
        {
            using (DeleteAction action = new DeleteAction(this.Entity))
            {
                action.SqlWhere(SmsTemplateInfo.Columns.EnterpriseID, EnterpriseID);
                action.Excute();
            }
        }

        public SmsTemplateInfo GetInfo(int id)
        {
            using (SelectAction action = new SelectAction(this.Entity))
            {
                action.SqlWhere(SmsTemplateInfo.Columns.ID, id);
                return action.QueryEntity<SmsTemplateInfo>();
            }
        }
    }
}
