using System;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using System.Globalization;
using System.Collections.Generic;
using System.Data;

namespace JX.Infrastructure.Common
{
	/// <summary>
	/// 文件帮助类：对文件、目录进行操作
	/// </summary>
	public class FileHelper
	{
		#region 属性
		/// <summary>
		/// 当前应用程序的系统环境描述
		/// </summary>
		public static IHostingEnvironment HostingEnvironment
		{
			get
			{
				return DI.ServiceProvider.GetRequiredService<IHostingEnvironment>();
			}
		}
		/// <summary>
		/// 目录分隔符，WINDOWS：“\”;Mac OS and Linux：“/”
		/// </summary>
		public static readonly string DirectorySeparatorChar = Path.DirectorySeparatorChar.ToString();
		/// <summary>
		/// 当前应用程序目录的绝对路径（例：D:\JXIPS\JXWebHost）
		/// </summary>
		public static readonly string ContentRootPath = HostingEnvironment.ContentRootPath;
		/// <summary>
		/// 当前应用程序的静态文件目录的绝对路径（例：D:\JXIPS\JXWebHost\wwwroot）
		/// </summary>
		public static readonly string WebRootPath = HostingEnvironment.WebRootPath;
		/// <summary>
		/// 当前应用程序的静态文件目录的名称（例：wwwroot）
		/// </summary>
		public static string WebRootName
		{
			get
			{
				string result = "";
				if (!string.IsNullOrEmpty(WebRootPath))
				{
					result = WebRootPath.Substring(WebRootPath.LastIndexOf(DirectorySeparatorChar)+1);
				}
				return result;
			}
		}
		#endregion

		#region 绝对路径
		/// <summary>
		/// 是否是绝对路径。
		/// windows下判断 路径是否包含 ":"。
		/// Mac OS、Linux下判断 路径是否包含 "\"
		/// </summary>
		/// <param name="path">文件路径</param>
		/// <returns></returns>
		public static bool IsAbsolute(string path)
		{
			return Path.VolumeSeparatorChar == ':' ? path.IndexOf(Path.VolumeSeparatorChar) > 0 : path.IndexOf('\\') > 0;
		}
		/// <summary>
		/// 获取文件绝对路径
		/// </summary>
		/// <param name="path">文件路径</param>
		/// <returns></returns>
		public static string MapPath(string path)
		{
			return IsAbsolute(path) ? path : Path.Combine(ContentRootPath, path.TrimStart('~', '/').Replace("/", DirectorySeparatorChar));
		}
		#endregion

		#region 是否存在
		/// <summary>
		/// 检查文件或文件夹是否存在
		/// </summary>
		/// <param name="file">文件路径</param>
		/// <param name="method"></param>
		/// <returns></returns>
		public static bool IsExist(string file, FileMethod method=FileMethod.File)
		{
			if (method == FileMethod.File)
			{
				return File.Exists(MapPath(file));
			}
			else if (method == FileMethod.Folder)
			{
				return Directory.Exists(MapPath(file));
			}
			return false;
		}
		/// <summary>
		/// 检查指定网站程序根目录下是否存在指定目录，不存在就创建，并返回FALSE
		/// </summary>
		/// <param name="categorDir">目录名</param>
		/// <returns>存在该目录返回真，否则返回false</returns>
		public static bool IsExistCategoryDirAndCreate(string categorDir)
		{
			string file = Path.Combine(ContentRootPath, categorDir);
			if (IsExist(file, FileMethod.Folder))
			{
				return true;
			}
			Create(file, FileMethod.Folder);
			return false;
		}
		/// <summary>
		/// 检测目录是否为空
		/// </summary>
		/// <param name="path">文件路径</param>
		/// <returns></returns>
		public static bool IsEmptyDirectory(string path)
		{
			return Directory.GetFiles(MapPath(path)).Length <= 0 && Directory.GetDirectories(MapPath(path)).Length <= 0;
		}
		#endregion

		#region 文件快速读写
		/// <summary>
		/// 创建或追加文件内容，使用UTF8编码
		/// </summary>
		/// <param name="file">要创建的文件名完整路径</param>
		/// <param name="fileContent">要创建或追加的文件内容</param>
		/// <returns>创建成功则返回文件内容，否则抛出异常</returns>
		public static string WriteAppend(string file, string fileContent)
		{
			string str;
			FileInfo info = new FileInfo(MapPath(file));
			if (!Directory.Exists(info.DirectoryName))
			{
				Directory.CreateDirectory(info.DirectoryName);
			}
			FileStream stream = new FileStream(MapPath(file), FileMode.Append, FileAccess.Write);
			StreamWriter writer = new StreamWriter(stream, Encoding.UTF8);
			try
			{
				writer.Write(fileContent);
				str = fileContent;
			}
			catch (Exception exception)
			{
				throw new FileNotFoundException(exception.ToString());
			}
			finally
			{
				writer.Flush();
				stream.Flush();
				writer.Dispose();
				stream.Dispose();
			}
			return str;
		}

