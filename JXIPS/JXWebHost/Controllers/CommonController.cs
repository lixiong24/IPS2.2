using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JX.Infrastructure.Common;
using JX.Infrastructure;
using JX.Infrastructure.TencentCaptcha;
using MimeKit;
using System.Text;
using JX.Application;
using JX.Core.Entity;

namespace JXWebHost.Controllers
{
    public class CommonController : Controller
    {
		private IRegionServiceApp _RegionServiceApp;
		
		public CommonController(IRegionServiceApp regionServiceApp)
		{
			_RegionServiceApp = regionServiceApp;
		}

		/// <summary>
		/// 上传文件
		/// </summary>
		/// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> UploadHandle()
		{
			ResultInfo resultInfo = new ResultInfo();
			var uploadConfig = ConfigHelper.Get<UploadFilesConfig>();
			if (!uploadConfig.EnableUploadFiles)
			{
				resultInfo.Msg = "没有开启上传权限";
				return Json(resultInfo);
			}
			var formFile = Request.Form.Files[0];
			resultInfo = await Utility.FileUploadSaveAs(formFile);
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
			ResultInfo resultInfo = new ResultInfo();
			var uploadConfig = ConfigHelper.Get<UploadFilesConfig>();
			if (!uploadConfig.EnableUploadFiles)
			{
				resultInfo.Msg = "没有开启上传权限";
				return Json(resultInfo);
			}
			var formFile = Request.Form.Files[0];
			resultInfo = await Utility.FileUploadSaveAs(formFile,"","","", isThumb, isWaterMark);
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

		/// <summary>
		/// 发送邮件
		/// </summary>
		/// <param name="mailToAddress">收件人地址</param>
		/// <param name="subject">邮件标题</param>
		/// <param name="mailBody">邮件内容</param>
		/// <returns></returns>
		[HttpPost]
		public IActionResult SendMail(string mailToAddress, string subject= "这是一封测试邮件", string mailBody= "这是一封测试邮件，如果您可以成功收到此邮件，则说明您的“邮件参数配置”设置正确。")
		{
			ResultInfo resultInfo = new ResultInfo();
			if (string.IsNullOrEmpty(mailToAddress))
			{
				resultInfo.Status = 0;
				resultInfo.Msg = "收件人地址不能为空";
				return Json(resultInfo);
			}
			if (string.IsNullOrEmpty(subject))
			{
				resultInfo.Status = 0;
				resultInfo.Msg = "邮件标题不能为空";
				return Json(resultInfo);
			}
			if (string.IsNullOrEmpty(mailBody))
			{
				resultInfo.Status = 0;
				resultInfo.Msg = "邮件内容不能为空";
				return Json(resultInfo);
			}
			MailSender sender2 = new MailSender();
			sender2.Subject = subject;
			sender2.MailBody = mailBody;
			sender2.IsBodyHtml = true;
			sender2.FromName = "系统";
			sender2.MailToAddressList.Add(new MailboxAddress(mailToAddress));
			//sender2.AttachmentFilePath = Utility.UploadDirPath(true) + "a.rar";
			if (sender2.Send() == MailState.Ok)
			{
				resultInfo.Status = 1;
				resultInfo.Msg = "邮件发送成功";
			}
			else
			{
				resultInfo.Status = 0;
				resultInfo.Msg = sender2.Msg;
			}
			return Json(resultInfo);
		}

		/// <summary>
		/// 得到国家、省份、城市、区域相对应的下拉选项代码
		/// </summary>
		/// <param name="Action"></param>
		/// <param name="Country"></param>
		/// <param name="Province"></param>
		/// <param name="City"></param>
		/// <param name="Area"></param>
		/// <returns></returns>
		[HttpPost]
		public IActionResult Region(string Action = "country", string Country = "中华人民共和国", string Province = "", string City = "", string Area="")
		{
			ResultInfo resultInfo = new ResultInfo();
			StringBuilder sb = new StringBuilder();
			sb.Append("<option value=\"\">请选择</option>");
			switch (Action.ToLower())
			{
				case "country":
					IList<RegionEntity> CountryList = _RegionServiceApp.GetCountryList();
					foreach (RegionEntity info in CountryList)
					{
						if (Country == info.Country)
						{
							sb.Append("<option selected=\"selected\" value=\"" + info.Country + "\">" + info.Country + "</option>");
						}
						else
						{
							sb.Append("<option value=\"" + info.Country + "\">" + info.Country + "</option>");
						}
					}
					break;
				case "province":
					IList<RegionEntity> ProvinceList = _RegionServiceApp.GetProvinceListByCountry(Country);
					foreach (RegionEntity info in ProvinceList)
					{
						if (Province == info.Province)
						{
							sb.Append("<option selected=\"selected\" value=\"" + info.Province + "\">" + info.Province + "</option>");
						}
						else
						{
							sb.Append("<option value=\"" + info.Province + "\">" + info.Province + "</option>");
						}
					}
					break;
				case "city":
					IList<RegionEntity> CityList = _RegionServiceApp.GetCityListByProvince(Province);
					foreach (RegionEntity info in CityList)
					{
						if (City == info.City)
						{
							sb.Append("<option selected=\"selected\" value=\"" + info.City + "\">" + info.City + "</option>");
						}
						else
						{
							sb.Append("<option value=\"" + info.City + "\">" + info.City + "</option>");
						}
					}
					break;
				case "area":
					IList<RegionEntity> AreaList = _RegionServiceApp.GetAreaListByCity(City);
					foreach (RegionEntity info in AreaList)
					{
						if (Area == info.Area)
						{
							sb.Append("<option selected=\"selected\" value=\"" + info.Area + "\">" + info.Area + "</option>");
						}
						else
						{
							sb.Append("<option value=\"" + info.Area + "\">" + info.Area + "</option>");
						}
					}
					break;
			}
			resultInfo.Status = 1;
			resultInfo.Data = sb.ToString();
			return Json(resultInfo);
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
