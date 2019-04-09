using System;
using System.IO;
using System.IO.Compression;

namespace JX.Infrastructure.Common
{
	/// <summary>
	/// Zip帮助类
	/// </summary>
	public class ZipHelper
    {
		#region 压缩、解压文件和文件夹(zip)
		/// <summary>
		/// 压缩文件和文件夹
		/// </summary>
		/// <param name="filePath">被压缩的目录路径（例：c:\example）</param>
		/// <param name="zipPath">压缩后的保存路径（例：c:\result.zip）</param>
		public static void ZipFile(string filePath,string zipPath)
		{
			System.IO.Compression.ZipFile.CreateFromDirectory(FileHelper.MapPath(filePath), FileHelper.MapPath(zipPath));
		}
		/// <summary>
		/// 解压文件到目录
		/// </summary>
		/// <param name="zipPath">压缩文件的路径（例：c:\result.zip）</param>
		/// <param name="UnZipPath">存放被解压文件的目录路径（例：c:\example）</param>
		public static void UnZipFile(string zipPath,string UnZipPath)
		{
			System.IO.Compression.ZipFile.ExtractToDirectory(FileHelper.MapPath(zipPath), FileHelper.MapPath(UnZipPath));
		}
		#endregion

		#region 添加、提取文件(zip)
		/// <summary>
		/// 从压缩文件中提取指定的文件到目录中
		/// </summary>
		/// <param name="zipPath">压缩文件的路径（例：c:\result.zip）</param>
		/// <param name="extractPath">存放被解压文件的目录路径（例：c:\example）</param>
		/// <param name="extractFileName">要提取的文件名称（例：a.txt 或 .txt）</param>
		public static void ExtractFileFromZip(string zipPath,string extractPath,string extractFileName)
		{
			extractPath = FileHelper.MapPath(extractPath);
			using (ZipArchive archive = System.IO.Compression.ZipFile.OpenRead(FileHelper.MapPath(zipPath)))
			{
				foreach (ZipArchiveEntry entry in archive.Entries)
				{
					if (entry.FullName.EndsWith(extractFileName, StringComparison.OrdinalIgnoreCase))
					{
						entry.ExtractToFile(Path.Combine(extractPath, entry.FullName));
					}
				}
			}
		}
		/// <summary>
		/// 添加一个新文件到压缩文件中
		/// </summary>
		/// <param name="zipPath">压缩文件的路径（例：c:\result.zip）</param>
		/// <param name="filePath">要添加的文件路径（例：c:\result.txt）</param>
		public static void AddFileToZip(string zipPath, string filePath)
		{
			using (FileStream zipToOpen = new FileStream(FileHelper.MapPath(zipPath), FileMode.Open))
			{
				using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
				{
					ZipArchiveEntry readmeEntry = archive.CreateEntryFromFile(FileHelper.MapPath(filePath),FileHelper.GetFileName(filePath));
					
				}
			}
		}
		#endregion

		#region 压缩、解压文件(gz)
		/// <summary>
		/// 压缩文件，压缩成功后，会生成一个和源文件同名，后缀名为.gz的压缩文件。（例：c:\result.txt.gz）
		/// </summary>
		/// <param name="filePath">要压缩的文件路径（例：c:\result.txt）</param>
		public static void CompressFile(string filePath)
		{
			filePath = FileHelper.MapPath(filePath);
			FileInfo fileInfo = new FileInfo(filePath);
			CompressFile(fileInfo);
		}
		/// <summary>
		/// 压缩文件，压缩成功后，会生成一个和源文件同名，后缀名为.gz的压缩文件。（例：c:\result.txt.gz）
		/// </summary>
		/// <param name="fileToCompress">要压缩的文件</param>
		public static void CompressFile(FileInfo fileToCompress)
		{
			using (FileStream originalFileStream = fileToCompress.OpenRead())
			{
				if ((File.GetAttributes(fileToCompress.FullName) & FileAttributes.Hidden) != FileAttributes.Hidden & fileToCompress.Extension != ".gz")
				{
					using (FileStream compressedFileStream = File.Create(fileToCompress.FullName + ".gz"))
					{
						using (GZipStream compressionStream = new GZipStream(compressedFileStream, CompressionMode.Compress))
						{
							originalFileStream.CopyTo(compressionStream);
						}
					}
				}
			}
		}
		/// <summary>
		/// 解压文件。解压成功后的文件，与压缩文件在同一目录。去掉压缩文件的后缀名，就是解压成功后的文件名。
		/// </summary>
		/// <param name="compressFilePath">要解压的文件路径（例：c:\result.txt.gz）</param>
		public static void DecompressFile(string compressFilePath)
		{
			compressFilePath = FileHelper.MapPath(compressFilePath);
			FileInfo fileInfo = new FileInfo(compressFilePath);
			DecompressFile(fileInfo);
		}
		/// <summary>
		/// 解压文件。解压成功后的文件，与压缩文件在同一目录。去掉压缩文件的后缀名，就是解压成功后的文件名。
		/// </summary>
		/// <param name="fileToDecompress">要解压的文件</param>
		public static void DecompressFile(FileInfo fileToDecompress)
		{
			using (FileStream originalFileStream = fileToDecompress.OpenRead())
			{
				string currentFileName = fileToDecompress.FullName;
				string newFileName = currentFileName.Remove(currentFileName.Length - fileToDecompress.Extension.Length);

				using (FileStream decompressedFileStream = File.Create(newFileName))
				{
					using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
					{
						decompressionStream.CopyTo(decompressedFileStream);
					}
				}
			}
		}
		#endregion

		#region 压缩、解压文件夹下的所有文件
		/// <summary>
		/// 压缩指定目录下的所有文件
		/// </summary>
		/// <param name="dirPath">目录路径（例：c:\result）</param>
		public static void CompressFileByDir(string dirPath)
		{
			DirectoryInfo directorySelected = new DirectoryInfo(FileHelper.MapPath(dirPath));
			foreach (FileInfo fileToCompress in directorySelected.GetFiles())
			{
				CompressFile(fileToCompress);
			}
		}
		/// <summary>
		/// 解压指定目录下的所有压缩文件（.gz）
		/// </summary>
		/// <param name="dirPath">目录路径（例：c:\result）</param>
		public static void DecompressFileByDir(string dirPath)
		{
			DirectoryInfo directorySelected = new DirectoryInfo(FileHelper.MapPath(dirPath));
			foreach (FileInfo fileToDecompress in directorySelected.GetFiles("*.gz"))
			{
				DecompressFile(fileToDecompress);
			}
		}
		#endregion
	}
}
