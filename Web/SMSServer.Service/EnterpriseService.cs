#region Version Info
/* ========================================================================
* 【本类功能概述】
* 
* 作者：王军 时间：2013/8/5 23:24:08
* 文件名：EnterpriseService
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
using SMSServer.Logic;
using SMSService.Logic;

namespace SMSServer.Service
{
    public class EnterpriseService
    {


        public SmsEnterpriseCfgInfo GetModelWithKey(string cfgkey, int enterpriseId)
        {
            return SmsEnterpriseCfgManage.Instance.GetModelWithKey(cfgkey, enterpriseId);
        }

        public List<SmsEnterpriseInfo> GetEnterprise()
        {
            return SmsEnterpriseManage.Instance.GetList(0, -1);
        }
        public  SmsEnterpriseInfo  GetEnterpriseInfo(int enterpriseID)
        {
            return SmsEnterpriseManage.Instance.FindById(enterpriseID);
        }
        public int[] GetChannels(SmsEnterpriseCfgInfo cfg)
        {
            if (cfg == null)
                return new int[0];
            if (string.IsNullOrEmpty(cfg.CfgValue))
                return new int[0];
            string[] array = cfg.CfgValue.Split(',');
            int[] iArray = new int[array.Length];
            for (int a = 0; a < array.Length; a++)
            {
                try
                {
                    iArray[a] = int.Parse(array[a]);
                }
                catch (Exception)
                {
                }
            }
            return iArray;

        }
    }
}
