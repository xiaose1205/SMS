#region Version Info
/* ========================================================================
* 【本类功能概述】
* 
* 作者：王军 时间：2013/8/31 22:38:37
* 文件名：DemoService
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
using System.Threading;

namespace SMSServer.OpenPlatform
{
    public class DemoService : BaseService
    {
        public override int SendSMS(SMSSDKMassInfo smsInfos, string extendNub)
        {
            Random iRandom = new Random();
            return iRandom.Next(0, 2);

        }

        public override int SendSMS(List<SDKGroupInfo> smsInfos, string extendNub)
        {
            Random iRandom = new Random();
            return iRandom.Next(0, 2);
        }

        public override string GetStatusreport()
        {
            throw new NotImplementedException();
        }

        public override string Getbalance()
        {
            throw new NotImplementedException();
        }

        public override string Getascending()
        {
            throw new NotImplementedException();
        }



        public override int GetSignNum()
        {
            return 10000;
        }

        public override List<MoInfo> GetMo()
        {
            List<MoInfo> mos = new List<MoInfo>();
            Random iRandom = new Random();
            int size = iRandom.Next(0, 2);
            for (int i = 0; i < size; i++)
            {
                mos.Add(new MoInfo()
                {
                    Content = "dssYUTYUhjkhj hjkh好家伙%……&*（" + DateTime.Now,
                    Phone = DateTime.Now.ToString("13MMddHHmms"),
                    MoTime = DateTime.Now,
                    ExtraNub =( i == 0 ? 123 : 122)+""
                });
                Thread.Sleep(300);
            }
            return mos;
        }

        public override int MassCount()
        {
            return 70;
        }

        public override int GroupCount()
        {
            return 1;
        }

        public override SendUser SendUser { get; set; }
    }
}
