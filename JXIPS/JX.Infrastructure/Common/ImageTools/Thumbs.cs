using System;
using System.DrawingCore;
using System.DrawingCore.Drawing2D;
using System.DrawingCore.Imaging;
using System.IO;

namespace JX.Infrastructure.Common
{
	/// <summary>
	/// 制作缩略图类，定义了制作缩略图的方法。
	/// </summary>
	public abstract class Thumbs
	{
		/// <summary>
		/// 生成缩略图，并返回图片调用URL。
		/// 返回格式：/uploads/123_S_50_50.jpg
		/// </summary>
		/// <param name="originalImagePath">原图Url(如：/uploads/123.jpg)</param>
		/// <param name="isRebuild">存在同名的缩略图时，是否重新生成。（true：是；false：否；）</param>
		/// <returns></returns>
		public static string GetThumbUrl(string originalImagePath, bool isRebuild)
		{
			ThumbsConfig thumbConfig = ConfigHelper.Get<ThumbsConfig>();
			int thumbsWidth = thumbConfig.ThumbsWidth;
			int thumbsHeight = thumbConfig.ThumbsHeight;
			int thumbsMode = thumbConfig.ThumbsMode;
			string addBackColor = thumbConfig.AddBackColor;
			ThumbsMode byHeightAndWidth = ThumbsMode.ByHeightAndWidth;
			switch (thumbsMode)
			{
				case 0:
					byHeightAndWidth = ThumbsMode.ByHeightAndWidth;
					break;

				case 1:
					byHeightAndWidth = ThumbsMode.CutByHeightOrWidth;
					break;

				case 2:
					byHeightAndWidth = ThumbsMode.AddBackColor;
					break;
			}
			originalImagePath = originalImagePath.TrimStart('~');
			string strOriImagePhysical = FileHelper.MapPath(FileHelper.WebRootPath + FileHelper.DirectorySeparatorChar + originalImagePath.Replace("/", FileHelper.DirectorySeparatorChar));
			string strImageDir = Path.GetDirectoryName(strOriImagePhysical) + Path.DirectorySeparatorChar.ToString();
			string strImageName = Path.GetFileNameWithoutExtension(strOriImagePhysical);
			string strImageExtension = Path.GetExtension(strOriImagePhysical);
			string strThumbFileName = strImageName + "_S" + "_" + thumbsWidth.ToString() + "_" + thumbsHeight.ToString() + strImageExtension;
			string strResult = originalImagePath.Substring(0, originalImagePath.LastIndexOf("/") + 1) + strThumbFileName;
			if (!isRebuild)
			{
				if (File.Exists(strImageDir + strThumbFileName))
				{
					return strResult;
				}
			}
			MakeThumbnail(strOriImagePhysical, strImageDir + strThumbFileName, thumbsWidth, thumbsHeight, byHeightAndWidth, addBackColor);
			return strResult;
		}

        /// <summary>
        /// 生成缩略图，并返回图片物理地址。
        /// 返回格式：d:/website/uploads/123_S_50_50.jpg
        /// </summary>
        /// <param name="originalImagePath">原图物理地址(如：d:/website/uploads/123.jpg)</param>
        /// <param name="isRebuild">存在同名的缩略图时，是否重新生成。（true：是；false：否；）</param>
        /// <returns></returns>
        public static string GetThumbPath(string originalImagePath, bool isRebuild)
		{
			ThumbsConfig thumbConfig = ConfigHelper.Get<ThumbsConfig>();
			int thumbsWidth = thumbConfig.ThumbsWidth;
			int thumbsHeight = thumbConfig.ThumbsHeight;
			int thumbsMode = thumbConfig.ThumbsMode;
			string addBackColor = thumbConfig.AddBackColor;
			ThumbsMode byHeightAndWidth = ThumbsMode.ByHeightAndWidth;
			switch (thumbsMode)
			{
				case 0:
					byHeightAndWidth = ThumbsMode.ByHeightAndWidth;
					break;

				case 1:
					byHeightAndWidth = ThumbsMode.CutByHeightOrWidth;
					break;

				case 2:
					byHeightAndWidth = ThumbsMode.AddBackColor;
					break;
			}
			string strOriImagePhysical = FileHelper.MapPath(originalImagePath);
			string strImageDir = Path.GetDirectoryName(strOriImagePhysical) + Path.DirectorySeparatorChar.ToString();
			string strImageName = Path.GetFileNameWithoutExtension(strOriImagePhysical);
			string strImageExtension = Path.GetExtension(strOriImagePhysical);
			string strThumbFileName = strImageName + "_S" + "_" + thumbsWidth.ToString() + "_" + thumbsHeight.ToString() + strImageExtension;
			string strResult = strImageDir + strThumbFileName;
			if (!isRebuild)
			{
				if (File.Exists(strImageDir + strThumbFileName))
				{
					return strResult;
				}
			}
			MakeThumbnail(strOriImagePhysical, strImageDir + strThumbFileName, thumbsWidth, thumbsHeight, byHeightAndWidth, addBackColor);
			return strResult;
		}

