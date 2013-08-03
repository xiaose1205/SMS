using HelloData.FrameWork.Data;

namespace SMSServer.Logic
{
    public class SmsAccountManage : BaseManager<SmsAccountManage, SmsAccountInfo>
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
                action.SqlKeyValue(SmsAccountInfo.Columns.Password, newpwd);
                action.SqlWhere(SmsAccountInfo.Columns.Account, username);
                action.SqlWhere(SmsAccountInfo.Columns.Password, password);
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
        public SmsAccountInfo GetAccountInfo(string username, string password)
        {
            using (SelectAction action = new SelectAction(Entity))
            {
                action.SqlWhere(SmsAccountInfo.Columns.Account, username);
                action.SqlWhere(SmsAccountInfo.Columns.Password, password);
                return action.QueryEntity<SmsAccountInfo>();
            }

        }
    }
}
