<%@ Page Title="" Language="C#" MasterPageFile="~/Master/ChildSite.Master" AutoEventWireup="true" CodeBehind="SelectTemplate.aspx.cs" Inherits="SMSServer.Web.Info.SelectTemplate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ScriptHolder" runat="server">
     <link href="../Styles/Site.css" rel="stylesheet" />
    
    <script src="../Scripts/lib/artDialog.js?skin=black"></script>
    <script src="../Scripts/lib/iframeTools.source.js"></script>
    <link href="../Styles/buttons.css" rel="stylesheet" />
    <link href="../Styles/flexigrid.css" rel="stylesheet" type="text/css" />
   
        <link href="../Styles/common.css" rel="stylesheet" />
    <script language="javascript" type="text/javascript" src="../Scripts/lib/flexigrid-1.1A.js"></script>
    <script src="../Scripts/site/template.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="tools">
        <div class="cont_tools" style="width: 30%">
            <a href="#" id="search" class="button button-rounded button-tiny   button-action">查询</a>
            <a href="#" id="select" class="button button-rounded button-tiny   button-primary">选择短语</a>
        </div>
        <div class="search_tools">
            <span>短信内容:</span>
            <input id="name" size="16" class="input-medium" placeholder="请输入短信内容"
                type="text" />
        </div>
    </div>
    <div class="grid_tools">
        <table id="grid">
        </table>
    </div>
</asp:Content>
