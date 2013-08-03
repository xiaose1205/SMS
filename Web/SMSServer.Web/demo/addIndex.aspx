<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MainSite.Master" AutoEventWireup="true" CodeBehind="addIndex.aspx.cs" Inherits="SMSServer.Web.demo.addIndex" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ScriptHolder" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

 
    <script src="../Scripts/lib/jquery.form.js"></script>
    <script src="../Scripts/lib/jquery.blockUI.js"></script>
    <script src="../Scripts/lib/jquery.common.js"></script>
    <script src="../Scripts/lib/jquery.actions.js"></script> 
      <script src="../Scripts/site/demo.js"></script>
    <div class="form">
        <div class="title">
            <h3>表单</h3>
        </div>
        <div class="body">
            <div class="formPanel">

                <h4>基本资料</h4>
                <form class="form-horizontal">
                    <ul class="form">
                        <li>
                            <label>文章标题：</label>
                            <input type="text" class="text" name="UserName" />
                        </li>
                        <li>
                            <label>文章标题：</label>
                            <input type="text" class="text" />
                        </li>
                        <li>
                            <label>文章标题：</label>
                            <input type="checkbox" class="checkbox" />
                        </li>
                        <li>
                            <div>
                                <label>所属类别：</label>
                                <select id="article_CategoryId" name="article.CategoryId">
                                    <option value="">== 请选择所属类别 ==</option>
                                    <option value="49">牛仔裤种类</option>
                                    <option value="11">服装海报</option>
                                    <option value="10">电子时尚杂志</option>
                                    <option value="7">牛仔裤美女</option>
                                    <option value="72">│　├─清纯美女</option>
                                    <option value="43">│　├─美女明星</option>
                                    <option value="16">│　├─性感美女</option>
                                    <option value="8">│　└─时尚美女</option>
                                </select>
                            </div>
                            <div>
                                <label>发布状态：</label>
                                <select id="article_Published" name="article.Published">
                                    <option selected="selected" value="0">未发布</option>
                                    <option value="1">已发布</option>
                                </select>
                            </div>
                        </li>

                        <li>
                            <div>
                                <label>
                                    推荐：
                                </label>
                                <input type="checkbox" id="article_Recommend" name="article.Recommend" value="true" class="checkbox" /><input type="hidden" id="article_RecommendH" name="article.Recommend" value="false" />
                            </div>
                            <div>
                                <label>
                                    头条：
                                </label>
                                <input type="checkbox" id="article_IsTop" name="article.IsTop" value="true" class="checkbox" /><input type="hidden" id="article_IsTopH" name="article.IsTop" value="false" />
                            </div>
                            <div>
                                <label>排序数：</label>
                                <input type="text" id="article_DisplayOrder" name="article.DisplayOrder" value="0" style="width: 60px;" />
                            </div>
                        </li>

                        <li>
                            <label>文章标题：</label>
                            <input type="text" class="text" />
                        </li>
                        <li>
                            <label>文章摘要：</label>
                            <textarea id="article_Description" name="article.Description" style="width: 60%; height: 80px;"></textarea>
                        </li>
                        <li>
                            <label>文章标题：</label>
                            <input type="text" class="text" />
                        </li>
                        <li>
                            <label>文章标题：</label>
                            <input type="text" class="text" />
                        </li>
                    </ul>
                    <div class="but_tools">
                        <div>
                            <input type="button" value="提 交" class="button button-rounded button-tiny button-primary" onclick="addindex()" />
                            <input type="reset" class="button button-rounded button-tiny button-primary" name="重 置" value="重 置" />
                        </div>
                    </div>
                </form>
            </div>

        </div>
    </div>

</asp:Content>
