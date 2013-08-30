

var gird;
$(document).ready(function () {
    var setting = {
        view: {
            selectedMulti: false
        },
        async: {
            enable: true,
            url: "ajax/contactgroup/getlist",
            autoParam: ["id", "name=n", "level=lv"],
            dataFilter: filter
        },
        callback: {
            beforeClick: beforeClick,
            beforeAsync: beforeAsync,
            onAsyncError: onAsyncError,
            onAsyncSuccess: onAsyncSuccess

        }
    };
    var log, className = "dark";
    function beforeAsync(treeId, treeNode) {
        className = (className === "dark" ? "" : "dark");
        return true;
    }
    function onAsyncError(event, treeId, treeNode, XMLHttpRequest, textStatus, errorThrown) {
    }
    function onAsyncSuccess(event, treeId, treeNode, msg) {
        if (msg.length < 5) {
            treeNode.isParent = false;
            treeNode.isLastNode = true;
        }
    }
    var treeN = null;
    function beforeClick(treeId, treeNode) {
        treeN = treeNode;
        var contactQuery = {
            "gid": treeNode.id,
            "phone": $("#phone").val(),
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
    function filter(treeId, parentNode, childNodes) {
        if (!childNodes) return null;
        for (var i = 0, l = childNodes.length; i < l; i++) {
            childNodes[i].name = childNodes[i].name.replace(/\.n/g, '.');
        }
        return childNodes;
    }
    function getNodeId() {
        if (treeN == null) {
            return 0;
        } else {
            return treeN.id;
        }

    }
    $.fn.zTree.init($("#treeDemo"), setting);
    if ($("#grid") != undefined) {
        gird = $("#grid").flexigrid({
            url: 'ajax/contact/getlist',
            dataType: 'json',
            colModel: [
                { display: 'id', name: 'id', width: 50, align: 'center', hide: false },
                { display: '姓名', name: 'name', width: 100, align: 'center' },
                { display: '手机号码', name: 'phone', width: 150, align: 'center' },
                { display: '性别', name: 'sex', width: 80, align: 'center' },
                { display: '生日', name: 'birthday', width: 100, align: 'center' },
                { display: '备注', name: 'comment', width: 250, align: 'center' },
                { display: '创建时间', name: 'createtime', width: 100, align: 'center' }
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
        var id = getNodeId();
        var contactQuery = {
            "gid": id,
            "phone": $("#phone").val(),
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
    /*tag显示*/
    $('.waitsenduser').tagsInput({
        width: '90%',
        "height": '210px',
        'minChars': 11, //每个标签的小最字符
        'maxChars': 11,
        'maxCount': 500,
        'onChange': function (tag) {

        },//添加标签时的事件函数
        'onRemoveTag': function (tag) {

        },//移除标签时的事件函数
        'removeWithBackspace': true,
        'defaultText': '输入手机号码'
    });
    $("#sendcontent").change(function () {
        var value = $(this).val();
        var len = parseInt($("#lblWord").val());
        var signature = $("#signature").val();
        var totallen = value.length + signature.length;

        if (totallen <= 70)
            $("#lblGroupNum").val(1);
        else {
            $("#lblGroupNum").val(totallen / len + (totallen % len > 0 ? 1 : 0));
        }
        $("#lblWordNum").html(totallen);
    });
    $("#sendcontent").bind('textchange', function () {
        var value = $(this).val();
        var len = parseInt($("#lblWord").html());
        var signature = $("#signature").html();
        var totallen = value.length + signature.length;
         
        if (totallen <= 70)
            $("#lblGroupNum").html(1);
        else {
            $("#lblGroupNum").html(Math.ceil(totallen / len ));
        }
        $("#lblWordNum").html(totallen);
    });
    $(".waitsenduser_tag").bind('textchange', function () {
        var value = $(this).val();
        if (value.length > 11) {
            var arry = value.split(',');
            for (var i = 0; i < arry.length; i++) {
                if (arry[i].length == 11)
                    if (!$('.waitsenduser').tagExist(arry[i]))
                        $('.waitsenduser').addTag(arry[i]);
            }


        }
    });
    $("#search").click(function () {
        doQuery();
    });
    $("#addselect").click(function () {
        var checkedRows = $("#grid").getCheckedRows();
        if (!checkedRows || checkedRows.length <= 0) {
            $.showError("请选择需要发送的联系人！");
            return false;
        }

        for (var i = 0; i < checkedRows.length; i++) {
            var cid = reid(parseInt(checkedRows[i][0]) + 10000000000);

            if (!$('.waitsenduser').tagExist(cid))
                $('.waitsenduser').addTag(cid);
        }
    });
    $("#addall").click(function () {

        var id = getNodeId();
        var tag = "g" + id + "|" + $("#name").val() + "|" + $("#phone").val();
        console.log(tag);
        if (!$('.waitsenduser').tagExist(tag))
            $('.waitsenduser').addTag(tag);
    });
    $("#clear").click(function () {
        console.log("click");
        $('.waitsenduser').importTags();
    });
    function reid(id) {

        var newid = (id + "").substring(1);
        return "c" + newid + "";
    }

    $("#btnSelect").click(function () {
        art.dialog.open("info/seltemplate.aspx",
         {
             title: "选择短语", width: 620, height: 400, close: function () {
                 var content = art.dialog.data('content'); // 读取B页面的数据

                 if (content != undefined) {
                     $("#sendcontent").val($("#sendcontent").val() + content);

                     $("#lblWordNum").html($("#sendcontent").val().length);
                 }
             },
             lock: true,
             resize: false
         });
    });
    $(".smstag").click(function () {
        $("#sendcontent").val($("#sendcontent").val() + "@" + $(this).html());
        $("#lblWordNum").html($("#sendcontent").val().length);
        return false;
    });
    $("#btnSave").click(function () {
        if ($.trim($("#sendcontent").val()) == "") {
            $.showError("短语不能为空");
            return;
        }
        $.post("ajax/template/addtemplate", { template: $("#sendcontent").val() }, function (data) {
            if (data.Result == 1) {
                $.showSuccess("添加成功");
            } else {
                $.showError(data.Message);
            }
        }, "json");
    });

    $("#btnSend").click(function () {
        if ($.trim($("#sendcontent").val()) == "") {
            $.showError("短信内容不能为空");
            return;
        }
        var tags = $('.waitsenduser').getTags();
        console.log(tags.length);
        if (tags.length <= 1 && tags[0] == "") {
            $.showError("请输入手机号码或者选择联系人");
            return;
        }
        if ($.trim($("#txtName").val()) == "") {
            $.showError("批次名称不能为空");
            return;
        }
        $.post("ajax/sms/smssend", {
            content: $("#sendcontent").val(),
            mobiles: tags.toString(), batchname: $("#txtName").val(),
            batchremark: $("#txtRemark").val()
                  , fkeyword: $("#IsFilterKey").attr("checked") == "checked"
                    , fblack: $("#IsFilterBlack").attr("checked") == "checked"
                      , frepeat: $("#cbxNoAgain").attr("checked") == "checked"
        }, function (data) {
            if (data.Result == 1) {
                $.showSuccess("提交成功");
            } else {
                $.showError(data.Message);
            }
        }, "json");

    });
});

