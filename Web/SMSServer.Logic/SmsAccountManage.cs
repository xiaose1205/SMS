using HelloData.FWCommon.DEncrypt;
using HelloData.FrameWork.Data;

namespace SMSServer.Logic
{
    public class SmsAccountManage : BaseManager<SmsAccountManage, SmsAccountInfo>
    {
        private MD5Encrypt md5 = new MD5Encrypt();
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
                action.SqlWhere(SmsAccountInfo.Columns.Password, md5.Encrypt(password));
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
                action.SqlWhere(SmsAccountInfo.Columns.Password, md5.Encrypt(password));
                return action.QueryEntity<SmsAccountInfo>();
            }

        }

        public void AddAccount(SmsAccountInfo info)
        {
            info.Password = md5.Encrypt(info.Password);
            base.Add(info);
        }

        public void EditAccount(SmsAccountInfo info)
        {
            base.Save(info);
        }

        public void DeleteAccount(string ids)
        {
            using (DeleteAction action = new DeleteAction(this.Entity))
            {
                action.SqlWhere(SmsEnterpriseInfo.Columns.ID, ids, ConditionEnum.And, RelationEnum.In);
                action.Excute();
            }
        }

        public PageList<SmsAccountInfo> GetList(int PageIndex, int PageSize)
        {
            using (SelectAction action = new SelectAction(this.Entity))
            {
                action.SqlPageParms(PageSize);
                return action.QueryPage<SmsAccountInfo>(PageIndex);
            }
        }

        public void UpdatePwd(string pwd, string accountid)
        {
            using (TradAction action = new TradAction())
            {
                string sql = "update sms_account set `PASSWORD`='" + md5.Encrypt(pwd) + "' where id=" + accountid + "";
                action.Excute(sql);
            }
        }

        public void SetStae(string ids, int state)
        {
            using (TradAction action = new TradAction())
            {
                string sql = "update sms_account set `state`='" + state + "' where id in (" + ids + ")";
                action.Excute(sql);
            }
        }

        public SmsAccountInfo GetAccount(int id)
        {
            using (SelectAction action = new SelectAction(this.Entity))
            {
                action.SqlWhere(SmsAccountInfo.Columns.ID, id);
                return action.QueryEntity<SmsAccountInfo>();
            }
        }

        public bool UpdateMyPwd(string pwd, string accountid, string oldpwd)
        {
            using (TradAction action = new TradAction())
            {
                string sql = "update sms_account set `PASSWORD`='" + md5.Encrypt(pwd) + "' where id=" + accountid + " and `PASSWORD`='" + md5.Encrypt(oldpwd) + "'";
                 action.Excute(sql);
                 return action.ReturnCode > 0;
            }
        }
    }
}
