using JX.Core;
using JX.Core.Entity;
using JX.Infrastructure;
using JX.Infrastructure.Common;
using JX.Infrastructure.Data;
using JX.Infrastructure.Log;
using JXWebHost.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Diagnostics;
using System.Linq;

namespace JXWebHost.Controllers
{
	public class HomeController : Controller
    {
		private IRegionRepository _RegionRepository;
		private IAddressRepository _AddressRepository;
		private IAdminRepository _AdminRepository;
		private IAdminRolesRepository _AdminRolesRepository;
		private IRoleFieldPermissionsRepository _RoleFieldPermissionsRepository;
		public HomeController(IRegionRepository regionRepository, 
			IAddressRepository addressRepository, 
			IAdminRepository adminRepository, 
			IAdminRolesRepository adminRolesRepository,
			IRoleFieldPermissionsRepository roleFieldPermissionsRepository)
		{
			_RegionRepository = regionRepository;
			_AddressRepository = addressRepository;
			_AdminRepository = adminRepository;
			_AdminRolesRepository = adminRolesRepository;
			_RoleFieldPermissionsRepository = roleFieldPermissionsRepository;
		}

		public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

		public IActionResult Category(string id="")
		{
			if (string.IsNullOrEmpty(id))
			{
				return RedirectToAction(nameof(HomeController.Error), "Home");
			}
			var arrNodeID = id.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
			int nodeID = DataConverter.CLng(arrNodeID[0]);
			int pageNum = 0;
			if (nodeID <= 0)
			{
				return RedirectToAction(nameof(HomeController.Error), "Home");
			}
			if(arrNodeID.Length == 2)
			{
				pageNum = DataConverter.CLng(arrNodeID[1]);
			}
			ViewBag.NodeID = nodeID;
			ViewBag.PageNum = pageNum;
			ViewData["Title"] = "栏目标题";
			return View();
		}

