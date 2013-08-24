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
    function beforeClick(treeId, treeNode) {

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
});


