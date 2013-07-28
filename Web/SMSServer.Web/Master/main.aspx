<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="SMSServer.Web.Master.main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <script type="text/javascript" src="Scripts/lib/jquery-1.7.1.min.js"></script>
    <script language="javascript" type="text/javascript" src="Scripts/lib/flexigrid.js"></script>
    <script language="javascript" type="text/javascript" src="Scripts/Script.js"></script>
    <link href="../Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/flexigrid.css" rel="stylesheet" type="text/css" />
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
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
