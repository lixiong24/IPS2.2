﻿using JX.Infrastructure.Common;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Diagnostics;
using System.DrawingCore;
using System.DrawingCore.Imaging;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JX.Infrastructure
{
	/// <summary>
	/// 实用工具类
	/// </summary>
	public static class Utility
    {
		#region 得到GET方式提交的参数值
		/// <summary>
		/// 获取查询字符串整型值
		/// </summary>
		/// <param name="query"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		public static int Query(string query, int defaultValue)
		{
			string val = MyHttpContext.Current.Request.Query[query];
			return DataConverter.CLng(val, defaultValue);
		}
		/// <summary>
		/// 获取查询字符串时间值
		/// </summary>
		/// <param name="query"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		public static DateTime Query(string query, DateTime defaultValue)
		{
			string val = MyHttpContext.Current.Request.Query[query];
			return DataConverter.CDate(val, defaultValue);
		}
		/// <summary>
		/// 获取查询字符串数字值
		/// </summary>
		/// <param name="query"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		public static decimal Query(string query, decimal defaultValue)
		{
			string val = MyHttpContext.Current.Request.Query[query];
			return DataConverter.CDecimal(val, defaultValue);
		}
		/// <summary>
		/// 获取查询字符串值，返回值经过WebUtility.UrlDecode方法解码和过滤掉SQL非法字符
		/// </summary>
		/// <param name="query"></param>
		/// <returns></returns>
		public static string Query(string query)
		{
			return Query(query, "");
		}
		/// <summary>
		/// 获取查询字符串值，返回值经过WebUtility.UrlDecode方法解码和过滤掉SQL非法字符
		/// </summary>
		/// <param name="query"></param>
		/// <param name="defaultValue">默认值</param>
		/// <param name="isFilterBadChar">是否对参数值进行WebUtility.UrlDecode方法解码和过滤掉SQL非法字符</param>
		/// <returns></returns>
		public static string Query(string query, string defaultValue,bool isFilterBadChar=true)
		{
			string val = MyHttpContext.Current.Request.Query[query];
			if (string.IsNullOrEmpty(val))
			{
				return defaultValue;
			}
			if(isFilterBadChar)
			{
				val = DataSecurity.FilterBadChar(WebUtility.UrlDecode(val));
			}
			return val;
		}

		/// <summary>
		/// 在当前请求路径后追加查询字符串,如果存在同名则替换
		/// </summary>
		/// <param name="name">查询字符串名</param>
		/// <param name="value">查询字符串值</param>
		/// <returns></returns>
		public static string AddQuery(string name, string value)
		{
			NameValueCollection query = ParseQueryString(MyHttpContext.Current.Request.QueryString.ToString());
			query[name] = value;
			return MyHttpContext.Current.Request.Path + "?" + ParseNameValueCollection(query);
		}
		/// <summary>
		/// 在指定路径后追加查询字符串,如果存在同名则替换
		/// </summary>
		/// <param name="path">要追加查询字符串的路径</param>
		/// <param name="name">要追加的查询字符串名称</param>
		/// <param name="value">要追加的查询字符串值</param>
		/// <returns></returns>
		public static string AddQuery(string path, string name, string value)
		{
			int index = path.IndexOf("?");
			if (index != -1)
			{
				string pathName = path.Substring(0, index);
				string query = path.Substring(index + 1);
				NameValueCollection querys = ParseQueryString(query);
				querys[name] = value;
				return pathName + "?" + ParseNameValueCollection(querys);
			}
			return path + "?" + name + "=" + value;
		}

		/// <summary>
		/// 将查询字符串分析成一个 System.Collections.Specialized.NameValueCollection
		/// </summary>
		/// <param name="query"></param>
		/// <returns></returns>
		public static NameValueCollection ParseQueryString(string query)
		{
			if (query == null)
			{
				throw new ArgumentNullException("query");
			}
			NameValueCollection queryCollection = new NameValueCollection();
			if ((query.Length > 0) && (query[0] == '?'))
			{
				query = query.Substring(1);
			}
			int num = (query != null) ? query.Length : 0;
			for (int i = 0; i < num; i++)
			{
				int startIndex = i;
				int num4 = -1;
				while (i < num)
				{
					char ch = query[i];
					if (ch == '=')
					{
						if (num4 < 0)
						{
							num4 = i;
						}
					}
					else if (ch == '&')
					{
						break;
					}
					i++;
				}
				string str = null;
				string str2 = null;
				if (num4 >= 0)
				{
					str = query.Substring(startIndex, num4 - startIndex);
					str2 = query.Substring(num4 + 1, (i - num4) - 1);
				}
				else
				{
					str2 = query.Substring(startIndex, i - startIndex);
				}
				queryCollection.Add(WebUtility.UrlDecode(str), WebUtility.UrlDecode(str2));
				if ((i == (num - 1)) && (query[i] == '&'))
				{
					queryCollection.Add(null, string.Empty);
				}
			}
			return queryCollection;
		}
		/// <summary>
		/// 将NameValueCollection转换成查询字符串
		/// </summary>
		/// <param name="nvCollection"></param>
		/// <returns></returns>
		public static string ParseNameValueCollection(NameValueCollection nvCollection)
		{
			string queryString = "";
			IEnumerator myEnumerator = nvCollection.GetEnumerator();
			foreach (String strKey in nvCollection.AllKeys)
			{
				queryString += "&" + strKey + "=" + nvCollection[strKey];
			}
			return queryString.TrimStart('&');
		}

		#endregion

		#region 得到POST方式提交的参数值
		/// <summary>
		/// 获取请求变量整型值
		/// </summary>
		/// <param name="name"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		public static int Request(string name, int defaultValue)
		{
			string val = MyHttpContext.Current.Request.Form[name];
			return DataConverter.CLng(val, defaultValue);
		}
		/// <summary>
		/// 获取请求变量小数值
		/// </summary>
		/// <param name="name"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		public static decimal Request(string name, decimal defaultValue)
		{
			string val = MyHttpContext.Current.Request.Form[name];
			return DataConverter.CDecimal(val, defaultValue);
		}
		/// <summary>
		/// 获取请求变量时间值
		/// </summary>
		/// <param name="name"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		public static DateTime Request(string name, DateTime defaultValue)
		{
			string val = MyHttpContext.Current.Request.Form[name];
			return DataConverter.CDate(val, defaultValue);
		}
		/// <summary>
		/// 获取请求变量字符串值，返回值经过WebUtility.UrlDecode方法解码和过滤掉SQL非法字符
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public static string Request(string name)
		{
			return Request(name, "");
		}
		/// <summary>
		/// 获取请求变量字符串值，返回值经过WebUtility.UrlDecode方法解码和过滤掉SQL非法字符
		/// </summary>
		/// <param name="name"></param>
		/// <param name="defaultValue">默认值</param>
		/// <param name="isFilterBadChar">是否对参数值进行WebUtility.UrlDecode方法解码和过滤掉SQL非法字符</param>
		/// <returns></returns>
		public static string Request(string name, string defaultValue, bool isFilterBadChar = true)
		{
			string val = MyHttpContext.Current.Request.Form[name];
			if (string.IsNullOrEmpty(val))
			{
				return defaultValue;
			}
			if (isFilterBadChar)
			{
				val = DataSecurity.FilterBadChar(WebUtility.UrlDecode(val));
			}
			return val;
		}
		#endregion

		#region Session常用方法
		/// <summary>
		/// 设置session值
		/// </summary>
		/// <param name="name"></param>
		/// <param name="value"></param>
		public static void SetSession(string name, object value)
		{
			if (MyHttpContext.Current.Session != null)
			{
				MyHttpContext.Current.Session.Set(name, ObjectToBytes(value));
			}
		}
		/// <summary>
		/// 删除session
		/// </summary>
		/// <param name="name"></param>
		public static void RemoveSession(string name)
		{
			if (MyHttpContext.Current.Session != null)
			{
				MyHttpContext.Current.Session.Remove(name);
			}
		}
		/// <summary>
		/// 获取session值
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public static object GetSession(string name)
		{
			if (MyHttpContext.Current.Session != null)
			{
				byte[] buff;
				if (MyHttpContext.Current.Session.TryGetValue(name,out buff))
				{
					return BytesToObject(buff);
				}
			}
			return null;
		}
		/// <summary>
		/// 获取session值
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="name"></param>
		/// <returns></returns>
		public static T GetSession<T>(string name)
		{
			T t = default(T);
			if (MyHttpContext.Current.Session != null)
			{
				byte[] buff;
				if (MyHttpContext.Current.Session.TryGetValue(name, out buff))
				{
					return BytesToObject<T>(buff);
				}
			}
			return t;
		}
		/// <summary>
		/// 获取int类型的session值
		/// </summary>
		/// <param name="name"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		public static int GetSession(string name, int defaultValue)
		{
			object val = GetSession(name);
			return DataConverter.CLng(val, defaultValue);
		}
		/// <summary>
		/// 获取DateTime类型的session值
		/// </summary>
		/// <param name="name"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		public static DateTime GetSession(string name, DateTime defaultValue)
		{
			object val = GetSession(name);
			return val == null ? defaultValue : DataConverter.CDate(val);
		}
		/// <summary>
		/// 获取会话,转为字符串
		/// </summary>
		/// <param name="name"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		public static string GetSession(string name, string defaultValue)
		{
			object val = GetSession(name);
			return val == null ? defaultValue : val.ToString();
		}
		/// <summary>
		/// 获取bool类型的session值
		/// </summary>
		/// <param name="name"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		public static bool GetSession(string name, bool defaultValue)
		{
			object val = GetSession(name);
			return val == null ? defaultValue : DataConverter.CBoolean(val.ToString());
		}
		#endregion

		#region 从指定URL地址取出页面的名称
		/// <summary>
		/// 从指定URL地址取出页面的名称，不包含后缀名
		/// </summary>
		/// <param name="weburl">url地址</param>
		/// <returns></returns>
		public static string GetPageNameFromUrl(string weburl)
		{
			return GetPageNameFromUrl(weburl, false);
		}
		/// <summary>
		/// 从指定URL地址取出页面的名称
		/// 如果URL不为空,返回URL中的文件名部分,否则返回空字符串
		/// </summary>
		/// <param name="weburl">url地址</param>
		/// <param name="containExt">是否包含后缀名</param>
		/// <returns>如果URL不为空,返回URL中的文件名部分(不包括扩展名),否则返回空字符串</returns>
		public static string GetPageNameFromUrl(string weburl, bool containExt)
		{
			string fileName = string.Empty;
			if (string.IsNullOrEmpty(weburl))
			{
				return fileName;
			}
			if (containExt)
			{
				fileName = Path.GetFileName(weburl);
			}
			else
			{
				fileName = Path.GetFileNameWithoutExtension(weburl);
			}
			return fileName;
		}
		/// <summary>
		/// 获取当前请求的虚拟路径中的页面名称。
		/// </summary>
		/// <param name="containExt">是否包含后缀名</param>
		/// <returns></returns>
		public static string GetPageName(bool containExt)
		{
			string path = MyHttpContext.Current.Request.Path;
			string result = "";
			if (containExt)
			{
				result = Path.GetFileName(path);
			}
			else
			{
				result = Path.GetFileNameWithoutExtension(path);
			}
			return result;
		}
		/// <summary>
		/// 获取当前请求的虚拟路径中的页面名称后缀名。
		/// </summary>
		/// <returns></returns>
		public static string GetPageExtension()
		{
			string path = MyHttpContext.Current.Request.Path;
			return GetPageExtension(path);
		}
		/// <summary>
		/// 获取指定路径中的页面名称后缀名
		/// </summary>
		/// <param name="weburl"></param>
		/// <returns></returns>
		public static string GetPageExtension(string weburl)
		{
			return Path.GetExtension(weburl);
		}
		#endregion

		#region 判断页面后缀名
		/// <summary>
		/// 判断accessingurl是否以path开头，并且以"aspx"或"/"结尾。
		/// </summary>
		/// <param name="accessingurl">访问URL</param>
		/// <param name="path"></param>
		/// <returns></returns>
		public static bool AccessingPath(string accessingurl, string path)
		{
			bool flag = accessingurl.StartsWith(path, StringComparison.CurrentCultureIgnoreCase);
			bool flag2 = accessingurl.EndsWith("aspx", StringComparison.CurrentCultureIgnoreCase);
			bool flag3 = accessingurl.EndsWith("/", StringComparison.CurrentCultureIgnoreCase);
			if (!flag)
			{
				return false;
			}
			if (!flag2)
			{
				return flag3;
			}
			return true;
		}
		/// <summary>
		/// 判断当前请求页是否为指定类型页:如 .aspx ,.htm ,.ashx
		/// </summary>       
		/// <param name="suffix">指定的页面类型。如：.aspx ,.htm ,.ashx</param>
		/// <returns></returns>
		public static bool AccessingPage(string suffix)
		{
			string filePath = MyHttpContext.Current.Request.Path.Value;

			return AccessingPage(filePath, suffix);
		}
		/// <summary>
		/// 判断指定URL是否为指定类型页:如 .aspx ,.htm ,.ashx
		/// </summary>
		/// <param name="accessingUrl">带后缀名的页面路径，如果没有后缀名返回FALSE</param>
		/// <param name="suffix">指定的页面类型。如：.aspx ,.htm ,.ashx</param>
		/// <returns></returns>
		public static bool AccessingPage(string accessingUrl, string suffix)
		{
			if (string.IsNullOrEmpty(accessingUrl) || string.IsNullOrEmpty(suffix))
			{
				return false;
			}
			string extension = Path.GetExtension(accessingUrl).ToLower();
			if (extension == suffix.ToLower())
			{
				return true;
			}
			return false;
		}
		#endregion

		#region 页面消息提示

		#region 显示普通消息
		/// <summary>
		/// 显示普通消息
		/// </summary>
		/// <param name="message">消息内容</param>
		/// <param name="returnurl">返回页面地址</param>
		/// <param name="messageTitle">消息标题</param>
		/// <param name="pageUrl">显示消息的页面地址</param>
		public static void WriteMessage(string message, string returnurl="", string messageTitle= "消息提示", string pageUrl= "/Admin/Home/ShowMessage")
		{
			SetSession("Message", message);
			SetSession("ReturnUrl", returnurl);
			SetSession("MessageTitle", messageTitle);
			MyHttpContext.Current.Response.Redirect(pageUrl);
		}
		#endregion

		#region 显示错误消息
		/// <summary>
		/// 显示错误消息
		/// </summary>
		/// <param name="errorMessage">消息内容</param>
		/// <param name="returnurl">返回页面地址</param>
		/// <param name="pageUrl">显示消息的页面地址</param>
		public static void WriteErrMsg(string errorMessage, string returnurl= "mClose", string pageUrl= "/Admin/Home/ShowMessage")
		{
			WriteMessage(errorMessage, returnurl, "错误消息", pageUrl);
		}
		/// <summary>
		/// 会员中心显示错误消息。页面："~/User/ShowError"。
		/// </summary>
		/// <param name="errorMessage">消息内容</param>
		/// <param name="returnurl">返回页面地址</param>
		public static void WriteUserErrMsg(string errorMessage, string returnurl = "mClose")
		{
			WriteErrMsg(errorMessage, returnurl, "/User/ShowMessage");
		}
		/// <summary>
		/// 网站前台显示错误消息。页面："~/Home/ShowError"。
		/// </summary>
		/// <param name="errorMessage"></param>
		/// <param name="returnurl"></param>
		public static void WriteFrontErrMsg(string errorMessage, string returnurl = "mClose")
		{
			WriteErrMsg(errorMessage, returnurl, "/Home/ShowMessage");
		}
		#endregion

		#region 显示成功消息
		/// <summary>
		/// 显示成功消息
		/// </summary>
		/// <param name="successMessage">消息内容</param>
		/// <param name="returnurl">返回页面地址</param>
		/// <param name="pageUrl">显示消息的页面地址</param>
		public static void WriteSuccessMsg(string successMessage, string returnurl= "mRefresh", string pageUrl = "/Admin/Home/ShowMessage")
		{
			WriteMessage(successMessage, returnurl,"成功消息",pageUrl);
		}
		/// <summary>
		/// 会员中心显示成功消息。页面："~/User/ShowSuccess"。
		/// </summary>
		/// <param name="successMessage">消息内容</param>
		/// <param name="returnurl">返回页面地址</param>
		public static void WriteUserSuccessMsg(string successMessage, string returnurl = "mRefresh")
		{
			WriteSuccessMsg(successMessage, returnurl, "/User/ShowMessage");
		}
		/// <summary>
		/// 网站前台显示成功消息。页面："~/Home/ShowSuccess"。
		/// </summary>
		/// <param name="successMessage"></param>
		/// <param name="returnurl"></param>
		public static void WriteFrontSuccessMsg(string successMessage, string returnurl = "mRefresh")
		{
			WriteSuccessMsg(successMessage, returnurl, "/Home/ShowMessage");
		}
		#endregion

		#endregion

		#region 得到程序路径
		/// <summary>
		/// 得到当前应用程序名（例：http://www.baidu.com）
		/// </summary>
		/// <returns></returns>
		public static string GetApplicationName()
		{
			var request = MyHttpContext.Current.Request;
			return new StringBuilder()
				.Append(request.Scheme)
				.Append("://")
				.Append(request.Host)
				.ToString();
		}
		/// <summary>
		/// 得到当前的完整URL
		/// </summary>
		/// <returns></returns>
		public static string GetAbsoluteUri()
		{
			var request = MyHttpContext.Current.Request;
			return new StringBuilder()
				.Append(request.Scheme)
				.Append("://")
				.Append(request.Host)
				.Append(request.PathBase)
				.Append(request.Path)
				.Append(request.QueryString)
				.ToString();
		}
		/// <summary>
		/// 获取应用程序根路径，从config/SiteConfig.json文件中得到： / 或 /shop/
		/// </summary>
		/// <returns></returns>
		public static string GetBasePath()
		{
			return ConfigHelper.Get<SiteConfig>().VirtualPath;
		}
		/// <summary>
		/// 获取 应用程序根路径+relativePath 的路径
		/// </summary>
		/// <param name="relativePath">相对路径：相对于应用程序根路径</param>
		/// <returns></returns>
		public static string GetBasePath(object relativePath)
		{
			if (DataValidator.IsNull(relativePath))
			{
				return GetBasePath();
			}
			return GetBasePath() + relativePath;
		}

		/// <summary>
		/// 得到当前应用程序根路径的物理路径
		/// </summary>
		/// <returns></returns>
		public static string PhyPath()
		{
			return PhyPath("");
		}
		/// <summary>
		/// 得到指定地址的物理绝对路径
		/// </summary>
		/// <param name="relativePath">相对于网站根目录的相对地址</param>
		/// <returns></returns>
		public static string PhyPath(string relativePath)
		{
			string appPath = GetBasePath(relativePath);
			string phyPath = FileHelper.MapPath(appPath);
			return phyPath;
		}

		/// <summary>
		/// 得到上传目录名称
		/// </summary>
		/// <returns></returns>
		public static string UploadDir()
		{
			return ConfigHelper.Get<UploadFilesConfig>().UploadDir;
		}
		/// <summary>
		/// 得到上传目录路径。
		/// IsStaticDir为false时，返回：UploadFiles/；
		/// IsStaticDir为true时，返回：F:\WebHost\wwwroot/UploadFiles/；
		/// </summary>
		/// <param name="IsStaticDir">是否添加静态文件目录到上传目录名称前面</param>
		/// <returns></returns>
		public static string UploadDirPath(bool IsStaticDir = false)
		{
			var UploadDir = ConfigHelper.Get<UploadFilesConfig>().UploadDir;
			if (!string.IsNullOrEmpty(UploadDir) && !UploadDir.EndsWith("/"))
			{
				UploadDir = UploadDir + "/";
			}
			if (IsStaticDir)
			{
				UploadDir = FileHelper.WebRootPath + FileHelper.DirectorySeparatorChar + UploadDir;
			}
			return UploadDir;

		}
		#endregion

		#region 日期时间处理
		/// <summary>
		/// 是否同年同月同日
		/// </summary>
		/// <param name="d1">日期1</param>
		/// <param name="d2">日期2</param>
		/// <returns></returns>
		public static bool IsSameDay(DateTime d1, DateTime d2)
		{
			return d1.Date.Equals(d2.Date);
		}

		/// <summary>
		/// 是否同一周，星期一为一周的开始
		/// </summary>
		/// <param name="d1">日期1</param>
		/// <param name="d2">日期2</param>
		/// <returns></returns>
		public static bool IsSameWeek(DateTime d1, DateTime d2)
		{
			return IsSameWeek(d1, d2, true);
		}
		/// <summary>
		/// 是否同一周
		/// </summary>
		/// <param name="d1">日期1</param>
		/// <param name="d2">日期2</param>
		/// <param name="b">是否表示星期一为一周的开始</param>
		/// <returns></returns>
		public static bool IsSameWeek(DateTime d1, DateTime d2, bool b)
		{
			bool bFlag = false;
			if (b)
			{
				if (d1.DayOfWeek == DayOfWeek.Sunday)
				{
					d1 = d1.AddDays(-1);
				}
				if (d2.DayOfWeek == DayOfWeek.Sunday)
				{
					d2 = d2.AddDays(-1);
				}
			}
			TimeSpan t = d1 > d2 ? d1 - d2 : d2 - d1;
			if (t.Days <= 7 && t.Days == (d2 > d1 ? d2.DayOfWeek - d1.DayOfWeek : d1.DayOfWeek - d2.DayOfWeek))
			{
				bFlag = true;
			}
			else
			{
				bFlag = false;
			}
			return bFlag;
		}

		/// <summary>
		/// 是否同年同月
		/// </summary>
		/// <param name="d1">日期1</param>
		/// <param name="d2">日期2</param>
		/// <returns></returns>
		public static bool IsSameMonth(DateTime d1, DateTime d2)
		{
			if (d1.Year == d2.Year && d1.Month == d2.Month)
			{
				return true;
			}
			return false;
		}

		/// <summary>
		/// 返回跨两个指定日期的日期和时间边界数。间隔数=结束时间-开始时间；结束时间比开始时间晚，返回大于0的值，否则，返回小于0的值。
		/// </summary>
		/// <param name="startDate">开始日期</param>
		/// <param name="endDate">结束日期</param>
		/// <param name="interval">间隔标志,是规定了应在日期的哪一部分计算差额的参数。（yyyy：年、q：季度、m：月、y：一年的日数、d：日、w：一周的日数、ww：周、h：时、n：分、s：秒）</param>
		/// <returns>返回间隔标志指定的时间间隔</returns>
		public static long DateDiff(DateTime startDate, DateTime endDate, string interval)
		{
			long lngDateDiffValue = 0;
			TimeSpan TS = new TimeSpan(endDate.Ticks - startDate.Ticks);
			switch (interval)
			{
				case "s":
					lngDateDiffValue = (long)TS.TotalSeconds;
					break;
				case "n":
					lngDateDiffValue = (long)TS.TotalMinutes;
					break;
				case "h":
					lngDateDiffValue = (long)TS.TotalHours;
					break;
				case "d":
					lngDateDiffValue = (long)TS.Days;
					break;
				case "w":
					lngDateDiffValue = (long)(TS.Days / 7);
					break;
				case "m":
					lngDateDiffValue = (long)(endDate.Month - startDate.Month) + (12 * (endDate.Year - startDate.Year));
					break;
				case "q":
					lngDateDiffValue = (long)(((endDate.Month - startDate.Month) + (12 * (endDate.Year - startDate.Year))) / 3);
					break;
				case "yyyy":
					lngDateDiffValue = (long)(endDate.Year - startDate.Year);
					break;
			}
			return (lngDateDiffValue);
		}
		#endregion

		#region 时间戳
		/// <summary>
		/// 得到当前时间戳(ms)
		/// </summary>
		/// <returns></returns>
		public static long CurrentTimeMillis()
		{
			return (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
		}
		/// <summary>
		/// 时间戳转为C#格式时间
		/// </summary>
		/// <param name="timeStamp">Unix时间戳格式</param>
		/// <returns>C#格式时间</returns>
		public static DateTime GetTimeByTimeStamp(string timeStamp)
		{
			DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc));
			long lTime = long.Parse(timeStamp);
			if (timeStamp.Length == 13)
			{
				return dtStart.AddMilliseconds(lTime);
			}
			else if (timeStamp.Length == 10)
			{
				return dtStart.AddSeconds(lTime);
			}
			else
			{
				return dtStart.AddMilliseconds(lTime);
			}
		}
		#endregion

		#region 获得客户端IP和浏览器信息
		/// <summary>
		/// 获得客户端IP
		/// </summary>
		/// <returns></returns>
		public static string GetClientIP()
		{
			return IPHelper.GetClientIP();
		}
		/// <summary>
		/// 得到本地主机IPV4地址
		/// </summary>
		/// <returns></returns>
		public static string GetHostIP()
		{
			return IPHelper.GetHostIP();
		}

		/// <summary>
		/// 获取客户端使用的 HTTP 数据传输方法（GET 或 POST）。没有信息返回空。
		/// </summary>
		/// <returns></returns>
		public static string GetRequestType()
		{
			if (MyHttpContext.Current.Request != null)
			{
				return MyHttpContext.Current.Request.Method;
			}
			return "";
		}
		#endregion

		#region Bytes与Object的互相转换
		/// <summary>
		/// 将对象转换为byte数组
		/// </summary>
		/// <param name="obj">被转换对象</param>
		/// <returns>转换后byte数组</returns>
		public static byte[] ObjectToBytes(object obj)
		{
			string json = JsonConvert.SerializeObject(obj);
			byte[] serializedResult = Encoding.UTF8.GetBytes(json);
			return serializedResult;
		}

		/// <summary>
		/// 将byte数组转换成对象
		/// </summary>
		/// <param name="buff">被转换byte数组</param>
		/// <returns>转换完成后的对象</returns>
		public static object BytesToObject(byte[] buff)
		{
			string json = Encoding.UTF8.GetString(buff);
			return JsonConvert.DeserializeObject<object>(json);
		}

		/// <summary>
		/// 将byte数组转换成对象
		/// </summary>
		/// <param name="buff">被转换byte数组</param>
		/// <returns>转换完成后的对象</returns>
		public static T BytesToObject<T>(byte[] buff)
		{
			string json = Encoding.UTF8.GetString(buff);
			return JsonConvert.DeserializeObject<T>(json);
		}
		#endregion

		#region 数据库字段的类型与C#数据类型的转换
		/// <summary>
		/// 转换Type类型为对应的DbType类型
		/// </summary>
		/// <param name="t"></param>
		/// <returns></returns>
		public static DbType TypeToDbType(Type t)
		{
			DbType dbt;
			try
			{
				dbt = (DbType)Enum.Parse(typeof(DbType), t.Name);
			}
			catch
			{
				dbt = DbType.Object;
			}
			return dbt;
		}
		/// <summary>
		/// 转换DbType类型为对应的Type类型
		/// </summary>
		/// <param name="dbType"></param>
		/// <returns></returns>
		public static Type DbTypeToType(DbType dbType)
		{
			Type toReturn = typeof(DBNull);
			switch (dbType)
			{
				case DbType.UInt64:
					toReturn = typeof(UInt64);
					break;

				case DbType.Int64:
					toReturn = typeof(Int64);
					break;

				case DbType.Int32:
					toReturn = typeof(Int32);
					break;

				case DbType.UInt32:
					toReturn = typeof(UInt32);
					break;

				case DbType.Single:
					toReturn = typeof(float);
					break;

				case DbType.Date:
				case DbType.DateTime:
				case DbType.Time:
					toReturn = typeof(DateTime);
					break;

				case DbType.String:
				case DbType.StringFixedLength:
				case DbType.AnsiString:
				case DbType.AnsiStringFixedLength:
					toReturn = typeof(string);
					break;

				case DbType.UInt16:
					toReturn = typeof(UInt16);
					break;

				case DbType.Int16:
					toReturn = typeof(Int16);
					break;

				case DbType.SByte:
					toReturn = typeof(byte);
					break;

				case DbType.Object:
					toReturn = typeof(object);
					break;

				case DbType.VarNumeric:
				case DbType.Decimal:
					toReturn = typeof(decimal);
					break;

				case DbType.Currency:
					toReturn = typeof(double);
					break;

				case DbType.Binary:
					toReturn = typeof(byte[]);
					break;

				case DbType.Double:
					toReturn = typeof(Double);
					break;

				case DbType.Guid:
					toReturn = typeof(Guid);
					break;

				case DbType.Boolean:
					toReturn = typeof(bool);
					break;
			}

			return toReturn;
		}
		#endregion

		#region 保存上传文件
		/// <summary>
		/// 客户端通过AJAX文件，上传文件到指定位置。成功则通过ResultInfo.Data返回文件名。会从UploadFilesConfig文件中取值进行后缀名、文件大小的判断。
		/// </summary>
		/// <param name="file">上传控件(从Request.Form.Files[0]得到)</param>
		/// <param name="fileDir">保存文件目录，不存在则创建。(不带文件名，相对于网站静态文件目录。如：UploadFiles/Photo/)。不指定时，从UploadFilesConfig文件中取值</param>
		/// <param name="allowedExtensions">允许上传的文件后缀名，多个后缀名用“,”分割（如：jpg,swf,flv）。不指定时，从UploadFilesConfig文件中取值</param>
		/// <param name="fileNameMode">文件名模式：{$Origin}：原文件名；{$Random}：随机数。不指定时，从UploadFilesConfig文件中取值</param>
		/// <param name="isThumb">是否生成缩略图</param>
		/// <param name="isWaterMark">是否添加水印</param>
		/// <returns></returns>
		public static async Task<ResultInfo> FileUploadSaveAs(IFormFile file, string fileDir="", string allowedExtensions="", string fileNameMode="",bool isThumb=false,bool isWaterMark=false)
		{
			ResultInfo resultInfo = new ResultInfo();
			try
			{
				if (file == null || file.Length <= 0)
				{
					resultInfo.Status = 0;
					resultInfo.Msg = "上传内容不存在";
					return resultInfo;
				}

				var uploadFilesConfig = ConfigHelper.Get<UploadFilesConfig>();
				#region 得到上传目录名
				if (string.IsNullOrEmpty(fileDir))
				{
					fileDir = uploadFilesConfig.UploadDir;
				}
				switch (FileHelper.DirectorySeparatorChar)
				{
					case "/"://Mac OS and Linux
						fileDir = fileDir.Replace("\\", FileHelper.DirectorySeparatorChar);
						break;
					case "\\"://WINDOWS
						fileDir = fileDir.Replace("/", FileHelper.DirectorySeparatorChar);
						break;
				}
				if (fileDir.Substring(fileDir.Length - 1, 1) != FileHelper.DirectorySeparatorChar)
				{
					fileDir = fileDir + FileHelper.DirectorySeparatorChar;
				}
				FileHelper.CreateFileFolder(FileHelper.WebRootPath + FileHelper.DirectorySeparatorChar + fileDir);
				#endregion
				#region 得到允许上传的文件后缀名
				if (string.IsNullOrEmpty(allowedExtensions))
				{
					allowedExtensions = uploadFilesConfig.UploadFileExts;
				}
				allowedExtensions = allowedExtensions.Replace('|', ',');
				string[] arrExte = allowedExtensions.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
				string strExte = file.FileName.Substring(file.FileName.LastIndexOf(".") + 1).ToLower();
				if (!StringHelper.Contains(arrExte, strExte))
				{
					resultInfo.Status = 0;
					resultInfo.Msg = "只能上传" + allowedExtensions + "类型的文件！";
					return resultInfo;
				}
				#endregion
				#region 检查上传文件大小是否超出范围
				int uploadFileMaxSize = uploadFilesConfig.UploadFileMaxSize;//允许上传文件的最大KB数
				if (file.Length > (uploadFileMaxSize * 1024))
				{
					resultInfo.Status = 0;
					resultInfo.Msg = "文件大小超出范围，只能上传" + uploadFileMaxSize + "KB以内的文件！";
					return resultInfo;
				}
				#endregion
				#region 得到文件名
				if (string.IsNullOrEmpty(fileNameMode))
				{
					fileNameMode = uploadFilesConfig.UploadFileName;
				}
				string strFile = fileNameMode.Replace("{$Year}", DateTime.Now.Year.ToString())
					.Replace("{$Month}", DateTime.Now.Month.ToString())
					.Replace("{$Day}", DateTime.Now.Day.ToString())
					.Replace("{$Hour}", DateTime.Now.Hour.ToString())
					.Replace("{$Minute}", DateTime.Now.Minute.ToString())
					.Replace("{$Second}", DateTime.Now.Second.ToString())
					.Replace("{$Origin}", file.FileName.Substring(0, file.FileName.LastIndexOf(".")))
					.Replace("{$Random}", DataSecurity.MakeFileRndName());
				#endregion
				string strFileName = strFile + "." + strExte;
				string filePath = FileHelper.WebRootPath + FileHelper.DirectorySeparatorChar + fileDir + strFileName;
				using (var stream = new FileStream(filePath, FileMode.Create))
				{
					await file.CopyToAsync(stream);
				}
				if (isWaterMark)
				{
					WaterMark.AddWaterMark(FileHelper.WebRootName + FileHelper.DirectorySeparatorChar + fileDir + strFileName);
				}
				if (isThumb)
				{
					Thumbs.GetThumbUrl("/" + fileDir.Replace(FileHelper.DirectorySeparatorChar, "/") + strFileName, true);
				}
				resultInfo.Status = 1;
				resultInfo.Msg = "上传成功";
				resultInfo.Data = strFileName;
				return resultInfo;
			}
			catch(Exception ex)
			{
				resultInfo.Status = 0;
				resultInfo.Msg = ex.Message;
				return resultInfo;
			}
		}
		#endregion

		#region 分期付款算法
		/// <summary>
		/// 方式：等额本金还款。返回：交错数组:(1.月还款额,2.月利息)
		/// </summary>
		/// <param name="nDeadline">期限</param>
		/// <param name="fMoney">总金额</param>
		/// <param name="yRate">年利率(例：7%请输入0.07)</param>
		/// <returns>交错数组:(1.月还款额,2.月利息)</returns>
		public static double[][] F_MonthMoney(int nDeadline, double fMoney, double yRate)
		{
			double[][] arr = new double[2][];//声明交错数组

			double[] fPrincipal = new double[nDeadline]; //本金
			double[] fSparePrin = new double[nDeadline];//剩余本金
			double[] fMonthRate = new double[nDeadline];//月利息
			double[] fMonthMoney = new double[nDeadline];//月还款额

			for (int i = 0; i < nDeadline; i++)
			{
				fPrincipal[i] = fMoney / nDeadline;
				if (i == 0)
				{
					fSparePrin[i] = fMoney - fPrincipal[i];//剩余本金
					fMonthRate[i] = Math.Round(fMoney * (yRate / 12), 2);//月利息
				}
				else
				{
					fSparePrin[i] = fSparePrin[i - 1] - fPrincipal[i];//剩余本金
					fMonthRate[i] = Math.Round(fSparePrin[i - 1] * (yRate / 12), 2);//月利息=上个月的剩余本金×利率
				}

				fMonthMoney[i] = Math.Round(fPrincipal[i] + fMonthRate[i], 2);
			}

			arr[0] = fMonthMoney;//月还款
			arr[1] = fMonthRate;//月利息

			return arr;
		}
		/// <summary>
		/// 方式：等额本息还款。返回：交错数组:(1.月还款额,2.月本金，3.月利息)
		/// </summary>
		/// <param name="nDeadline">期限</param>
		/// <param name="fMoney">总金额</param>
		/// <param name="yRate">年利率(例：7%请输入0.07)</param>
		/// <returns>交错数组:(1.月还款额,2.月本金，3.月利息)</returns>
		public static double[][] D_TotalMoney(int nDeadline, double fMoney, double yRate)
		{
			double[][] arr = new double[3][];//声明交错数组

			int i;
			double tlnAcct = 0, tdepAcct = 0;

			double[] lnAcctbal = new double[nDeadline]; /*贷款余额*/
			double[] depAcctbal = new double[nDeadline]; /*总还款*/
			double[] payrateAcct = new double[nDeadline]; /*每月应还利息*/
			double[] payAcct = new double[nDeadline]; /*每月应还款*/
			double[] paybaseAcct = new double[nDeadline]; /*每月应还本金*/

			tlnAcct = fMoney;

			for (i = 0; i < nDeadline; i++)
			{
				paybaseAcct[i] = Math.Round((Math.Pow((1 + yRate / 12), i + 1) - Math.Pow((1 + yRate / 12), i)) / (Math.Pow((1 + yRate / 12), nDeadline) - 1) * fMoney, 2);
				payrateAcct[i] = Math.Round(tlnAcct * yRate / 12, 2);
				payAcct[i] = Math.Round(paybaseAcct[i] + payrateAcct[i], 2);
				lnAcctbal[i] = tlnAcct - paybaseAcct[i];
				depAcctbal[i] = tdepAcct + payAcct[i];
				tdepAcct = depAcctbal[i];
				tlnAcct = tlnAcct - paybaseAcct[i];
			}

			arr[0] = payAcct;//月还款
			arr[1] = paybaseAcct;//月本金
			arr[2] = payrateAcct;//月利息

			return arr;
		}
		#endregion

		#region 身份证相关算法
		/// <summary>
		/// 从身份证中提取生日，成功返回生日，失败返回1900-01-01。
		/// </summary>
		/// <param name="IDCard">身份证</param>
		/// <returns></returns>
		public static DateTime GetBirthdayByIDCard(string IDCard)
		{
			if (!DataValidator.IsIDCard(IDCard))
			{
				return DataConverter.CDate("1900-01-01");
			}
			string year = IDCard.Substring(6, 4);
			string month = IDCard.Substring(10, 2);
			string date = IDCard.Substring(12, 2);
			string result = year + "-" + month + "-" + date;
			DateTime Birthday;
			if (!DateTime.TryParse(result, out Birthday))
			{
				Birthday = DataConverter.CDate("1900-01-01");
			}
			return Birthday;
		}
		/// <summary>
		/// 从身份证中提取年龄
		/// </summary>
		/// <param name="IDCard"></param>
		/// <returns></returns>
		public static int GetAgeByIDCard(string IDCard)
		{
			DateTime birthday = GetBirthdayByIDCard(IDCard);
			int age = (int)DateDiff(birthday, DateTime.Now, "yyyy");
			if (DateTime.Now.Month < birthday.Month || (DateTime.Now.Month == birthday.Month && DateTime.Now.Day < birthday.Day))
			{
				age--;
			}
			return age;
		}
		/// <summary>
		/// 根据生日得到年龄
		/// </summary>
		/// <param name="birthday"></param>
		/// <returns></returns>
		public static int GetAgeByBirthday(DateTime birthday)
		{
			int age = (int)DateDiff(birthday, DateTime.Now, "yyyy");
			if (DateTime.Now.Month < birthday.Month || (DateTime.Now.Month == birthday.Month && DateTime.Now.Day < birthday.Day))
			{
				age--;
			}
			return age;
		}
		/// <summary>
		/// 从身份证中提取性别，0：未知；1：男；2：女。
		/// </summary>
		/// <param name="IDCard"></param>
		/// <returns></returns>
		public static int GetSexByIDCard(string IDCard)
		{
			if (!DataValidator.IsIDCard(IDCard))
			{
				return 0;
			}
			int sex = 0;
			int lastCode = -1;
			if (IDCard.Length == 15)
			{
				lastCode = DataConverter.CLng(IDCard.Substring(IDCard.Length - 1, 1), -1);
			}
			else if (IDCard.Length == 18)
			{
				lastCode = DataConverter.CLng(IDCard.Substring(16, 1), -1);
			}
			if (lastCode > -1)
			{
				if (lastCode % 2 == 0)
				{
					sex = 2;
				}
				else
				{
					sex = 1;
				}
			}
			return sex;
		}
		/// <summary>
		/// 从身份证中提取地址，返回数组：省、市、区
		/// </summary>
		/// <param name="IDCard"></param>
		/// <returns></returns>
		public static string[] GetAddressByIDCard(string IDCard)
		{
			#region 所有省市区列表
			Dictionary<string, string> dic = new Dictionary<string, string>();
			dic.Add("110000", "北京市");
			dic.Add("120000", "天津市");
			dic.Add("130000", "河北省");
			dic.Add("140000", "山西省");
			dic.Add("150000", "内蒙古");
			dic.Add("210000", "辽宁省");
			dic.Add("220000", "吉林省");
			dic.Add("230000", "黑龙江");
			dic.Add("310000", "上海市");
			dic.Add("320000", "江苏省");
			dic.Add("330000", "浙江省");
			dic.Add("340000", "安徽省");
			dic.Add("350000", "福建省");
			dic.Add("360000", "江西省");
			dic.Add("370000", "山东省");
			dic.Add("410000", "河南省");
			dic.Add("420000", "湖北省");
			dic.Add("430000", "湖南省");
			dic.Add("440000", "广东省");
			dic.Add("450000", "广西");
			dic.Add("460000", "海南省");
			dic.Add("500000", "重庆市");
			dic.Add("510000", "四川省");
			dic.Add("520000", "贵州省");
			dic.Add("530000", "云南省");
			dic.Add("540000", "西藏");
			dic.Add("610000", "陕西省");
			dic.Add("620000", "甘肃省");
			dic.Add("630000", "青海省");
			dic.Add("640000", "宁夏");
			dic.Add("650000", "新疆");
			dic.Add("710000", "台湾省");
			dic.Add("810000", "香港");
			dic.Add("820000", "澳门");
			dic.Add("110100", "北京市");
			dic.Add("130100", "石家庄市");
			dic.Add("130200", "唐山市");
			dic.Add("130300", "秦皇岛市");
			dic.Add("130400", "邯郸市");
			dic.Add("130500", "邢台市");
			dic.Add("130600", "保定市");
			dic.Add("130700", "张家口市");
			dic.Add("130800", "承德市");
			dic.Add("130900", "沧州市");
			dic.Add("131000", "廊坊市");
			dic.Add("131100", "衡水市");
			dic.Add("140100", "太原市");
			dic.Add("140200", "大同市");
			dic.Add("140300", "阳泉市");
			dic.Add("140400", "长治市");
			dic.Add("140500", "晋城市");
			dic.Add("140600", "朔州市");
			dic.Add("140700", "晋中市");
			dic.Add("140800", "运城市");
			dic.Add("140900", "忻州市");
			dic.Add("141000", "临汾市");
			dic.Add("141100", "吕梁市");
			dic.Add("150100", "呼和浩特市");
			dic.Add("150200", "包头市");
			dic.Add("150300", "乌海市");
			dic.Add("150400", "赤峰市");
			dic.Add("150500", "通辽市");
			dic.Add("150600", "鄂尔多斯市");
			dic.Add("150700", "呼伦贝尔市");
			dic.Add("150800", "巴彦淖尔市");
			dic.Add("150900", "乌兰察布市");
			dic.Add("152200", "兴安盟");
			dic.Add("152500", "锡林郭勒盟");
			dic.Add("152900", "阿拉善盟");
			dic.Add("210100", "沈阳市");
			dic.Add("210200", "大连市");
			dic.Add("210300", "鞍山市");
			dic.Add("210400", "抚顺市");
			dic.Add("210500", "本溪市");
			dic.Add("210600", "丹东市");
			dic.Add("210700", "锦州市");
			dic.Add("210800", "营口市");
			dic.Add("210900", "阜新市");
			dic.Add("211000", "辽阳市");
			dic.Add("211100", "盘锦市");
			dic.Add("211200", "铁岭市");
			dic.Add("211300", "朝阳市");
			dic.Add("211400", "葫芦岛市");
			dic.Add("220100", "长春市");
			dic.Add("220200", "吉林市");
			dic.Add("220300", "四平市");
			dic.Add("220400", "辽源市");
			dic.Add("220500", "通化市");
			dic.Add("220600", "白山市");
			dic.Add("220700", "松原市");
			dic.Add("220800", "白城市");
			dic.Add("222400", "延边朝鲜族自治州");
			dic.Add("230100", "哈尔滨市");
			dic.Add("230200", "齐齐哈尔市");
			dic.Add("230300", "鸡西市");
			dic.Add("230400", "鹤岗市");
			dic.Add("230500", "双鸭山市");
			dic.Add("230600", "大庆市");
			dic.Add("230700", "伊春市");
			dic.Add("230800", "佳木斯市");
			dic.Add("230900", "七台河市");
			dic.Add("231000", "牡丹江市");
			dic.Add("231100", "黑河市");
			dic.Add("231200", "绥化市");
			dic.Add("232700", "大兴安岭地区");
			dic.Add("310100", "市辖区");
			dic.Add("310200", "县");
			dic.Add("320100", "南京市");
			dic.Add("320200", "无锡市");
			dic.Add("320300", "徐州市");
			dic.Add("320400", "常州市");
			dic.Add("320500", "苏州市");
			dic.Add("320600", "南通市");
			dic.Add("320700", "连云港市");
			dic.Add("320800", "淮安市");
			dic.Add("320900", "盐城市");
			dic.Add("321000", "扬州市");
			dic.Add("321100", "镇江市");
			dic.Add("321200", "泰州市");
			dic.Add("321300", "宿迁市");
			dic.Add("330100", "杭州市");
			dic.Add("330200", "宁波市");
			dic.Add("330300", "温州市");
			dic.Add("330400", "嘉兴市");
			dic.Add("330500", "湖州市");
			dic.Add("330600", "绍兴市");
			dic.Add("330700", "金华市");
			dic.Add("330800", "衢州市");
			dic.Add("330900", "舟山市");
			dic.Add("331000", "台州市");
			dic.Add("331100", "丽水市");
			dic.Add("340100", "合肥市");
			dic.Add("340200", "芜湖市");
			dic.Add("340300", "蚌埠市");
			dic.Add("340400", "淮南市");
			dic.Add("340500", "马鞍山市");
			dic.Add("340600", "淮北市");
			dic.Add("340700", "铜陵市");
			dic.Add("340800", "安庆市");
			dic.Add("341000", "黄山市");
			dic.Add("341100", "滁州市");
			dic.Add("341200", "阜阳市");
			dic.Add("341300", "宿州市");
			dic.Add("341400", "巢湖市");
			dic.Add("341500", "六安市");
			dic.Add("341600", "亳州市");
			dic.Add("341700", "池州市");
			dic.Add("341800", "宣城市");
			dic.Add("350100", "福州市");
			dic.Add("350200", "厦门市");
			dic.Add("350300", "莆田市");
			dic.Add("350400", "三明市");
			dic.Add("350500", "泉州市");
			dic.Add("350600", "漳州市");
			dic.Add("350700", "南平市");
			dic.Add("350800", "龙岩市");
			dic.Add("350900", "宁德市");
			dic.Add("360100", "南昌市");
			dic.Add("360200", "景德镇市");
			dic.Add("360300", "萍乡市");
			dic.Add("360400", "九江市");
			dic.Add("360500", "新余市");
			dic.Add("360600", "鹰潭市");
			dic.Add("360700", "赣州市");
			dic.Add("360800", "吉安市");
			dic.Add("360900", "宜春市");
			dic.Add("361000", "抚州市");
			dic.Add("361100", "上饶市");
			dic.Add("370100", "济南市");
			dic.Add("370200", "青岛市");
			dic.Add("370300", "淄博市");
			dic.Add("370400", "枣庄市");
			dic.Add("370500", "东营市");
			dic.Add("370600", "烟台市");
			dic.Add("370700", "潍坊市");
			dic.Add("370800", "济宁市");
			dic.Add("370900", "泰安市");
			dic.Add("371000", "威海市");
			dic.Add("371100", "日照市");
			dic.Add("371200", "莱芜市");
			dic.Add("371300", "临沂市");
			dic.Add("371400", "德州市");
			dic.Add("371500", "聊城市");
			dic.Add("371600", "滨州市");
			dic.Add("371700", "荷泽市");
			dic.Add("410100", "郑州市");
			dic.Add("410200", "开封市");
			dic.Add("410300", "洛阳市");
			dic.Add("410400", "平顶山市");
			dic.Add("410500", "安阳市");
			dic.Add("410600", "鹤壁市");
			dic.Add("410700", "新乡市");
			dic.Add("410800", "焦作市");
			dic.Add("410900", "濮阳市");
			dic.Add("411000", "许昌市");
			dic.Add("411100", "漯河市");
			dic.Add("411200", "三门峡市");
			dic.Add("411300", "南阳市");
			dic.Add("411400", "商丘市");
			dic.Add("411500", "信阳市");
			dic.Add("411600", "周口市");
			dic.Add("411700", "驻马店市");
			dic.Add("420100", "武汉市");
			dic.Add("420200", "黄石市");
			dic.Add("420300", "十堰市");
			dic.Add("420500", "宜昌市");
			dic.Add("420600", "襄樊市");
			dic.Add("420700", "鄂州市");
			dic.Add("420800", "荆门市");
			dic.Add("420900", "孝感市");
			dic.Add("421000", "荆州市");
			dic.Add("421100", "黄冈市");
			dic.Add("421200", "咸宁市");
			dic.Add("421300", "随州市");
			dic.Add("422800", "恩施土家族苗族自治州");
			dic.Add("429000", "省直辖行政单位");
			dic.Add("430100", "长沙市");
			dic.Add("430200", "株洲市");
			dic.Add("430300", "湘潭市");
			dic.Add("430400", "衡阳市");
			dic.Add("430500", "邵阳市");
			dic.Add("430600", "岳阳市");
			dic.Add("430700", "常德市");
			dic.Add("430800", "张家界市");
			dic.Add("430900", "益阳市");
			dic.Add("431000", "郴州市");
			dic.Add("431100", "永州市");
			dic.Add("431200", "怀化市");
			dic.Add("431300", "娄底市");
			dic.Add("433100", "湘西土家族苗族自治州");
			dic.Add("440100", "广州市");
			dic.Add("440200", "韶关市");
			dic.Add("440300", "深圳市");
			dic.Add("440400", "珠海市");
			dic.Add("440500", "汕头市");
			dic.Add("440600", "佛山市");
			dic.Add("440700", "江门市");
			dic.Add("440800", "湛江市");
			dic.Add("440900", "茂名市");
			dic.Add("441200", "肇庆市");
			dic.Add("441300", "惠州市");
			dic.Add("441400", "梅州市");
			dic.Add("441500", "汕尾市");
			dic.Add("441600", "河源市");
			dic.Add("441700", "阳江市");
			dic.Add("441800", "清远市");
			dic.Add("441900", "东莞市");
			dic.Add("442000", "中山市");
			dic.Add("445100", "潮州市");
			dic.Add("445200", "揭阳市");
			dic.Add("445300", "云浮市");
			dic.Add("450100", "南宁市");
			dic.Add("450200", "柳州市");
			dic.Add("450300", "桂林市");
			dic.Add("450400", "梧州市");
			dic.Add("450500", "北海市");
			dic.Add("450600", "防城港市");
			dic.Add("450700", "钦州市");
			dic.Add("450800", "贵港市");
			dic.Add("450900", "玉林市");
			dic.Add("451000", "百色市");
			dic.Add("451100", "贺州市");
			dic.Add("451200", "河池市");
			dic.Add("451300", "来宾市");
			dic.Add("451400", "崇左市");
			dic.Add("460100", "海口市");
			dic.Add("460200", "三亚市");
			dic.Add("469000", "省直辖县级行政单位");
			dic.Add("500100", "市辖区");
			dic.Add("500200", "县");
			dic.Add("500300", "市");
			dic.Add("510100", "成都市");
			dic.Add("510300", "自贡市");
			dic.Add("510400", "攀枝花市");
			dic.Add("510500", "泸州市");
			dic.Add("510600", "德阳市");
			dic.Add("510700", "绵阳市");
			dic.Add("510800", "广元市");
			dic.Add("510900", "遂宁市");
			dic.Add("511000", "内江市");
			dic.Add("511100", "乐山市");
			dic.Add("511300", "南充市");
			dic.Add("511400", "眉山市");
			dic.Add("511500", "宜宾市");
			dic.Add("511600", "广安市");
			dic.Add("511700", "达州市");
			dic.Add("511800", "雅安市");
			dic.Add("511900", "巴中市");
			dic.Add("512000", "资阳市");
			dic.Add("513200", "阿坝藏族羌族自治州");
			dic.Add("513300", "甘孜藏族自治州");
			dic.Add("513400", "凉山彝族自治州");
			dic.Add("520100", "贵阳市");
			dic.Add("520200", "六盘水市");
			dic.Add("520300", "遵义市");
			dic.Add("520400", "安顺市");
			dic.Add("522200", "铜仁地区");
			dic.Add("522300", "黔西南布依族苗族自治州");
			dic.Add("522400", "毕节地区");
			dic.Add("522600", "黔东南苗族侗族自治州");
			dic.Add("522700", "黔南布依族苗族自治州");
			dic.Add("530100", "昆明市");
			dic.Add("530300", "曲靖市");
			dic.Add("530400", "玉溪市");
			dic.Add("530500", "保山市");
			dic.Add("530600", "昭通市");
			dic.Add("530700", "丽江市");
			dic.Add("530800", "思茅市");
			dic.Add("530900", "临沧市");
			dic.Add("532300", "楚雄彝族自治州");
			dic.Add("532500", "红河哈尼族彝族自治州");
			dic.Add("532600", "文山壮族苗族自治州");
			dic.Add("532800", "西双版纳傣族自治州");
			dic.Add("532900", "大理白族自治州");
			dic.Add("533100", "德宏傣族景颇族自治州");
			dic.Add("533300", "怒江傈僳族自治州");
			dic.Add("533400", "迪庆藏族自治州");
			dic.Add("540100", "拉萨市");
			dic.Add("542100", "昌都地区");
			dic.Add("542200", "山南地区");
			dic.Add("542300", "日喀则地区");
			dic.Add("542400", "那曲地区");
			dic.Add("542500", "阿里地区");
			dic.Add("542600", "林芝地区");
			dic.Add("610100", "西安市");
			dic.Add("610200", "铜川市");
			dic.Add("610300", "宝鸡市");
			dic.Add("610400", "咸阳市");
			dic.Add("610500", "渭南市");
			dic.Add("610600", "延安市");
			dic.Add("610700", "汉中市");
			dic.Add("610800", "榆林市");
			dic.Add("610900", "安康市");
			dic.Add("611000", "商洛市");
			dic.Add("620100", "兰州市");
			dic.Add("620200", "嘉峪关市");
			dic.Add("620300", "金昌市");
			dic.Add("620400", "白银市");
			dic.Add("620500", "天水市");
			dic.Add("620600", "武威市");
			dic.Add("620700", "张掖市");
			dic.Add("620800", "平凉市");
			dic.Add("620900", "酒泉市");
			dic.Add("621000", "庆阳市");
			dic.Add("621100", "定西市");
			dic.Add("621200", "陇南市");
			dic.Add("622900", "临夏回族自治州");
			dic.Add("623000", "甘南藏族自治州");
			dic.Add("630100", "西宁市");
			dic.Add("632100", "海东地区");
			dic.Add("632200", "海北藏族自治州");
			dic.Add("632300", "黄南藏族自治州");
			dic.Add("632500", "海南藏族自治州");
			dic.Add("632600", "果洛藏族自治州");
			dic.Add("632700", "玉树藏族自治州");
			dic.Add("632800", "海西蒙古族藏族自治州");
			dic.Add("640100", "银川市");
			dic.Add("640200", "石嘴山市");
			dic.Add("640300", "吴忠市");
			dic.Add("640400", "固原市");
			dic.Add("640500", "中卫市");
			dic.Add("650100", "乌鲁木齐市");
			dic.Add("650200", "克拉玛依市");
			dic.Add("652100", "吐鲁番地区");
			dic.Add("652200", "哈密地区");
			dic.Add("652300", "昌吉回族自治州");
			dic.Add("652700", "博尔塔拉蒙古自治州");
			dic.Add("652800", "巴音郭楞蒙古自治州");
			dic.Add("652900", "阿克苏地区");
			dic.Add("653000", "克孜勒苏柯尔克孜自治州");
			dic.Add("653100", "喀什地区");
			dic.Add("653200", "和田地区");
			dic.Add("654000", "伊犁哈萨克自治州");
			dic.Add("654200", "塔城地区");
			dic.Add("654300", "阿勒泰地区");
			dic.Add("659000", "省直辖行政单位");
			dic.Add("110101", "东城区");
			dic.Add("110102", "西城区");
			dic.Add("110103", "崇文区");
			dic.Add("110104", "宣武区");
			dic.Add("110105", "朝阳区");
			dic.Add("110106", "丰台区");
			dic.Add("110107", "石景山区");
			dic.Add("110108", "海淀区");
			dic.Add("110109", "门头沟区");
			dic.Add("110111", "房山区");
			dic.Add("110112", "通州区");
			dic.Add("110113", "顺义区");
			dic.Add("110114", "昌平区");
			dic.Add("110115", "大兴区");
			dic.Add("110116", "怀柔区");
			dic.Add("110117", "平谷区");
			dic.Add("110228", "密云县");
			dic.Add("110229", "延庆县");
			dic.Add("120101", "和平区");
			dic.Add("120102", "河东区");
			dic.Add("120103", "河西区");
			dic.Add("120104", "南开区");
			dic.Add("120105", "河北区");
			dic.Add("120106", "红桥区");
			dic.Add("120107", "塘沽区");
			dic.Add("120108", "汉沽区");
			dic.Add("120109", "大港区");
			dic.Add("120110", "东丽区");
			dic.Add("120111", "西青区");
			dic.Add("120112", "津南区");
			dic.Add("120113", "北辰区");
			dic.Add("120114", "武清区");
			dic.Add("120115", "宝坻区");
			dic.Add("120221", "宁河县");
			dic.Add("120223", "静海县");
			dic.Add("120225", "蓟县");
			dic.Add("130101", "市辖区");
			dic.Add("130102", "长安区");
			dic.Add("130103", "桥东区");
			dic.Add("130104", "桥西区");
			dic.Add("130105", "新华区");
			dic.Add("130107", "井陉矿区");
			dic.Add("130108", "裕华区");
			dic.Add("130121", "井陉县");
			dic.Add("130123", "正定县");
			dic.Add("130124", "栾城县");
			dic.Add("130125", "行唐县");
			dic.Add("130126", "灵寿县");
			dic.Add("130127", "高邑县");
			dic.Add("130128", "深泽县");
			dic.Add("130129", "赞皇县");
			dic.Add("130130", "无极县");
			dic.Add("130131", "平山县");
			dic.Add("130132", "元氏县");
			dic.Add("130133", "赵县");
			dic.Add("130181", "辛集市");
			dic.Add("130182", "藁城市");
			dic.Add("130183", "晋州市");
			dic.Add("130184", "新乐市");
			dic.Add("130185", "鹿泉市");
			dic.Add("130201", "市辖区");
			dic.Add("130202", "路南区");
			dic.Add("130203", "路北区");
			dic.Add("130204", "古冶区");
			dic.Add("130205", "开平区");
			dic.Add("130207", "丰南区");
			dic.Add("130208", "丰润区");
			dic.Add("130223", "滦县");
			dic.Add("130224", "滦南县");
			dic.Add("130225", "乐亭县");
			dic.Add("130227", "迁西县");
			dic.Add("130229", "玉田县");
			dic.Add("130230", "唐海县");
			dic.Add("130281", "遵化市");
			dic.Add("130283", "迁安市");
			dic.Add("130301", "市辖区");
			dic.Add("130302", "海港区");
			dic.Add("130303", "山海关区");
			dic.Add("130304", "北戴河区");
			dic.Add("130321", "青龙满族自治县");
			dic.Add("130322", "昌黎县");
			dic.Add("130323", "抚宁县");
			dic.Add("130324", "卢龙县");
			dic.Add("130401", "市辖区");
			dic.Add("130402", "邯山区");
			dic.Add("130403", "丛台区");
			dic.Add("130404", "复兴区");
			dic.Add("130406", "峰峰矿区");
			dic.Add("130421", "邯郸县");
			dic.Add("130423", "临漳县");
			dic.Add("130424", "成安县");
			dic.Add("130425", "大名县");
			dic.Add("130426", "涉县");
			dic.Add("130427", "磁县");
			dic.Add("130428", "肥乡县");
			dic.Add("130429", "永年县");
			dic.Add("130430", "邱县");
			dic.Add("130431", "鸡泽县");
			dic.Add("130432", "广平县");
			dic.Add("130433", "馆陶县");
			dic.Add("130434", "魏县");
			dic.Add("130435", "曲周县");
			dic.Add("130481", "武安市");
			dic.Add("130501", "市辖区");
			dic.Add("130502", "桥东区");
			dic.Add("130503", "桥西区");
			dic.Add("130521", "邢台县");
			dic.Add("130522", "临城县");
			dic.Add("130523", "内丘县");
			dic.Add("130524", "柏乡县");
			dic.Add("130525", "隆尧县");
			dic.Add("130526", "任县");
			dic.Add("130527", "南和县");
			dic.Add("130528", "宁晋县");
			dic.Add("130529", "巨鹿县");
			dic.Add("130530", "新河县");
			dic.Add("130531", "广宗县");
			dic.Add("130532", "平乡县");
			dic.Add("130533", "威县");
			dic.Add("130534", "清河县");
			dic.Add("130535", "临西县");
			dic.Add("130581", "南宫市");
			dic.Add("130582", "沙河市");
			dic.Add("130601", "市辖区");
			dic.Add("130602", "新市区");
			dic.Add("130603", "北市区");
			dic.Add("130604", "南市区");
			dic.Add("130621", "满城县");
			dic.Add("130622", "清苑县");
			dic.Add("130623", "涞水县");
			dic.Add("130624", "阜平县");
			dic.Add("130625", "徐水县");
			dic.Add("130626", "定兴县");
			dic.Add("130627", "唐县");
			dic.Add("130628", "高阳县");
			dic.Add("130629", "容城县");
			dic.Add("130630", "涞源县");
			dic.Add("130631", "望都县");
			dic.Add("130632", "安新县");
			dic.Add("130633", "易县");
			dic.Add("130634", "曲阳县");
			dic.Add("130635", "蠡县");
			dic.Add("130636", "顺平县");
			dic.Add("130637", "博野县");
			dic.Add("130638", "雄县");
			dic.Add("130681", "涿州市");
			dic.Add("130682", "定州市");
			dic.Add("130683", "安国市");
			dic.Add("130684", "高碑店市");
			dic.Add("130701", "市辖区");
			dic.Add("130702", "桥东区");
			dic.Add("130703", "桥西区");
			dic.Add("130705", "宣化区");
			dic.Add("130706", "下花园区");
			dic.Add("130721", "宣化县");
			dic.Add("130722", "张北县");
			dic.Add("130723", "康保县");
			dic.Add("130724", "沽源县");
			dic.Add("130725", "尚义县");
			dic.Add("130726", "蔚县");
			dic.Add("130727", "阳原县");
			dic.Add("130728", "怀安县");
			dic.Add("130729", "万全县");
			dic.Add("130730", "怀来县");
			dic.Add("130731", "涿鹿县");
			dic.Add("130732", "赤城县");
			dic.Add("130733", "崇礼县");
			dic.Add("130801", "市辖区");
			dic.Add("130802", "双桥区");
			dic.Add("130803", "双滦区");
			dic.Add("130804", "鹰手营子矿区");
			dic.Add("130821", "承德县");
			dic.Add("130822", "兴隆县");
			dic.Add("130823", "平泉县");
			dic.Add("130824", "滦平县");
			dic.Add("130825", "隆化县");
			dic.Add("130826", "丰宁满族自治县");
			dic.Add("130827", "宽城满族自治县");
			dic.Add("130828", "围场满族蒙古族自治县");
			dic.Add("130901", "市辖区");
			dic.Add("130902", "新华区");
			dic.Add("130903", "运河区");
			dic.Add("130921", "沧县");
			dic.Add("130922", "青县");
			dic.Add("130923", "东光县");
			dic.Add("130924", "海兴县");
			dic.Add("130925", "盐山县");
			dic.Add("130926", "肃宁县");
			dic.Add("130927", "南皮县");
			dic.Add("130928", "吴桥县");
			dic.Add("130929", "献县");
			dic.Add("130930", "孟村回族自治县");
			dic.Add("130981", "泊头市");
			dic.Add("130982", "任丘市");
			dic.Add("130983", "黄骅市");
			dic.Add("130984", "河间市");
			dic.Add("131001", "市辖区");
			dic.Add("131002", "安次区");
			dic.Add("131003", "广阳区");
			dic.Add("131022", "固安县");
			dic.Add("131023", "永清县");
			dic.Add("131024", "香河县");
			dic.Add("131025", "大城县");
			dic.Add("131026", "文安县");
			dic.Add("131028", "大厂回族自治县");
			dic.Add("131081", "霸州市");
			dic.Add("131082", "三河市");
			dic.Add("131101", "市辖区");
			dic.Add("131102", "桃城区");
			dic.Add("131121", "枣强县");
			dic.Add("131122", "武邑县");
			dic.Add("131123", "武强县");
			dic.Add("131124", "饶阳县");
			dic.Add("131125", "安平县");
			dic.Add("131126", "故城县");
			dic.Add("131127", "景县");
			dic.Add("131128", "阜城县");
			dic.Add("131181", "冀州市");
			dic.Add("131182", "深州市");
			dic.Add("140101", "市辖区");
			dic.Add("140105", "小店区");
			dic.Add("140106", "迎泽区");
			dic.Add("140107", "杏花岭区");
			dic.Add("140108", "尖草坪区");
			dic.Add("140109", "万柏林区");
			dic.Add("140110", "晋源区");
			dic.Add("140121", "清徐县");
			dic.Add("140122", "阳曲县");
			dic.Add("140123", "娄烦县");
			dic.Add("140181", "古交市");
			dic.Add("140201", "市辖区");
			dic.Add("140202", "城区");
			dic.Add("140203", "矿区");
			dic.Add("140211", "南郊区");
			dic.Add("140212", "新荣区");
			dic.Add("140221", "阳高县");
			dic.Add("140222", "天镇县");
			dic.Add("140223", "广灵县");
			dic.Add("140224", "灵丘县");
			dic.Add("140225", "浑源县");
			dic.Add("140226", "左云县");
			dic.Add("140227", "大同县");
			dic.Add("140301", "市辖区");
			dic.Add("140302", "城区");
			dic.Add("140303", "矿区");
			dic.Add("140311", "郊区");
			dic.Add("140321", "平定县");
			dic.Add("140322", "盂县");
			dic.Add("140401", "市辖区");
			dic.Add("140402", "城区");
			dic.Add("140411", "郊区");
			dic.Add("140421", "长治县");
			dic.Add("140423", "襄垣县");
			dic.Add("140424", "屯留县");
			dic.Add("140425", "平顺县");
			dic.Add("140426", "黎城县");
			dic.Add("140427", "壶关县");
			dic.Add("140428", "长子县");
			dic.Add("140429", "武乡县");
			dic.Add("140430", "沁县");
			dic.Add("140431", "沁源县");
			dic.Add("140481", "潞城市");
			dic.Add("140501", "市辖区");
			dic.Add("140502", "城区");
			dic.Add("140521", "沁水县");
			dic.Add("140522", "阳城县");
			dic.Add("140524", "陵川县");
			dic.Add("140525", "泽州县");
			dic.Add("140581", "高平市");
			dic.Add("140601", "市辖区");
			dic.Add("140602", "朔城区");
			dic.Add("140603", "平鲁区");
			dic.Add("140621", "山阴县");
			dic.Add("140622", "应县");
			dic.Add("140623", "右玉县");
			dic.Add("140624", "怀仁县");
			dic.Add("140701", "市辖区");
			dic.Add("140702", "榆次区");
			dic.Add("140721", "榆社县");
			dic.Add("140722", "左权县");
			dic.Add("140723", "和顺县");
			dic.Add("140724", "昔阳县");
			dic.Add("140725", "寿阳县");
			dic.Add("140726", "太谷县");
			dic.Add("140727", "祁县");
			dic.Add("140728", "平遥县");
			dic.Add("140729", "灵石县");
			dic.Add("140781", "介休市");
			dic.Add("140801", "市辖区");
			dic.Add("140802", "盐湖区");
			dic.Add("140821", "临猗县");
			dic.Add("140822", "万荣县");
			dic.Add("140823", "闻喜县");
			dic.Add("140824", "稷山县");
			dic.Add("140825", "新绛县");
			dic.Add("140826", "绛县");
			dic.Add("140827", "垣曲县");
			dic.Add("140828", "夏县");
			dic.Add("140829", "平陆县");
			dic.Add("140830", "芮城县");
			dic.Add("140881", "永济市");
			dic.Add("140882", "河津市");
			dic.Add("140901", "市辖区");
			dic.Add("140902", "忻府区");
			dic.Add("140921", "定襄县");
			dic.Add("140922", "五台县");
			dic.Add("140923", "代县");
			dic.Add("140924", "繁峙县");
			dic.Add("140925", "宁武县");
			dic.Add("140926", "静乐县");
			dic.Add("140927", "神池县");
			dic.Add("140928", "五寨县");
			dic.Add("140929", "岢岚县");
			dic.Add("140930", "河曲县");
			dic.Add("140931", "保德县");
			dic.Add("140932", "偏关县");
			dic.Add("140981", "原平市");
			dic.Add("141001", "市辖区");
			dic.Add("141002", "尧都区");
			dic.Add("141021", "曲沃县");
			dic.Add("141022", "翼城县");
			dic.Add("141023", "襄汾县");
			dic.Add("141024", "洪洞县");
			dic.Add("141025", "古县");
			dic.Add("141026", "安泽县");
			dic.Add("141027", "浮山县");
			dic.Add("141028", "吉县");
			dic.Add("141029", "乡宁县");
			dic.Add("141030", "大宁县");
			dic.Add("141031", "隰县");
			dic.Add("141032", "永和县");
			dic.Add("141033", "蒲县");
			dic.Add("141034", "汾西县");
			dic.Add("141081", "侯马市");
			dic.Add("141082", "霍州市");
			dic.Add("141101", "市辖区");
			dic.Add("141102", "离石区");
			dic.Add("141121", "文水县");
			dic.Add("141122", "交城县");
			dic.Add("141123", "兴县");
			dic.Add("141124", "临县");
			dic.Add("141125", "柳林县");
			dic.Add("141126", "石楼县");
			dic.Add("141127", "岚县");
			dic.Add("141128", "方山县");
			dic.Add("141129", "中阳县");
			dic.Add("141130", "交口县");
			dic.Add("141181", "孝义市");
			dic.Add("141182", "汾阳市");
			dic.Add("150101", "市辖区");
			dic.Add("150102", "新城区");
			dic.Add("150103", "回民区");
			dic.Add("150104", "玉泉区");
			dic.Add("150105", "赛罕区");
			dic.Add("150121", "土默特左旗");
			dic.Add("150122", "托克托县");
			dic.Add("150123", "和林格尔县");
			dic.Add("150124", "清水河县");
			dic.Add("150125", "武川县");
			dic.Add("150201", "市辖区");
			dic.Add("150202", "东河区");
			dic.Add("150203", "昆都仑区");
			dic.Add("150204", "青山区");
			dic.Add("150205", "石拐区");
			dic.Add("150206", "白云矿区");
			dic.Add("150207", "九原区");
			dic.Add("150221", "土默特右旗");
			dic.Add("150222", "固阳县");
			dic.Add("150223", "达尔罕茂明安联合旗");
			dic.Add("150301", "市辖区");
			dic.Add("150302", "海勃湾区");
			dic.Add("150303", "海南区");
			dic.Add("150304", "乌达区");
			dic.Add("150401", "市辖区");
			dic.Add("150402", "红山区");
			dic.Add("150403", "元宝山区");
			dic.Add("150404", "松山区");
			dic.Add("150421", "阿鲁科尔沁旗");
			dic.Add("150422", "巴林左旗");
			dic.Add("150423", "巴林右旗");
			dic.Add("150424", "林西县");
			dic.Add("150425", "克什克腾旗");
			dic.Add("150426", "翁牛特旗");
			dic.Add("150428", "喀喇沁旗");
			dic.Add("150429", "宁城县");
			dic.Add("150430", "敖汉旗");
			dic.Add("150501", "市辖区");
			dic.Add("150502", "科尔沁区");
			dic.Add("150521", "科尔沁左翼中旗");
			dic.Add("150522", "科尔沁左翼后旗");
			dic.Add("150523", "开鲁县");
			dic.Add("150524", "库伦旗");
			dic.Add("150525", "奈曼旗");
			dic.Add("150526", "扎鲁特旗");
			dic.Add("150581", "霍林郭勒市");
			dic.Add("150602", "东胜区");
			dic.Add("150621", "达拉特旗");
			dic.Add("150622", "准格尔旗");
			dic.Add("150623", "鄂托克前旗");
			dic.Add("150624", "鄂托克旗");
			dic.Add("150625", "杭锦旗");
			dic.Add("150626", "乌审旗");
			dic.Add("150627", "伊金霍洛旗");
			dic.Add("150701", "市辖区");
			dic.Add("150702", "海拉尔区");
			dic.Add("150721", "阿荣旗");
			dic.Add("150722", "莫力达瓦达斡尔族自治旗");
			dic.Add("150723", "鄂伦春自治旗");
			dic.Add("150724", "鄂温克族自治旗");
			dic.Add("150725", "陈巴尔虎旗");
			dic.Add("150726", "新巴尔虎左旗");
			dic.Add("150727", "新巴尔虎右旗");
			dic.Add("150781", "满洲里市");
			dic.Add("150782", "牙克石市");
			dic.Add("150783", "扎兰屯市");
			dic.Add("150784", "额尔古纳市");
			dic.Add("150785", "根河市");
			dic.Add("150801", "市辖区");
			dic.Add("150802", "临河区");
			dic.Add("150821", "五原县");
			dic.Add("150822", "磴口县");
			dic.Add("150823", "乌拉特前旗");
			dic.Add("150824", "乌拉特中旗");
			dic.Add("150825", "乌拉特后旗");
			dic.Add("150826", "杭锦后旗");
			dic.Add("150901", "市辖区");
			dic.Add("150902", "集宁区");
			dic.Add("150921", "卓资县");
			dic.Add("150922", "化德县");
			dic.Add("150923", "商都县");
			dic.Add("150924", "兴和县");
			dic.Add("150925", "凉城县");
			dic.Add("150926", "察哈尔右翼前旗");
			dic.Add("150927", "察哈尔右翼中旗");
			dic.Add("150928", "察哈尔右翼后旗");
			dic.Add("150929", "四子王旗");
			dic.Add("150981", "丰镇市");
			dic.Add("152201", "乌兰浩特市");
			dic.Add("152202", "阿尔山市");
			dic.Add("152221", "科尔沁右翼前旗");
			dic.Add("152222", "科尔沁右翼中旗");
			dic.Add("152223", "扎赉特旗");
			dic.Add("152224", "突泉县");
			dic.Add("152501", "二连浩特市");
			dic.Add("152502", "锡林浩特市");
			dic.Add("152522", "阿巴嘎旗");
			dic.Add("152523", "苏尼特左旗");
			dic.Add("152524", "苏尼特右旗");
			dic.Add("152525", "东乌珠穆沁旗");
			dic.Add("152526", "西乌珠穆沁旗");
			dic.Add("152527", "太仆寺旗");
			dic.Add("152528", "镶黄旗");
			dic.Add("152529", "正镶白旗");
			dic.Add("152530", "正蓝旗");
			dic.Add("152531", "多伦县");
			dic.Add("152921", "阿拉善左旗");
			dic.Add("152922", "阿拉善右旗");
			dic.Add("152923", "额济纳旗");
			dic.Add("210101", "市辖区");
			dic.Add("210102", "和平区");
			dic.Add("210103", "沈河区");
			dic.Add("210104", "大东区");
			dic.Add("210105", "皇姑区");
			dic.Add("210106", "铁西区");
			dic.Add("210111", "苏家屯区");
			dic.Add("210112", "东陵区");
			dic.Add("210113", "新城子区");
			dic.Add("210114", "于洪区");
			dic.Add("210122", "辽中县");
			dic.Add("210123", "康平县");
			dic.Add("210124", "法库县");
			dic.Add("210181", "新民市");
			dic.Add("210201", "市辖区");
			dic.Add("210202", "中山区");
			dic.Add("210203", "西岗区");
			dic.Add("210204", "沙河口区");
			dic.Add("210211", "甘井子区");
			dic.Add("210212", "旅顺口区");
			dic.Add("210213", "金州区");
			dic.Add("210224", "长海县");
			dic.Add("210281", "瓦房店市");
			dic.Add("210282", "普兰店市");
			dic.Add("210283", "庄河市");
			dic.Add("210301", "市辖区");
			dic.Add("210302", "铁东区");
			dic.Add("210303", "铁西区");
			dic.Add("210304", "立山区");
			dic.Add("210311", "千山区");
			dic.Add("210321", "台安县");
			dic.Add("210323", "岫岩满族自治县");
			dic.Add("210381", "海城市");
			dic.Add("210401", "市辖区");
			dic.Add("210402", "新抚区");
			dic.Add("210403", "东洲区");
			dic.Add("210404", "望花区");
			dic.Add("210411", "顺城区");
			dic.Add("210421", "抚顺县");
			dic.Add("210422", "新宾满族自治县");
			dic.Add("210423", "清原满族自治县");
			dic.Add("210501", "市辖区");
			dic.Add("210502", "平山区");
			dic.Add("210503", "溪湖区");
			dic.Add("210504", "明山区");
			dic.Add("210505", "南芬区");
			dic.Add("210521", "本溪满族自治县");
			dic.Add("210522", "桓仁满族自治县");
			dic.Add("210601", "市辖区");
			dic.Add("210602", "元宝区");
			dic.Add("210603", "振兴区");
			dic.Add("210604", "振安区");
			dic.Add("210624", "宽甸满族自治县");
			dic.Add("210681", "东港市");
			dic.Add("210682", "凤城市");
			dic.Add("210701", "市辖区");
			dic.Add("210702", "古塔区");
			dic.Add("210703", "凌河区");
			dic.Add("210711", "太和区");
			dic.Add("210726", "黑山县");
			dic.Add("210727", "义县");
			dic.Add("210781", "凌海市");
			dic.Add("210782", "北宁市");
			dic.Add("210801", "市辖区");
			dic.Add("210802", "站前区");
			dic.Add("210803", "西市区");
			dic.Add("210804", "鲅鱼圈区");
			dic.Add("210811", "老边区");
			dic.Add("210881", "盖州市");
			dic.Add("210882", "大石桥市");
			dic.Add("210901", "市辖区");
			dic.Add("210902", "海州区");
			dic.Add("210903", "新邱区");
			dic.Add("210904", "太平区");
			dic.Add("210905", "清河门区");
			dic.Add("210911", "细河区");
			dic.Add("210921", "阜新蒙古族自治县");
			dic.Add("210922", "彰武县");
			dic.Add("211001", "市辖区");
			dic.Add("211002", "白塔区");
			dic.Add("211003", "文圣区");
			dic.Add("211004", "宏伟区");
			dic.Add("211005", "弓长岭区");
			dic.Add("211011", "太子河区");
			dic.Add("211021", "辽阳县");
			dic.Add("211081", "灯塔市");
			dic.Add("211101", "市辖区");
			dic.Add("211102", "双台子区");
			dic.Add("211103", "兴隆台区");
			dic.Add("211121", "大洼县");
			dic.Add("211122", "盘山县");
			dic.Add("211201", "市辖区");
			dic.Add("211202", "银州区");
			dic.Add("211204", "清河区");
			dic.Add("211221", "铁岭县");
			dic.Add("211223", "西丰县");
			dic.Add("211224", "昌图县");
			dic.Add("211281", "调兵山市");
			dic.Add("211282", "开原市");
			dic.Add("211301", "市辖区");
			dic.Add("211302", "双塔区");
			dic.Add("211303", "龙城区");
			dic.Add("211321", "朝阳县");
			dic.Add("211322", "建平县");
			dic.Add("211324", "喀喇沁左翼蒙古族自治县");
			dic.Add("211381", "北票市");
			dic.Add("211382", "凌源市");
			dic.Add("211401", "市辖区");
			dic.Add("211402", "连山区");
			dic.Add("211403", "龙港区");
			dic.Add("211404", "南票区");
			dic.Add("211421", "绥中县");
			dic.Add("211422", "建昌县");
			dic.Add("211481", "兴城市");
			dic.Add("220101", "市辖区");
			dic.Add("220102", "南关区");
			dic.Add("220103", "宽城区");
			dic.Add("220104", "朝阳区");
			dic.Add("220105", "二道区");
			dic.Add("220106", "绿园区");
			dic.Add("220112", "双阳区");
			dic.Add("220122", "农安县");
			dic.Add("220181", "九台市");
			dic.Add("220182", "榆树市");
			dic.Add("220183", "德惠市");
			dic.Add("220201", "市辖区");
			dic.Add("220202", "昌邑区");
			dic.Add("220203", "龙潭区");
			dic.Add("220204", "船营区");
			dic.Add("220211", "丰满区");
			dic.Add("220221", "永吉县");
			dic.Add("220281", "蛟河市");
			dic.Add("220282", "桦甸市");
			dic.Add("220283", "舒兰市");
			dic.Add("220284", "磐石市");
			dic.Add("220301", "市辖区");
			dic.Add("220302", "铁西区");
			dic.Add("220303", "铁东区");
			dic.Add("220322", "梨树县");
			dic.Add("220323", "伊通满族自治县");
			dic.Add("220381", "公主岭市");
			dic.Add("220382", "双辽市");
			dic.Add("220401", "市辖区");
			dic.Add("220402", "龙山区");
			dic.Add("220403", "西安区");
			dic.Add("220421", "东丰县");
			dic.Add("220422", "东辽县");
			dic.Add("220501", "市辖区");
			dic.Add("220502", "东昌区");
			dic.Add("220503", "二道江区");
			dic.Add("220521", "通化县");
			dic.Add("220523", "辉南县");
			dic.Add("220524", "柳河县");
			dic.Add("220581", "梅河口市");
			dic.Add("220582", "集安市");
			dic.Add("220601", "市辖区");
			dic.Add("220602", "八道江区");
			dic.Add("220621", "抚松县");
			dic.Add("220622", "靖宇县");
			dic.Add("220623", "长白朝鲜族自治县");
			dic.Add("220625", "江源县");
			dic.Add("220681", "临江市");
			dic.Add("220701", "市辖区");
			dic.Add("220702", "宁江区");
			dic.Add("220721", "前郭尔罗斯蒙古族自治县");
			dic.Add("220722", "长岭县");
			dic.Add("220723", "乾安县");
			dic.Add("220724", "扶余县");
			dic.Add("220801", "市辖区");
			dic.Add("220802", "洮北区");
			dic.Add("220821", "镇赉县");
			dic.Add("220822", "通榆县");
			dic.Add("220881", "洮南市");
			dic.Add("220882", "大安市");
			dic.Add("222401", "延吉市");
			dic.Add("222402", "图们市");
			dic.Add("222403", "敦化市");
			dic.Add("222404", "珲春市");
			dic.Add("222405", "龙井市");
			dic.Add("222406", "和龙市");
			dic.Add("222424", "汪清县");
			dic.Add("222426", "安图县");
			dic.Add("230101", "市辖区");
			dic.Add("230102", "道里区");
			dic.Add("230103", "南岗区");
			dic.Add("230104", "道外区");
			dic.Add("230106", "香坊区");
			dic.Add("230107", "动力区");
			dic.Add("230108", "平房区");
			dic.Add("230109", "松北区");
			dic.Add("230111", "呼兰区");
			dic.Add("230123", "依兰县");
			dic.Add("230124", "方正县");
			dic.Add("230125", "宾县");
			dic.Add("230126", "巴彦县");
			dic.Add("230127", "木兰县");
			dic.Add("230128", "通河县");
			dic.Add("230129", "延寿县");
			dic.Add("230181", "阿城市");
			dic.Add("230182", "双城市");
			dic.Add("230183", "尚志市");
			dic.Add("230184", "五常市");
			dic.Add("230201", "市辖区");
			dic.Add("230202", "龙沙区");
			dic.Add("230203", "建华区");
			dic.Add("230204", "铁锋区");
			dic.Add("230205", "昂昂溪区");
			dic.Add("230206", "富拉尔基区");
			dic.Add("230207", "碾子山区");
			dic.Add("230208", "梅里斯达斡尔族区");
			dic.Add("230221", "龙江县");
			dic.Add("230223", "依安县");
			dic.Add("230224", "泰来县");
			dic.Add("230225", "甘南县");
			dic.Add("230227", "富裕县");
			dic.Add("230229", "克山县");
			dic.Add("230230", "克东县");
			dic.Add("230231", "拜泉县");
			dic.Add("230281", "讷河市");
			dic.Add("230301", "市辖区");
			dic.Add("230302", "鸡冠区");
			dic.Add("230303", "恒山区");
			dic.Add("230304", "滴道区");
			dic.Add("230305", "梨树区");
			dic.Add("230306", "城子河区");
			dic.Add("230307", "麻山区");
			dic.Add("230321", "鸡东县");
			dic.Add("230381", "虎林市");
			dic.Add("230382", "密山市");
			dic.Add("230401", "市辖区");
			dic.Add("230402", "向阳区");
			dic.Add("230403", "工农区");
			dic.Add("230404", "南山区");
			dic.Add("230405", "兴安区");
			dic.Add("230406", "东山区");
			dic.Add("230407", "兴山区");
			dic.Add("230421", "萝北县");
			dic.Add("230422", "绥滨县");
			dic.Add("230501", "市辖区");
			dic.Add("230502", "尖山区");
			dic.Add("230503", "岭东区");
			dic.Add("230505", "四方台区");
			dic.Add("230506", "宝山区");
			dic.Add("230521", "集贤县");
			dic.Add("230522", "友谊县");
			dic.Add("230523", "宝清县");
			dic.Add("230524", "饶河县");
			dic.Add("230601", "市辖区");
			dic.Add("230602", "萨尔图区");
			dic.Add("230603", "龙凤区");
			dic.Add("230604", "让胡路区");
			dic.Add("230605", "红岗区");
			dic.Add("230606", "大同区");
			dic.Add("230621", "肇州县");
			dic.Add("230622", "肇源县");
			dic.Add("230623", "林甸县");
			dic.Add("230624", "杜尔伯特蒙古族自治县");
			dic.Add("230701", "市辖区");
			dic.Add("230702", "伊春区");
			dic.Add("230703", "南岔区");
			dic.Add("230704", "友好区");
			dic.Add("230705", "西林区");
			dic.Add("230706", "翠峦区");
			dic.Add("230707", "新青区");
			dic.Add("230708", "美溪区");
			dic.Add("230709", "金山屯区");
			dic.Add("230710", "五营区");
			dic.Add("230711", "乌马河区");
			dic.Add("230712", "汤旺河区");
			dic.Add("230713", "带岭区");
			dic.Add("230714", "乌伊岭区");
			dic.Add("230715", "红星区");
			dic.Add("230716", "上甘岭区");
			dic.Add("230722", "嘉荫县");
			dic.Add("230781", "铁力市");
			dic.Add("230801", "市辖区");
			dic.Add("230802", "永红区");
			dic.Add("230803", "向阳区");
			dic.Add("230804", "前进区");
			dic.Add("230805", "东风区");
			dic.Add("230811", "郊区");
			dic.Add("230822", "桦南县");
			dic.Add("230826", "桦川县");
			dic.Add("230828", "汤原县");
			dic.Add("230833", "抚远县");
			dic.Add("230881", "同江市");
			dic.Add("230882", "富锦市");
			dic.Add("230901", "市辖区");
			dic.Add("230902", "新兴区");
			dic.Add("230903", "桃山区");
			dic.Add("230904", "茄子河区");
			dic.Add("230921", "勃利县");
			dic.Add("231001", "市辖区");
			dic.Add("231002", "东安区");
			dic.Add("231003", "阳明区");
			dic.Add("231004", "爱民区");
			dic.Add("231005", "西安区");
			dic.Add("231024", "东宁县");
			dic.Add("231025", "林口县");
			dic.Add("231081", "绥芬河市");
			dic.Add("231083", "海林市");
			dic.Add("231084", "宁安市");
			dic.Add("231085", "穆棱市");
			dic.Add("231101", "市辖区");
			dic.Add("231102", "爱辉区");
			dic.Add("231121", "嫩江县");
			dic.Add("231123", "逊克县");
			dic.Add("231124", "孙吴县");
			dic.Add("231181", "北安市");
			dic.Add("231182", "五大连池市");
			dic.Add("231201", "市辖区");
			dic.Add("231202", "北林区");
			dic.Add("231221", "望奎县");
			dic.Add("231222", "兰西县");
			dic.Add("231223", "青冈县");
			dic.Add("231224", "庆安县");
			dic.Add("231225", "明水县");
			dic.Add("231226", "绥棱县");
			dic.Add("231281", "安达市");
			dic.Add("231282", "肇东市");
			dic.Add("231283", "海伦市");
			dic.Add("232721", "呼玛县");
			dic.Add("232722", "塔河县");
			dic.Add("232723", "漠河县");
			dic.Add("310101", "黄浦区");
			dic.Add("310103", "卢湾区");
			dic.Add("310104", "徐汇区");
			dic.Add("310105", "长宁区");
			dic.Add("310106", "静安区");
			dic.Add("310107", "普陀区");
			dic.Add("310108", "闸北区");
			dic.Add("310109", "虹口区");
			dic.Add("310110", "杨浦区");
			dic.Add("310112", "闵行区");
			dic.Add("310113", "宝山区");
			dic.Add("310114", "嘉定区");
			dic.Add("310115", "浦东新区");
			dic.Add("310116", "金山区");
			dic.Add("310117", "松江区");
			dic.Add("310118", "青浦区");
			dic.Add("310119", "南汇区");
			dic.Add("310120", "奉贤区");
			dic.Add("310230", "崇明县");
			dic.Add("320101", "市辖区");
			dic.Add("320102", "玄武区");
			dic.Add("320103", "白下区");
			dic.Add("320104", "秦淮区");
			dic.Add("320105", "建邺区");
			dic.Add("320106", "鼓楼区");
			dic.Add("320107", "下关区");
			dic.Add("320111", "浦口区");
			dic.Add("320113", "栖霞区");
			dic.Add("320114", "雨花台区");
			dic.Add("320115", "江宁区");
			dic.Add("320116", "六合区");
			dic.Add("320124", "溧水县");
			dic.Add("320125", "高淳县");
			dic.Add("320201", "市辖区");
			dic.Add("320202", "崇安区");
			dic.Add("320203", "南长区");
			dic.Add("320204", "北塘区");
			dic.Add("320205", "锡山区");
			dic.Add("320206", "惠山区");
			dic.Add("320211", "滨湖区");
			dic.Add("320281", "江阴市");
			dic.Add("320282", "宜兴市");
			dic.Add("320301", "市辖区");
			dic.Add("320302", "鼓楼区");
			dic.Add("320303", "云龙区");
			dic.Add("320304", "九里区");
			dic.Add("320305", "贾汪区");
			dic.Add("320311", "泉山区");
			dic.Add("320321", "丰县");
			dic.Add("320322", "沛县");
			dic.Add("320323", "铜山县");
			dic.Add("320324", "睢宁县");
			dic.Add("320381", "新沂市");
			dic.Add("320382", "邳州市");
			dic.Add("320401", "市辖区");
			dic.Add("320402", "天宁区");
			dic.Add("320404", "钟楼区");
			dic.Add("320405", "戚墅堰区");
			dic.Add("320411", "新北区");
			dic.Add("320412", "武进区");
			dic.Add("320481", "溧阳市");
			dic.Add("320482", "金坛市");
			dic.Add("320501", "市辖区");
			dic.Add("320502", "沧浪区");
			dic.Add("320503", "平江区");
			dic.Add("320504", "金阊区");
			dic.Add("320505", "虎丘区");
			dic.Add("320506", "吴中区");
			dic.Add("320507", "相城区");
			dic.Add("320581", "常熟市");
			dic.Add("320582", "张家港市");
			dic.Add("320583", "昆山市");
			dic.Add("320584", "吴江市");
			dic.Add("320585", "太仓市");
			dic.Add("320601", "市辖区");
			dic.Add("320602", "崇川区");
			dic.Add("320611", "港闸区");
			dic.Add("320621", "海安县");
			dic.Add("320623", "如东县");
			dic.Add("320681", "启东市");
			dic.Add("320682", "如皋市");
			dic.Add("320683", "通州市");
			dic.Add("320684", "海门市");
			dic.Add("320701", "市辖区");
			dic.Add("320703", "连云区");
			dic.Add("320705", "新浦区");
			dic.Add("320706", "海州区");
			dic.Add("320721", "赣榆县");
			dic.Add("320722", "东海县");
			dic.Add("320723", "灌云县");
			dic.Add("320724", "灌南县");
			dic.Add("320801", "市辖区");
			dic.Add("320802", "清河区");
			dic.Add("320803", "楚州区");
			dic.Add("320804", "淮阴区");
			dic.Add("320811", "清浦区");
			dic.Add("320826", "涟水县");
			dic.Add("320829", "洪泽县");
			dic.Add("320830", "盱眙县");
			dic.Add("320831", "金湖县");
			dic.Add("320901", "市辖区");
			dic.Add("320902", "亭湖区");
			dic.Add("320903", "盐都区");
			dic.Add("320921", "响水县");
			dic.Add("320922", "滨海县");
			dic.Add("320923", "阜宁县");
			dic.Add("320924", "射阳县");
			dic.Add("320925", "建湖县");
			dic.Add("320981", "东台市");
			dic.Add("320982", "大丰市");
			dic.Add("321001", "市辖区");
			dic.Add("321002", "广陵区");
			dic.Add("321003", "邗江区");
			dic.Add("321011", "郊区");
			dic.Add("321023", "宝应县");
			dic.Add("321081", "仪征市");
			dic.Add("321084", "高邮市");
			dic.Add("321088", "江都市");
			dic.Add("321101", "市辖区");
			dic.Add("321102", "京口区");
			dic.Add("321111", "润州区");
			dic.Add("321112", "丹徒区");
			dic.Add("321181", "丹阳市");
			dic.Add("321182", "扬中市");
			dic.Add("321183", "句容市");
			dic.Add("321201", "市辖区");
			dic.Add("321202", "海陵区");
			dic.Add("321203", "高港区");
			dic.Add("321281", "兴化市");
			dic.Add("321282", "靖江市");
			dic.Add("321283", "泰兴市");
			dic.Add("321284", "姜堰市");
			dic.Add("321301", "市辖区");
			dic.Add("321302", "宿城区");
			dic.Add("321311", "宿豫区");
			dic.Add("321322", "沭阳县");
			dic.Add("321323", "泗阳县");
			dic.Add("321324", "泗洪县");
			dic.Add("330101", "市辖区");
			dic.Add("330102", "上城区");
			dic.Add("330103", "下城区");
			dic.Add("330104", "江干区");
			dic.Add("330105", "拱墅区");
			dic.Add("330106", "西湖区");
			dic.Add("330108", "滨江区");
			dic.Add("330109", "萧山区");
			dic.Add("330110", "余杭区");
			dic.Add("330122", "桐庐县");
			dic.Add("330127", "淳安县");
			dic.Add("330182", "建德市");
			dic.Add("330183", "富阳市");
			dic.Add("330185", "临安市");
			dic.Add("330201", "市辖区");
			dic.Add("330203", "海曙区");
			dic.Add("330204", "江东区");
			dic.Add("330205", "江北区");
			dic.Add("330206", "北仑区");
			dic.Add("330211", "镇海区");
			dic.Add("330212", "鄞州区");
			dic.Add("330225", "象山县");
			dic.Add("330226", "宁海县");
			dic.Add("330281", "余姚市");
			dic.Add("330282", "慈溪市");
			dic.Add("330283", "奉化市");
			dic.Add("330301", "市辖区");
			dic.Add("330302", "鹿城区");
			dic.Add("330303", "龙湾区");
			dic.Add("330304", "瓯海区");
			dic.Add("330322", "洞头县");
			dic.Add("330324", "永嘉县");
			dic.Add("330326", "平阳县");
			dic.Add("330327", "苍南县");
			dic.Add("330328", "文成县");
			dic.Add("330329", "泰顺县");
			dic.Add("330381", "瑞安市");
			dic.Add("330382", "乐清市");
			dic.Add("330401", "市辖区");
			dic.Add("330402", "秀城区");
			dic.Add("330411", "秀洲区");
			dic.Add("330421", "嘉善县");
			dic.Add("330424", "海盐县");
			dic.Add("330481", "海宁市");
			dic.Add("330482", "平湖市");
			dic.Add("330483", "桐乡市");
			dic.Add("330501", "市辖区");
			dic.Add("330502", "吴兴区");
			dic.Add("330503", "南浔区");
			dic.Add("330521", "德清县");
			dic.Add("330522", "长兴县");
			dic.Add("330523", "安吉县");
			dic.Add("330601", "市辖区");
			dic.Add("330602", "越城区");
			dic.Add("330621", "绍兴县");
			dic.Add("330624", "新昌县");
			dic.Add("330681", "诸暨市");
			dic.Add("330682", "上虞市");
			dic.Add("330683", "嵊州市");
			dic.Add("330701", "市辖区");
			dic.Add("330702", "婺城区");
			dic.Add("330703", "金东区");
			dic.Add("330723", "武义县");
			dic.Add("330726", "浦江县");
			dic.Add("330727", "磐安县");
			dic.Add("330781", "兰溪市");
			dic.Add("330782", "义乌市");
			dic.Add("330783", "东阳市");
			dic.Add("330784", "永康市");
			dic.Add("330801", "市辖区");
			dic.Add("330802", "柯城区");
			dic.Add("330803", "衢江区");
			dic.Add("330822", "常山县");
			dic.Add("330824", "开化县");
			dic.Add("330825", "龙游县");
			dic.Add("330881", "江山市");
			dic.Add("330901", "市辖区");
			dic.Add("330902", "定海区");
			dic.Add("330903", "普陀区");
			dic.Add("330921", "岱山县");
			dic.Add("330922", "嵊泗县");
			dic.Add("331001", "市辖区");
			dic.Add("331002", "椒江区");
			dic.Add("331003", "黄岩区");
			dic.Add("331004", "路桥区");
			dic.Add("331021", "玉环县");
			dic.Add("331022", "三门县");
			dic.Add("331023", "天台县");
			dic.Add("331024", "仙居县");
			dic.Add("331081", "温岭市");
			dic.Add("331082", "临海市");
			dic.Add("331101", "市辖区");
			dic.Add("331102", "莲都区");
			dic.Add("331121", "青田县");
			dic.Add("331122", "缙云县");
			dic.Add("331123", "遂昌县");
			dic.Add("331124", "松阳县");
			dic.Add("331125", "云和县");
			dic.Add("331126", "庆元县");
			dic.Add("331127", "景宁畲族自治县");
			dic.Add("331181", "龙泉市");
			dic.Add("340101", "市辖区");
			dic.Add("340102", "瑶海区");
			dic.Add("340103", "庐阳区");
			dic.Add("340104", "蜀山区");
			dic.Add("340111", "包河区");
			dic.Add("340121", "长丰县");
			dic.Add("340122", "肥东县");
			dic.Add("340123", "肥西县");
			dic.Add("340201", "市辖区");
			dic.Add("340202", "镜湖区");
			dic.Add("340203", "马塘区");
			dic.Add("340204", "新芜区");
			dic.Add("340207", "鸠江区");
			dic.Add("340221", "芜湖县");
			dic.Add("340222", "繁昌县");
			dic.Add("340223", "南陵县");
			dic.Add("340301", "市辖区");
			dic.Add("340302", "龙子湖区");
			dic.Add("340303", "蚌山区");
			dic.Add("340304", "禹会区");
			dic.Add("340311", "淮上区");
			dic.Add("340321", "怀远县");
			dic.Add("340322", "五河县");
			dic.Add("340323", "固镇县");
			dic.Add("340401", "市辖区");
			dic.Add("340402", "大通区");
			dic.Add("340403", "田家庵区");
			dic.Add("340404", "谢家集区");
			dic.Add("340405", "八公山区");
			dic.Add("340406", "潘集区");
			dic.Add("340421", "凤台县");
			dic.Add("340501", "市辖区");
			dic.Add("340502", "金家庄区");
			dic.Add("340503", "花山区");
			dic.Add("340504", "雨山区");
			dic.Add("340521", "当涂县");
			dic.Add("340601", "市辖区");
			dic.Add("340602", "杜集区");
			dic.Add("340603", "相山区");
			dic.Add("340604", "烈山区");
			dic.Add("340621", "濉溪县");
			dic.Add("340701", "市辖区");
			dic.Add("340702", "铜官山区");
			dic.Add("340703", "狮子山区");
			dic.Add("340711", "郊区");
			dic.Add("340721", "铜陵县");
			dic.Add("340801", "市辖区");
			dic.Add("340802", "迎江区");
			dic.Add("340803", "大观区");
			dic.Add("340811", "郊区");
			dic.Add("340822", "怀宁县");
			dic.Add("340823", "枞阳县");
			dic.Add("340824", "潜山县");
			dic.Add("340825", "太湖县");
			dic.Add("340826", "宿松县");
			dic.Add("340827", "望江县");
			dic.Add("340828", "岳西县");
			dic.Add("340881", "桐城市");
			dic.Add("341001", "市辖区");
			dic.Add("341002", "屯溪区");
			dic.Add("341003", "黄山区");
			dic.Add("341004", "徽州区");
			dic.Add("341021", "歙县");
			dic.Add("341022", "休宁县");
			dic.Add("341023", "黟县");
			dic.Add("341024", "祁门县");
			dic.Add("341101", "市辖区");
			dic.Add("341102", "琅琊区");
			dic.Add("341103", "南谯区");
			dic.Add("341122", "来安县");
			dic.Add("341124", "全椒县");
			dic.Add("341125", "定远县");
			dic.Add("341126", "凤阳县");
			dic.Add("341181", "天长市");
			dic.Add("341182", "明光市");
			dic.Add("341201", "市辖区");
			dic.Add("341202", "颍州区");
			dic.Add("341203", "颍东区");
			dic.Add("341204", "颍泉区");
			dic.Add("341221", "临泉县");
			dic.Add("341222", "太和县");
			dic.Add("341225", "阜南县");
			dic.Add("341226", "颍上县");
			dic.Add("341282", "界首市");
			dic.Add("341301", "市辖区");
			dic.Add("341302", "墉桥区");
			dic.Add("341321", "砀山县");
			dic.Add("341322", "萧县");
			dic.Add("341323", "灵璧县");
			dic.Add("341324", "泗县");
			dic.Add("341401", "市辖区");
			dic.Add("341402", "居巢区");
			dic.Add("341421", "庐江县");
			dic.Add("341422", "无为县");
			dic.Add("341423", "含山县");
			dic.Add("341424", "和县");
			dic.Add("341501", "市辖区");
			dic.Add("341502", "金安区");
			dic.Add("341503", "裕安区");
			dic.Add("341521", "寿县");
			dic.Add("341522", "霍邱县");
			dic.Add("341523", "舒城县");
			dic.Add("341524", "金寨县");
			dic.Add("341525", "霍山县");
			dic.Add("341601", "市辖区");
			dic.Add("341602", "谯城区");
			dic.Add("341621", "涡阳县");
			dic.Add("341622", "蒙城县");
			dic.Add("341623", "利辛县");
			dic.Add("341701", "市辖区");
			dic.Add("341702", "贵池区");
			dic.Add("341721", "东至县");
			dic.Add("341722", "石台县");
			dic.Add("341723", "青阳县");
			dic.Add("341801", "市辖区");
			dic.Add("341802", "宣州区");
			dic.Add("341821", "郎溪县");
			dic.Add("341822", "广德县");
			dic.Add("341823", "泾县");
			dic.Add("341824", "绩溪县");
			dic.Add("341825", "旌德县");
			dic.Add("341881", "宁国市");
			dic.Add("350101", "市辖区");
			dic.Add("350102", "鼓楼区");
			dic.Add("350103", "台江区");
			dic.Add("350104", "仓山区");
			dic.Add("350105", "马尾区");
			dic.Add("350111", "晋安区");
			dic.Add("350121", "闽侯县");
			dic.Add("350122", "连江县");
			dic.Add("350123", "罗源县");
			dic.Add("350124", "闽清县");
			dic.Add("350125", "永泰县");
			dic.Add("350128", "平潭县");
			dic.Add("350181", "福清市");
			dic.Add("350182", "长乐市");
			dic.Add("350201", "市辖区");
			dic.Add("350203", "思明区");
			dic.Add("350205", "海沧区");
			dic.Add("350206", "湖里区");
			dic.Add("350211", "集美区");
			dic.Add("350212", "同安区");
			dic.Add("350213", "翔安区");
			dic.Add("350301", "市辖区");
			dic.Add("350302", "城厢区");
			dic.Add("350303", "涵江区");
			dic.Add("350304", "荔城区");
			dic.Add("350305", "秀屿区");
			dic.Add("350322", "仙游县");
			dic.Add("350401", "市辖区");
			dic.Add("350402", "梅列区");
			dic.Add("350403", "三元区");
			dic.Add("350421", "明溪县");
			dic.Add("350423", "清流县");
			dic.Add("350424", "宁化县");
			dic.Add("350425", "大田县");
			dic.Add("350426", "尤溪县");
			dic.Add("350427", "沙县");
			dic.Add("350428", "将乐县");
			dic.Add("350429", "泰宁县");
			dic.Add("350430", "建宁县");
			dic.Add("350481", "永安市");
			dic.Add("350501", "市辖区");
			dic.Add("350502", "鲤城区");
			dic.Add("350503", "丰泽区");
			dic.Add("350504", "洛江区");
			dic.Add("350505", "泉港区");
			dic.Add("350521", "惠安县");
			dic.Add("350524", "安溪县");
			dic.Add("350525", "永春县");
			dic.Add("350526", "德化县");
			dic.Add("350527", "金门县");
			dic.Add("350581", "石狮市");
			dic.Add("350582", "晋江市");
			dic.Add("350583", "南安市");
			dic.Add("350601", "市辖区");
			dic.Add("350602", "芗城区");
			dic.Add("350603", "龙文区");
			dic.Add("350622", "云霄县");
			dic.Add("350623", "漳浦县");
			dic.Add("350624", "诏安县");
			dic.Add("350625", "长泰县");
			dic.Add("350626", "东山县");
			dic.Add("350627", "南靖县");
			dic.Add("350628", "平和县");
			dic.Add("350629", "华安县");
			dic.Add("350681", "龙海市");
			dic.Add("350701", "市辖区");
			dic.Add("350702", "延平区");
			dic.Add("350721", "顺昌县");
			dic.Add("350722", "浦城县");
			dic.Add("350723", "光泽县");
			dic.Add("350724", "松溪县");
			dic.Add("350725", "政和县");
			dic.Add("350781", "邵武市");
			dic.Add("350782", "武夷山市");
			dic.Add("350783", "建瓯市");
			dic.Add("350784", "建阳市");
			dic.Add("350801", "市辖区");
			dic.Add("350802", "新罗区");
			dic.Add("350821", "长汀县");
			dic.Add("350822", "永定县");
			dic.Add("350823", "上杭县");
			dic.Add("350824", "武平县");
			dic.Add("350825", "连城县");
			dic.Add("350881", "漳平市");
			dic.Add("350901", "市辖区");
			dic.Add("350902", "蕉城区");
			dic.Add("350921", "霞浦县");
			dic.Add("350922", "古田县");
			dic.Add("350923", "屏南县");
			dic.Add("350924", "寿宁县");
			dic.Add("350925", "周宁县");
			dic.Add("350926", "柘荣县");
			dic.Add("350981", "福安市");
			dic.Add("350982", "福鼎市");
			dic.Add("360101", "市辖区");
			dic.Add("360102", "东湖区");
			dic.Add("360103", "西湖区");
			dic.Add("360104", "青云谱区");
			dic.Add("360105", "湾里区");
			dic.Add("360111", "青山湖区");
			dic.Add("360121", "南昌县");
			dic.Add("360122", "新建县");
			dic.Add("360123", "安义县");
			dic.Add("360124", "进贤县");
			dic.Add("360201", "市辖区");
			dic.Add("360202", "昌江区");
			dic.Add("360203", "珠山区");
			dic.Add("360222", "浮梁县");
			dic.Add("360281", "乐平市");
			dic.Add("360301", "市辖区");
			dic.Add("360302", "安源区");
			dic.Add("360313", "湘东区");
			dic.Add("360321", "莲花县");
			dic.Add("360322", "上栗县");
			dic.Add("360323", "芦溪县");
			dic.Add("360401", "市辖区");
			dic.Add("360402", "庐山区");
			dic.Add("360403", "浔阳区");
			dic.Add("360421", "九江县");
			dic.Add("360423", "武宁县");
			dic.Add("360424", "修水县");
			dic.Add("360425", "永修县");
			dic.Add("360426", "德安县");
			dic.Add("360427", "星子县");
			dic.Add("360428", "都昌县");
			dic.Add("360429", "湖口县");
			dic.Add("360430", "彭泽县");
			dic.Add("360481", "瑞昌市");
			dic.Add("360501", "市辖区");
			dic.Add("360502", "渝水区");
			dic.Add("360521", "分宜县");
			dic.Add("360601", "市辖区");
			dic.Add("360602", "月湖区");
			dic.Add("360622", "余江县");
			dic.Add("360681", "贵溪市");
			dic.Add("360701", "市辖区");
			dic.Add("360702", "章贡区");
			dic.Add("360721", "赣县");
			dic.Add("360722", "信丰县");
			dic.Add("360723", "大余县");
			dic.Add("360724", "上犹县");
			dic.Add("360725", "崇义县");
			dic.Add("360726", "安远县");
			dic.Add("360727", "龙南县");
			dic.Add("360728", "定南县");
			dic.Add("360729", "全南县");
			dic.Add("360730", "宁都县");
			dic.Add("360731", "于都县");
			dic.Add("360732", "兴国县");
			dic.Add("360733", "会昌县");
			dic.Add("360734", "寻乌县");
			dic.Add("360735", "石城县");
			dic.Add("360781", "瑞金市");
			dic.Add("360782", "南康市");
			dic.Add("360801", "市辖区");
			dic.Add("360802", "吉州区");
			dic.Add("360803", "青原区");
			dic.Add("360821", "吉安县");
			dic.Add("360822", "吉水县");
			dic.Add("360823", "峡江县");
			dic.Add("360824", "新干县");
			dic.Add("360825", "永丰县");
			dic.Add("360826", "泰和县");
			dic.Add("360827", "遂川县");
			dic.Add("360828", "万安县");
			dic.Add("360829", "安福县");
			dic.Add("360830", "永新县");
			dic.Add("360881", "井冈山市");
			dic.Add("360901", "市辖区");
			dic.Add("360902", "袁州区");
			dic.Add("360921", "奉新县");
			dic.Add("360922", "万载县");
			dic.Add("360923", "上高县");
			dic.Add("360924", "宜丰县");
			dic.Add("360925", "靖安县");
			dic.Add("360926", "铜鼓县");
			dic.Add("360981", "丰城市");
			dic.Add("360982", "樟树市");
			dic.Add("360983", "高安市");
			dic.Add("361001", "市辖区");
			dic.Add("361002", "临川区");
			dic.Add("361021", "南城县");
			dic.Add("361022", "黎川县");
			dic.Add("361023", "南丰县");
			dic.Add("361024", "崇仁县");
			dic.Add("361025", "乐安县");
			dic.Add("361026", "宜黄县");
			dic.Add("361027", "金溪县");
			dic.Add("361028", "资溪县");
			dic.Add("361029", "东乡县");
			dic.Add("361030", "广昌县");
			dic.Add("361101", "市辖区");
			dic.Add("361102", "信州区");
			dic.Add("361121", "上饶县");
			dic.Add("361122", "广丰县");
			dic.Add("361123", "玉山县");
			dic.Add("361124", "铅山县");
			dic.Add("361125", "横峰县");
			dic.Add("361126", "弋阳县");
			dic.Add("361127", "余干县");
			dic.Add("361128", "鄱阳县");
			dic.Add("361129", "万年县");
			dic.Add("361130", "婺源县");
			dic.Add("361181", "德兴市");
			dic.Add("370101", "市辖区");
			dic.Add("370102", "历下区");
			dic.Add("370103", "市中区");
			dic.Add("370104", "槐荫区");
			dic.Add("370105", "天桥区");
			dic.Add("370112", "历城区");
			dic.Add("370113", "长清区");
			dic.Add("370124", "平阴县");
			dic.Add("370125", "济阳县");
			dic.Add("370126", "商河县");
			dic.Add("370181", "章丘市");
			dic.Add("370201", "市辖区");
			dic.Add("370202", "市南区");
			dic.Add("370203", "市北区");
			dic.Add("370205", "四方区");
			dic.Add("370211", "黄岛区");
			dic.Add("370212", "崂山区");
			dic.Add("370213", "李沧区");
			dic.Add("370214", "城阳区");
			dic.Add("370281", "胶州市");
			dic.Add("370282", "即墨市");
			dic.Add("370283", "平度市");
			dic.Add("370284", "胶南市");
			dic.Add("370285", "莱西市");
			dic.Add("370301", "市辖区");
			dic.Add("370302", "淄川区");
			dic.Add("370303", "张店区");
			dic.Add("370304", "博山区");
			dic.Add("370305", "临淄区");
			dic.Add("370306", "周村区");
			dic.Add("370321", "桓台县");
			dic.Add("370322", "高青县");
			dic.Add("370323", "沂源县");
			dic.Add("370401", "市辖区");
			dic.Add("370402", "市中区");
			dic.Add("370403", "薛城区");
			dic.Add("370404", "峄城区");
			dic.Add("370405", "台儿庄区");
			dic.Add("370406", "山亭区");
			dic.Add("370481", "滕州市");
			dic.Add("370501", "市辖区");
			dic.Add("370502", "东营区");
			dic.Add("370503", "河口区");
			dic.Add("370521", "垦利县");
			dic.Add("370522", "利津县");
			dic.Add("370523", "广饶县");
			dic.Add("370601", "市辖区");
			dic.Add("370602", "芝罘区");
			dic.Add("370611", "福山区");
			dic.Add("370612", "牟平区");
			dic.Add("370613", "莱山区");
			dic.Add("370634", "长岛县");
			dic.Add("370681", "龙口市");
			dic.Add("370682", "莱阳市");
			dic.Add("370683", "莱州市");
			dic.Add("370684", "蓬莱市");
			dic.Add("370685", "招远市");
			dic.Add("370686", "栖霞市");
			dic.Add("370687", "海阳市");
			dic.Add("370701", "市辖区");
			dic.Add("370702", "潍城区");
			dic.Add("370703", "寒亭区");
			dic.Add("370704", "坊子区");
			dic.Add("370705", "奎文区");
			dic.Add("370724", "临朐县");
			dic.Add("370725", "昌乐县");
			dic.Add("370781", "青州市");
			dic.Add("370782", "诸城市");
			dic.Add("370783", "寿光市");
			dic.Add("370784", "安丘市");
			dic.Add("370785", "高密市");
			dic.Add("370786", "昌邑市");
			dic.Add("370801", "市辖区");
			dic.Add("370802", "市中区");
			dic.Add("370811", "任城区");
			dic.Add("370826", "微山县");
			dic.Add("370827", "鱼台县");
			dic.Add("370828", "金乡县");
			dic.Add("370829", "嘉祥县");
			dic.Add("370830", "汶上县");
			dic.Add("370831", "泗水县");
			dic.Add("370832", "梁山县");
			dic.Add("370881", "曲阜市");
			dic.Add("370882", "兖州市");
			dic.Add("370883", "邹城市");
			dic.Add("370901", "市辖区");
			dic.Add("370902", "泰山区");
			dic.Add("370903", "岱岳区");
			dic.Add("370921", "宁阳县");
			dic.Add("370923", "东平县");
			dic.Add("370982", "新泰市");
			dic.Add("370983", "肥城市");
			dic.Add("371001", "市辖区");
			dic.Add("371002", "环翠区");
			dic.Add("371081", "文登市");
			dic.Add("371082", "荣成市");
			dic.Add("371083", "乳山市");
			dic.Add("371101", "市辖区");
			dic.Add("371102", "东港区");
			dic.Add("371103", "岚山区");
			dic.Add("371121", "五莲县");
			dic.Add("371122", "莒县");
			dic.Add("371201", "市辖区");
			dic.Add("371202", "莱城区");
			dic.Add("371203", "钢城区");
			dic.Add("371301", "市辖区");
			dic.Add("371302", "兰山区");
			dic.Add("371311", "罗庄区");
			dic.Add("371312", "河东区");
			dic.Add("371321", "沂南县");
			dic.Add("371322", "郯城县");
			dic.Add("371323", "沂水县");
			dic.Add("371324", "苍山县");
			dic.Add("371325", "费县");
			dic.Add("371326", "平邑县");
			dic.Add("371327", "莒南县");
			dic.Add("371328", "蒙阴县");
			dic.Add("371329", "临沭县");
			dic.Add("371401", "市辖区");
			dic.Add("371402", "德城区");
			dic.Add("371421", "陵县");
			dic.Add("371422", "宁津县");
			dic.Add("371423", "庆云县");
			dic.Add("371424", "临邑县");
			dic.Add("371425", "齐河县");
			dic.Add("371426", "平原县");
			dic.Add("371427", "夏津县");
			dic.Add("371428", "武城县");
			dic.Add("371481", "乐陵市");
			dic.Add("371482", "禹城市");
			dic.Add("371501", "市辖区");
			dic.Add("371502", "东昌府区");
			dic.Add("371521", "阳谷县");
			dic.Add("371522", "莘县");
			dic.Add("371523", "茌平县");
			dic.Add("371524", "东阿县");
			dic.Add("371525", "冠县");
			dic.Add("371526", "高唐县");
			dic.Add("371581", "临清市");
			dic.Add("371601", "市辖区");
			dic.Add("371602", "滨城区");
			dic.Add("371621", "惠民县");
			dic.Add("371622", "阳信县");
			dic.Add("371623", "无棣县");
			dic.Add("371624", "沾化县");
			dic.Add("371625", "博兴县");
			dic.Add("371626", "邹平县");
			dic.Add("371701", "市辖区");
			dic.Add("371702", "牡丹区");
			dic.Add("371721", "曹县");
			dic.Add("371722", "单县");
			dic.Add("371723", "成武县");
			dic.Add("371724", "巨野县");
			dic.Add("371725", "郓城县");
			dic.Add("371726", "鄄城县");
			dic.Add("371727", "定陶县");
			dic.Add("371728", "东明县");
			dic.Add("410101", "市辖区");
			dic.Add("410102", "中原区");
			dic.Add("410103", "二七区");
			dic.Add("410104", "管城回族区");
			dic.Add("410105", "金水区");
			dic.Add("410106", "上街区");
			dic.Add("410108", "邙山区");
			dic.Add("410122", "中牟县");
			dic.Add("410181", "巩义市");
			dic.Add("410182", "荥阳市");
			dic.Add("410183", "新密市");
			dic.Add("410184", "新郑市");
			dic.Add("410185", "登封市");
			dic.Add("410201", "市辖区");
			dic.Add("410202", "龙亭区");
			dic.Add("410203", "顺河回族区");
			dic.Add("410204", "鼓楼区");
			dic.Add("410205", "南关区");
			dic.Add("410211", "郊区");
			dic.Add("410221", "杞县");
			dic.Add("410222", "通许县");
			dic.Add("410223", "尉氏县");
			dic.Add("410224", "开封县");
			dic.Add("410225", "兰考县");
			dic.Add("410301", "市辖区");
			dic.Add("410302", "老城区");
			dic.Add("410303", "西工区");
			dic.Add("410304", "廛河回族区");
			dic.Add("410305", "涧西区");
			dic.Add("410306", "吉利区");
			dic.Add("410307", "洛龙区");
			dic.Add("410322", "孟津县");
			dic.Add("410323", "新安县");
			dic.Add("410324", "栾川县");
			dic.Add("410325", "嵩县");
			dic.Add("410326", "汝阳县");
			dic.Add("410327", "宜阳县");
			dic.Add("410328", "洛宁县");
			dic.Add("410329", "伊川县");
			dic.Add("410381", "偃师市");
			dic.Add("410401", "市辖区");
			dic.Add("410402", "新华区");
			dic.Add("410403", "卫东区");
			dic.Add("410404", "石龙区");
			dic.Add("410411", "湛河区");
			dic.Add("410421", "宝丰县");
			dic.Add("410422", "叶县");
			dic.Add("410423", "鲁山县");
			dic.Add("410425", "郏县");
			dic.Add("410481", "舞钢市");
			dic.Add("410482", "汝州市");
			dic.Add("410501", "市辖区");
			dic.Add("410502", "文峰区");
			dic.Add("410503", "北关区");
			dic.Add("410505", "殷都区");
			dic.Add("410506", "龙安区");
			dic.Add("410522", "安阳县");
			dic.Add("410523", "汤阴县");
			dic.Add("410526", "滑县");
			dic.Add("410527", "内黄县");
			dic.Add("410581", "林州市");
			dic.Add("410601", "市辖区");
			dic.Add("410602", "鹤山区");
			dic.Add("410603", "山城区");
			dic.Add("410611", "淇滨区");
			dic.Add("410621", "浚县");
			dic.Add("410622", "淇县");
			dic.Add("410701", "市辖区");
			dic.Add("410702", "红旗区");
			dic.Add("410703", "卫滨区");
			dic.Add("410704", "凤泉区");
			dic.Add("410711", "牧野区");
			dic.Add("410721", "新乡县");
			dic.Add("410724", "获嘉县");
			dic.Add("410725", "原阳县");
			dic.Add("410726", "延津县");
			dic.Add("410727", "封丘县");
			dic.Add("410728", "长垣县");
			dic.Add("410781", "卫辉市");
			dic.Add("410782", "辉县市");
			dic.Add("410801", "市辖区");
			dic.Add("410802", "解放区");
			dic.Add("410803", "中站区");
			dic.Add("410804", "马村区");
			dic.Add("410811", "山阳区");
			dic.Add("410821", "修武县");
			dic.Add("410822", "博爱县");
			dic.Add("410823", "武陟县");
			dic.Add("410825", "温县");
			dic.Add("410881", "济源市");
			dic.Add("410882", "沁阳市");
			dic.Add("410883", "孟州市");
			dic.Add("410901", "市辖区");
			dic.Add("410902", "华龙区");
			dic.Add("410922", "清丰县");
			dic.Add("410923", "南乐县");
			dic.Add("410926", "范县");
			dic.Add("410927", "台前县");
			dic.Add("410928", "濮阳县");
			dic.Add("411001", "市辖区");
			dic.Add("411002", "魏都区");
			dic.Add("411023", "许昌县");
			dic.Add("411024", "鄢陵县");
			dic.Add("411025", "襄城县");
			dic.Add("411081", "禹州市");
			dic.Add("411082", "长葛市");
			dic.Add("411101", "市辖区");
			dic.Add("411102", "源汇区");
			dic.Add("411103", "郾城区");
			dic.Add("411104", "召陵区");
			dic.Add("411121", "舞阳县");
			dic.Add("411122", "临颍县");
			dic.Add("411201", "市辖区");
			dic.Add("411202", "湖滨区");
			dic.Add("411221", "渑池县");
			dic.Add("411222", "陕县");
			dic.Add("411224", "卢氏县");
			dic.Add("411281", "义马市");
			dic.Add("411282", "灵宝市");
			dic.Add("411301", "市辖区");
			dic.Add("411302", "宛城区");
			dic.Add("411303", "卧龙区");
			dic.Add("411321", "南召县");
			dic.Add("411322", "方城县");
			dic.Add("411323", "西峡县");
			dic.Add("411324", "镇平县");
			dic.Add("411325", "内乡县");
			dic.Add("411326", "淅川县");
			dic.Add("411327", "社旗县");
			dic.Add("411328", "唐河县");
			dic.Add("411329", "新野县");
			dic.Add("411330", "桐柏县");
			dic.Add("411381", "邓州市");
			dic.Add("411401", "市辖区");
			dic.Add("411402", "梁园区");
			dic.Add("411403", "睢阳区");
			dic.Add("411421", "民权县");
			dic.Add("411422", "睢县");
			dic.Add("411423", "宁陵县");
			dic.Add("411424", "柘城县");
			dic.Add("411425", "虞城县");
			dic.Add("411426", "夏邑县");
			dic.Add("411481", "永城市");
			dic.Add("411501", "市辖区");
			dic.Add("411502", "师河区");
			dic.Add("411503", "平桥区");
			dic.Add("411521", "罗山县");
			dic.Add("411522", "光山县");
			dic.Add("411523", "新县");
			dic.Add("411524", "商城县");
			dic.Add("411525", "固始县");
			dic.Add("411526", "潢川县");
			dic.Add("411527", "淮滨县");
			dic.Add("411528", "息县");
			dic.Add("411601", "市辖区");
			dic.Add("411602", "川汇区");
			dic.Add("411621", "扶沟县");
			dic.Add("411622", "西华县");
			dic.Add("411623", "商水县");
			dic.Add("411624", "沈丘县");
			dic.Add("411625", "郸城县");
			dic.Add("411626", "淮阳县");
			dic.Add("411627", "太康县");
			dic.Add("411628", "鹿邑县");
			dic.Add("411681", "项城市");
			dic.Add("411701", "市辖区");
			dic.Add("411702", "驿城区");
			dic.Add("411721", "西平县");
			dic.Add("411722", "上蔡县");
			dic.Add("411723", "平舆县");
			dic.Add("411724", "正阳县");
			dic.Add("411725", "确山县");
			dic.Add("411726", "泌阳县");
			dic.Add("411727", "汝南县");
			dic.Add("411728", "遂平县");
			dic.Add("411729", "新蔡县");
			dic.Add("420101", "市辖区");
			dic.Add("420102", "江岸区");
			dic.Add("420103", "江汉区");
			dic.Add("420104", "乔口区");
			dic.Add("420105", "汉阳区");
			dic.Add("420106", "武昌区");
			dic.Add("420107", "青山区");
			dic.Add("420111", "洪山区");
			dic.Add("420112", "东西湖区");
			dic.Add("420113", "汉南区");
			dic.Add("420114", "蔡甸区");
			dic.Add("420115", "江夏区");
			dic.Add("420116", "黄陂区");
			dic.Add("420117", "新洲区");
			dic.Add("420201", "市辖区");
			dic.Add("420202", "黄石港区");
			dic.Add("420203", "西塞山区");
			dic.Add("420204", "下陆区");
			dic.Add("420205", "铁山区");
			dic.Add("420222", "阳新县");
			dic.Add("420281", "大冶市");
			dic.Add("420301", "市辖区");
			dic.Add("420302", "茅箭区");
			dic.Add("420303", "张湾区");
			dic.Add("420321", "郧县");
			dic.Add("420322", "郧西县");
			dic.Add("420323", "竹山县");
			dic.Add("420324", "竹溪县");
			dic.Add("420325", "房县");
			dic.Add("420381", "丹江口市");
			dic.Add("420501", "市辖区");
			dic.Add("420502", "西陵区");
			dic.Add("420503", "伍家岗区");
			dic.Add("420504", "点军区");
			dic.Add("420505", "猇亭区");
			dic.Add("420506", "夷陵区");
			dic.Add("420525", "远安县");
			dic.Add("420526", "兴山县");
			dic.Add("420527", "秭归县");
			dic.Add("420528", "长阳土家族自治县");
			dic.Add("420529", "五峰土家族自治县");
			dic.Add("420581", "宜都市");
			dic.Add("420582", "当阳市");
			dic.Add("420583", "枝江市");
			dic.Add("420601", "市辖区");
			dic.Add("420602", "襄城区");
			dic.Add("420606", "樊城区");
			dic.Add("420607", "襄阳区");
			dic.Add("420624", "南漳县");
			dic.Add("420625", "谷城县");
			dic.Add("420626", "保康县");
			dic.Add("420682", "老河口市");
			dic.Add("420683", "枣阳市");
			dic.Add("420684", "宜城市");
			dic.Add("420701", "市辖区");
			dic.Add("420702", "梁子湖区");
			dic.Add("420703", "华容区");
			dic.Add("420704", "鄂城区");
			dic.Add("420801", "市辖区");
			dic.Add("420802", "东宝区");
			dic.Add("420804", "掇刀区");
			dic.Add("420821", "京山县");
			dic.Add("420822", "沙洋县");
			dic.Add("420881", "钟祥市");
			dic.Add("420901", "市辖区");
			dic.Add("420902", "孝南区");
			dic.Add("420921", "孝昌县");
			dic.Add("420922", "大悟县");
			dic.Add("420923", "云梦县");
			dic.Add("420981", "应城市");
			dic.Add("420982", "安陆市");
			dic.Add("420984", "汉川市");
			dic.Add("421001", "市辖区");
			dic.Add("421002", "沙市区");
			dic.Add("421003", "荆州区");
			dic.Add("421022", "公安县");
			dic.Add("421023", "监利县");
			dic.Add("421024", "江陵县");
			dic.Add("421081", "石首市");
			dic.Add("421083", "洪湖市");
			dic.Add("421087", "松滋市");
			dic.Add("421101", "市辖区");
			dic.Add("421102", "黄州区");
			dic.Add("421121", "团风县");
			dic.Add("421122", "红安县");
			dic.Add("421123", "罗田县");
			dic.Add("421124", "英山县");
			dic.Add("421125", "浠水县");
			dic.Add("421126", "蕲春县");
			dic.Add("421127", "黄梅县");
			dic.Add("421181", "麻城市");
			dic.Add("421182", "武穴市");
			dic.Add("421201", "市辖区");
			dic.Add("421202", "咸安区");
			dic.Add("421221", "嘉鱼县");
			dic.Add("421222", "通城县");
			dic.Add("421223", "崇阳县");
			dic.Add("421224", "通山县");
			dic.Add("421281", "赤壁市");
			dic.Add("421301", "市辖区");
			dic.Add("421302", "曾都区");
			dic.Add("421381", "广水市");
			dic.Add("422801", "恩施市");
			dic.Add("422802", "利川市");
			dic.Add("422822", "建始县");
			dic.Add("422823", "巴东县");
			dic.Add("422825", "宣恩县");
			dic.Add("422826", "咸丰县");
			dic.Add("422827", "来凤县");
			dic.Add("422828", "鹤峰县");
			dic.Add("429004", "仙桃市");
			dic.Add("429005", "潜江市");
			dic.Add("429006", "天门市");
			dic.Add("429021", "神农架林区");
			dic.Add("430101", "市辖区");
			dic.Add("430102", "芙蓉区");
			dic.Add("430103", "天心区");
			dic.Add("430104", "岳麓区");
			dic.Add("430105", "开福区");
			dic.Add("430111", "雨花区");
			dic.Add("430121", "长沙县");
			dic.Add("430122", "望城县");
			dic.Add("430124", "宁乡县");
			dic.Add("430181", "浏阳市");
			dic.Add("430201", "市辖区");
			dic.Add("430202", "荷塘区");
			dic.Add("430203", "芦淞区");
			dic.Add("430204", "石峰区");
			dic.Add("430211", "天元区");
			dic.Add("430221", "株洲县");
			dic.Add("430223", "攸县");
			dic.Add("430224", "茶陵县");
			dic.Add("430225", "炎陵县");
			dic.Add("430281", "醴陵市");
			dic.Add("430301", "市辖区");
			dic.Add("430302", "雨湖区");
			dic.Add("430304", "岳塘区");
			dic.Add("430321", "湘潭县");
			dic.Add("430381", "湘乡市");
			dic.Add("430382", "韶山市");
			dic.Add("430401", "市辖区");
			dic.Add("430405", "珠晖区");
			dic.Add("430406", "雁峰区");
			dic.Add("430407", "石鼓区");
			dic.Add("430408", "蒸湘区");
			dic.Add("430412", "南岳区");
			dic.Add("430421", "衡阳县");
			dic.Add("430422", "衡南县");
			dic.Add("430423", "衡山县");
			dic.Add("430424", "衡东县");
			dic.Add("430426", "祁东县");
			dic.Add("430481", "耒阳市");
			dic.Add("430482", "常宁市");
			dic.Add("430501", "市辖区");
			dic.Add("430502", "双清区");
			dic.Add("430503", "大祥区");
			dic.Add("430511", "北塔区");
			dic.Add("430521", "邵东县");
			dic.Add("430522", "新邵县");
			dic.Add("430523", "邵阳县");
			dic.Add("430524", "隆回县");
			dic.Add("430525", "洞口县");
			dic.Add("430527", "绥宁县");
			dic.Add("430528", "新宁县");
			dic.Add("430529", "城步苗族自治县");
			dic.Add("430581", "武冈市");
			dic.Add("430601", "市辖区");
			dic.Add("430602", "岳阳楼区");
			dic.Add("430603", "云溪区");
			dic.Add("430611", "君山区");
			dic.Add("430621", "岳阳县");
			dic.Add("430623", "华容县");
			dic.Add("430624", "湘阴县");
			dic.Add("430626", "平江县");
			dic.Add("430681", "汨罗市");
			dic.Add("430682", "临湘市");
			dic.Add("430701", "市辖区");
			dic.Add("430702", "武陵区");
			dic.Add("430703", "鼎城区");
			dic.Add("430721", "安乡县");
			dic.Add("430722", "汉寿县");
			dic.Add("430723", "澧县");
			dic.Add("430724", "临澧县");
			dic.Add("430725", "桃源县");
			dic.Add("430726", "石门县");
			dic.Add("430781", "津市市");
			dic.Add("430801", "市辖区");
			dic.Add("430802", "永定区");
			dic.Add("430811", "武陵源区");
			dic.Add("430821", "慈利县");
			dic.Add("430822", "桑植县");
			dic.Add("430901", "市辖区");
			dic.Add("430902", "资阳区");
			dic.Add("430903", "赫山区");
			dic.Add("430921", "南县");
			dic.Add("430922", "桃江县");
			dic.Add("430923", "安化县");
			dic.Add("430981", "沅江市");
			dic.Add("431001", "市辖区");
			dic.Add("431002", "北湖区");
			dic.Add("431003", "苏仙区");
			dic.Add("431021", "桂阳县");
			dic.Add("431022", "宜章县");
			dic.Add("431023", "永兴县");
			dic.Add("431024", "嘉禾县");
			dic.Add("431025", "临武县");
			dic.Add("431026", "汝城县");
			dic.Add("431027", "桂东县");
			dic.Add("431028", "安仁县");
			dic.Add("431081", "资兴市");
			dic.Add("431101", "市辖区");
			dic.Add("431102", "芝山区");
			dic.Add("431103", "冷水滩区");
			dic.Add("431121", "祁阳县");
			dic.Add("431122", "东安县");
			dic.Add("431123", "双牌县");
			dic.Add("431124", "道县");
			dic.Add("431125", "江永县");
			dic.Add("431126", "宁远县");
			dic.Add("431127", "蓝山县");
			dic.Add("431128", "新田县");
			dic.Add("431129", "江华瑶族自治县");
			dic.Add("431201", "市辖区");
			dic.Add("431202", "鹤城区");
			dic.Add("431221", "中方县");
			dic.Add("431222", "沅陵县");
			dic.Add("431223", "辰溪县");
			dic.Add("431224", "溆浦县");
			dic.Add("431225", "会同县");
			dic.Add("431226", "麻阳苗族自治县");
			dic.Add("431227", "新晃侗族自治县");
			dic.Add("431228", "芷江侗族自治县");
			dic.Add("431229", "靖州苗族侗族自治县");
			dic.Add("431230", "通道侗族自治县");
			dic.Add("431281", "洪江市");
			dic.Add("431301", "市辖区");
			dic.Add("431302", "娄星区");
			dic.Add("431321", "双峰县");
			dic.Add("431322", "新化县");
			dic.Add("431381", "冷水江市");
			dic.Add("431382", "涟源市");
			dic.Add("433101", "吉首市");
			dic.Add("433122", "泸溪县");
			dic.Add("433123", "凤凰县");
			dic.Add("433124", "花垣县");
			dic.Add("433125", "保靖县");
			dic.Add("433126", "古丈县");
			dic.Add("433127", "永顺县");
			dic.Add("433130", "龙山县");
			dic.Add("440101", "市辖区");
			dic.Add("440102", "东山区");
			dic.Add("440103", "荔湾区");
			dic.Add("440104", "越秀区");
			dic.Add("440105", "海珠区");
			dic.Add("440106", "天河区");
			dic.Add("440107", "芳村区");
			dic.Add("440111", "白云区");
			dic.Add("440112", "黄埔区");
			dic.Add("440113", "番禺区");
			dic.Add("440114", "花都区");
			dic.Add("440183", "增城市");
			dic.Add("440184", "从化市");
			dic.Add("440201", "市辖区");
			dic.Add("440203", "武江区");
			dic.Add("440204", "浈江区");
			dic.Add("440205", "曲江区");
			dic.Add("440222", "始兴县");
			dic.Add("440224", "仁化县");
			dic.Add("440229", "翁源县");
			dic.Add("440232", "乳源瑶族自治县");
			dic.Add("440233", "新丰县");
			dic.Add("440281", "乐昌市");
			dic.Add("440282", "南雄市");
			dic.Add("440301", "市辖区");
			dic.Add("440303", "罗湖区");
			dic.Add("440304", "福田区");
			dic.Add("440305", "南山区");
			dic.Add("440306", "宝安区");
			dic.Add("440307", "龙岗区");
			dic.Add("440308", "盐田区");
			dic.Add("440401", "市辖区");
			dic.Add("440402", "香洲区");
			dic.Add("440403", "斗门区");
			dic.Add("440404", "金湾区");
			dic.Add("440501", "市辖区");
			dic.Add("440507", "龙湖区");
			dic.Add("440511", "金平区");
			dic.Add("440512", "濠江区");
			dic.Add("440513", "潮阳区");
			dic.Add("440514", "潮南区");
			dic.Add("440515", "澄海区");
			dic.Add("440523", "南澳县");
			dic.Add("440601", "市辖区");
			dic.Add("440604", "禅城区");
			dic.Add("440605", "南海区");
			dic.Add("440606", "顺德区");
			dic.Add("440607", "三水区");
			dic.Add("440608", "高明区");
			dic.Add("440701", "市辖区");
			dic.Add("440703", "蓬江区");
			dic.Add("440704", "江海区");
			dic.Add("440705", "新会区");
			dic.Add("440781", "台山市");
			dic.Add("440783", "开平市");
			dic.Add("440784", "鹤山市");
			dic.Add("440785", "恩平市");
			dic.Add("440801", "市辖区");
			dic.Add("440802", "赤坎区");
			dic.Add("440803", "霞山区");
			dic.Add("440804", "坡头区");
			dic.Add("440811", "麻章区");
			dic.Add("440823", "遂溪县");
			dic.Add("440825", "徐闻县");
			dic.Add("440881", "廉江市");
			dic.Add("440882", "雷州市");
			dic.Add("440883", "吴川市");
			dic.Add("440901", "市辖区");
			dic.Add("440902", "茂南区");
			dic.Add("440903", "茂港区");
			dic.Add("440923", "电白县");
			dic.Add("440981", "高州市");
			dic.Add("440982", "化州市");
			dic.Add("440983", "信宜市");
			dic.Add("441201", "市辖区");
			dic.Add("441202", "端州区");
			dic.Add("441203", "鼎湖区");
			dic.Add("441223", "广宁县");
			dic.Add("441224", "怀集县");
			dic.Add("441225", "封开县");
			dic.Add("441226", "德庆县");
			dic.Add("441283", "高要市");
			dic.Add("441284", "四会市");
			dic.Add("441301", "市辖区");
			dic.Add("441302", "惠城区");
			dic.Add("441303", "惠阳区");
			dic.Add("441322", "博罗县");
			dic.Add("441323", "惠东县");
			dic.Add("441324", "龙门县");
			dic.Add("441401", "市辖区");
			dic.Add("441402", "梅江区");
			dic.Add("441421", "梅县");
			dic.Add("441422", "大埔县");
			dic.Add("441423", "丰顺县");
			dic.Add("441424", "五华县");
			dic.Add("441426", "平远县");
			dic.Add("441427", "蕉岭县");
			dic.Add("441481", "兴宁市");
			dic.Add("441501", "市辖区");
			dic.Add("441502", "城区");
			dic.Add("441521", "海丰县");
			dic.Add("441523", "陆河县");
			dic.Add("441581", "陆丰市");
			dic.Add("441601", "市辖区");
			dic.Add("441602", "源城区");
			dic.Add("441621", "紫金县");
			dic.Add("441622", "龙川县");
			dic.Add("441623", "连平县");
			dic.Add("441624", "和平县");
			dic.Add("441625", "东源县");
			dic.Add("441701", "市辖区");
			dic.Add("441702", "江城区");
			dic.Add("441721", "阳西县");
			dic.Add("441723", "阳东县");
			dic.Add("441781", "阳春市");
			dic.Add("441801", "市辖区");
			dic.Add("441802", "清城区");
			dic.Add("441821", "佛冈县");
			dic.Add("441823", "阳山县");
			dic.Add("441825", "连山壮族瑶族自治县");
			dic.Add("441826", "连南瑶族自治县");
			dic.Add("441827", "清新县");
			dic.Add("441881", "英德市");
			dic.Add("441882", "连州市");
			dic.Add("445101", "市辖区");
			dic.Add("445102", "湘桥区");
			dic.Add("445121", "潮安县");
			dic.Add("445122", "饶平县");
			dic.Add("445201", "市辖区");
			dic.Add("445202", "榕城区");
			dic.Add("445221", "揭东县");
			dic.Add("445222", "揭西县");
			dic.Add("445224", "惠来县");
			dic.Add("445281", "普宁市");
			dic.Add("445301", "市辖区");
			dic.Add("445302", "云城区");
			dic.Add("445321", "新兴县");
			dic.Add("445322", "郁南县");
			dic.Add("445323", "云安县");
			dic.Add("445381", "罗定市");
			dic.Add("450101", "市辖区");
			dic.Add("450102", "兴宁区");
			dic.Add("450103", "青秀区");
			dic.Add("450105", "江南区");
			dic.Add("450107", "西乡塘区");
			dic.Add("450108", "良庆区");
			dic.Add("450109", "邕宁区");
			dic.Add("450122", "武鸣县");
			dic.Add("450123", "隆安县");
			dic.Add("450124", "马山县");
			dic.Add("450125", "上林县");
			dic.Add("450126", "宾阳县");
			dic.Add("450127", "横县");
			dic.Add("450201", "市辖区");
			dic.Add("450202", "城中区");
			dic.Add("450203", "鱼峰区");
			dic.Add("450204", "柳南区");
			dic.Add("450205", "柳北区");
			dic.Add("450221", "柳江县");
			dic.Add("450222", "柳城县");
			dic.Add("450223", "鹿寨县");
			dic.Add("450224", "融安县");
			dic.Add("450225", "融水苗族自治县");
			dic.Add("450226", "三江侗族自治县");
			dic.Add("450301", "市辖区");
			dic.Add("450302", "秀峰区");
			dic.Add("450303", "叠彩区");
			dic.Add("450304", "象山区");
			dic.Add("450305", "七星区");
			dic.Add("450311", "雁山区");
			dic.Add("450321", "阳朔县");
			dic.Add("450322", "临桂县");
			dic.Add("450323", "灵川县");
			dic.Add("450324", "全州县");
			dic.Add("450325", "兴安县");
			dic.Add("450326", "永福县");
			dic.Add("450327", "灌阳县");
			dic.Add("450328", "龙胜各族自治县");
			dic.Add("450329", "资源县");
			dic.Add("450330", "平乐县");
			dic.Add("450331", "荔蒲县");
			dic.Add("450332", "恭城瑶族自治县");
			dic.Add("450401", "市辖区");
			dic.Add("450403", "万秀区");
			dic.Add("450404", "蝶山区");
			dic.Add("450405", "长洲区");
			dic.Add("450421", "苍梧县");
			dic.Add("450422", "藤县");
			dic.Add("450423", "蒙山县");
			dic.Add("450481", "岑溪市");
			dic.Add("450501", "市辖区");
			dic.Add("450502", "海城区");
			dic.Add("450503", "银海区");
			dic.Add("450512", "铁山港区");
			dic.Add("450521", "合浦县");
			dic.Add("450601", "市辖区");
			dic.Add("450602", "港口区");
			dic.Add("450603", "防城区");
			dic.Add("450621", "上思县");
			dic.Add("450681", "东兴市");
			dic.Add("450701", "市辖区");
			dic.Add("450702", "钦南区");
			dic.Add("450703", "钦北区");
			dic.Add("450721", "灵山县");
			dic.Add("450722", "浦北县");
			dic.Add("450801", "市辖区");
			dic.Add("450802", "港北区");
			dic.Add("450803", "港南区");
			dic.Add("450804", "覃塘区");
			dic.Add("450821", "平南县");
			dic.Add("450881", "桂平市");
			dic.Add("450901", "市辖区");
			dic.Add("450902", "玉州区");
			dic.Add("450921", "容县");
			dic.Add("450922", "陆川县");
			dic.Add("450923", "博白县");
			dic.Add("450924", "兴业县");
			dic.Add("450981", "北流市");
			dic.Add("451001", "市辖区");
			dic.Add("451002", "右江区");
			dic.Add("451021", "田阳县");
			dic.Add("451022", "田东县");
			dic.Add("451023", "平果县");
			dic.Add("451024", "德保县");
			dic.Add("451025", "靖西县");
			dic.Add("451026", "那坡县");
			dic.Add("451027", "凌云县");
			dic.Add("451028", "乐业县");
			dic.Add("451029", "田林县");
			dic.Add("451030", "西林县");
			dic.Add("451031", "隆林各族自治县");
			dic.Add("451101", "市辖区");
			dic.Add("451102", "八步区");
			dic.Add("451121", "昭平县");
			dic.Add("451122", "钟山县");
			dic.Add("451123", "富川瑶族自治县");
			dic.Add("451201", "市辖区");
			dic.Add("451202", "金城江区");
			dic.Add("451221", "南丹县");
			dic.Add("451222", "天峨县");
			dic.Add("451223", "凤山县");
			dic.Add("451224", "东兰县");
			dic.Add("451225", "罗城仫佬族自治县");
			dic.Add("451226", "环江毛南族自治县");
			dic.Add("451227", "巴马瑶族自治县");
			dic.Add("451228", "都安瑶族自治县");
			dic.Add("451229", "大化瑶族自治县");
			dic.Add("451281", "宜州市");
			dic.Add("451301", "市辖区");
			dic.Add("451302", "兴宾区");
			dic.Add("451321", "忻城县");
			dic.Add("451322", "象州县");
			dic.Add("451323", "武宣县");
			dic.Add("451324", "金秀瑶族自治县");
			dic.Add("451381", "合山市");
			dic.Add("451401", "市辖区");
			dic.Add("451402", "江洲区");
			dic.Add("451421", "扶绥县");
			dic.Add("451422", "宁明县");
			dic.Add("451423", "龙州县");
			dic.Add("451424", "大新县");
			dic.Add("451425", "天等县");
			dic.Add("451481", "凭祥市");
			dic.Add("460101", "市辖区");
			dic.Add("460105", "秀英区");
			dic.Add("460106", "龙华区");
			dic.Add("460107", "琼山区");
			dic.Add("460108", "美兰区");
			dic.Add("460201", "市辖区");
			dic.Add("469001", "五指山市");
			dic.Add("469002", "琼海市");
			dic.Add("469003", "儋州市");
			dic.Add("469005", "文昌市");
			dic.Add("469006", "万宁市");
			dic.Add("469007", "东方市");
			dic.Add("469025", "定安县");
			dic.Add("469026", "屯昌县");
			dic.Add("469027", "澄迈县");
			dic.Add("469028", "临高县");
			dic.Add("469030", "白沙黎族自治县");
			dic.Add("469031", "昌江黎族自治县");
			dic.Add("469033", "乐东黎族自治县");
			dic.Add("469034", "陵水黎族自治县");
			dic.Add("469035", "保亭黎族苗族自治县");
			dic.Add("469036", "琼中黎族苗族自治县");
			dic.Add("469037", "西沙群岛");
			dic.Add("469038", "南沙群岛");
			dic.Add("469039", "中沙群岛的岛礁及其海域");
			dic.Add("500101", "万州区");
			dic.Add("500102", "涪陵区");
			dic.Add("500103", "渝中区");
			dic.Add("500104", "大渡口区");
			dic.Add("500105", "江北区");
			dic.Add("500106", "沙坪坝区");
			dic.Add("500107", "九龙坡区");
			dic.Add("500108", "南岸区");
			dic.Add("500109", "北碚区");
			dic.Add("500110", "万盛区");
			dic.Add("500111", "双桥区");
			dic.Add("500112", "渝北区");
			dic.Add("500113", "巴南区");
			dic.Add("500114", "黔江区");
			dic.Add("500115", "长寿区");
			dic.Add("500222", "綦江县");
			dic.Add("500223", "潼南县");
			dic.Add("500224", "铜梁县");
			dic.Add("500225", "大足县");
			dic.Add("500226", "荣昌县");
			dic.Add("500227", "璧山县");
			dic.Add("500228", "梁平县");
			dic.Add("500229", "城口县");
			dic.Add("500230", "丰都县");
			dic.Add("500231", "垫江县");
			dic.Add("500232", "武隆县");
			dic.Add("500233", "忠县");
			dic.Add("500234", "开县");
			dic.Add("500235", "云阳县");
			dic.Add("500236", "奉节县");
			dic.Add("500237", "巫山县");
			dic.Add("500238", "巫溪县");
			dic.Add("500240", "石柱土家族自治县");
			dic.Add("500241", "秀山土家族苗族自治县");
			dic.Add("500242", "酉阳土家族苗族自治县");
			dic.Add("500243", "彭水苗族土家族自治县");
			dic.Add("500381", "江津市");
			dic.Add("500382", "合川市");
			dic.Add("500383", "永川市");
			dic.Add("500384", "南川市");
			dic.Add("510101", "市辖区");
			dic.Add("510104", "锦江区");
			dic.Add("510105", "青羊区");
			dic.Add("510106", "金牛区");
			dic.Add("510107", "武侯区");
			dic.Add("510108", "成华区");
			dic.Add("510112", "龙泉驿区");
			dic.Add("510113", "青白江区");
			dic.Add("510114", "新都区");
			dic.Add("510115", "温江区");
			dic.Add("510121", "金堂县");
			dic.Add("510122", "双流县");
			dic.Add("510124", "郫县");
			dic.Add("510129", "大邑县");
			dic.Add("510131", "蒲江县");
			dic.Add("510132", "新津县");
			dic.Add("510181", "都江堰市");
			dic.Add("510182", "彭州市");
			dic.Add("510183", "邛崃市");
			dic.Add("510184", "崇州市");
			dic.Add("510301", "市辖区");
			dic.Add("510302", "自流井区");
			dic.Add("510303", "贡井区");
			dic.Add("510304", "大安区");
			dic.Add("510311", "沿滩区");
			dic.Add("510321", "荣县");
			dic.Add("510322", "富顺县");
			dic.Add("510401", "市辖区");
			dic.Add("510402", "东区");
			dic.Add("510403", "西区");
			dic.Add("510411", "仁和区");
			dic.Add("510421", "米易县");
			dic.Add("510422", "盐边县");
			dic.Add("510501", "市辖区");
			dic.Add("510502", "江阳区");
			dic.Add("510503", "纳溪区");
			dic.Add("510504", "龙马潭区");
			dic.Add("510521", "泸县");
			dic.Add("510522", "合江县");
			dic.Add("510524", "叙永县");
			dic.Add("510525", "古蔺县");
			dic.Add("510601", "市辖区");
			dic.Add("510603", "旌阳区");
			dic.Add("510623", "中江县");
			dic.Add("510626", "罗江县");
			dic.Add("510681", "广汉市");
			dic.Add("510682", "什邡市");
			dic.Add("510683", "绵竹市");
			dic.Add("510701", "市辖区");
			dic.Add("510703", "涪城区");
			dic.Add("510704", "游仙区");
			dic.Add("510722", "三台县");
			dic.Add("510723", "盐亭县");
			dic.Add("510724", "安县");
			dic.Add("510725", "梓潼县");
			dic.Add("510726", "北川羌族自治县");
			dic.Add("510727", "平武县");
			dic.Add("510781", "江油市");
			dic.Add("510801", "市辖区");
			dic.Add("510802", "市中区");
			dic.Add("510811", "元坝区");
			dic.Add("510812", "朝天区");
			dic.Add("510821", "旺苍县");
			dic.Add("510822", "青川县");
			dic.Add("510823", "剑阁县");
			dic.Add("510824", "苍溪县");
			dic.Add("510901", "市辖区");
			dic.Add("510903", "船山区");
			dic.Add("510904", "安居区");
			dic.Add("510921", "蓬溪县");
			dic.Add("510922", "射洪县");
			dic.Add("510923", "大英县");
			dic.Add("511001", "市辖区");
			dic.Add("511002", "市中区");
			dic.Add("511011", "东兴区");
			dic.Add("511024", "威远县");
			dic.Add("511025", "资中县");
			dic.Add("511028", "隆昌县");
			dic.Add("511101", "市辖区");
			dic.Add("511102", "市中区");
			dic.Add("511111", "沙湾区");
			dic.Add("511112", "五通桥区");
			dic.Add("511113", "金口河区");
			dic.Add("511123", "犍为县");
			dic.Add("511124", "井研县");
			dic.Add("511126", "夹江县");
			dic.Add("511129", "沐川县");
			dic.Add("511132", "峨边彝族自治县");
			dic.Add("511133", "马边彝族自治县");
			dic.Add("511181", "峨眉山市");
			dic.Add("511301", "市辖区");
			dic.Add("511302", "顺庆区");
			dic.Add("511303", "高坪区");
			dic.Add("511304", "嘉陵区");
			dic.Add("511321", "南部县");
			dic.Add("511322", "营山县");
			dic.Add("511323", "蓬安县");
			dic.Add("511324", "仪陇县");
			dic.Add("511325", "西充县");
			dic.Add("511381", "阆中市");
			dic.Add("511401", "市辖区");
			dic.Add("511402", "东坡区");
			dic.Add("511421", "仁寿县");
			dic.Add("511422", "彭山县");
			dic.Add("511423", "洪雅县");
			dic.Add("511424", "丹棱县");
			dic.Add("511425", "青神县");
			dic.Add("511501", "市辖区");
			dic.Add("511502", "翠屏区");
			dic.Add("511521", "宜宾县");
			dic.Add("511522", "南溪县");
			dic.Add("511523", "江安县");
			dic.Add("511524", "长宁县");
			dic.Add("511525", "高县");
			dic.Add("511526", "珙县");
			dic.Add("511527", "筠连县");
			dic.Add("511528", "兴文县");
			dic.Add("511529", "屏山县");
			dic.Add("511601", "市辖区");
			dic.Add("511602", "广安区");
			dic.Add("511621", "岳池县");
			dic.Add("511622", "武胜县");
			dic.Add("511623", "邻水县");
			dic.Add("511681", "华莹市");
			dic.Add("511701", "市辖区");
			dic.Add("511702", "通川区");
			dic.Add("511721", "达县");
			dic.Add("511722", "宣汉县");
			dic.Add("511723", "开江县");
			dic.Add("511724", "大竹县");
			dic.Add("511725", "渠县");
			dic.Add("511781", "万源市");
			dic.Add("511801", "市辖区");
			dic.Add("511802", "雨城区");
			dic.Add("511821", "名山县");
			dic.Add("511822", "荥经县");
			dic.Add("511823", "汉源县");
			dic.Add("511824", "石棉县");
			dic.Add("511825", "天全县");
			dic.Add("511826", "芦山县");
			dic.Add("511827", "宝兴县");
			dic.Add("511901", "市辖区");
			dic.Add("511902", "巴州区");
			dic.Add("511921", "通江县");
			dic.Add("511922", "南江县");
			dic.Add("511923", "平昌县");
			dic.Add("512001", "市辖区");
			dic.Add("512002", "雁江区");
			dic.Add("512021", "安岳县");
			dic.Add("512022", "乐至县");
			dic.Add("512081", "简阳市");
			dic.Add("513221", "汶川县");
			dic.Add("513222", "理县");
			dic.Add("513223", "茂县");
			dic.Add("513224", "松潘县");
			dic.Add("513225", "九寨沟县");
			dic.Add("513226", "金川县");
			dic.Add("513227", "小金县");
			dic.Add("513228", "黑水县");
			dic.Add("513229", "马尔康县");
			dic.Add("513230", "壤塘县");
			dic.Add("513231", "阿坝县");
			dic.Add("513232", "若尔盖县");
			dic.Add("513233", "红原县");
			dic.Add("513321", "康定县");
			dic.Add("513322", "泸定县");
			dic.Add("513323", "丹巴县");
			dic.Add("513324", "九龙县");
			dic.Add("513325", "雅江县");
			dic.Add("513326", "道孚县");
			dic.Add("513327", "炉霍县");
			dic.Add("513328", "甘孜县");
			dic.Add("513329", "新龙县");
			dic.Add("513330", "德格县");
			dic.Add("513331", "白玉县");
			dic.Add("513332", "石渠县");
			dic.Add("513333", "色达县");
			dic.Add("513334", "理塘县");
			dic.Add("513335", "巴塘县");
			dic.Add("513336", "乡城县");
			dic.Add("513337", "稻城县");
			dic.Add("513338", "得荣县");
			dic.Add("513401", "西昌市");
			dic.Add("513422", "木里藏族自治县");
			dic.Add("513423", "盐源县");
			dic.Add("513424", "德昌县");
			dic.Add("513425", "会理县");
			dic.Add("513426", "会东县");
			dic.Add("513427", "宁南县");
			dic.Add("513428", "普格县");
			dic.Add("513429", "布拖县");
			dic.Add("513430", "金阳县");
			dic.Add("513431", "昭觉县");
			dic.Add("513432", "喜德县");
			dic.Add("513433", "冕宁县");
			dic.Add("513434", "越西县");
			dic.Add("513435", "甘洛县");
			dic.Add("513436", "美姑县");
			dic.Add("513437", "雷波县");
			dic.Add("520101", "市辖区");
			dic.Add("520102", "南明区");
			dic.Add("520103", "云岩区");
			dic.Add("520111", "花溪区");
			dic.Add("520112", "乌当区");
			dic.Add("520113", "白云区");
			dic.Add("520114", "小河区");
			dic.Add("520121", "开阳县");
			dic.Add("520122", "息烽县");
			dic.Add("520123", "修文县");
			dic.Add("520181", "清镇市");
			dic.Add("520201", "钟山区");
			dic.Add("520203", "六枝特区");
			dic.Add("520221", "水城县");
			dic.Add("520222", "盘县");
			dic.Add("520301", "市辖区");
			dic.Add("520302", "红花岗区");
			dic.Add("520303", "汇川区");
			dic.Add("520321", "遵义县");
			dic.Add("520322", "桐梓县");
			dic.Add("520323", "绥阳县");
			dic.Add("520324", "正安县");
			dic.Add("520325", "道真仡佬族苗族自治县");
			dic.Add("520326", "务川仡佬族苗族自治县");
			dic.Add("520327", "凤冈县");
			dic.Add("520328", "湄潭县");
			dic.Add("520329", "余庆县");
			dic.Add("520330", "习水县");
			dic.Add("520381", "赤水市");
			dic.Add("520382", "仁怀市");
			dic.Add("520401", "市辖区");
			dic.Add("520402", "西秀区");
			dic.Add("520421", "平坝县");
			dic.Add("520422", "普定县");
			dic.Add("520423", "镇宁布依族苗族自治县");
			dic.Add("520424", "关岭布依族苗族自治县");
			dic.Add("520425", "紫云苗族布依族自治县");
			dic.Add("522201", "铜仁市");
			dic.Add("522222", "江口县");
			dic.Add("522223", "玉屏侗族自治县");
			dic.Add("522224", "石阡县");
			dic.Add("522225", "思南县");
			dic.Add("522226", "印江土家族苗族自治县");
			dic.Add("522227", "德江县");
			dic.Add("522228", "沿河土家族自治县");
			dic.Add("522229", "松桃苗族自治县");
			dic.Add("522230", "万山特区");
			dic.Add("522301", "兴义市");
			dic.Add("522322", "兴仁县");
			dic.Add("522323", "普安县");
			dic.Add("522324", "晴隆县");
			dic.Add("522325", "贞丰县");
			dic.Add("522326", "望谟县");
			dic.Add("522327", "册亨县");
			dic.Add("522328", "安龙县");
			dic.Add("522401", "毕节市");
			dic.Add("522422", "大方县");
			dic.Add("522423", "黔西县");
			dic.Add("522424", "金沙县");
			dic.Add("522425", "织金县");
			dic.Add("522426", "纳雍县");
			dic.Add("522427", "威宁彝族回族苗族自治县");
			dic.Add("522428", "赫章县");
			dic.Add("522601", "凯里市");
			dic.Add("522622", "黄平县");
			dic.Add("522623", "施秉县");
			dic.Add("522624", "三穗县");
			dic.Add("522625", "镇远县");
			dic.Add("522626", "岑巩县");
			dic.Add("522627", "天柱县");
			dic.Add("522628", "锦屏县");
			dic.Add("522629", "剑河县");
			dic.Add("522630", "台江县");
			dic.Add("522631", "黎平县");
			dic.Add("522632", "榕江县");
			dic.Add("522633", "从江县");
			dic.Add("522634", "雷山县");
			dic.Add("522635", "麻江县");
			dic.Add("522636", "丹寨县");
			dic.Add("522701", "都匀市");
			dic.Add("522702", "福泉市");
			dic.Add("522722", "荔波县");
			dic.Add("522723", "贵定县");
			dic.Add("522725", "瓮安县");
			dic.Add("522726", "独山县");
			dic.Add("522727", "平塘县");
			dic.Add("522728", "罗甸县");
			dic.Add("522729", "长顺县");
			dic.Add("522730", "龙里县");
			dic.Add("522731", "惠水县");
			dic.Add("522732", "三都水族自治县");
			dic.Add("530101", "市辖区");
			dic.Add("530102", "五华区");
			dic.Add("530103", "盘龙区");
			dic.Add("530111", "官渡区");
			dic.Add("530112", "西山区");
			dic.Add("530113", "东川区");
			dic.Add("530121", "呈贡县");
			dic.Add("530122", "晋宁县");
			dic.Add("530124", "富民县");
			dic.Add("530125", "宜良县");
			dic.Add("530126", "石林彝族自治县");
			dic.Add("530127", "嵩明县");
			dic.Add("530128", "禄劝彝族苗族自治县");
			dic.Add("530129", "寻甸回族彝族自治县");
			dic.Add("530181", "安宁市");
			dic.Add("530301", "市辖区");
			dic.Add("530302", "麒麟区");
			dic.Add("530321", "马龙县");
			dic.Add("530322", "陆良县");
			dic.Add("530323", "师宗县");
			dic.Add("530324", "罗平县");
			dic.Add("530325", "富源县");
			dic.Add("530326", "会泽县");
			dic.Add("530328", "沾益县");
			dic.Add("530381", "宣威市");
			dic.Add("530401", "市辖区");
			dic.Add("530402", "红塔区");
			dic.Add("530421", "江川县");
			dic.Add("530422", "澄江县");
			dic.Add("530423", "通海县");
			dic.Add("530424", "华宁县");
			dic.Add("530425", "易门县");
			dic.Add("530426", "峨山彝族自治县");
			dic.Add("530427", "新平彝族傣族自治县");
			dic.Add("530428", "元江哈尼族彝族傣族自治县");
			dic.Add("530501", "市辖区");
			dic.Add("530502", "隆阳区");
			dic.Add("530521", "施甸县");
			dic.Add("530522", "腾冲县");
			dic.Add("530523", "龙陵县");
			dic.Add("530524", "昌宁县");
			dic.Add("530601", "市辖区");
			dic.Add("530602", "昭阳区");
			dic.Add("530621", "鲁甸县");
			dic.Add("530622", "巧家县");
			dic.Add("530623", "盐津县");
			dic.Add("530624", "大关县");
			dic.Add("530625", "永善县");
			dic.Add("530626", "绥江县");
			dic.Add("530627", "镇雄县");
			dic.Add("530628", "彝良县");
			dic.Add("530629", "威信县");
			dic.Add("530630", "水富县");
			dic.Add("530701", "市辖区");
			dic.Add("530702", "古城区");
			dic.Add("530721", "玉龙纳西族自治县");
			dic.Add("530722", "永胜县");
			dic.Add("530723", "华坪县");
			dic.Add("530724", "宁蒗彝族自治县");
			dic.Add("530801", "市辖区");
			dic.Add("530802", "翠云区");
			dic.Add("530821", "普洱哈尼族彝族自治县");
			dic.Add("530822", "墨江哈尼族自治县");
			dic.Add("530823", "景东彝族自治县");
			dic.Add("530824", "景谷傣族彝族自治县");
			dic.Add("530825", "镇沅彝族哈尼族拉祜族自治县");
			dic.Add("530826", "江城哈尼族彝族自治县");
			dic.Add("530827", "孟连傣族拉祜族佤族自治县");
			dic.Add("530828", "澜沧拉祜族自治县");
			dic.Add("530829", "西盟佤族自治县");
			dic.Add("530901", "市辖区");
			dic.Add("530902", "临翔区");
			dic.Add("530921", "凤庆县");
			dic.Add("530922", "云县");
			dic.Add("530923", "永德县");
			dic.Add("530924", "镇康县");
			dic.Add("530925", "双江拉祜族佤族布朗族傣族自治县");
			dic.Add("530926", "耿马傣族佤族自治县");
			dic.Add("530927", "沧源佤族自治县");
			dic.Add("532301", "楚雄市");
			dic.Add("532322", "双柏县");
			dic.Add("532323", "牟定县");
			dic.Add("532324", "南华县");
			dic.Add("532325", "姚安县");
			dic.Add("532326", "大姚县");
			dic.Add("532327", "永仁县");
			dic.Add("532328", "元谋县");
			dic.Add("532329", "武定县");
			dic.Add("532331", "禄丰县");
			dic.Add("532501", "个旧市");
			dic.Add("532502", "开远市");
			dic.Add("532522", "蒙自县");
			dic.Add("532523", "屏边苗族自治县");
			dic.Add("532524", "建水县");
			dic.Add("532525", "石屏县");
			dic.Add("532526", "弥勒县");
			dic.Add("532527", "泸西县");
			dic.Add("532528", "元阳县");
			dic.Add("532529", "红河县");
			dic.Add("532530", "金平苗族瑶族傣族自治县");
			dic.Add("532531", "绿春县");
			dic.Add("532532", "河口瑶族自治县");
			dic.Add("532621", "文山县");
			dic.Add("532622", "砚山县");
			dic.Add("532623", "西畴县");
			dic.Add("532624", "麻栗坡县");
			dic.Add("532625", "马关县");
			dic.Add("532626", "丘北县");
			dic.Add("532627", "广南县");
			dic.Add("532628", "富宁县");
			dic.Add("532801", "景洪市");
			dic.Add("532822", "勐海县");
			dic.Add("532823", "勐腊县");
			dic.Add("532901", "大理市");
			dic.Add("532922", "漾濞彝族自治县");
			dic.Add("532923", "祥云县");
			dic.Add("532924", "宾川县");
			dic.Add("532925", "弥渡县");
			dic.Add("532926", "南涧彝族自治县");
			dic.Add("532927", "巍山彝族回族自治县");
			dic.Add("532928", "永平县");
			dic.Add("532929", "云龙县");
			dic.Add("532930", "洱源县");
			dic.Add("532931", "剑川县");
			dic.Add("532932", "鹤庆县");
			dic.Add("533102", "瑞丽市");
			dic.Add("533103", "潞西市");
			dic.Add("533122", "梁河县");
			dic.Add("533123", "盈江县");
			dic.Add("533124", "陇川县");
			dic.Add("533321", "泸水县");
			dic.Add("533323", "福贡县");
			dic.Add("533324", "贡山独龙族怒族自治县");
			dic.Add("533325", "兰坪白族普米族自治县");
			dic.Add("533421", "香格里拉县");
			dic.Add("533422", "德钦县");
			dic.Add("533423", "维西傈僳族自治县");
			dic.Add("540101", "市辖区");
			dic.Add("540102", "城关区");
			dic.Add("540121", "林周县");
			dic.Add("540122", "当雄县");
			dic.Add("540123", "尼木县");
			dic.Add("540124", "曲水县");
			dic.Add("540125", "堆龙德庆县");
			dic.Add("540126", "达孜县");
			dic.Add("540127", "墨竹工卡县");
			dic.Add("542121", "昌都县");
			dic.Add("542122", "江达县");
			dic.Add("542123", "贡觉县");
			dic.Add("542124", "类乌齐县");
			dic.Add("542125", "丁青县");
			dic.Add("542126", "察雅县");
			dic.Add("542127", "八宿县");
			dic.Add("542128", "左贡县");
			dic.Add("542129", "芒康县");
			dic.Add("542132", "洛隆县");
			dic.Add("542133", "边坝县");
			dic.Add("542221", "乃东县");
			dic.Add("542222", "扎囊县");
			dic.Add("542223", "贡嘎县");
			dic.Add("542224", "桑日县");
			dic.Add("542225", "琼结县");
			dic.Add("542226", "曲松县");
			dic.Add("542227", "措美县");
			dic.Add("542228", "洛扎县");
			dic.Add("542229", "加查县");
			dic.Add("542231", "隆子县");
			dic.Add("542232", "错那县");
			dic.Add("542233", "浪卡子县");
			dic.Add("542301", "日喀则市");
			dic.Add("542322", "南木林县");
			dic.Add("542323", "江孜县");
			dic.Add("542324", "定日县");
			dic.Add("542325", "萨迦县");
			dic.Add("542326", "拉孜县");
			dic.Add("542327", "昂仁县");
			dic.Add("542328", "谢通门县");
			dic.Add("542329", "白朗县");
			dic.Add("542330", "仁布县");
			dic.Add("542331", "康马县");
			dic.Add("542332", "定结县");
			dic.Add("542333", "仲巴县");
			dic.Add("542334", "亚东县");
			dic.Add("542335", "吉隆县");
			dic.Add("542336", "聂拉木县");
			dic.Add("542337", "萨嘎县");
			dic.Add("542338", "岗巴县");
			dic.Add("542421", "那曲县");
			dic.Add("542422", "嘉黎县");
			dic.Add("542423", "比如县");
			dic.Add("542424", "聂荣县");
			dic.Add("542425", "安多县");
			dic.Add("542426", "申扎县");
			dic.Add("542427", "索县");
			dic.Add("542428", "班戈县");
			dic.Add("542429", "巴青县");
			dic.Add("542430", "尼玛县");
			dic.Add("542521", "普兰县");
			dic.Add("542522", "札达县");
			dic.Add("542523", "噶尔县");
			dic.Add("542524", "日土县");
			dic.Add("542525", "革吉县");
			dic.Add("542526", "改则县");
			dic.Add("542527", "措勤县");
			dic.Add("542621", "林芝县");
			dic.Add("542622", "工布江达县");
			dic.Add("542623", "米林县");
			dic.Add("542624", "墨脱县");
			dic.Add("542625", "波密县");
			dic.Add("542626", "察隅县");
			dic.Add("542627", "朗县");
			dic.Add("610101", "市辖区");
			dic.Add("610102", "新城区");
			dic.Add("610103", "碑林区");
			dic.Add("610104", "莲湖区");
			dic.Add("610111", "灞桥区");
			dic.Add("610112", "未央区");
			dic.Add("610113", "雁塔区");
			dic.Add("610114", "阎良区");
			dic.Add("610115", "临潼区");
			dic.Add("610116", "长安区");
			dic.Add("610122", "蓝田县");
			dic.Add("610124", "周至县");
			dic.Add("610125", "户县");
			dic.Add("610126", "高陵县");
			dic.Add("610201", "市辖区");
			dic.Add("610202", "王益区");
			dic.Add("610203", "印台区");
			dic.Add("610204", "耀州区");
			dic.Add("610222", "宜君县");
			dic.Add("610301", "市辖区");
			dic.Add("610302", "渭滨区");
			dic.Add("610303", "金台区");
			dic.Add("610304", "陈仓区");
			dic.Add("610322", "凤翔县");
			dic.Add("610323", "岐山县");
			dic.Add("610324", "扶风县");
			dic.Add("610326", "眉县");
			dic.Add("610327", "陇县");
			dic.Add("610328", "千阳县");
			dic.Add("610329", "麟游县");
			dic.Add("610330", "凤县");
			dic.Add("610331", "太白县");
			dic.Add("610401", "市辖区");
			dic.Add("610402", "秦都区");
			dic.Add("610403", "杨凌区");
			dic.Add("610404", "渭城区");
			dic.Add("610422", "三原县");
			dic.Add("610423", "泾阳县");
			dic.Add("610424", "乾县");
			dic.Add("610425", "礼泉县");
			dic.Add("610426", "永寿县");
			dic.Add("610427", "彬县");
			dic.Add("610428", "长武县");
			dic.Add("610429", "旬邑县");
			dic.Add("610430", "淳化县");
			dic.Add("610431", "武功县");
			dic.Add("610481", "兴平市");
			dic.Add("610501", "市辖区");
			dic.Add("610502", "临渭区");
			dic.Add("610521", "华县");
			dic.Add("610522", "潼关县");
			dic.Add("610523", "大荔县");
			dic.Add("610524", "合阳县");
			dic.Add("610525", "澄城县");
			dic.Add("610526", "蒲城县");
			dic.Add("610527", "白水县");
			dic.Add("610528", "富平县");
			dic.Add("610581", "韩城市");
			dic.Add("610582", "华阴市");
			dic.Add("610601", "市辖区");
			dic.Add("610602", "宝塔区");
			dic.Add("610621", "延长县");
			dic.Add("610622", "延川县");
			dic.Add("610623", "子长县");
			dic.Add("610624", "安塞县");
			dic.Add("610625", "志丹县");
			dic.Add("610626", "吴旗县");
			dic.Add("610627", "甘泉县");
			dic.Add("610628", "富县");
			dic.Add("610629", "洛川县");
			dic.Add("610630", "宜川县");
			dic.Add("610631", "黄龙县");
			dic.Add("610632", "黄陵县");
			dic.Add("610701", "市辖区");
			dic.Add("610702", "汉台区");
			dic.Add("610721", "南郑县");
			dic.Add("610722", "城固县");
			dic.Add("610723", "洋县");
			dic.Add("610724", "西乡县");
			dic.Add("610725", "勉县");
			dic.Add("610726", "宁强县");
			dic.Add("610727", "略阳县");
			dic.Add("610728", "镇巴县");
			dic.Add("610729", "留坝县");
			dic.Add("610730", "佛坪县");
			dic.Add("610801", "市辖区");
			dic.Add("610802", "榆阳区");
			dic.Add("610821", "神木县");
			dic.Add("610822", "府谷县");
			dic.Add("610823", "横山县");
			dic.Add("610824", "靖边县");
			dic.Add("610825", "定边县");
			dic.Add("610826", "绥德县");
			dic.Add("610827", "米脂县");
			dic.Add("610828", "佳县");
			dic.Add("610829", "吴堡县");
			dic.Add("610830", "清涧县");
			dic.Add("610831", "子洲县");
			dic.Add("610901", "市辖区");
			dic.Add("610902", "汉滨区");
			dic.Add("610921", "汉阴县");
			dic.Add("610922", "石泉县");
			dic.Add("610923", "宁陕县");
			dic.Add("610924", "紫阳县");
			dic.Add("610925", "岚皋县");
			dic.Add("610926", "平利县");
			dic.Add("610927", "镇坪县");
			dic.Add("610928", "旬阳县");
			dic.Add("610929", "白河县");
			dic.Add("611001", "市辖区");
			dic.Add("611002", "商州区");
			dic.Add("611021", "洛南县");
			dic.Add("611022", "丹凤县");
			dic.Add("611023", "商南县");
			dic.Add("611024", "山阳县");
			dic.Add("611025", "镇安县");
			dic.Add("611026", "柞水县");
			dic.Add("620101", "市辖区");
			dic.Add("620102", "城关区");
			dic.Add("620103", "七里河区");
			dic.Add("620104", "西固区");
			dic.Add("620105", "安宁区");
			dic.Add("620111", "红古区");
			dic.Add("620121", "永登县");
			dic.Add("620122", "皋兰县");
			dic.Add("620123", "榆中县");
			dic.Add("620201", "市辖区");
			dic.Add("620301", "市辖区");
			dic.Add("620302", "金川区");
			dic.Add("620321", "永昌县");
			dic.Add("620401", "市辖区");
			dic.Add("620402", "白银区");
			dic.Add("620403", "平川区");
			dic.Add("620421", "靖远县");
			dic.Add("620422", "会宁县");
			dic.Add("620423", "景泰县");
			dic.Add("620501", "市辖区");
			dic.Add("620502", "秦城区");
			dic.Add("620503", "北道区");
			dic.Add("620521", "清水县");
			dic.Add("620522", "秦安县");
			dic.Add("620523", "甘谷县");
			dic.Add("620524", "武山县");
			dic.Add("620525", "张家川回族自治县");
			dic.Add("620601", "市辖区");
			dic.Add("620602", "凉州区");
			dic.Add("620621", "民勤县");
			dic.Add("620622", "古浪县");
			dic.Add("620623", "天祝藏族自治县");
			dic.Add("620701", "市辖区");
			dic.Add("620702", "甘州区");
			dic.Add("620721", "肃南裕固族自治县");
			dic.Add("620722", "民乐县");
			dic.Add("620723", "临泽县");
			dic.Add("620724", "高台县");
			dic.Add("620725", "山丹县");
			dic.Add("620801", "市辖区");
			dic.Add("620802", "崆峒区");
			dic.Add("620821", "泾川县");
			dic.Add("620822", "灵台县");
			dic.Add("620823", "崇信县");
			dic.Add("620824", "华亭县");
			dic.Add("620825", "庄浪县");
			dic.Add("620826", "静宁县");
			dic.Add("620901", "市辖区");
			dic.Add("620902", "肃州区");
			dic.Add("620921", "金塔县");
			dic.Add("620922", "安西县");
			dic.Add("620923", "肃北蒙古族自治县");
			dic.Add("620924", "阿克塞哈萨克族自治县");
			dic.Add("620981", "玉门市");
			dic.Add("620982", "敦煌市");
			dic.Add("621001", "市辖区");
			dic.Add("621002", "西峰区");
			dic.Add("621021", "庆城县");
			dic.Add("621022", "环县");
			dic.Add("621023", "华池县");
			dic.Add("621024", "合水县");
			dic.Add("621025", "正宁县");
			dic.Add("621026", "宁县");
			dic.Add("621027", "镇原县");
			dic.Add("621101", "市辖区");
			dic.Add("621102", "安定区");
			dic.Add("621121", "通渭县");
			dic.Add("621122", "陇西县");
			dic.Add("621123", "渭源县");
			dic.Add("621124", "临洮县");
			dic.Add("621125", "漳县");
			dic.Add("621126", "岷县");
			dic.Add("621201", "市辖区");
			dic.Add("621202", "武都区");
			dic.Add("621221", "成县");
			dic.Add("621222", "文县");
			dic.Add("621223", "宕昌县");
			dic.Add("621224", "康县");
			dic.Add("621225", "西和县");
			dic.Add("621226", "礼县");
			dic.Add("621227", "徽县");
			dic.Add("621228", "两当县");
			dic.Add("622901", "临夏市");
			dic.Add("622921", "临夏县");
			dic.Add("622922", "康乐县");
			dic.Add("622923", "永靖县");
			dic.Add("622924", "广河县");
			dic.Add("622925", "和政县");
			dic.Add("622926", "东乡族自治县");
			dic.Add("622927", "积石山保安族东乡族撒拉族自治县");
			dic.Add("623001", "合作市");
			dic.Add("623021", "临潭县");
			dic.Add("623022", "卓尼县");
			dic.Add("623023", "舟曲县");
			dic.Add("623024", "迭部县");
			dic.Add("623025", "玛曲县");
			dic.Add("623026", "碌曲县");
			dic.Add("623027", "夏河县");
			dic.Add("630101", "市辖区");
			dic.Add("630102", "城东区");
			dic.Add("630103", "城中区");
			dic.Add("630104", "城西区");
			dic.Add("630105", "城北区");
			dic.Add("630121", "大通回族土族自治县");
			dic.Add("630122", "湟中县");
			dic.Add("630123", "湟源县");
			dic.Add("632121", "平安县");
			dic.Add("632122", "民和回族土族自治县");
			dic.Add("632123", "乐都县");
			dic.Add("632126", "互助土族自治县");
			dic.Add("632127", "化隆回族自治县");
			dic.Add("632128", "循化撒拉族自治县");
			dic.Add("632221", "门源回族自治县");
			dic.Add("632222", "祁连县");
			dic.Add("632223", "海晏县");
			dic.Add("632224", "刚察县");
			dic.Add("632321", "同仁县");
			dic.Add("632322", "尖扎县");
			dic.Add("632323", "泽库县");
			dic.Add("632324", "河南蒙古族自治县");
			dic.Add("632521", "共和县");
			dic.Add("632522", "同德县");
			dic.Add("632523", "贵德县");
			dic.Add("632524", "兴海县");
			dic.Add("632525", "贵南县");
			dic.Add("632621", "玛沁县");
			dic.Add("632622", "班玛县");
			dic.Add("632623", "甘德县");
			dic.Add("632624", "达日县");
			dic.Add("632625", "久治县");
			dic.Add("632626", "玛多县");
			dic.Add("632721", "玉树县");
			dic.Add("632722", "杂多县");
			dic.Add("632723", "称多县");
			dic.Add("632724", "治多县");
			dic.Add("632725", "囊谦县");
			dic.Add("632726", "曲麻莱县");
			dic.Add("632801", "格尔木市");
			dic.Add("632802", "德令哈市");
			dic.Add("632821", "乌兰县");
			dic.Add("632822", "都兰县");
			dic.Add("632823", "天峻县");
			dic.Add("640101", "市辖区");
			dic.Add("640104", "兴庆区");
			dic.Add("640105", "西夏区");
			dic.Add("640106", "金凤区");
			dic.Add("640121", "永宁县");
			dic.Add("640122", "贺兰县");
			dic.Add("640181", "灵武市");
			dic.Add("640201", "市辖区");
			dic.Add("640202", "大武口区");
			dic.Add("640205", "惠农区");
			dic.Add("640221", "平罗县");
			dic.Add("640301", "市辖区");
			dic.Add("640302", "利通区");
			dic.Add("640323", "盐池县");
			dic.Add("640324", "同心县");
			dic.Add("640381", "青铜峡市");
			dic.Add("640401", "市辖区");
			dic.Add("640402", "原州区");
			dic.Add("640422", "西吉县");
			dic.Add("640423", "隆德县");
			dic.Add("640424", "泾源县");
			dic.Add("640425", "彭阳县");
			dic.Add("640501", "市辖区");
			dic.Add("640502", "沙坡头区");
			dic.Add("640521", "中宁县");
			dic.Add("640522", "海原县");
			dic.Add("650101", "市辖区");
			dic.Add("650102", "天山区");
			dic.Add("650103", "沙依巴克区");
			dic.Add("650104", "新市区");
			dic.Add("650105", "水磨沟区");
			dic.Add("650106", "头屯河区");
			dic.Add("650107", "达坂城区");
			dic.Add("650108", "东山区");
			dic.Add("650121", "乌鲁木齐县");
			dic.Add("650201", "市辖区");
			dic.Add("650202", "独山子区");
			dic.Add("650203", "克拉玛依区");
			dic.Add("650204", "白碱滩区");
			dic.Add("650205", "乌尔禾区");
			dic.Add("652101", "吐鲁番市");
			dic.Add("652122", "鄯善县");
			dic.Add("652123", "托克逊县");
			dic.Add("652201", "哈密市");
			dic.Add("652222", "巴里坤哈萨克自治县");
			dic.Add("652223", "伊吾县");
			dic.Add("652301", "昌吉市");
			dic.Add("652302", "阜康市");
			dic.Add("652303", "米泉市");
			dic.Add("652323", "呼图壁县");
			dic.Add("652324", "玛纳斯县");
			dic.Add("652325", "奇台县");
			dic.Add("652327", "吉木萨尔县");
			dic.Add("652328", "木垒哈萨克自治县");
			dic.Add("652701", "博乐市");
			dic.Add("652722", "精河县");
			dic.Add("652723", "温泉县");
			dic.Add("652801", "库尔勒市");
			dic.Add("652822", "轮台县");
			dic.Add("652823", "尉犁县");
			dic.Add("652824", "若羌县");
			dic.Add("652825", "且末县");
			dic.Add("652826", "焉耆回族自治县");
			dic.Add("652827", "和静县");
			dic.Add("652828", "和硕县");
			dic.Add("652829", "博湖县");
			dic.Add("652901", "阿克苏市");
			dic.Add("652922", "温宿县");
			dic.Add("652923", "库车县");
			dic.Add("652924", "沙雅县");
			dic.Add("652925", "新和县");
			dic.Add("652926", "拜城县");
			dic.Add("652927", "乌什县");
			dic.Add("652928", "阿瓦提县");
			dic.Add("652929", "柯坪县");
			dic.Add("653001", "阿图什市");
			dic.Add("653022", "阿克陶县");
			dic.Add("653023", "阿合奇县");
			dic.Add("653024", "乌恰县");
			dic.Add("653101", "喀什市");
			dic.Add("653121", "疏附县");
			dic.Add("653122", "疏勒县");
			dic.Add("653123", "英吉沙县");
			dic.Add("653124", "泽普县");
			dic.Add("653125", "莎车县");
			dic.Add("653126", "叶城县");
			dic.Add("653127", "麦盖提县");
			dic.Add("653128", "岳普湖县");
			dic.Add("653129", "伽师县");
			dic.Add("653130", "巴楚县");
			dic.Add("653131", "塔什库尔干塔吉克自治县");
			dic.Add("653201", "和田市");
			dic.Add("653221", "和田县");
			dic.Add("653222", "墨玉县");
			dic.Add("653223", "皮山县");
			dic.Add("653224", "洛浦县");
			dic.Add("653225", "策勒县");
			dic.Add("653226", "于田县");
			dic.Add("653227", "民丰县");
			dic.Add("654002", "伊宁市");
			dic.Add("654003", "奎屯市");
			dic.Add("654021", "伊宁县");
			dic.Add("654022", "察布查尔锡伯自治县");
			dic.Add("654023", "霍城县");
			dic.Add("654024", "巩留县");
			dic.Add("654025", "新源县");
			dic.Add("654026", "昭苏县");
			dic.Add("654027", "特克斯县");
			dic.Add("654028", "尼勒克县");
			dic.Add("654201", "塔城市");
			dic.Add("654202", "乌苏市");
			dic.Add("654221", "额敏县");
			dic.Add("654223", "沙湾县");
			dic.Add("654224", "托里县");
			dic.Add("654225", "裕民县");
			dic.Add("654226", "和布克赛尔蒙古自治县");
			dic.Add("654301", "阿勒泰市");
			dic.Add("654321", "布尔津县");
			dic.Add("654322", "富蕴县");
			dic.Add("654323", "福海县");
			dic.Add("654324", "哈巴河县");
			dic.Add("654325", "青河县");
			dic.Add("654326", "吉木乃县");
			dic.Add("659001", "石河子市");
			dic.Add("659002", "阿拉尔市");
			dic.Add("659003", "图木舒克市");
			dic.Add("659004", "五家渠市");
			#endregion
			string provinceCode = IDCard.Substring(0, 2) + "0000";
			string cityCode = IDCard.Substring(0, 4) + "00";
			string areaCode = IDCard.Substring(0, 6);
			string[] result = new string[3];
			result[0] = "";
			if (dic.ContainsKey(provinceCode))
			{
				result[0] = dic[provinceCode];
			}
			result[1] = "";
			if (dic.ContainsKey(cityCode))
			{
				result[1] = dic[cityCode];
			}
			result[2] = "";
			if (dic.ContainsKey(areaCode))
			{
				result[2] = dic[areaCode];
			}
			return result;
		}
		#endregion

		#region 手机号码处理
		/// <summary>
		/// 得到脱敏处理后的手机号。（例：137*****521）
		/// </summary>
		/// <param name="mobile"></param>
		/// <returns></returns>
		public static string GetEncryptMobile(string mobile)
		{
			if (!DataValidator.IsMobile(mobile))
			{
				return mobile;
			}
			return mobile.Substring(0, 3) + "*****" + mobile.Substring(mobile.Length - 3, 3);
		}
		/// <summary>
		/// 得到手机号码运营商。（例：移动、联通、电信、未知）
		/// </summary>
		/// <param name="phone"></param>
		/// <returns></returns>
		public static string GetMobileOperators(string phone)
		{
			string CMCC = "移动";
			string UNICOM = "联通";
			string TELECOM = "电信";
			string UNKNOWN = "未知";

			// 去除前后的空白
			phone = phone.Trim();
			// 处理国内的+86开头
			if (phone.StartsWith("+"))
			{
				phone = phone.Substring(1);
			}
			if (phone.StartsWith("86"))
			{
				phone = phone.Substring(2);
			}
			// 去除+86后电话号码应为11位
			if (!DataValidator.IsMobile(phone))
			{
				return UNKNOWN;
			}

			// 截取前3或前4位电话号码，判断运营商
			string head1 = phone.Substring(0, 3);
			string head2 = phone.Substring(0, 4);

			// 移动前三位
			bool cmcctemp3 = head1.Equals("134") || head1.Equals("135") || head1.Equals("136")
					|| head1.Equals("137") || head1.Equals("138")
					|| head1.Equals("139") || head1.Equals("147")
					|| head1.Equals("150") || head1.Equals("151")
					|| head1.Equals("152") || head1.Equals("157")
					|| head1.Equals("158") || head1.Equals("159")
					|| head1.Equals("182") || head1.Equals("183")
					|| head1.Equals("184") || head1.Equals("178")
					|| head1.Equals("187") || head1.Equals("188");
			if (cmcctemp3)
			{
				return CMCC;
			}
			// 移动前4位
			bool cmcctemp4 = head2.Equals("1340") || head2.Equals("1341")
					|| head2.Equals("1342") || head2.Equals("1343")
					|| head2.Equals("1344") || head2.Equals("1345")
					|| head2.Equals("1346") || head2.Equals("1347")
					|| head2.Equals("1348") || head2.Equals("1705");
			if (cmcctemp4)
			{
				return CMCC;
			}
			// 联通前3位
			bool unicomtemp = head1.Equals("130") || head1.Equals("131")
					|| head1.Equals("132") || head1.Equals("145")
					|| head1.Equals("155") || head1.Equals("156") || head1.Equals("176")
					|| head1.Equals("185") || head1.Equals("186");
			if (unicomtemp)
			{
				return UNICOM;
			}
			//联通前4位
			bool unicomtemp4 = head1.Equals("1709");
			if (unicomtemp4)
			{
				return UNICOM;
			}
			// 电信前3位
			bool telecomtemp = head1.Equals("133") || head1.Equals("153")
					|| head1.Equals("181") || head1.Equals("177")
					|| head1.Equals("180") || head1.Equals("189");
			if (telecomtemp)
			{
				return TELECOM;
			}
			//电信前4位
			bool telecomtemp4 = head1.Equals("1700");
			if (telecomtemp4)
			{
				return TELECOM;
			}
			return UNKNOWN;
		}
		#endregion

		#region 图片与base64编码互相转换
		/// <summary>
		/// 图片转为base64编码的字符串
		/// </summary>
		/// <param name="Imagefilename">图片物理路径</param>
		/// <returns></returns>
		public static string ImgToBase64String(string Imagefilename)
		{
			try
			{
				Bitmap bmp = new Bitmap(Imagefilename);

				MemoryStream ms = new MemoryStream();
				bmp.Save(ms, ImageFormat.Jpeg);
				byte[] arr = new byte[ms.Length];
				ms.Position = 0;
				ms.Read(arr, 0, (int)ms.Length);
				ms.Close();
				return Convert.ToBase64String(arr);
			}
			catch (Exception)
			{
				return "";
			}
		}
		/// <summary>
		/// base64编码的字符串转为图片。成功返回图片名字。
		/// </summary>
		/// <param name="strbase64"></param>
		/// <param name="saveDir">图片保存目录</param>
		/// <returns></returns>
		public static string Base64StringToImage(string strbase64, string saveDir = "UploadFiles/")
		{
			try
			{
				saveDir = saveDir.Replace("/", FileHelper.DirectorySeparatorChar);
				if (!saveDir.EndsWith(Path.DirectorySeparatorChar.ToString()))
				{
					saveDir = saveDir + Path.DirectorySeparatorChar.ToString();
				}
				string strOriImagePhysical = FileHelper.MapPath(FileHelper.WebRootPath + FileHelper.DirectorySeparatorChar + saveDir.Replace("/", FileHelper.DirectorySeparatorChar));
				if (!Directory.Exists(strOriImagePhysical))
				{
					Directory.CreateDirectory(strOriImagePhysical);
				}
				string strFile = DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".jpg";
				byte[] arr = Convert.FromBase64String(strbase64);
				MemoryStream ms = new MemoryStream(arr);
				Image img = Image.FromStream(ms);
				img.Save(strOriImagePhysical + strFile, ImageFormat.Jpeg);
				return strFile;
			}
			catch (Exception)
			{
				return "";
			}
		}
		#endregion

		#region 其他常用方法
		/// <summary>
		/// 判断是否移动设备
		/// </summary>
		/// <returns></returns>
		public static bool IsMobileBrowser()
		{
			//GETS THE CURRENT USER CONTEXT
			HttpContext context = MyHttpContext.Current;
			if (context == null)
				return false;
			Regex b = new Regex(@"(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|iris|kindle|lge |maemo|midp|mmp|mobile.+firefox|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows ce|xda|xiino", RegexOptions.IgnoreCase | RegexOptions.Multiline);
			Regex v = new Regex(@"1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-", RegexOptions.IgnoreCase | RegexOptions.Multiline);
			string userAgent = context.Request.UserAgent();
			if ((b.IsMatch(userAgent) || v.IsMatch(userAgent.Substring(0, 4))))
			{
				return true;
			}
			return false;
		}

		/// <summary>
		/// 是否微信浏览器
		/// </summary>
		/// <returns></returns>
		public static bool IsWxBrowser()
		{
			HttpContext context = MyHttpContext.Current;
			if (context == null)
			{
				return false;
			}
			
			return context.Request.UserAgent().ToLower().Contains("micromessenger");
		}

		/// <summary>
		/// 判断当前请求参考是否来自于外部网址
		/// </summary>
		/// <returns></returns>
		public static bool IsOutReferrer()
		{
			HttpContext context = MyHttpContext.Current;
			if (context == null)
			{
				return true;
			}
			var applicationUrl = context.Request.AbsoluteUri();
			Uri comeUrl = new Uri(context.Request.UrlReferrer());
			Uri url = new Uri(applicationUrl);
			return comeUrl == null ? true : comeUrl.Host == url.Host ? false : true;
		}

		/// <summary>
		/// 返回指定路径的HMACSHA1加密安全码
		/// 安全码：不带扩展名的文件名 + Action查询参数提交的值 + SessionID
		/// </summary>
		/// <param name="filePath">指定路径。例：Content/ContentManage.aspx?Action=Add</param>
		/// <returns></returns>
		public static string GetSecurityCode(string filePath)
		{
			if (string.IsNullOrEmpty(filePath))
			{
				return string.Empty;
			}
			string str = string.Empty;
			string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);
			int index = filePath.IndexOf("?", StringComparison.CurrentCultureIgnoreCase);
			if (index > 0)
			{
				str = ParseQueryString(filePath.Substring(index, filePath.Length - index))["Action"];
			}
			string strMsg = fileNameWithoutExtension.ToLower() + str.ToLower() + MyHttpContext.Current.Session.Id;
			string strKey = Guid.NewGuid().ToString().Replace("-", string.Empty);
			return HmacSha1.EncryptBase64(strMsg, strKey);
		}

		/// <summary>
		/// 启动一个系统进程并得到返回结果。
		/// </summary>
		/// <param name="processName">进程名</param>
		/// <param name="arguments">进程参数</param>
		/// <param name="isWindow">是否有窗口显示</param>
		/// <returns></returns>
		public static string GetProcessResult(string processName, string arguments, bool isWindow)
		{
			try
			{
				ProcessStartInfo ps = new ProcessStartInfo(processName, arguments);
				ps.UseShellExecute = false;
				ps.CreateNoWindow = isWindow;
				ps.RedirectStandardOutput = true;
				Process p = Process.Start(ps);
				p.WaitForExit();
				string output = p.StandardOutput.ReadToEnd();
				p.Dispose();
				return output;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// 检查当前登录账号的权限
		/// </summary>
		/// <param name="claimsPrincipal">证件当事人（当前登录账号）</param>
		/// <param name="operateCode">权限码</param>
		/// <returns></returns>
		public static bool AccessCheck(ClaimsPrincipal claimsPrincipal,string operateCode)
		{
			if (string.IsNullOrEmpty(operateCode))
			{
				return false;
			}
			if (operateCode == "None")
			{
				return true;
			}
			if(claimsPrincipal.IsInRole("SuperAdmin"))
			{
				return true;
			}
			return claimsPrincipal.IsInRole(operateCode);
		}

		/// <summary>
		/// 金额转换成中文大写金额，保留两位小数
		/// </summary>
		/// <param name="LowerMoney"></param>
		/// <returns></returns>
		public static string MoneyToUpper(string LowerMoney)
		{
			string functionReturnValue = null;
			bool IsNegative = false; // 是否是负数
			if (LowerMoney.Trim().Substring(0, 1) == "-")
			{
				// 是负数则先转为正数
				LowerMoney = LowerMoney.Trim().Remove(0, 1);
				IsNegative = true;
			}
			string strLower = null;
			string strUpart = null;
			string strUpper = null;
			int iTemp = 0;
			// 保留两位小数 123.489→123.49　　123.4→123.4
			LowerMoney = Math.Round(double.Parse(LowerMoney), 2).ToString();
			if (LowerMoney.IndexOf(".") > 0)
			{
				if (LowerMoney.IndexOf(".") == LowerMoney.Length - 2)
				{
					LowerMoney = LowerMoney + "0";
				}
			}
			else
			{
				LowerMoney = LowerMoney + ".00";
			}
			strLower = LowerMoney;
			iTemp = 1;
			strUpper = "";
			while (iTemp <= strLower.Length)
			{
				switch (strLower.Substring(strLower.Length - iTemp, 1))
				{
					case ".":
						strUpart = "圆";
						break;
					case "0":
						strUpart = "零";
						break;
					case "1":
						strUpart = "壹";
						break;
					case "2":
						strUpart = "贰";
						break;
					case "3":
						strUpart = "叁";
						break;
					case "4":
						strUpart = "肆";
						break;
					case "5":
						strUpart = "伍";
						break;
					case "6":
						strUpart = "陆";
						break;
					case "7":
						strUpart = "柒";
						break;
					case "8":
						strUpart = "捌";
						break;
					case "9":
						strUpart = "玖";
						break;
				}

				switch (iTemp)
				{
					case 1:
						strUpart = strUpart + "分";
						break;
					case 2:
						strUpart = strUpart + "角";
						break;
					case 3:
						strUpart = strUpart + "";
						break;
					case 4:
						strUpart = strUpart + "";
						break;
					case 5:
						strUpart = strUpart + "拾";
						break;
					case 6:
						strUpart = strUpart + "佰";
						break;
					case 7:
						strUpart = strUpart + "仟";
						break;
					case 8:
						strUpart = strUpart + "万";
						break;
					case 9:
						strUpart = strUpart + "拾";
						break;
					case 10:
						strUpart = strUpart + "佰";
						break;
					case 11:
						strUpart = strUpart + "仟";
						break;
					case 12:
						strUpart = strUpart + "亿";
						break;
					case 13:
						strUpart = strUpart + "拾";
						break;
					case 14:
						strUpart = strUpart + "佰";
						break;
					case 15:
						strUpart = strUpart + "仟";
						break;
					case 16:
						strUpart = strUpart + "万";
						break;
					default:
						strUpart = strUpart + "";
						break;
				}

				strUpper = strUpart + strUpper;
				iTemp = iTemp + 1;
			}

			strUpper = strUpper.Replace("零拾", "零");
			strUpper = strUpper.Replace("零佰", "零");
			strUpper = strUpper.Replace("零仟", "零");
			strUpper = strUpper.Replace("零零零", "零");
			strUpper = strUpper.Replace("零零", "零");
			strUpper = strUpper.Replace("零角零分", "整");
			strUpper = strUpper.Replace("零分", "整");
			strUpper = strUpper.Replace("零角", "零");
			strUpper = strUpper.Replace("零亿零万零圆", "亿圆");
			strUpper = strUpper.Replace("亿零万零圆", "亿圆");
			strUpper = strUpper.Replace("零亿零万", "亿");
			strUpper = strUpper.Replace("零万零圆", "万圆");
			strUpper = strUpper.Replace("零亿", "亿");
			strUpper = strUpper.Replace("零万", "万");
			strUpper = strUpper.Replace("零圆", "圆");
			strUpper = strUpper.Replace("零零", "零");

			// 对壹圆以下的金额的处理
			if (strUpper.Substring(0, 1) == "圆")
			{
				strUpper = strUpper.Substring(1, strUpper.Length - 1);
			}
			if (strUpper.Substring(0, 1) == "零")
			{
				strUpper = strUpper.Substring(1, strUpper.Length - 1);
			}
			if (strUpper.Substring(0, 1) == "角")
			{
				strUpper = strUpper.Substring(1, strUpper.Length - 1);
			}
			if (strUpper.Substring(0, 1) == "分")
			{
				strUpper = strUpper.Substring(1, strUpper.Length - 1);
			}
			if (strUpper.Substring(0, 1) == "整")
			{
				strUpper = "零圆整";
			}
			functionReturnValue = strUpper;

			if (IsNegative == true)
			{
				return "负" + functionReturnValue;
			}
			else
			{
				return functionReturnValue;
			}
		}
		#endregion

		#region Http请求相关方法
		/// <summary>
		/// http post 请求方法，返回请求结果
		/// </summary>
		/// <param name="postUrl">请求地址（例：http://xxx.com/acquireData）</param>
		/// <param name="param">请求参数（例：phone=12345678901）</param>
		/// <param name="contentType">ContentType参数值:application/x-www-form-urlencoded或application/json</param>
		/// <param name="isGzip">是否启用GZIP压缩</param>
		/// <param name="headerKey">请求头名称</param>
		/// <param name="headerValue">请求头值</param>
		/// <returns></returns>
		public static string HttpPost(string postUrl, string param,string contentType= "application/x-www-form-urlencoded", bool isGzip = false, string headerKey="",string headerValue="")
		{
			try
			{
				byte[] bytes = Encoding.UTF8.GetBytes(param);
				byte[] byteParam;
				if (isGzip)
				{
					MemoryStream ms = new MemoryStream();
					GZipStream compressedzipStream = new GZipStream(ms, CompressionMode.Compress, true);
					compressedzipStream.Write(bytes, 0, bytes.Length);
					compressedzipStream.Close();
					byteParam = ms.ToArray();
				}
				else
				{
					byteParam = bytes;
				}
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(postUrl);
				request.Timeout = 30000;
				request.Method = "Post";
				request.ContentType = contentType;
				request.ContentLength = byteParam.Length;
				if (!string.IsNullOrEmpty(headerKey))
				{
					request.Headers.Add(headerKey,headerValue);
				}
				Stream requestStream = request.GetRequestStream();
				requestStream.Write(byteParam, 0, byteParam.Length);
				requestStream.Close();
				HttpWebResponse response = (HttpWebResponse)request.GetResponse();
				Stream responseStream = response.GetResponseStream();
				Encoding encoding = Encoding.UTF8;
				StreamReader reader = new StreamReader(responseStream, encoding);
				char[] buffer = new char[256];
				int length = reader.Read(buffer, 0, 256);
				StringBuilder builder = new StringBuilder("");
				while (length > 0)
				{
					string str2 = new string(buffer, 0, length);
					builder.Append(str2);
					length = reader.Read(buffer, 0, 0x100);
				}
				response.Close();
				reader.Close();
				return builder.ToString();
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}
		/// <summary>
		/// http post 请求方法，请求参数格式为JSON，返回请求结果
		/// </summary>
		/// <param name="postUrl">请求地址（例：http://xxx.com/acquireData）</param>
		/// <param name="param">请求参数（例：{"name":"aaa","age":"18"}）</param>
		/// <param name="isGzip">是否启用GZIP压缩</param>
		/// <param name="headerKey">请求头名称</param>
		/// <param name="headerValue">请求头值</param>
		/// <returns></returns>
		public static string HttpPostByJSON(string postUrl, string param, bool isGzip = false, string headerKey = "", string headerValue = "")
		{
			return HttpPost(postUrl, param, "application/json", isGzip, headerKey, headerValue);
		}
		/// <summary>
		/// http get 请求方法，返回请求结果
		/// </summary>
		/// <param name="strUrl">请求地址（例：http://xxx.com/acquireData?name=aaa）</param>
		/// <param name="contentType">ContentType参数值</param>
		/// <param name="headerKey">请求头名称</param>
		/// <param name="headerValue">请求头值</param>
		/// <returns></returns>
		public static string HttpGet(string strUrl, string contentType = "application/x-www-form-urlencoded", string headerKey = "", string headerValue = "")
		{
			if (string.IsNullOrEmpty(strUrl))
			{
				return "";
			}
			try
			{
				HttpWebRequest request = WebRequest.Create(strUrl) as HttpWebRequest;
				request.Method = "GET";
				request.Timeout = 30000;
				request.ContentType = contentType;
				if (!string.IsNullOrEmpty(headerKey))
				{
					request.Headers.Add(headerKey, headerValue);
				}
				HttpWebResponse response = (HttpWebResponse)request.GetResponse();
				Stream responseStream = response.GetResponseStream();
				Encoding encoding = Encoding.UTF8;
				StreamReader reader = new StreamReader(responseStream, encoding);
				char[] buffer = new char[0x100];
				int length = reader.Read(buffer, 0, 0x100);
				StringBuilder builder = new StringBuilder("");
				while (length > 0)
				{
					string str2 = new string(buffer, 0, length);
					builder.Append(str2);
					length = reader.Read(buffer, 0, 0x100);
				}
				response.Close();
				reader.Close();
				return builder.ToString();
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}
		/// <summary>
		/// 下载网络文件到本地，成功返回文件名
		/// </summary>
		/// <param name="url">请求地址（例：http://xxx.com/a.jpg）</param>
		/// <param name="fileDir">保存目录(不带文件名，如：d://WebSite/UploadFiles/Photo/)</param>
		/// <param name="fileNameMode">文件名模式：{$DateTime}：时间；{$Origin}：原文件名；{$Random}：随机数</param>
		/// <returns></returns>
		public static string HttpDownload(string url, string fileDir, string fileNameMode = "")
		{
			try
			{
				if (string.IsNullOrEmpty(url)) return "";

				switch (FileHelper.DirectorySeparatorChar)
				{
					case "/"://Mac OS and Linux
						fileDir = fileDir.Replace("\\", FileHelper.DirectorySeparatorChar);
						break;
					case "\\"://WINDOWS
						fileDir = fileDir.Replace("/", FileHelper.DirectorySeparatorChar);
						break;
				}
				if (fileDir.Substring(fileDir.Length - 1, 1) != FileHelper.DirectorySeparatorChar)
				{
					fileDir = fileDir + FileHelper.DirectorySeparatorChar;
				}
				fileDir = FileHelper.MapPath(fileDir);
				FileHelper.CreateFileFolder(fileDir);
				string strFile;
				switch (fileNameMode)
				{
					case "{$DateTime}":
						strFile = DateTime.Now.ToString("yyyyMMddHHmmssfff");
						break;
					case "{$Origin}":
						strFile = url.Substring(url.LastIndexOf("/") + 1, url.LastIndexOf("."));
						break;
					case "{$Random}":
						strFile = DataSecurity.MakeFileRndName();
						break;
					default:
						strFile = DateTime.Now.ToString("yyyyMMddHHmmssfff");
						break;
				}
				string strExte = url.Substring(url.LastIndexOf(".") + 1).ToLower();
				string strFileName = strFile + "." + strExte;
				string strPath = fileDir + strFileName;

				WebClient client = new WebClient();
				//方法一
				client.DownloadFile(url, strPath);

				//方法二
				//Stream stream = client.OpenRead(url);
				//byte[] mByte = new byte[100000];
				//int allByte = mByte.Length;
				//int startByte = 0;
				////写入到BYTE数组中，起缓冲作用
				//while (allByte > 0)
				//{
				//	int m = stream.Read(mByte, startByte, allByte);
				//	if (m == 0)
				//		break;

				//	startByte += m;
				//	allByte -= m;
				//}
				//FileStream fileStream = new FileStream(strPath, FileMode.OpenOrCreate, FileAccess.Write);
				//fileStream.Write(mByte, 0, startByte);
				//stream.Close();
				//fileStream.Close();
				return strFileName;
			}
			catch (Exception)
			{
				return "";
			}
		}
		#endregion

		#region 得到菜单路径
		/// <summary>
		/// 得到管理后台菜单路径。例：~/Config/AdminMenuShop.xml
		/// </summary>
		/// <returns></returns>
		public static string GetAdminMenuPath()
		{
			WebHostConfig webHostConfig = ConfigHelper.Get<WebHostConfig>();
			string adminMenuPath = "~/Config/AdminMenuShop.xml";
			switch (webHostConfig.Edition)
			{
				case "Base":
					adminMenuPath = "~/Config/AdminMenuBase.xml";
					break;
				case "BaseUser":
					adminMenuPath = "~/Config/AdminMenuBaseUser.xml";
					break;
				case "Shop":
					adminMenuPath = "~/Config/AdminMenuShop.xml";
					break;
				case "Industry":
					adminMenuPath = "~/Config/AdminMenuIndustry.xml";
					break;
			}
			return adminMenuPath;
		}

		/// <summary>
		/// 得到会员中心菜单路径。例：~/Config/UserMenuShop.xml
		/// </summary>
		/// <returns></returns>
		public static string GetUserMenuPath()
		{
			WebHostConfig webHostConfig = ConfigHelper.Get<WebHostConfig>();
			string userMenuPath = "~/Config/UserMenuShop.xml";
			switch (webHostConfig.Edition)
			{
				case "Base":
					userMenuPath = "~/Config/UserMenuBase.xml";
					break;
				case "BaseUser":
					userMenuPath = "~/Config/UserMenuBaseUser.xml";
					break;
				case "Shop":
					userMenuPath = "~/Config/UserMenuShop.xml";
					break;
				case "Industry":
					userMenuPath = "~/Config/UserMenuIndustry.xml";
					break;
			}
			return userMenuPath;
		}
		#endregion
	}
}
