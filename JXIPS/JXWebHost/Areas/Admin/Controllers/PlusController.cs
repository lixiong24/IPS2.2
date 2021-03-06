﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using JX.Application;
using JX.Core.Entity;
using JX.Infrastructure;
using JX.Infrastructure.Common;
using JX.Infrastructure.Framework.Authorize;
using JXWebHost.Areas.Admin.Models.PlusViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit;

namespace JXWebHost.Areas.Admin.Controllers
{
	[Area("Admin")]
	[AdminAuthorize]
	public class PlusController : Controller
    {
		private IUserMessageServiceApp _UserMessageServiceApp;
		private IUsersServiceApp _UsersServiceApp;
		private IRegionServiceApp _RegionServiceApp;

		public PlusController(IUserMessageServiceApp UserMessageServiceApp, 
			IUsersServiceApp UsersServiceApp, 
			IRegionServiceApp RegionServiceApp)
		{
			_UserMessageServiceApp = UserMessageServiceApp;
			_UsersServiceApp = UsersServiceApp;
			_RegionServiceApp = RegionServiceApp;
		}

		#region 站内信管理
		[AdminAuthorize(Roles = "SuperAdmin,MessageManage")]
		public ActionResult MessageManage()
        {
            return View();
        }

		[AdminAuthorize(Roles = "SuperAdmin,MessageManage")]
		public IActionResult GetMessageList()
		{
			int PageNum = Utility.Query("PageNum", 0);
			int PageSize = Utility.Query("PageSize", 10);
			string SearchName = Utility.Query("SearchName");
			string SearchKeyword = Utility.Query("SearchKeyword");
			int TabStatus = Utility.Query("TabStatus", -1);
			string filter = " 1=1 ";
			if (!string.IsNullOrEmpty(SearchKeyword))
			{
				filter += " and " + SearchName + " like '%" + DataSecurity.FilterBadChar(SearchKeyword) + "%'";
			}
			if (TabStatus >= 0)
			{
				filter += " and IsRead = " + TabStatus;
			}
			string strColumn = "MessageID,Title,Sender,Incept,SendTime,IsSend,IsDelInbox,IsDelSendbox,IsRead";
			int RecordTotal;
			var result = _UserMessageServiceApp.GetList(PageNum, PageSize, "MessageID", strColumn, "desc", filter, "", out RecordTotal);
			PagerModel<UserMessageEntity> pagerModel = new PagerModel<UserMessageEntity>(PageNum, PageSize, RecordTotal, result);
			return Json(pagerModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[AdminAuthorize(Roles = "SuperAdmin,MessageManage")]
		public IActionResult DelMessage(int id)
		{
			if (id <= 0)
			{
				return Json(new
				{
					Result = "删除失败！没有指定要删除的记录ID！"
				});
			}
			try
			{
				if (_UserMessageServiceApp.Delete(p=>p.MessageID==id))
				{
					return Json(new
					{
						Result = "ok"
					});
				}
				else
				{
					return Json(new
					{
						Result = "删除失败！"
					});
				}
			}
			catch (Exception ex)
			{
				return Json(new
				{
					Result = "删除失败！" + ex.Message
				});
			}
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		[AdminAuthorize(Roles = "SuperAdmin,MessageManage")]
		public IActionResult DelMessageMulti(string ids)
		{
			if (string.IsNullOrEmpty(ids))
			{
				return Json(new
				{
					Result = "删除失败！没有指定要删除的记录ID！"
				});
			}
			if (!DataValidator.IsValidId(ids))
			{
				return Json(new
				{
					Result = "删除失败！指定要删除的记录ID格式不对！"
				});
			}
			try
			{
				var arrIDs = StringHelper.GetArrayBySplit<int>(ids).ToArray();
				_UserMessageServiceApp.Delete(p => arrIDs.Contains(p.MessageID));
				return Json(new
				{
					Result = "ok"
				});
			}
			catch (Exception ex)
			{
				return Json(new
				{
					Result = "删除失败！" + ex.Message
				});
			}
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[AdminAuthorize(Roles = "SuperAdmin,MessageManage")]
		public IActionResult DelMessageBatch(int DelType=0, string DelValue="")
		{
			if (string.IsNullOrEmpty(DelValue))
			{
				return Json(new
				{
					Result = "删除失败！请指定要删除的发件人或日期！"
				});
			}
			try
			{
				bool bFlag = false;
				if (DelType == 0)
				{
					var arrDelValue = StringHelper.GetArrayBySplit<string>(DelValue).ToArray();
					bFlag = _UserMessageServiceApp.Delete(p=>arrDelValue.Contains(p.Sender));
				}
				else if (DelType == 1)
				{
					switch (DelValue)
					{
						case "0":
							bFlag = _UserMessageServiceApp.Delete(p=>true);
							break;
						default:
							bFlag = _UserMessageServiceApp.Delete(p => EF.Functions.DateDiffDay(p.SendTime, DateTime.Now) >= DataConverter.CLng(DelValue));
							break;
					}
				}
				if (bFlag)
				{
					return Json(new
					{
						Result = "ok"
					});
				}
				else
				{
					return Json(new
					{
						Result = "删除失败！"
					});
				}
			}
			catch (Exception ex)
			{
				return Json(new
				{
					Result = "删除失败！" + ex.Message
				});
			}
		}

		[AdminAuthorize(Roles = "SuperAdmin,MessageManage")]
		public ActionResult MessageSend(int id=0,string atype="")
		{
			var viewModel = new MessageViewModel();
			viewModel.MessageID = id;
			if (string.IsNullOrEmpty(atype))
			{
				ViewBag.Incept = "";
				viewModel.Sender = User.FindFirst(ClaimTypes.Name).Value;
			}
			else
			{
				StringBuilder builder = new StringBuilder();
				var entity = _UserMessageServiceApp.Get(p => p.MessageID == id);
				viewModel.MessageID = entity.MessageID;
				viewModel.Sender = User.FindFirst(ClaimTypes.Name).Value;
				switch (atype)
				{
					case "Reply":
						viewModel.Title = "Re: " + entity.Title;
						builder.Append("======在 ");
						builder.Append(entity.SendTime.Value.ToLongTimeString());
						builder.Append(" 您来信中写道：======\r\n");
						builder.Append(entity.Content);
						builder.Append("\r\n================================================\r\n");
						viewModel.Content = builder.ToString();
						viewModel.Incept = entity.Sender;
						viewModel.InceptType = 1;
						break;
					case "Forward":
						viewModel.Title = "Fw: " + entity.Title;
						builder.Append("============== 下面是转发信息 ==============\r\n");
						builder.Append("原发件人：" + entity.Sender + "\r\n");
						builder.Append("原发件内容：\r\n");
						builder.Append(entity.Content);
						builder.Append("\r\n================================================\r\n");
						viewModel.Content = builder.ToString();
						viewModel.InceptType = 1;
						viewModel.Incept = "";
						break;
				}
				ViewBag.Incept = viewModel.Incept;
			}
			return View(viewModel);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		[AdminAuthorize(Roles = "SuperAdmin,MessageManage")]
		public async Task<ActionResult> MessageSend(MessageViewModel viewModel, IFormCollection collection)
		{
			#region 添加并发送
			StringBuilder sbIncept = new StringBuilder();
			switch(viewModel.InceptType)
			{
				case 0://所有会员
					var listAll = await _UsersServiceApp.QueryDynamicAsync<UsersEntity>(p => p.UserID > 0, p => p.UserName);
					listAll.ForEach(item => {
						StringHelper.AppendString(sbIncept,item);
					});
					break;
				case 1://指定会员
					string Incept = collection["ctlSelectUser"];
					if (string.IsNullOrEmpty(Incept))
					{
						ModelState.AddModelError(string.Empty, "收件人不能为空");
						return View(viewModel);
					}
					string[] strArray = Incept.Split(new char[] { ',' });
					for (int j = 0; j < strArray.Length; j++)
					{
						if (_UsersServiceApp.IsExist(p=>p.UserName== strArray[j]))
						{
							StringHelper.AppendString(sbIncept, strArray[j]);
						}
					}
					break;
				case 2://指定会员组
					var InceptGroup = collection["InceptGroup"];
					if (string.IsNullOrEmpty(InceptGroup))
					{
						ModelState.AddModelError(string.Empty, "收件人会员组不能为空");
						return View(viewModel);
					}
					var listGroup = await _UsersServiceApp.SqlQueryOneAsync<string>("select UserName from Users where GroupID in ("+ InceptGroup + ")");
					List<string> list = (List<string>)listGroup;
					list.ForEach(item => {
						StringHelper.AppendString(sbIncept, item);
					});
					break;
			}
			if (string.IsNullOrEmpty(sbIncept.ToString()))
			{
				ModelState.AddModelError(string.Empty, "收件人不存在");
				return View(viewModel);
			}
			foreach (string strItem in sbIncept.ToString().Split(new char[] { ',' }))
			{
				var entity = new UserMessageEntity();
				entity.Title = viewModel.Title;
				entity.Content = viewModel.Content;
				entity.Sender = viewModel.Sender;
				entity.Incept = strItem;
				entity.SendTime = DateTime.Now;
				entity.IsSend = 1;
				entity.IsRead = 0;
				entity.IsDelInbox = 0;
				entity.IsDelSendbox = 0;
				await _UserMessageServiceApp.AddAsync(entity);
			}
			#endregion
			viewModel.result = "ok";
			return View(viewModel);
		}

		[AdminAuthorize(Roles = "SuperAdmin,MessageManage")]
		public ActionResult ViewMessage(int id = 0)
		{
			var entity = _UserMessageServiceApp.Get(p => p.MessageID == id);
			if(entity != null)
			{
				var currentAdmin = User.FindFirst(ClaimTypes.Name).Value;
				if(entity.Incept == currentAdmin)
				{
					entity.IsRead = 1;
					_UserMessageServiceApp.Update(entity);
				}
			}
			return View(entity);
		}
		#endregion

		#region 邮件发送
		[AdminAuthorize(Roles = "SuperAdmin,MailListSend")]
		public ActionResult MailListSend()
		{
			var viewModel = new MailViewModel();
			ViewBag.Content = "";
			return View(viewModel);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		[AdminAuthorize(Roles = "SuperAdmin,MailListSend")]
		public async Task<ActionResult> MailListSend(MailViewModel viewModel, IFormCollection collection)
		{
			string content = collection["ctlContent"];
			ViewBag.Content = content;
			if (string.IsNullOrEmpty(content))
			{
				ModelState.AddModelError(string.Empty, "邮件内容不能为空");
				return View(viewModel);
			}
			content = content.Replace("src=\"", "src=\"" + Utility.GetApplicationName());

			StringBuilder sbIncept = new StringBuilder();
			switch (viewModel.InceptType)
			{
				case 0://所有会员
					var listAll = await _UsersServiceApp.QueryDynamicAsync<UsersEntity>(p => p.UserID > 0, p => p.Email);
					listAll.ForEach(item => {
						StringHelper.AppendString(sbIncept, item);
					});
					break;
				case 1://指定会员
					string Incept = collection["ctlSelectUser"];
					if (string.IsNullOrEmpty(Incept))
					{
						ModelState.AddModelError(string.Empty, "收件人不能为空");
						return View(viewModel);
					}
					var arrIncept = StringHelper.GetArrayBySplit<string>(Incept).ToArray();
					var listIncept = await _UsersServiceApp.QueryDynamicAsync<UsersEntity>(p => arrIncept.Contains(p.UserName), p => p.Email);
					listIncept.ForEach(item => {
						StringHelper.AppendString(sbIncept, item);
					});
					break;
				case 2://指定会员组
					var InceptGroup = collection["InceptGroup"];
					if (string.IsNullOrEmpty(InceptGroup))
					{
						ModelState.AddModelError(string.Empty, "收件人会员组不能为空");
						return View(viewModel);
					}
					var arrInceptGroup = StringHelper.GetArrayBySplit<int>(InceptGroup).ToArray();
					var listInceptGroup = await _UsersServiceApp.QueryDynamicAsync<UsersEntity>(p => arrInceptGroup.Contains(p.GroupID), p => p.Email);
					listInceptGroup.ForEach(item => {
						StringHelper.AppendString(sbIncept, item);
					});
					break;
				case 3:// 指定email
					if (string.IsNullOrEmpty(viewModel.InceptEmail))
					{
						ModelState.AddModelError(string.Empty, "指定收件人邮箱不能为空");
						return View(viewModel);
					}
					StringHelper.AppendString(sbIncept, viewModel.InceptEmail.TrimEnd(','));
					break;
			}
			if (string.IsNullOrEmpty(sbIncept.ToString()))
			{
				ModelState.AddModelError(string.Empty, "收件人邮箱不存在");
				return View(viewModel);
			}
			
			
			int SuccessCount = 0;
			int failCount = 0;
			StringBuilder sbFail = new StringBuilder();
			foreach (string strItem in sbIncept.ToString().Split(new char[] { ',' }))
			{
				MailSender sender2 = new MailSender();
				sender2.Subject = viewModel.Title;
				sender2.MailBody = content;
				sender2.IsBodyHtml = true;
				sender2.FromName = viewModel.Sender;
				sender2.MailToAddressList.Add(new MailboxAddress(strItem));
				if (sender2.Send() == MailState.Ok)
				{
					SuccessCount = SuccessCount + 1;
				}
				else
				{
					failCount = failCount + 1;
					StringHelper.AppendString(sbFail, strItem);
				}
			}
			var msg = "<li>发送完成！成功：<font color='blue'>" + SuccessCount.ToString() + "</fong>个，失败：<font color='red'>" + failCount.ToString()+ "</fong>个</li>";
			if(failCount > 0)
			{
				msg += "<li>失败email：" + sbFail.ToString() + "</li>";
			}
			Utility.WriteMessage(msg);
			return View(viewModel);
		}
		#endregion

		#region 数据字典管理
		[AdminAuthorize(Roles = "SuperAdmin,ChoicesetManage")]
		public ActionResult ChoicesetManage()
		{
			return View();
		}
		#endregion

		#region 行政区划管理
		[AdminAuthorize(Roles = "SuperAdmin,RegionManage")]
		public IActionResult RegionManage()
		{
			return View();
		}
		[AdminAuthorize(Roles = "SuperAdmin,RegionManage")]
		public IActionResult GetRegionList()
		{
			int PageNum = Utility.Query("PageNum", 0);
			int PageSize = Utility.Query("PageSize", 15);
			string SearchName = Utility.Query("SearchName");
			string SearchKeyword = Utility.Query("SearchKeyword");
			int TabStatus = Utility.Query("TabStatus", 0);
			string filter = " 1=1 ";
			if (!string.IsNullOrEmpty(SearchKeyword))
			{
				filter += " and " + SearchName + " like '%" + DataSecurity.FilterBadChar(SearchKeyword) + "%'";
			}
			if (TabStatus > 0)
			{
				//filter += " and IsRead = " + TabStatus;
			}
			string strColumn = " * ";
			int RecordTotal;
			var result = _RegionServiceApp.GetList(PageNum * PageSize, PageSize, "RegionID", strColumn, "desc", filter, "", out RecordTotal);
			PagerModel<RegionEntity> pagerModel = new PagerModel<RegionEntity>(PageNum, PageSize, RecordTotal, result);
			return Json(pagerModel);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		[AdminAuthorize(Roles = "SuperAdmin,RegionManage")]
		public IActionResult DelRegion(int id)
		{
			if (id <= 0)
			{
				return Json(new
				{
					Result = "删除失败！没有指定要删除的记录ID！"
				});
			}
			try
			{
				if (_RegionServiceApp.Delete(p => p.RegionID == id))
				{
					return Json(new
					{
						Result = "ok"
					});
				}
				else
				{
					return Json(new
					{
						Result = "删除失败！"
					});
				}
			}
			catch (Exception ex)
			{
				return Json(new
				{
					Result = "删除失败！" + ex.Message
				});
			}
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		[AdminAuthorize(Roles = "SuperAdmin,RegionManage")]
		public IActionResult DelRegionMulti(string ids)
		{
			if (string.IsNullOrEmpty(ids))
			{
				return Json(new
				{
					Result = "删除失败！没有指定要删除的记录ID！"
				});
			}
			if (!DataValidator.IsValidId(ids))
			{
				return Json(new
				{
					Result = "删除失败！指定要删除的记录ID格式不对！"
				});
			}
			try
			{
				var arrIDs = StringHelper.GetArrayBySplit<int>(ids).ToArray();
				_RegionServiceApp.Delete(p => arrIDs.Contains(p.RegionID));
				return Json(new
				{
					Result = "ok"
				});
			}
			catch (Exception ex)
			{
				return Json(new
				{
					Result = "删除失败！" + ex.Message
				});
			}
		}
		#endregion

		#region 行政区划编辑
		[AdminAuthorize(Roles = "SuperAdmin,RegionManage")]
		public IActionResult RegionEdit(int id = 0)
		{
			var model = new RegionEntity();
			model.RegionID = id;
			if (id <= 0)
				return View(model);
			model = _RegionServiceApp.Get(p => p.RegionID == id);
			if (model == null || model.RegionID <= 0)
				return View(model);
			return View(model);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		[AdminAuthorize(Roles = "SuperAdmin,RegionManage")]
		public async Task<ActionResult> RegionEdit(int id = 0, RegionEntity model = null, IFormCollection collection = null)
		{
			if (string.IsNullOrEmpty(model.Country))
			{
				ModelState.AddModelError(string.Empty, "国家名称不能为空");
				return View(model);
			}
			if (string.IsNullOrEmpty(model.Province))
			{
				ModelState.AddModelError(string.Empty, "省份名称不能为空");
				return View(model);
			}
			if (string.IsNullOrEmpty(model.City))
			{
				ModelState.AddModelError(string.Empty, "城市名称不能为空");
				return View(model);
			}
			if (string.IsNullOrEmpty(model.PostCode))
			{
				ModelState.AddModelError(string.Empty, "邮政编码不能为空");
				return View(model);
			}
			if (string.IsNullOrEmpty(model.AreaCode))
			{
				ModelState.AddModelError(string.Empty, "区号不能为空");
				return View(model);
			}
			if (id <= 0)
			{
				#region 添加
				if (!await _RegionServiceApp.AddAsync(model))
				{
					ModelState.AddModelError(string.Empty, "添加失败");
					return View(model);
				}
				id = model.RegionID;
				#endregion
			}
			else
			{
				#region 修改
				model.RegionID = id;
				if (!await _RegionServiceApp.UpdateAsync(model))
				{
					ModelState.AddModelError(string.Empty, "修改失败");
					return View(model);
				}
				#endregion
			}
			Utility.WriteMessage("操作成功", "mRefresh");
			return View(model);
		}
		[AdminAuthorize(Roles = "SuperAdmin,RegionManage")]
		public IActionResult RegionView(int id = 0)
		{
			var model = new RegionEntity();
			model.RegionID = id;
			if (id <= 0)
			{
				Utility.WriteMessage("指定的ID不存在", "mClose");
				return View(model);
			}

			model = _RegionServiceApp.Get(p => p.RegionID == id);
			if (model == null || model.RegionID <= 0)
			{
				Utility.WriteMessage("指定的信息不存在", "mClose");
				return View(model);
			}
			return View(model);
		}
		#endregion
	}
}