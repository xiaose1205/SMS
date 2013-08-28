<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MainSite.Master" AutoEventWireup="true" CodeBehind="Sysinfo.aspx.cs" Inherits="SMSServer.Web.Master.Sysinfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ScriptHolder" runat="server">
    <style>
        
.z-datagrid .dg_row:hover {
	background-color: rgb(255, 252, 233);
}
.z-datagrid .selected {
	background-color: rgb(216, 247, 157);
}
.z-datagrid .selected:hover {
	background-color: rgb(230, 255, 166);
}
.z-datagrid td.selector {
	padding-right: 2px; text-overflow: clip;
}
.z-datagrid td.rowNo {
	padding-right: 2px; text-overflow: clip;
}
.z-datagrid td.noellipsis {
	padding-right: 2px; text-overflow: clip;
}
table.z-datagrid {
	background: url("../images/default/thbg.gif") repeat-x top rgb(255, 255, 255); margin: 0px; border: 1px solid rgb(218, 224, 229); clear: both; border-collapse: separate; table-layout: fixed; border-spacing: 0;
}
table.z-datagrid td {
	padding: 4px 7px 0px 6px; color: rgb(85, 85, 85); line-height: 16px; border-bottom-color: rgb(237, 239, 242); border-bottom-width: 1px; border-bottom-style: solid;
}
table.z-datagrid th {
	padding: 4px 7px 0px 6px; color: rgb(85, 85, 85); line-height: 16px; border-bottom-color: rgb(237, 239, 242); border-bottom-width: 1px; border-bottom-style: solid;
}
.z-datagrid td.tightenTB {
	padding-top: 0px; padding-bottom: 0px;
}
.z-datagrid td.tightenTB img {
	vertical-align: middle;
}
table.z-datagrid td td {
	border-bottom-color: currentColor; border-bottom-width: 0px; border-bottom-style: none;
}
table.z-datagrid th td {
	border-bottom-color: currentColor; border-bottom-width: 0px; border-bottom-style: none;
}
table.z-datagrid .inTd-minor td {
	color: rgb(153, 153, 153); padding-top: 0px; padding-bottom: 0px; border-bottom-color: currentColor; border-bottom-width: 0px; border-bottom-style: none;
}
table.z-datagrid .caption {
	color: rgb(51, 51, 51);
}
table.z-datagrid td {
	overflow: hidden; white-space: nowrap; text-overflow: ellipsis;
}
table.z-datagrid thead td {
	color: rgb(51, 102, 153); font-weight: normal;
}
table.z-datagrid tr.dataTableHead td {
	color: rgb(51, 102, 153); font-weight: normal;
}
table.z-datagrid thead td {
	background: url("../images/default/th.gif") no-repeat left top; padding: 0px 7px 2px 6px; height: 24px; line-height: 22px; border-bottom-color: rgb(218, 224, 229); border-left-color: rgb(214, 214, 214); border-bottom-width: 1px; border-left-width: 0px; border-bottom-style: solid; border-left-style: solid; _padding-bottom: 0px;
}
table.z-datagrid tr.dataTableHead td {
	background: url("../images/default/th.gif") no-repeat left top; padding: 0px 7px 2px 6px; height: 24px; line-height: 22px; border-bottom-color: rgb(218, 224, 229); border-left-color: rgb(214, 214, 214); border-bottom-width: 1px; border-left-width: 0px; border-bottom-style: solid; border-left-style: solid; _padding-bottom: 0px;
}
table.z-datagrid thead td:first-child {
	background-image: none;
}
table.z-datagrid tr.dataTableHead td:first-child {
	background-image: none;
}
table.z-datagrid thead td.thOver {
	background: url("../images/default/thbg_over.gif") no-repeat left top;
}
table.z-datagrid tr.dataTableHead td.thOver {
	background: url("../images/default/thbg_over.gif") no-repeat left top;
}
table.z-datagrid tfoot td {
	height: 22px; color: rgb(119, 136, 153); line-height: 22px; padding-top: 0px; padding-bottom: 1px; vertical-align: middle; border-top-color: rgb(218, 224, 229); border-bottom-color: rgb(218, 224, 229); border-top-width: 0px; border-bottom-width: 0px; border-top-style: solid; border-bottom-style: solid; background-color: rgb(241, 245, 254);
}
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
<table width="100%" style="border-collapse: separate; border-spacing: 6px;" border="0"
        cellspacing="6">
        <tbody>
            <tr>
                <td width="50%" valign="top">
                    <div class="z-legend">
                        <b>应用信息</b></div>
                    <table class="z-datagrid" cellspacing="0" cellpadding="0" width="100%">
                        <tbody>
                            <tr class="dataTableHead">
                                <td height="30" width="36%" align="right" type="Tree">
                                    项&nbsp;
                                </td>
                                <td width="64%" type="Data" field="count">
                                    值
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    应用代码：
                                </td>
                                <td>
                                    DiougensWeb
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    应用名称：
                                </td>
                                <td>
                                    Diougens管理系统
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    应用版本：
                                </td>
                                <td>
                                    1.0.0.1
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    本次启动时间：
                                </td>
                                <td>
                                    <%=HelloData.FrameWork.AppCons.StartTime.ToString("yyyy-MM-dd HH:mm:ss") %>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    最后更新时间：
                                </td>
                                <td>
                                    安装后从未更新
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    当前己登录用户数：
                                </td>
                                <td>
                                    1
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    是否是调试模式：
                                </td>
                                <td>
                                    <%=  HelloData.FrameWork.AppCons.LogSqlExcu.ToString()%>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <p>
                        &nbsp;</p>
                    <div class="z-legend">
                        <b>数据库信息</b></div>
                    <table class="z-datagrid" cellspacing="0" cellpadding="0" width="100%">
                        <tbody>
                            <tr class="dataTableHead">
                                <td height="30" width="36%" align="right" type="Tree">
                                    项&nbsp;
                                </td>
                                <td width="64%" type="Data" field="count">
                                    值
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    数据库类型：
                                </td>
                                <td>
                                    <asp:Label ID="sqltype" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    数据库服务器地址：
                                </td>
                                <td>
                                    <asp:Label ID="sqlip" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    数据库服务器端口：
                                </td>
                                <td>
                                    <asp:Label ID="sqlport" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    数据库名称：
                                </td>
                                <td>
                                    <asp:Label ID="sqlname" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    用户名：
                                </td>
                                <td>
                                    <asp:Label ID="sqluser" runat="server" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
                <td width="50%" valign="top">
                    <div class="z-legend">
                        <b>服务器信息</b></div>
                    <table class="z-datagrid" cellspacing="0" cellpadding="0" width="100%">
                        <tbody>
                            <tr class="dataTableHead">
                                <td height="30" width="36%" align="right" type="Tree">
                                    项&nbsp;
                                </td>
                                <td width="64%" type="Data" field="count">
                                    值
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    服务器名称：
                                </td>
                                <td>
                                    <asp:Label ID="servername" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    服务器IP地址：
                                </td>
                                <td>
                                    <asp:Label ID="serverip" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    服务器域名：
                                </td>
                                <td>
                                    <asp:Label ID="server_name" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    服务器操作系统：
                                </td>
                                <td>
                                    <asp:Label ID="serverms" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    NET解释引擎版本：
                                </td>
                                <td>
                                    <asp:Label ID="servernet" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    服务器浏览器版本：
                                </td>
                                <td>
                                    <asp:Label ID="serverie" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    服务器IIS版本：
                                </td>
                                <td>
                                    <asp:Label ID="serversoft" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    所用语言：
                                </td>
                                <td>
                                    <asp:Label ID="serverlan" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    服务器现在时间：
                                </td>
                                <td>
                                    <asp:Label ID="servertime" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    虚拟目录Session总数：
                                </td>
                                <td>
                                    <asp:Label ID="servers" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    虚拟目录Application总数：
                                </td>
                                <td>
                                    <asp:Label ID="servera" runat="server" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
        </tbody>
    </table></asp:Content>
