﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master/ChildSite.Master" AutoEventWireup="true" CodeBehind="EditContact.aspx.cs" Inherits="SMSServer.Web.Info.EditContact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ScriptHolder" runat="server">
    <script src="../Scripts/lib/WdatePicker.js"></script>
    <link href="../Scripts/lib/skin/WdatePicker.css" rel="stylesheet" />
    <script src="../Scripts/site/contact.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <form id="form1" runat="server" class="form-horizontal" action="../ajax/contact/editcontact">
        <div class="z-legend">
            <strong>联系人</strong>
        </div>
        <div class="control-group">
            <label class="control-label" for="phone">姓名:</label>
            <div class="controls">
                <input type="text" id="name" name="name" maxlength="10" value="<%=name%>" /><span class="red">*</span>
            </div>
        </div>
        <div class="control-group">
            <label class="control-label" for="phone">手机号码:</label>
            <div class="controls">
                <input type="text" id="phone" name="phone" maxlength="13" value="<%=phone%>" /><span class="red">*</span>
            </div>
        </div>
        <div class="control-group">
            <label class="control-label" for="phone">生日:</label>
            <div class="controls">
                <input type="text" id="birthday" name="birthday" value="<%=birthday%>" class=" Wdate" onfocus="WdatePicker({startDate:'%y-%M-01 00:00:00',dateFmt:'yyyy-MM-dd HH:mm:ss',alwaysUseStartDate:true})" style="width: 206px;" />
            </div>
        </div>
        <div class="control-group">
            <label class="control-label" for="phone">性别:</label>
            <div class="controls">
                <select style="width: 100px;" name="sex" id="sex">
                    <%=sex %>
                </select><span class="red">*</span>
            </div>
        </div>
        <div class="control-group">
            <label class="control-label" for="phone">备注:</label>
            <div class="controls">
                <textarea style="width: 220px; height: 90px" rows="3" name="remark"><%=remark%></textarea>
            </div>
        </div>
        <input type="hidden" value="<%=Request.QueryString["id"] %>" name="id" />
        <input type="hidden" value="<%=Request.Params["gid"] %>" name="gid" />
        <%---将button,input 放在这个容器里面就会自动处理 ----%>
        <div class="autool_buttons" id="actions">
            <input type="button" value="确认" onclick="edit();" />
            <input type="button" value="取消" />
        </div>

        <%----%>
    </form>
</asp:Content>
