var gird;
$(document).ready(function () {
    if ($("#grid") != undefined) {
        gird = $("#grid").flexigrid({
            url: 'ajax/enterprise/getlist',
            dataType: 'json',
            colModel: [
                { display: 'id', name: 'id', width: 30, align: 'center', hide: false },
                { display: '企业名称', name: 'name', width: 100, align: 'center' },
                { display: '企业描述', name: 'introduction', width: 150, align: 'center' },
                { display: '短信单价', name: 'smsprice', width: 100, align: 'center' },
                 { display: '移动通道', name: 'chinamobile', width: 100, align: 'center' },
                  { display: '联通通道', name: 'union', width: 100, align: 'center' },
                  { display: '电信通道', name: 'cdma', width: 100, align: 'center' },
                   { display: '短信长度', name: 'smslength', width: 100, align: 'center' },
                { display: '创建时间', name: 'createtime', width: 150, align: 'center' }
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
            height: 'auto',
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

    $("#add").click(function () {
        $.AddAction(450, 130, '添加企业', "account/addenterprise.aspx", doQuery);;
    });
    $("#edit").click(function () {
        $.EditAction(450, 130, '修改企业', "account/editenterprise.aspx?id={0}", doQuery);;
    });
    $("#delete").click(function () {
        $.DeleteAction("black", doQuery, "是否确认删除所选的数据？");
    });
    $("#setting").click(function () {
        $.EditAction(450, 280, '设置企业短信规则', "account/enterprisecfg.aspx?eid={0}", doQuery);;
    });
});


function add() {
    if ($.trim($("#name").val()) == "") {
        $.showError("手机号码不能为空");
        return;
    }

    /*下面这段代码会自动处理提交信息，并执行返回后的function*/
    $.childAction(function () {
        var api = art.dialog.open.api;
        api && api.close();
    });
}
function edit() {
    if ($.trim($("#name").val()) == "") {
        $.showError("手机号码不能为空");
        return;
    }
    /*下面这段代码会自动处理提交信息，并执行返回后的function*/
    $.childAction(function () {
        var api = art.dialog.open.api;
        api && api.close();
    });
}
function setting() {
    
    /*下面这段代码会自动处理提交信息，并执行返回后的function*/
    $.childAction(function () {
        var api = art.dialog.open.api;
        api && api.close();
    });
}