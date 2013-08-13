#region Version Info
/* ========================================================================
* 【本类功能概述】
* 
* 作者：王军 时间：2013/8/6 23:27:04
* 文件名：SendResultEnum
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

namespace SMSService.Entity
{
    public enum SendResultEnum
    {
        /// <summary>
        /// 成功
        /// </summary>
        SUCCESS = 0,
        /// <summary>
        ///  账号无效
        /// </summary>
        INVALID_ACCOUNT = 1,
        /// <summary>
        /// 余额不足
        /// </summary>
        NO_SAVE_ACCOUNT = 2,
        /// <summary>
        /// 用户名密码错误
        /// </summary>
        ACCOUNT_OR_PIN_WRONG = 3,
        /// <summary>
        /// 资金账户不存在
        /// </summary>
        CAPITAL_ACCOUNT_NOT_EXIST = 4,
        /// <summary>
        /// 包号码数量超过最大限制
        /// </summary>
        TOO_LARGE_PACK = 5,
        /// <summary>
        /// 参数无效
        /// </summary>
        INVALID_PARAM = 6,
        /// <summary>
        /// 系统内部错误
        /// </summary>
        INNER_ERROR = 7,
        /// <summary>
        /// 手机或者内容错误
        /// </summary>
        MOBILE_MSG_ERROT = 8
        , CONTACT_ERROR = 9
    }
}
