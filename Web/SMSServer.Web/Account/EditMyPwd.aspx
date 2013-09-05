<%@ Page Title="" Language="C#" MasterPageFile="~/Master/ChildSite.Master" AutoEventWireup="true" CodeBehind="EditMyPwd.aspx.cs" Inherits="SMSServer.Web.Account.EditMyPwd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ScriptHolder" runat="server">
    <script src="../Scripts/site/account.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <form id="form1" runat="server" class="form-horizontal" action="../ajax/account/EditmyPassword">
        <div class="z-legend">
            <strong>修改密码</strong>
        </div>
        <input type="hidden" value="<% =Request.QueryString["id"]%>" name="aid" />
        <div class="control-group">
            <label class="control-label" for="pwd">旧密码</label>
            <div class="controls">
                <input type="password" id="oldpwd" name="oldpwd" />
            </div>
        </div>
        <div class="control-group">
            <label class="control-label" for="pwd">新密码</label>
            <div class="controls">
                <input type="password" id="pwd" name="pwd" />
            </div>
        </div>
        <div class="control-group">
            <label class="control-label" for="repwd">确认密码</label>
            <div class="controls">
                <input type="password" id="repwd" name="repwd" />
            </div>
        </div>
        <%---将button,input 放在这个容器里面就会自动处理 ----%>
        <div class="autool_buttons" id="actions">
            <input type="button" value="确认" onclick="cgpwd();" />
            <input type="button" value="取消" />
        </div>

        <%----%>
    </form>
</asp:Content>
