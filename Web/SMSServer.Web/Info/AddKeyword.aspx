<%@ Page Title="" Language="C#" MasterPageFile="~/Master/ChildSite.Master" AutoEventWireup="true" CodeBehind="AddKeyword.aspx.cs" Inherits="SMSServer.Web.Info.AddKeyword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ScriptHolder" runat="server">
    <script src="../Scripts/site/keyword.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
  <form id="form1" runat="server" class="form-horizontal" action="../ajax/keyword/addkeyword?parame=1">
        <div class="z-legend">
            <strong>关键词</strong>
        </div>

        <div class="control-group">
            <label class="control-label" for="keyword">关键词</label>
            <div class="controls">
                <input type="text" id="keyword" name="keyword" />
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
