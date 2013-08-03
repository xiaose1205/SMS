function add() {
    if ($.trim($("#UserName").val()) == "") {
        $.showError("用户名不能为空");
        return;
    }

    /*下面这段代码会自动处理提交信息，并执行返回后的function*/
    $.childAction(function () {
        var api = art.dialog.open.api;
        api && api.close();
    });
}

function addindex() {
 
    if ($.trim($("#UserName").val()) == "") {
      
        $.showError("用户名不能为空");
        return;
    }
    $.childAction(function () {
        var api = art.dialog.open.api;
        api && api.close();
    });
}

//$('.flexme2').flexigrid({
//    title: "MyTable",
//    usepager: true,
//    singleSelect: true,
//    resizable: false,
//    height: '100%'
//});
var gird;
$(document).ready(function () {
    if ($("#grid") != undefined) {
        gird=   $("#grid").flexigrid({
            url: 'demo/Ajax.ashx?handler=user&type=list',
            dataType: 'json',
            colModel: [
                { display: 'id', name: 'id', width: 100, align: 'center', hide: false },
                { display: '用户名称', name: 'name', width: 250, align: 'center' },
                { display: '权限', name: 'identity', width: 150, align: 'center' }
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
            autoload: true,
            singleSelect: true,
            specify: true,
            striped: true,
            showcheckbox: true,
            mutliSelect:true,
            showToggleBtn: true 
        });
    }
   
    $("#add").click(function () {
        $.AddAction(500, 180, '添加用户', "demo/add.aspx", function () {
        });;
    });
    $("#search").click(function () {
        doQuery();
    });
    $("#delete").click(function() {
        $.DeleteAction("", function() {
        },"")
    });
});
function doQuery() {

    if ($("#grid") != undefined) {
        alert(gird.getCheckedRows());
        var contactQuery = {
            "name": $("#name").val()
        };
        var params = {
            extParam: contactQuery
        };
        if ($('#grid')[0] != undefined) {
            $('#grid')[0].p.newp = 1;
            $('#grid').flexOptions(params).flexReload();
        }
    }

}