<%@ Page Title="" Language="C#" MasterPageFile="~/Master/ChildSite.Master" AutoEventWireup="true" CodeBehind="AddAccount.aspx.cs" Inherits="SMSServer.Web.Account.AddAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ScriptHolder" runat="server">
    <script src="../Scripts/site/account.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <form id="form1" runat="server" class="form-horizontal" action="../ajax/account/AddAccount">
        <div class="z-legend">
            <strong>账号</strong>
        </div>
        <div class="control-group">
            <label class="control-label" for="enterprise">企业名称</label>
            <div class="controls">
                <select name="enterpriseid">
                    <%=enterpise %>
                </select>
            </div>
        </div>
        <div class="control-group">
            <label class="control-label" for="account">账号名称</label>
            <div class="controls">
                <input type="text" id="account" name="account" />
            </div>
        </div>
        <div class="control-group">
            <label class="control-label">账号密码</label>
            <div class="controls">
                默认为:123456
            </div>
        </div>
        <div class="control-group">
            <label class="control-label" for="signature">账号签名</label>
            <div class="controls">
                <input type="text" id="signature" name="signature" />
            </div>
        </div>
        <%---将button,input 放在这个容器里面就会自动处理 ----%>
        <div class="autool_buttons" id="actions">
            <input type="button" value="确认" onclick="add();" />
            <input type="button" value="取消" />
        </div>

        <%----%>
    </form>
</asp:Content>
