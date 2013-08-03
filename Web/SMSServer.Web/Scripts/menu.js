$(document).ready(function () {
    $(".navbtn").mouseenter(function () {

        if ($("#navigatehead").hasClass("navigatehead-mini")) {
            $("#navigatehead").addClass("navigatehead-mini-over");
        }
    });
    $(".navbtn").mouseleave(function () {
        if ($("#navigatehead").hasClass("navigatehead-mini")) {
            $("#navigatehead").removeClass("navigatehead-mini-over");
        }
    });
    $("#sidebar h3 a").click(function () {
        if ($(this).parent().next().css("display") == "none") {
            $(this).parent().next().show("slow");
            $(this).find(".meunStatus").attr("src", "Images/icon_menu_show.png");
        } else {
            $(this).find(".meunStatus").attr("src", "Images/icon_menu_hide.png");
            $(this).parent().next().hide("slow");
        }
    });
    $("#sidebar ul li a ").click(function () {
        $("#sidebar h3").removeClass("selected");
        $("#sidebar ul li").removeClass("selected");
        $(this).parent().addClass("selected");
        $(this).parent().parent().prev().addClass("selected");
        $("#nav1").html($(this).parent().parent().prev().text());
        $("#nav2").html($(this).text());
        loadPage($(this).attr("page"));
     
        return false;
    });
    $("#infoshow").click(function() {
        $(this).hide("slow");
    });
});
function exit() {

    art.dialog({
        lock: true,
        fixed: true,
        content: '确认要退出当前系统吗?',
        ok: function () {
            $.post("/Ajax.ashx", { handler: 'user', type: 'exit' }, function (data) {
                if (data.Result == 1) {
                    window.location.href = "/Login.aspx";
                } else {
                    art.dialog(data.Message);
                }
            }, "json");
        },
        cancelVal: '关闭',
        cancel: true //为true等价于function(){}
    });

}

 function shutoropen(menucount) {
    var classname = m_id('menuimg_' + menucount).parentNode.className;
    if (m_id('menu_' + menucount).style.display == 'none') {
        m_id('menu_' + menucount).style.display = ''; collapsed = collapsed.replace('[' + menucount + ']', '');
        m_id('menuimg_' + menucount).src = '../img/LeftNav/bt_show.png';
    } else {
        m_id('menu_' + menucount).style.display = 'none'; collapsed += '[' + menucount + ']';
        m_id('menuimg_' + menucount).src = '../img/LeftNav/bt_block.png';
    }
}

function OpenShutManager() {
    var leftnav = $('#outContainer');
    var titlenav = $('#navigate');
    var navigatehead = $('#navigatehead');
   // var container = $('#container');
    var cont = $('#content');
    if (leftnav.hasClass("outContainer-mini")) {
        leftnav.removeClass("outContainer-mini");
        titlenav.removeClass("navigate-mini");
        cont.removeClass("content-mini");
        leftnav.addClass("outContainer");
        titlenav.addClass("navigate");
        cont.addClass("content");
        navigatehead.addClass("navigatehead");
        navigatehead.removeClass("navigatehead-mini");
        navigatehead.removeClass("navigatehead-mini-over");
        document.body.style.background ="url('../Images/body_bg.gif') repeat-y left top";
        //container.addClass("container");
        //container.removeClass("container-mini");
    } else {
        //container.addClass("container-mini");
        //container.removeClass("container");
        navigatehead.addClass("navigatehead-mini");
        navigatehead.removeClass("navigatehead");
        leftnav.removeClass("outContainer");
        titlenav.removeClass("navigate");
        cont.removeClass("content");
        leftnav.addClass("outContainer-mini");
        titlenav.addClass("navigate-mini");
        cont.addClass("content-mini");
        document.body.style.background = "url('../Images/body_bg-mini.gif') repeat-y left top";

    }
}

function loadPage(url) {
    $("#pageload").show();
    var date = new Date();
    var urlnew = url;
    if (url.indexOf("?") > -1)
        urlnew = url + "&t=" + date.getMilliseconds();
    else {
        urlnew = url + "?t=" + date.getMilliseconds();
    }
    //$(".contentbody").load(urlnew, function (response, status, xhr) {
    //    $("#pageload").hide();
    //    }
    //);
    $.ajax({
        url: urlnew, success: function (data) {
            $(".contentbody").html(data);
            $("#pageload").hide();
        }
    });
 
}

function alertWarn(msg) {

}

function closeAlert() {

}