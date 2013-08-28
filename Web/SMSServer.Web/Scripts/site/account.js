var gird;
$(document).ready(function () {
    if ($("#grid") != undefined) {
        gird = $("#grid").flexigrid({
            url: 'ajax/account/getlist',
            dataType: 'json',
            colModel: [
                { display: 'id', name: 'id', width: 30, align: 'center', hide: false },
                { display: '账号名称', name: 'account', width: 100, align: 'center' },
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
        $.AddAction(450, 110, '添加黑名单', "info/addblack.aspx", doQuery);;
    });
    $("#edit").click(function () {
        $.EditAction(450, 110, '修改黑名单', "info/EditBlack.aspx?id={0}", doQuery);;
    });
    $("#delete").click(function () {
        $.DeleteAction("black", doQuery, "是否确认删除所选的数据？");
    });
    $("#clear").click(function () {
        art.dialog.confirm("是否确认清空所有？", function () {
            $.post("../ajax/black/clear", {}, function (data) {
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
    $("#inport").click(function () {
        var uploadArr = [];
        uploadArr.push("手机号码");
        art.dialog.data("uploadarr", uploadArr);
        art.dialog.data("ajaxhande", "black");
        $.AddAction(500, 300, '导入黑名单', "../Master/Upload.aspx", function () {
            var bValue = art.dialog.data('bValue'); // 读取B页面的数据
            doQuery();
            art.dialog.data('bValue', "");
        });
    });
});


function add() {
    if ($.trim($("#phone").val()) == "") {
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
    if ($.trim($("#phone").val()) == "") {
        $.showError("手机号码不能为空");
        return;
    }
    /*下面这段代码会自动处理提交信息，并执行返回后的function*/
    $.childAction(function () {
        var api = art.dialog.open.api;
        api && api.close();
    });
}