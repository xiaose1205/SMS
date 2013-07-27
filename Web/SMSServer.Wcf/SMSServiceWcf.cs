using System;
using System.Collections.Generic;
using HelloData.FWCommon.Cache;
using SMSServer.Logic;
using SMSServer.Wcf.Models;
using SMSServer.Util;
using SMSServer.Wcf.Response;
using SMSServer.Models;


namespace SMSServer.Wcf
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“Service1”。
    public class SMSServerWcf : ISMSServer
    {
        /// <summary>
        /// 测试
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string GetDataTest(int value)
        {
            return string.Format("You entered: {0},success字符：123ASDa测试<>[](*&%^)!", value);
        }
        /// <summary>
        /// 获取账号信息包含余额
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public GetAccountInfoResponse GetAccountBalance(string username, string password)
        {
            if (!CheckUtil.CheckAccount(username, password))
                return (GetAccountInfoResponse)CheckUtil.CreateResponse(ResponseCodeEnum.ACCOUNT_ERROR);
            GetAccountInfoResponse response = new GetAccountInfoResponse();
            try
            {
                Sms_AddRecord addRecord = Sms_AddRecordManage.Instance.GetAccountInfo(username, password);
                response.AccountInfo = new AccountModel();
                response.AccountInfo.Mount = addRecord.AfterAdd.HasValue ? addRecord.AfterAdd.Value : 0;
            }
            catch (Exception exception)
            {
                return (GetAccountInfoResponse)CheckUtil.CreateResponse(ResponseCodeEnum.INNER_EXCEPTION, exception.Message);
            }
            return response;
        }
        /// <summary>
        /// 获取上行
        /// </summary>
        /// <returns></returns>
        public GetMoResponse GetMoMessage(string username, string password)
        {
            if (!CheckUtil.CheckAccount(username, password))
                return (GetMoResponse)CheckUtil.CreateResponse(ResponseCodeEnum.ACCOUNT_ERROR);
            GetMoResponse response = new GetMoResponse();
            try
            {

                List<Sms_MO> smsMos = Sms_MOManage.Instance.GetUserMo(username, password);
                response.MoModels = new List<MoModel>();
                foreach (Sms_MO mo in smsMos)
                {
                    response.MoModels.Add(new MoModel
                                              {
                                                  Content = mo.Content,
                                                  Mobile = mo.Phone,
                                                  MsgID = mo.ID,
                                                  RecTime = mo.ReceiveTime.HasValue ? mo.ReceiveTime.Value : DateTime.Now
                                              });
                }
            }
            catch (Exception exception)
            {
                return (GetMoResponse)CheckUtil.CreateResponse(ResponseCodeEnum.INNER_EXCEPTION, exception.Message);
            }

            Console.WriteLine(response.Code);
            return response;
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="newpassword"></param>
        /// <returns></returns>
        public ModifyResponse ModifyPassword(string username, string password, string newpassword)
        {
            ModifyResponse modifyResponse = new ModifyResponse();
            try
            {
                if (!CheckUtil.CheckAccount(username, password))
                    return (ModifyResponse)CheckUtil.CreateResponse(ResponseCodeEnum.ACCOUNT_ERROR);
                if (string.IsNullOrEmpty(newpassword))
                    return (ModifyResponse)CheckUtil.CreateResponse(ResponseCodeEnum.MODIFY_ERROR);
                modifyResponse.IsSuccess = Sms_AccountManage.Instance.UpdatePwd(username, password, newpassword);
                if (modifyResponse.IsSuccess)
                   CacheHelper.Remove(CheckUtil.AcctountCachePre + username);
            }
            catch (Exception exception)
            {
                return (ModifyResponse)CheckUtil.CreateResponse(ResponseCodeEnum.INNER_EXCEPTION, exception.Message);
            }
            return modifyResponse;
        }
        /// <summary>
        /// 充值
        /// </summary>
        /// <returns></returns>
        public ChargeResponse ChargeMoney(string username, string password, double money)
        {
            if (!CheckUtil.CheckAccount(username, password))
                return (ChargeResponse)CheckUtil.CreateResponse(ResponseCodeEnum.ACCOUNT_ERROR);
            return null;
        }

        public PostMsgResponse PostMsgMass(string username, string password, List<string> mobiles, string content, int timeingTime)
        {
            if (!CheckUtil.CheckAccount(username, password))
                return (PostMsgResponse)CheckUtil.CreateResponse(ResponseCodeEnum.ACCOUNT_ERROR);
            return null;
        }

        public PostMsgResponse PostMsgGroup(string username, string password, List<MessageData> messageDatas, int timeingTime)
        {
            if (!CheckUtil.CheckAccount(username, password))
                return (PostMsgResponse)CheckUtil.CreateResponse(ResponseCodeEnum.ACCOUNT_ERROR);
            if (messageDatas.Count == 0)
                return (PostMsgResponse)CheckUtil.CreateResponse(ResponseCodeEnum.ACCOUNT_ERROR);

            return null;
        }
    }
}
