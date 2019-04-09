//当验证不通过时会触发
function error(code) {
	switch (code) {
		case "Q_EXCEED_NUM_LIMIT":
			code = "上传文件总数量超出限制";
			break;
		case "F_EXCEED_SIZE":
			code = "上传文件大小超出限制";
			break;
		case "Q_TYPE_DENIED":
			code = "上传文件类型不匹配";
			break;
		case "F_DUPLICATE":
			code = "该文件已存在！";
			break;
	}
	alert('错误: ' + code);
}

//创建进度条，实时显示。
//file：上传文件对象；percentage：上传进度；
function ShowUploadProgress(file, percentage) {
	var $divImageItem = $('#' + file.id),
		$divImageItemUploaded = $divImageItem.find('.Uploaded'),
		$progress = $divImageItemUploaded.find('.progress'),
		$percentBar = $divImageItemUploaded.find('.progress .progress-bar'),
		$percentText = $divImageItemUploaded.find('.progress .text');
	// 避免重复创建
	if (!$progress.length) {
		$progress = $(
					'<div class="progress" style="display:block;">' +
						'<span class="progress-bar" role="progressbar" style="display:block;height:20px;"></span>' +
						'<span class="text"></span>' +
					'</div>');
		$percentBar = $progress.find('.progress-bar');
		$percentText = $progress.find('.text');
		$divImageItemUploaded.append($progress);
	}
	$percentBar.css('width', percentage * 100 + '%');
	$percentText.html(parseFloat(percentage * 100).toFixed(2) + '%');
}

//文件上传成功时显示成功标记。
//file：上传文件对象；response：服务器返回的数据；
function ShowUploadSuccess(file, response) {
//	var $divImageItem = $('#' + file.id),
//		$divImageItemUploaded = $divImageItem.find('.Uploaded'),
//		$success = $divImageItemUploaded.find('.success');
//	// 避免重复创建
//	if (!$success.length) {
//		$success = $('<div class="success"></div>').appendTo($divImageItemUploaded);
//	}
//	$success.show();
	//保存服务器返回的上传文件名称
	if (response.status == "1") {
		$('#hidFile' + file.id).val(response.data);
	}
}

//文件上传失败时显示失败标记。
//file：上传文件对象；
function ShowUploadError(file, reason) {
	var $divImageItem = $('#' + file.id),
		$divImageItemUploaded = $divImageItem.find('.Uploaded'),
		$error = $divImageItemUploaded.find('.error');
	// 避免重复创建
	if (!$error.length) {
		$error = $('<div class="error"></div>').appendTo($divImageItemUploaded);
	}
	$error.text('上传失败:' + reason);
}

//文件上传完成时，先删除进度条。
//file：上传文件对象；
function ShowUploadComplete(file) {
	$('#' + file.id).find('.Uploaded .progress').remove();
}