		/// <summary>
		/// 用指定文件内容创建文件（UTF-8格式），如果文件已经存在，则覆盖。
		/// </summary>
		/// <param name="file">要创建的文件名完整路径</param>
		/// <param name="fileContent">要创建的文件内容</param>
		/// <returns>创建成功则返回文件内容，否则抛出异常</returns>
		public static string WriteFile(string file, string fileContent)
		{
			string str;
			FileInfo info = new FileInfo(MapPath(file));
			if (!Directory.Exists(info.DirectoryName))
			{
				Directory.CreateDirectory(info.DirectoryName);
			}
			FileStream stream = new FileStream(MapPath(file), FileMode.Create, FileAccess.Write);
			StreamWriter writer = new StreamWriter(stream, Encoding.UTF8);
			try
			{
				writer.Write(fileContent);
				str = fileContent;
			}
			catch (Exception exception)
			{
				throw new FileNotFoundException(exception.ToString());
			}
			finally
			{
				writer.Flush();
				stream.Flush();
				writer.Dispose();
				stream.Dispose();
			}
			return str;
		}
		/// <summary>
		/// 用指定文件内容创建文件UTF-8格式
		/// </summary>
		/// <param name="file">要创建的文件名完整路径</param>
		/// <param name="fileContent">要创建或追加的文件内容</param>
		/// <param name="append">确定是否将数据追加到文件。如果该文件存在，并且 append 为 false，则该文件被覆盖。如果该文件存在，并且 append 为 true，则数据被追加到该文件中。否则，将创建新文件。</param>
		public static void WriteFile(string file, string fileContent, bool append)
		{
			if (append)
			{
				WriteAppend(file, fileContent);
			}
			else
			{
				WriteFile(file, fileContent);
			}
		}

		/// <summary>
		/// 读取指定文件内容
		/// </summary>
		/// <param name="filePath">文件路径</param>
		/// <returns>UTF-8格式的文件内容</returns>
		public static string ReadFile(string filePath)
		{
			string content = string.Empty;
			if (!File.Exists(MapPath(filePath)))
			{
				return content;
			}
			using (FileStream stream = new FileStream(MapPath(filePath), FileMode.Open, FileAccess.Read))
			{
				Encoding encoding = GetEncoding(stream);
				StreamReader reader = new StreamReader(stream, encoding, true, 1024);
				content = reader.ReadToEnd();
				reader.Dispose();
				if (encoding != Encoding.UTF8)
				{
					content = ConvertEncoding(content, encoding, Encoding.UTF8);
				}
				return content;
			}
		}

		/// <summary>
		/// 批量替换指定目录下的所有文件中指定的内容
		/// </summary>
		/// <param name="dir">指定目录路径</param>
		/// <param name="originalContent">要替换的原始内容</param>
		/// <param name="newContent">要替换的新内容</param>
		public static void ReplaceFileContent(string dir, string originalContent, string newContent)
		{
			if (!string.IsNullOrEmpty(originalContent))
			{
				DirectoryInfo info = new DirectoryInfo(MapPath(dir));
				foreach (FileInfo info2 in info.GetFiles("*.*", SearchOption.AllDirectories))
				{
					StreamReader reader = info2.OpenText();
					string str = reader.ReadToEnd();
					reader.Dispose();
					if (str.Contains(originalContent))
					{
						str = str.Replace(originalContent, newContent);
						WriteFile(info2.FullName, str,false);
					}
				}
			}
		}
		#endregion

		#region 创建、删除、移动文件与文件夹
		/// <summary>
		/// 创建文件夹或文件
		/// </summary>
		/// <param name="file">文件或文件夹全名包括路径</param>
		/// <param name="method">文件类型：文件夹或文件</param>
		public static void Create(string file, FileMethod method)
		{
			try
			{
				if (method == FileMethod.File)
				{
					WriteFile(file, string.Empty);
				}
				else if (method == FileMethod.Folder)
				{
					Directory.CreateDirectory(MapPath(file));
				}
			}
			catch
			{
				throw new UnauthorizedAccessException("没有权限！");
			}
		}

		/// <summary>
		/// 在指定网站应用程序目录创建文件夹
		/// 创建成功后返回文件夹全名包括路径
		/// </summary>
		/// <param name="folderName">文件夹名称(不包括完整路径)</param>
		/// <returns>创建成功后的文件夹全名包括路径</returns>
		public static string CreateFileFolder(string folderName)
		{
			if (string.IsNullOrEmpty(folderName))
			{
				throw new ArgumentNullException("folderName", "folderName为空！");
			}
			string path = MapPath(folderName);
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
			return path;
		}

		/// <summary>
		/// 移动文件或文件夹
		/// </summary>
		/// <param name="oldFile">源文件或文件夹</param>
		/// <param name="newFile">目标文件或文件夹</param>
		/// <param name="method">文件类型：文件夹或文件</param>
		public static void Move(string oldFile, string newFile, FileMethod method)
		{
			if (method == FileMethod.File)
			{
				File.Move(MapPath(oldFile), MapPath(newFile));
			}
			if (method == FileMethod.Folder)
			{
				Directory.Move(MapPath(oldFile), MapPath(newFile));
			}
		}

		/// <summary>
		/// 删除文件或文件夹
		/// </summary>
		/// <param name="file">要删除的文件全名包括路径</param>
		/// <param name="method">文件类型：文件夹或文件</param>
		public static void Delete(string file, FileMethod method)
		{
			file = MapPath(file);
			if ((method == FileMethod.File) && File.Exists(file))
			{
				File.Delete(file);
			}
			if ((method == FileMethod.Folder) && Directory.Exists(file))
			{
				Directory.Delete(file, true);
			}
		}
		/// <summary>
		/// 清空目录下所有文件及子目录，依然保留该目录
		/// </summary>
		/// <param name="path">目录路径</param>
		public static void ClearDirectory(string path)
		{
			if (IsExist(path,FileMethod.Folder))
			{
				//目录下所有文件
				string[] files = Directory.GetFiles(MapPath(path));
				foreach (var file in files)
				{
					Delete(file, FileMethod.File);
				}
				//目录下所有子目录
				string[] directorys = Directory.GetDirectories(MapPath(path));
				foreach (var dir in directorys)
				{
					Delete(dir, FileMethod.Folder);
				}
			}
		}
		#endregion

