<%@ Page Title="" Language="C#" MasterPageFile="~/Master/ChildSite.Master" AutoEventWireup="true" CodeBehind="EditAccount.aspx.cs" Inherits="SMSServer.Web.Account.EditAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ScriptHolder" runat="server">
    <script src="../Scripts/site/account.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <form id="form1" runat="server" class="form-horizontal" action="../ajax/account/EditAccount">
        <div class="z-legend">
            <strong>账号</strong>
        </div>
        <input type="hidden" value="<% =Request.QueryString["id"]%>" name="id" />
        <div class="control-group">
            <label class="control-label" for="account">账号名称</label>
            <div class="controls">
                <input type="text" id="account" name="account" value="<%=account %>" />
            </div>
        </div>
        <div class="control-group">
            <label class="control-label" for="signature">账号签名</label>
            <div class="controls">
                <input type="text" id="signature" name="signature" value="<%=sign %>" />
            </div>
        </div>
        <%---将button,input 放在这个容器里面就会自动处理 ----%>
        <div class="autool_buttons" id="actions">
            <input type="button" value="确认" onclick="edit();" />
            <input type="button" value="取消" />
        </div>

        <%----%>
    </form>
</asp:Content>
