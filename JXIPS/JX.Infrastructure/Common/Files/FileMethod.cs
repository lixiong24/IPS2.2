using System.ComponentModel;

namespace JX.Infrastructure.Common
{
	/// <summary>
	/// 文件操作类别枚举
	/// </summary>
	public enum FileMethod
	{
		/// <summary>
		/// 文件夹
		/// </summary>
		[Description("文件夹")]
		Folder,
		/// <summary>
		/// 文件
		/// </summary>
		[Description("文件")]
		File,
		/// <summary>
		/// 所有
		/// </summary>
		[Description("所有")]
		All
	}
}