		#region 拷贝文件与文件夹
		/// <summary>
		/// 拷贝目录及其所有子目录和文件
		/// </summary>
		/// <param name="oldDir">源目录</param>
		/// <param name="newDir">目标目录</param>
		public static void CopyDirectory(string oldDir, string newDir)
		{
			DirectoryInfo od = new DirectoryInfo(oldDir);
			CopyDirInfo(od, oldDir, newDir);
		}
		/// <summary>
		/// 拷贝目录及其所有子目录和文件
		/// </summary>
		/// <param name="od">源目录对象</param>
		/// <param name="oldDir">源目录</param>
		/// <param name="newDir">目标目录</param>
		private static void CopyDirInfo(DirectoryInfo od, string oldDir, string newDir)
		{
			if (!IsExist(newDir, FileMethod.Folder))
			{
				Create(newDir, FileMethod.Folder);
			}
			foreach (DirectoryInfo info in od.GetDirectories())
			{
				CopyDirInfo(info, info.FullName, newDir + info.FullName.Replace(oldDir, string.Empty));
			}
			foreach (FileInfo info2 in od.GetFiles())
			{
				CopyFile(info2.FullName, newDir + info2.FullName.Replace(oldDir, string.Empty));
			}
		}

		/// <summary>
		/// 拷贝文件，如果已经存在则重写
		/// </summary>
		/// <param name="oldFile">源文件</param>
		/// <param name="newFile">目标文件</param>
		/// <param name="isOverWrite">是否可以覆盖</param>
		public static void CopyFile(string oldFile, string newFile, bool isOverWrite = true)
		{
			File.Copy(MapPath(oldFile), MapPath(newFile), isOverWrite);
		}
		/// <summary>
		/// 用文件流的方式拷贝文件
		/// </summary>
		/// <param name="oldPath">源文件路径</param>
		/// <param name="newPath">目标文件路径</param>
		/// <returns></returns>
		public static bool CopyFileStream(string oldPath, string newPath)
		{
			try
			{
				oldPath = MapPath(oldPath);
				newPath = MapPath(newPath);
				FileStream input = new FileStream(oldPath, FileMode.Open, FileAccess.Read);
				FileStream output = new FileStream(newPath, FileMode.Create, FileAccess.Write);
				BinaryReader reader = new BinaryReader(input);
				BinaryWriter writer = new BinaryWriter(output);
				reader.BaseStream.Seek(0L, SeekOrigin.Begin);
				reader.BaseStream.Seek(0L, SeekOrigin.End);
				while (reader.BaseStream.Position < reader.BaseStream.Length)
				{
					writer.Write(reader.ReadByte());
				}
				reader.Dispose();
				writer.Dispose();
				input.Flush();
				input.Dispose();
				output.Flush();
				output.Dispose();
				return true;
			}
			catch
			{
				return false;
			}
		}

		/// <summary>
		/// 将子级目录列表添加到父级目录列表
		/// </summary>
		/// <param name="parent">父目录列表</param>
		/// <param name="child">子目录列表</param>
		/// <returns></returns>
		public static List<DirDetail> CopyDT(List<DirDetail> parent, List<DirDetail> child)
		{
			foreach (DirDetail info in child)
			{
				parent.Add(info);
			}
			return parent;
		}
		/// <summary>
		/// 将子级目录列表添加到父级目录列表
		/// </summary>
		/// <param name="parent">父目录列表</param>
		/// <param name="child">子目录列表</param>
		/// <returns></returns>
		public static DataTable CopyDT(DataTable parent, DataTable child)
		{
			for (int i = 0; i < child.Rows.Count; i++)
			{
				DataRow row = parent.NewRow();
				for (int j = 0; j < parent.Columns.Count; j++)
				{
					row[j] = child.Rows[i][j];
				}
				parent.Rows.Add(row);
			}
			return parent;
		}
		#endregion

		#region 获取文件名和扩展名
		/// <summary>
		/// 获取文件名和扩展名
		/// </summary>
		/// <param name="path">文件路径</param>
		/// <returns></returns>
		public static string GetFileName(string path)
		{
			return Path.GetFileName(path);
		}
		/// <summary>
		/// 获取文件扩展名
		/// </summary>
		/// <param name="path">文件路径</param>
		/// <returns></returns>
		public static string GetFileExtension(string path)
		{
			return Path.GetExtension(path);
		}
		/// <summary>
		/// 获取文件名不带扩展名
		/// </summary>
		/// <param name="path">文件路径</param>
		/// <returns></returns>
		public static string GetFileNameWithOutExtension(string path)
		{
			return Path.GetFileNameWithoutExtension(path);
		}
		#endregion

