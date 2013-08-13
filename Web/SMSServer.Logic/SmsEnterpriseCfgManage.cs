#region Version Info
/* ========================================================================
* 【本类功能概述】
* 
* 作者：王军 时间：2013/8/9 21:49:48
* 文件名：SmsEnterpriseCfgManage
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
using HelloData.FWCommon.Cache;
using HelloData.FrameWork.Data;
using SMSServer.Logic;

namespace SMSService.Logic
{
    public class SmsEnterpriseCfgManage : BaseManager<SmsEnterpriseCfgManage, SmsEnterpriseCfgInfo>
    {
        public SmsEnterpriseCfgInfo GetModelWithKey(string cfgkey, int enterpriseId)
        {
            string key = "enterprise_" + cfgkey + enterpriseId;
            SmsEnterpriseCfgInfo getCacheValue = CacheHelper.Cache.Get<SmsEnterpriseCfgInfo>(key);
            if (getCacheValue == null)
            {
                using (SelectAction action = new SelectAction(this.Entity))
                {
                    action.SqlWhere(SmsEnterpriseCfgInfo.Columns.CfgKey, cfgkey);
                    SmsEnterpriseCfgInfo info = action.QueryEntity<SmsEnterpriseCfgInfo>();
                    if (info != null)
                    {
                        CacheHelper.Cache.Set(key, info);
                        return info;
                    }
                }
            }
            else
            {
                return getCacheValue;
            }
            return null;
        }
    }
}
