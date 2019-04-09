using JX.Infrastructure.Common;
using JX.Infrastructure.Field;
using System;
using System.Data;
using System.Text;

namespace JX.Infrastructure.Data
{
	/// <summary>
	/// 数据查询语句生成器
	/// </summary>
	public sealed class Query
	{
		private Query()
		{
		}

		#region 生成添加、修改、删除表中字段列的SQL语句
		/// <summary>
		/// 生成添加表字段语句
		/// </summary>
		/// <param name="fieldInfo"></param>
		/// <param name="tableName"></param>
		/// <returns></returns>
		public static string GetAddColumnToTableSql(FieldInfo fieldInfo, string tableName)
		{
			StringBuilder sqlText = new StringBuilder();
			sqlText.Append("ALTER TABLE [");
			sqlText.Append(tableName);
			sqlText.Append("] ADD [");
			if (fieldInfo.FieldType == FieldType.RegionType)
			{
				sqlText.Append(fieldInfo.FieldName + "_Country][nvarchar] (255),[");
				sqlText.Append(fieldInfo.FieldName + "_Province][nvarchar] (255),[");
				sqlText.Append(fieldInfo.FieldName + "_City][nvarchar] (255),[");
				sqlText.Append(fieldInfo.FieldName + "_Area][nvarchar] (255)");
			}
			else if (fieldInfo.FieldType == FieldType.RegionTypeFive)
			{
				sqlText.Append(fieldInfo.FieldName + "_Country][nvarchar] (255),[");
				sqlText.Append(fieldInfo.FieldName + "_Province][nvarchar] (255),[");
				sqlText.Append(fieldInfo.FieldName + "_City][nvarchar] (255),[");
				sqlText.Append(fieldInfo.FieldName + "_Area][nvarchar] (255),[");
				sqlText.Append(fieldInfo.FieldName + "_Area1][nvarchar] (255),[");
				sqlText.Append(fieldInfo.FieldName + "_Area2][nvarchar] (255)");
			}
			else
			{
				sqlText.Append(fieldInfo.FieldName);
				sqlText.Append("] ");
				if (fieldInfo.FieldType == FieldType.ListBoxDataType && fieldInfo.Settings[3].ToLower() == "string")
				{
					sqlText.Append("[nvarchar] (255)");
				}
				else
				{
					GetFieldType(fieldInfo.FieldType, sqlText);
				}
			}
			return sqlText.ToString();
		}
		/// <summary>
		/// 生成添加表区域字段列语句:添加四列：fieldInfo.FieldName +(_Country | _Province| _City| _Area)
		/// </summary>
		/// <param name="fieldInfo"></param>
		/// <param name="tableName"></param>
		/// <returns></returns>
		public static string GetAddRegionColumnToTableSql(FieldInfo fieldInfo, string tableName)
		{
			StringBuilder builder = new StringBuilder();
			builder.Append("ALTER TABLE [");
			builder.Append(tableName);
			builder.Append("] ADD [");
			builder.Append(fieldInfo.FieldName + "_Country][nvarchar] (255),[");
			builder.Append(fieldInfo.FieldName + "_Province][nvarchar] (255),[");
			builder.Append(fieldInfo.FieldName + "_City][nvarchar] (255),[");
			builder.Append(fieldInfo.FieldName + "_Area][nvarchar] (255)");
			return builder.ToString();
		}
		/// <summary>
		/// 生成添加表“数据绑定选项”字段语句。只能用于字符串类型的“数据绑定选项”。
		/// </summary>
		/// <param name="fieldInfo"></param>
		/// <param name="tableName"></param>
		/// <returns></returns>
		public static string GetAddListBoxDataColumnToTableSql(FieldInfo fieldInfo, string tableName)
		{
			StringBuilder builder = new StringBuilder();
			builder.Append("ALTER TABLE [");
			builder.Append(tableName);
			builder.Append("] ADD [");
			builder.Append(fieldInfo.FieldName);
			builder.Append("][nvarchar] (255)");
			return builder.ToString();
		}

