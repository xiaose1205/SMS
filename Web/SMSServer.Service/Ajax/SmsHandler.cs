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
using SMSService.Entity;
using SMSService.Logic;

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
        public HandlerResponse SmsSend()
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
            sendinfo.Mobiles = mobiles.Split(',');
            /*wait,batch,count三个表，mt表不需要了*/
            ThreadPool.QueueUserWorkItem(new WaitCallback(SendPool), sendinfo);
            return CreateHandler(1, "批次提交成功，后台正在处理中...");
        }
        public HandlerResponse FileSend()
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
            sendinfo.IsHeader = isheader == "1";
            sendinfo.spilter = spilter;
            /*wait,batch,count三个表，mt表不需要了*/
            ThreadPool.QueueUserWorkItem(new WaitCallback(SendPool), sendinfo);
            return CreateHandler(1, "批次提交成功，后台正在处理中...");
        }

        public void SendPool(object sender)
        {
            SendInfo info = sender as SendInfo;
            SmsBatchInfo batchInfo = new SmsBatchInfo();
            batchInfo.AccountID = info.AccountID;
            batchInfo.EnterPriseID = info.EnterpriseID;
            batchInfo.BatchName = info.BatchName;
            batchInfo.Remark = info.BatchRemark;
            batchInfo.SmsContent = info.Content;
        
            batchInfo.CommitTime = DateTime.Now;

            batchInfo.MsgType = 1;
            batchInfo.CreateTime = DateTime.Now.AddSeconds(-5);
            batchInfo.MessageState = 0;
            batchInfo.BatchState = 1;
            int batchId = SmsBatchManage.Instance.AddBatch(batchInfo);
            int mtpackLength = 100;
            int readCount = 0;
            int totalCount = 0;
            List<SmsBatchWaitInfo> waitInfos = new List<SmsBatchWaitInfo>();
            if (info.IsFileSend)
            {
                DataTable dt = new DataTable();
                /* 文件发送*/
                String dirPath = Path.Combine(Path.Combine(Request.PhysicalApplicationPath, "uplpod"), info.FileName);

                if (File.Exists(dirPath))
                {

                    dt = FileUtily.ReadDataTable(dirPath, 0, info.spilter, info.IsHeader);
                }
                totalCount = dt.Rows.Count;
                 bool isGroup = info.Content.IndexOf("@") > -1;

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
                            Content = ComparContent(info.Content, dt.Columns, dt.Rows[i]),
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
                            waitInfo.MsgPack = JsonHelper.SerializeObject(groupInfo);
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
                    massInfo.Phones = new List<string>();
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
                            waitInfo.MsgPack = JsonHelper.SerializeObject(massInfo);
                            waitInfos.Add(waitInfo);
                            massInfo = new SMSMassInfo();
                            waitInfo = new SmsBatchWaitInfo();
                        }
                        readCount++;
                    }
                }

            }
            else
            {
                List<string> cids = new List<string>();
                List<SmsContactInfo> smsContactInfos = new List<SmsContactInfo>();
                /*联系人发送*/
                for (int i = 0; i < info.Mobiles.Length; i++)
                {
                    string mobile = info.Mobiles[i];
                    string submobile = mobile.Substring(0, 1);
                    switch (submobile)
                    {
                        case "c":
                            /*直接联系人*/
                            string cid = mobile.TrimStart('c').TrimStart('0');
                            cids.Add(cid);
                            break;
                        case "g":
                            string[] contions = mobile.TrimStart('g').Split('|');
                            int gid = 0;
                            if (int.TryParse(contions[0], out gid))
                                smsContactInfos.AddRange(SmsContactManage.Instance.getList(0, -1, int.Parse(contions[0]), contions[1], contions[2], info.EnterpriseID));
                            break;
                        case "1":
                            if (AppContent.isPhone(mobile))
                                smsContactInfos.Add(new SmsContactInfo()
                                    {
                                        Mobile = mobile,
                                        Birthday = DateTime.Parse("1910-1-1")
                                    });
                            break;
                    }
                }
                List<SmsContactInfo> contacts = SmsContactManage.Instance.GetContacts(cids, info.EnterpriseID);
                smsContactInfos.AddRange(contacts);
             
                bool isGroup = info.Content.IndexOf("@") > -1;
                totalCount = smsContactInfos.Count;
                if (isGroup)
                {
                    SMSGroupInfo groupInfo = new SMSGroupInfo();
                    groupInfo.groupInfos = new List<GroupInfo>();
                    SmsBatchWaitInfo waitInfo = new SmsBatchWaitInfo();
                    for (int i = 0; i < smsContactInfos.Count; i++)
                    {
                        SmsContactInfo contactInfo = smsContactInfos[i];
                        if (!AppContent.isPhone(contactInfo.Mobile))
                            continue;
                        groupInfo.groupInfos.Add(new GroupInfo()
                        {
                            Content = ComparContent(info.Content, contactInfo),
                            Phone = contactInfo.Mobile
                        });

                        if ((i % mtpackLength == 0 && i != 0) || i == smsContactInfos.Count - 1)
                        {
                            waitInfo.AccountID = info.AccountID;
                            waitInfo.EnterPriseID = info.EnterpriseID;
                            waitInfo.CreateTime = DateTime.Now;
                            waitInfo.MsgCount = mtpackLength;
                            waitInfo.MsgType = 1;
                            waitInfo.BatchID = batchId;
                            waitInfo.MsgPack = JsonHelper.SerializeObject(groupInfo);
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
                    massInfo.Phones = new List<string>();
                    SmsBatchWaitInfo waitInfo = new SmsBatchWaitInfo();
                    for (int i = 0; i < smsContactInfos.Count; i++)
                    {
                        SmsContactInfo contactInfo = smsContactInfos[i];
                        if (!AppContent.isPhone(contactInfo.Mobile))
                            continue;
                        massInfo.Phones.Add(
                          contactInfo.Mobile
                            );

                        if ((i % mtpackLength == 0 && i != 0) || i == smsContactInfos.Count - 1)
                        {
                            waitInfo.AccountID = info.AccountID;
                            waitInfo.EnterPriseID = info.EnterpriseID;
                            waitInfo.CreateTime = DateTime.Now;
                            waitInfo.MsgCount = mtpackLength;
                            waitInfo.MsgType = 1;
                            waitInfo.MsgPack = JsonHelper.SerializeObject(massInfo);
                            waitInfos.Add(waitInfo);
                            massInfo = new SMSMassInfo();
                            waitInfo = new SmsBatchWaitInfo();
                        }
                        readCount++;
                    }
                }
            } SmsBatchAmountInfo amountInfo = new SmsBatchAmountInfo();
            amountInfo.BatchID = batchId;
            amountInfo.SendAmount = 0;
            amountInfo.PlanSendCount =totalCount;
            amountInfo.RealAmount = readCount;
            amountInfo.SuccessAmount = 0;
            amountInfo.CreateTime = DateTime.Now;
            SmsBatchManage.Instance.AddBatchAmount(amountInfo);
            SmsBatchManage.Instance.AddBatchWait(waitInfos);
            SmsBatchManage.Instance.UpdateState(batchId,BatchState.Waiting);
        }

        private string ComparContent(string content, DataColumnCollection dataColumn, DataRow dataRow)
        {
            for (int i = 0; i < dataColumn.Count; i++)
            {
                if (dataRow[i] != null)
                    content = content.Replace("@" + dataColumn[i].ColumnName, dataRow[i].ToString());
            }
            return content;
        }
        private string ComparContent(string content, SmsContactInfo dataRow)
        {
            if (dataRow.Birthday.Year == 1910 && dataRow.Birthday.Month == 1)
            {
                return content;
            }
            string sex = "";
            switch (dataRow.Sex)
            {
                case 1:
                    sex = "先生";
                    break;
                case 2:
                    sex = "女士"; break;
            }
            content = content.Replace("@姓名", dataRow.Name)
                    .Replace("@性别", sex)
                   .Replace("@生日", DateTostr(dataRow.Birthday))
                    .Replace("@手机号码", dataRow.Mobile)
                    .Replace("@备注", dataRow.Comment);
            return content;
        }
    }
}
