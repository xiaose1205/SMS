var gird;
$(document).ready(function () {
    if ($("#grid") != undefined) {
        gird = $("#grid").flexigrid({
            url: 'ajax/keyword/getlist',
            dataType: 'json',
            colModel: [
                { display: 'id', name: 'id', width: 100, align: 'center', hide: false },
                { display: '关键词', name: 'keyword', width: 300, align: 'center' },

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
        $.AddAction(450, 110, '添加关键词', "info/addkeyword.aspx", doQuery);;
    });
    $("#edit").click(function () {
        $.EditAction(450, 110, '修改关键词', "info/Editkeyword.aspx?id={0}", doQuery);;
    });
    $("#delete").click(function () {
        $.DeleteAction("keyword", doQuery, "是否确认删除所选的数据？");
    });
    $("#clear").click(function () {
        art.dialog.confirm("是否确认清空所有？", function () {
            $.post("../ajax/keyword/clear", {}, function (data) {
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
    if ($.trim($("#phone").val()) == "") {
        $.showError("关键词不能为空");
        return;
    }

    /*下面这段代码会自动处理提交信息，并执行返回后的function*/
    $.childAction(function () {
        var api = art.dialog.open.api;
        api && api.close();
    });
}
function edit() {
    if ($.trim($(".phone").val()) == "") {
        $.showError("关键词不能为空");
        return;
    }
    $("input[name='id']").val($(".keywordid").val());
    $("input[name='phone']").val($(".phone").val());
    /*下面这段代码会自动处理提交信息，并执行返回后的function*/
    $.childAction(function () {
        var api = art.dialog.open.api;
        api && api.close();
    });
}