		/// <summary>
		/// 生成修改字段语句
		/// </summary>
		/// <param name="fieldInfo"></param>
		/// <param name="tableName"></param>
		/// <returns></returns>
		public static string GetAlterColumnToTableSql(FieldInfo fieldInfo, string tableName)
		{
			StringBuilder sqlText = new StringBuilder();
			sqlText.Append(" ALTER TABLE [");
			sqlText.Append(tableName);
			sqlText.Append("] ALTER COLUMN [");
			sqlText.Append(fieldInfo.FieldName);
			sqlText.Append("]");
			if (fieldInfo.FieldType == FieldType.ListBoxDataType
				&& fieldInfo.Settings[3].ToLower() == "string")
			{
				sqlText.Append("[nvarchar] (255)");
			}
			else
			{
				GetFieldType(fieldInfo.FieldType, sqlText);
			}
			return sqlText.ToString();
		}

		/// <summary>
		/// 生成删除表字段语句
		/// </summary>
		/// <param name="fieldName"></param>
		/// <param name="tableName"></param>
		/// <returns></returns>
		public static string GetDeleteColumnFromTableSql(string fieldName, string tableName)
		{
			StringBuilder builder = new StringBuilder();
			builder.Append(" ALTER TABLE [");
			builder.Append(tableName);
			builder.Append("] DROP COLUMN [");
			builder.Append(fieldName);
			builder.Append("] ");
			return builder.ToString();
		}
		/// <summary>
		/// 生成删除表字段语句（行政区划）
		/// </summary>
		/// <param name="fieldName"></param>
		/// <param name="tableName"></param>
		/// <returns></returns>
		public static string GetDeleteRegionColumnFromTableSql(string fieldName, string tableName)
		{
			StringBuilder builder = new StringBuilder();
			builder.Append(" ALTER TABLE [");
			builder.Append(tableName);
			builder.Append("] DROP COLUMN [");
			builder.Append(fieldName + "_Country],[" + fieldName + "_Province],[" + fieldName + "_City],[" + fieldName + "_Area]");
			return builder.ToString();
		}
		/// <summary>
		/// 生成删除表字段语句（行政区划（5级））
		/// </summary>
		/// <param name="fieldName"></param>
		/// <param name="tableName"></param>
		/// <returns></returns>
		public static string GetDeleteRegionFiveColumnFromTableSql(string fieldName, string tableName)
		{
			StringBuilder builder = new StringBuilder();
			builder.Append(" ALTER TABLE [");
			builder.Append(tableName);
			builder.Append("] DROP COLUMN [");
			builder.Append(fieldName + "_Country],[" + fieldName + "_Province],[" + fieldName + "_City],[" + fieldName + "_Area],[" + fieldName + "_Area1],[" + fieldName + "_Area2]");
			return builder.ToString();
		}
		#endregion

		#region 生成插入、修改表中数据的SQL语句
		/// <summary>
		/// 生成插入SQL语句
		/// </summary>
		/// <param name="tableName"></param>
		/// <param name="contentData">包含添加信息内容的数据表：包含FieldType,FieldAsia,FieldLevel,FieldValue字段的数据行</param>
		/// <param name="filter"></param>
		/// <returns></returns>
		public static string GetInsertTableSql(string tableName, DataTable contentData, string filter)
		{
			DataRow[] dataRows = GetDataRows(contentData, filter);
			string filedSting = GetFiledSting(dataRows);
			string parametersString = GetParametersString(dataRows);
			return GetInsertTableSql(tableName, filedSting, parametersString);
		}
		/// <summary>
		/// 生成插入SQL语句：
		/// </summary>
		/// <param name="tableName"></param>
		/// <param name="strField">插入语句INSERT INTO 段</param>
		/// <param name="paramters">插入语句VALUES 段</param>
		/// <returns></returns>
		public static string GetInsertTableSql(string tableName, string strField, string paramters)
		{
			StringBuilder builder = new StringBuilder();
			builder.Append("INSERT INTO ");
			builder.Append(tableName);
			builder.Append("(");
			builder.Append(strField);
			builder.Append(")");
			builder.Append("VALUES");
			builder.Append("(");
			builder.Append(paramters);
			builder.Append(")");
			return builder.ToString();
		}

