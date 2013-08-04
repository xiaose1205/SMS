using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using HytMsg.Model;
using HytMsg.BLL.GateWay;


namespace SMSServer.WcfHost.Task
{
    /// <summary>
    ///  任务处理
    /// </summary>
    public class TaskService : BaseService<TaskService>
    {
        public TaskService()
        {
            base.IsStop = false;
            base.SleepSpan = AppContent.ReadTask;
            this.ServiceName = "任务读取";
        }

        public TaskManage Taskmrg = new TaskManage();
        public override void WorkHandle()
        {

            List<TaskModel> models = Taskmrg.GetSendingTask();
            Print("读取任务队列：" + models.Count + "");
            foreach (var taskModel in models)
            {
                #region 检查发送用户是否已不存在
                if (!Taskmrg.CheckUser(taskModel.UserID))
                {
                    //若用户不存在，则更新任务状态为暂停。
                    Taskmrg.UpdateTaskByState((int)TaskState.Stop, taskModel.TaskID, -1);
                    continue;
                }
                #endregion

                DateTime LastRunTime = new DateTime(1900, 1, 1);
                DateTime StartTime = taskModel.StartTime;
                //没有运行过或者不是今天运行。
                if (taskModel.LastRunTime == null || taskModel.LastRunTime.Value.Date != DateTime.Now.Date)
                {
                    LastRunTime = DateTime.Now.AddDays(-1);
                }
                else
                    LastRunTime = taskModel.LastRunTime.Value;
                //1一次性、2每天、3每周、4每月、5节日型
                switch (taskModel.TaskType)
                {
                    case 1:
                        if (LastRunTime.Day != DateTime.Now.Day &&
                            StartTime.Year == DateTime.Now.Year &&
                            StartTime.Month == DateTime.Now.Month &&
                            StartTime.Day == DateTime.Now.Day &&
                            WithInTime(StartTime)
                            )
                        {   //创建批次
                            CreateBatchMessage(taskModel);
                        }
                        else
                            continue;

                        break;
                    case 2:
                        if (LastRunTime.Day != DateTime.Now.Day && WithInTime(StartTime))
                        {   //创建批次
                            CreateBatchMessage(taskModel);
                        }
                        else
                            continue;
                        break;
                    case 3:
                        if (!taskModel.Day.HasValue)
                            continue;
                        if (LastRunTime.Date != DateTime.Now.Date)
                        {
                            int Day = taskModel.Day.Value;
                            if (Day == 7) Day = 0;
                            if (Day == (int)DateTime.Now.DayOfWeek && WithInTime(StartTime))
                            {
                                //创建批次
                                CreateBatchMessage(taskModel);
                            }
                            else
                                continue;
                        }
                        else
                            continue;
                        break;
                    case 4:
                        if (!taskModel.Day.HasValue)
                            continue;
                        if (LastRunTime.Month != DateTime.Now.Month)
                        {
                            int Day = taskModel.Day.Value;

                            if (DateTime.Now.Day == Day && WithInTime(StartTime))
                            {   //创建批次
                                CreateBatchMessage(taskModel);
                            }
                            else
                                continue;
                        }
                        else
                            continue;
                        break;
                    case 5:
                        break;
                }

            } Thread.Sleep(base.SleepSpan);
        }
        /// <summary>
        /// time为24小时制的时分秒
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public bool WithInTime(DateTime time)
        {
            DateTime now = DateTime.Now;
            if (time.Hour == now.Hour && time.Minute > now.Minute - AppContent.ReadTask && time.Minute <= now.Minute + AppContent.ReadTask)
                return true;
            return false;
        }
        private void CreateBatchMessage(TaskModel taskModel)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(CreateBatchMessageHandel), taskModel);
        }

        /// <summary>
        /// 表task要加上执行次数的
        /// </summary>
        /// <param name="taskmodel"></param>
        public void CreateBatchMessageHandel(object taskmodel)
        {
            try
            {
                TaskModel model = (TaskModel)taskmodel;
                BatchManage manger = new BatchManage();
                string batchid = Guid.NewGuid().ToString();
                BatchModel batchmodel = new BatchModel();
                batchmodel.BatchID = Guid.NewGuid().ToString();
                batchmodel.EnterPriseID = model.EnterPriseID;
                batchmodel.CreateTime = DateTime.Now;
                batchmodel.Name = model.TaskName + DateTime.Now.ToString("_yyyyMMdd");
                batchmodel.SendType = Convert.ToInt32(model.SendType);
                batchmodel.UploadUserID = model.UserID;
                batchmodel.UploadComment = string.Empty;
                batchmodel.StartTime = DateTime.Now;
                batchmodel.FilterConfig = model.FilterConfig;
                batchmodel.OriginalContent = model.Content;
                batchmodel.SuccessAmount = 0;
                manger.CreateBatch(batchmodel, model);
                Print("读取任务，创建批次" + batchmodel.Name + "");
                TaskManage taskmrg = new TaskManage();
                //更新所有的执行状态与执行次数
                if (model.TaskType == 1)
                {
                    taskmrg.UpdateTaskByState((int)TaskState.Stop, model.TaskID, (int)model.TaskCount + 1);
                }
                else
                {
                    taskmrg.UpdateTaskByState((int)TaskState.Active, model.TaskID, (int)model.TaskCount + 1);
                }
                Print("处理完成一个任务：" + model.TaskID + "(" + model.TaskName + ")");
            }
            catch (Exception ex)
            {
                Print(ex.Message);
            }
        }

    }
}
