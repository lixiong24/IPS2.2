namespace JX.Infrastructure.Common
{
	/// <summary>
	/// 缩略图模式 枚举
	/// </summary>
	public enum ThumbsMode
	{
		/// <summary>
		/// 常规算法：宽度和高度都大于0时，直接缩小成指定大小，其中一个为0时，按比例缩小
		/// </summary>
		ByHeightAndWidth,
		/// <summary>
		/// 宽度不变，缩放高度
		/// </summary>
		ByWidth,
		/// <summary>
		/// 高度不变，缩放宽度
		/// </summary>
		ByHeight,
		/// <summary>
		/// 裁剪法：宽度和高度都大于0时，先按最佳比例缩小再裁剪成指定大小，其中一个为0时，按比例缩小。
		/// </summary>
		CutByHeightOrWidth,
		/// <summary>
		/// 补充法：在指定大小的背景图上附加上按最佳比例缩小的图片。 
		/// </summary>
		AddBackColor
	}
}
