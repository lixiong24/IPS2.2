using CodeSmith.Engine;
using SchemaExplorer;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Diagnostics;

namespace CommonFunction
{
	/// <summary>
	/// 为CodeSmith中的模板提供常用函数。
	/// </summary>
	public class Common : CodeTemplate
	{
		private string entityFormat 		= "{0}";
		
		#region GetName	
				
		#region 得到符合类命名规则的名字
		/// <summary>
		/// 得到符合类命名规则的名字。（去除字符串中的空格和非法字符，并把首字母转换成大写。合法字符：a-z,A-Z,0-9,_）
		/// </summary>
		/// <param name="table"></param>
		/// <returns></returns>
		public string GetClassName(SchemaObjectBase table)
		{
			return GetClassName(table.Name);
		}
		/// <summary>
		/// 得到符合类命名规则的名字。（去除字符串中的空格和非法字符，并把首字母转换成大写。合法字符：a-z,A-Z,0-9,_）
		/// </summary>
		/// <param name="tableName"></param>
		/// <returns></returns>
		public string GetClassName(string tableName)
		{
			// 1.remove space or bad characters
			string name = GetCleanName(string.Format(this.entityFormat, tableName));
			// 2. Set Pascal case
			name = GetPascalCaseName(name);
			return name;
		}
		#endregion
		
		#region 清除不规则的字符，返回符合规则的字符
		/// <summary>
		/// 清除不规则的字符，返回符合规则的字符。(合法字符：a-z,A-Z,0-9,_)
		/// </summary>
		/// <param name="name">要清除的字符</param>
		/// <returns>清除后的字符</returns>
		public string GetCleanName(string name)
		{
			return Regex.Replace(name, @"[\W]", "");
		}
		/// <summary>
		/// 清除不规则的字符，返回符合规则的字符。(合法字符：a-z,A-Z,0-9,_)
		/// </summary>
		/// <param name="schemaObject">DB Object whose name is to be cleaned</param>
		/// <returns>清除后的字符</returns>
		public string GetCleanName(SchemaObjectBase schemaObject)
		{
			return GetCleanName(schemaObject.Name);
		}
		#endregion
	
		#region 得到匈牙利命名规则的字符串(把首字母转换成大写)
		/// <summary>
		/// 得到匈牙利命名规则的字符串(把首字母转换成大写)
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public string GetPascalCaseName(string name)
		{
			//return name.Substring(0, 1).ToUpper() + name.Substring(1,name.Length-2) + name.Substring(name.Length-1).ToLower();
			return name.Substring(0, 1).ToUpper() + name.Substring(1);
		}
		#endregion
		
		#region 得到驼峰命名法的字符串(把首字母转换成小写)
		/// <summary>
		/// 得到驼峰命名法的字符串(把首字母转换成小写)
		/// 如果 name 都是大写, 全部转换成小写。
		/// </summary>
		/// <param name="name">Name to be changed</param>
		/// <returns>CamelCased version of the name</returns>
		public string GetCamelCaseName(string name)
		{
			if (name.Equals(name.ToUpper()))
				return name.ToLower().Replace(" ", "");
			else
				return name.Substring(0, 1).ToLower() + name.Substring(1).Replace(" ", "");
		}
		#endregion
	
		#region 得到安全的名字
		/// <summary>
		/// 如果字符串中有(' ', '@', '-', ',', '!')中的一个，就用[]把字符串括起来
		/// </summary>
		/// <param name="schemaObject">Database schema object (e.g. a table, stored proc, etc)</param>
		/// <returns>The safe name of the object</returns>
		public string GetSafeName(SchemaObjectBase schemaObject)
		{
			return GetSafeName(schemaObject.Name);
		}
		/// <summary>
		/// 如果字符串中有(' ', '@', '-', ',', '!')中的一个，就用[]把字符串括起来
		/// </summary>
		/// <param name="objectName">The name of the database schema object</param>
		/// <returns>The safe name of the object</returns>
		public string GetSafeName(string objectName)
		{
			return objectName.IndexOfAny(new char[] { ' ', '@', '-', ',', '!' }) > -1 ? "[" + objectName + "]" : objectName;
		}
		#endregion
		
		#region 得到以驼峰法命名并清除了不规则字符的名字
		/// <summary>
		/// 得到以驼峰法命名并清除了不规则字符的名字
		/// </summary>
		/// <param name="par">Command Parameter</param>
		/// <returns>the cleaned, camelcased name </returns>
		public string GetCleanParName(ParameterSchema par)
		{
			return GetCleanParName(par.Name);
		}
		/// <summary>
		/// 得到以驼峰法命名并清除了不规则字符的名字
		/// </summary>
		/// <param name="name">name to be cleaned</param>
		/// <returns>the cleaned, camelcased name </returns>
		public string GetCleanParName(string name)
		{
			return GetCamelCaseName(GetCleanName(name));
		}
		#endregion
		
		#region 得到以属性形式表现的名字。（清除不规则的字符并以匈牙利命名法命名）
		/// <summary>
		/// 得到以属性形式表现的名字。（清除不规则的字符并以匈牙利命名法命名）
		/// </summary>
		/// <param name="name">name to be cleaned</param>
		/// <returns>the cleaned, camelcased name </returns>
		public string GetPropertyName(string name)
		{
			name = Regex.Replace(name, @"[\W]", "");
			name = GetPascalCaseName(name);
			return name;
		}
		/// <summary>
		/// 得到以属性形式表现的名字。（清除不规则的字符并以匈牙利命名法命名）
		/// </summary>
		/// <param name="schemaObject">name to be cleaned</param>
		/// <returns>the cleaned, camelcased name </returns>
		public string GetPropertyName(SchemaObjectBase schemaObject)
		{
			return GetPropertyName(schemaObject.Name);
		}
		#endregion
				
		#region Model层/DAL层/Biz层的命名方法
		/// <summary>
		/// 得到实体类名字。(在字符串尾部加上"Entity",去除字符串中的空格和非法字符，并把首字母转换成大写。)
		/// </summary>
		/// <param name="tableName"></param>
		/// <returns></returns>
		public string GetModelClassName(string tableName)
		{
			return GetClassName(tableName) + "Entity";
		}
		/// <summary>
		/// 得到实体类名字。(在字符串尾部加上"Entity",去除字符串中的空格和非法字符，并把首字母转换成大写。)
		/// </summary>
		/// <param name="schemaObject"></param>
		/// <returns></returns>
		public string GetModelClassName(SchemaObjectBase schemaObject)
		{
			return GetClassName(schemaObject.Name) + "Entity";
		}
		
