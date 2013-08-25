<%@ Page Title="" Language="C#" MasterPageFile="~/Master/ChildSite.Master" AutoEventWireup="true" CodeBehind="EditKeyword.aspx.cs" Inherits="SMSServer.Web.Info.EditKeyword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ScriptHolder" runat="server">
    <script src="../Scripts/site/keyword.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
     <form id="form1" runat="server" class="form-horizontal" action="../ajax/keyword/editkeyword">
        <div class="z-legend">
            <strong>关键词</strong>
        </div>
        <input name="id" value="<%=kid %>"  id="keywordid" type="hidden"   />
        <div class="control-group">
            <label class="control-label" for="keyword">关键词</label>
            <div class="controls">
                <input type="text" id="keyword" name="keyword" value="<%=keyword %>"  />
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
