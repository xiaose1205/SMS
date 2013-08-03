<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MainSite.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SMSServer.Web.demo.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ScriptHolder" runat="server">
   
    <script src="../Scripts/site/demo.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <div class="tools">
        <div class="cont_tools">

            <a href="#" id="search" class="button button-rounded button-tiny   button-action">查询</a>

            <a href="#" id="add" class="button button-rounded button-tiny button-primary">添加</a>
            <a href="#"  id="delete" class="button button-rounded button-tiny  button-primary">删除</a>
            <a href="#"  id="edit" class="button button-rounded button-tiny  button-primary">修改</a>
        </div>
        <div class="search_tools">
            <span>用户名称:</span>
            <input id="name" size="16" class="input-medium" placeholder="请输入用户名称"
                type="text" />
        </div>
    </div>
    <div class="grid_tools">
        <table id="grid">
        </table>
    </div>
 


</asp:Content>
