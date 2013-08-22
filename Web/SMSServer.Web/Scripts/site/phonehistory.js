﻿var gird;
$(document).ready(function () {
    if ($("#grid") != undefined) {
        gird = $("#grid").flexigrid({
            url: 'ajax/phonehistory/getlist',
            dataType: 'json',
            colModel: [
                { display: 'id', name: 'id', width: 100, align: 'center', hide: true },
                { display: '批次名称', name: 'batchname', width: 150, align: 'center' },
                { display: '手机号码', name: 'phone', width: 100, align: 'center' },
                { display: '短信内容', name: 'content', width: 250, align: 'center' },
                { display: '状态', name: 'state', width: 80, align: 'center' },
                { display: '状态描述', name: 'stateremark', width: 150, align: 'center' },
                { display: '发送时间', name: 'posttime', width: 100, align: 'center' }
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
            mutliSelect: true,
            showToggleBtn: true
        });
    }
});