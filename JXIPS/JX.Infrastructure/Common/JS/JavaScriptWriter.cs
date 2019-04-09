﻿using System;
using System.Text;

namespace JX.Infrastructure.Common
{
	/// <summary>
	/// 实现客户端脚本输出
	/// </summary>
	public class JavaScriptWriter
	{
		#region 成员变量和属性

		private StringBuilder sb = new StringBuilder();
		private int openBlocks = 0;
		private bool format = false;

		/// <summary>
		/// 当前的缩进层次
		/// </summary>
		private int currIndent = 0;
		/// <summary>
		/// 当前的缩进层次
		/// </summary>
		public int Indent
		{
			get { return currIndent; }
			set { currIndent = value; }
		}

		#endregion

		#region 构造函数

		/// <summary>
		/// 
		/// </summary>
		public JavaScriptWriter()
		{
		}

		/// <summary>
		/// 在输出到页面时是否需要格式
		/// </summary>
		/// <param name="Formatted">需要格式?</param>
		public JavaScriptWriter(bool Formatted)
		{
			format = Formatted;
		}
		#endregion

		#region 公开方法

		/// <summary>
		/// 新增一行javascript代码
		/// </summary>
		/// <param name="parts">代码字串的数组</param>
		public void AddLine(params string[] parts)
		{
			// 如果有格式设置，则加入缩进的行
			if (format)
				for (int i = 0; i < currIndent; i++)
					sb.Append("\t");

			foreach (string part in parts)
				sb.Append(part);

			if (format)
				sb.Append(Environment.NewLine);
			else
				if (parts.Length > 0)
				sb.Append(" ");
		}

		/// <summary>
		/// 输入"{"，并使层次缩进一层
		/// </summary>
		public void OpenBlock()
		{
			AddLine("{");
			currIndent++;
			openBlocks++;
		}

		/// <summary>
		/// 输入"}"，并使层次扩展一层
		/// </summary>
		public void CloseBlock()
		{
			// 检查一个function有没有"{"
			if (openBlocks < 1)
				throw new InvalidOperationException("在调用JavaScriptWriter.CloseBlock()时没有先前的JavaScriptWriter.OpenBlock()调用");

			currIndent--;
			openBlocks--;
			AddLine("}");
		}

		/// <summary>
		/// 加入注解的(为javascript加入注解)
		/// </summary>
		/// <param name="CommentText">注解的字串数组.</param>
		public void AddCommentLine(params string[] CommentText)
		{
			if (format)
			{
				for (int i = 0; i < currIndent; i++)
					sb.Append("\t");

				sb.Append("// ");

				foreach (string part in CommentText)
					sb.Append(part);

				sb.Append(Environment.NewLine);
			}
		}

		/// <summary>
		/// 转换开发和结束的javascript的标记，并在中间加入已加入的javascrpt的代码
		/// </summary>
		/// <returns>返回标准的javascript代码</returns>
		public override string ToString()
		{
			if (openBlocks > 0)
				throw new InvalidOperationException("JavaScriptWriter: 没有相应的关闭标识");

			return String.Format(
				"<script language=\"javascript\" type=\"text/javascript\">{0}{1}</script>",
				Environment.NewLine,
				sb
				);
		}

		#endregion
	}
}