		#region 得到文件的编码格式
		/// <summary>
		/// 获取文件流中的内容所使用的编码格式
		/// </summary>
		/// <param name="stream">文件流对象</param>
		/// <returns>文件流中内容的编码</returns>
		public static Encoding GetEncoding(FileStream stream)
		{
			Encoding bigEndianUnicode = Encoding.UTF8;
			if ((stream != null) && (stream.Length >= 2L))
			{
				byte num = 0;
				byte num2 = 0;
				byte num3 = 0;
				long offset = stream.Seek(0L, SeekOrigin.Begin);
				stream.Seek(0L, SeekOrigin.Begin);
				num = Convert.ToByte(stream.ReadByte());
				num2 = Convert.ToByte(stream.ReadByte());
				if (stream.Length >= 3L)
				{
					num3 = Convert.ToByte(stream.ReadByte());
				}
				if (stream.Length >= 4L)
				{
					Convert.ToByte(stream.ReadByte());
				}
				if ((num == 254) && (num2 == 255))
				{
					bigEndianUnicode = Encoding.BigEndianUnicode;
				}
				if (((num == 255) && (num2 == 254)) && (num3 != 255))
				{
					bigEndianUnicode = Encoding.Unicode;
				}
				if (((num == 239) && (num2 == 187)) && (num3 == 191))
				{
					bigEndianUnicode = Encoding.UTF8;
				}
				stream.Seek(offset, SeekOrigin.Begin);
			}
			stream.Dispose();
			return bigEndianUnicode;
		}

		/// <summary>
		/// 将指定字符串转为指定编码格式
		/// </summary>
		/// <param name="content">要转换编码的字符串</param>
		/// <param name="srcEncoding">字符串的原始编码格式</param>
		/// <param name="targetEncoding">目标编码格式</param>
		/// <returns>目标编码格式的字符串</returns>
		public static string ConvertEncoding(string content, Encoding srcEncoding, Encoding targetEncoding)
		{
			if ((srcEncoding != targetEncoding) && !string.IsNullOrEmpty(content))
			{
				byte[] bytes = srcEncoding.GetBytes(content);
				bytes = Encoding.Convert(srcEncoding, targetEncoding, bytes);
				char[] chars = new char[targetEncoding.GetCharCount(bytes, 0, bytes.Length)];
				targetEncoding.GetChars(bytes, 0, bytes.Length, chars, 0);
				content = new string(chars);
			}
			return content;
		}
		#endregion

		#region 得到文件大小
		/// <summary>
		/// 获取文件的大小：KB为单位
		/// </summary>
		/// <param name="filePath">文件路径</param>
		/// <returns>文件大小：KB为单位</returns>
		public static string GetFileSize(string filePath)
		{
			FileInfo info = new FileInfo(MapPath(filePath));
			float num = info.Length / 1024L;
			return (num.ToString(CultureInfo.CurrentCulture) + "KB");
		}

		/// <summary>
		/// 根据文件大小生成相应用于显示的HTML字符串(Span标签)
		/// 文件大小不足1KB，则返回以B为单位的字符串，1KB-1MB内则以KB为单位显示，1GB以外以GB为单位，其他情况以MB为单位内
		/// </summary>
		/// <param name="fileSize">文件大小</param>
		/// <returns>文件大小不足1KB，则返回以B为单位的字符串，1KB-1MB内则以KB为单位显示，1GB以外以GB为单位，其他情况以MB为单位内</returns>
		public static string ConvertSizeToShow(long fileSize)
		{
			long num = fileSize / 1024L;
			if (num < 1L)
			{
				return (fileSize.ToString(CultureInfo.CurrentCulture) + "<span style='color:red'>&nbsp;&nbsp;B</span>");
			}
			if (num < 1024L)
			{
				return (num.ToString(CultureInfo.CurrentCulture) + "<span style='color:red'>&nbsp;KB</span>");
			}
			long num2 = num / 1024L;
			if (num2 < 1L)
			{
				return (num.ToString(CultureInfo.CurrentCulture) + "<span style='color:red'>&nbsp;KB</span>");
			}
			if (num2 >= 1024L)
			{
				num2 /= 1024L;
				return (num2.ToString(CultureInfo.CurrentCulture) + "<span style='color:red'>&nbsp;GB</span>");
			}
			return (num2.ToString(CultureInfo.CurrentCulture) + "<span style='color:red'>&nbsp;MB</span>");
		}
		#endregion

		#region 获取目录中的所有信息
		/// <summary>
		/// 生成目录信息：目录中文件的总大小、子目录总数、目录中所有文件总数
		/// </summary>
		/// <param name="dir">指定目录</param>
		/// <returns>文件信息数组：[0] 目录中文件的总大小，[1] 子目录总数 [2]目录中所有文件总数</returns>
		public static long[] GetDirInfos(string dir)
		{
			long[] numArray = new long[3];
			DirectoryInfo d = new DirectoryInfo(MapPath(dir));
			return DirInfo(d);
		}
		/// <summary>
		/// 得到目录信息（目录中文件的总大小、子目录总数、目录中所有文件总数）
		/// </summary>
		/// <param name="d"></param>
		/// <returns></returns>
		private static long[] DirInfo(DirectoryInfo d)
		{
			long[] numArray = new long[3];
			long num = 0L;			//目录中文件的总大小
			long num2 = 0L;		//子目录总数
			long num3 = 0L;		//目录中所有文件总数
			FileInfo[] files = d.GetFiles();
			num3 += files.Length;
			foreach (FileInfo info in files)
			{
				num += info.Length;
			}
			DirectoryInfo[] directories = d.GetDirectories();
			num2 += directories.Length;
			foreach (DirectoryInfo info2 in directories)
			{
				num += DirInfo(info2)[0];
				num2 += DirInfo(info2)[1];
				num3 += DirInfo(info2)[2];
			}
			numArray[0] = num;
			numArray[1] = num2;
			numArray[2] = num3;
			return numArray;
		}

