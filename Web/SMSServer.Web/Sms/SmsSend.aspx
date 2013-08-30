<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MainSite.Master" AutoEventWireup="true" CodeBehind="SmsSend.aspx.cs" Inherits="SMSServer.Web.Sms.SmsSend" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ScriptHolder" runat="server">
    <link href="../Styles/smssend.css" rel="stylesheet" />

    <script src="../Scripts/lib/jquery.ztree.all-3.5.min.js"></script>
    <script src="../Scripts/site/sms.js"></script>
    <link href="../Styles/jquery.tagsinput.css" rel="stylesheet" />
    <link href="../Styles/zTreeStyle.css" rel="stylesheet" />
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="sendpanel">
        <div class="pleft formPanel">
            <h4>通讯录列表</h4>
            <div class="ztreeground">
                <ul id="treeDemo" class="ztree"></ul>
            </div>

        </div>
        <div class="pright" style="height: 240px;">
            <div class="tools">
                <div class="cont_tools" style="width: 35%">

                    <a href="#" id="search" class="button button-rounded button-tiny   button-action">查询</a>

                    <a href="#" id="addselect" class="button button-rounded button-tiny button-primary">添加所选</a>
                    <a href="#" id="addall" class="button button-rounded button-tiny button-primary">添加全部</a>
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

        <div class="pleft formPanel">
            <h4>待发送联系人列表</h4>
            <textarea style="width: 240px; height: 200px;" id="waitsenduser" class="waitsenduser"></textarea>

            <div class="cont_tools" style="width: 100%">
                可以在输入框内直接粘贴(,分隔)  <a id="clear" class="button button-rounded button-tiny   button-highlight">清空</a>
            </div>
        </div>
        <div class="pright formPanel">
            <h4>编辑短信信息</h4>

            <div style="padding-bottom: 5px; padding-top: 5px">
                <div style="margin-bottom: 5px;">
                    批次名称：
                    <input class="text" maxlength="50" style="width: 60%; min-width: 330px;" id="txtName" /><span class="red">*</span>
                </div>
                <div>
                    批次备注：
                    <input class="text" maxlength="50" style="width: 60%; min-width: 330px;" id="txtRemark" />
                </div>
            </div>
            <div style="margin: 5px;">
                <input class="button button-rounded button-tiny button-primary" id="btnPreview" type="button" value="内容预览" />
                <input class="button button-rounded button-tiny button-primary" id="btnSelect" type="button" value="选择短语" />
                <input class="button button-rounded button-tiny button-primary" id="btnSave" type="button" value="保存短语" />
                <input class="txt" style="margin-right: 2px" id="IsFilterKey" type="checkbox" value="1"
                    checked="checked" /><a id="aFilterKey" style="cursor: hand">过滤关键字</a>
                <input class="txt" style="margin-right: 2px" id="IsFilterBlack" type="checkbox" value="1"
                    checked="checked" /><a id="aFilterBlack" style="cursor: hand">过滤黑名单</a>
                <input class="txt" style="margin-right: 2px" id="cbxNoAgain" type="checkbox" value="1"
                    checked="checked" /><a id="aNoAgain" style="cursor: hand">过滤重复号码</a>
            </div>

            <textarea style="width: 95%; height: 70px;" id="sendcontent"></textarea>
            <div>
                <a class="smstag">姓名</a>
                <a class="smstag">性别</a>
                <a class="smstag">生日</a>
                <a class="smstag">手机号码</a>
                <a class="smstag">备注</a>
            </div>
            <div style="margin: 5px;">
                签名：<span id="signature"><%=signature %></span>含签名共&nbsp;<label class="red" id="lblWordNum">
                    0</label>&nbsp;个字。[移动、联通、电信分&nbsp;<label class="red" id="lblGroupNum">
                        0
                    </label>
                &nbsp; 段，每条&nbsp;<span class="red" id="lblWord">
                    <%=smslength %></span>&nbsp; 个字]
            
               <input class="button button-rounded button-tiny button-primary" id="btnSend" type="button" value="发送短信" />
            </div>
            <div style="color: #999">
                * 批次是用来描述一批短信,每次发送信息都作为一个批次,无论发送信息的数量为多少。
                        <br />
                * 批次名称和批次备注将会便于您的后期查询。
            </div>

        </div>

    </div>
</asp:Content>
