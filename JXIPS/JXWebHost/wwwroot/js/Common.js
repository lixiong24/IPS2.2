﻿// 对Date的扩展，将 Date 转化为指定格式的String
// 月(M)、日(d)、小时(h)、分(m)、秒(s)、季度(q) 可以用 1-2 个占位符， 
// 年(y)可以用 1-4 个占位符，毫秒(S)只能用 1 个占位符(是 1-3 位的数字) 
// 例子： 
// (new Date()).Format("yyyy-MM-dd hh:mm:ss.S") ==> 2006-07-02 08:09:04.423 
// (new Date()).Format("yyyy-M-d h:m:s.S")      ==> 2006-7-2 8:9:4.18 
Date.prototype.Format = function (fmt) { 
	var o = {
		"M+": this.getMonth() + 1, //月份 
		"d+": this.getDate(), //日 
		"h+": this.getHours(), //小时 
		"m+": this.getMinutes(), //分 
		"s+": this.getSeconds(), //秒 
		"q+": Math.floor((this.getMonth() + 3) / 3), //季度 
		"S": this.getMilliseconds() //毫秒 
	};
	if (/(y+)/.test(fmt)) fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
	for (var k in o)
		if (new RegExp("(" + k + ")").test(fmt)) fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
	return fmt;
}
//把字符串转换成日期格式。示例：formatDateTime(strDate,"yyyy-MM-dd hh:mm:ss")
function formatDateTime(inputTime,fmt) {
	var date = new Date(inputTime);
	if (fmt == null || fmt == "")
		fmt = "yyyy-MM-dd hh:mm:ss";
	return date.Format(fmt);
}

function GetID(id) {
	return document.getElementById(id);
}

/* 过滤HTML符号 */
function RemoveHtml(instr) {
	var d = document.createElement("DIV");
	d.innerHTML = instr;
	d.id = "tempremovehtmlcontent";
	d.style.display = "none";
	return d.innerText;
}

//加入收藏
function AddFavorite(sURL, sTitle) {
	try {
		if (window.sidebar) // Firefox
		{
			window.sidebar.addPanel(sTitle, sURL, "");
		}
		else if (window.opera && window.print) // Opera
		{
			var elem = document.createElement('a');
			elem.setAttribute('href', sURL);
			elem.setAttribute('title', sTitle);
			elem.setAttribute('rel', 'sidebar'); // required to work in opera 7+
			elem.click();
		}
		else if (document.all) // IE
		{
			try {
				window.external.AddFavorite(sURL, sTitle);
			}
			catch (e) {
				window.external.addToFavoritesBar(sURL, sTitle);  //IE8
			}
		}
		else {
			alert("由于浏览器的限制，请使用Ctrl+D手动收藏！");
		}
	}
	catch (e) {
		alert("由于浏览器的限制，请使用Ctrl+D手动收藏！");
	}
}
//设为首页
function SetHome(vrl) {
	if (document.all) {
		document.body.style.behavior = 'url(#default#homepage)';
		document.body.setHomePage(vrl);
	} else if (window.sidebar) {
		if (window.netscape) {
			try {
				netscape.security.PrivilegeManager.enablePrivilege("UniversalXPConnect");
			} catch (e) {
				alert("该操作被浏览器拒绝，如果想启用该功能，请在地址栏内输入 about:config,然后将项 signed.applets.codebase_principal_support 值该为true");
			}
		}
		var prefs = Components.classes['@mozilla.org/preferences-service;1'].getService(Components.interfaces.nsIPrefBranch);
		prefs.setCharPref('browser.startup.homepage', vrl);
	}
}

//得到随机数
function RandomNum(n) {
	var rnd = '';
	for (var i = 0; i < n; i++)
		rnd += Math.floor(Math.random() * 10);
	return rnd;
}

//刷新验证码
function RefreshValdisplayDateCodeImage(ValdisplayDateCodeImageControl) {
	ValdisplayDateCodeImageControl.src = ValdisplayDateCodeImageControl.src + '?code=' + RandomNum(10);
}

