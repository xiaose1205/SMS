var setting = {
    async: {
        enable: true,
        url: "../aspxTest.aspx",
        autoParam: ["id", "name=n", "level=lv"],
        otherParam: { "otherParam": "zTreeAsyncTest" },
        dataFilter: filter
    }
};

function filter(treeId, parentNode, childNodes) {
    if (!childNodes) return null;
    for (var i = 0, l = childNodes.length; i < l; i++) {
        childNodes[i].name = childNodes[i].name.replace(/\.n/g, '.');
    }
    return childNodes;
}
var gird;
$(document).ready(function () {
    $.fn.zTree.init($("#treeDemo"), setting);
    if ($("#grid") != undefined) {
        gird = $("#grid").flexigrid({
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
            height: '190',
            autoload: true,
            singleSelect: true,
            specify: true,
            striped: true,
            showcheckbox: true,
            mutliSelect: true,
            showToggleBtn: true
        });
    }
    /*tag显示*/
    $('#waitsenduser').tagsInput({
        width: '90%',
        "height": '210px',
        'minChars':11, //每个标签的小最字符
        'maxChars': 11,
        'maxCount': 500,
        'onChange': function (tag) {
          
        },//添加标签时的事件函数
        'onRemoveTag': function (tag) {

        },//移除标签时的事件函数
        'removeWithBackspace': true,
        'defaultText': '输入手机号码'
    });
    $("#sendcontent").bind('textchange', function () {
        var value = $(this).val();
        $("#lblWordNum").html(value.length);
    });
    $("#waitsenduser_tag").bind('textchange', function () {
        var value = $(this).val();
        if (value.length > 11) {
            var arry = value.split(',');
            $('#waitsenduser').importTags(value);
        }
    });
    
});

