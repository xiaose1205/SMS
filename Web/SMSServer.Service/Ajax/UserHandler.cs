#region Version Info
/* ========================================================================
* 【本类功能概述】
* 
* 作者：王军 时间：2013/8/22 22:29:38
* 文件名：UserHandler
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
using HelloData.FWCommon;
using HelloData.Web.AppHandlers;
using SMSServer.Logic;

namespace SMSServer.Service.Ajax
{
    public class UserHandler : BaseHandler
    {
        public override HelloData.AppHandlers.IAppHandler CreateInstance()
        {
            return new MoHandler();
        }

        public override string HandlerName
        {
            get { return "user"; }
        }

        public HandlerResponse Login()
        {
            string username = Request.Params["username"];
            string password = Request.Params["password"];
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
              return  CreateHandler(0, "用户名或密码不能为空");
          SmsAccountInfo info=  SmsAccountManage.Instance.GetAccountInfo(username, password);
            if(info==null)
                return CreateHandler(0, "用户名或密码错误");
            AppContent.Current.LoginUser(info,DateTime.Now.AddDays(10));
            return CreateHandler(1, "登录成功");
        }
    }
}
