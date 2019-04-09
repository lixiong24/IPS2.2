using System;
using System.Text;

namespace JX.Infrastructure.Common
{
	/// <summary>
	/// 随机数和随机字符管理类
	/// </summary>
	public class RandomHelper
    {
		private static Random rand = new Random((int)DateTime.Now.Ticks);
		private static readonly char[] RandChar = new char[] {
			'0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f',
			'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v',
			'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L',
			'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
		 };
		private static int s_RoCount = 1;

		/// <summary>
		/// 得到格式化数字
		/// </summary>
		/// <param name="min">最小数</param>
		/// <param name="max">最大数</param>
		/// <returns>格式化数字</returns>
		public static int GetFormatedNumeric(int min, int max)
		{
			int num = 0;
			num = new Random(s_RoCount * ((int)DateTime.Now.Ticks)).Next(min, max);
			s_RoCount++;
			return num;
		}

		/// <summary>
		/// 得到指定长度的随机字符串
		/// </summary>
		/// <param name="length">长度</param>
		/// <returns>随机字符串</returns>
		public static string GetRandString(int length)
		{
			StringBuilder builder = new StringBuilder();
			for (int i = 0; i < length; i++)
			{
				builder.Append(GetRandChar());
			}
			return builder.ToString();
		}
		/// <summary>
		/// 得到随机字符串通过模板样式字符
		/// </summary>
		/// <param name="pattern">模板样式字符(#：得到随机数字；*：得到随机字符；?：得到随机字母；)。例：####***???</param>
		/// <returns>随机字符串</returns>
		public static string GetRandStringByPattern(string pattern)
		{
			if ((!pattern.Contains("#") && !pattern.Contains("?")) && !pattern.Contains("*"))
			{
				return pattern;
			}
			char[] chArray = pattern.ToCharArray();
			StringBuilder builder = new StringBuilder();
			for (int i = 0; i < chArray.Length; i++)
			{
				switch (chArray[i])
				{
					case '#':
						chArray[i] = GetRandNum();
						goto Label_0069;

					case '*':
						chArray[i] = GetRandChar();
						goto Label_0069;

					case '?':
						chArray[i] = GetRandWord();
						break;
				}
				Label_0069:
				builder.Append(chArray[i]);
			}
			return builder.ToString();
		}

		/// <summary>
		/// 得到随机字母
		/// </summary>
		/// <returns></returns>
		private static char GetRandWord()
		{
			return RandChar[rand.Next(10, 62)];
		}
		/// <summary>
		/// 得到随机字符
		/// </summary>
		/// <returns>字符</returns>
		private static char GetRandChar()
		{
			return RandChar[rand.Next(62)];
		}
		/// <summary>
		/// 得到随机数字
		/// </summary>
		/// <returns>数字</returns>
		private static char GetRandNum()
		{
			return RandChar[rand.Next(0, 10)];
		}
	}
}
