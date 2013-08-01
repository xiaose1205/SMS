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
////});
//$(document).ready(function () {
//    if ($("#grid") != undefined) {
//        $("#grid").flexigrid({
//            url: '../demo/data',
//            dataType: 'json',
//            colModel: [{ display: 'ISO', name: 'iso', width: 40, sortable: true, align: 'center' },
//		{ display: 'Name', name: 'name', width: 180, sortable: true, align: 'left' },
//		{ display: 'Printable Name', name: 'printable_name', width: 120, sortable: true, align: 'left' },
//		{ display: 'ISO3', name: 'iso3', width: 130, sortable: true, align: 'left', hide: true },
//		{ display: 'Number Code', name: 'numcode', width: 80, sortable: true, align: 'right' }],
//            minColToggle: 1,
//            onrowclick: false,
//            sortname: "iso",
//            sortorder: "asc",
//            usepager: true,
//            useRp: true,
//            rp: 15,
//            resizable: false,
//            width: 'auto',
//            height: 'auto',
//            autoload: true,
//            singleSelect: true,
//            specify: true,
//            striped: true,
//            showcheckbox: true,
//            showToggleBtn: true
//        });
        
//    }

//    function doQuery() {
//        if ($("#grid") != undefined) {
//            var contactQuery = {
//                "name": $("#name").val()
//            };
//            var params = {
//                extParam: contactQuery
//            };
//            if ($('#grid')[0] != undefined) {
//                $('#grid')[0].p.newp = 1;
//                $('#grid').flexOptions(params).flexReload();
//            }
//        }

//    }
//});