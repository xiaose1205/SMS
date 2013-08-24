#region Version Info
/* ========================================================================
* 【本类功能概述】
* 
* 作者：王军 时间：2013/8/23 23:16:15
* 文件名：SmsContactGroupManage
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
    public class SmsContactGroupManage : BaseManager<SmsContactGroupManage, SmsContactgroupInfo>
    {

        public List<SmsContactgroupInfo> getList(int parentId)
        {
            using (SelectAction action = new SelectAction(this.Entity))
            {
                action.SqlWhere(SmsContactgroupInfo.Columns.ParentGroupID, parentId);
                action.SqlPageParms(-1);
                return action.QueryPage<SmsContactgroupInfo>(0);
            }
        }

        public int AddGroup(SmsContactgroupInfo entity)
        {
            using (InserAction inserAction = new InserAction(entity))
            {
                inserAction.ExcuteIdentity();
                return inserAction.ReturnCode;
            }
        }

        public int UpdateGroup(SmsContactgroupInfo info)
        {
            using (UpdateAction action = new UpdateAction(this.Entity))
            {
                action.SqlKeyValue(SmsContactgroupInfo.Columns.Name, info.Name);
                action.SqlWhere(SmsContactgroupInfo.Columns.ID, info.ID);
                return action.Excute().ReturnCode;
            }
        }

        public int DelGroup(int groupId)
        {
            using (DeleteAction action = new DeleteAction(this.Entity))
            {
                action.SqlWhere(SmsContactgroupInfo.Columns.ID, groupId);
                return action.Excute().ReturnCode;
            }
        }
    }
}
