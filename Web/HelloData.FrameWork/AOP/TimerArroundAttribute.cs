#region Version Info
/* ========================================================================
* 【本类功能概述】
* 
* 作者：王军 时间：2013/4/17 00:10:15
* 文件名：TimerArroundAttribute
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
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace HelloData.FrameWork.AOP
{
    public class TimerArroundAttribute : FWCommon.AOP.ArroundAttribute
    {
        readonly Stopwatch _watch = new Stopwatch();
        public override void BeginAction(FWCommon.AOP.InvokeContext context)
        {
            _watch.Reset();
            _watch.Start();
        }
        public override void EndAction(FWCommon.AOP.InvokeContext context)
        {
            if (!AppCons.LogSqlExcu) return;
            FWCommon.Logging.Logger.CurrentLog.Info(string.Format("耗时: {0} ms\r\n******", _watch.ElapsedMilliseconds));
        }
    }
}