		public IActionResult TestCommon()
		{
			ViewData["ContentRootPath"] = FileHelper.ContentRootPath;
			ViewData["WebRootPath"] = FileHelper.WebRootPath;
			ViewData["WebRootName"] = FileHelper.WebRootName;

			string strRequestMsg = string.Empty;
			strRequestMsg += " HasFormContentType：" + MyHttpContext.Current.Request.HasFormContentType + Environment.NewLine;
			strRequestMsg += " Host：" + MyHttpContext.Current.Request.Host + Environment.NewLine;
			strRequestMsg += " IsHttps：" + MyHttpContext.Current.Request.IsHttps + Environment.NewLine;
			strRequestMsg += " Method：" + MyHttpContext.Current.Request.Method + Environment.NewLine;
			strRequestMsg += " Path：" + MyHttpContext.Current.Request.Path + Environment.NewLine;
			strRequestMsg += " PathBase：" + MyHttpContext.Current.Request.PathBase + Environment.NewLine;
			strRequestMsg += " Protocol：" + MyHttpContext.Current.Request.Protocol + Environment.NewLine;
			strRequestMsg += " Scheme：" + MyHttpContext.Current.Request.Scheme + Environment.NewLine;
			ViewData["RequestMsg"] = strRequestMsg;

			ViewData["RequestReferer"] = MyHttpContext.Current.Request.UrlReferrer();
			string strHeaders = string.Empty;
			foreach (String strFormKey in MyHttpContext.Current.Request.Headers.Keys)
			{
				strHeaders += strFormKey + "：" + MyHttpContext.Current.Request.Headers[strFormKey] + "#####";
			}
			ViewData["RequestHeaders"] = strHeaders;

			ViewData["RequestHeadersJSON"] = "";//MyHttpContext.Current.Request.Headers.ToJson();
			string strForm = string.Empty;
			if (MyHttpContext.Current.Request.Method == "POST")
			{
				foreach (String strFormKey in MyHttpContext.Current.Request.Form.Keys)
				{
					strForm += strFormKey + "：" + DataConverter.ToString(MyHttpContext.Current.Request.Form[strFormKey]) + "#####";
				}
			}
			ViewData["RequestFormJSON"] = strForm;
			//ViewData["RequestFormJSON"] = MyHttpContext.Current.Request.Form.ToJson();

			string strCurrentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff");
			var resultAdd = CacheHelper.CacheServiceProvider.AddOrUpdate("CurrentTime", strCurrentTime);
			if (CacheHelper.CacheServiceProvider.Exists("CurrentTime"))
			{
				string resultGet = CacheHelper.CacheServiceProvider.Get<string>("CurrentTime");
				ViewData["CurrentTime"] = resultGet;
			}

			string strMsg = "我是加密文件，请保管好";
			string strKey = Guid.NewGuid().ToString().Replace("-", string.Empty);
			string strEncryptAes = AesRijndael.Encrypt(strMsg, strKey);
			string strDecryptAes = AesRijndael.Decrypt(strEncryptAes, strKey);
			ViewData["EncryptAes"] = strEncryptAes;
			ViewData["DecryptAes"] = strDecryptAes;

			string strEncryptHmacSha1 = HmacSha1.EncryptUtf8(strMsg, strKey);
			string strEncryptHmacSha1Base64 = HmacSha1.EncryptBase64(strMsg, strKey);
			ViewData["EncryptHmacSha1"] = strEncryptHmacSha1;
			ViewData["EncryptHmacSha1Base64"] = strEncryptHmacSha1Base64;

			string strEncryptMd5 = Md5.EncryptHexString(strMsg);
			ViewData["EncryptMd5"] = strEncryptMd5;

			string strEncryptSha1 = Sha1.Encrypt(strMsg);
			ViewData["EncryptSha1"] = strEncryptSha1;

			ViewData["ClientIP"] = IPHelper.GetClientIP();
			ViewData["HostIP"] = IPHelper.GetHostIP();

			ViewData["RandomFormatedNumeric"] = RandomHelper.GetFormatedNumeric(4, 10);
			ViewData["RandomString"] = RandomHelper.GetRandString(4);
			ViewData["RandomStringByPattern"] = RandomHelper.GetRandStringByPattern("JX###???***");

			ViewData["StringHelper-GetHashKey"] = StringHelper.GetHashKey(strMsg, StringFilterOptions.HoldChinese);
			ViewData["StringHelper-GetStringHashKey"] = StringHelper.GetStringHashKey(strMsg);
			ViewData["StringHelper-MD5"] = StringHelper.MD5(strMsg);
			ViewData["StringHelper-MD5D"] = StringHelper.MD5D(strMsg);
			ViewData["StringHelper-MD5GB2312"] = StringHelper.MD5GB2312(strMsg);
			ViewData["StringHelper-SHA1"] = StringHelper.SHA1(strMsg);
			ViewData["StringHelper-ValidateMD5"] = StringHelper.ValidateMD5(strEncryptMd5, StringHelper.MD5(strMsg));

			ViewData["StringHelper-SubString"] = StringHelper.SubString(strMsg, 12, "...");
			ViewData["StringHelper-GetInitial"] = StringHelper.GetInitial(strMsg);
			ViewData["StringHelper-MakeSpellCode"] = ChineseSpell.MakeSpellCode(strMsg, SpellOptions.EnableUnicodeLetter);
			ViewData["StringHelper-FirstLetterOnly"] = ChineseSpell.MakeSpellCode(strMsg, SpellOptions.FirstLetterOnly);

			ViewData["XmlSerializer"] = ConfigHelper.Get<IPLockConfig>().ToXml();
			var strXML = "<IPLockConfig> <AdminLockIPBlack>10.123.123.1</AdminLockIPBlack> <AdminLockIPType>30.123.123.3</AdminLockIPType> <AdminLockIPWhite>20.123.123.2</AdminLockIPWhite> <LockIPType>60.123.123.6</LockIPType> <LockIPBlack>40.123.123.4</LockIPBlack> <LockIPWhite>50.123.123.5</LockIPWhite> </IPLockConfig>";
			var ipLockConfig = strXML.ToXmlObject<IPLockConfig>();
			ViewData["XmlDeserialize"] = "IPLockConfig:" + ipLockConfig.AdminLockIPBlack + " " + ipLockConfig.AdminLockIPType + " " + ipLockConfig.AdminLockIPWhite;

			ViewData["JsonSerializer"] = ConfigHelper.Get<WebHostConfig>().ToJson();
			ConfigHelper.Save(ConfigHelper.Get<ShopConfig>());
			ConfigHelper.Save(ConfigHelper.Get<SiteConfig>());
			ConfigHelper.Save(ConfigHelper.Get<SiteOptionConfig>());
			ConfigHelper.Save(ConfigHelper.Get<SmsConfig>());
			ConfigHelper.Save(ConfigHelper.Get<UserConfig>());
			ConfigHelper.Save(ConfigHelper.Get<WebHostConfig>());
			var strJSON = "{\"AuthenticationType\": 0,\"EnabledSsl\": false,\"MailFrom\": \"2094838895@qq.com\",\"MailServer\": \"smtp.qq.com\",\"MailServerPassWord\": \"lx123456\",\"MailServerUserName\": \"2094838895\",\"Port\": \"25\"}";
			var mailConfig = strJSON.ToJsonObject<MailConfig>();
			ViewData["JsonDeserialize"] = mailConfig.AuthenticationType + " " + mailConfig.EnabledSsl + " " + mailConfig.MailFrom + " " + mailConfig.MailServer;


			CookieHelper.CreateCookie("cName", "aspnetcore"+ strCurrentTime, 10);
			ViewData["CookieHelper"] = CookieHelper.GetCookie("cName");
			//CookieHelper.DeleteCookie("cName");

			DateTime beginDate = new DateTime(2015, 12, 5);
			DateTime endDate = DateTime.Now;
			ViewData["DateDiff-yyyy"] = Utility.DateDiff(beginDate, endDate, "yyyy");
			ViewData["DateDiff-q"] = Utility.DateDiff(beginDate, endDate, "q");
			ViewData["DateDiff-m"] = Utility.DateDiff(beginDate, endDate, "m");
			ViewData["DateDiff-d"] = Utility.DateDiff(beginDate, endDate, "d");
			ViewData["DateDiff-w"] = Utility.DateDiff(beginDate, endDate, "w");
			ViewData["DateDiff-h"] = Utility.DateDiff(beginDate, endDate, "h");
			ViewData["DateDiff-n"] = Utility.DateDiff(beginDate, endDate, "n");
			ViewData["DateDiff-s"] = Utility.DateDiff(beginDate, endDate, "s");

			ViewData["Query-name"] = Utility.Query("name");
			ViewData["Query-date"] = Utility.Query("date", DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss:fff");
			ViewData["Query-age"] = Utility.Query("age", 0);
			ViewData["Query-mobile"] = Utility.AddQuery("mobile", "15871375589");

			var mailConfigSession = ConfigHelper.Get<MailConfig>();
			Utility.SetSession("sessionName", mailConfigSession);

			LogFactory.SaveFileLog("日志标题get", "日志内容");


			return View();
		}

		public IActionResult Config()
		{
			var redisConfig = ConfigHelper.GetAppSettingSection<RedisConfig>();
			ViewData["Msg"] = "RedisConfig:" + redisConfig.IsUseRedis.ToString() + " " + redisConfig.ConnectionString + " " + redisConfig.InstanceName;

			var ipLockConfig = ConfigHelper.Get<IPLockConfig>();
			ViewData["Msg1"] = "IPLockConfig:" + ipLockConfig.AdminLockIPBlack + " " + ipLockConfig.AdminLockIPType + " " + ipLockConfig.AdminLockIPWhite;

			ipLockConfig.AdminLockIPBlack = "10.123.123.1";
			ipLockConfig.AdminLockIPWhite = "20.123.123.2";
			ipLockConfig.AdminLockIPType = "30.123.123.3";
			ipLockConfig.LockIPBlack = "40.123.123.4";
			ipLockConfig.LockIPWhite = "50.123.123.5";
			ipLockConfig.LockIPType = "60.123.123.6";
			ConfigHelper.Save(ipLockConfig);
			var ipLockConfig1 = ConfigHelper.Get<IPLockConfig>();
			ViewData["Msg2"] = "IPLockConfig:" + ipLockConfig1.AdminLockIPBlack + " " + ipLockConfig1.AdminLockIPType + " " + ipLockConfig1.AdminLockIPWhite;

			//var uploadFilesConfig = ConfigHelper.Get<UploadFilesConfig>();
			//ConfigHelper.Save(uploadFilesConfig);

			var mailConfigSession = Utility.GetSession<MailConfig>("sessionName");
			ViewData["SessionValue"] = (mailConfigSession == null) ? "" : mailConfigSession.ToJson();

			return View();
		}

		public IActionResult Mail()
		{
			MailSender sender2 = new MailSender();
			sender2.Subject = "这是一封测试邮件，如果您可以成功收到此邮件，则说明您的“邮件参数配置”设置正确。";
			sender2.MailBody = "这是一封测试邮件，如果您可以成功收到此邮件，则说明您的“邮件参数配置”设置正确。<a href='www.baidu.com'>百度</a>";
			sender2.IsBodyHtml = true;
			sender2.FromName = "lixiong";
			sender2.MailToAddressList.Add(new MailboxAddress("442106890@qq.com"));
			sender2.AttachmentFilePath = Utility.UploadDirPath(true) + "a.rar";
			if (sender2.Send() == MailState.Ok)
			{
				ViewData["msg"] = "邮件发送成功！";
			}
			else
			{
				ViewData["msg"] = sender2.Msg;
			}
			return View();
		}

		public IActionResult ThumbsConfig()
		{
			var thumbsConfig = ConfigHelper.Get<ThumbsConfig>();
			string strMsg = "AddBackColor:" + thumbsConfig.AddBackColor + " ";
			strMsg += "ThumbsMode:" + thumbsConfig.ThumbsMode + " ";
			strMsg += "ThumbsWidth:" + thumbsConfig.ThumbsWidth + " ";
			strMsg += "ThumbsHeight:" + thumbsConfig.ThumbsHeight + " ";
			strMsg += "静态文件目录路径：" + FileHelper.WebRootPath + " ";
			strMsg += "静态文件目录名称：" + FileHelper.WebRootName + " ";
			ViewData["Msg"] = strMsg;

			var thumbUrl = Thumbs.GetThumbUrl(Utility.GetBasePath() + Utility.UploadDirPath() + "test.jpg", true);
			ViewData["ImageUrl"] = Url.Content(thumbUrl);

			var thumbPath = Thumbs.GetThumbPath(Utility.UploadDirPath(true) + "test1.jpg", true);
			ViewData["ImagePath"] = Url.Content(thumbPath);

			var waterMarkConfig = ConfigHelper.Get<WaterMarkConfig>();
			string strWaterMarkMsg = "WaterMarkType:" + waterMarkConfig.WaterMarkType + " ";
			strWaterMarkMsg += "FoneBorder:" + waterMarkConfig.WaterMarkTextInfo.FoneBorder + " ";
			strWaterMarkMsg += "FoneBorderColor:" + waterMarkConfig.WaterMarkTextInfo.FoneBorderColor + " ";
			strWaterMarkMsg += "FoneColor:" + waterMarkConfig.WaterMarkTextInfo.FoneColor + " ";
			strWaterMarkMsg += "FoneSize:" + waterMarkConfig.WaterMarkTextInfo.FoneSize + " ";
			strWaterMarkMsg += "FoneStyle:" + waterMarkConfig.WaterMarkTextInfo.FoneStyle + " ";
			strWaterMarkMsg += "FoneType:" + waterMarkConfig.WaterMarkTextInfo.FoneType + " ";
			strWaterMarkMsg += "Text:" + waterMarkConfig.WaterMarkTextInfo.Text + " ";
			strWaterMarkMsg += "WaterMarkPosition:" + waterMarkConfig.WaterMarkTextInfo.WaterMarkPosition + " ";
			strWaterMarkMsg += "WaterMarkPositionX:" + waterMarkConfig.WaterMarkTextInfo.WaterMarkPositionX + " ";
			strWaterMarkMsg += "WaterMarkPositionY:" + waterMarkConfig.WaterMarkTextInfo.WaterMarkPositionY + " ";

			strWaterMarkMsg += "ImagePath:" + waterMarkConfig.WaterMarkImageInfo.ImagePath + " ";
			strWaterMarkMsg += "Transparence:" + waterMarkConfig.WaterMarkImageInfo.Transparence + " ";
			strWaterMarkMsg += "WaterMarkPercent:" + waterMarkConfig.WaterMarkImageInfo.WaterMarkPercent + " ";
			strWaterMarkMsg += "WaterMarkPercentType:" + waterMarkConfig.WaterMarkImageInfo.WaterMarkPercentType + " ";
			strWaterMarkMsg += "WaterMarkPosition:" + waterMarkConfig.WaterMarkImageInfo.WaterMarkPosition + " ";
			strWaterMarkMsg += "WaterMarkPositionX:" + waterMarkConfig.WaterMarkImageInfo.WaterMarkPositionX + " ";
			strWaterMarkMsg += "WaterMarkPositionY:" + waterMarkConfig.WaterMarkImageInfo.WaterMarkPositionY + " ";
			strWaterMarkMsg += "WaterMarkThumbPercent:" + waterMarkConfig.WaterMarkImageInfo.WaterMarkThumbPercent + " ";
			ViewData["WaterMarkMsg"] = strWaterMarkMsg;

			WaterMark.AddWaterMark(FileHelper.WebRootName + FileHelper.DirectorySeparatorChar + Utility.UploadDirPath() + "test.jpg");
			ViewData["WaterUrl"] = Url.Content(Utility.GetBasePath() + Utility.UploadDirPath() + "test.jpg");

			waterMarkConfig.WaterMarkType = 0;
			waterMarkConfig.WaterMarkTextInfo.Text = "asp.net core";
			ConfigHelper.Save(waterMarkConfig);

			return View();
		}

		public IActionResult Upload()
		{
			return View();
		}

		public IActionResult EFTest()
		{
			SortModelField[] orderByExpression = new SortModelField[2] 
            {
                new SortModelField { SortName = "Province", IsDESC = true },
                new SortModelField { SortName = "City", IsDESC = true }
            };
			var result = _RegionRepository.LoadAll(null, orderByExpression);
			var list = result.ToList();
			AddressEntity address = new AddressEntity();
			//address.AddressID = _AddressRepository.GetMax<int>(p => p.AddressID) + 1;
			//address.UserName = "test";
			//address.ConsigneeName = "张三"+ address.AddressID.ToString();
			//_AddressRepository.Add(address);

			//address = _AddressRepository.Get(p => p.AddressID == 1);
			//address.HomePhone = _AddressRepository.GetScalar<string,int>(p=>p.ConsigneeName, p=>p.AddressID==2,p=>p.AddressID);

			//Expression<Func<AddressDTO, bool>> exp = p=>p.AddressID==1;
			//Expression<Func<Address, bool>> exp2 = exp.Cast<AddressDTO, Address>();
			//address.Mobile = _AddressRepository.IsExist(exp2).ToString();

			//var result = _AddressRepository.GetBySQL<dynamic>("select UserName,ConsigneeName from Address where AddressID=1", (p => new { p.UserName, p.ConsigneeName }));
			//address.Country = result.UserName;
			//address.Province = result.ConsigneeName;

			//address.Area = _AddressRepository.GetMax<int>(p => p.AddressID).ToString();
			//address.Area1 = _AddressRepository.GetMin<int>(p => p.AddressID).ToString();
			//address.Area2 = _AddressRepository.GetAvg(p => p.AddressID).ToString();
			//address.Addresses = _AddressRepository.GetSum(p => p.AddressID).ToString();
			//address.ZipCode = _AddressRepository.GetCount().ToString();

			//var adminEntity = _AdminRepository.GetEntityFull(2);
			//address.HomePhone = adminEntity.RoleNames;
			//address.Mobile = _AdminRepository.GetRoleIDs(2);
			//address.Country = _RoleFieldPermissionsRepository.DeleteFieldPermissionFromRoles(1,1,"a").ToString();
			return View(address);
		}

		public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
