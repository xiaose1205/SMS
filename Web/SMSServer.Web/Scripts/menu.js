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
        loadPage($(this).attr("page"));
        return false;
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

 
//加载样式---类
function addClass(elem, value) {
    if (!elem.className) {
        elem.className = value;
    } else {
        newClass = elem.className;
        newClass += " ";
        newClass += value;
        elem.className = newClass;
    }
}
//点击实现高亮显示---类
function highOnclick(elemId, tagOff, tagOff2, classCur, add_cur) {
    if (!document.getElementsByTagName) return false;
    if (!document.getElementById(elemId)) return false;
    var elemId = document.getElementById(elemId);
    var links = elemId.getElementsByTagName("a");
    for (i = 0; i < links.length; i++) {
        if (links[i].parentNode.nodeName != tagOff && links[i].parentNode.nodeName != tagOff2) {
            links[i].onclick = function () {
                for (n = 0; n < links.length; n++) {
                    links[n].className = "";
                }
                this.className = classCur;
                firsttagoff(elemId, tagOff, this.parentNode.parentNode, add_cur);
                this.blur();
            }
        }
    }
}
//附属点击实现高亮显示---类
function firsttagoff(elemId, tagOff, addtag, add_cur) {
    var ulitem = elemId.getElementsByTagName(addtag.nodeName);
    var tagoffitem = elemId.getElementsByTagName(tagOff);
    for (i = 0; i < tagoffitem.length; i++) {
        tagoffitem[i].firstChild.className = "";
    }
    for (j = 0; j < ulitem.length; j++) {
        if (ulitem[j].innerHTML == addtag.innerHTML) {
            tagoffitem[j].firstChild.className = add_cur;
            break;
        }
    }
}
//加载高亮显示函数
window.onload = function sidemenu() {
    highOnclick("side", "H3", "H2", "menu_cur", "h3_cur");
}
//展开/关闭
function m_id(id) {
    return document.getElementById(id);
}
function getcookie(name) {
    var cookie_start = document.cookie.indexOf(name);
    var cookie_end = document.cookie.indexOf(";", cookie_start);
    return cookie_start == -1 ? '' : unescape(document.cookie.substring(cookie_start + name.length + 1, (cookie_end > cookie_start ? cookie_end : document.cookie.length)));
}
var collapsed = getcookie('m_shutoropen');
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
    $(".contentbody").html("loading");
    var date = new Date();
    var urlnew = url;
    if (url.indexOf("?") > -1)
        urlnew = url + "&t=" + date.getMilliseconds();
    else {
        urlnew = url + "?t=" + date.getMilliseconds();
    }
    $.ajax({
        url: urlnew, success: function (data) {
            $(".contentbody").html(data);
        }
    });
}

function alertWarn(msg) {

}

function closeAlert() {

}