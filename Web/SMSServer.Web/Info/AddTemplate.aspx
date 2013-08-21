<%@ Page Title="" Language="C#" MasterPageFile="~/Master/ChildSite.Master" AutoEventWireup="true" CodeBehind="AddTemplate.aspx.cs" Inherits="SMSServer.Web.Info.AddTemplate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ScriptHolder" runat="server">
    <script src="../Scripts/site/template.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
      <form id="form1" runat="server" class="form-horizontal" action="../ajax/template/addtemplate?parame=1">
        <div class="z-legend">
            <strong>常用短语</strong>
        </div>

        <div class="control-group">
            <label class="control-label" for="template">常用短语</label>
            <div class="controls">
                <input type="text" id="template" name="template" />
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
