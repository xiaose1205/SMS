<%@ Page Title="" Language="C#" MasterPageFile="~/Master/ChildSite.Master" AutoEventWireup="true" CodeBehind="EditTemplate.aspx.cs" Inherits="SMSServer.Web.Info.EditTemplate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ScriptHolder" runat="server">
    <script src="../Scripts/site/template.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <form id="form1" runat="server" class="form-horizontal" action="../ajax/template/edittemplate?parame=1">
        <div class="z-legend">
            <strong>常用短语</strong>
        </div>
        <input name="id" value="" runat="server" id="templateid" type="hidden" class="templateid" />
        <div class="control-group">
            <label class="control-label" for="template">常用短语</label>
            <div class="controls">
                <input type="text" id="template" name="template1" runat="server" class="template" />
            </div>
        </div>
        <input name="id" value="" type="hidden" />
        <input name="template" type="hidden" />
        <%---将button,input 放在这个容器里面就会自动处理 ----%>
        <div class="autool_buttons" id="actions">
            <input type="button" value="确认" onclick="edit();" />
            <input type="button" value="取消" />
        </div>

        <%----%>
    </form>

</asp:Content>