		/// <summary>
		/// 制作缩略图
		/// </summary>
		/// <param name="originalImagePath">源图物理路径</param>
		/// <param name="thumbnailPath">缩略图物理路径</param>
		/// <param name="width">缩略图宽度</param>
		/// <param name="height">缩略图高度</param>
		/// <param name="thumbsMode">缩略图模式</param>
		/// <param name="bgColor">背景色</param>
		public static void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height, ThumbsMode thumbsMode, string bgColor)
		{
			Image image = null;
			try
			{
				image = Image.FromFile(originalImagePath);
			}
			catch (FileNotFoundException)
			{
				throw new FileNotFoundException("生成缩略图的源图片未找到");
			}
			int num = width;
			int num2 = height;
			int num5 = image.Width;
			int num6 = image.Height;
			int x = 0;
			int y = 0;
			switch (thumbsMode)
			{
				case ThumbsMode.ByWidth:
					num2 = (image.Height * width) / image.Width;
					break;

				case ThumbsMode.ByHeight:
					num = (image.Width * height) / image.Height;
					break;

				case ThumbsMode.CutByHeightOrWidth:
					if (num == 0)
					{
						num = 1;
					}
					if (num2 == 0)
					{
						num2 = 1;
					}
					if ((((double)image.Width) / ((double)image.Height)) > (((double)num) / ((double)num2)))
					{
						num6 = image.Height;
						num5 = (image.Height * num) / num2;
						y = 0;
						x = (image.Width - num5) / 2;
					}
					else
					{
						num5 = image.Width;
						num6 = (image.Width * height) / num;
						x = 0;
						y = (image.Height - num6) / 2;
					}
					break;

				case ThumbsMode.AddBackColor:
					{
						double num7 = GetThumbsPercent(image.Width, image.Height, width, height);
						if (width == 0)
						{
							width = 1;
						}
						if (height == 0)
						{
							height = 1;
						}
						num = Convert.ToInt32((double)(((double)image.Width) / num7));
						num2 = Convert.ToInt32((double)(((double)image.Height) / num7));
						x = (width - num) / 2;
						y = (height - num2) / 2;
						num5 = x + num;
						num6 = y + num2;
						break;
					}
			}
			if (num == 0)
			{
				num = 1;
			}
			if (num2 == 0)
			{
				num2 = 1;
			}
			Image image2 = new Bitmap(num, num2);
			if (thumbsMode == ThumbsMode.AddBackColor)
			{
				image2 = new Bitmap(width, height);
			}
			Graphics graphics = Graphics.FromImage(image2);
			graphics.InterpolationMode = InterpolationMode.High;
			graphics.SmoothingMode = SmoothingMode.HighQuality;
			if ((thumbsMode == ThumbsMode.AddBackColor) && !string.IsNullOrEmpty(bgColor))
			{
				ColorConverter converter = new ColorConverter();
				Color color = (Color)converter.ConvertFromString(bgColor);
				graphics.Clear(color);
			}
			else
			{
				graphics.Clear(Color.Transparent);
			}
			if (thumbsMode == ThumbsMode.AddBackColor)
			{
				graphics.DrawImage(image, new Rectangle(x, y, num, num2), new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);
			}
			else
			{
				graphics.DrawImage(image, new Rectangle(0, 0, num, num2), new Rectangle(x, y, num5, num6), GraphicsUnit.Pixel);
			}
			try
			{
				image2.Save(thumbnailPath, ImageFormat.Jpeg);
			}
			catch
			{
				throw new Exception("该图像以错误的图像格式保存。- 或 - 该图像被保存到创建该图像的文件");
			}
			finally
			{
				image.Dispose();
				image2.Dispose();
				graphics.Dispose();
			}
		}

		/// <summary>
		/// 得到缩略图百分比
		/// </summary>
		/// <param name="originalImageWidth">源图宽度</param>
		/// <param name="originalImageHeight">源图高度</param>
		/// <param name="width">要缩放的宽度</param>
		/// <param name="height">要缩放的高度</param>
		/// <returns>缩略图百分比</returns>
		private static double GetThumbsPercent(int originalImageWidth, int originalImageHeight, int width, int height)
		{
			if (width == 0)
			{
				width = 1;
			}
			if (height == 0)
			{
				height = 1;
			}
			double num = 1.0;
			double num2 = Convert.ToDouble(originalImageWidth);     //源图宽度
			double num3 = Convert.ToDouble(originalImageHeight);        //源图高度
			double num4 = Convert.ToDouble(width);                              //要缩放的宽度
			double num5 = Convert.ToDouble(height);                         //要缩放的高度
			if ((originalImageWidth <= originalImageHeight) && (width >= height))
			{
				//源图是竖形或正方形，而缩略图是横形或正方形，
				//则缩放百分比＝源图高度/要缩放的高度
				num = num3 / num5;
			}
			else if ((originalImageWidth > originalImageHeight) && (width < height))
			{
				//源图是横形，而缩略图是竖形，
				//则缩放百分比＝源图宽度/要缩放的宽度
				num = num2 / num4;
			}
			else if ((originalImageWidth <= originalImageHeight) && (width <= height))
			{
				//源图与缩略图是一样的形状，
				if ((originalImageHeight / height) >= (originalImageWidth / width))
				{
					//缩略图是竖形或正方形，
					//则缩放百分比＝源图宽度/要缩放的宽度
					num = num2 / num4;
				}
				else
				{
					//缩略图是横形
					//则缩放百分比＝源图高度/要缩放的高度
					num = num3 / num5;
				}
			}
			else if ((originalImageHeight / height) >= (originalImageWidth / width))
			{
				//缩略图是竖形或正方形，
				//则缩放百分比＝源图高度/要缩放的高度
				num = num3 / num5;
			}
			else
			{
				//则缩放百分比＝源图宽度/要缩放的宽度
				num = num2 / num4;
			}
			if (num <= 1.0)
			{
				num = 1.0;
			}
			return num;
		}
	}
}
