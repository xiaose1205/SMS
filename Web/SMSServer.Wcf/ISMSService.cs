using System.Collections.Generic;
using System.ServiceModel;
using SMSServer.Wcf.Models;
using SMSServer.Wcf.Response;

namespace SMSServer.Wcf
{
    [ServiceContract]
    public interface ISMSServer
    {
        /// <summary>
        /// 测试
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [OperationContract]
        string GetDataTest(int value);

        /// <summary>
        /// 发送短信，支持大数量发送
        /// </summary>
        /// <param name="messageDatas"></param>
        /// <param name="timeingTime"></param>
        /// <returns></returns>
        [OperationContract]
        PostMsgResponse PostMsgMass(string username, string password, List<string> mobiles, string content, int timeingTime);
        /// <summary>
        /// 发送短信，支持大数量发送
        /// </summary>
        /// <param name="messageDatas"></param>
        /// <param name="timeingTime"></param>
        /// <returns></returns>
        [OperationContract]
        PostMsgResponse PostMsgGroup(string username, string password, List<MessageData> messageDatas, int timeingTime);
        /// <summary>
        /// 获取账号信息包含余额
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [OperationContract]
        GetAccountInfoResponse GetAccountBalance(string username, string password);
        /// <summary>
        /// 获取上行
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        GetMoResponse GetMoMessage(string username, string password);
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="newpassword"></param>
        /// <returns></returns>
        [OperationContract]
        ModifyResponse ModifyPassword(string username, string password, string newpassword);
        /// <summary>
        /// 充值
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        ChargeResponse ChargeMoney(string username, string password, double money);

    }



}
