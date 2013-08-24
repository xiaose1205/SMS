<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelTemplate.aspx.cs" Inherits="SMSServer.Web.Info.SelTemplate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

    <script type="text/javascript" src="../Scripts/lib/jquery-1.7.1.min.js"></script>
    <script src="../Scripts/lib/artDialog.js?skin=black"></script>
    <script src="../Scripts/lib/iframeTools.source.js"></script>
    <link href="../Styles/buttons.css" rel="stylesheet" />
    <link href="../Styles/flexigrid.css" rel="stylesheet" type="text/css" />

    <link href="../Styles/common.css" rel="stylesheet" />
    <script language="javascript" type="text/javascript" src="../Scripts/lib/flexigrid-1.1A.js"></script>
    <script src="../Scripts/site/template.js"></script>
    <link href="../Styles/child.css" rel="stylesheet" />
    <script src="../Scripts/lib/artDialog.extend.js"></script>

    <script src="../Scripts/lib/jquery.actions.js"></script>
    <script>
        var gird;
        $(document).ready(function () {
            if ($("#grid") != undefined) {
                gird = $("#grid").flexigrid({
                    url: 'ajax/template/getlist',
                    dataType: 'json',
                    colModel: [
                        { display: 'id', name: 'id', width: 50, align: 'center', hide: false },
                        { display: '常用短语', name: 'content', width: 300, align: 'center' },
                        { display: ' 创建时间', name: 'createtime', width: 100, align: 'center' }
                    ],
                    minColToggle: 1,
                    onrowclick: false,
                    sortname: "id",
                    sortorder: "asc",
                    usepager: true,
                    useRp: true,
                    rp: 15,
                    resizable: false,
                    width: 'auto',
                    height: '300',
                    autoload: false,
                    singleSelect: true,
                    specify: true,
                    striped: true,
                    showcheckbox: true,
                    mutliSelect: true,
                    showToggleBtn: true
                });
                doQuery();
            }

            function doQuery() {
                var contactQuery = {

                };
                var params = {
                    extParam: contactQuery
                };
                if ($('#grid')[0] != undefined) {
                    $('#grid')[0].p.newp = 1;
                    $('#grid').flexOptions(params).flexReload();
                }
            }
        });
        function select() {
            var checkedRows = $("#grid").getCheckedRows();
            if (!checkedRows || checkedRows.length <= 0) {
                $.showError("请选择需要的数据！");
                return false;
            }
            if (checkedRows.length > 1) {
                $.showError("每次只能选择一条数据！");
                return false;
            }

            art.dialog.data("content", checkedRows[0][1]);

            var api = art.dialog.open.api;
            api && api.close();
        };
    </script>
</head>
<body>
    <div class="tools">
        <div class="cont_tools" style="width: 30%">
            <a href="#" id="search" class="button button-rounded button-tiny   button-action">查询</a>
        </div>
        <div class="search_tools">
            <span style="font-size: 12px">短信内容:</span>
            <input id="name" size="16" class="input-medium" placeholder="请输入短信内容"
                type="text" />
        </div>
    </div>
    <div class="grid_tools">
        <table id="grid">
        </table>
    </div>
    <%---将button,input 放在这个容器里面就会自动处理 ----%>
    <div class="autool_buttons" id="actions">
        <input type="button" value="选择短语" onclick="select();" />
    </div>
</body>
</html>