		/// <summary>
		/// 生成更新SQL语句
		/// </summary>
		/// <param name="tableName"></param>
		/// <param name="contentData">包含添加信息内容的数据表：包含FieldType,FieldAsia,FieldLevel,FieldValue字段的数据行</param>
		/// <param name="filter"></param>
		/// <param name="where"></param>
		/// <returns></returns>
		public static string GetUpdataSql(string tableName, DataTable contentData, string filter, string where)
		{
			string updateFieldList = GetUpdateFieldList(GetDataRows(contentData, filter));
			return GetUpdateSql(tableName, updateFieldList, where);
		}
		/// <summary>
		/// 生成更新SQL语句:
		/// </summary>
		/// <param name="tableName"></param>
		/// <param name="strUpdateField">更新SQL语句更新部分</param>
		/// <param name="where">更新SQL语句更新条件部分</param>
		/// <returns></returns>
		public static string GetUpdateSql(string tableName, string strUpdateField, string where)
		{
			StringBuilder builder = new StringBuilder();
			builder.Append(" UPDATE ");
			builder.Append(tableName);
			builder.Append(" SET ");
			builder.Append(strUpdateField);
			builder.Append(" WHERE ");
			builder.Append(where);
			return builder.ToString();
		}
		
		/// <summary>
		/// 从模型数据表行中获取字段名称，生成逗号分隔的字符串
		/// </summary>
		/// <param name="rows">包含FieldType,FieldAsia,FieldLevel,FieldValue字段的数据行</param>
		/// <returns></returns>
		public static string GetFiledSting(DataRow[] rows)
		{
			StringBuilder builder = new StringBuilder();
			foreach (DataRow row in rows)
			{
				if (string.Compare(row["FieldType"].ToString(), "RegionType", true) == 0)
				{
					builder.Append(" [" + row["FieldName"] + "_Country],");
					builder.Append(" [" + row["FieldName"] + "_Province],");
					builder.Append(" [" + row["FieldName"] + "_City],");
					builder.Append(" [" + row["FieldName"] + "_Area]");
					builder.Append(",");
				}
				else if (string.Compare(row["FieldType"].ToString(), "RegionTypeFive", true) == 0)
				{
					builder.Append(" [" + row["FieldName"] + "_Country],");
					builder.Append(" [" + row["FieldName"] + "_Province],");
					builder.Append(" [" + row["FieldName"] + "_City],");
					builder.Append(" [" + row["FieldName"] + "_Area],");
					builder.Append(" [" + row["FieldName"] + "_Area1],");
					builder.Append(" [" + row["FieldName"] + "_Area2]");
					builder.Append(",");
				}
				else
				{
					builder.Append("[");
					builder.Append(row["FieldName"]);
					builder.Append("] ");
					builder.Append(",");
				}
			}
			if (builder.Length > 1)
			{
				builder.Remove(builder.Length - 1, 1);
			}
			return builder.ToString();
		}
		/// <summary>
		/// 从数据行中获取字段，并生成查询语句:@FieldName1,@FieldName2....
		/// </summary>
		/// <param name="rows">包含添加信息内容的数据表：包含FieldType,FieldAsia,FieldLevel,FieldValue字段的数据行</param>
		/// <returns></returns>
		public static string GetParametersString(DataRow[] rows)
		{
			StringBuilder builder = new StringBuilder();
			foreach (DataRow row in rows)
			{
				if (string.Compare(row["FieldType"].ToString(), "RegionType", true) == 0)
				{
					builder.Append(" @" + row["FieldName"] + "_Country,");
					builder.Append(" @" + row["FieldName"] + "_Province,");
					builder.Append(" @" + row["FieldName"] + "_City,");
					builder.Append(" @" + row["FieldName"] + "_Area");
					builder.Append(",");
				}
				else if (string.Compare(row["FieldType"].ToString(), "RegionTypeFive", true) == 0)
				{
					builder.Append(" @" + row["FieldName"] + "_Country,");
					builder.Append(" @" + row["FieldName"] + "_Province,");
					builder.Append(" @" + row["FieldName"] + "_City,");
					builder.Append(" @" + row["FieldName"] + "_Area,");
					builder.Append(" @" + row["FieldName"] + "_Area1,");
					builder.Append(" @" + row["FieldName"] + "_Area2");
					builder.Append(",");
				}
				else
				{
					builder.Append("@");
					builder.Append(row["FieldName"]);
					builder.Append(",");
				}
			}
			if (builder.Length > 1)
			{
				builder.Remove(builder.Length - 1, 1);
			}
			return builder.ToString();
		}
		/// <summary>
		/// 从数据表中获取字段，并生成查询参数语句。
		/// </summary>
		/// <param name="contentData">包含添加信息内容的数据表：包含FieldType,FieldAsia,FieldLevel,FieldValue字段的数据行</param>
		/// <param name="filter"></param>
		/// <returns></returns>
		public static Parameters GetParameters(DataTable contentData, string filter)
		{
			Parameters parameters = new Parameters();
			foreach (DataRow row in GetDataRows(contentData, filter))
			{
				object fieldValue = row["FieldValue"];
				FieldType fieldType = (FieldType)Enum.Parse(typeof(FieldType), row["FieldType"].ToString());
				if (fieldType == FieldType.RegionType)
				{
					string[] strArray = row["FieldValue"].ToString().Split(new char[] { ',' });
					parameters.AddInParameter("@" + row["FieldName"] + "_Country", GetFieldParameType(fieldType), strArray[0]);
					parameters.AddInParameter("@" + row["FieldName"] + "_Province", GetFieldParameType(fieldType), strArray[1]);
					parameters.AddInParameter("@" + row["FieldName"] + "_City", GetFieldParameType(fieldType), strArray[2]);
					parameters.AddInParameter("@" + row["FieldName"] + "_Area", GetFieldParameType(fieldType), strArray[3]);
				}
				else if (fieldType == FieldType.RegionTypeFive)
				{
					string[] strArray = row["FieldValue"].ToString().Split(new char[] { ',' });
					parameters.AddInParameter("@" + row["FieldName"] + "_Country", GetFieldParameType(fieldType), strArray[0]);
					parameters.AddInParameter("@" + row["FieldName"] + "_Province", GetFieldParameType(fieldType), strArray[1]);
					parameters.AddInParameter("@" + row["FieldName"] + "_City", GetFieldParameType(fieldType), strArray[2]);
					parameters.AddInParameter("@" + row["FieldName"] + "_Area", GetFieldParameType(fieldType), strArray[3]);
					parameters.AddInParameter("@" + row["FieldName"] + "_Area1", GetFieldParameType(fieldType), strArray[4]);
					parameters.AddInParameter("@" + row["FieldName"] + "_Area2", GetFieldParameType(fieldType), strArray[5]);
				}
				else if (fieldType == FieldType.ListBoxDataType)
				{
					int nValue = 0;
					if (int.TryParse(fieldValue.ToString(), out nValue))
					{
						parameters.AddInParameter("@" + row["FieldName"], DbType.Int32, fieldValue);
					}
					else
					{
						parameters.AddInParameter("@" + row["FieldName"], DbType.String, fieldValue);
					}
				}
				else
				{
					parameters.AddInParameter("@" + row["FieldName"], GetFieldParameType(fieldType), GetFieldValue(fieldType, fieldValue));
				}
			}
			return parameters;
		}
		/// <summary>
		/// 生成更新字段语句：[FieldName]=@FieldName,...
		/// </summary>
		/// <param name="rows">包含添加信息内容的数据表：包含FieldType,FieldAsia,FieldLevel,FieldValue字段的数据行</param>
		/// <returns></returns>
		public static string GetUpdateFieldList(DataRow[] rows)
		{
			StringBuilder builder = new StringBuilder();
			foreach (DataRow row in rows)
			{
				if (string.Compare(row["FieldType"].ToString(), "RegionType", true) == 0)
				{
					builder.Append(string.Concat(new object[] { " [", row["FieldName"], "_Country] = @", row["FieldName"], "_Country," }));
					builder.Append(string.Concat(new object[] { " [", row["FieldName"], "_Province] = @", row["FieldName"], "_Province," }));
					builder.Append(string.Concat(new object[] { " [", row["FieldName"], "_City] = @", row["FieldName"], "_City," }));
					builder.Append(string.Concat(new object[] { " [", row["FieldName"], "_Area] = @", row["FieldName"], "_Area" }));
					builder.Append(",");
				}
				else if (string.Compare(row["FieldType"].ToString(), "RegionTypeFive", true) == 0)
				{
					builder.Append(string.Concat(new object[] { " [", row["FieldName"], "_Country] = @", row["FieldName"], "_Country," }));
					builder.Append(string.Concat(new object[] { " [", row["FieldName"], "_Province] = @", row["FieldName"], "_Province," }));
					builder.Append(string.Concat(new object[] { " [", row["FieldName"], "_City] = @", row["FieldName"], "_City," }));
					builder.Append(string.Concat(new object[] { " [", row["FieldName"], "_Area] = @", row["FieldName"], "_Area," }));
					builder.Append(string.Concat(new object[] { " [", row["FieldName"], "_Area1] = @", row["FieldName"], "_Area1," }));
					builder.Append(string.Concat(new object[] { " [", row["FieldName"], "_Area2] = @", row["FieldName"], "_Area2" }));
					builder.Append(",");
				}
				else
				{
					builder.Append(" [");
					builder.Append(row["FieldName"]);
					builder.Append("]");
					builder.Append(" = ");
					builder.Append("@");
					builder.Append(row["FieldName"]);
					builder.Append(",");
				}
			}
			if (builder.Length > 1)
			{
				builder.Remove(builder.Length - 1, 1);
			}
			return builder.ToString();
		}

