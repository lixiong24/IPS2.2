using System;

namespace JX.Infrastructure.Common
{
	/// <summary>
	/// 枚举 中文拼音操作
	/// </summary>
	[Flags]
	public enum SpellOptions
	{
		/// <summary>
		/// 操作第一个字母
		/// </summary>
		FirstLetterOnly = 1,
		/// <summary>
		/// 转换未知字符为问号
		/// </summary>
		TranslateUnknowWordToInterrogation = 2,
		/// <summary>
		/// 采用统一字符编码标准
		/// </summary>
		EnableUnicodeLetter = 4
	}
}
