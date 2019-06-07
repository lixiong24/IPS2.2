using System;
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

namespace JXWebHost.Areas.Admin.Controllers
{
	[Area("Admin")]
	[AdminAuthorize]
	public class PlusController : Controller
    {
		private IUserMessageServiceApp _UserMessageServiceApp;
		private IUsersServiceApp _UsersServiceApp;

		public PlusController(IUserMessageServiceApp UserMessageServiceApp, IUsersServiceApp UsersServiceApp)
		{
			_UserMessageServiceApp = UserMessageServiceApp;
			_UsersServiceApp = UsersServiceApp;
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
			return View();
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
		public ActionResult RegionManage()
		{
			return View();
		}
		#endregion
	}
}