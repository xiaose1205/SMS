<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MainSite.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SMSServer.Web.demo.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ScriptHolder" runat="server">
    <script type="text/javascript">
        $(function () {
            $('.flexme2').flexigrid({
                title: 'Countries',
                usepager: true,
                singleSelect: true,
                resizable: false,
                height: '100%'
            });
            $("#add").click(function () {
                $.AddAction(500, 180, '添加用户', "demo/add.aspx", function() {
                });;
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <a id="add" href="#">添加测试</a>
    <table class="flexme2">
        <thead>
            <tr>
                <th width="100">名adsssssssss称 1</th>
                <th width="100">名称 2</th>
                <th width="100">asddddddd名称 3 is a long header name</th>
                <th width="300">名称 4</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>This is data 1 with overflowing content</td>
                <td>This is data 2</td>
                <td>This is data 3</td>
                <td>This is data 4</td>
            </tr>
            <tr>
                <td>This is data 1</td>
                <td>This is data 2</td>
                <td>This is data 3</td>
                <td>This is data 4</td>
            </tr>
            <tr>
                <td>This is data 1</td>
                <td>This is data 2</td>
                <td>This is data 3</td>
                <td>This is data 4</td>
            </tr>
            <tr>
                <td>This is data 1</td>
                <td>This is data 2</td>
                <td>This is data 3</td>
                <td>This is data 4</td>
            </tr>
            <tr>
                <td>This is data 1</td>
                <td>This is data 2</td>
                <td>This is data 3</td>
                <td>This is data 4</td>
            </tr>
            <tr>
                <td>This is data 1</td>
                <td>This is data 2</td>
                <td>This is data 3</td>
                <td>This is data 4</td>
            </tr>
        </tbody>
    </table>


</asp:Content>
