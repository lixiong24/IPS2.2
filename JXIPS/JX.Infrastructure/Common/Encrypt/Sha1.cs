﻿using System;
using System.Security.Cryptography;
using System.Text;

namespace JX.Infrastructure.Common
{
	/// <summary>
	/// Sha1加密类
	/// </summary>
	public class Sha1
    {
		/// <summary>
		/// 获取Sha1加密值
		/// </summary>
		/// <param name="input"></param>
		/// <param name="encoding">如果为空，则默认Utf-8</param>
		/// <returns></returns>
		public static string Encrypt(string input, Encoding encoding = null)
		{
			if (string.IsNullOrEmpty(input))
				throw new ArgumentNullException("input", "Sha1加密的字符串不能为空！");

			if (encoding == null)
				encoding = Encoding.UTF8;

			var data = encoding.GetBytes(input);
			var encryData = Encrypt(data);

			StringBuilder sBuilder = new StringBuilder();
			for (int i = 0; i < encryData.Length; i++)
			{
				sBuilder.Append(encryData[i].ToString("x2"));
			}

			// Return the hexadecimal string.
			return sBuilder.ToString();

		}

		/// <summary>
		/// 获取Sha1加密值
		/// </summary>
		/// <param name="bytes"></param>
		/// <returns></returns>
		public static byte[] Encrypt(byte[] bytes)
		{
			if (bytes == null || bytes.Length == 0)
				throw new ArgumentNullException("bytes", "Sha1加密的字节不能为空！");

			using (SHA1 sha1Hash = SHA1.Create())
			{
				return sha1Hash.ComputeHash(bytes);
			}
		}
	}
}