		/// <summary>
		/// 得到DAL层名字。(在字符串尾部加上"DAL",去除字符串中的空格和非法字符，并把首字母转换成大写。)
		/// </summary>
		/// <param name="tableName"></param>
		/// <returns></returns>
		public string GetDALClassName(string tableName)
		{
			return GetClassName(tableName) + "DAL";
		}
		/// <summary>
		/// 得到DAL层名字。(在字符串尾部加上"DAL",去除字符串中的空格和非法字符，并把首字母转换成大写。)
		/// </summary>
		/// <param name="schemaObject"></param>
		/// <returns></returns>
		public string GetDALClassName(SchemaObjectBase schemaObject)
		{
			return GetClassName(schemaObject.Name) + "DAL";
		}
		
		/// <summary>
		/// 得到Biz层名字。(在字符串尾部加上"Biz",去除字符串中的空格和非法字符，并把首字母转换成大写。)
		/// </summary>
		/// <param name="tableName"></param>
		/// <returns></returns>
		public string GetBizClassName(string tableName)
		{
			return GetClassName(tableName) + "Biz";
		}
		/// <summary>
		/// 得到Biz层名字。(在字符串尾部加上"Biz",去除字符串中的空格和非法字符，并把首字母转换成大写。)
		/// </summary>
		/// <param name="schemaObject"></param>
		/// <returns></returns>
		public string GetBizClassName(SchemaObjectBase schemaObject)
		{
			return GetClassName(schemaObject.Name) + "Biz";
		}
		#endregion
		
		#region Domain层/Repository层/Application层的命名方法
		/// <summary>
		/// 得到实体类名字。(去除字符串中的空格和非法字符，并把首字母转换成大写，名字后面添加Entity。)
		/// </summary>
		/// <param name="tableName"></param>
		/// <returns></returns>
		public string GetEntityClassName(string tableName)
		{
			return GetClassName(tableName) + "Entity";
		}
		/// <summary>
		/// 得到实体类名字。(去除字符串中的空格和非法字符，并把首字母转换成大写。)
		/// </summary>
		/// <param name="schemaObject"></param>
		/// <returns></returns>
		public string GetEntityClassName(SchemaObjectBase schemaObject)
		{
			return GetClassName(schemaObject.Name) + "Entity";
		}
		
		/// <summary>
		/// 得到Domain层名字。(在字符串尾部加上"ServeicDomain",去除字符串中的空格和非法字符，并把首字母转换成大写。)
		/// </summary>
		/// <param name="tableName"></param>
		/// <returns></returns>
		public string GetDomainClassName(string tableName)
		{
			return GetClassName(tableName) + "ServeicDomain";
		}
		/// <summary>
		/// 得到Domain层名字。(在字符串尾部加上"ServeicDomain",去除字符串中的空格和非法字符，并把首字母转换成大写。)
		/// </summary>
		/// <param name="schemaObject"></param>
		/// <returns></returns>
		public string GetDomainClassName(SchemaObjectBase schemaObject)
		{
			return GetClassName(schemaObject.Name) + "ServeicDomain";
		}
		
		/// <summary>
		/// 得到IRepositories层名字。
		/// </summary>
		/// <param name="tableName"></param>
		/// <returns></returns>
		public string GetIRepositoriesClassName(string tableName)
		{
			return "I" + GetClassName(tableName) + "Repository";
		}
		/// <summary>
		/// 得到IRepositories层名字。
		/// </summary>
		/// <param name="schemaObject"></param>
		/// <returns></returns>
		public string GetIRepositoriesClassName(SchemaObjectBase schemaObject)
		{
			return "I" + GetClassName(schemaObject.Name) + "Repository";
		}
		
		/// <summary>
		/// 得到IRepositoriesADO层名字。
		/// </summary>
		/// <param name="tableName"></param>
		/// <returns></returns>
		public string GetIRepositoriesADOClassName(string tableName)
		{
			return "I" + GetClassName(tableName) + "RepositoryADO";
		}
		/// <summary>
		/// 得到IRepositoriesADO层名字。
		/// </summary>
		/// <param name="schemaObject"></param>
		/// <returns></returns>
		public string GetIRepositoriesADOClassName(SchemaObjectBase schemaObject)
		{
			return "I" + GetClassName(schemaObject.Name) + "RepositoryADO";
		}
		
		/// <summary>
		/// 得到Repository层名字。(在字符串尾部加上"Repository",去除字符串中的空格和非法字符，并把首字母转换成大写。)
		/// </summary>
		/// <param name="tableName"></param>
		/// <returns></returns>
		public string GetRepositoryClassName(string tableName)
		{
			return GetClassName(tableName) + "Repository";
		}
		/// <summary>
		/// 得到Repository层名字。(在字符串尾部加上"Repository",去除字符串中的空格和非法字符，并把首字母转换成大写。)
		/// </summary>
		/// <param name="schemaObject"></param>
		/// <returns></returns>
		public string GetRepositoryClassName(SchemaObjectBase schemaObject)
		{
			return GetClassName(schemaObject.Name) + "Repository";
		}
		
		/// <summary>
		/// 得到RepositoryADO层名字。(在字符串尾部加上"RepositoryADO",去除字符串中的空格和非法字符，并把首字母转换成大写。)
		/// </summary>
		/// <param name="tableName"></param>
		/// <returns></returns>
		public string GetRepositoryADOClassName(string tableName)
		{
			return GetClassName(tableName) + "RepositoryADO";
		}
		/// <summary>
		/// 得到RepositoryADO层名字。(在字符串尾部加上"RepositoryADO",去除字符串中的空格和非法字符，并把首字母转换成大写。)
		/// </summary>
		/// <param name="schemaObject"></param>
		/// <returns></returns>
		public string GetRepositoryADOClassName(SchemaObjectBase schemaObject)
		{
			return GetClassName(schemaObject.Name) + "RepositoryADO";
		}
		
		/// <summary>
		/// 得到DTO层名字。(在字符串尾部加上"DTO",去除字符串中的空格和非法字符，并把首字母转换成大写。)
		/// </summary>
		/// <param name="tableName"></param>
		/// <returns></returns>
		public string GetDTOClassName(string tableName)
		{
			return GetClassName(tableName) + "DTO";
		}
		/// <summary>
		/// 得到DTO层名字。(在字符串尾部加上"DTO",去除字符串中的空格和非法字符，并把首字母转换成大写。)
		/// </summary>
		/// <param name="schemaObject"></param>
		/// <returns></returns>
		public string GetDTOClassName(SchemaObjectBase schemaObject)
		{
			return GetClassName(schemaObject.Name) + "DTO";
		}
		
