<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MainSite.Master" AutoEventWireup="true" CodeBehind="PhoneHistory.aspx.cs" Inherits="SMSServer.Web.Sms.PhoneHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ScriptHolder" runat="server">

    <script src="../Scripts/site/phonehistory.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="tools">
        <div class="cont_tools">

            <a href="#" id="search" class="button button-rounded button-tiny   button-action">查询</a>

            <a href="#" id="add" class="button button-rounded button-tiny button-primary">导出</a>

        </div>
        <div class="search_tools">
            <span>手机号码:</span>
            <input id="phone" size="16" class="input-medium" placeholder="请输入手机号码"
                type="text" />
            <span>开始时间:</span>
            <input id="starttime" size="16" class="input-medium  Wdate"  onFocus="WdatePicker({startDate:'%y-%M-01 00:00:00',dateFmt:'yyyy-MM-dd HH:mm:ss',alwaysUseStartDate:true})"  placeholder="请输入开始时间"
                type="text" />
            <span>结束时间:</span>
            <input id="endtime" size="16" class="input-medium   Wdate"  onFocus="WdatePicker({startDate:'%y-%M-01 00:00:00',dateFmt:'yyyy-MM-dd HH:mm:ss',alwaysUseStartDate:true})"  placeholder="请输入结束时间"
                type="text" />
            <span>状态:</span>
            <select id="state">
                <option value="-1">全部</option>
                <option value="1">成功</option>
                <option value="0">失败</option>
            </select>
        </div>
    </div>
    <div class="grid_tools">
        <table id="grid">
        </table>
    </div>
</asp:Content>
