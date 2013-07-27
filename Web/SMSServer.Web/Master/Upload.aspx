<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Upload.aspx.cs" Inherits="SMSServer.Web.Master.Upload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../Styles/bootstrap.css" rel="stylesheet" />
    <script src="../Scripts/lib/artDialog.js"></script>
    <script src="../Scripts/lib/jquery-1.7.1.min.js"></script>
    <script src="../Scripts/lib/jquery.actions.js"></script>
    <script src="../Scripts/lib/jquery.blockUI.js"></script>
    <script src="../Scripts/lib/jquery.common.js"></script>
    <script src="../Scripts/lib/jquery.form.js"></script>
    <script src="../Scripts/lib/jquery.eparse-common.js"></script>
    <script src="../Scripts/lib/artDialog.extend.js"></script>
    <script src="../Scripts/lib/bootstrap.min.js"></script>
    <link href="../Styles/common.css" rel="stylesheet" />
    <link href="../Styles/Site.css" rel="stylesheet" />
</head>
<body class="child_form ">
    <form id="form1" runat="server" class="form-horizontal">
        <div class="z-legend ">
           <strong>上传文件</strong>
        </div>
        <div style="margin-left: 20px;">
            <a id="fileupload" class="btn btn-link"><i class="icon-upload"></i>上传</a>
            <span style="margin-left: 5px; margin-right: 15px;"><i class="icon-info-sign"></i>请上传csv或txt(英文,间隔)文件</span>
            <span>路径：</span><span id="imgpre" style="border-bottom-color: cadetblue; border-bottom-style: solid; border-bottom-width: 1px;">......</span>
        </div>
        <div id="uploadpanel" style="border: 1px solid #CCCCCC; height: 180px; margin-top: 20px; overflow-y: scroll;">
        </div>
        <div class="autool_buttons" id="actions">
            <input type="button" value="确认" onclick="doupload();" class="button" />
            <input type="button" value="取消" class="button" />
        </div>
    </form>
</body>
</html>
