

/*操作添加的页面*/
$.AddAction = function (width, height, name, url, funCallback) {
    art.dialog.open(url,
    {
        title: name, width: width, height: height, close: function () {
            var bValue = art.dialog.data('bValue'); // 读取B页面的数据
            if (bValue != undefined && bValue != '') {
                art.dialog.data('bValue', '');
                funCallback();
            }
        },
        lock: true,
        resize: false
    });
};

/*操作修改的页面*/
$.EditAction = function (width, height, name, url, funCallback) {
    var checkedRows = $("#grid").getCheckedRows();
    if (!checkedRows || checkedRows.length <= 0) {
        $.showError("请选择需要编辑的数据！");
        return false;
    }
    if (checkedRows.length > 1) {
        $.showError("每次只能编辑一个数据！");
        return false;
    }
    var id = checkedRows[0][0];
    var editurl = url.replace("{0}", id);
    art.dialog.open(editurl,
    {
        title: name, width: width, height: height, close: function () {
            var bValue = art.dialog.data('bValue'); // 读取B页面的数据
            if (bValue != undefined && bValue != '') {
                art.dialog.data('bValue', '');
                funCallback();
            }
        },
        lock: true,
        resize: false
    });

};

/*修改操作不是checkbox时的操作*/
$.EditActionSingle = function (width, height, name, url, funCallback) {
    art.dialog.open(url,
    {
        title: name, width: width, height: height, close: function () {
            var bValue = art.dialog.data('bValue'); // 读取B页面的数据
            if (bValue != undefined && bValue != '') {
                art.dialog.data('bValue', '');
                funCallback();
            }
        },
        lock: true,
        resize: false
    });
};

/*操作删除的页面*/
$.DeleteAction = function (handler, funCallback, msg) {
    var checkedRows = $("#grid").getCheckedRows();
    if (!checkedRows || checkedRows.length <= 0) {
        $.showError("请选择需要删除的数据！");
        return false;
    }
    var ids = "";
    for (var i = 0; i < checkedRows.length; i++) {
        ids += checkedRows[i][0] + ",";
    }
    var showmsg = (msg == undefined || msg == "" ? "确认要删除选中数据吗？" : msg)
    art.dialog.confirm(showmsg, function () {
        $.post("/Ajax.ashx", { handler: handler, type: 'delete', ids: ids }, function (data) {
            if (data.Result == 1) {
                funCallback();
            } else {
                $.showError(data.Message);
            }
        }, "json");
    }
    , function () {
    });
};

/*删除操作不是checkbox时的操作*/
$.DeleteActionSingle = function (handler, id, funCallback) {
    art.dialog.confirm("确认要删除选中数据吗?", function () {
        $.post("/Ajax.ashx", { handler: handler, type: 'delete', ids: id }, function (data) {
            if (data.Result == 1) {
                $.showSuccess(data.Message);
                funCallback();
            } else {
                $.showError(data.Message);
            }
        }, "json");
    }
    , function () {
    });
};

$.childAction = function (fun) {
    $.showError("");
    var isunvailty = false;
    $("#form1").find("input[type][name]").each(function () {

        if (($(this).attr("data-null") != "" && $(this).attr("data-null") == "false") && $.trim($(this).val()) == "") {
            $.showError($(this).attr("data-msg"));
            isunvailty = true;
            $(this).focus();
            return false;
        }
        if ($(this).attr("data-minlength") != undefined && $(this).attr("data-minlength") != "" && $.trim($(this).val()).length < $(this).attr("data-minlength")) {
            $.showError("输入字符长度请大于" + $(this).attr("data-minlength") + "");
            $(this).focus(); isunvailty = true; return false;
        }
        if (($(this).attr("data-maxlength") != undefined
            && $(this).attr("data-maxlength") != "")
            && $.trim($(this).val()).length > $(this).attr("data-maxlength")) {
            $.showError("输入字符长度请小于" + $(this).attr("data-maxlength") + "");
            $(this).focus(); isunvailty = true; return false;
        }
        if ($(this).attr("data-reg") != undefined && $(this).attr("data-reg") != "") {
            var reg = $(this).attr("data-reg");
            if (!reg.test($(this).val())) {
                $.showError($(this).attr("data-msg"));
                $(this).focus(); isunvailty = true; return false;
            }
        }
        if ($(this).attr("data-number") != undefined && $("data-number") != "") {
            var reg = $(this).attr("data-number");
            if (!reg.test($(this).val())) {
                $.showError($(this).attr("data-msg"));
                $(this).focus(); isunvailty = true; return false;
            }
        }
        if ($(this).attr("data-special-char") != undefined && $("data-special-char") != "") {
            var reg = new RegExp("[~!@#$%^&*()=+[\\]{}\"'.;:/?><`|！·￥…—（）\\-、；：。？，“”‘’》《]");
            if (!reg.test($(this).val())) {
                $.showError($(this).attr("data-msg-special-char"));
                $(this).focus(); isunvailty = true; return false;
            }
        }
    });
    if (isunvailty == false) {
        $(".form-horizontal").xwAjaxPost(fun);
    }
};

$.popupWindow = function (width, height, name, url) {
    art.dialog.open(url,
        {
            title: name,
            width: width,
            height: height,
            close: function () {
                var bValue = art.dialog.data('bValue'); // 读取B页面的数据
                if (bValue != undefined && bValue != '') {
                    art.dialog.data('bValue', '');
                }
            },
            lock: true,
            resize: false
        });
};
var isshowIngo = false;
function showInf(a, b) {
    if (isshowIngo == false) {
        isshowIngo = true;
        $("#infoshow").show();
        window.setTimeout(function () {
            $("#infoshow").hide("slow");
            isshowIngo = false;
        }, 5000);
    }
    $("#infoshow").removeClass().addClass(a);
    $("#infoshow").find("strong").html(a + ":");
    $("#infoshow").find("span").html(b);
  
}

$.showError = function (message, func, element) {
    var api = art.dialog.open.api;
    if (api == undefined) {
        showInf("error",message);
    } else {
        api.info(message, "error");
      
    }
    if (typeof (func) != "undefined")
        func();
    if (element != undefined) {

    }
    //art.dialog({
    //    icon: 'error',
    //    lock: true,
    //    fixed: true,
    //    content: message,
    //    ok: function () {
    //        if (typeof (func) != "undefined")
    //            func();
    //    }

    //});
};

$.showSuccess = function (message, func) {
    art.dialog({
        icon: 'succeed',
        lock: true,
        fixed: true,
        content: message,
        ok: function () {
            if (typeof (func) != "undefined")
                func();
        }
    });
};
$.alert = function (result, message, func) {
    art.dialog({
        icon: result == 1 ? 'succeed' : 'error',
        lock: true,
        fixed: true,
        content: message,
        ok: function () {
            if (result == 1 && typeof (func) != "undefined")
                func();
        }
    });
}