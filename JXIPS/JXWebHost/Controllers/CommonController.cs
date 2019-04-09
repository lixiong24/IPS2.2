using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JX.Infrastructure.Common;
using JX.Infrastructure;
using JX.Infrastructure.TencentCaptcha;

namespace JXWebHost.Controllers
{
    public class CommonController : Controller
    {
		/// <summary>
		/// 上传文件
		/// </summary>
		/// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> UploadHandle()
		{
			var formFile = Request.Form.Files[0];
			ResultInfo resultInfo = await Utility.FileUploadSaveAs(formFile);
			return Json(resultInfo);
		}

		/// <summary>
		/// 上传图片
		/// </summary>
		/// <param name="isThumb"></param>
		/// <param name="isWaterMark"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> UploadImageHandle(bool isThumb = false, bool isWaterMark = false)
		{
			var formFile = Request.Form.Files[0];
			ResultInfo resultInfo = await Utility.FileUploadSaveAs(formFile,"","","", isThumb, isWaterMark);
			return Json(resultInfo);
		}

		/// <summary>
		/// 图形验证码
		/// </summary>
		/// <returns></returns>
		public IActionResult ValidateCode()
		{
			string code = "";
			System.IO.MemoryStream ms = ValidateCodeHelper.CreateValidateCode(out code);
			Utility.SetSession("LoginValidateCode", code);
			Response.Body.Dispose();
			return File(ms.ToArray(), @"image/png");
		}

		/// <summary>
		/// 发送短信
		/// </summary>
		/// <param name="mobile">手机号</param>
		/// <param name="ticket">腾讯验证码客户端验证回调的票据</param>
		/// <param name="randstr">腾讯验证码客户端验证回调的随机串</param>
		/// <returns></returns>
		[HttpPost]
		public IActionResult SendCodeSMS(string mobile,string ticket,string randstr)
		{
			ResultInfo resultInfo = new ResultInfo();
			if(string.IsNullOrEmpty(mobile))
			{
				resultInfo.Status = 0;
				resultInfo.Msg = "手机号不能为空";
				return Json(resultInfo);
			}
			if (string.IsNullOrEmpty(ticket))
			{
				resultInfo.Status = 0;
				resultInfo.Msg = "ticket不能为空";
				return Json(resultInfo);
			}
			if (string.IsNullOrEmpty(randstr))
			{
				resultInfo.Status = 0;
				resultInfo.Msg = "randstr不能为空";
				return Json(resultInfo);
			}
			if (TencentCaptchaUtility.CheckTicket(ticket, randstr,Utility.GetClientIP()))
			{
				//调用发送短信接口

				resultInfo.Status = 1;
				resultInfo.Msg = "发送成功";
				return Json(resultInfo);
			}
			else
			{
				resultInfo.Status = 0;
				resultInfo.Msg = "ticket验证不通过，发送失败！";
				return Json(resultInfo);
			}
		}

		private IActionResult RedirectToLocal(string returnUrl)
		{
			if (Url.IsLocalUrl(returnUrl))
			{
				return Redirect(returnUrl);
			}
			else
			{
				return RedirectToAction(nameof(HomeController.Index), "Home");
			}
		}
	}
}