		/// <summary>
		/// 从数据表选择指定条件的数据行
		/// </summary>
		/// <param name="contentData"></param>
		/// <param name="filter"></param>
		/// <returns></returns>
		public static DataRow[] GetDataRows(DataTable contentData, string filter)
		{
			if (!string.IsNullOrEmpty(filter))
			{
				return contentData.Select(filter);
			}
			return contentData.Select();
		}
		#endregion

		#region 模型字段类型与字段值、SQL类型之间的转换
		/// <summary>
		/// 根据模型字段类型，获取字段参数数据类型
		/// </summary>
		/// <param name="fieldType"></param>
		/// <returns></returns>
		public static DbType GetFieldParameType(FieldType fieldType)
		{
			switch (fieldType)
			{
				case FieldType.TextType:
				case FieldType.MultipleTextType:
				case FieldType.MultipleHtmlTextType:
				case FieldType.ListBoxType:
				case FieldType.ListBoxIntroType:
				case FieldType.LookType:
				case FieldType.LinkType:
				case FieldType.CountType:
				case FieldType.PictureType:
				case FieldType.FileType:
				case FieldType.ColorType:
				case FieldType.TemplateType:
				case FieldType.AuthorType:
				case FieldType.SourceType:
				case FieldType.KeywordType:
				case FieldType.OperatingType:
				case FieldType.DownServerType:
				case FieldType.Producer:
				case FieldType.Trademark:
				case FieldType.ContentType:
				case FieldType.TitleType:
				case FieldType.MultiplePhotoType:
				case FieldType.SelectUser:
				case FieldType.IPType:
				case FieldType.NodeType:
				case FieldType.InfoType:
				case FieldType.StatusType:
				case FieldType.RegionType:
				case FieldType.RegionTypeFive:
				case FieldType.RegionTypeSelect:
				case FieldType.RegionTypeDropDown:
				case FieldType.RegionTypeText:
				case FieldType.IndustryCategory:
				case FieldType.NodeCategory:
				case FieldType.NumBuilder:
				case FieldType.QRCodeType:
					return DbType.String;

				case FieldType.NumberType:
					return DbType.Double;

				case FieldType.MoneyType:
					return DbType.Currency;

				case FieldType.DateTimeType:
					return DbType.DateTime;

				case FieldType.BoolType:
					return DbType.Boolean;

				case FieldType.ListBoxDataType:
					return DbType.Int32;
			}
			return DbType.Int32;
		}
		/// <summary>
		/// 根据模型字段类型，转换字段值
		/// </summary>
		/// <param name="fieldType"></param>
		/// <param name="fieldValue"></param>
		/// <returns></returns>
		public static object GetFieldValue(FieldType fieldType, object fieldValue)
		{
			switch (fieldType)
			{
				case FieldType.NumberType:
				case FieldType.MoneyType:
					if (string.IsNullOrEmpty(fieldValue.ToString()))
					{
						fieldValue = DBNull.Value;
					}
					return fieldValue;

				case FieldType.DateTimeType:
					if (!string.IsNullOrEmpty(fieldValue.ToString()))
					{
						fieldValue = DataConverter.CDate(fieldValue.ToString());
						return fieldValue;
					}
					fieldValue = DBNull.Value;
					return fieldValue;

				case FieldType.LookType:
				case FieldType.LinkType:
				case FieldType.QRCodeType:
					return fieldValue;

				case FieldType.BoolType:
					fieldValue = DataConverter.CBoolean(fieldValue.ToString());
					return fieldValue;

				case FieldType.RegionType:
				case FieldType.RegionTypeFive:
				case FieldType.RegionTypeSelect:
				case FieldType.RegionTypeDropDown:
				case FieldType.RegionTypeText:
					return fieldValue;

				case FieldType.IndustryCategory:
					return fieldValue;
			}
			return fieldValue;
		}
		/// <summary>
		/// 根据模型字段类型，生成添加表字段类型的SQL语句：[nvarchar] (255)
		/// </summary>
		/// <param name="fieldType"></param>
		/// <param name="sqlText"></param>
		private static void GetFieldType(FieldType fieldType, StringBuilder sqlText)
		{
			switch (fieldType)
			{
				case FieldType.TextType:
				case FieldType.ListBoxType:
				case FieldType.LookType:
				case FieldType.CountType:
				case FieldType.ColorType:
				case FieldType.TemplateType:
				case FieldType.AuthorType:
				case FieldType.SourceType:
				case FieldType.KeywordType:
				case FieldType.OperatingType:
				case FieldType.Producer:
				case FieldType.Trademark:
				case FieldType.TitleType:
				case FieldType.SelectUser:
				case FieldType.IPType:
				case FieldType.IndustryCategory:
				case FieldType.NumBuilder:
					sqlText.Append("[nvarchar] (255)");
					return;

				case FieldType.MultipleTextType:
				case FieldType.MultipleHtmlTextType:
				case FieldType.LinkType:
				case FieldType.PictureType:
				case FieldType.FileType:
				case FieldType.DownServerType:
				case FieldType.ContentType:
				case FieldType.MultiplePhotoType:
				case FieldType.QRCodeType:
					sqlText.Append("[ntext]");
					return;

				case FieldType.NumberType:
					sqlText.Append(" [float] ");
					return;

				case FieldType.MoneyType:
					sqlText.Append(" [money] ");
					return;

				case FieldType.DateTimeType:
					sqlText.Append("[datetime]");
					return;

				case FieldType.BoolType:
					sqlText.Append("[bit]");
					return;

				case FieldType.RegionType:
				case FieldType.RegionTypeFive:
				case FieldType.RegionTypeDropDown:
				case FieldType.RegionTypeText:
					sqlText.Append("[nvarchar] (255)");
					return;
				case FieldType.RegionTypeSelect:
					sqlText.Append("[ntext]");
					return;
				case FieldType.NodeCategory:
				case FieldType.ListBoxIntroType:
					sqlText.Append("[nvarchar] (MAX)");
					return;
				case FieldType.ListBoxDataType:
					sqlText.Append("[Int]");
					return;
			}
			sqlText.Append("[Int]");
		}
		#endregion
	}
}
