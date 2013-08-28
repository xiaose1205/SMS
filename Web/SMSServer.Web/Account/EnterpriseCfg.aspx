<%@ Page Title="" Language="C#" MasterPageFile="~/Master/ChildSite.Master" AutoEventWireup="true" CodeBehind="EnterpriseCfg.aspx.cs" Inherits="SMSServer.Web.Account.EnterpriseCfg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ScriptHolder" runat="server">
    <script src="../Scripts/site/enterprise.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <form id="form1" runat="server" class="form-horizontal" action="../ajax/enterprise/enterprisecfg">
        <div class="z-legend">
            <strong>企业短信规则设定</strong>
        </div>

        <div class="control-group">
            <label class="control-label" for="smsprice">短信单价</label>
            <div class="controls">
                <input type="text" id="smsprice" name="smsprice" value="<%=smsprice %>"/>
            </div>
        </div>
        <div class="control-group">
            <label class="control-label" for="chinamobile">移动通道</label>
            <div class="controls">
                <input type="text" id="chinamobile" name="chinamobile"  value="<%=chinamobile %>"/>
            </div>
        </div>
        <div class="control-group">
            <label class="control-label" for="union">联通通道</label>
            <div class="controls">
                <input type="text" id="union" name="union"  value="<%=union %>"/>
            </div>
        </div>
        <div class="control-group">
            <label class="control-label" for="cdma">电信通道</label>
            <div class="controls">
                <input type="text" id="cdma" name="cdma"  value="<%=cdma %>"/>
            </div>
        </div>
         <div class="control-group">
            <label class="control-label" for="smslength">短信单条长度</label>
            <div class="controls">
                <input type="text" id="smslength" name="smslength"  value="<%=smslength %>"/>
            </div>
        </div>
        
        <input type="hidden" name="enterpriseid" value="<%=enterpriseid %>"/>
        <%---将button,input 放在这个容器里面就会自动处理 ----%>
        <div class="autool_buttons" id="actions">
            <input type="button" value="确认" onclick="setting();" />
            <input type="button" value="取消" />
        </div>

        <%----%>
    </form>
</asp:Content>
