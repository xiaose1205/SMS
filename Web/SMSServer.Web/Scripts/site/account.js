﻿var gird;
$(document).ready(function () {
    if ($("#grid") != undefined) {
        gird = $("#grid").flexigrid({
            url: 'ajax/account/getlist',
            dataType: 'json',
            colModel: [
                { display: 'id', name: 'id', width: 30, align: 'center', hide: false },
                { display: '账号名称', name: 'account', width: 100, align: 'center' },
                  { display: '企业ID', name: 'eid', width: 50, align: 'center' },
                { display: '签名', name: 'signature', width: 100, align: 'center' },
                 { display: '状态', name: 'state', width: 100, align: 'center' },
                { display: '创建时间', name: 'createtime', width: 150, align: 'center' },
                { display: '最近登录时间', name: 'logintime', width: 150, align: 'center' }
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
        $.AddAction(450, 210, '添加账号', "account/addaccount.aspx", doQuery);;
    });
    $("#edit").click(function () {
        $.EditAction(450, 160, '修改账号', "account/Editaccount.aspx?id={0}", doQuery);;
    });
    $("#delete").click(function () {
        $.DeleteAction("account", doQuery, "是否确认删除所选的数据？");
    });
    $("#changepwd").click(function () {
        $.EditAction(450, 160, '修改密码', "account/Editpassword.aspx?id={0}", doQuery);;
    });
    $("#unuseful").click(function () {
        var checkedRows = $("#grid").getCheckedRows();
        if (!checkedRows || checkedRows.length <= 0) {
            $.showError("请选择需要设置的数据！");
            return;
        }
        var ids = "";
        for (var i = 0; i < checkedRows.length; i++) {
            ids += checkedRows[i][0] + ",";
        }
        art.dialog.confirm("是否确认设置状态为禁用？", function () {
            $.post("../ajax/account/setstate", { ids: ids, state: 0 }, function (data) {
                if (data.Result == 1) {
                    doQuery();
                } else {
                    $.showError(data.Message);
                }
            }, "json");
        }
         , function () {
         });
    });
    $("#useful").click(function () {
        var checkedRows = $("#grid").getCheckedRows();
        if (!checkedRows || checkedRows.length <= 0) {
            $.showError("请选择需要设置的数据！");
            return;
        }
        var ids = "";
        for (var i = 0; i < checkedRows.length; i++) {
            ids += checkedRows[i][0] + ",";
        }
        art.dialog.confirm("是否确认设置状态为正常？", function () {
            $.post("../ajax/account/setstate", { ids: ids, state: 1 }, function (data) {
                if (data.Result == 1) {
                    doQuery();
                } else {
                    $.showError(data.Message);
                }
            }, "json");
        }
         , function () {
         });
    });
});


function add() {
    if ($.trim($("#account").val()) == "") {
        $.showError("账号不能为空");
        return;
    }

    /*下面这段代码会自动处理提交信息，并执行返回后的function*/
    $.childAction(function () {
        var api = art.dialog.open.api;
        api && api.close();
    });
}
function edit() {
    if ($.trim($("#account").val()) == "") {
        $.showError("账号不能为空");
        return;
    }

    /*下面这段代码会自动处理提交信息，并执行返回后的function*/
    $.childAction(function () {
        var api = art.dialog.open.api;
        api && api.close();
    });
}
function edit() {
    if ($.trim($("#account").val()) == "") {
        $.showError("账号不能为空");
        return;
    }

    /*下面这段代码会自动处理提交信息，并执行返回后的function*/
    $.childAction(function () {
        var api = art.dialog.open.api;
        api && api.close();
    });
}

function cgpwd() {
    if ($.trim($("#pwd").val()) == "") {
        $.showError("密码不能为空");
        return;
    }
    if ($.trim($("#repwd").val()) == "") {
        $.showError("确认密码不能为空");
        return;
    }
    if ($.trim($("#repwd").val()) != $.trim($("#pwd").val())) {
        $.showError("两次密码不相同");
        return;
    }
    /*下面这段代码会自动处理提交信息，并执行返回后的function*/
    $.childAction(function () {
        var api = art.dialog.open.api;
        api && api.close();
    });
}