/*
在图片列表中创建显示图片的区域，并返回创建的图片对象
baseUrl：网站根目录路径；
SaveDataID：保存上传数据的控件ID；
fileListID：文件列表对象ID；
fileID：上传文件对象ID；
uploader：WebUpload对象；
isShowText：是否显示文本区域；
*/
function addImageWU(baseUrl, SaveDataID, fileListID, fileID, uploader,isShowText) {
	/* 整个LI的结构
	<li class="UploadWrap">
		<div class="Uploaded">
			<img />
			<div class="view">
				<a><img /><img /></a>
				<a><img /><img /></a>
				<a><img /><img /></a>
			</div>
		</div>
		<div class="text-view">
			<textarea></textarea>
			<input type="hidden" />
		</div>
	</li>*/
	//图片文件的容器（LI）
	var imageContainer = document.createElement("li");
	imageContainer.id = fileID;
	imageContainer.className = "UploadWrap";

	//图片显示区域
	var divImg = document.createElement("div");
	divImg.className = "Uploaded";
	//图片控件
	var newImg = document.createElement("img");
	newImg.id = "img" + fileID;
	divImg.appendChild(newImg);
	//排序、删除区域
	var divView = document.createElement("div");
	divView.className = "view";
	//左移按纽、图片
	var aLeft = document.createElement("a");
	aLeft.id = "prev" + fileID;
	aLeft.href = "javascript:void(0);";
	aLeft.onclick = function () {
		MoveLeft(fileID);
		SavaLatestServerDataWU(SaveDataID, fileListID);
	};
	var imgLeft1 = document.createElement("img");
	imgLeft1.className = "img1";
	imgLeft1.src = baseUrl + "plugins/WebUpload/images/last1.png";
	aLeft.appendChild(imgLeft1);
	var imgLeft2 = document.createElement("img");
	imgLeft2.className = "img2";
	imgLeft2.src = baseUrl + "plugins/WebUpload/images/last2.png";
	aLeft.appendChild(imgLeft2);
	divView.appendChild(aLeft);
	//右移按纽、图片
	var aRight = document.createElement("a");
	aRight.id = "next" + fileID;
	aRight.href = "javascript:void(0);";
	aRight.onclick = function () {
		MoveRight(fileID);
		SavaLatestServerDataWU(SaveDataID, fileListID);
	};
	var imgRight1 = document.createElement("img");
	imgRight1.className = "img1";
	imgRight1.src = baseUrl + "plugins/WebUpload/images/next1.png";
	aRight.appendChild(imgRight1);
	var imgRight2 = document.createElement("img");
	imgRight2.className = "img2";
	imgRight2.src = baseUrl + "plugins/WebUpload/images/next2.png";
	aRight.appendChild(imgRight2);
	divView.appendChild(aRight);
	//删除按纽、图片
	var aDel = document.createElement("a");
	aDel.id = "del" + fileID;
	aDel.href = "javascript:void(0);";
	aDel.onclick = function () {
		removeImage(fileListID,fileID, uploader);
		SavaLatestServerDataWU(SaveDataID, fileListID);
	};
	var imgDel1 = document.createElement("img");
	imgDel1.className = "img1";
	imgDel1.src = baseUrl + "plugins/WebUpload/images/delete1.png";
	aDel.appendChild(imgDel1);
	var imgDel2 = document.createElement("img");
	imgDel2.className = "img2";
	imgDel2.src = baseUrl + "plugins/WebUpload/images/delete2.png";
	aDel.appendChild(imgDel2);
	divView.appendChild(aDel);
	divImg.appendChild(divView);
	imageContainer.appendChild(divImg);
	//文本框显示区域
	var divText = document.createElement("div");
	divText.className = "text-view";
	if (isShowText) {
		divText.style = "display:;";
	}
	else {
		divText.style = "display:none;";
	}
	//文本框控件
	var newText = document.createElement("textarea");
	newText.id = "txt"+fileID;
	newText.style = "height:20px;";
	newText.value = "";
	newText.onchange = function () {
		SavaLatestServerDataWU(SaveDataID, fileListID);
	};
	newText.onfocus = function () {
		dragLength(this);
	};
	newText.onblur = function () {
		sameAs(this);
	};
	divText.appendChild(newText);
	//图片路径保存控件
	var newInputHid = document.createElement("input");
	newInputHid.id = "hidFile" + fileID;
	newInputHid.type = "hidden";
	divText.appendChild(newInputHid);
	imageContainer.appendChild(divText);

	document.getElementById(fileListID).appendChild(imageContainer);
	return $(newImg);
}

//删除图片区域，并从上传队列中移除
//fileListID：文件列表对象ID（UL）；fileID：上传文件容器ID（LI）；uploader：WebUpload对象；
function removeImage(fileListID,fileID, uploader) {
	uploader.removeFile(fileID, true);//删除上传文件，并从上传队列中移出
	var delChild = document.getElementById(fileID);
	document.getElementById(fileListID).removeChild(delChild);
}

//向左边移动 obj：图片容器LI的ID；
function MoveLeft(obj) {
	CustomNodeSwapAndReplace();
	var imageItem = document.getElementById(obj);
	imageItem.previousSibling.swapNode(imageItem);
}
//向右边移动 obj：图片容器LI的ID；
function MoveRight(obj) {
	CustomNodeSwapAndReplace();
	var imageItem = document.getElementById(obj);
	imageItem.swapNode(imageItem.nextSibling);
}
function CustomNodeSwapAndReplace() {
	if (window.Node) {
		Node.prototype.replaceNode = function ($target) {
			return this.parentNode.replaceChild($target, this);
		}
		Node.prototype.swapNode = function ($target) {
			var $targetParent = $target.parentNode;
			var $targetNextSibling = $target.nextSibling;
			var $thisNode = this.parentNode.replaceChild($target, this);
			$targetNextSibling ? $targetParent.insertBefore($thisNode, $targetNextSibling) : $targetParent.appendChild($thisNode);
			return this;
		}
	}
}
function dragLength(textObj) {
	textObj.style.height = 50 + 'px';
}
function sameAs(textObj) {
	textObj.style.height = 20 + 'px';
}

