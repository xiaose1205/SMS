using HelloData.FrameWork.Data;

namespace SMSServer.Logic
{
    public class Sms_AccountManage : BaseManager<Sms_AccountManage, Sms_Account>
    {

        /// <summary>
        /// 更新密码
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="newpwd"></param>
        /// <returns></returns>
        public bool UpdatePwd(string username, string password, string newpwd)
        {
            using (UpdateAction action = new UpdateAction(Entity))
            {
                action.SqlKeyValue(Sms_Account.Columns.Password, newpwd);
                action.SqlWhere(Sms_Account.Columns.Account, username);
                action.SqlWhere(Sms_Account.Columns.Password, password);
                action.Excute();
                return action.ReturnCode > 0;
            }
        }
        /// <summary>
        /// 获取账号的基本信息
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Sms_Account GetAccountInfo(string username, string password)
        {
            using (SelectAction action = new SelectAction(Entity))
            {
                action.SqlWhere(Sms_Account.Columns.Account, username);
                action.SqlWhere(Sms_Account.Columns.Password, password);
                return action.QueryEntity<Sms_Account>();
            }

        }
    }
}
