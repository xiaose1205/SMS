<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MainSite.Master" AutoEventWireup="true" CodeBehind="Sysinfo.aspx.cs" Inherits="SMSServer.Web.Master.Sysinfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ScriptHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <div class="form">
        <div class="title">
            <h3>基本资料</h3>
        </div>
        <div class="body">
            <div class="formPanel">

                <form class="form-horizontal">
                    <ul class="form">
                        <li>
                            <label>用户账号：</label>
                            <label runat="server" id="account" style="float: none; padding-left: 100px;"></label>
                        </li>
                        <li>
                            <label>所属企业：</label>
                            <label runat="server" id="enterprise" style="float: none; padding-left: 100px;"></label>
                        </li>
                        <li>
                            <label>当前余额：</label>
                            <label runat="server" id="smsprice" style="float: none; padding-left: 100px;"></label>
                        </li>
                        <li>
                            <label>状态：</label>
                            <label runat="server" id="state" style="float: none; padding-left: 100px;"></label>
                        </li>

                    </ul>

                </form>
            </div>

        </div>
    </div>
</asp:Content>
