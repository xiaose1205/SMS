<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MainSite.Master" AutoEventWireup="true" CodeBehind="moindex.aspx.cs" Inherits="SMSServer.Web.Mo.moindex" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ScriptHolder" runat="server">
    <script src="../Scripts/site/mo.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">


    <div class="tools">
        <div class="cont_tools">

            <a href="#" id="search" class="button button-rounded button-tiny   button-action">查询</a>

            <a href="#" id="add" class="button button-rounded button-tiny button-primary">导出</a>
        </div>
        <div class="search_tools">
            <span>手机号码:</span>
            <input id="name" size="16" class="input-medium" placeholder="请输入手机号码"
                type="text" />
            <span>短信内容:</span>
            <input id="Text1" size="16" class="input-medium" placeholder="请输入短信内容"
                type="text" />
            <span>开始时间:</span>
            <input id="Text2" size="16" class="input-medium" placeholder="请输入短信内容"
                type="text" />
            <span>结束时间:</span>
            <input id="Text3" size="16" class="input-medium" placeholder="请输入短信内容"
                type="text" />
        </div>
    </div>
    <div class="grid_tools">
        <table id="grid">
        </table>
    </div>

</asp:Content>
