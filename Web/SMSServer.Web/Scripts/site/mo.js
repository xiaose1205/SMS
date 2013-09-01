var gird;
$(document).ready(function() {
    if ($("#grid") != undefined) {
        gird = $("#grid").flexigrid({
            url: 'ajax/mo/getlist',
            colModel: [
                { display: 'id', name: 'id', width: 100, align: 'center', hide: false },
                { display: '手机号码', name: 'phone', width: 100, align: 'center' },
                { display: '短信内容', name: 'content', width: 250, align: 'center' },
                 { display: '接收时间', name: 'retime', width: 150, align: 'center' }
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
        }); doQuery();
    }
    function doQuery() {
        var contactQuery = {
            "batchname": $("#name").val(),
            "state": $("#state").val(),
            "starttime": $("#starttime").val(),
            "endtime": $("#endtime").val()
        };
        var params = {
            extParam: contactQuery
        };
        if ($('#grid')[0] != undefined) {
            $('#grid')[0].p.newp = 1;
            $('#grid').flexOptions(params).flexReload();
        }
    }

    $("#search").click(function () {
        doQuery();
    });
});