		/// <summary>
		/// 将指定目录路径下的所有目录和子目录或文件生成一张数据表
		/// 目录的数据列表包含字段：(文件名,文件全名,内容类型,文件类型,路径,创建时间,文件大小)name rname content_type type path creatime size
		/// </summary>
		/// <param name="dir">要生成目录列表的文件夹路径</param>
		/// <param name="method">文件类型：文件夹或者文件</param>
		/// <returns>目录的数据列表包含字段：(文件名,文件全名,内容类型,文件类型,路径,创建时间,文件大小)name rname content_type type path creatime size</returns>
		public static List<DirDetail> GetDirectoryAllInfos(string dir, FileMethod method)
		{
			List<DirDetail> directoryAllInfo;
			try
			{
				DirectoryInfo d = new DirectoryInfo(MapPath(dir));
				directoryAllInfo = GetDirectoryAllInfo(d, method);
			}
			catch (Exception exception)
			{
				throw new FileNotFoundException(exception.ToString());
			}
			return directoryAllInfo;
		}
		/// <summary>
		/// 将指定目录路径下的所有目录和子目录或文件生成一张数据表
		/// 目录的数据列表包含字段：(文件名,文件全名,内容类型,文件类型,路径,创建时间,文件大小)name rname content_type type path creatime size
		/// </summary>
		/// <param name="dir">要生成目录列表的文件夹路径</param>
		/// <param name="method">文件类型：文件夹或者文件</param>
		/// <returns>目录的数据列表包含字段：(文件名,文件全名,内容类型,文件类型,路径,创建时间,文件大小)name rname content_type type path creatime size</returns>
		public static DataTable GetDirectoryAllInfosToDT(string dir, FileMethod method)
		{
			DataTable directoryAllInfo;
			try
			{
				DirectoryInfo d = new DirectoryInfo(dir);
				directoryAllInfo = GetDirectoryAllInfoToDT(d, method);
			}
			catch (Exception exception)
			{
				throw new FileNotFoundException(exception.ToString());
			}
			return directoryAllInfo;
		}
		/// <summary>
		/// 得到指定目录下的所有目录和子目录或文件的详细信息
		/// </summary>
		/// <param name="d"></param>
		/// <param name="method"></param>
		/// <returns></returns>
		private static List<DirDetail> GetDirectoryAllInfo(DirectoryInfo d, FileMethod method)
		{
			List<DirDetail> parent = new List<DirDetail>();
			foreach (DirectoryInfo info in d.GetDirectories())
			{
				if (method == FileMethod.File)
				{
					parent = CopyDT(parent, GetDirectoryAllInfo(info, method));
				}
				else
				{
					DirDetail ddInfo = new DirDetail();
					ddInfo.Name = info.Name;
					ddInfo.Rname = info.FullName;
					ddInfo.Content_type = string.Empty;
					ddInfo.Type = 1;
					ddInfo.Path = info.FullName.Replace(info.Name, string.Empty);
					ddInfo.Creatime = info.CreationTime;
					ddInfo.LastWriteTime = info.LastWriteTime;
					ddInfo.Size = 0;
					parent.Add(ddInfo);
					parent = CopyDT(parent, GetDirectoryAllInfo(info, method));
				}
			}
			if (method != FileMethod.Folder)
			{
				foreach (FileInfo info2 in d.GetFiles())
				{
					DirDetail ddInfo = new DirDetail();
					ddInfo.Name = info2.Name;
					ddInfo.Rname = info2.FullName;
					ddInfo.Content_type = info2.Extension.Replace(".", string.Empty);
					ddInfo.Type = 2;
					ddInfo.Path = info2.DirectoryName + DirectorySeparatorChar;
					ddInfo.Creatime = info2.CreationTime;
					ddInfo.LastWriteTime = info2.LastWriteTime;
					ddInfo.Size = info2.Length;
					parent.Add(ddInfo);
				}
			}
			return parent;
		}
		/// <summary>
		/// 得到指定目录下的所有目录和子目录或文件的详细信息
		/// </summary>
		/// <param name="d"></param>
		/// <param name="method"></param>
		/// <returns></returns>
		private static DataTable GetDirectoryAllInfoToDT(DirectoryInfo d, FileMethod method)
		{
			DataRow row;
			DataTable parent = new DataTable();
			parent.Locale = CultureInfo.CurrentCulture;
			parent.Columns.Add("name");
			parent.Columns.Add("rname");
			parent.Columns.Add("content_type");
			parent.Columns.Add("type");
			parent.Columns.Add("path");
			parent.Columns.Add("creatime", typeof(DateTime));
			parent.Columns.Add("size", typeof(int));
			foreach (DirectoryInfo info in d.GetDirectories())
			{
				if (method == FileMethod.File)
				{
					parent = CopyDT(parent, GetDirectoryAllInfoToDT(info, method));
				}
				else
				{
					row = parent.NewRow();
					row[0] = info.Name;
					row[1] = info.FullName;
					row[2] = string.Empty;
					row[3] = 1;
					row[4] = info.FullName.Replace(info.Name, string.Empty);
					row[5] = info.CreationTime;
					row[6] = 0;
					parent.Rows.Add(row);
					parent = CopyDT(parent, GetDirectoryAllInfoToDT(info, method));
				}
			}
			if (method != FileMethod.Folder)
			{
				foreach (FileInfo info2 in d.GetFiles())
				{
					row = parent.NewRow();
					row[0] = info2.Name;
					row[1] = info2.FullName;
					row[2] = info2.Extension.Replace(".", string.Empty);
					row[3] = 2;
					row[4] = info2.DirectoryName + DirectorySeparatorChar;
					row[5] = info2.CreationTime;
					row[6] = info2.Length;
					parent.Rows.Add(row);
				}
			}
			return parent;
		}

