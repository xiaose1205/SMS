#region Version Info
/* ========================================================================
* 【本类功能概述】
* 
* 作者：王军 时间：2013/8/25 02:02:46
* 文件名：SmsHandler
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
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using HelloData.FWCommon;
using HelloData.FWCommon.Utils;
using HelloData.Web;
using HelloData.Web.AppHandlers;
using SMSServer.Logic;

namespace SMSServer.Service.Ajax
{
    public class SmsHandler : BaseHandler
    {
        private class SendInfo
        {
            public string[] Mobiles { get; set; }

            public string Content { get; set; }
            //批次名称
            public string BatchName { get; set; }
            //批次备注
            public string BatchRemark { get; set; }
            //是否过滤关键词
            public bool FKeyword { get; set; }
            //是否过滤黑名单
            public bool FBlack { get; set; }
            // 是否过滤重复号码
            public bool FRepeat { get; set; }

            public int AccountID { get; set; }

            public int EnterpriseID { get; set; }
            public string FileName { get; set; }
            public bool IsFileSend { get; set; }
            public bool IsHeader { get; set; }
            public string spilter { get; set; }
        }

        public override HelloData.AppHandlers.IAppHandler CreateInstance()
        {
            return new BlackHandler();
        }

        public override string HandlerName
        {
            get { return "sms"; }
        }
        public HandlerResponse FileSend()
        {
            string mobiles = Request.Params["mobiles"];
            string content = Request.Params["content"];
            string batchname = Request.Params["batchname"];
            string batchremark = Request.Params["batchremark"];
            string fkeyword = Request.Params["fkeyword"];
            string fblack = Request.Params["fblack"];
            string frepeat = Request.Params["frepeat"];
            if (string.IsNullOrEmpty(mobiles) || string.IsNullOrEmpty(content))
                return CreateHandler(0, "联系人与短信内容不能为空");
            if (string.IsNullOrEmpty(batchname))
                batchname = DateTime.Now.ToString("批次yyyyMMddHHmmss");
            SendInfo sendinfo = new SendInfo();
            sendinfo.AccountID = AppContent.Current.GetCurrentUser().ID;
            sendinfo.EnterpriseID = AppContent.Current.GetCurrentUser().EnterpriseID;
            sendinfo.BatchRemark = batchremark;
            sendinfo.BatchName = batchname;
            sendinfo.Content = content;
            sendinfo.FBlack = StringPlus.StrToBool(fblack, true);
            sendinfo.FKeyword = StringPlus.StrToBool(fkeyword, true);
            sendinfo.FRepeat = StringPlus.StrToBool(frepeat, true);
            /*wait,batch,count三个表，mt表不需要了*/
            ThreadPool.QueueUserWorkItem(new WaitCallback(SendPool), sendinfo);
            return CreateHandler(1, "批次提交成功，后台正在处理中...");
        }
        public HandlerResponse SmsSend()
        {
            string filename = Request.Params["filename"];
            string isheader = Request.Params["isheader"];
            string spilter = Request.Params["isspilter"];
            string content = Request.Params["content"];
            string batchname = Request.Params["batchname"];
            string batchremark = Request.Params["batchremark"];
            string fkeyword = Request.Params["fkeyword"];
            string fblack = Request.Params["fblack"];
            string frepeat = Request.Params["frepeat"];
            if (string.IsNullOrEmpty(filename) || string.IsNullOrEmpty(content))
                return CreateHandler(0, "发送文件与短信内容不能为空");
            if (string.IsNullOrEmpty(batchname))
                batchname = DateTime.Now.ToString("批次yyyyMMddHHmmss");

            SendInfo sendinfo = new SendInfo();
            sendinfo.AccountID = AppContent.Current.GetCurrentUser().ID;
            sendinfo.EnterpriseID = AppContent.Current.GetCurrentUser().EnterpriseID;
            sendinfo.BatchRemark = batchremark;
            sendinfo.BatchName = batchname;
            sendinfo.Content = content;
            sendinfo.FBlack = StringPlus.StrToBool(fblack, true);
            sendinfo.FKeyword = StringPlus.StrToBool(fkeyword, true);
            sendinfo.FRepeat = StringPlus.StrToBool(frepeat, true);
            sendinfo.IsFileSend = true;
            sendinfo.FileName = filename;
            sendinfo.IsHeader = StringPlus.StrToBool(isheader, false);
            sendinfo.spilter = spilter;
            /*wait,batch,count三个表，mt表不需要了*/
            ThreadPool.QueueUserWorkItem(new WaitCallback(SendPool), sendinfo);
            return CreateHandler(1, "批次提交成功，后台正在处理中...");
        }

        public void SendPool(object sender)
        {
            SendInfo info = sender as SendInfo;
            if (info.IsFileSend)
            {
                /* 文件发送*/
                String dirPath = Path.Combine(Path.Combine(Request.PhysicalApplicationPath, "uplpod"), info.FileName);
                if (System.IO.File.Exists(dirPath))
                {
                    int mtpackLength = 100;
                    DataTable dt = FileUtily.ReadDataTable(dirPath, 0, info.spilter, info.IsHeader);
                    DataRow firstDr = dt.Rows[0];
                    dt.Rows.RemoveAt(0);
                    SmsBatchInfo batchInfo = new SmsBatchInfo();
                    batchInfo.AccountID = info.AccountID;
                    batchInfo.EnterPriseID = info.EnterpriseID;
                    batchInfo.BatchName = info.BatchName;
                    batchInfo.Remark = info.BatchRemark;
                    batchInfo.SmsContent = info.Content;
                    batchInfo.PostTime = DateTime.Now;
                    batchInfo.CommitTime = DateTime.Now;
                    batchInfo.Msgcount = dt.Rows.Count;
                    batchInfo.MtCount = dt.Rows.Count / mtpackLength + (dt.Rows.Count % mtpackLength > 0 ? 1 : 0);
                    batchInfo.MessageState = 0;
                    batchInfo.BatchState = 0;
                    int batchId = SmsBatchManage.Instance.AddBatch(batchInfo);
                    List<SmsBatchWaitInfo> waitInfos = new List<SmsBatchWaitInfo>();
                    bool isGroup = info.Content.IndexOf("@") == -1;
                    int readCount = 0;
                    if (isGroup)
                    {
                        SMSGroupInfo groupInfo = new SMSGroupInfo();
                        groupInfo.groupInfos = new List<GroupInfo>();
                        SmsBatchWaitInfo waitInfo = new SmsBatchWaitInfo();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (!AppContent.isPhone(dt.Rows[i][0].ToString()))
                                continue; 
                            groupInfo.groupInfos.Add(new GroupInfo()
                                {
                                    Content = ComparContent(info.Content, firstDr, dt.Rows[i]),
                                    Phone = dt.Rows[i][0].ToString()
                                });

                            if ((i % mtpackLength == 0 && i != 0) || i == dt.Rows.Count - 1)
                            {
                                waitInfo.AccountID = info.AccountID;
                                waitInfo.EnterPriseID = info.EnterpriseID;
                                waitInfo.CreateTime = DateTime.Now;
                                waitInfo.MsgCount = mtpackLength;
                                waitInfo.MsgType = 1;
                                waitInfo.BatchID = batchId;
                                waitInfo.MsgPack = Encoding.UTF8.GetBytes(JsonHelper.SerializeObject(groupInfo));
                                waitInfos.Add(waitInfo);
                                groupInfo.groupInfos = new List<GroupInfo>();
                                waitInfo = new SmsBatchWaitInfo();
                            }
                            readCount++;
                        }
                    }
                    else
                    {
                        SMSMassInfo massInfo = new SMSMassInfo();
                        massInfo.Content = info.Content;
                        SmsBatchWaitInfo waitInfo = new SmsBatchWaitInfo();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (!AppContent.isPhone(dt.Rows[i][0].ToString()))
                                continue; 
                            massInfo.Phones.Add(
                                  dt.Rows[i][0].ToString()
                            );

                            if ((i % mtpackLength == 0 && i != 0) || i == dt.Rows.Count - 1)
                            {
                                waitInfo.AccountID = info.AccountID;
                                waitInfo.EnterPriseID = info.EnterpriseID;
                                waitInfo.CreateTime = DateTime.Now;
                                waitInfo.MsgCount = mtpackLength;
                                waitInfo.MsgType = 1;
                                waitInfo.MsgPack = Encoding.UTF8.GetBytes(JsonHelper.SerializeObject(massInfo));
                                waitInfos.Add(waitInfo);
                                massInfo = new SMSMassInfo();
                                waitInfo = new SmsBatchWaitInfo();
                            }
                            readCount++;
                        }
                    }
                    SmsBatchAmountInfo amountInfo = new SmsBatchAmountInfo();
                    amountInfo.BatchID = batchId;
                    amountInfo.SendAmount = 0;
                    amountInfo.PlanSendCount = dt.Rows.Count;
                    amountInfo.RealAmount = readCount;
                    amountInfo.SuccessAmount = 0;
                    SmsBatchManage.Instance.AddBatchAmount(amountInfo);
                    SmsBatchManage.Instance.AddBatchWait(waitInfos);

                }
            }
        }

        private string ComparContent(string content, DataRow firstDr, DataRow dataRow)
        {
            for (int i = 0; i < firstDr.ItemArray.Length; i++)
            {
                if (dataRow[i] != null)
                    content = content.Replace("@" + firstDr[i], dataRow[i].ToString());
            }
            return content;
        }
    }
}
