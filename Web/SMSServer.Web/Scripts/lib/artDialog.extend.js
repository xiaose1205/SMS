$(document).ready(function () {
    $("#actions").hide();
    var api = art.dialog.open.api;
    var buttons = [];
    var index = 0;
    $("#actions").find("button").each(function () {
        var btnmo = {};
        if ($(this).attr("onclick") != undefined) {
            var event = $(this).attr("onclick");
            api.config.button.push({
                name: $(this).text(),
                callback: function () {
                    new Function(event)();
                    return false;
                },
                focus: index == 0
            });
        } else {
            api.config.button.push({
                name: $(this).text(),
                focus: index == 0
            });
        }
        index++;
    });
    $("#actions").find("input[type='button'],input[type='submit']").each(function () {
        var btnmo = {};
        if ($(this).attr("onclick") != undefined) {
            var event = $(this).attr("onclick");
            api.config.button.push({
                name: $(this).val(),
                callback: function () {
                    new Function(event)();
                    return false;
                },
                focus: index == 0
            });
        } else {
            api.config.button.push({
                name: $(this).val(),
                focus: index == 0
            });
        }
        index++;
    });
    api.button(api.config.button);



});