		/// <summary>
		/// 得到IAppService层名字。(例：IAddressServiceApp)
		/// </summary>
		/// <param name="tableName"></param>
		/// <returns></returns>
		public string GetIAppServiceClassName(string tableName)
		{
			return "I" + GetClassName(tableName) + "ServiceApp";
		}
		/// <summary>
		/// 得到IAppService层名字。(例：IAddressServiceApp)
		/// </summary>
		/// <param name="schemaObject"></param>
		/// <returns></returns>
		public string GetIAppServiceClassName(SchemaObjectBase schemaObject)
		{
			return "I" + GetClassName(schemaObject.Name) + "ServiceApp";
		}
		
		/// <summary>
		/// 得到IAppServiceADO层名字。(例：IAddressServiceAppADO)
		/// </summary>
		/// <param name="tableName"></param>
		/// <returns></returns>
		public string GetIAppServiceADOClassName(string tableName)
		{
			return "I" + GetClassName(tableName) + "ServiceAppADO";
		}
		/// <summary>
		/// 得到IAppServiceADO层名字。(例：IAddressServiceAppADO)
		/// </summary>
		/// <param name="schemaObject"></param>
		/// <returns></returns>
		public string GetIAppServiceADOClassName(SchemaObjectBase schemaObject)
		{
			return "I" + GetClassName(schemaObject.Name) + "ServiceAppADO";
		}
		
		/// <summary>
		/// 得到AppService层名字。(例：AddressServiceApp)
		/// </summary>
		/// <param name="tableName"></param>
		/// <returns></returns>
		public string GetAppServiceClassName(string tableName)
		{
			return "" + GetClassName(tableName) + "ServiceApp";
		}
		/// <summary>
		/// 得到AppService层名字。(例：AddressServiceApp)
		/// </summary>
		/// <param name="schemaObject"></param>
		/// <returns></returns>
		public string GetAppServiceClassName(SchemaObjectBase schemaObject)
		{
			return "" + GetClassName(schemaObject.Name) + "ServiceApp";
		}
		
		/// <summary>
		/// 得到AppServiceADO层名字。(例：AddressServiceAppADO)
		/// </summary>
		/// <param name="tableName"></param>
		/// <returns></returns>
		public string GetAppServiceADOClassName(string tableName)
		{
			return "" + GetClassName(tableName) + "ServiceAppADO";
		}
		/// <summary>
		/// 得到AppServiceADO层名字。(例：AddressServiceAppADO)
		/// </summary>
		/// <param name="schemaObject"></param>
		/// <returns></returns>
		public string GetAppServiceADOClassName(SchemaObjectBase schemaObject)
		{
			return "" + GetClassName(schemaObject.Name) + "ServiceAppADO";
		}
		
		/// <summary>
		/// 得到Enity与Dto的关系映射代码。
		/// </summary>
		/// <param name="tableName"></param>
		/// <returns></returns>
		public string GetMapperName(string tableName)
		{
			string result = "cfg.CreateMap<" + GetEntityClassName(tableName) + "," + GetDTOClassName(tableName) + ">();\r\n";
			result += "cfg.CreateMap<" + GetDTOClassName(tableName) + "," + GetEntityClassName(tableName) + ">();";
			return result;
		}
		/// <summary>
		/// 得到Enity与Dto的关系映射代码。
		/// </summary>
		/// <param name="schemaObject"></param>
		/// <returns></returns>
		public string GetMapperName(SchemaObjectBase schemaObject)
		{
			string result = "cfg.CreateMap<" + GetEntityClassName(schemaObject.Name) + "," + GetDTOClassName(schemaObject.Name) + ">();\r\n";
			result += "cfg.CreateMap<" + GetDTOClassName(schemaObject.Name) + "," + GetEntityClassName(schemaObject.Name) + ">();";
			return result;
		}
		
		/// <summary>
		/// 得到仓储类的DI代码
		/// </summary>
		/// <param name="tableName"></param>
		/// <returns></returns>
		public string GetRepositoryDI(string tableName)
		{
			string result = "services.AddScoped<" + GetIRepositoriesClassName(tableName) + "," + GetRepositoryClassName(tableName) + ">();\r\n";
			return result;
		}
		/// <summary>
		/// 得到仓储类的DI代码
		/// </summary>
		/// <param name="schemaObject"></param>
		/// <returns></returns>
		public string GetRepositoryDI(SchemaObjectBase schemaObject)
		{
			string result = "services.AddScoped<" + GetIRepositoriesClassName(schemaObject.Name) + "," + GetRepositoryClassName(schemaObject.Name) + ">();\r\n";
			return result;
		}
		
		/// <summary>
		/// 得到ADO仓储类的DI代码
		/// </summary>
		/// <param name="tableName"></param>
		/// <returns></returns>
		public string GetRepositoryADODI(string tableName)
		{
			string result = "services.AddScoped<" + GetIRepositoriesADOClassName(tableName) + "," + GetRepositoryADOClassName(tableName) + ">();\r\n";
			return result;
		}
		/// <summary>
		/// 得到ADO仓储类的DI代码
		/// </summary>
		/// <param name="schemaObject"></param>
		/// <returns></returns>
		public string GetRepositoryADODI(SchemaObjectBase schemaObject)
		{
			string result = "services.AddScoped<" + GetIRepositoriesADOClassName(schemaObject.Name) + "," + GetRepositoryADOClassName(schemaObject.Name) + ">();\r\n";
			return result;
		}
		
		/// <summary>
		/// 得到应用层服务类的DI代码
		/// </summary>
		/// <param name="tableName"></param>
		/// <returns></returns>
		public string GetAppServiceDI(string tableName)
		{
			string result = "services.AddScoped<" + GetIAppServiceClassName(tableName) + "," + GetAppServiceClassName(tableName) + ">();\r\n";
			return result;
		}
		/// <summary>
		/// 得到应用层服务类的DI代码
		/// </summary>
		/// <param name="schemaObject"></param>
		/// <returns></returns>
		public string GetAppServiceDI(SchemaObjectBase schemaObject)
		{
			string result = "services.AddScoped<" + GetIAppServiceClassName(schemaObject.Name) + "," + GetAppServiceClassName(schemaObject.Name) + ">();\r\n";
			return result;
		}
		
		/// <summary>
		/// 得到应用层服务类的DI代码(ADO)
		/// </summary>
		/// <param name="tableName"></param>
		/// <returns></returns>
		public string GetAppServiceADODI(string tableName)
		{
			string result = "services.AddScoped<" + GetIAppServiceADOClassName(tableName) + "," + GetAppServiceADOClassName(tableName) + ">();\r\n";
			return result;
		}
		/// <summary>
		/// 得到应用层服务类的DI代码(ADO)
		/// </summary>
		/// <param name="schemaObject"></param>
		/// <returns></returns>
		public string GetAppServiceADODI(SchemaObjectBase schemaObject)
		{
			string result = "services.AddScoped<" + GetIAppServiceADOClassName(schemaObject.Name) + "," + GetAppServiceADOClassName(schemaObject.Name) + ">();\r\n";
			return result;
		}
		#endregion
		
