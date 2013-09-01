<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="SMSServer.Web.MainPage" %>

<%@ Import Namespace="SMSServer.Service" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>后台框架</title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta name="keywords" content="后台框架" />
    <meta name="description" content="后台框架" />
    <script type="text/javascript" src="Scripts/lib/jquery-1.7.1.min.js"></script>
    <script language="javascript" type="text/javascript" src="Scripts/lib/flexigrid-1.1A.js"></script>
    <script language="javascript" type="text/javascript" src="Scripts/Script.js"></script>
    <script src="Scripts/lib/jquery.textchange.min.js" language="javascript" type="text/javascript"></script>
    <script src="Scripts/lib/jquery.tagsinput.min.js" language="javascript" type="text/javascript"></script>
    <script src="Scripts/lib/artDialog.js?skin=black"></script>
    <script src="Scripts/lib/iframeTools.source.js"></script>
    <script src="Scripts/lib/jquery.actions.js"></script>
    <link href="Styles/buttons.css" rel="stylesheet" />
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="Styles/flexigrid.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/menu.js"></script>
    <link href="Styles/common.css" rel="stylesheet" />
    <script src="Scripts/lib/WdatePicker.js"></script>
    <link href="Scripts/lib/skin/WdatePicker.css" rel="stylesheet" />
    <!--[if IE 6]>
    <script type="text/javascript" src="Scripts/lib/DD_belatedPNG.js" ></script>
    <script type="text/javascript">DD_belatedPNG.fix('div,img');</script>
<![endif]-->
    <script type="text/javascript">
        $(function () {
            $('.flexme2').flexigrid({
                title: 'Countries',
                usepager: true,
                singleSelect: true,
                resizable: false,
                height: '100%'
            });

        });
        // loadPage("master/sysinfo.aspx");
    </script>
</head>
<body>
    <div id="header">
        <div id="top">
            <div class="logo">
                <img src="Images/logo.png" />版本号：V1.0
            </div>
            <ul class="quicklink">
                <li>用户：<a href="#">admin</a>
                </li>
                <li>
                    <a href="#">修改密码</a>
                </li>
                <li class="last">
                    <a href="#">退出</a>
                </li>
            </ul>
        </div>
        <div id="navigate" class="navigate">

            <div class="navigatehead" id="navigatehead">

                <h3>
                    <a href="javascript:void(0)" onclick="OpenShutManager()" class="navbtn" title="收缩菜单列表"></a>
                    <img src="Images/icon_settings.png" />功能菜单列表
                </h3>
            </div>

            <label>
                <img src="Images/icon_home.gif" />
                当前位置：短信运营系统 > <span id="nav1"></span>> <span id="nav2"></span>
            </label>
            <div style="float: right; display: none; background-color: khaki; padding: 3px; padding-left: 10px; padding-right: 10px; margin-top: 5px; margin-right: 10px;" id="pageload">
                <img src="Images/icons/indicator.gif" style="border: 0px; margin-right: 5px;" />加载中...
            </div>
        </div>
    </div>


    <div id="outContainer" class="outContainer">

        <div id="infoshow" style="bottom: 5px; right: 5px; position: fixed; padding-right: 10px; display: none; z-index: 1002">
            <div style="float: right; margin-top: 10px; margin-right: 5px;">
                <img src="Images/close.gif" />
            </div>
            <p>
                <strong>WARNING: </strong>
                <span>This is a warning message.
                </span>
            </p>

        </div>

        <div id="container" class="container">
            <div id="sidebar" class="sidebar">

                <h3 class="selected"><a href="javascript:void(0)">
                    <img class="meunStatus" src="Images/icon_menu_show.png" /><img src="Images/icon_sms.png" />短信管理</a></h3>
                <ul>
                    <li>
                        <a href="#" page="sms/smssend.aspx" title="联系人发送">
                            <img src="Images/icons/email_send.gif" />联系人发送</a>
                    </li>
                    <li>
                        <a href="#" page="sms/filesend.aspx" title="文件发送">
                            <img src="Images/icons/file_up.gif" />文件发送</a>
                    </li>
                    <li>
                        <a href="#" page="sms/phonehistory.aspx" title="号码历史">
                            <img src="Images/icons/email_valid.gif" />号码历史</a>
                    </li>
                    <li class="selected">

                        <a href="#" page="sms/batchhistory.aspx" title="批次历史">
                            <img src="Images/icons/album_option.gif" />批次历史</a>
                    </li>
                </ul>
                <h3><a href="javascript:void(0)">
                    <img class="meunStatus" src="Images/icon_menu_show.png" /><img src="Images/icons/email_read.gif" />接收信息</a></h3>
                <ul>
                    <li>
                        <a href="#" page="mo/moindex.aspx" title="上行信息">
                            <img src="Images/icons/email_inbox.gif" />上行信息</a>
                    </li>

                </ul>
                <h3><a href="javascript:void(0)">
                    <img class="meunStatus" src="Images/icon_menu_show.png" /><img src="Images/icons/app_option.gif" />资料管理</a></h3>
                <ul>
                    <li>
                        <a href="#" page="info/contact.aspx" title="通讯录">
                            <img src="Images/icons/email_contact.gif" />通讯录</a>
                    </li>
                    <li>
                        <a href="#" page="info/black.aspx" title="黑名单">
                            <img src="Images/icons/userprofile.gif " />黑名单</a>
                    </li>
                    <li>
                        <a href="#" page="info/keyword.aspx" title="关键词">
                            <img src="Images/icons/permission.gif " />关键词</a>
                    </li>
                    <li>
                        <a href="#" title="常用短语" page="info/template.aspx">
                            <img src="Images/icons/topic.gif " />常用短语</a>
                    </li>
                </ul>
                <h3><a href="javascript:void(0)">
                    <img class="meunStatus" src="Images/icon_menu_show.png" /><img src="Images/icons/setting.gif" />账号管理</a></h3>
                <ul>
                    <% if (AppContent.Current.GetCurrentUser().ID == 1)
                       { %>
                    <li>
                        <a href="#" page="account/account.aspx" title="企业账号">
                            <img src="Images/icons/people_famale.gif " />企业账号</a>
                    </li>
                    <li>
                        <a href="#" page="account/enterprise.aspx" title="企业信息">
                            <img src="Images/icons/fortune_1.gif " />企业信息</a>
                    </li>
                    <% } %>
                    <li>
                        <a href="#" page="master/sysinfo.aspx" title="基本信息">
                            <img src="Images/icons/vcard.gif " />基本信息</a>
                    </li>

                </ul>
                <ul>
                    <li>
                        <a href="#" page="aspxTest.aspx" title="退出登录">
                            <img src="Images/icons/Btn.Close.gif " />退出登录</a>
                    </li>

                </ul>
            </div>

            <div id="content">
                <div class="contentbody">
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
                </div>
            </div>
        </div>
    </div>
</body>
</html>
