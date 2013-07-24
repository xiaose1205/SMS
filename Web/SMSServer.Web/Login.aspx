<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SMSServer.Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="Styles/login.css" rel="stylesheet" />
</head>
<body class="loginPageBody">
    <div class="LoginWrapbg">
        <div style="width: 100%; height: 50%; left: 0; top: 0; z-index: -1;">
        </div>
        <div style="width: 442px; height: 440px; margin: 0 auto; margin-top: -260px;">
            <div class="loginLogo">
            </div>

            <div class="loginBar" id="loginBar">
                <form id="form1" method="post">
                    <div class="welcome">
                        欢迎登录短信系统
                    </div>
                    <div class="">
                        <div class="fieldWrap">
                            <div class="lable">
                                用户账号：
                            </div>
                            <div class="inputWrap">
                                <input name="UserName" type="text" class="inputText" id="UserName" onfocus="this.select();" />
                            </div>
                        </div>
                        <div class="fieldWrap">
                            <div class="lable">
                                用户密码：
                            </div>
                            <div class="inputWrap">
                                <input name="Password" type="password" class="inputText" id="Password" onfocus="this.select();" />
                            </div>
                        </div>
                        <div class="fieldWrap verifyCodeWrap" id='verifyCodeWrap'>
                        </div>
                        <%--     <div class="fieldWrap">
                            <div class="lable">
                                验证码：
                            </div>
                            <div class=" selectWrap inputWrap">
                                <input name="checkcode" type="text" class="inputText" id="checkcode" onfocus="this.select();"
                                    style="width: 100px;" />
                                <img src="Ajax.ashx?handler=checkcode" id="img_checkcode" onclick="recheckcode('checkcode')"
                                    style="height: 23px; margin-bottom: -5px;" />
                            </div>
                        </div>--%>
                        <div class="fieldWrap" id="loginBtnWrap">
                            <input type="button" id="loginBtn" class="inline-block" style="cursor: pointer" value="登录" />
                        </div>
                        <div class="fieldWrap" id="Div1">
                            <span id="err"></span>
                        </div>
                    </div>
                </form>
            </div>
        </div>
        <div class="copyright">
            <div class="center">
                Copyright &copy; 2012-2013 Design by Eparse Inc. All rights reserved.Eparse版权所有
            </div>
        </div>
    </div>
</body>
</html>
