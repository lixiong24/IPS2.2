using Microsoft.Net.Http.Headers;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace JX.Infrastructure.Common
{
	/// <summary>
	/// IP操作帮助类
	/// </summary>
	public class IPHelper
    {
		/// <summary>
		/// 构造
		/// </summary>
		public IPHelper()
		{
		}

		#region 私有成员
		private static long firstStartIp = 0;
		private static long lastStartIp = 0;
		private static long startIp = 0;
		private static long endIp = 0;
		private static int countryFlag = 0;
		private static long endIpOff = 0;
		#endregion

		#region 公共属性
		/// <summary>
		/// IP数据库地址，默认从网站根目录下的“/IPData/QQWry.Dat”得到。
		/// </summary>
		private static string _dataPath = FileHelper.MapPath("~/IPData/QQWry.Dat");
		/// <summary>
		/// 设置IP数据库地址，默认从网站根目录下的“/IPData/QQWry.Dat”得到。
		/// </summary>
		public static string DataPath
		{
			set { _dataPath = value; }
		}

		/// <summary>
		/// 要查询的IP
		/// </summary>
		private static string _ip = "0.0.0.0";
		/// <summary>
		/// 设置要查询的IP
		/// </summary>
		public static string IP
		{
			set { _ip = value; }
		}

		/// <summary>
		/// IP地址位置
		/// </summary>
		private static string country;
		/// <summary>
		/// 得到IP地址位置
		/// </summary>
		public static string Country
		{
			get { return country; }
		}

		/// <summary>
		/// 上网方式
		/// </summary>
		private static string local;
		/// <summary>
		/// 得到上网方式
		/// </summary>
		public static string Local
		{
			get { return local; }
		}
		/// <summary>
		/// 错误信息
		/// </summary>
		private static string errMsg = null;
		/// <summary>
		/// 得到错误信息
		/// </summary>
		public static string ErrMsg
		{
			get { return errMsg; }
		}

		/// <summary>
		/// 存放IP地址信息的流文件
		/// </summary>
		private static FileStream objfs = null;
		/// <summary>
		/// 设置存放IP地址信息的流文件
		/// </summary>
		public static FileStream IPFileStream
		{
			set { objfs = value; }
		}

		#endregion

		#region 私有方法

		#region 搜索匹配数据
		/// <summary>
		/// 搜索匹配数据
		/// </summary>
		/// <returns></returns>
		private static int QQwry()
		{
			string pattern = @"(((\d{1,2})|(1\d{2})|(2[0-4]\d)|(25[0-5]))\.){3}((\d{1,2})|(1\d{2})|(2[0-4]\d)|(25[0-5]))";
			Regex objRe = new Regex(pattern);
			Match objMa = objRe.Match(_ip);
			if (!objMa.Success)
			{
				errMsg = "IP格式错误";
				return 4;
			}

			long ip_Int = IpToInt(_ip);
			int nRet = 0;
			if (ip_Int >= IpToInt("127.0.0.0") && ip_Int <= IpToInt("127.255.255.255"))
			{
				country = "本机内部环回地址";
				local = "";
				nRet = 1;
			}
			else if ((ip_Int >= IpToInt("0.0.0.0") && ip_Int <= IpToInt("2.255.255.255")) || (ip_Int >= IpToInt("64.0.0.0") && ip_Int <= IpToInt("126.255.255.255")) || (ip_Int >= IpToInt("58.0.0.0") && ip_Int <= IpToInt("60.255.255.255")))
			{
				country = "网络保留地址";
				local = "";
				nRet = 1;
			}

			try
			{
				objfs = new FileStream(_dataPath, FileMode.Open, FileAccess.Read);
			}
			catch
			{
			}

			try
			{
				//objfs.Seek(0,SeekOrigin.Begin);
				objfs.Position = 0;
				byte[] buff = new Byte[8];
				objfs.Read(buff, 0, 8);
				firstStartIp = buff[0] + buff[1] * 256 + buff[2] * 256 * 256 + buff[3] * 256 * 256 * 256;
				lastStartIp = buff[4] * 1 + buff[5] * 256 + buff[6] * 256 * 256 + buff[7] * 256 * 256 * 256;
				long recordCount = Convert.ToInt64((lastStartIp - firstStartIp) / 7.0);
				if (recordCount <= 1)
				{
					country = "FileDataError";
					objfs.Dispose();
					return 2;
				}
				long rangE = recordCount;
				long rangB = 0;
				long recNO = 0;
				while (rangB < rangE - 1)
				{
					recNO = (rangE + rangB) / 2;
					GetStartIp(recNO);
					if (ip_Int == startIp)
					{
						rangB = recNO;
						break;
					}
					if (ip_Int > startIp)
						rangB = recNO;
					else
						rangE = recNO;
				}
				GetStartIp(rangB);
				GetEndIp();
				if (startIp <= ip_Int && endIp >= ip_Int)
				{
					GetCountry();
					local = local.Replace("（我们一定要解放台湾！！！）", "");
				}
				else
				{
					nRet = 3;
					country = "未知";
					local = "";
				}
				objfs.Dispose();
				return nRet;
			}
			catch
			{
				return 1;
			}
		}
		#endregion

		#region IP地址转换成Int数据
		/// <summary>
		/// IP地址转换成Int数据
		/// </summary>
		/// <param name="ip"></param>
		/// <returns></returns>
		private static long IpToInt(string ip)
		{
			char[] dot = new char[] { '.' };
			string[] ipArr = ip.Split(dot);
			if (ipArr.Length == 3)
				ip = ip + ".0";
			ipArr = ip.Split(dot);

			long ip_Int = 0;
			long p1 = long.Parse(ipArr[0]) * 256 * 256 * 256;
			long p2 = long.Parse(ipArr[1]) * 256 * 256;
			long p3 = long.Parse(ipArr[2]) * 256;
			long p4 = long.Parse(ipArr[3]);
			ip_Int = p1 + p2 + p3 + p4;
			return ip_Int;
		}
		#endregion

		#region int转换成IP
		/// <summary>
		/// int转换成IP
		/// </summary>
		/// <param name="ip_Int"></param>
		/// <returns></returns>
		private static string IntToIP(long ip_Int)
		{
			long seg1 = (ip_Int & 0xff000000) >> 24;
			if (seg1 < 0)
				seg1 += 0x100;
			long seg2 = (ip_Int & 0x00ff0000) >> 16;
			if (seg2 < 0)
				seg2 += 0x100;
			long seg3 = (ip_Int & 0x0000ff00) >> 8;
			if (seg3 < 0)
				seg3 += 0x100;
			long seg4 = (ip_Int & 0x000000ff);
			if (seg4 < 0)
				seg4 += 0x100;
			string ip = seg1.ToString() + "." + seg2.ToString() + "." + seg3.ToString() + "." + seg4.ToString();

			return ip;
		}
		#endregion

		#region 获取起始IP范围
		/// <summary>
		/// 获取起始IP范围
		/// </summary>
		/// <param name="recNO"></param>
		/// <returns></returns>
		private static long GetStartIp(long recNO)
		{
			long offSet = firstStartIp + recNO * 7;
			//objfs.Seek(offSet,SeekOrigin.Begin);
			objfs.Position = offSet;
			byte[] buff = new Byte[7];
			objfs.Read(buff, 0, 7);

			endIpOff = Convert.ToInt64(buff[4].ToString()) + Convert.ToInt64(buff[5].ToString()) * 256 + Convert.ToInt64(buff[6].ToString()) * 256 * 256;
			startIp = Convert.ToInt64(buff[0].ToString()) + Convert.ToInt64(buff[1].ToString()) * 256 + Convert.ToInt64(buff[2].ToString()) * 256 * 256 + Convert.ToInt64(buff[3].ToString()) * 256 * 256 * 256;
			return startIp;
		}
		#endregion

		#region 获取结束IP
		/// <summary>
		/// 获取结束IP
		/// </summary>
		/// <returns></returns>
		private static long GetEndIp()
		{
			//objfs.Seek(endIpOff,SeekOrigin.Begin);
			objfs.Position = endIpOff;
			byte[] buff = new Byte[5];
			objfs.Read(buff, 0, 5);
			endIp = Convert.ToInt64(buff[0].ToString()) + Convert.ToInt64(buff[1].ToString()) * 256 + Convert.ToInt64(buff[2].ToString()) * 256 * 256 + Convert.ToInt64(buff[3].ToString()) * 256 * 256 * 256;
			countryFlag = buff[4];
			return endIp;
		}
		#endregion

		#region 获取国家/区域偏移量
		/// <summary>
		/// 获取国家/区域偏移量
		/// </summary>
		/// <returns></returns>
		private static string GetCountry()
		{
			switch (countryFlag)
			{
				case 1:
				case 2:
					country = GetFlagStr(endIpOff + 4);
					local = (1 == countryFlag) ? " " : GetFlagStr(endIpOff + 8);
					break;
				default:
					country = GetFlagStr(endIpOff + 4);
					local = GetFlagStr(objfs.Position);
					break;
			}
			return " ";
		}
		#endregion

		#region 获取国家/区域字符串
		/// <summary>
		/// 获取国家/区域字符串
		/// </summary>
		/// <param name="offSet"></param>
		/// <returns></returns>
		private static string GetFlagStr(long offSet)
		{
			int flag = 0;
			byte[] buff = new Byte[3];
			while (1 == 1)
			{
				//objfs.Seek(offSet,SeekOrigin.Begin);
				objfs.Position = offSet;
				flag = objfs.ReadByte();
				if (flag == 1 || flag == 2)
				{
					objfs.Read(buff, 0, 3);
					if (flag == 2)
					{
						countryFlag = 2;
						endIpOff = offSet - 4;
					}
					offSet = Convert.ToInt64(buff[0].ToString()) + Convert.ToInt64(buff[1].ToString()) * 256 + Convert.ToInt64(buff[2].ToString()) * 256 * 256;
				}
				else
				{
					break;
				}
			}
			if (offSet < 12)
				return " ";
			objfs.Position = offSet;
			return GetStr();
		}
		#endregion

		#region GetStr
		/// <summary>
		/// 得到字符串
		/// </summary>
		/// <returns></returns>
		private static string GetStr()
		{
			byte lowC = 0;
			byte upC = 0;
			string str = "";
			byte[] buff = new byte[2];
			while (1 == 1)
			{
				lowC = (Byte)objfs.ReadByte();
				if (lowC == 0)
					break;
				if (lowC > 127)
				{
					upC = (byte)objfs.ReadByte();
					buff[0] = lowC;
					buff[1] = upC;
					Encoding enc = Encoding.GetEncoding("GB2312");
					if (upC == 0)
						break;
					str += enc.GetString(buff);
				}
				else
				{
					str += (char)lowC;
				}
			}
			return str;
		}
		#endregion

		#endregion

		#region 公共方法

		#region 查询IP真实地理位置
		/// <summary>
		/// 查询IP真实地理位置
		/// </summary>
		/// <returns></returns>
		public static string IPLocation()
		{
			try
			{
				QQwry();
				return country + local.Replace("CZ88.NET", "");
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}
		/// <summary>
		/// 查询IP真实地理位置
		/// </summary>
		/// <param name="ip">要查询的IP地址</param>
		/// <returns>返回IP真实地理位置</returns>
		public static string IPLocation(string ip)
		{
			try
			{
				_ip = ip;
				QQwry();
				string localtion = country + local;
				localtion = localtion.Replace("CZ88.NET", "");
				return localtion;
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}
		/// <summary>
		/// 根据IP地址库进行查询
		/// </summary>
		/// <param name="dataPath">IP地址库路径</param>
		/// <param name="ip">查询的IP</param>
		/// <returns>返回IP真实地理位置</returns>
		public static string IPLocation(string dataPath, string ip)
		{
			try
			{
				_dataPath = dataPath;
				_ip = ip;
				QQwry();
				return country + local;
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}
		#endregion

		#region 获取IP地址
		/// <summary>
		/// 获得客户端IP
		/// </summary>
		/// <returns></returns>
		public static string GetClientIP()
		{
			var ip = MyHttpContext.Current.Request.Headers["X-Forwarded-For"].FirstOrDefault();
			if (string.IsNullOrEmpty(ip))
			{
				ip = MyHttpContext.Current.Connection.RemoteIpAddress.MapToIPv4().ToString();
			}
			return ip;
		}

		/// <summary>
		/// 得到本地主机IPV4地址
		/// </summary>
		/// <returns></returns>
		public static string GetHostIP()
		{
			return MyHttpContext.Current.Connection.LocalIpAddress.MapToIPv4().ToString();
		}
		#endregion

		#region IP编码
		/// <summary>
		/// 编码ＩＰ，与DecodeIP()成对使用
		/// </summary>
		/// <param name="sip"></param>
		/// <returns></returns>
		public static double EncodeIP(string sip)
		{
			if (string.IsNullOrEmpty(sip))
			{
				return 0.0;
			}
			string[] strArray = sip.Split(new char[] { '.' });
			long num = 0L;
			foreach (string str in strArray)
			{
				byte num2;
				if (byte.TryParse(str, out num2))
				{
					num = (num << 8) | num2;
				}
				else
				{
					return 0.0;
				}
			}
			return (double)num;
		}

		/// <summary>
		/// 解码IP地址，与EncodeIP()成对使用
		/// </summary>
		/// <param name="ip"></param>
		/// <returns></returns>
		public static string DecodeIP(long ip)
		{
			string[] strArray = new string[] { ((ip >> 24) & 0xffL).ToString(CultureInfo.CurrentCulture), ".", ((ip >> 16) & 0xffL).ToString(CultureInfo.CurrentCulture), ".", ((ip >> 8) & 0xffL).ToString(CultureInfo.CurrentCulture), ".", (ip & 0xffL).ToString(CultureInfo.CurrentCulture) };
			return string.Concat(strArray);
		}

		/// <summary>
		/// 解码锁定IP，返回格式为：192.168.1.1----192.168.1.2\n192.168.1.3----192.168.1.4
		/// </summary>
		/// <param name="lockIP">多个ＩＰ地址以“$$$”分割</param>
		/// <returns></returns>
		public static string DecodeLockIP(string lockIP)
		{
			StringBuilder builder = new StringBuilder(0x100);
			if (!string.IsNullOrEmpty(lockIP))
			{
				try
				{
					string[] strArray = lockIP.Split(new string[] { "$$$" }, StringSplitOptions.RemoveEmptyEntries);
					for (int i = 0; i < strArray.Length; i++)
					{
						string[] strArray2 = strArray[i].Split(new string[] { "----" }, StringSplitOptions.RemoveEmptyEntries);
						builder.Append(DecodeIP(Convert.ToInt64(strArray2[0], CultureInfo.CurrentCulture)) + "----" + DecodeIP(Convert.ToInt64(strArray2[1], CultureInfo.CurrentCulture)) + "\n");
					}
					return builder.ToString().TrimEnd(new char[] { '\n' });
				}
				catch (IndexOutOfRangeException)
				{
					return builder.ToString();
				}
			}
			return builder.ToString();
		}
		/// <summary>
		/// 编码锁定IP
		/// </summary>
		/// <param name="iplist">ＩＰ地址列表，多个ＩＰ之间以“\n”分割。每个ＩＰ以“----”分割。格式：192.168.1.1----192.168.1.2\n192.168.1.3----192.168.1.4</param>
		/// <returns></returns>
		public static string EncodeLockIP(string iplist)
		{
			StringBuilder builder = new StringBuilder(0x100);
			if (!string.IsNullOrEmpty(iplist.Trim()))
			{
				string[] strArray = iplist.Split(new char[] { '\n' });
				for (int i = 0; i < strArray.Length; i++)
				{
					if (!string.IsNullOrEmpty(strArray[i]) && strArray[i].Contains("----"))
					{
						string[] strArray2 = strArray[i].Split(new string[] { "----" }, StringSplitOptions.RemoveEmptyEntries);
						if (strArray2.Length < 2)
						{
							throw new ArgumentException("请填写正确网站黑白名单中的IP地址！");
						}
						if (!DataValidator.IsIP(strArray2[0]) || !DataValidator.IsIP(strArray2[1]))
						{
							throw new ArgumentException("请填写正确网站黑白名单中的IP地址！");
						}
						if (i == 0)
						{
							builder.Append(EncodeIP(strArray2[0]) + "----" + EncodeIP(strArray2[1]));
						}
						else
						{
							builder.Append(string.Concat(new object[] { "$$$", EncodeIP(strArray2[0]), "----", EncodeIP(strArray2[1]) }));
						}
					}
				}
			}
			return builder.ToString();
		}
		#endregion

		#endregion
	}
}