//用于回车后产生按纽点击事件
//使用方式：onkeypress="javascript:return DefaultButton(event, 'BtnLogOnAjax')"
function DefaultButton(event, linkOpenType) {
	if (event.keyCode == 13 && !(event.srcElement && (event.srcElement.tagName.toLowerCase() == "textarea"))) {
		var defaultButton = GetID(linkOpenType);
		if (defaultButton && typeof (defaultButton.click) != "undefined") {
			defaultButton.click();
			event.cancelBubble = true;
			if (event.stopPropagation)
				event.stopPropagation();
			return false;
		}
	}
	return true;
}

//获取url中的参数
//name：参数名称；decodeType：参数值解码方式；
function getUrlParam(name, decodeType) {
	var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
	var r = window.location.search.substr(1).match(reg);  //匹配目标参数
	if (r != null) {
		switch (decodeType) {
			case 0:
				return unescape(r[2]);
			case 1:
				return decodeURI(r[2]);
			case 2:
				return decodeURIComponent(r[2]);
			default:
				return unescape(r[2]);
		}
	}
	return null;
}

//iframe自动适应页面高度
//IFrameIDs：用逗号分隔的iframe的ID
function dynIFrameSize(IFrameIDs) {
	var arrIFrameIDs = IFrameIDs.split(",");
	for (i = 0; i < arrIFrameIDs.length; i++) {
		if (document.getElementById) {
			var dyniframe = document.getElementById(arrIFrameIDs[i]);
			if (dyniframe && !window.opera) {
				dyniframe.style.display = "block";
				//如果用户的浏览器是NetScape
				if (dyniframe.contentDocument && dyniframe.contentDocument.body.offsetHeight) {
					if (dyniframe.contentDocument.body.offsetHeight <= 450) {
						dyniframe.style.height = 450 + "px";
					} else {
						dyniframe.style.height = (dyniframe.contentDocument.body.offsetHeight + 5) + "px";
					}
				}
				else if (dyniframe.Document && dyniframe.Document.body) //如果用户的浏览器是IE
				{
					if (dyniframe.Document.body.scrollHeight) {
						if (dyniframe.Document.body.scrollHeight <= 450) {
							dyniframe.style.height = 450;
						} else {
							dyniframe.style.height = dyniframe.Document.body.scrollHeight + 5;
						}
					}
				}
			}
		}
	}
}

