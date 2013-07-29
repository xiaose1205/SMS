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