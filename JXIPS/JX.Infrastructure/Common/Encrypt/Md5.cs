using System;
using System.Security.Cryptography;
using System.Text;

namespace JX.Infrastructure.Common
{
	/// <summary>
	/// MD5加密类
	/// </summary>
	public class Md5
    {
		/// <summary>
		/// 获取16位MD5值
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public static string HalfEncryptHexString(string input)
		{
			string result = EncryptHexString(input);

			if (!string.IsNullOrEmpty(result))
			{
				return result.Substring(0, 16);
			}
			return result;
		}


		/// <summary>
		/// 获取MD5加密值
		/// </summary>
		/// <param name="input"></param>
		/// <param name="encoding">如果为空，则默认Utf-8</param>
		/// <returns></returns>
		public static string EncryptHexString(string input, Encoding encoding = null)
		{
			if (string.IsNullOrEmpty(input))
				throw new ArgumentNullException("input", "MD5加密的字符串不能为空！");

			if (encoding == null)
				encoding = Encoding.UTF8;

			var data = encoding.GetBytes(input);
			var encryData = Encrypt(data);

			StringBuilder sBuilder = new StringBuilder();
			for (int i = 0; i < encryData.Length; i++)
			{
				sBuilder.Append(encryData[i].ToString("x2"));
			}
			return sBuilder.ToString();
		}


		/// <summary>
		/// 获取MD5加密值
		/// </summary>
		/// <param name="bytes"></param>
		/// <returns></returns>
		public static byte[] Encrypt(byte[] bytes)
		{
			if (bytes == null || bytes.Length == 0)
				throw new ArgumentNullException("bytes", "MD5加密的字节不能为空！");

			using (MD5 md5Hash = MD5.Create())
			{
				return md5Hash.ComputeHash(bytes);
			}
		}
	}
}
