<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MainSite.Master" AutoEventWireup="true" CodeBehind="FileSend.aspx.cs" Inherits="SMSServer.Web.Sms.FileSend" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ScriptHolder" runat="server">
    <link href="../Styles/smssend.css" rel="stylesheet" />
    <script src="../Scripts/lib/jquery.fineuploader-3.6.4.min.js"></script>
    <link href="../Styles/fineuploader.css" rel="stylesheet" />

    <script>
        var uploadarr = "";
        var ajaxhandle = "";
        var otherparm = "";
        var filename;
        var ftitle;
        var fvalue;
        $(document).ready(function () {
            $("#uploadpanel").append("<div style='height:5px;'></div>");
            for (var i = 0; i < uploadarr.length; i++) {
                var html = '<div class="control-group" >';
                html += '  <label class="control-label" for="up_' + i + '" id="lb_' + i + '">' + uploadarr[i] + '</label>';
                html += '  <div class="controls"><select style="width:120px;"  dataid="' + i + '"  id="up_' + i + '" name="up_' + i + '" class="control_select"/></select> 预览：<span for="up_' + i + '">...</span></div>';
                html += "</div>";
                $("#uploadpanel").append(html);
            }
            $("select").change(function () {
                if (fvalue[$(this).get(0).selectedIndex] != undefined)
                    $("span[for='up_" + $(this).attr("dataid") + "']").html(fvalue[$(this).get(0).selectedIndex]);
                else
                    $("span[for='up_" + $(this).attr("dataid") + "']").html("");
            });
            var isheader = 1;
            var spilter = "|";
            var manualuploader = new qq.FineUploader({
                element: $('#fileupload')[0],
                request: {
                    endpoint: requestendpoint()// '../Master/AjaxFile.ashx?header=' + isheader + '&spilter=' + spilter
                },
                multiple: false,
                validation: {
                    allowedExtensions: ['xls', 'txt'],
                    sizeLimit: 512000000 // 5000 kB = 50 * 1024 bytes
                }, autoUpload: false,
                text: {
                    uploadButton: '<i class="icon-upload"></i>选择文件'
                },
                callbacks: {
                    onComplete: function (id, fileName, data) {
                        if (data.success) {
                            var arrar = data.message;
                            if (arrar[0] == null || arrar[1] == null) {

                                $.showError("导入的文件不合法，无法找到列名"); return false;
                            }
                            ftitle = arrar[0].split(',');
                            fvalue = arrar[1].split(',');
                            if (ftitle.length == 0) {
                                $.showError("导入的文件不合法，无法找到列名"); return false;
                            }
                            var html = "";
                            for (var i = 0; i < ftitle.length; i++) {
                                html += "  <a class='smstag'>" + ftitle[i] + "</a>";
                            }
                            $("#msgtag").html(html);
                            $("#filename").html(data.filename);
                            filename = data.filename;

                        }
                    }
                }
            });

            function requestendpoint() {
                return '../Master/AjaxFile.ashx?header=' + isheader + '&spilter=' + spilter;

            }

            $('#inport').click(function () {
                manualuploader.setEndpoint(requestendpoint(), null);
                manualuploader.uploadStoredFiles();
            });
            $("#isheader").click(function () {
                isheader = $("#isheader").attr("checked") == "checked" ? 1 : 0;
            });
            $("input[name='splter']").click(function () {
                spilter = $(this).val();
            });
            $("#mysplter").change(function () {
                spilter = $(this).val();
            });
            $("#sendcontent").bind('textchange', function () {
                var value = $(this).val();
                $("#lblWordNum").html(value.length);
            });
            $("#sendcontent").change(function () {
                var value = $(this).val();
                $("#lblWordNum").html(value.length);
            });
            $(".smstag").live("click", function () {
                $("#sendcontent").val($("#sendcontent").val() + "@" + $(this).html());
                $("#lblWordNum").html($("#sendcontent").val().length);
                return false;
            });
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
                if ($("#filename").html() == "") {
                    $.showError("请先上传文件");
                    return;
                }
                if ($.trim($("#sendcontent").val()) == "") {
                    $.showError("短信内容不能为空");
                    return;
                }
                if ($.trim($("#txtName").val()) == "") {
                    $.showError("批次名称不能为空");
                    return;
                }

                $.post("ajax/sms/filesend", {
                    content: $("#sendcontent").val(),
                    filename: filename, batchname: $("#txtName").val(),
                    batchremark: $("#txtRemark").val(), isheader: isheader, isspilter: spilter
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

        function doupload() {

            if (filename == undefined) {
                $.showError("请先导入文件");
                return;
            }
            var arr = "";
            $(".control_select").each(function () {
                arr += $(this).val() + "|";
            });

            $.showError("正在导入中...");

            $.post("../ajax/" + ajaxhandle + "/upload" + otherparm, { filearr: arr, filename: filename }, function (data) {

                if (data.Result == 1) {
                    $.showSuccess("导入成功...");
                    art.dialog.data('bValue', "ok");
                    var api = art.dialog.open.api;
                    api && api.close();
                } else {
                    $.showError(data.Message);
                    art.dialog.data('bValue', "");
                }

            }, "json");
        }
    </script>
    <style>
        .form-inline {
            clear: both;
        }

        .form-inline input,
        .form-inline textarea,
        .form-inline select,
        .form-inline .help-inline,
        .form-inline .uneditable-input,
        .form-inline .input-append {
            display: inline-block;
            *display: inline;
            margin-bottom: 0;
            vertical-align: middle;
            *zoom: 1;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="sendpanel">

        <div style="height: 150px;" class="  formPanel">
            <div class="z-legend ">
                <h4>上传文件 <span style="margin-left: 5px; margin-right: 15px; font-size: 12px; font-weight: normal;"><i class="icon-info-sign"></i>请上传excel或txt(英文,间隔)文件</span>
                    <span id="filename" style="border-bottom-color: cadetblue; border-bottom-style: solid; border-bottom-width: 1px; display: none;">......</span>
                </h4>
            </div>
            <div style="margin-left: 20px; margin-top: 10px;">

                <div class="form-inline" style="margin-bottom: 10px;">
                    <label class="checkbox" style="margin-right: 10px;">
                        <input type="checkbox" id="isheader" checked="checked">
                        是否包含列头
                    </label>

                    <i class="icon-th-large"></i>分隔符:  
                  <label>
                      <input type="radio" name="splter" value="|" checked="checked" style="margin-right: 5px; margin-left: 5px;">|
                  </label>
                    <label>
                        <input type="radio" name="splter" style="margin-right: 5px; margin-left: 5px;" value="tap">tap
                    </label>
                    <label>
                        <input type="radio" name="splter" style="margin-right: 5px; margin-left: 5px;" value="blank">空格
                    </label>
                    <label>
                        <input type="radio" name="splter" style="margin-right: 5px; margin-left: 5px;">
                    </label>
                    <label>
                        <input type="text" value="" style="width: 50px; height: 16px; line-height: 16px;" class="input-small" id="mysplter" />
                    </label>

                </div>
                <div>
                    <a id="fileupload" class="btn btn-link"></a>
                    <a href="#" id="inport" class="button button-rounded button-tiny   button-action" style="margin-left: 10px;">点击上传</a>
                    <i class="icon-info-sign"></i><span style="margin-top: 14px;">第一列必须为手机号码</span>
                </div>
            </div>
        </div>
        <div class="  formPanel">
            <h4>编辑短信信息</h4>

            <div style="padding-bottom: 5px; padding-top: 5px">
                <div style="margin-bottom: 5px;">
                    批次名称：
                    <input class="text" maxlength="50" style="width: 60%; min-width: 330px;" id="txtName" /><span class="red">*</span>
                </div>
                <div>
                    批次备注：
                    <input class="text" maxlength="50" style="width: 60%; min-width: 330px;" id="txtRemark" />
                </div>
            </div>
            <div style="margin: 5px;">
                <input class="button button-rounded button-tiny button-primary" id="btnPreview" type="button" value="内容预览" />
                <input class="button button-rounded button-tiny button-primary" id="btnSelect" type="button" value="选择短语" />
                <input class="button button-rounded button-tiny button-primary" id="btnSave" type="button" value="保存短语" />
                <input class="txt" style="margin-right: 2px" id="IsFilterKey" type="checkbox" value="1"
                    checked="checked" /><a id="aFilterKey" style="cursor: hand">过滤关键字</a>
                <input class="txt" style="margin-right: 2px" id="IsFilterBlack" type="checkbox" value="1"
                    checked="checked" /><a id="aFilterBlack" style="cursor: hand">过滤黑名单</a>
                <input class="txt" style="margin-right: 2px" id="cbxNoAgain" type="checkbox" value="1"
                    checked="checked" /><a id="aNoAgain" style="cursor: hand">过滤重复号码</a>
            </div>

            <textarea style="width: 95%; height: 70px;" id="sendcontent"></textarea>
            <div id="msgtag">
            </div>
            <div style="margin: 5px;">
                含签名共&nbsp;<label class="red" id="lblWordNum">
                    0</label>&nbsp;个字。[移动、联通、电信分&nbsp;<label class="red" id="lblGroupNum">
                        0
                    </label>
                &nbsp; 段，每条&nbsp;<label class="red" id="lblWord">
                    70</label>&nbsp; 个字]
            
               <input class="button button-rounded button-tiny button-primary" id="btnSend" type="button" value="发送短信" />
            </div>
            <div style="color: #999">
                * 批次是用来描述一批短信,每次发送信息都作为一个批次,无论发送信息的数量为多少。
                        <br />
                * 批次名称和批次备注将会便于您的后期查询。
            </div>

        </div>

    </div>
</asp:Content>