//保存最新的上传数据
//savaDataID：保存上传数据的控件ID；fileListID：文件列表容器ID；
function SavaLatestServerDataWU(savaDataID, fileListID) {
	var fileList = $("#" + fileListID);
	if (fileList != null) {
		var savaData = "";
		fileList.find("input[type='hidden']").each(function (i) {
			var imgSrc = $(this).val();
			var textValue = $(this).prev().val();
			if (savaData == "") {
				savaData = textValue + "|" + imgSrc;
			}
			else {
				savaData = savaData + "$$$" + textValue + "|" + imgSrc;
			}
		});
		$("#" + savaDataID).val(savaData);
	}
}
/*
savaDataID：保存上传图片数据的容器ID
baseUrl：网站根目录路径；
uploadDir：上传目录路径
uploader：WebUpload对象
*/
function LoadImageWU(savaDataID, baseUrl, uploadDir, uploader) {
	var savaData = $("#" + savaDataID).val();
	if (savaData == null || savaData == "") {
		return;
	}
	var arrData = savaData.split("$$$");
	for (i = 0; i < arrData.length; i++) {
		var arrImg = arrData[i].split("|");
		var imgUrl = "";
		if (arrImg.length > 1) {
			imgUrl = arrImg[1];
		}
		else {
			imgUrl = arrImg[0];
		}
		var serverDataUrl = baseUrl + uploadDir + imgUrl;
		var fileName = WebUploader.File.Status.COMPLETE + "|" + arrData[i];
		GetFileObject(serverDataUrl, fileName, function (fileObject) {
			var wuFile = new WebUploader.File(fileObject);
			wuFile.setStatus(WebUploader.File.Status.COMPLETE);
			uploader.addFiles(wuFile);
		});
	}
}
/*
显示图片。
baseUrl：网站根目录路径；
uploadDir：上传目录路径；
arrImg：包含图片数据的数组（图片说明、图片地址）；
fileID：上传文件对象ID；
*/
function ShowImgByServer(baseUrl, uploadDir, arrImg,fileID) {
	var imgUrl = "";
	var imgText = "";
	if (arrImg.length == 3) {
		imgText = arrImg[1];
		imgUrl = arrImg[2];
	}
	else if (arrImg.length == 2) {
		imgText = arrImg[0];
		imgUrl = arrImg[1];
	}
	else {
		imgUrl = arrImg[0];
	}
	if (imgUrl != "") {
		jQuery("#img" + fileID).attr("src", baseUrl + uploadDir + imgUrl);
		jQuery("#txt" + fileID).val(imgText);
		jQuery("#hidFile" + fileID).val(imgUrl);
	}
}
/*
得到指定URL的Blob对象
url：服务器对象地址；cb：回调函数
*/
function GetFileBlob(url, cb) {
	var xhr = new XMLHttpRequest();
	xhr.open("GET", url);
	xhr.responseType = "blob";
	if (typeof document.addEventListener != "undefined") {
		xhr.addEventListener('load', function () {
			cb(xhr.response);
		});
	} else {
		xhr.attachEvent('onload', function () {
			cb(xhr.response);
		});
	} 
	xhr.send();
}
/*
把Blob对象转换成一个File对象
blob：Blob对象；name：文件的名称；
*/
function BlobToFile(blob, name) {
	blob.lastModifiedDate = new Date();
	blob.name = name;
	return blob;
}
/*
得到一个File对象；
filePathOrUrl：文件地址；fileName：文件名称，包含后缀名；cb：回调函数；
*/
function GetFileObject(filePathOrUrl, fileName, cb) {
	GetFileBlob(filePathOrUrl, function (blob) {
		cb(BlobToFile(blob, fileName));
	});
}