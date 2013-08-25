<%@ Page Language="C#" MasterPageFile="~/Master/ChildSite.Master" AutoEventWireup="true" CodeBehind="Upload.aspx.cs" Inherits="SMSServer.Web.Master.Upload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ScriptHolder" runat="server">

    <script src="../Scripts/lib/jquery.fineuploader-3.6.4.min.js"></script>
    <link href="../Styles/fineuploader.css" rel="stylesheet" />
    <script>
        var uploadarr = art.dialog.data("uploadarr");
        var ajaxhandle = art.dialog.data("ajaxhande");
        var otherparm = (art.dialog.data("otherparm") == undefined || art.dialog.data("otherparm") == null) ? "" : art.dialog.data("otherparm");
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
                            $("#filename").html(data.filename);
                            filename = data.filename;
                            var showindex = 0;
                            $(".control_select").empty();
                            $(".control_select").each(function () {
                                var selected = 0;
                                var ischoose = false;
                                for (var i = 0; i < ftitle.length; i++) {

                                    $(this).append("<option value=" + i + ">" + $.trim(ftitle[i]) + "</option>");

                                    if (showindex == i) {
                                        selected = i;
                                        if (fvalue[i] != undefined) {
                                            ischoose = true;
                                            $("span[for='" + $(this).attr("id") + "']").html($.trim(fvalue[i]));
                                        }
                                    }

                                    if ($.trim(ftitle[i]) != "" && $("#lb_" + $(this).attr("dataid") + "").html().indexOf($.trim(ftitle[i])) != -1) {
                                        selected = i;
                                        if (fvalue[i] != undefined) {
                                            ischoose = true;
                                            $("span[for='" + $(this).attr("id") + "']").html($.trim(fvalue[i]));
                                        }
                                    }

                                }
                                if (!ischoose) {
                                    $("span[for='" + $(this).attr("id") + "']").html($.trim(fvalue[selected]));
                                }
                                $(this).get(0).selectedIndex = selected;
                                showindex++;
                            });
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
                debugger;
                spilter = $(this).val();
            });
            $("#mysplter").change(function () {
                spilter = $(this).val();
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <form id="form1" runat="server" class="form-horizontal">
        <div class="z-legend ">
            <strong>上传文件</strong>   <span style="margin-left: 5px; margin-right: 15px;"><i class="icon-info-sign"></i>请上传excel或txt(英文,间隔)文件</span>
            <span id="filename" style="border-bottom-color: cadetblue; border-bottom-style: solid; border-bottom-width: 1px; display: none;">......</span>

        </div>
        <div style="margin-left: 20px;">
            <a id="fileupload" class="btn btn-link"></a><a href="#" id="inport" class="btn btn-link">上传</a>

            <div class="form-inline">
                <label class="checkbox" style="margin-right: 10px;">
                    <input type="checkbox" id="isheader" checked="checked">
                    是否包含列头
                </label>


                <label>
                    <i class="icon-th-large"></i>分隔符:  
                    <input type="radio" name="splter" value="|" checked="checked" style="margin-right: 5px; margin-left: 5px;">|
                      <input type="radio" name="splter" style="margin-right: 5px; margin-left: 5px;" value="tap">tap
                      <input type="radio" name="splter" style="margin-right: 5px; margin-left: 5px;" value="blank">空格
                     <input type="radio" name="splter" style="margin-right: 5px; margin-left: 5px;">
                    <input type="text" value="" style="width: 50px; height: 16px; line-height: 16px;" class="input-small" id="mysplter" />
                </label>



            </div>
        </div>
        <div id="uploadpanel" style="border: 1px solid #CCCCCC; height: 150px; margin-top: 10px; overflow-y: scroll;">
        </div>
        <div class="autool_buttons" id="actions">
            <input type="button" value="确认" onclick="doupload();" class="button" />
            <input type="button" value="取消" class="button" />
        </div>
    </form>
</asp:Content>
