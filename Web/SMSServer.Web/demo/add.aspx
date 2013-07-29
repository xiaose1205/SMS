<%@ Page Title="" Language="C#" MasterPageFile="~/Master/ChildSite.Master" AutoEventWireup="true" CodeBehind="add.aspx.cs" Inherits="SMSServer.Web.demo.add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ScriptHolder" runat="server">
    <script src="../Scripts/site/demo.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="z-legend">
        <strong>用户基本信息</strong>
    </div>

    <div class="control-group">
        <label class="control-label" for="UserName">用户名</label>
        <div class="controls">
            <input type="text" id="UserName" name="username" />
        </div>
    </div>
    <div class="control-group">
        <label class="control-label" for="password">登录密码</label>
        <div class="controls">
            <input type="button" disabled="disabled" class="btn-link" id="password" name="UserName" value="默认[123456]" />
        </div>
    </div>
    <div class="control-group">
        <label class="control-label" for="role">用户权限</label>
        <div class="controls">
            <select id="role" name="role">
                <option value="1">超级管理员</option>
                <option value="2">财务人员</option>
                <option value="3">商务部管理员</option>
            </select>
        </div>
    </div>
    <%---将button,input 放在这个容器里面就会自动处理 ----%>
    <div class="autool_buttons" id="actions">
        <input type="button" value="确认" onclick="add();" />
        <input type="button" value="取消" />
    </div>
    <%----%>
</asp:Content>
