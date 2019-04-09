using System;

namespace JX.Infrastructure.Common
{
	/// <summary>
	/// 字符串过滤选项 ：用于StringHelper类从字符串中挑选符合条件的数字、字母、中文、全角字符
	/// 选项可以叠加使用，如  StringFilterOptions.HoldLetter|StringFilterOptions.HoldNumber 表示从字符串中选取字母和数字
	/// </summary>
	[Flags]
	public enum StringFilterOptions
	{
		/// <summary>
		/// 从字符中选取中文 
		/// </summary>
		HoldChinese = 4,
		/// <summary>
		/// 选取字母
		/// </summary>
		HoldLetter = 2,
		/// <summary>
		/// 选取数字
		/// </summary>
		HoldNumber = 1,
		/// <summary>
		/// 是否将字符中的全角转为半角
		/// </summary>
		SBCToDBC = 8
	}
}
