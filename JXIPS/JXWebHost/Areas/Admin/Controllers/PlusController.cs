using System;
using System.Collections.Generic;
using System.Linq;
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
				_UserMessageServiceApp.Delete(" and MessageID in ("+ ids + ")");
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
				string strWhere = " and Sender in (" + DelValue + ")";
				if (DelType == 1)
				{
					switch (DelValue)
					{
						case "0":
							strWhere = "";
							break;
						default:
							strWhere = " and datediff(day,SendTime,getdate()) >="+ DelValue;
							break;
					}
				}
				_UserMessageServiceApp.Delete(strWhere);
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

		[AdminAuthorize(Roles = "SuperAdmin,MessageManage")]
		public ActionResult MessageSend()
		{
			var viewModel = new MessageViewModel();
			viewModel.MessageID = 0;
			return View(viewModel);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		[AdminAuthorize(Roles = "SuperAdmin,MessageManage")]
		public async Task<ActionResult> MessageSend(MessageViewModel viewModel, IFormCollection collection)
		{
			#region 添加
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
					if (string.IsNullOrEmpty(viewModel.Incept))
					{
						ModelState.AddModelError(string.Empty, "收件人不能为空");
						return View(viewModel);
					}
					StringHelper.AppendString(sbIncept, viewModel.Incept);
					break;
				case 2://指定会员组
					var InceptGroup = collection["dropUserGroup"];
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
			var entity = new UserMessageEntity();
			entity.Title = viewModel.Title;
			entity.Content = viewModel.Content;
			entity.Sender = viewModel.Sender;
			entity.Incept = sbIncept.ToString();
			entity.SendTime = DateTime.Now;
			string msg = await _AdminService.AddAdminFull(adminDTO);
			if (msg != "ok")
			{
				ModelState.AddModelError(string.Empty, msg);
				return View(adminViewModel);
			}
			#endregion
			return View(adminViewModel);
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