		#endregion
		
		#region GetType
		
		/// <summary>
		/// 转换数据库中的类型为C#中DataReader对应方法
		/// </summary>
		/// <param name="field">Column or parameter</param>
		/// <returns>The C# (rough) equivalent of the field's data type</returns>
		public string GetDataReaderMethod(DataObjectBase field)
		{
			string result = "";
			switch (field.NativeType.ToLower())
			{
				case "bit":
					{
						result = "GetBoolean";
						break;
					}
				case "date":
				case "datetime":
				case "smalldatetime":
					{
						result = "GetNullableDateTime";
						break;
					}
				case "decimal":
				case "smallmoney":
				case "money":
					{
						result = "GetDecimal";
						break;
					}
				case "float":
					{
						result = "GetDouble";
						break;
					}
				case "real":
					{
						result = "GetFloat";
						break;
					}
				case "smallint":
					{
						result = "GetInt16";
						break;
					}
				case "int":
					{
						result = "GetInt32";
						break;
					}
				case "bigint":
					{
						result = "GetInt64";
						break;
					}
				case "char":
				case "varchar":
				case "nchar":
				case "nvarchar":
				case "ntext":
				case "text":
					{
						result = "GetString";
						break;
					}
				case "tinyint":
					{
						result = "GetByte";
						break;
					}
				case "uniqueidentifier":
					{
						result = "GetGuid";
						break;
					}
				case "variant":
					{
						result = "GetValue";
						break;
					}
				default: 
					{
						result = "GetString";
						break;
					}
			}
			return result;
		}
		
		/// <summary>
		/// 转换数据库中的类型为C#类型
		/// </summary>
		/// <param name="field">Column or parameter</param>
		/// <returns>The C# (rough) equivalent of the field's data type</returns>
		public string GetCSType(DataObjectBase field)
		{
			if (field.NativeType.ToLower() == "real")
				return "System.Single";
			else if(field.DataType == DbType.DateTime)
				return "DateTime?";
			else if(field.DataType == DbType.Date)
				return "DateTime?";
			else
				return field.SystemType.ToString();
		}
		
		/// <summary>
		/// 转换数据库中的类型为C#中DbType枚举类型
		/// </summary>
		/// <param name="field">Column or parameter</param>
		/// <returns>The C# (rough) equivalent of the field's data type</returns>
		public string GetEnumDbType(DataObjectBase field)
		{
			string strDbType = "";
			switch (field.NativeType.ToLower())
			{
				case "bigint":
					{
						strDbType = "DbType.Int64";
						break;
					}
				case "binary":
					{
						strDbType = "DbType.Binary";
						break;
					}
				case "bit":
					{
						strDbType = "DbType.Boolean";
						break;
					}
				case "char":
					{
						strDbType = "DbType.AnsiStringFixedLength";
						break;
					}
				case "datetime":
					{
						strDbType = "DbType.DateTime";
						break;
					}
				case "decimal":
					{
						strDbType = "DbType.Decimal";
						break;
					}
				case "float":
					{
						strDbType = "DbType.Double";
						break;
					}
				/*case "image":
					{
						strDbType = "DbType.Object";
						break;
					}*/
				case "int":
					{
						strDbType = "DbType.Int32";
						break;
					}
				case "money":
					{
						strDbType = "DbType.Currency";
						break;
					}
				case "nchar":
					{
						strDbType = "DbType.String";
						break;
					}
				case "ntext":
					{
						strDbType = "DbType.String";
						break;
					}
				case "nvarchar":
					{
						strDbType = "DbType.String";
						break;
					}
				case "real":
					{
						strDbType = "DbType.Single";
						break;
					}
				case "smalldatetime":
					{
						strDbType = "DbType.DateTime";
						break;
					}
				case "smallint":
					{
						strDbType = "DbType.Int16";
						break;
					}
				case "smallmoney":
					{
						strDbType = "DbType.Decimal";
						break;
					}
				case "text":
					{
						strDbType = "DbType.String";
						break;
					}
				/*case "timestamp":
					{
						strDbType = "SqlDbType.Timestamp";
						break;
					}*/
				case "tinyint":
					{
						strDbType = "DbType.Byte";
						break;
					}
				/*case "udt":
					{
						strDbType = "SqlDbType.Udt";
						break;
					}*/
				case "uniqueidentifier":
					{
						strDbType = "DbType.Guid";
						break;
					}
				case "varbinary":
					{
						strDbType = "DbType.Binary";
						break;
					}
				case "varchar":
					{
						strDbType = "DbType.AnsiString";
						break;
					}
				case "variant":
					{
						strDbType = "DbType.Object";
						break;
					}
				default: 
					{
						strDbType = "DbType.String";
						break;
					}
			}
			return strDbType;
		}
		
