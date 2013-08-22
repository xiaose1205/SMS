<%@ Page Title="" Language="C#" MasterPageFile="~/Master/ChildSite.Master" AutoEventWireup="true" CodeBehind="EditKeyword.aspx.cs" Inherits="SMSServer.Web.Info.EditKeyword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ScriptHolder" runat="server">
    <script src="../Scripts/site/keyword.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
     <form id="form1" runat="server" class="form-horizontal" action="../ajax/keyword/editkeyword">
        <div class="z-legend">
            <strong>关键词</strong>
        </div>
        <input name="id" value="" runat="server" id="keywordid" type="hidden" class="keywordid" />
        <div class="control-group">
            <label class="control-label" for="keyword">手机号码</label>
            <div class="controls">
                <input type="text" id="keyword" name="keyword1" runat="server" class="keyword" />
            </div>
        </div>
        <input name="id" value="" type="hidden" />
        <input name="keyword" type="hidden" />
        <%---将button,input 放在这个容器里面就会自动处理 ----%>
        <div class="autool_buttons" id="actions">
            <input type="button" value="确认" onclick="edit();" />
            <input type="button" value="取消" />
        </div>

        <%----%>
    </form>

</asp:Content>
