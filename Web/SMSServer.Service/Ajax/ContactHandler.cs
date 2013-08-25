#region Version Info
/* ========================================================================
* 【本类功能概述】
* 
* 作者：王军 时间：2013/8/23 23:06:33
* 文件名：ContactHandler
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
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using HelloData.FWCommon;
using HelloData.FrameWork.Data;
using HelloData.Web;
using HelloData.Web.AppHandlers;
using SMSServer.Logic;
using SMSService.Logic;

namespace SMSServer.Service.Ajax
{
    public class ContactHandler : BaseHandler
    {
        public override HelloData.AppHandlers.IAppHandler CreateInstance()
        {
            return new BlackHandler();
        }

        public override string HandlerName
        {
            get { return "contact"; }
        }
        public HandlerResponse getList()
        {
            int gid = int.Parse(Request.Params["gid"]);
            string name = Request.Params["name"];
            string phone = Request.Params["phone"];
            int PageIndex = int.Parse(Request.Params["PageIndex"]);
            int PageSize = int.Parse(Request.Params["PageSize"]);
            PageList<SmsContactInfo> infos = SmsContactManage.Instance.getList(PageIndex, PageSize, gid, name, phone);

            JsonFlexiGridData data = new JsonFlexiGridData();
            data.rows = new List<FlexiGridRow>();
            foreach (var item in infos)
            {
                FlexiGridRow row = new FlexiGridRow();
                row.id = item.ID.ToString();
                row.cell = new Dictionary<string, object>();
                row.cell.Add("id", item.ID);
                row.cell.Add("phone", item.Mobile);
                row.cell.Add("name", item.Name);
                row.cell.Add("comment", item.Comment);
                switch (item.Sex)
                {
                    case 1:
                        row.cell.Add("sex", "男");
                        break;
                    case 2:
                        row.cell.Add("sex", "女"); break;
                    default:
                        row.cell.Add("sex", "保密"); break;
                }
                row.cell.Add("birthday", DateTostr(item.Birthday));
                row.cell.Add("createtime", DateTostr(item.CreateTime));
                data.rows.Add(row);
            }
            data.page = PageIndex;
            data.total = infos.TotalCount;
            return CreateHandler(101, new JavaScriptSerializer().Serialize(data));

        }

        public HandlerResponse addContact()
        {
            string name = Request.Params["name"];
            string phone = Request.Params["phone"];
            string sex = Request.Params["sex"];
            string birthday = Request.Params["birthday"];
            if (string.IsNullOrEmpty(birthday))
                birthday = DateTime.Parse("1970-1-1").ToString(CultureInfo.InvariantCulture);
            string remark = Request.Params["remark"];
            string gid = Request.Params["gid"];
            SmsContactInfo info = new SmsContactInfo();
            info.Mobile = phone;
            info.Name = name;
            info.GroupID = int.Parse(gid);
            info.Sex = int.Parse(sex);
            info.Comment = remark;
            info.Birthday = DateTime.Parse(birthday);
            info.CreateTime = DateTime.Now;
            info.EnterpriseId = AppContent.Current.GetCurrentUser().EnterpriseID;
            SmsContactManage.Instance.Add(info);
            return CreateHandler(1, "添加成功");
        }
        public HandlerResponse editContact()
        {

            string id = Request.Params["id"];
            int cid = 0;
            if (string.IsNullOrEmpty(id) || !int.TryParse(id, out cid))
            {

                return CreateHandler(0, "主键不存在");
            }
            if (cid == 0)
                return CreateHandler(0, "主键不存在");
            string name = Request.Params["name"];
            string phone = Request.Params["phone"];
            string sex = Request.Params["sex"];
            string birthday = Request.Params["birthday"];

            if (string.IsNullOrEmpty(birthday))
                birthday = DateTime.Parse("1970-1-1").ToString(CultureInfo.InvariantCulture);
            string remark = Request.Params["remark"];
            string gid = Request.Params["gid"];
            SmsContactInfo info = new SmsContactInfo();
            info.ID = cid;
            info.Mobile = phone;
            info.Name = name;
            info.Sex = int.Parse(sex);
            info.Comment = remark;
            info.Birthday = DateTime.Parse(birthday);
            info.CreateTime = DateTime.Now;
            info.EnterpriseId = AppContent.Current.GetCurrentUser().EnterpriseID;
            SmsContactManage.Instance.Save(info);
            return CreateHandler(1, "更新成功");
        }
        public SmsContactInfo GetContact(int id)
        {
            return SmsContactManage.Instance.GetContact(id);
        }
        public HandlerResponse Delete()
        {
            string ids = Request.Params["ids"];
            if (string.IsNullOrEmpty(ids))
                return CreateHandler(0, "删除失败");
            SmsContactManage.Instance.DeleteContact(ids.TrimEnd(','));
            return CreateHandler(1, "删除成功");

        }
        public HandlerResponse upload()
        {
            string url = Request.Params["filename"].ToLower().Replace("master", "");
            String dirPath = Path.Combine(Path.Combine(Request.PhysicalApplicationPath, "uplpod"), url);
            bool isheader = Request.Params["header"] == "1";
            string spilter = Request.Params["spilter"];
            int groupid = int.Parse(Request.Params["groupid"]);
            string[] filearr = Request.Params["filearr"].TrimEnd('|').Split('|');
            if (string.IsNullOrEmpty(dirPath))
            {
                return CreateHandler(0, "导入错误");
            }
            else
            {
                if (System.IO.File.Exists(dirPath))
                {
                    var dt = FileUtily.ReadDataTable(dirPath, 0, spilter);
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        return CreateHandler(0, "导入错误");
                    }
                    else
                    {
                        List<SmsContactInfo> contacts = new List<SmsContactInfo>();
                        foreach (DataRow dr in dt.Rows)
                        {
                            SmsContactInfo contact = new SmsContactInfo();
                            contact.Name = dr[int.Parse(filearr[0])].ToString();
                            contact.Mobile = dr[int.Parse(filearr[1])].ToString();
                            if (!AppContent.isPhone(contact.Mobile))
                                continue;
                            int sex = 0;
                            contact.Sex = 0;
                            if (int.TryParse(dr[int.Parse(filearr[2])].ToString(), out sex))
                            {
                                if (sex == 0 || sex == 2 || sex == 1)
                                {
                                    contact.Sex = sex;
                                }
                                else
                                {
                                    contact.Sex = 0;
                                }
                            }
                            string birthday = dr[int.Parse(filearr[3])].ToString();
                            DateTime bir = DateTime.Parse("1970-1-1");
                            if (DateTime.TryParse(birthday, out bir))
                            {
                                contact.Birthday = bir;
                            }
                            contact.Comment = dr[int.Parse(filearr[4])].ToString();
                            contact.CreateTime = DateTime.Now;
                            if (groupid != 0)
                                contact.GroupID = groupid;
                            contact.EnterpriseId = AppContent.Current.GetCurrentUser().EnterpriseID;
                            contacts.Add(contact);
                        }
                        SmsContactManage.Instance.ImportList(contacts, groupid);
                    }
                }
                return CreateHandler(1, "导入成功");
            }
        }
    }
}