		#region 转换数据库中的类型为C#中SqlDbType枚举类型
		/// <summary>
		/// 转换数据库中的类型为C#中SqlDbType枚举类型
		/// </summary>
		/// <param name="field">Column or parameter</param>
		/// <returns>The C# (rough) equivalent of the field's data type</returns>
		public string GetEnumSqlDbType(DataObjectBase field)
		{
			string strSqlDbType = "";
			switch (field.NativeType.ToLower())
			{
				case "bigint":
					{
						strSqlDbType = "SqlDbType.BigInt";
						break;
					}
				case "binary":
					{
						strSqlDbType = "SqlDbType.Binary";
						break;
					}
				case "bit":
					{
						strSqlDbType = "SqlDbType.Bit";
						break;
					}
				case "char":
					{
						strSqlDbType = "SqlDbType.Char";
						break;
					}
				case "datetime":
					{
						strSqlDbType = "SqlDbType.DateTime";
						break;
					}
				case "decimal":
					{
						strSqlDbType = "SqlDbType.Decimal";
						break;
					}
				case "float":
					{
						strSqlDbType = "SqlDbType.Float";
						break;
					}
				case "image":
					{
						strSqlDbType = "SqlDbType.Image";
						break;
					}
				case "int":
					{
						strSqlDbType = "SqlDbType.Int";
						break;
					}
				case "money":
					{
						strSqlDbType = "SqlDbType.Money";
						break;
					}
				case "nchar":
					{
						strSqlDbType = "SqlDbType.NChar";
						break;
					}
				case "ntext":
					{
						strSqlDbType = "SqlDbType.NText";
						break;
					}
				case "nvarchar":
					{
						strSqlDbType = "SqlDbType.NVarChar";
						break;
					}
				case "real":
					{
						strSqlDbType = "SqlDbType.Real";
						break;
					}
				case "smalldatetime":
					{
						strSqlDbType = "SqlDbType.SmallDateTime";
						break;
					}
				case "smallint":
					{
						strSqlDbType = "SqlDbType.SmallInt";
						break;
					}
				case "smallmoney":
					{
						strSqlDbType = "SqlDbType.SmallMoney";
						break;
					}
				case "text":
					{
						strSqlDbType = "SqlDbType.Text";
						break;
					}
				case "timestamp":
					{
						strSqlDbType = "SqlDbType.Timestamp";
						break;
					}
				case "tinyint":
					{
						strSqlDbType = "SqlDbType.TinyInt";
						break;
					}
				case "udt":
					{
						strSqlDbType = "SqlDbType.Udt";
						break;
					}
				case "uniqueidentifier":
					{
						strSqlDbType = "SqlDbType.UniqueIdentifier";
						break;
					}
				case "varbinary":
					{
						strSqlDbType = "SqlDbType.VarBinary";
						break;
					}
				case "varchar":
					{
						strSqlDbType = "SqlDbType.VarChar";
						break;
					}
				case "variant":
					{
						strSqlDbType = "SqlDbType.Variant";
						break;
					}
				default: 
					{
						strSqlDbType = "SqlDbType.VarChar";
						break;
					}
			}
			return strSqlDbType;
		}
		/// <summary>
		/// Get the Sql Data type of a column
		/// </summary>
		/// <param name="column">Column for which to get the type</param>
		/// <returns>String representing the SQL data type</returns>
		public string GetSqlDbType(DataObjectBase column)
		{
			switch (column.NativeType)
			{
				case "bigint": return "BigInt";
				case "binary": return "Binary";
				case "bit": return "Bit";
				case "char": return "Char";
				case "datetime": return "DateTime";
				case "decimal": return "Decimal";
				case "float": return "Float";
				case "image": return "Image";
				case "int": return "Int";
				case "money": return "Money";
				case "nchar": return "NChar";
				case "ntext": return "NText";
				case "numeric": return "Decimal";
				case "nvarchar": return "NVarChar";
				case "real": return "Real";
				case "smalldatetime": return "SmallDateTime";
				case "smallint": return "SmallInt";
				case "smallmoney": return "SmallMoney";
				case "sql_variant": return "Variant";
				case "sysname": return "NChar";
				case "text": return "Text";
				case "timestamp": return "Timestamp";
				case "tinyint": return "TinyInt";
				case "uniqueidentifier": return "UniqueIdentifier";
				case "varbinary": return "VarBinary";
				case "varchar": return "VarChar";
				default: return "__UNKNOWN__" + column.NativeType;
			}
		}
		#endregion
		
		#region GetNullableType
		/// <summary>
		/// Convert db types to NullableTypes
		/// </summary>
		/// <param name="dataType">Column or parameter data type</param>
		/// <returns>The NullableType (rough) equivalent of the field's data type</returns>
		public string GetNullableType(DbType dataType)
		{
			switch (dataType)
			{
				case DbType.AnsiString: return "NullableString";
				case DbType.AnsiStringFixedLength: return "NullableString";
				case DbType.Binary: return "NullableByte[]";
				case DbType.Boolean: return "NullableBoolean";
				case DbType.Byte: return "NullableByte";
				case DbType.Currency: return "NullableDecimal";
				case DbType.Date: return "NullableDateTime";
				case DbType.DateTime: return "NullableDateTime";
				case DbType.Decimal: return "NullableDecimal";
				case DbType.Double: return "NullableDouble";
				case DbType.Guid: return "NullableGuid";
				case DbType.Int16: return "NullableInt16";
				case DbType.Int32: return "NullableInt32";
				case DbType.Int64: return "NullableInt64";
				case DbType.Object: return "object";
				case DbType.Single: return "NullableSingle";
				case DbType.String: return "NullableString";
				case DbType.StringFixedLength: return "NullableString";
				case DbType.Time: return "NullableDateTime";
				case DbType.VarNumeric: return "NullableDecimal";
				//the following won't be used
				//		case DbType.SByte: return "NullableSByte";
				//		case DbType.UInt16: return "NullableUShort";
				//		case DbType.UInt32: return "NullableUInt";
				//		case DbType.UInt64: return "NullableULong";
				default: return "object";
			}
		}
		/// <summary>
		/// Convert db types to NullableTypes
		/// </summary>
		/// <param name="field">Column or parameter</param>
		/// <returns>The NullableType (rough) equivalent of the field's data type</returns>
		public string GetNullableType(DataObjectBase field)
		{
			return GetNullableType(field.DataType);
		}
		/// <summary>
		/// Convert db types to NullableTypes
		/// </summary>
		/// <param name="dataType">Column or parameter data type, as a string</param>
		/// <returns>The NullableType (rough) equivalent of the field's data type</returns>
		public string GetNullableType(string dataType)
		{
			try 
			{ 
				return GetNullableType((DbType)Enum.Parse(typeof(DbType), dataType)); 
			}
			catch 
			{ 
				return "object"; 
			}
		}
		#endregion
	
		/// <summary>
		/// 转换数据库中的类型为C#类型，带默认值。(日期类型默认值为"1900-1-1 0:0:0:0")
		/// </summary>
		/// <param name="column">Column or parameter</param>
		/// <returns>The C# (rough) equivalent of the field's data type</returns>
		public string GetCSDefaultByType(DataObjectBase column)
		{
			if (column.NativeType.ToLower() == "real")
				return "0.0F";
			else
			{
				DbType dataType = column.DataType;
				switch (dataType)
				{
					case DbType.AnsiString:
						return "string.Empty";
					case DbType.AnsiStringFixedLength:
						return "string.Empty";	
					case DbType.String:
						return "string.Empty";
					case DbType.StringFixedLength:
						return "string.Empty";
	
					case DbType.Boolean:
						return "false";
						
					case DbType.Guid:
						return "Guid.Empty";
	
					//Answer modified was just 0
					case DbType.Binary:
						return "new byte[] {}";
	
					//Answer modified was just 0
					case DbType.Byte:
						return "(byte)0";
	
					case DbType.Currency:
						return "0";
	
					case DbType.Date:
						return "DateTime.MaxValue";
						//return "new DateTime(1900, 1, 1)";
	
					case DbType.DateTime:
						return "DateTime.MaxValue";
						//return "new DateTime(1900,1,1,0,0,0,0)";
	
					case DbType.Decimal:
						return "0.0m";
	
					case DbType.Double:
						return "0.0f";
	
					case DbType.Int16:
						return "0";
	
					case DbType.Int32:
						return "0";
	
					case DbType.Int64:
						return "0";
	
					case DbType.Object:
						return "null";
	
					case DbType.Single:
						return "0F";
	
					case DbType.Time: return "DateTime.MaxValue";
					case DbType.VarNumeric: return "0";
					//the following won't be used
					case DbType.SByte: return "0";
					case DbType.UInt16: return "0";
					case DbType.UInt32: return "0";
					case DbType.UInt64: return "0";
					default: return "null";
				}
			}
		}
		
