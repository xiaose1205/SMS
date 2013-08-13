using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using HelloData.FWCommon.Logging;

namespace SMSServer.WcfHost
{
    public class BaseService<T> where T : BaseService<T>, new()
    {
        public string ServiceName { get; set; }
        private static T _sInstance = null;
        /// <summary>
        /// 获取当前业务逻辑对象的实例
        /// </summary>
        public static T Instance
        {
            get { return _sInstance ?? (_sInstance = new T()); }
        }
        public ServiceState State { get; set; }
        public bool IsStop = false;
        public int SleepSpan = 1000;
        /// <summary>
        /// star当前服务
        /// </summary>
        public virtual void Star()
        {
            Print("准备启动...");
            if (State != ServiceState.Open)
                ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadStar));
        }
        /// <summary>
        /// 停止当前服务
        /// </summary>
        public virtual void Stop()
        {
            if (CurrenTh != null)
                State = ServiceState.Closing;
        }
        public void Print(string message)
        {
            Logger.CurrentLog.Debug(this.ServiceName + ":" + message);
        }

        public void Print(string message, Exception ex)
        {
            Logger.CurrentLog.Debug(this.ServiceName + ":" + message, ex);
        }
        public void ThreadStar(object sender)
        {
            this.State = ServiceState.Open;
            Print("已经启动...");
            this.CurrenTh = Thread.CurrentThread;
            this.CurrenTh.IsBackground = true;

            while (this.State == ServiceState.Open)
            {
                try
                {
                    WorkHandle();
                }
                catch (ThreadAbortException)
                { }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                        Print(ex.InnerException.Message, ex);
                    else
                        Print(ex.Message, ex);
                }
            }
            State = ServiceState.Closed;
        }
        /// <summary>
        /// 服务运行操作
        /// </summary>
        public virtual void WorkHandle()
        {

        }

        public Thread CurrenTh { get; set; }
    }
    /// <summary>
    /// 服务状态
    /// </summary>
    public enum ServiceState
    {
        /// <summary>
        /// 关闭的服务
        /// </summary>
        Closed,
        /// <summary>
        /// 关闭中
        /// </summary>
        Closing,
        /// <summary>
        /// 打开中
        /// </summary>
        Open,
        /// <summary>
        /// 未初始化
        /// </summary>
        UnInitialize
    }
}