		/// <summary>
		/// 将指定目录路径下的所有目录不包括子目录或文件生成一张数据表
		/// name(文件名) type(文件类型：1：文件夹；2：文件；) size(文件大小) content_type(文件扩展名) creatime(创建时间) lastWriteTime(修改时间)
		/// </summary>
		/// <param name="dir">要生成目录列表的文件夹路径</param>
		/// <param name="method">文件类型：文件夹或者文件</param>
		/// <returns></returns>
		public static List<DirDetail> GetDirectoryInfos(string dir, FileMethod method)
		{
			dir = MapPath(dir);
			List<DirDetail> table = new List<DirDetail>();
			if (method != FileMethod.File)
			{
				for (int i = 0; i < Directory.GetDirectories(dir).Length; i++)
				{
					DirDetail ddInfo = new DirDetail();
					DirectoryInfo d = new DirectoryInfo(Directory.GetDirectories(dir)[i]);
					long[] numArray = DirInfo(d);
					ddInfo.Name = d.Name;
					ddInfo.Rname = d.FullName;
					ddInfo.Path = d.FullName.Replace(d.Name, string.Empty);
					ddInfo.Type = 1;
					ddInfo.Size = numArray[0];
					ddInfo.Content_type = string.Empty;
					ddInfo.Creatime = d.CreationTime;
					ddInfo.LastWriteTime = d.LastWriteTime;
					table.Add(ddInfo);
				}
			}
			if (method != FileMethod.Folder)
			{
				for (int j = 0; j < Directory.GetFiles(dir).Length; j++)
				{
					DirDetail ddInfo = new DirDetail();
					FileInfo info2 = new FileInfo(Directory.GetFiles(dir)[j]);
					ddInfo.Name = info2.Name;
					ddInfo.Rname = info2.FullName;
					ddInfo.Path = info2.DirectoryName + @"\";
					ddInfo.Type = 2;
					ddInfo.Size = info2.Length;
					ddInfo.Content_type = info2.Extension.Replace(".", string.Empty);
					ddInfo.Creatime = info2.CreationTime;
					ddInfo.LastWriteTime = info2.LastWriteTime;
					table.Add(ddInfo);
				}
			}
			return table;
		}
		/// <summary>
		/// 将指定目录路径下的所有目录不包括子目录或文件生成一张数据表
		/// name(文件名) type(文件类型：1：文件夹；2：文件；) size(文件大小) content_type(文件扩展名) creatime(创建时间) lastWriteTime(修改时间)
		/// </summary>
		/// <param name="dir">要生成目录列表的文件夹路径</param>
		/// <param name="method">文件类型：文件夹或者文件</param>
		/// <returns></returns>
		public static DataTable GetDirectoryInfosToDT(string dir, FileMethod method)
		{
			DataRow row;
			DataTable table = new DataTable();
			table.Locale = CultureInfo.CurrentCulture;
			table.Columns.Add("name", typeof(string));
			table.Columns.Add("type");
			table.Columns.Add("size", typeof(long));
			table.Columns.Add("content_type");
			table.Columns.Add("createTime", typeof(DateTime));
			table.Columns.Add("lastWriteTime", typeof(DateTime));
			if (method != FileMethod.File)
			{
				for (int i = 0; i < Directory.GetDirectories(dir).Length; i++)
				{
					row = table.NewRow();
					DirectoryInfo d = new DirectoryInfo(Directory.GetDirectories(dir)[i]);
					long[] numArray = DirInfo(d);
					row[0] = d.Name;
					row[1] = 1;
					row[2] = numArray[0];
					row[3] = string.Empty;
					row[4] = d.CreationTime;
					row[5] = d.LastWriteTime;
					table.Rows.Add(row);
				}
			}
			if (method != FileMethod.Folder)
			{
				for (int j = 0; j < Directory.GetFiles(dir).Length; j++)
				{
					row = table.NewRow();
					FileInfo info2 = new FileInfo(Directory.GetFiles(dir)[j]);
					row[0] = info2.Name;
					row[1] = 2;
					row[2] = info2.Length;
					row[3] = info2.Extension.Replace(".", string.Empty);
					row[4] = info2.CreationTime;
					row[5] = info2.LastWriteTime;
					table.Rows.Add(row);
				}
			}
			return table;
		}
		#endregion