//绑定国家 country：选中的国家；PrefixID：被绑定控件ID的前缀；
function DataBindCountry(country, PrefixID) {
	var Action = "Country";
	var url = '/Common/Region';
	$.ajax({
		type: "POST",
		url: url,
		data: { "Action": Action, "Country": country },
		async: true,
		headers: {
			"X-CSRF-TOKEN-JXWebHost": $("input[name='AntiforgeryFieldname']").val()
		},
		error: function (data, status, e) {
			layer.alert('网络超时，发送失败!');
		},
		success: function (returnData) {
			if (returnData.status == "1") {
				var objID = PrefixID + "Country";
				$("#" + objID).empty();
				$("#" + objID).append(returnData.data);
			}
			else {
				layer.alert(returnData.msg);
			}
		}
	});
}
//绑定省份 country：选中的国家；province：选中的省份；PrefixID：被绑定控件ID的前缀；
function DataBindProvince(country, province, PrefixID) {
	var Action = "Province";
	var url = '/Common/Region';
	$.ajax({
		type: "POST",
		url: url,
		data: { "Action": Action, "Country": country, "Province": province },
		async: true,
		headers: {
			"X-CSRF-TOKEN-JXWebHost": $("input[name='AntiforgeryFieldname']").val()
		},
		error: function (data, status, e) {
			layer.alert('网络超时，发送失败!');
		},
		success: function (returnData) {
			if (returnData.status == "1") {
				var objID = PrefixID + "Province";
				$("#" + objID).empty();
				$("#" + objID).append(returnData.data);
			}
			else {
				layer.alert(returnData.msg);
			}
		}
	});
}
//绑定城市 province：选中的省份；city：选中的城市；PrefixID：被绑定控件ID的前缀；
function DataBindCity(province, city, PrefixID) {
	var Action = "City";
	var url = '/Common/Region';
	$.ajax({
		type: "POST",
		url: url,
		data: { "Action": Action, "Province": province, "City": city },
		async: true,
		headers: {
			"X-CSRF-TOKEN-JXWebHost": $("input[name='AntiforgeryFieldname']").val()
		},
		error: function (data, status, e) {
			layer.alert('网络超时，发送失败!');
		},
		success: function (returnData) {
			if (returnData.status == "1") {
				var objID = PrefixID + "City";
				$("#" + objID).empty();
				$("#" + objID).append(returnData.data);
			}
			else {
				layer.alert(returnData.msg);
			}
		}
	});
}
//绑定区县 city：选中的城市；area：选中的区县；PrefixID：被绑定控件ID的前缀；
function DataBindArea(city, area, PrefixID) {
	var Action = "Area";
	var url = '/Common/Region';
	$.ajax({
		type: "POST",
		url: url,
		data: { "Action": Action, "City": city, "Area": area },
		async: true,
		headers: {
			"X-CSRF-TOKEN-JXWebHost": $("input[name='AntiforgeryFieldname']").val()
		},
		error: function (data, status, e) {
			layer.alert('网络超时，发送失败!');
		},
		success: function (returnData) {
			if (returnData.status == "1") {
				var objID = PrefixID + "Area";
				$("#" + objID).empty();
				$("#" + objID).append(returnData.data);
			}
			else {
				layer.alert(returnData.msg);
			}
		}
	});
}
function SelectProvince(PrefixID) {
	var province = $("#" + PrefixID +"Province").val();
	var city = $("#" + PrefixID +"City").val();
	DataBindCity(province, "", PrefixID);
	DataBindArea(city, "", PrefixID);
}
function SelectCity(PrefixID) {
	var city = $("#" + PrefixID + "City").val();
	DataBindArea(city, "", PrefixID);
}
//初始化区域控件
//province：选中的省份；city：选中的城市；area：选中的区县；PrefixID：被绑定控件ID的前缀；
function InitRegion(province, city, area, PrefixID) {
	DataBindProvince("中华人民共和国", province, PrefixID);
	DataBindCity(province, city, PrefixID);
	DataBindArea(city, area, PrefixID);
}

function IsWeiXin() {
	var ua = navigator.userAgent.toLowerCase();
	if (ua.match(/MicroMessenger/i) == "micromessenger") {
		return true;
	} else {
		return false;
	}
}
function ShowWeiXinTip() {
	var isWeixin = IsWeiXin();
	if (isWeixin) {
		var winHeight = typeof window.innerHeight != 'undefined' ? window.innerHeight : document.documentElement.clientHeight;
		var weixinTip = $('<div id="weixinTip"><p><img src="/Images/live_weixin.png" alt="微信打开" width="100%" /></p></div>');
		$("body").append(weixinTip);
		$("#weixinTip").css({
			"position": "fixed",
			"left": "0",
			"top": "0",
			"height": winHeight,
			"width": "100%",
			"z-index": "1000",
			"background-color": "rgba(0,0,0,0.8)",
			"filter": "alpha(opacity=80)",
		});
		$("#weixinTip p").css({
			"text-align": "center",
			"margin-top": "10%",
			"padding-left": "5%",
			"padding-right": "5%"
		});
	}
}

function layer_showFull(title, url) {
	if (title == null || title == '') {
		title = false;
	};
	if (url == null || url == '') {
		url = "404.html";
	};
	var w = 800;
	var h = ($(window).height() - 50);
	var index = layer.open({
		type: 2,
		area: [w + 'px', h + 'px'],
		fix: false, //不固定
		maxmin: true,
		shade: 0.4,
		title: title,
		content: url
	});
	layer.full(index);
}