		/// <summary>
		/// 通过指定值转换数据库中的类型为C#类型。
		/// </summary>
		/// <param name="column">Data type for which to get the default value.</param>
		/// <param name="stringValue">a mock string value.</param>
		/// <param name="bValue">a mock boolean value.</param>
		/// <param name="guidValue">a mock Guid value.</param>
		/// <param name="numValue">a mock numeric value.</param>
		/// <param name="dtValue">a mock datetime value.</param>
		/// <returns>A string representation of the default value.</returns>
		public string GetCSMockValueByType(DataObjectBase column, string stringValue, bool bValue, Guid guidValue, int numValue, DateTime dtValue)
		{
			if (column.NativeType.ToLower() == "real")
				return numValue.ToString() + "F";
			else
			{
				switch (column.DataType)
				{
					case DbType.AnsiString:
						return "\"" + stringValue + "\"";
	
					case DbType.AnsiStringFixedLength:
						return "\"" + stringValue + "\"";
	
					case DbType.String:
						return "\"" + stringValue + "\"";
	
					case DbType.Boolean:
						return bValue.ToString().ToLower();
	
					case DbType.StringFixedLength:
						return "\"" + stringValue + "\"";
	
					case DbType.Guid:
						return "new Guid(\"" + guidValue.ToString() + "\")";
	
	
					//Answer modified was just 0
					case DbType.Binary:
						return "new byte[] {" + numValue.ToString() + "}";
	
					//Answer modified was just 0
					case DbType.Byte:
						return "(byte)" + numValue.ToString() + "";
					//return "{ 0 }";
	
					case DbType.Currency:
						return numValue.ToString();
	
					case DbType.Date:
						return string.Format("new DateTime({0}, {1}, {2}, 0, 0, 0, 0)", dtValue.Date.Year, dtValue.Date.Month, dtValue.Date.Day);
	
					case DbType.DateTime:
						return string.Format("new DateTime({0}, {1}, {2}, {3}, {4}, {5}, {6})", dtValue.Year, dtValue.Month, dtValue.Day, dtValue.Hour, dtValue.Minute, dtValue.Second, dtValue.Millisecond);
	
					case DbType.Decimal:
						return numValue.ToString() + "m";
					//return "0M";
					//return "0.0M";
	
					case DbType.Double:
						return numValue.ToString() + ".0f";
	
					case DbType.Int16:
						return "(short)" + numValue.ToString();
	
					case DbType.Int32:
						return "(int)" + numValue.ToString();
	
					case DbType.Int64:
						return "(long)" + numValue.ToString();
	
					case DbType.Object:
						return "null";
	
					case DbType.Single:
						return numValue.ToString() + "F";
	
					//case DbType.Time: return "DateTime.MaxValue";
					case DbType.Time:
						return string.Format("new DateTime({0}, {1}, {2}, {3}, {4}, {5}, {6})", dtValue.Year, dtValue.Month, dtValue.Day, dtValue.Hour, dtValue.Minute, dtValue.Second, dtValue.Millisecond);
	
					case DbType.VarNumeric:
						return numValue.ToString();
					//the following won't be used
					//		case DbType.SByte: return "0";
					//		case DbType.UInt16: return "0";
					//		case DbType.UInt32: return "0";
					//		case DbType.UInt64: return "0";
					default: return "null";
				}
			}
		}

		/// <summary>
		/// 得到数据库中类型的大小。
		/// </summary>
		/// <param name="column">Column or parameter</param>
		/// <returns>The C# (rough) equivalent of the field's data type</returns>
		public int GetDataTypeSize(DataObjectBase column)
		{
			int size = 1;
			switch (column.DataType)
			{
				case DbType.AnsiString:
				case DbType.AnsiStringFixedLength:
				case DbType.String:
				case DbType.StringFixedLength:
					{
						if (column.NativeType != "text" && column.NativeType != "ntext")
						{
							if (column.Size > 0)
							{
								size = column.Size;
							}
						}
						else
						{
							size = 3888;
						}
						break;
					}
			}
			return size;
		}
		
		#region 生成随机数
		/// <summary>
		/// 在给定数值之间生成随机数
		/// </summary>
		/// <param name="min">lowest bound</param>
		/// <param name="max">highest bound</param>
		public int RandomNumber(int min, int max)
		{
			Random random = new Random();
			return random.Next(min, max);
		}
		/// <summary>
		/// 生成随机字符串
		/// </summary>
		/// <param name="column"></param>
		/// <param name="lowerCase">If true, generate lowercase string</param>
		/// <returns>Random string</returns>
		public string RandomString(ColumnSchema column, bool lowerCase)
		{
			//Debugger.Break();
			int size = 2; // default size
	
			// calculate maximum size of the field
			switch (column.DataType)
			{
				case DbType.AnsiString:
				case DbType.AnsiStringFixedLength:
				case DbType.String:
				case DbType.StringFixedLength:
					{
						if (column.NativeType != "text" && column.NativeType != "ntext")
						{
							if (column.Size > 0)
							{
								size = column.Size;
							}
						}
						break;
					}
			}
	
			return RandomString((size / 2) - 1, lowerCase);
		}
		/// <summary>
		/// 生成指定长度的随机字符串
		/// </summary>
		/// <param name="size">Size of the string</param>
		/// <param name="lowerCase">If true, generate lowercase string</param>
		/// <returns>Random string</returns>
		/// <remarks>Mahesh Chand  - http://www.c-sharpcorner.com/Code/2004/Oct/RandomNumber.asp</remarks>
		public string RandomString(int size, bool lowerCase)
		{
			StringBuilder builder = new StringBuilder();
			Random random = new Random(size);
			char ch;
			for (int i = 0; i < size; i++)
			{
				ch = Convert.ToChar(Convert.ToInt32(26 * random.NextDouble() + 65));
				builder.Append(ch);
			}
			if (lowerCase)
				return builder.ToString().ToLower();
			return builder.ToString();
		}
		#endregion
		
		#endregion
		
		#region 得到属性名的长度
		/// <summary>
		/// 得到属性名的长度
		/// </summary>
		public int GetPropertyNameLength(ColumnSchema column)
		{
			return (GetPropertyName(column)).Length;
		}
		/// <summary>
		/// 得到属性名的长度
		/// </summary>
		public int GetPropertyNameLength(ViewColumnSchema column)
		{
			return (GetPropertyName(column)).Length;
		}
		/// <summary>
		/// 得到属性名的最大长度
		/// </summary>
		public int GetPropertyNameMaxLength(TableSchema table)
		{
			int ret = 0;
			foreach(ColumnSchema column in table.Columns)
			{
				ret = ret < GetPropertyNameLength(column)?GetPropertyNameLength(column):ret;
			}
			return ret;
		}
		/// <summary>
		/// 得到属性名的最大长度
		/// </summary>
		public int GetPropertyNameMaxLength(ViewSchema view)
		{
			int ret = 0;
			foreach(ViewColumnSchema column in view.Columns)
			{
				ret = ret < GetPropertyNameLength(column)?GetPropertyNameLength(column):ret;
			}
			return ret;
		}
		#endregion
		