		#region 文件与文件内容搜索
		/// <summary>
		/// 从指定目录下查找所有包含指定字符的所有文件，生成数据列表返回。
		/// 数据列表包括字段(name(文件名),type(2),size(文件大小，单位：字节),content_type(文件扩展名),createTime(创建时间),lastWriteTime(最后修改时间))
		/// </summary>
		/// <param name="dir">要搜索的目录</param>
		/// <param name="searchPattern">搜索模式如(*.*)</param>
		/// <param name="searchKeyword">要搜索的字符</param>
		/// <returns>包含关键词的文件列表，包括字段(name(文件名),type(2),size(文件大小，单位：字节),content_type(文件扩展名),createTime(创建时间),lastWriteTime(最后修改时间))</returns>
		public static List<DirDetail> SearchFileContent(string dir, string searchPattern, string searchKeyword)
		{
			dir = MapPath(dir);
			List<DirDetail> table = new List<DirDetail>();
			DirectoryInfo info = new DirectoryInfo(dir);
			foreach (FileInfo info2 in info.GetFiles(searchPattern, SearchOption.AllDirectories))
			{
				DirDetail ddInfo = new DirDetail();
				StreamReader reader = info2.OpenText();
				string str = reader.ReadToEnd();
				reader.Dispose();
				if (str.Contains(searchKeyword))
				{
					ddInfo.Name = info2.FullName.Remove(0, info.FullName.Length);
					ddInfo.Rname = info2.FullName;
					ddInfo.Path = info2.DirectoryName + DirectorySeparatorChar;
					ddInfo.Type = 2;
					ddInfo.Size = info2.Length;
					ddInfo.Content_type = info2.Extension.Replace(".", string.Empty);
					ddInfo.Creatime = info2.CreationTime;
					ddInfo.LastWriteTime = info2.LastWriteTime;
					table.Add(ddInfo);
				}
			}
			return table;
		}
		/// <summary>
		/// 从指定目录下查找所有包含指定字符的所有文件，生成数据列表返回。
		/// 数据列表包括字段(name(文件名),type(2),size(文件大小，单位：字节),content_type(文件扩展名),createTime(创建时间),lastWriteTime(最后修改时间))
		/// </summary>
		/// <param name="dir">要搜索的目录</param>
		/// <param name="searchPattern">搜索模式如(*.*)</param>
		/// <param name="searchKeyword">要搜索的字符</param>
		/// <returns>包含关键词的文件列表，包括字段(name(文件名),type(2),size(文件大小，单位：字节),content_type(文件扩展名),createTime(创建时间),lastWriteTime(最后修改时间))</returns>
		public static DataTable SearchFileContentToDT(string dir, string searchPattern, string searchKeyword)
		{
			DataTable table = new DataTable();
			table.Locale = CultureInfo.CurrentCulture;
			table.Columns.Add("name");
			table.Columns.Add("type");
			table.Columns.Add("size", typeof(int));
			table.Columns.Add("content_type");
			table.Columns.Add("createTime", typeof(DateTime));
			table.Columns.Add("lastWriteTime", typeof(DateTime));
			DirectoryInfo info = new DirectoryInfo(dir);
			foreach (FileInfo info2 in info.GetFiles(searchPattern, SearchOption.AllDirectories))
			{
				DataRow row = table.NewRow();
				StreamReader reader = info2.OpenText();
				string str = reader.ReadToEnd();
				reader.Dispose();
				if (str.Contains(searchKeyword))
				{
					row[0] = info2.FullName.Remove(0, info.FullName.Length);
					row[1] = 2;
					row[2] = info2.Length;
					row[3] = info2.Extension.Replace(".", string.Empty);
					row[4] = info2.CreationTime;
					row[5] = info2.LastWriteTime;
					table.Rows.Add(row);
				}
			}
			return table;
		}

		/// <summary>
		/// 指定条件搜索指定目录下的文件，生成数据列表
		/// 数据列表包括字段(name(文件名),type(2),size(文件大小，单位：字节),content_type(文件扩展名),createTime(创建时间),lastWriteTime(最后修改时间))
		/// </summary>
		/// <param name="dir">指定目录</param>
		/// <param name="searchPattern">搜索模式：如(*.gif)</param>
		/// <returns>符合条件的文件列表，包括字段(name,type,size,content_type,createTime,lastWriteTime)</returns>
		public static List<DirDetail> SearchFiles(string dir, string searchPattern)
		{
			dir = MapPath(dir);
			List<DirDetail> table = new List<DirDetail>();
			DirectoryInfo info = new DirectoryInfo(dir);
			foreach (FileInfo info2 in info.GetFiles(searchPattern, SearchOption.AllDirectories))
			{
				DirDetail ddInfo = new DirDetail();
				ddInfo.Name = info2.FullName.Remove(0, info.FullName.Length);
				ddInfo.Rname = info2.FullName;
				ddInfo.Path = info2.DirectoryName + DirectorySeparatorChar;
				ddInfo.Type = 2;
				ddInfo.Size = info2.Length;
				ddInfo.Content_type = info2.Extension.Replace(".", string.Empty);
				ddInfo.Creatime = info2.CreationTime;
				ddInfo.LastWriteTime = info2.LastWriteTime;
				table.Add(ddInfo);
			}
			return table;
		}
		/// <summary>
		/// 指定条件搜索指定目录下的文件，生成数据列表
		/// 数据列表包括字段(name(文件名),type(2),size(文件大小，单位：字节),content_type(文件扩展名),createTime(创建时间),lastWriteTime(最后修改时间))
		/// </summary>
		/// <param name="dir">指定目录</param>
		/// <param name="searchPattern">搜索模式：如(*.gif)</param>
		/// <returns>符合条件的文件列表，包括字段(name,type,size,content_type,createTime,lastWriteTime)</returns>
		public static DataTable SearchFilesToDT(string dir, string searchPattern)
		{
			DataTable table = new DataTable();
			table.Locale = CultureInfo.CurrentCulture;
			DirectoryInfo info = new DirectoryInfo(dir);
			table.Columns.Add("name");
			table.Columns.Add("type");
			table.Columns.Add("size", typeof(int));
			table.Columns.Add("content_type");
			table.Columns.Add("createTime", typeof(DateTime));
			table.Columns.Add("lastWriteTime", typeof(DateTime));
			foreach (FileInfo info2 in info.GetFiles(searchPattern, SearchOption.AllDirectories))
			{
				DataRow row = table.NewRow();
				row[0] = info2.FullName.Remove(0, info.FullName.Length);
				row[1] = 2;
				row[2] = info2.Length;
				row[3] = info2.Extension.Replace(".", string.Empty);
				row[4] = info2.CreationTime;
				row[5] = info2.LastWriteTime;
				table.Rows.Add(row);
			}
			return table;
		}

