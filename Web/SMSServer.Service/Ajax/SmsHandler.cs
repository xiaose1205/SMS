#region Version Info
/* ========================================================================
* 【本类功能概述】
* 
* 作者：王军 时间：2013/8/25 02:02:46
* 文件名：SmsHandler
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
using HelloData.FWCommon;
using HelloData.Web.AppHandlers;

namespace SMSServer.Service.Ajax
{
    public class SmsHandler : BaseHandler
    {
        private class SendInfo
        {
            public string Mobiles { get; set; }
            
            public string Content { get; set; }
            //批次名称
            public string BatchName { get; set; }
            //批次备注
            public string BatchRemark { get; set; }
            //是否过滤关键词
            public string FKeyword { get; set; }
            //是否过滤黑名单
            public string FBlack { get; set; }
            // 是否过滤重复号码
            public string FRepeat { get; set; }

            public int AccountID { get; set; }

            public int EnterpriseID { get; set; }
        }

        public override HelloData.AppHandlers.IAppHandler CreateInstance()
        {
            return new BlackHandler();
        }

        public override string HandlerName
        {
            get { return "sms"; }
        }

        public HandlerResponse SendSMS()
        {
            string mobiles = Request.Params["mobiles"];
            string content = Request.Params["content"];
            string batchname = Request.Params["batchname"];
            string batchremark = Request.Params["batchremark"];
            string fkeyword = Request.Params["fkeyword"];
            string fblack = Request.Params["fblack"];
            string frepeat = Request.Params["frepeat"];
            if (string.IsNullOrEmpty(mobiles) || string.IsNullOrEmpty(content))
                return CreateHandler(0, "联系人与短信内容不能为空");
            if (string.IsNullOrEmpty(batchname))
                batchname = DateTime.Now.ToString("批次yyyyMMddHHmmss");
            SendInfo sendinfo = new SendInfo();

            /*wait,batch,count三个表，mt表不需要了*/
            ThreadPool.QueueUserWorkItem(new WaitCallback(SendPool), sendinfo);
            return CreateHandler(1,"批次提交成功，后台正在处理中...");
        }

        public void SendPool(object sender)
        {

        }
    }
}
