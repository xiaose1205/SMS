<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MainSite.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="SMSServer.Web.Info.Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ScriptHolder" runat="server">
    <link href="../Styles/smssend.css" rel="stylesheet" />
    <script src="../Scripts/site/contact.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="sendpanel clearfix">
        <div class="pleft formPanel" style="height: 100%;">
            <h4>通讯录列表</h4>

            <a href="#" id="a2" class="button button-rounded button-tiny button-primary">添加组</a>
            <a href="#" id="a1" class="button button-rounded button-tiny button-primary">修改组</a>
            <a href="#" id="a3" class="button button-rounded button-tiny button-primary">删除组</a>
            <div class="ztreeground" style="height: 80%;">
                <ul id="treeDemo" class="ztree" style="height: 450px;"></ul>
            </div>

        </div>
        <div class="pright" style="height: 100%;">
            <div class="tools">
                <div class="cont_tools" style="width:400px;">

                    <a href="#" id="search" class="button button-rounded button-tiny   button-action">查询</a>
                    <a href="#" id="a6" class="button button-rounded button-tiny button-primary">修改</a>
                    <a href="#" id="a7" class="button button-rounded button-tiny button-primary">删除</a>
                    <a href="#" id="add" class="button button-rounded button-tiny button-primary">添加</a>

                    <a href="#" id="a4" class="button button-rounded button-tiny button-highlight">导入</a>
                    <a href="#" id="a5" class="button button-rounded button-tiny button-highlight">清空</a>
                </div>
                <div class="search_tools">
                    <span>姓名:</span>
                    <input id="name" size="16" class="input-medium" placeholder="请输入姓名"
                        type="text" />
                    <span>手机号码:</span>
                    <input id="phone" size="16" class="input-medium" placeholder="请输入手机号码"
                        type="text" />
                </div>
            </div>
            <div style="width: 100%">
                <table id="grid" style="width: 100%">
                </table>
            </div>
        </div>
        <div style="clear: both;">
        </div>
    </div>

</asp:Content>