		#region 得到成员变量名。样式：_adminID
		/// <summary>
		/// 得到成员变量名。样式：_adminID
		/// </summary>
		/// <param name="column">The ColumnSchema with the name to be cleaned</param>
		/// <returns>the cleaned, camelcased name with a _ prefix</returns>
		public string GetMemberVariableName(ColumnSchema column)
		{
			return "_" + GetCleanParName(column.Name);
		}
		/// <summary>
		/// 得到成员变量名。样式：_adminID
		/// </summary>
		/// <param name="schemaObject"></param>
		/// <returns>the cleaned, camelcased name with a _ prefix</returns>
		public string GetMemberVariableName(SchemaObjectBase schemaObject)
		{
			return "_" + GetCleanParName(schemaObject.Name);
		}
		/// <summary>
		/// 得到成员变量名。样式：_adminID
		/// </summary>
		/// <param name="name">name to be cleaned</param>
		/// <returns>the cleaned, camelcased name with a _ prefix</returns>
		public string GetMemberVariableName(string name)
		{
			return "_" + GetCleanParName(name);
		}
		#endregion
		
		#region 得到成员变量声明,样式：protected string _id;
		/// <summary>
		/// 得到成员变量声明,默认为"protected"
		/// 样式：protected string _id;
		/// </summary>
		public string GetMemberVariableDeclarationStatement(ColumnSchema column)
		{
			return GetMemberVariableDeclarationStatement("protected", column);
		}
		/// <summary>
		/// 得到成员变量声明
		/// 样式：protected string _id;
		/// </summary>
		public string GetMemberVariableDeclarationStatement(string protectionLevel, ColumnSchema column)
		{
			string statement = protectionLevel + " ";
			statement += GetCSType(column) + " " + GetMemberVariableName(column);
	
			string defaultValue = GetCSDefaultByType(column);
			if (defaultValue != "")
			{
				statement += " = " + defaultValue;
			}
	
			statement += ";";
	
			return statement;
		}
		/// <summary>
		/// 得到成员变量声明
		/// 样式：protected string m_id;
		/// </summary>
		public string GetMemberVariableDeclarationStatement(string protectionLevel, ColumnSchema column,string prefixName)
		{
			string statement = protectionLevel + " ";
			statement += GetCSType(column) + " " + prefixName + GetMemberVariableName(column);
			statement += ";";
	
			return statement;
		}
		/// <summary>
		/// 得到成员变量声明,默认为"protected"
		/// 样式：protected string _id;
		/// </summary>
		public string GetMemberVariableDeclarationStatement(ViewColumnSchema column)
		{
			return GetMemberVariableDeclarationStatement("protected", column);
		}
		/// <summary>
		/// 得到成员变量声明
		/// 样式：protected string _id;
		/// </summary>
		public string GetMemberVariableDeclarationStatement(string protectionLevel, ViewColumnSchema column)
		{
			string statement = protectionLevel + " ";
			statement += GetCSType(column) + " " + GetMemberVariableName(column);
	
			//string defaultValue = GetCSDefaultByType(column);
			//if (defaultValue != "")
			//{
			//	statement += " = " + defaultValue;
			//}
	
			statement += ";";
	
			return statement;
		}
		/// <summary>
		/// 得到成员变量声明
		/// 样式：protected string m_id;
		/// </summary>
		public string GetMemberVariableDeclarationStatement(string protectionLevel, ViewColumnSchema column,string prefixName)
		{
			string statement = protectionLevel + " ";
			statement += GetCSType(column) + " " + prefixName + GetMemberVariableName(column);
			statement += ";";
	
			return statement;
		}
		#endregion
		
		#region 得到所有主键的成员变量名声明。样式：private System.Int32 _adminID;
		/// <summary>
		/// 得到所有主键的成员变量名声明。样式：private System.Int32 _adminID;
		/// </summary>
		public string GetPrimaryKeySentences(TableSchema table)
		{
			string s = "";
			if(table.HasPrimaryKey)
			//if (table.PrimaryKey != null)
			{
				for(int i = 0; i < table.PrimaryKey.MemberColumns.Count; i++)
				{
					s = s + "private " + GetCSType(table.PrimaryKey.MemberColumns[i]) + " " + GetMemberVariableName(table.PrimaryKey.MemberColumns[i]) + ";" + Environment.NewLine + "\t\t";
				}
			}
			else
			{
				//throw new ApplicationException("这个方法需要最少一个主键才能工作。");
			}
			return s;
		}
		/// <summary>
		/// 得到所有主键的成员变量名声明。样式：private System.Int32 m_adminID;
		/// </summary>
		public string GetPrimaryKeySentences(TableSchema table,string prefixName)
		{
			string s = "";
			if(table.HasPrimaryKey)
			//if (table.PrimaryKey != null)
			{
				for(int i = 0; i < table.PrimaryKey.MemberColumns.Count; i++)
				{
					s = s + "private " + GetCSType(table.PrimaryKey.MemberColumns[i]) + " " + prefixName + GetMemberVariableName(table.PrimaryKey.MemberColumns[i]) + ";" + Environment.NewLine + "\t\t";
				}
			}
			else
			{
				//throw new ApplicationException("这个方法需要最少一个主键才能工作。");
			}
			return s;
		}
		#endregion
		
		
		/// <summary>
		/// 得到第一个主键的数据类型，没有主键则返回第一列的数据类型
		/// </summary>
		public string GetFirstPrimaryKeyType(TableSchema table)
		{
			if (table.HasPrimaryKey)
			{
				return GetCSType(table.PrimaryKey.MemberColumns[0]);
			}
			else
			{
				return GetCSType(table.Columns[0]);
			}
		}
		/// <summary>
		/// 得到第一个主键的名称，没有主键则返回第一列的名称
		/// </summary>
		public string GetFirstPrimaryKey(TableSchema table)
		{
			string s = "";
			if (table.HasPrimaryKey)
			{
				s = table.PrimaryKey.MemberColumns[0].Name;
			}
			else
			{
				s = table.Columns[0].Name;
			}
			return s;
		}
		/// <summary>
		/// 通过主键生成方法所需要的参数声明
		/// 样式：string id
		/// </summary>
		public string GenPrimaryKeyParam(TableSchema table)
		{
			string s = "";
			if (table.HasPrimaryKey)
			{
				for(int i = 0; i < table.PrimaryKey.MemberColumns.Count; i++)
				{
					s = s + GetCSType(table.PrimaryKey.MemberColumns[i]) + " " + GetCamelCaseName(GetSafeName(table.PrimaryKey.MemberColumns[i])) + ", ";
				}
			}
			else
			{
				//throw new ApplicationException("This template will only work on tables with a primary key.");
			}
			s = s.Remove(s.Length - 2, 2);
			return s;
		}
		/// <summary>
		/// 通过主键生成方法所需要的参数声明
		/// 样式：string id
		/// </summary>
		public string GenPrimaryKeyEF(TableSchema table)
		{
			string s = "";
			if (table.HasPrimaryKey)
			{
				for(int i = 0; i < table.PrimaryKey.MemberColumns.Count; i++)
				{
					s = s + "e." + GetPropertyName(table.PrimaryKey.MemberColumns[i]) + ", ";
				}
				s = s.Remove(s.Length - 2, 2);
			}
			return s;
		}
		
