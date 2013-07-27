
(function ($) {

    /*
    * xwAjaxPost form plugin
    * @requires jQuery v1.1 or later
    * post提交时统一处理整合代码
    *pre-need:jquery.form.js && jquery.blockUI.js
    * Revision: wangjun
    * Version: 1.0.0
    */

    /*
    *  buton的类型不要设置为submit。
    *  demo: function updaterole() {
    *    $("#form1").xwAjaxPost(function () {
    * 回调的ajax处理成功后的方法  parent.callback_refresh_diagclose();
    *    });
    *}
    */
    $.fn.xwAjaxPost = function (options) {
        var isValid = $(this).valid();
        if (!isValid) {
            var validator = $(this).validate();
            for (var i = 0; i < validator.errorList.length; i++) {
                var obj = validator.errorList[i];
                $(obj.element).attr("title", obj.message);
            }
            $.unblockUI();
            return this;
        }
        if (typeof options == 'function')
            options = { EndPost: options };

        var defaults = {

        }
        var options = $.extend(defaults, options);
        this.each(function () {
            var suboptions = {
                dataType: 'json',
                beforeSubmit: postBefore,
                success: postSuccess
            };
            $(this).ajaxForm(suboptions);
            $(this).submit();
            return this;
        });
        /*结果为json格式*/
        function postSuccess(responseData, statusText) {
            var result = responseData.Code;
            var message = responseData.Result;
            if (result == undefined) {
                result = 1;
                message = "处理成功！";
            }
            if (typeof options.EndPost == 'function') {
                if ($("body").find("#isok").length == 0) {
                    $("body").append("   <input type='hidden' id='isok' />");
                }
                $("#isok").val("isok");
            }
            $.unblockUI();
            if ($("body").find("#loadingpanel222").length != 0) {
                $("#loadingpanel222").remove();
            }
            if (result == 1) {
                Dialog.alert(message, options.EndPost);
            }
            else {
                Dialog.alert(message);
            }
        }

        function postBefore() {
            if ($("body").find("#loading").length != 0) {
                $.blockUI({ message: $('#loading') });
            }
            else {
                $("body").append(" <div id='loadingpanel222'> <img alt='loading' id='loading' src='/Content/Images/loading.gif')' style='display:none' /></div>");
                $.blockUI({ message: $('#loading') });
            }
        }
        function postError() {
            $.unblockUI();
            Dialog.alert("");
        }

    };
    /*
    * disable form plugin
    * @requires jQuery v1.1 or later
    *disable  设置ture,false
     
    * Revision: wangwei
    * Version: 1.0.0
    */
    /*
    *demo: $(".input_style_E").disable(false);
    *       $(".input_style_E").disable(true);
    */
    $.fn.disable = function (options) {
        if (options == null || options == false) {
            this.each(function () {
                return $(this).removeAttr("disabled");
            });
        }
        else {
            this.each(function () {
                return $(this).attr("disabled", "disabled");
            });
        }
    };
})(jQuery);

 