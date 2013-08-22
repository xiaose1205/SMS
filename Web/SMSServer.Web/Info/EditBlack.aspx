<%@ Page Title="" Language="C#" MasterPageFile="~/Master/ChildSite.Master" AutoEventWireup="true" CodeBehind="EditBlack.aspx.cs" Inherits="SMSServer.Web.Info.EditBlack" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ScriptHolder" runat="server">
    <script src="../Scripts/site/black.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <form id="form1" runat="server" class="form-horizontal" action="../ajax/black/editblack">
        <div class="z-legend">
            <strong>黑名单</strong>
        </div>
        <input name="id" value="" runat="server" id="blackid" type="hidden" class="blackid" />
        <div class="control-group">
            <label class="control-label" for="phone">手机号码</label>
            <div class="controls">
                <input type="text" id="phone" name="phone1" runat="server" class="phone" />
            </div>
        </div>
        <input name="id" value="" type="hidden" />
        <input name="phone" type="hidden" />
        <%---将button,input 放在这个容器里面就会自动处理 ----%>
        <div class="autool_buttons" id="actions">
            <input type="button" value="确认" onclick="edit();" />
            <input type="button" value="取消" />
        </div>

        <%----%>
    </form>
</asp:Content>
