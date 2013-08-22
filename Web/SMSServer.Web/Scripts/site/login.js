
var ajaxhtml = "<span class='ajaxloading'>服务器正在处理中...</span>";
var successhtml = '<span class="suc-msg">处理成功</span>';
var errorhtml = '<span class="err-msg">处理失败</span>';
/*重新加载验证码*/
function recheckcode(field) {

    $("#img_" + field).attr("src", "Ajax.ashx?handler=checkcode&time=" + new Date().getMilliseconds() + "");
}
var isChecked = false;
function checkcode() {

}
function login() {
    $("#err").html("");
    if ($.trim($("#UserName").val()) == "") {
        $("#err").html("请输入用户名");
        return false;
    }
    if ($.trim($("#Password").val()) == "") {
        $("#err").html("请输入密码"); return false;
    }
    $("#err").html("正在登录服务器");
    $.post("ajax/user/login", {   username: $("#UserName").val(), password: $("#Password").val() }, function (data) {
        if (data.Result == 1) {
            window.location.href = "mainpage.aspx";
        } else {
            $("#err").html(data.Message);
        }
    }, "json");
    return false;
}
$().ready(function () {

    $("#loginBtn").click(function () {
        login();
    });
    $(this).bind('keydown', function (e) {
        var key = e.which;
        if (key == 13) {
            e.preventDefault();
            login();
        }
    });

});