		/// <summary>
		/// 从指定目录下查找指定条件的模板文件(*.html,*.htm)，生成数据列表
		/// 数据列表包括字段(name(文件名),type(2),size(文件大小，单位：字节),content_type(文件扩展名),createTime(创建时间),lastWriteTime(最后修改时间))
		/// </summary>
		/// <param name="dir">指定目录</param>
		/// <param name="searchPattern">搜索词:如"商品"</param>
		/// <returns>符合条件的模板文件列表，包括字段(name,type,size,content_type,createTime,lastWriteTime)</returns>
		public static List<DirDetail> SearchTemplateFiles(string dir, string searchPattern)
		{
			dir = MapPath(dir);
			List<DirDetail> table = new List<DirDetail>();
			DirectoryInfo info = new DirectoryInfo(dir);
			string str = searchPattern;
			string str2 = searchPattern.ToLower();
			int length = searchPattern.Length;
			if (length < 4)
			{
				str = "*" + str + "*.html";
			}
			else if ((str2.Substring(length - 4, 4) != ".html") || (str2.Substring(length - 3, 3) != ".htm"))
			{
				str = "*" + str + "*.html";
			}
			try
			{
				foreach (FileInfo info2 in info.GetFiles(str, SearchOption.AllDirectories))
				{
					DirDetail ddInfo = new DirDetail();
					ddInfo.Name = info2.FullName.Remove(0, info.FullName.Length).Replace("/", "\"");
					ddInfo.Rname = info2.FullName;
					ddInfo.Path = info2.DirectoryName + DirectorySeparatorChar;
					ddInfo.Type = 2;
					ddInfo.Size = info2.Length;
					ddInfo.Content_type = info2.Extension.Replace(".", string.Empty);
					ddInfo.Creatime = info2.CreationTime;
					ddInfo.LastWriteTime = info2.LastWriteTime;
					table.Add(ddInfo);
				}
			}
			catch (ArgumentException)
			{
			}
			return table;
		}
		/// <summary>
		/// 从指定目录下查找指定条件的模板文件(*.html,*.htm)，生成数据列表
		/// 数据列表包括字段(name(文件名),type(2),size(文件大小，单位：字节),content_type(文件扩展名),createTime(创建时间),lastWriteTime(最后修改时间))
		/// </summary>
		/// <param name="dir">指定目录</param>
		/// <param name="searchPattern">搜索词:如"商品"</param>
		/// <returns>符合条件的模板文件列表，包括字段(name,type,size,content_type,createTime,lastWriteTime)</returns>
		public static DataTable SearchTemplateFilesToDT(string dir, string searchPattern)
		{
			DataTable table = new DataTable();
			table.Locale = CultureInfo.CurrentCulture;
			DirectoryInfo info = new DirectoryInfo(dir);
			string str = searchPattern;
			string str2 = searchPattern.ToLower(CultureInfo.CurrentCulture);
			int length = searchPattern.Length;
			if (length < 4)
			{
				str = "*" + str + "*.html";
			}
			else if ((str2.Substring(length - 4, 4) != ".html") || (str2.Substring(length - 3, 3) != ".htm"))
			{
				str = "*" + str + "*.html";
			}
			table.Columns.Add("name");
			table.Columns.Add("type");
			table.Columns.Add("size", typeof(int));
			table.Columns.Add("content_type");
			table.Columns.Add("createTime", typeof(DateTime));
			table.Columns.Add("lastWriteTime", typeof(DateTime));
			try
			{
				foreach (FileInfo info2 in info.GetFiles(str, SearchOption.AllDirectories))
				{
					DataRow row = table.NewRow();
					row[0] = info2.FullName.Remove(0, info.FullName.Length).Replace("/", "\"");
					row[1] = 2;
					row[2] = info2.Length;
					row[3] = info2.Extension.Replace(".", string.Empty);
					row[4] = info2.CreationTime;
					row[5] = info2.LastWriteTime;
					table.Rows.Add(row);
				}
			}
			catch (ArgumentException)
			{
			}
			return table;
		}
		#endregion
	}

	/// <summary>
	/// 文件目录详细信息类
	/// </summary>
	public class DirDetail
	{
		/// <summary>
		/// 文件名
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// 文件全名
		/// </summary>
		public string Rname { get; set; }
		/// <summary>
		/// 内容类型
		/// </summary>
		public string Content_type { get; set; }
		/// <summary>
		/// 文件类型(1：文件夹；2：文件；)
		/// </summary>
		public int Type { get; set; }
		/// <summary>
		/// 路径
		/// </summary>
		public string Path { get; set; }
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime Creatime { get; set; }
		/// <summary>
		/// 最后修改时间
		/// </summary>
		public DateTime LastWriteTime { get; set; }
		/// <summary>
		/// 文件大小
		/// </summary>
		public long Size { get; set; }
	}
}
