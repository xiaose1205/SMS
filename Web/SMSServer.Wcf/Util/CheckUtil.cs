using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloData.FWCommon.Cache;
using SMSServer.Wcf.Response;
using SMSServer.Models;
using SMSServer.Logic;
using HelloData.FrameWork.Data;
 

namespace SMSServer.Util
{
    public class CheckUtil
    {
        public const string AcctountCachePre = "Username:";
        public const string TelesegCachePre = "Teleseg:";
        /// <summary>
        /// 验证账号是否合法
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool CheckAccount(string username, string password)
        {
            if (string.IsNullOrEmpty(username)
                || string.IsNullOrEmpty(password)
                || password.Length < 32)
                return false;
            SmsAccountInfo account = CacheHelper.Get<SmsAccountInfo>(AcctountCachePre + username);
            if (account == null)
                account = SmsAccountManage.Instance.GetAccountInfo(username, password);
            if (account == null || account.EnterpriseID == 0)
                return false;
            CacheHelper.Insert(AcctountCachePre + username, account);
            return true;
        }

        public static BaseResponse CreateResponse(ResponseCodeEnum code, string message)
        {
            Console.WriteLine((int)code);
            Console.WriteLine(message);
            return new BaseResponse()
                       {
                           Code = (int)code,
                           Message = message
                       };
        }
        public static BaseResponse CreateResponse(ResponseCodeEnum code)
        {
            string message = string.Empty;
            switch (code)
            {
                case ResponseCodeEnum.ACCOUNT_ERROR:
                    message = "账号或者密码错误";
                    break;
                case ResponseCodeEnum.ACCOUNT_NOEXIT:
                    message = "账号不存在";
                    break;
                case ResponseCodeEnum.SUCCESS:
                    message = "操作成功";
                    break;
                case ResponseCodeEnum.INNER_EXCEPTION:
                    message = "内部错误";
                    break;
                case ResponseCodeEnum.MODIFY_ERROR:
                    message = "修改失败";
                    break;
            }
            return CreateResponse(code, message);
        }

        /// <summary>
        /// 检测号码的合法性
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public static bool CheckMobile(string mobile)
        {
            if (string.IsNullOrEmpty(mobile) || mobile.Length < 10 || mobile.Length > 11)
                return false;
            string mobileFirst = mobile.Substring(0, 1);
            int mobilefirstInt;
            if (!int.TryParse(mobileFirst, out mobilefirstInt))
                return false;
            if (mobilefirstInt != 0 || mobilefirstInt != 1)
                return false;
            PageList<SmsTelesegInfo> telesegs =
               CacheHelper.Get<PageList<SmsTelesegInfo>>(TelesegCachePre);
            if (telesegs == null)
            {
                telesegs = SmsTelesegManage.Instance.FindList(-1, 0); 
                if (telesegs != null && telesegs.Count > 0)
                    CacheHelper.Insert(TelesegCachePre, telesegs);
            }
            string mobile3Pre = mobile.Substring(0, 3);
            if (telesegs != null)
                if (telesegs.Any(smsTeleseg => smsTeleseg.Phone == mobile3Pre))
                    return true; 
            return true;

        }
    }
}