//通过腾讯发送验证码
var valSendCodeSMSID = "TencentCaptcha";
var valMobileID = "txtMobile";
var valImgCodeID = "txtImgCode";
var valCodeSMSTimer = parseInt(0);
function valCodeSMSCountdown() {
	if (valCodeSMSTimer == 0) {
		jQuery("#" + valSendCodeSMSID).html("获取验证码");
		jQuery("#" + valSendCodeSMSID).val("获取验证码");
		jQuery("#" + valSendCodeSMSID).removeAttr("disabled");
	} else {
		valCodeSMSTimer--;
		jQuery("#" + valSendCodeSMSID).html(valCodeSMSTimer + "秒后重发");
		jQuery("#" + valSendCodeSMSID).val(valCodeSMSTimer + "秒后重发");
		setTimeout("valCodeSMSCountdown()", 1000);
	}
}
function valCodeSMSSendCodeSMS(res) {
	// res（用户主动关闭验证码）= {ret: 2, ticket: null}
	// res（验证成功） = {ret: 0, ticket: "String", randstr: "String"}
	if (res.ret === 0) {
		if (valCodeSMSTimer != 0) {
			return false;
		}
		var mobile = jQuery("#" + valMobileID).val();
		if (mobile == null || mobile == '') {
			layer.alert('手机号码不能为空!');
			return false;
		}
		var ticket = res.ticket;
		var randstr = res.randstr;
		var url = '/Common/SendCodeSMS';
		$.ajax({
			type: "POST",
			url: url,
			data: { "mobile": mobile, "ticket": ticket, "randstr": randstr },
			headers: {
				"X-CSRF-TOKEN-JXWebHost": $("input[name='AntiforgeryFieldname']").val()
			},
			error: function (data, status, e) {
				layer.alert('网络超时，发送失败!');
			},
			success: function (returnData) {
				if (returnData.status == "1") {
					valCodeSMSTimer = parseInt(90);
					$("#" + valSendCodeSMSID).html(valCodeSMSTimer + "秒后重发");
					$("#" + valSendCodeSMSID).val(valCodeSMSTimer + "秒后重发");
					$("#" + valSendCodeSMSID).attr({ "disabled": "disabled" });
					valCodeSMSCountdown();
				}
				else {
					layer.alert(returnData.msg);
				}
			}
		});
	}
	else {
		layer.alert("验证失败");
		return false;
	}
}

//发送邮件
//mailToAddressID：收件人地址控件ID；subjectID：邮件标题控件ID；mailBodyID：邮件内容控件ID；
function SendMail(mailToAddressID, subjectID, mailBodyID) {
	var mailToAddress = jQuery("#" + mailToAddressID).val();
	if (mailToAddress == null || mailToAddress == '') {
		layer.alert('收件人邮箱不能为空!');
		return false;
	}
	var subject = jQuery("#" + subjectID).val();
	if (subject == null || subject == '') {
		layer.alert('邮件标题不能为空!');
		return false;
	}
	var mailBody = jQuery("#" + mailBodyID).val();
	if (mailBody == null || mailBody == '') {
		layer.alert('邮件内容不能为空!');
		return false;
	}
	var url = '/Common/SendMail';
	$.ajax({
		type: "POST",
		url: url,
		data: { "mailToAddress": mailToAddress, "subject": subject, "mailBody": mailBody },
		headers: {
			"X-CSRF-TOKEN-JXWebHost": $("input[name='AntiforgeryFieldname']").val()
		},
		error: function (data, status, e) {
			layer.alert('网络超时，发送失败!');
			return false;
		},
		success: function (returnData) {
			if (returnData.status == "1") {
				layer.alert(returnData.msg);
			}
			else {
				layer.alert(returnData.msg);
			}
		}
	});
}

//得到枚举类型的说明
function GetEnumDesc(enumType, enumValue) {
	var url = '/Common/GetEnumDescription';
	$.ajax({
		type: "POST",
		url: url,
		data: { "enumType": enumType, "enumValue": enumValue },
		headers: {
			"X-CSRF-TOKEN-JXWebHost": $("input[name='AntiforgeryFieldname']").val()
		},
		error: function (data, status, e) {
			return "";
		},
		success: function (returnData) {
			return returnData;
		}
	});
}