		/// <summary>
		/// 为带主键的构造函数赋值
		/// 样式：_id = id;
		/// </summary>
		public string GenPrimaryKeyParamValue(TableSchema table)
		{
			string s = "";
			if (table.HasPrimaryKey)
			{
				for(int i = 0; i < table.PrimaryKey.MemberColumns.Count; i++)
				{
					s = s + GetMemberVariableName(table.PrimaryKey.MemberColumns[i]) + " = " + GetCamelCaseName(GetSafeName(table.PrimaryKey.MemberColumns[i])) + ";\n\t\t\t";
				}
			}
			else
			{
				//throw new ApplicationException("This template will only work on tables with a primary key.");
			}
			s = s.Remove(s.Length - 2, 2);
			return s;
		}
		
		/// <summary>
		/// 把数据表中的所有列作为构造函数的方法参数进行声明
		/// 样式：System.Int32 id,System.String name
		/// </summary>
		public string GetConstructorParameters( TableSchema table )
		{
			string ret = "";
			foreach(ColumnSchema column in table.Columns)
			{
				ret += GetCSType(column) + " " + GetCamelCaseName(GetPropertyName(column)) + ",\n\t\t\t";
			}
			return ret.Substring(0, ret.Length - 5);
		}
		/// <summary>
		/// 把数据表中的所有列作为构造函数的方法参数进行声明
		/// 样式：System.Int32 id,System.String name
		/// </summary>
		public string GetConstructorParameters( ViewSchema view )
		{
			string ret = "";
			foreach(ViewColumnSchema column in view.Columns)
			{
				ret += GetCSType(column) + " " + GetCamelCaseName(GetPropertyName(column)) + ",\n\t\t\t";
			}
			return ret.Substring(0, ret.Length - 5);
		}
		
		/// <summary>
		/// 为构造函数的参数赋值
		/// 样式：_id = id;
		/// </summary>
		public string GetAssignValue( TableSchema table )
		{
			string ret = "";
			foreach(ColumnSchema column in table.Columns)
			{
				ret += GetMemberVariableName(column) + (new String(' ', GetPropertyNameMaxLength(table) - GetPropertyNameLength(column))) + " = " + GetCamelCaseName(GetPropertyName(column)) + ";\n\t\t\t";
			}
			return ret;
		}
		/// <summary>
		/// 为构造函数的参数赋值
		/// 样式：_id = id;
		/// </summary>
		public string GetAssignValue( ViewSchema view )
		{
			string ret = "";
			foreach(ViewColumnSchema column in view.Columns)
			{
				ret += GetMemberVariableName(column) + (new String(' ', GetPropertyNameMaxLength(view) - GetPropertyNameLength(column))) + " = " + GetCamelCaseName(GetPropertyName(column)) + ";\n\t\t\t";
			}
			return ret;
		}
		
		/// <summary>
		/// 检查字段是否为标识符
		/// </summary>
		public bool IsIdentity(ColumnSchema column)
		{
			return (bool)column.ExtendedProperties["CS_IsIdentity"].Value;
		}
		
		/// <summary>
		/// 检查字段是否有默认值
		/// </summary>
		public bool IsDefault(ColumnSchema column)
		{
			if ((string)column.ExtendedProperties["CS_Default"].Value == "")
			{
				return false;
			}
			return true;
		}
		
		/// <summary>
		/// 根据主键类型生成对应的检查代码
		/// </summary>
		public string GetPrimaryKeyCheckCode(TableSchema schemaObject,string entityName)
		{
			string result = "";
			if (schemaObject.HasPrimaryKey && schemaObject.PrimaryKey.MemberColumns.Count == 1 && !IsIdentity(schemaObject.PrimaryKey.MemberColumns[0]))
			{
				switch (schemaObject.PrimaryKey.MemberColumns[0].NativeType.ToLower())
				{
					case "bigint":
					case "int":
					case "smallint":
						{
							result += "if(" + entityName + "." + schemaObject.PrimaryKey.MemberColumns[0].Name + " <= 0) " + entityName + "." + schemaObject.PrimaryKey.MemberColumns[0].Name + "=GetNewID();";
							break;
						}
					case "uniqueidentifier":
						{
							result += "if(" + entityName + "." + schemaObject.PrimaryKey.MemberColumns[0].Name + " == Guid.Empty) " + entityName + "." + schemaObject.PrimaryKey.MemberColumns[0].Name + "=Guid.NewGuid();";
							break;
						}
				}
			}
			return result;
		}
		/// <summary>
		/// 根据主键类型生成对应的检查代码
		/// </summary>
		public string GetPrimaryKeyCheckCodeEF(TableSchema schemaObject,string entityName)
		{
			string result = "";
			if (schemaObject.HasPrimaryKey && schemaObject.PrimaryKey.MemberColumns.Count == 1 && !IsIdentity(schemaObject.PrimaryKey.MemberColumns[0]))
			{
				switch (schemaObject.PrimaryKey.MemberColumns[0].NativeType.ToLower())
				{
					case "bigint":
					case "int":
					case "smallint":
						{
							result += "if(" + entityName + "." + schemaObject.PrimaryKey.MemberColumns[0].Name + " <= 0) " + entityName + "." + schemaObject.PrimaryKey.MemberColumns[0].Name + "=GetMax<int>(p=>p."+schemaObject.PrimaryKey.MemberColumns[0].Name+")+1;";
							break;
						}
					case "uniqueidentifier":
						{
							result += "if(" + entityName + "." + schemaObject.PrimaryKey.MemberColumns[0].Name + " == Guid.Empty) " + entityName + "." + schemaObject.PrimaryKey.MemberColumns[0].Name + "=Guid.NewGuid();";
							break;
						}
				}
			}
			return result;
		}
	}
}