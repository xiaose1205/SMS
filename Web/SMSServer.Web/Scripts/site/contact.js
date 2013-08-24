var gird;
$(document).ready(function () {
    if ($("#grid") != undefined) {
        gird = $("#grid").flexigrid({
            url: 'ajax/contact/getlist',
            dataType: 'json',
            colModel: [
                { display: 'id', name: 'id', width: 100, align: 'center', hide: false },
                { display: '姓名', name: 'name', width: 100, align: 'center' },
                { display: '手机号码', name: 'phone', width: 150, align: 'center' },
                { display: '性别', name: 'sex', width: 80, align: 'center' },
                { display: '生日', name: 'birthday', width: 100, align: 'center' },
                { display: '备注', name: 'comment', width: 250, align: 'center' },
                { display: '创建时间', name: 'createtime', width: 100, align: 'center' }
            ],
            minColToggle: 1,
            onrowclick: false,
            sortname: "id",
            sortorder: "asc",
            usepager: true,
            useRp: true,
            rp: 15,
            resizable: false,
            width: 'auto',
            height: 'auto',
            autoload: false,
            singleSelect: true,
            specify: true,
            striped: true,
            showcheckbox: true,
            mutliSelect: true,
            showToggleBtn: true
        });
        doQuery();
    }
    function doQuery() {
        var contactQuery = {
            "gid": 0,
            "phone": $("#phone").val(),
            "name": $("#name").val()
        };
        var params = {
            extParam: contactQuery
        };
        if ($('#grid')[0] != undefined) {
            $('#grid')[0].p.newp = 1;
            $('#grid').flexOptions(params).flexReload();
        }
    }
    var setting = {
        view: {
            selectedMulti: false
        },
        async: {
            enable: true,
            url: "ajax/contactgroup/getlist",
            autoParam: ["id", "name=n", "level=lv"],
            dataFilter: filter
        },
        callback: {
            beforeClick: beforeClick,
            beforeAsync: beforeAsync,
            onAsyncError: onAsyncError,
            onAsyncSuccess: onAsyncSuccess,
            beforeRemove: beforeRemove,
            beforeRename: beforeRename,
            onRemove: onRemove,
            onRename: onRename
        }
    };
    var treeN = null;
    function beforeClick(treeId, treeNode) {
        treeN = treeNode;
        var contactQuery = {
            "gid": treeNode.id,
            "phone": $("#phone").val(),
            "name": $("#name").val()
        };
        var params = {
            extParam: contactQuery
        };
        if ($('#grid')[0] != undefined) {
            $('#grid')[0].p.newp = 1;
            $('#grid').flexOptions(params).flexReload();
        }
    }

    function getNodeId() {
        if (treeN == null) {
            return 0;
        } else {
            return treeN.id;
        }

    }

    function beforeRemove(treeId, treeNode) {
        return confirm("确认删除 节点 -- " + treeNode.name + " 吗？");
    }
    function onRename(e, treeId, treeNode) {
        $.post("ajax/contactgroup/update", { id: treeNode.id, name: treeNode.name }, function (data) {

        }, "json");
    }
    function onRemove(e, treeId, treeNode) {
        $.post("ajax/contactgroup/delete", { id: treeNode.id }, function (data) {

        }, "json");
    }
    function beforeRename(treeId, treeNode, newName) {
        if (newName.length == 0) {
            alert("节点名称不能为空.");
            var zTree = $.fn.zTree.getZTreeObj("treeDemo");
            setTimeout(function () { zTree.editName(treeNode); }, 10);
            return false;
        }
        return true;
    }
    function filter(treeId, parentNode, childNodes) {
        if (!childNodes) return null;
        for (var i = 0, l = childNodes.length; i < l; i++) {
            childNodes[i].name = childNodes[i].name.replace(/\.n/g, '.');
        }
        return childNodes;
    }

    var log, className = "dark";
    function beforeAsync(treeId, treeNode) {
        className = (className === "dark" ? "" : "dark");
        return true;
    }
    function onAsyncError(event, treeId, treeNode, XMLHttpRequest, textStatus, errorThrown) {
    }
    function onAsyncSuccess(event, treeId, treeNode, msg) {
        if (msg.length < 5) {
            treeNode.isParent = false;
            treeNode.isLastNode = true;
        }
    }

    $.fn.zTree.init($("#treeDemo"), setting);

    $("#addgroup").bind("click", { isParent: false }, add);
    function add(e) {
        var zTree = $.fn.zTree.getZTreeObj("treeDemo"),
			isParent = e.data.isParent,
			nodes = zTree.getSelectedNodes(),
			treeNode = nodes[0];
        $.post("ajax/contactgroup/add", { pid: treeNode ? treeNode.id : 0, name: "新联系人分组" }, function (data) {
            if (data.Result == 1) {
                if (treeNode) {
                    treeNode = zTree.addNodes(treeNode, { id: data.Message, pId: treeNode.id, isParent: isParent, name: "新联系人分组" });
                } else {
                    treeNode = zTree.addNodes(null, { id: Message, pId: 0, isParent: isParent, name: "新联系人分组" });
                }
            }
        }, "json");
        if (treeNode) {
            zTree.editName(treeNode[0]);
        } else {
            alert("无法增加子分组");
        }
    };
    $("#updategroup").click(function () {
        var zTree = $.fn.zTree.getZTreeObj("treeDemo"),
			nodes = zTree.getSelectedNodes(),
			treeNode = nodes[0];
        if (nodes.length == 0) {
            alert("请先选择一个节点");
            return;
        }
        zTree.editName(treeNode);
    });
    $("#delgroup").click(function () {
        var zTree = $.fn.zTree.getZTreeObj("treeDemo"),
			nodes = zTree.getSelectedNodes(),
			treeNode = nodes[0];
        if (nodes.length == 0) {
            alert("请先选择一个节点");
            return;
        }

        zTree.removeNode(treeNode, true);
    });
    $("#add").click(function () {
        var id = getNodeId();
        if (id == 0)
            alert("请先选择一个分组");
        else
            $.AddAction(450, 310, '添加联系人', "info/addcontact.aspx?gid="+id, doQuery);;

    });
    $("#edit").click(function () {
        $.AddAction(450, 310, '修改联系人', "info/editcontact.aspx", doQuery);;

    });
    $("#delete").click(function () {
        $.DeleteAction("contact", doQuery, "是否确认删除所选的数据？");

    });
    $("#clear").click(function () {

    });
    $("#search").click(function () {
        doQuery();
    });
    $("#inport").click(function () {

    });
});

function add() {
    if ($.trim($("#name").val()) == "") {
        $.showError("姓名不能为空");
        return;
    }
    if ($.trim($("#phone").val()) == "") {
        $.showError("手机号码不能为空");
        return;
    }

    /*下面这段代码会自动处理提交信息，并执行返回后的function*/
    $.childAction(function () {
        var api = art.dialog.open.api;
        api && api.close();
    });
}
function edit() {
    if ($.trim($(".phone").val()) == "") {
        $.showError("手机号码不能为空");
        return;
    }
    $("input[name='id']").val($(".blackid").val());
    $("input[name='phone']").val($(".phone").val());
    /*下面这段代码会自动处理提交信息，并执行返回后的function*/
    $.childAction(function () {
        var api = art.dialog.open.api;
        api && api.close();
    });
}