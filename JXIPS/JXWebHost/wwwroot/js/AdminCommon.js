//用于选项卡异步加载数据
function GoToTab(obj, tab, className,savaTabID) {
	if (savaTabID == null || savaTabID == "") {
		savaTabID = "hidTab";
	}
	$("#" + savaTabID).val(tab);
	if (className == null || className == "") {
		className = "current";
	}
	$(obj).addClass(className).siblings().removeClass(className);
	loadTables(0, 10);
}

//删除单条数据(url:为指定的API地址)
function DeleteSingle(id,url,callback) {
	layer.confirm("您确认删除选定的记录吗？", {
		btn: ["确定", "取消"]
	}, function () {
		$.ajax({
			type: "POST",
			url: url,
			data: { "id": id },
			headers: {
				"X-CSRF-TOKEN-JXWebHost": $("input[name='AntiforgeryFieldname']").val()
			},
			error: function (data, status, e) {
				layer.alert('网络超时，删除失败!');
			},
			success: function (data) {
				if (data.result == "ok") {
					layer.alert('删除成功!');
					if (callback != null && typeof callback == "function") {
						callback(0, 10);
					}
				}
				else {
					layer.alert(data.result);
				}
			}
		})
	});
};

//批量删除(url:为指定的API地址)
function DeleteMulti(url, callback) {
	var ids = "";
	$(".checkboxs").each(function () {
		if ($(this).prop("checked") == true) {
			ids += $(this).val() + ","
		}
	});
	ids = ids.substring(0, ids.length - 1);
	if (ids.length == 0) {
		layer.alert("请选择要删除的记录。");
		return;
	};
	//询问框
	layer.confirm("您确认删除选定的记录吗？", {
		btn: ["确定", "取消"]
	}, function () {
		var sendData = { "ids": ids };
		$.ajax({
			type: "Post",
			url: url,
			data: sendData,
			headers: {
				"X-CSRF-TOKEN-JXWebHost": $("input[name='AntiforgeryFieldname']").val()
			},
			error: function (data, status, e) {
				layer.alert('删除失败!');
			},
			success: function (data) {
				if (data.result == "ok") {
					layer.alert('删除成功!');
					if (callback != null && typeof callback == "function") {
						callback(0, 10);
					}
				}
				else {
					layer.alert(data.result);
				}
			}
		});
	});
};

//用于加载角色列表。selectID：显示控件的ID；selectValue：选中的值；isMultiple：控件是否能多选；
function loadRolesAjax(selectID, selectValue, isMultiple) {
	var placeholder = "请选择";
	if (isMultiple) {
		placeholder += "(可以多选)";
	}
	$.ajax({
		type: "GET",
		url: "/Admin/Administrator/GetRoleList?_t=" + new Date().getTime(),
		contentType: "application/x-www-form-urlencoded;charset=UTF-8",
		success: function (data) {
			var option = "";
			$.each(data, function (i, item) {
				option += "<option value='" + item.roleID + "'>" + item.roleName + "</option>";
			});
			$("#" + selectID).select2({ language: "zh-CN", placeholder: placeholder, allowClear: true, multiple: isMultiple });
			$("#" + selectID).html(option);
			$("#" + selectID).val(selectValue.split(',')).trigger("change");
		}
	});
}

//适用于HUI中，从子窗口刷新父页面
function HuiRefresh()
{
	parent.$('#btnRefresh').click();
}