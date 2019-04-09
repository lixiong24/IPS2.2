/*
 * $Id: CommonSqlCode.cs,v 1.47 2005/07/22 22:13:38 jroland Exp $
 * Last modified by $Author: jroland $
 * Last modified at $Date: 2005/07/22 22:13:38 $
 * $Revision: 1.47 $
 */
 
/*
	Common SQL related code generation methods
	Created: 12/30/03 by Oskar Austegard
	
	9/17/2004 - Dave Kekish 
	Changed sql to c# conversion for decimal type from Single to a Decimal.
	You cannot implicitly convert a objet to a Single.  
	see http://www.gotdotnet.com/Community/MessageBoard/Thread.aspx?id=263704
	
	01/26/05 - ab
	added isIntXX(), a convenience method	
*/
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

namespace MoM.Templates

{
	/// <summary>
	/// Common code-behind class used to simplify SQL Server based CodeSmith templates
	/// </summary>
	public class CommonSqlCode : CodeTemplate
	{
		#region private fields
// [ab 012605] convenience array for checking if a datatype is an integer 
		private readonly static DbType[] aIntegerDbTypes = new DbType[] {DbType.Int16,DbType.Int32, DbType.Int64 };
		
		private string entityFormat 		= "{0}";
		private string collectionFormat 	= "{0}Collection";
		private string providerFormat 		= "{0}Provider";
		private string interfaceFormat	 	= "I{0}";
		private string baseClassFormat 		= "{0}Base";
		private string unitTestFormat		= "{0}Test";
		private string enumFormat 			= "{0}List";
		private string manyToManyFormat		= "{0}From{1}";
		#endregion
		
		#region Helper
		/// <summary>
		/// Return a specified number of tabs
		/// </summary>
		/// <param name="n">Number of tabs</param>
		/// <returns>n tabs</returns>
		public string Tab(int n)
		{
			return new String('\t', n);
		}
		
		public string Tab()
		{
			return new String('\t', 1);
		}
		#endregion
		
		#region "Code style public properties"
		
		[Category("Code style")]
		[Description("The format for entity class name. Parameter {0} is replaced by the trimed table name, in Pascal case.")]
		public string EntityFormat
		{
			get {return this.entityFormat;}
			set
			{
				if (value.IndexOf("{0}") == -1) 
				{
					throw new ArgumentException("This parameter must contains the pattern {0} to be valid.", "EntityFormat");
				}
				this.entityFormat = value;
			}
		}
		
		[Category("Code style")]
		[Description("The format for any collection class name. Parameter {0} is replaced by the collection item class name.")]
		public string CollectionFormat
		{
			get {return this.collectionFormat;}
			set
			{
				if (value.IndexOf("{0}") == -1) 
				{
					throw new ArgumentException("This parameter must contains the pattern {0} to be valid.", "CollectionFormat");
				}
				this.collectionFormat = value;
			}
		}
		
		[Category("Code style")]
		[Description("The format for any provider class name. Parameter {0} is replaced by the original class name.")]
		public string ProviderFormat
		{
			get {return this.providerFormat;}
			set
			{
				if (value.IndexOf("{0}") == -1) 
				{
					throw new ArgumentException("This parameter must contains the pattern {0} to be valid.", "ProviderFormat");
				}
				this.providerFormat = value;
			}
		}
		
		[Category("Code style")]
		[Description("The format for any interface name. Parameter {0} is replaced by the original class name.")]
		public string InterfaceFormat
		{
			get {return this.interfaceFormat;}
			set
			{
				if (value.IndexOf("{0}") == -1) 
				{
					throw new ArgumentException("This parameter must contains the pattern {0} to be valid.", "InterfaceFormat");
				}
				this.interfaceFormat = value;
			}
		}
		
		[Category("Code style")]
		[Description("The format for any base class name. Parameter {0} is replaced by the original class name.")]
		public string BaseClassFormat
		{
			get {return this.baseClassFormat;}
			set
			{
				if (value.IndexOf("{0}") == -1) 
				{
					throw new ArgumentException("This parameter must contains the pattern {0} to be valid.", "BaseClassFormat");
				}
				this.baseClassFormat = value;
			}
		}
		
		[Category("Code style")]
		[Description("The format for any enum. Parameter {0} is replaced by the original class name.")]
		public string EnumFormat
		{
			get {return this.enumFormat;}
			set
			{
				if (value.IndexOf("{0}") == -1) 
				{
					throw new ArgumentException("This parameter must contains the pattern {0} to be valid.", "EnumFormat");
				}
				this.enumFormat = value;
			}
		}
		
		[Category("Code style")]
		[Description("The format for many to many methods. Parameter {0} is replaced by the secondary class name.")]
		public string ManyToManyFormat
		{
			get {return this.manyToManyFormat;}
			set
			{
				if (value.IndexOf("{0}") == -1) 
				{
					throw new ArgumentException("This parameter must contains the pattern {0} to be valid.", "ManyToManyFormat");
				}
				this.manyToManyFormat = value;
			}
		}
		
		#endregion
		
		#region GetName

		/// <summary>
		/// Get the safe name for a data object by determining if it contains spaces or other illegal
		/// characters - if so wrap with []
		/// </summary>
		/// <param name="schemaObject">Database schema object (e.g. a table, stored proc, etc)</param>
		/// <returns>The safe name of the object</returns>
		public string GetSafeName(SchemaObjectBase schemaObject)
		{
			return GetSafeName(schemaObject.Name);
		}

		/// <summary>
		/// Get the safe name for a data object by determining if it contains spaces or other illegal
		/// characters - if so wrap with []
		/// </summary>
		/// <param name="objectName">The name of the database schema object</param>
		/// <returns>The safe name of the object</returns>
		public string GetSafeName(string objectName)
		{
			return objectName.IndexOfAny(new char[]{' ', '@', '-', ',', '!'}) > -1 ? "[" + objectName + "]" : objectName;
		}
		/// <summary>
		/// Get the camel cased version of a name.  
		/// If the name is all upper case, change it to all lower case
		/// </summary>
		/// <param name="name">Name to be changed</param>
		/// <returns>CamelCased version of the name</returns>
		public string GetCamelCaseName(string name)
		{
			if (name.Equals(name.ToUpper()))
				return name.ToLower().Replace(" ","");
			else
				return name.Substring(0, 1).ToLower() + name.Substring(1).Replace(" ","");
		}
		
		/// <summary>
		/// Get the Pascal cased version of a name.  
		/// </summary>
		/// <param name="name">Name to be changed</param>
		/// <returns>PascalCased version of the name</returns>
		public string GetPascalCaseName(string name)
		{		
			return name.Substring(0, 1).ToUpper() + name.Substring(1);
		}
		
		
		#region Business object class name		
		public string GetAbstractClassName(string tableName)
		{
			return ApplyBaseClassFormat(GetClassName(tableName));
		}

		public string GetPartialClassName(string tableName)
		{
			return string.Format("{0}.generated", GetClassName(tableName));
		}
		
		public string GetEnumName(string tableName)
		{
			return string.Format(this.enumFormat, GetClassName(tableName));
		}
				
		
		// Create a class name from a table name, for a business object
		public string GetClassName(string tableName)
		{
			// 1.remove space or bad characters
			string name = GetCleanName(string.Format(this.entityFormat, tableName));
			
			// 2. Set Pascal case
			name = GetPascalCaseName(name);
			
			// 3. Remove any plural - Experimental, need more grammar analysis//ref: http://www.gsu.edu/~wwwesl/egw/crump.htm
			//ArrayList invariants = new ArrayList();
			//invariants.Add("alias");
			
			
			//if (invariants.Contains(name.ToLower()))
			//{
			//	return name;
			//}
			//else if (name.EndsWith("ies"))
			//{
			//	return name.Substring(0, name.Length-3) + "y";
			//}
			//else if (name.EndsWith("s") && !(name.EndsWith("ss") || name.EndsWith("us")))
			//{
			//	return name.Substring(0, name.Length-1);
			//}
			//else
				return name;
		}
		public string GetClassName(SchemaObjectBase table)
		{
			return GetClassName(table.Name);
		}
		public string GetEntityClassName(string tableName)
		{
			return GetClassName(tableName) + "Info";
		}
		public string GetEntityClassName(SchemaObjectBase schemaObject)
		{
			return GetClassName(schemaObject.Name) + "Info";
		}
		public string GetEntityCollectionClassName(string tableName)
		{
			return GetClassName(tableName) + "InfoCollection";
		}
		public string GetEntityCollectionClassName(SchemaObjectBase schemaObject)
		{
			return GetClassName(schemaObject.Name) + "InfoCollection";
		}
		#endregion
		
		#region collection class name
		public string GetAbstractCollectionClassName(string tableName)
		{
			return ApplyBaseClassFormat(GetCollectionClassName(tableName));
		}
		public string GetCollectionClassName(string tableName)
		{
			return string.Format(collectionFormat, GetClassName(tableName));
		}
		#endregion

		#region Provider class name
		public string GetProviderName(string tableName)
		{
			return string.Format(providerFormat, GetClassName(tableName));
		}
		
		public string GetProviderClassName(string tableName)
		{
			return GetProviderName(tableName);
		}
		
		/*public string GetProviderDecoratorClassName(string tableName)
		{
			return string.Format(decoratorFormat, GetProviderClassName(tableName));
		}*/
		public string GetIProviderName(string tableName)
		{
			return string.Format(interfaceFormat, GetProviderClassName(tableName));
		}
		public string GetProviderBaseName(string tableName)
		{
			return ApplyBaseClassFormat(GetProviderClassName(tableName));
		}
		
		public string GetProviderTestName(string tableName)
		{
			return string.Format(unitTestFormat, GetClassName(tableName));
		}
		#endregion
		
		#region Factory class name
				
		public string GetAbstractRepositoryClassName(string tableName)
		{
			return ApplyBaseClassFormat(GetRepositoryClassName(tableName));
		}
		
		public string GetRepositoryClassName(string tableName)
		{
			return GetProviderName(tableName);
		}		
		
		public string GetRepositoryTestClassName(string tableName)
		{
			return string.Format(unitTestFormat, GetClassName(tableName));
		}
		#endregion
		

		/// <summary>
		/// Remove any non-word characters from a name (word characters are a-z, A-Z, 0-9, _)
		/// so that it may be used in code
		/// </summary>
		/// <param name="name">name to be cleaned</param>
		/// <returns>Cleaned up object name</returns>
		public string GetCleanName(string name)
		{
			return Regex.Replace(name, @"[\W]", "");
		}
		
		public string GetPropertyName(string name)
		{		
		   	name = Regex.Replace(name, @"[\W]", "");
			name = GetPascalCaseName(name);
			return name;
		}
		public string GetPropertyName(SchemaObjectBase schemaObject)
		{		
			return GetPropertyName(schemaObject.Name);
		}
		/// <summary>
		/// Remove any non-word characters from a SchemaObject's name (word characters are a-z, A-Z, 0-9, _)
		/// so that it may be used in code
		/// </summary>
		/// <param name="schemaObject">DB Object whose name is to be cleaned</param>
		/// <returns>Cleaned up object name</returns>
		public string GetCleanName(SchemaObjectBase schemaObject)
		{
			return GetCleanName(schemaObject.Name);
		}
		
		
		private string ApplyBaseClassFormat(string className)
		{
			return string.Format(baseClassFormat, className);
		}
		
		public string GetObjectPropertyAccessor(ColumnSchema column, string objectName)
		{
			return objectName + "." + GetPropertyName(column.Name);
		}
		
		public string GetObjectPropertyAccessor(ViewColumnSchema column, string objectName)
		{
			return objectName + "." + GetPropertyName(column.Name);
		}
		
		public string GetPrivateName(SchemaObjectBase schemaObject)
		{
			return GetPrivateName(schemaObject.Name);
		}
						
		public string GetPrivateName(string name)
		{		
		   	name = Regex.Replace(name, @"[\W]", "");
			name = GetCamelCaseName(name);
			
			if (name == "internal" || name == "class" || name == "public" || name == "private")
			{
				name = "p" + name;
			}
			
			return name;
		}

		public string GetManyToManyName(TableKeySchema junctionTableKey, string junctionTableName)
		{			
			return GetManyToManyName(junctionTableKey.ForeignKeyMemberColumns, junctionTableName);
		}
		
		public string GetManyToManyName(ColumnSchemaCollection columns, string junctionTableName)
		{
			string result = string.Empty;
			foreach(ColumnSchema pCol in columns)
			{
				result += GetCleanName(pCol.Name);
			}
			return string.Format(this.manyToManyFormat, result, junctionTableName);
		}
		
		/// <summary>
		/// Get the cleaned, camelcased name of a parameter
		/// </summary>
		/// <param name="par">Command Parameter</param>
		/// <returns>the cleaned, camelcased name </returns>
		public string GetCleanParName(ParameterSchema par)
		{
			return GetCleanParName(par.Name);
		}

		/// <summary>
		/// Get the cleaned, camelcased version of a name
		/// </summary>
		/// <param name="name">name to be cleaned</param>
		/// <returns>the cleaned, camelcased name </returns>
		public string GetCleanParName(string name)
		{
			return GetCamelCaseName(GetCleanName(name));
		}

		/// <summary>
		/// Get the member variable styled version of a name
		/// </summary>
		/// <param name="column">The ColumnSchema with the name to be cleaned</param>
		/// <returns>the cleaned, camelcased name with a _ prefix</returns>
		public string GetMemberVariableName(ColumnSchema column)
		{
			return "_" + GetCleanParName(column.Name);
		}
		public string GetMemberVariableName(SchemaObjectBase schemaObject)
		{
			return "_" + GetCleanParName(schemaObject.Name);
		}

		/// <summary>
		/// Get the member variable styled version of a name
		/// </summary>
		/// <param name="name">name to be cleaned</param>
		/// <returns>the cleaned, camelcased name with a _ prefix</returns>
		public string GetMemberVariableName(string name)
		{
			return "_" + GetCleanParName(name);
		}
		
		/// <summary>
		/// Get the member variable styled version of a name
		/// </summary>
		/// <param name="column">The column with the name to be cleaned</param>
		/// <returns>the cleaned, pascal cases name with a _Original prefix</returns>
		public string GetOriginalMemberVariableName(ColumnSchema column)
		{
			return GetOriginalMemberVariableName(column.Name);
		}
		
		/// <summary>
		/// Get the member variable styled version of a name
		/// </summary>
		/// <param name="name">name to be cleaned</param>
		/// <returns>the cleaned, camelcased name with a _ prefix</returns>
		public string GetOriginalMemberVariableName(string name)
		{
			return "_Original" + GetPropertyName(name);
		}
		#endregion

		#region judge Column Type
		/// <summary>
		/// Check that a given key has all foreign's columns into the primary key.
		/// </summary>
		/// <param name="key">The key to check.</param>
		public bool IsJunctionKey(TableKeySchema key)
		{
			foreach(ColumnSchema col in key.ForeignKeyMemberColumns)
			{
				if (!col.IsPrimaryKeyMember)
					return false;
			}
			return true;
		}
		
		/// <summary>
		/// Check that a given index has all it's columns into the primary key.
		/// </summary>
		/// <param name="index">The index to check.</param>
		public bool IsPrimaryKey(IndexSchema index)
		{
			foreach(ColumnSchema col in index.MemberColumns)
			{
				if (!col.IsPrimaryKeyMember)
					return false;
			}
			return true;
		}

		/// <summary>
		/// Check if a column is an identity column
		/// </summary>
		/// <param name="column">DB table column to be checked</param>
		/// <returns>Identity?</returns>
		public bool IsIdentityColumn(ColumnSchema column)
		{
			return (bool)column.ExtendedProperties["CS_IsIdentity"].Value;
		} 
		
		public bool IsReadOnlyColumn(ColumnSchema column)
		{
			if (column.ExtendedProperties["CS_ReadOnly"].Value != null)
				return (bool)column.ExtendedProperties["CS_ReadOnly"].Value;
			else 
				return false;
			
			//return column.ExtendedProperties.Count == 0 || (bool)column.ExtendedProperties["CS_ReadOnly"].Value;
		}
		
		public bool IsComputed(ColumnSchema column)
		{
			return (bool)column.ExtendedProperties["CS_IsComputed"].Value == true || column.NativeType.ToLower() == "timestamp";
		}
		#endregion
		
		#region GetOwner
		/// <summary>
		/// Get the owner of a table
		/// </summary>
		/// <param name="table">The table to check</param>
		/// <returns>The safe name of the owner of the table</returns>
		public string GetOwner(TableSchema table)
		{
			return (table.Owner.Length > 0) ? GetSafeName(table.Owner) + "." : "";
		}
		
		/// <summary>
		/// Get the owner of a view
		/// </summary>
		/// <param name="view">The view to check</param>
		/// <returns>The safe name of the owner of the view</returns>
		public string GetOwner(ViewSchema view)
		{
			return (view.Owner.Length > 0) ? GetSafeName(view.Owner) + "." : "";
		}

		/// <summary>
		/// Get the owner of a command
		/// </summary>
		/// <param name="command">The command to check</param>
		/// <returns>The safe name of the owner of the command</returns>
		public string GetOwner(CommandSchema command)
		{
			return (command.Owner.Length > 0) ? GetSafeName(command.Owner) + "." : "";
		}
		#endregion

		/// <summary>
		/// Does the command have a resultset?
		/// </summary>
		/// <param name="cmd">Command in question</param>
		/// <returns>Resultset?</returns>
		public bool HasResultset(CommandSchema cmd)
		{
			return cmd.CommandResults.Count > 0;
		}
		
		#region GetSqlParameterStatement
		/// <summary>
		/// Get a SqlParameter statement for a column
		/// </summary>
		/// <param name="columns">Columns for which to get the Sql parameter statement</param>
		/// <returns>Sql Parameter statement</returns>
		public string GetSqlParameterStatement(ColumnSchemaCollection columns)
		{
			string result = string.Empty;
			
			for(int i=0; i<columns.Count; i++)
			{
				if (i>0) result += ", ";
				
				result += GetSqlParameterStatement(columns[i]) + Environment.NewLine;
				
			}	
			return result;
		}

		/// <summary>
		/// Get a SqlParameter statement for a column
		/// </summary>
		/// <param name="column">Column for which to get the Sql parameter statement</param>
		/// <returns>Sql Parameter statement</returns>
		public string GetSqlParameterStatement(ColumnSchema column)
		{
			return GetSqlParameterStatement(column, false);
		}
		
		/// <summary>
		/// Get a SqlParameter statement for a column
		/// </summary>
		/// <param name="column">Column for which to get the Sql parameter statement</param>
		/// <param name="isOutput">Is this an output parameter?</param>
		/// <returns>Sql Parameter statement</returns>
		public string GetSqlParameterStatement(ColumnSchema column, bool isOutput)
		{
			string param = "@" + GetPropertyName(column.Name) + " " + column.NativeType;
			
			switch (column.DataType)
			{
				case DbType.Decimal:
				{
					if (column.NativeType != "real")
						param += "(" + column.Precision + ", " + column.Scale + ")";
				
					break;
				}
				// [ab 022205] now handles xxxbinary data type
				case DbType.Binary:
				// 
				case DbType.AnsiString:
				case DbType.AnsiStringFixedLength:
				case DbType.String:
				case DbType.StringFixedLength:
				{
					if (column.NativeType != "text" && 
						column.NativeType != "ntext" && 
						column.NativeType != "timestamp" &&
						column.NativeType != "image"
						)

					{
						if (column.Size > 0)
						{
							param += "(" + column.Size + ")";
						}
					}
					break;
				}
			}
			
			if (isOutput)
			{
				param += " OUTPUT";
			}
			
			return param;
		}
		/// <summary>
		/// Get a SqlParameter statement for a column
		/// </summary>
		/// <param name="column">Column for which to get the Sql parameter statement</param>
		/// <param name="Name">the name of the parameter?</param>
		/// <returns>Sql Parameter statement</returns>
		public string GetSqlParameterStatement(ColumnSchema column, string Name)
		{
			string param = "@" + GetPropertyName(Name) + " " + column.NativeType;
			
			switch (column.DataType)
			{
				case DbType.Decimal:
				{
					param += "(" + column.Precision + ", " + column.Scale + ")";
					break;
				}
				case DbType.AnsiString:
				case DbType.AnsiStringFixedLength:
				case DbType.String:
				case DbType.StringFixedLength:
				{
					if (column.NativeType != "text" && column.NativeType != "ntext")
					{
						if (column.Size > 0)
						{
							param += "(" + column.Size + ")";
						}
					}
					break;
				}
			}	
			return param;
		}
		#endregion
		
		#region GetSqlParameterStatements
		public string GetSqlParameterStatements(string statementPrefix, ColumnSchema column)
		{
			return this.GetSqlParameterStatements(statementPrefix, column, "sql");
		}
		public string GetSqlParameterStatements(string statementPrefix, ColumnSchema column, string sqlObjectName)
		{
			string[] textArray1 = new string[10] { "\r\n", statementPrefix, sqlObjectName, ".AddParameter(\"@", column.Name, "\", SqlDbType.", this.GetSqlDbType(column), ", this.", this.GetPropertyName(column), this.GetSqlParameterExtraParams(statementPrefix, column) } ;
			string text1 = string.Concat(textArray1);
			return text1.Substring(statementPrefix.Length + 2);
		}
		#endregion
		
		#region GetSqlParameterXmlNode
		/// <summary>
		/// Get a SqlParameter statement for a column
		/// </summary>
		/// <param name="column">Column for which to get the Sql parameter statement</param>
		/// <param name="isOutput">indicates the direction</param>
		/// <returns>Sql Parameter statement</returns>
		public string GetSqlParameterXmlNode(ColumnSchema column, bool isOutput)
		{
			return GetSqlParameterXmlNode(column, column.Name, isOutput);
			//string formater = "<parameter name=\"@{0}\" type=\"{1}\" direction=\"{2}\" size=\"{3}\" precision=\"{4}\" scale=\"{5}\" param=\"{6}\"/>";			
			//return string.Format(formater, GetPropertyName(column.Name), column.NativeType, isOutput ? "Output" : "Input", column.Size, column.Precision, column.Scale, GetSqlParameterParam(column));
		}
		
		/// <summary>
		/// Get a SqlParameter statement for a column
		/// </summary>
		/// <param name="column">Column for which to get the Sql parameter statement</param>
		/// <param name="parameterName">the name of the parameter?</param>
		/// <param name="isOutput">indicates the direction</param>
		/// <returns>the xml Sql Parameter statement</returns>
		public string GetSqlParameterXmlNode(ColumnSchema column, string parameterName, bool isOutput)
		{
			string formater = "<parameter name=\"@{0}\" type=\"{1}\" direction=\"{2}\" size=\"{3}\" precision=\"{4}\" scale=\"{5}\" param=\"{6}\"/>";			
			return string.Format(formater, GetPropertyName(parameterName), column.NativeType, isOutput ? "Output" : "Input", column.Size, column.Precision, column.Scale, GetSqlParameterParam(column));
		}
		#endregion
		
		#region GetSqlParameterParam
		public string GetSqlParameterParam(ColumnSchema column)
		{
			string param = string.Empty;
			
			switch (column.DataType)
			{
				case DbType.Decimal:
				{
					param = "(" + column.Precision + ", " + column.Scale + ")";
					break;
				}
				case DbType.AnsiString:
				case DbType.AnsiStringFixedLength:
				case DbType.String:
				case DbType.StringFixedLength:
				{
					if (column.NativeType != "text" && column.NativeType != "ntext")
					{
						if (column.Size > 0)
						{
							param = "(" + column.Size + ")";
						}
					}
					break;
				}
			}	
			return param;
		}

		public string GetSqlParameterExtraParams(string statementPrefix, ColumnSchema column)
		{
			string param = string.Empty;
			
			switch (column.DataType)
			{
				case DbType.Decimal:
				{
					object[] objArray1 = new object[9] { ");\r\n", statementPrefix, "prm.Scale = ", column.Scale, ";\r\n", statementPrefix, "prm.Precision = ", column.Precision, ";" } ;
					param =  string.Concat(objArray1);
					break;
				}
				case DbType.AnsiStringFixedLength:
				case DbType.StringFixedLength:
				case DbType.String:
				{
					if ((column.NativeType != "text") && (column.NativeType != "ntext"))
					{
						param =  (", " + column.Size + ");");
					}
					else
					{
						param =  ");";
					}
					break;
				}
				default:
				{
					param =  ");";
					break;
				}
			}

			return param;
		}

		#endregion
		
		#region GetSqlProcedureComment
		/// <summary>
		/// Parse the text of a stored procedure to retrieve any comment prior to the CREATE PROC construct
		/// </summary>
		/// <param name="commandText">Command Text of the procedure</param>
		/// <returns>The procedure header comment</returns>
		public string GetSqlProcedureComment(string commandText)
		{
			string comment = "";
			// Find anything upto the CREATE PROC statement
			Regex regex = new Regex(@"CREATE[\s]*PROC", RegexOptions.IgnoreCase);	
			comment = regex.Split(commandText)[0];
			//remove comment characters
			regex = new Regex(@"(-{2,})|(/\*)|(\*/)");
			comment = regex.Replace(comment, string.Empty);
			//trim and return
			return comment.Trim();
		}

		/// <summary>
		/// Get any in-line SQL comments on the same lines as parameters
		/// </summary>
		/// <param name="commandText">Command Text of the procedure</param>
		/// <returns>Hashtable of parameter comments, with parameter names as keys</returns>
		public Hashtable GetSqlParameterComments(string commandText)
		{
			Hashtable paramComments = new Hashtable();
			//Get parameter names and comments
			string pattern = @"(?<param>@\w*)[^@]*--(?<comment>.*)";
			//loop through the matches and extract the parameter and the comment, ignoring duplicates
			foreach (Match match in Regex.Matches(commandText, pattern))
				if (!paramComments.ContainsKey(match.Groups["param"].Value))
					paramComments.Add(match.Groups["param"].Value, match.Groups["comment"].Value.Trim());
			//return the hashtable
			return paramComments;
		}
		
		/// <summary>
		/// Get the description ext. property of a column and return as inline SQL comment
		/// </summary>
		/// <param name="schemaObject">Any database object, but typically a column</param>
		/// <returns>Object description, as inline SQL comment</returns>
		public string GetColumnSqlComment(SchemaObjectBase schemaObject)
		{
			return schemaObject.Description.Length > 0 ? "-- " + schemaObject.Description : "";
		}
		#endregion
		
		#region "Stored procedures input transformations"
		
		/// <summary>
		/// Transform the list of sql parameters to a list of method parameters.
		/// </summary>
		public string TransformStoredProcedureInputsToMethod(ParameterSchemaCollection inputParameters)
		{
			return TransformStoredProcedureInputsToMethod(false, inputParameters);
		}
		
		/// <summary>
		/// Transform the list of sql parameters to a list of method parameters.
		/// </summary>
		public string TransformStoredProcedureInputsToMethod(bool startWithComa, ParameterSchemaCollection inputParameters)
		{
			string temp = string.Empty;
			for(int i=0; i<inputParameters.Count; i++)
			{
				temp += (i>0) || startWithComa ? ", " : "";
				temp += GetCSType(inputParameters[i]) + " " + GetPrivateName(inputParameters[i].Name.Substring(1));
			}
			
			return temp;
		}
		
		/// <summary>
		/// Transform the list of sql parameters to a list of ExecuteXXXXX parameters.
		/// </summary>
		public string TransformStoredProcedureInputsToDataAccess(ParameterSchemaCollection inputParameters)
		{
			return TransformStoredProcedureInputsToDataAccess(false, inputParameters);
		}
		
		/// <summary>
		/// Transform the list of sql parameters to a list of ExecuteXXXXX parameters.
		/// </summary>
		public string TransformStoredProcedureInputsToDataAccess(bool alwaysStartWithaComa, ParameterSchemaCollection inputParameters)
		{
			string temp = string.Empty;
			for(int i=0; i<inputParameters.Count; i++)
			{
				temp += (i>0) || alwaysStartWithaComa ? ", " : "";
				temp += GetPrivateName(inputParameters[i].Name.Substring(1));
			}
			
			return temp;
		}
						
		/// <summary>
		/// Transform the list of sql parameters to a list of comment param for a method
		/// </summary>
		public string TransformStoredProcedureInputsToMethodComments(ParameterSchemaCollection inputParameters)
		{
			string temp = string.Empty;
			for(int i=0; i<inputParameters.Count; i++)
			{
				temp += string.Format("{2}\t/// <param name=\"{0}\"> A <c>{1}</c> instance.</param>", GetPrivateName(inputParameters[i].Name.Substring(1)), GetCSType(inputParameters[i]), Environment.NewLine);
			}
			
			return temp;
		}

		#endregion
		
		#region controuctor
		public string GetFunctionHeaderParameters(ColumnSchemaCollection columns)
		{
			string output = "";
			for (int i = 0; i < columns.Count; i++)
			{
				output += GetCSType(columns[i]) + " ";
				output +=  GetPrivateName(columns[i].Name);
				if (i < columns.Count - 1)
				{
					output += ", ";
				}
			}
			return output;
		}
		
		public string GetFunctionParameters( ParameterSchemaCollection parameters)
		{
			string output = "";
			for (int i = 0; i < parameters.Count; i++)
			{
				output += GetCSType(parameters[i]) + " ";
				output +=  GetPrivateName(parameters[i].Name);
				if (i < parameters.Count - 1)
				{
					output += ", ";
				}
			}
			return output;
		}
		
		public string GetFunctionCallParameters(ColumnSchemaCollection columns)
		{
			string output = "";
			for (int i = 0; i < columns.Count; i++)
			{
				output +=  GetPrivateName(columns[i].Name);
				if (i < columns.Count - 1)
				{
					output += ", ";
				}
			}
			return output;
		}
		
		public string GetFunctionEntityParameters(ColumnSchemaCollection columns)
		{
			string output = "";
			for (int i = 0; i < columns.Count; i++)
			{
				output +=  "entity." + GetPropertyName(columns[i].Name);
				if (i < columns.Count - 1)
				{
					output += ", ";
				}
			}
			return output;
		}
		#endregion
		
		#region GetType
		/// <summary>
		/// Convert database types to C# types
		/// </summary>
		/// <param name="field">Column or parameter</param>
		/// <returns>The C# (rough) equivalent of the field's data type</returns>
		public string GetCSType(DataObjectBase field)
		{
			//return field.NativeType;
			if (field.NativeType.ToLower() == "real")
				return "System.Single";
			else
				return field.SystemType.ToString();
			//return GetCSType(field.DataType);
		}
		/// <summary>
		/// Convert database types to SqlDbType
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
			}
			return strSqlDbType;
		}
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
			try { return GetNullableType((DbType)Enum.Parse(typeof(DbType), dataType)); }
			catch { return "object"; }
		}
		#endregion


/*
		/// <summary>
		/// Get a default value for a given field's data type
		/// </summary>
		/// <param name="field">The field for which to get the default value</param>
		/// <returns>A string representation of the default value</returns>
		public string GetDefaultByType(DataObjectBase field)
		{
			return GetDefaultByType(field.DataType);
		}

		/// <summary>
		/// Get a default value for a given data type name
		/// </summary>
		/// <param name="dataType">String name of the data type for which to get the default value<</param>
		/// <returns>A string representation of the default value</returns>
		public string GetDefaultByType(string dataType)
		{
			try { return GetDefaultByType((DbType)Enum.Parse(typeof(DbType), dataType)); }
			catch { return "null"; }
		}

		/// <summary>
		/// Get a default value for a given data type
		/// </summary>
		/// <param name="dataType">Data type for which to get the default value<</param>
		/// <returns>A string representation of the default value</returns>
		public string GetDefaultByType(DbType dataType)
		{
			switch (dataType)
			{
				case DbType.AnsiString: return "string.Empty";
				case DbType.AnsiStringFixedLength: return "string.Empty";
				//Answer modified was just 0
				case DbType.Binary: return "0";
				case DbType.Boolean: return "false";
				
				//Answer modified was just 0
				case DbType.Byte: 
					return "(byte)0"; 
					//return "{ 0 }"; 
				
				case DbType.Currency: return "0";
				case DbType.Date: return "DateTime.MaxValue";
				case DbType.DateTime: return "DateTime.MaxValue";
				case DbType.Decimal: return "0";
				case DbType.Double: return "0";

				case DbType.Guid: 
					return "0";

				case DbType.Int16: 
					return "0";

				case DbType.Int32: 
					return "0";

				case DbType.Int64: return "0";
				case DbType.Object: return "null";
				case DbType.Single: return "0";
				case DbType.String: return "0";
				case DbType.StringFixedLength: return "string.Empty";
				case DbType.Time: return "DateTime.MaxValue";
				case DbType.VarNumeric: 
					return "0";
					//the following won't be used
					//		case DbType.SByte: return "0";
					//		case DbType.UInt16: return "0";
					//		case DbType.UInt32: return "0";
					//		case DbType.UInt64: return "0";
				default: return "null";
			}
		}
	
*/
		
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
						
					case DbType.Boolean: 
						return "false";
					
					case DbType.StringFixedLength: 
						return "string.Empty";
						
					case DbType.Guid: 
						return "Guid.Empty";
					
					
					//Answer modified was just 0
					case DbType.Binary: 
						return "new byte[] {}";
					
					//Answer modified was just 0
					case DbType.Byte:
						return "(byte)0";
						//return "{ 0 }";
					
					case DbType.Currency: 
						return "0";
					
					case DbType.Date: 
						return "DateTime.MinValue";
					
					case DbType.DateTime: 
						return "DateTime.MinValue";
					
					case DbType.Decimal: 
						return "0.0m";
						//return "0M";
						//return "0.0M";
					
					case DbType.Double: 
						return "0.0f";
					
					case DbType.Int16: 
						return "(short)0";
						
					case DbType.Int32: 
						return "(int)0";
						
					case DbType.Int64: 
						return "(long)0";
					
					case DbType.Object: 
						return "null";
					
					case DbType.Single: 
						return "0F";
					
					//case DbType.Time: return "DateTime.MaxValue";
					case DbType.Time: return "new DateTime(1900,1,1,0,0,0,0)";
					case DbType.VarNumeric: return "0";
						//the following won't be used
						//		case DbType.SByte: return "0";
						//		case DbType.UInt16: return "0";
						//		case DbType.UInt32: return "0";
						//		case DbType.UInt64: return "0";
					default: return "null";
				}
			}
		}
		
		/*
		/// <summary>
		/// Get a default value for a given data type
		/// </summary>
		/// <param name="dataType">Data type for which to get the default value<</param>
		/// <returns>A string representation of the default value</returns>
		public string GetCSDefaultByType(DbType dataType)
		{			
			
		}
*/
			/// <summary>
		/// Get a mock value for a given data type. Used by the unit test classes.
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
		/// <summary>
		/// Generates a random number between the given bounds.
		/// </summary>
		/// <param name="min">lowest bound</param>
		/// <param name="max">highest bound</param>
		public int RandomNumber(int min, int max)
		{
			Random random = new Random();
			return random.Next(min, max); 
		}

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
			
			return RandomString((size/2) -1, lowerCase);
		}
		
		/// <summary>
		/// Generates a random string with the given length
		/// </summary>
		/// <param name="size">Size of the string</param>
		/// <param name="lowerCase">If true, generate lowercase string</param>
		/// <returns>Random string</returns>
		/// <remarks>Mahesh Chand  - http://www.c-sharpcorner.com/Code/2004/Oct/RandomNumber.asp</remarks>
		public string RandomString(int size, bool lowerCase)
		{
			StringBuilder builder = new StringBuilder();
			Random random = new Random(size);
			char ch ;
			for(int i=0; i<size; i++)
			{
				ch = Convert.ToChar(Convert.ToInt32(26 * random.NextDouble() + 65)) ;
				builder.Append(ch); 
			}
			if(lowerCase)
			return builder.ToString().ToLower();
			return builder.ToString();
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
		
		#region RuleColumn
		public string FKColumnName(TableKeySchema fkey)
		{
			string Name = String.Empty;
			for(int x=0;x < fkey.ForeignKeyMemberColumns.Count;x++)
			{
				Name += GetPropertyName(fkey.ForeignKeyMemberColumns[x].Name);
			}
			return Name;
		}
		
		public string PKColumnName(TableKeySchema key)
		{
			string Name = String.Empty;
			for(int x=0;x < key.ForeignKeyMemberColumns.Count;x++)
			{
				Name += GetPropertyName(key.PrimaryKeyMemberColumns[x].Name);
			}
			return Name;
		}
		
		public string IXColumnName(IndexSchema index)
		{
			string Name = String.Empty;
			for(int x=0;x < index.MemberColumns.Count;x++)
			{
				Name += GetPropertyName(index.MemberColumns[x].Name);
			}
			return Name;
		}
		
		public string IXColumnNames(IndexSchema index)
		{
			string Name = String.Empty;
			for(int x=0;x < index.MemberColumns.Count;x++)
			{
				Name += ", " + GetPrivateName(index.MemberColumns[x].Name);
			}
			return Name.Substring(2);
		}
		
		public string GetKeysName(ColumnSchemaCollection keys)
		{	
			string result = String.Empty;
			for(int x=0; x < keys.Count;x++)
			{
				result += GetPropertyName(keys[x].Name);
			}
			return result;
		}

		public bool IsMultiplePrimaryKeys(ColumnSchemaCollection keys)
		{
			if(keys.Count > 1)
				return true;
			return false;
		}
		#endregion
		
		#region IsMatching
		// Check a table for enum eligibility
		// <exception name="ApplicationException"/>
		public void ValidForEnum(TableSchema table)
		{
			#region "Primary key validation"
			
			// No primary key
			if (table.PrimaryKey == null)
			{
				throw new ApplicationException("table has no primary key.");
			}
			
			// Multiple column in primary key
			if (table.PrimaryKey.MemberColumns.Count != 1)
			{
				throw new ApplicationException("table primary key contains more than one column.");
			}
			
			// Primary key column is not an integer
			if (!isIntXX(table.PrimaryKey.MemberColumns[0]))
			{
				throw new ApplicationException("table primary key column is not an integer. (used for enum value)");
			}
			
			#endregion
			
			#region "Second column must be a string"
			
			// The table must have 2 columns at least
			if (table.Columns.Count < 2)
			{
				throw new ApplicationException("table must at least contains two columns, an integer primary key, and a string.");
			}
			
			// The second column must be a string (char, varchar) 
			if (table.Columns[1].SystemType != typeof(string))
			{
				throw new ApplicationException("table 2nd column must be a string.");
			}
						
			// The second column must have a unique constraint (index with unique constraint)
			if (!table.Columns[1].IsUnique)
			{
				throw new ApplicationException("table 2nd column must be unique (used for the enum label).");
			}
									
			#endregion
			
			#region "Check relations"
			
			// the table mustn't have foreign relation
			if (table.ForeignKeys.Count > 0)
			{
				throw new ApplicationException("table cannot have relations where it is the foreign table.");
			}
			
			// relation with table as primary key can only be on the first column 
			foreach(TableKeySchema key in table.PrimaryKeys)
			{
				if (key.PrimaryKeyMemberColumns[0].Name != table.Columns[0].Name || key.PrimaryKeyMemberColumns.Count > 1)
				{
					throw new ApplicationException("table cannot have relations where it is the foreign table.");
				}
			}
			
			#endregion
		}
	
		/// <summary>
		/// Indicates if the output rowset of the command is compliant with the table rowset.
		/// </summary>
		/// <param name="command">The stored procedure</param>
		/// <param name="table">The table</param>
		public bool IsMatching(CommandSchema command, TableSchema table)
		{
			if (command.CommandResults.Count != 1)
			{
				return false;
			}
			
			if (command.CommandResults[0].Columns.Count != table.Columns.Count)
			{
				return false;
			}
			
			for(int i=0; i<table.Columns.Count; i++) //  CommandResultSchema cmdResult in command.CommandResults)
			{
				if (command.CommandResults[0].Columns[i].Name != table.Columns[i].Name)
				{
					return false;
				}
				
				if (command.CommandResults[0].Columns[i].NativeType != table.Columns[i].NativeType)
				{
					return false;
				}
			}
			return true;
		}
		
		/// <summary>
		/// Indicates if the output rowset of the command is compliant with the view rowset.
		/// </summary>
		/// <param name="command">The stored procedure</param>
		/// <param name="view">The view</param>
		public bool IsMatching(CommandSchema command, ViewSchema view)
		{
			if (command.CommandResults.Count != 1)
			{
				return false;
			}
			
			if (command.CommandResults[0].Columns.Count != view.Columns.Count)
			{
				return false;
			}
			
			for(int i=0; i<view.Columns.Count; i++)
			{
				if (command.CommandResults[0].Columns[i].Name != view.Columns[i].Name)
				{
					return false;
				}
				
				if (command.CommandResults[0].Columns[i].NativeType != view.Columns[i].NativeType)
				{
					return false;
				}
			}
			return true;
		}

		#endregion
		
		#region Is Int Column
		/// <summary>
		///	Indicates if a column is an int.
		/// </summary>
		/// <author>ab</author>
		/// <date>01/26/05</date>
		public bool isIntXX(ColumnSchema column)
		{
			bool result = false;

			for(int i = 0; i < aIntegerDbTypes.Length; i++)
			{
				if (aIntegerDbTypes[i] == column.DataType) result=true;
			}
			
			return result;		
		}
		
		// [ab 013105] column name sorting comparer
		public class columnSchemaComparer : IComparer  
		{
	      	int IComparer.Compare( Object x, Object y )  
			{
				if (x is ColumnSchema && y is ColumnSchema)
	          		return( (new CaseInsensitiveComparer()).Compare( ((ColumnSchema)x).Name,  ((ColumnSchema)y).Name ) );
					
				throw new ArgumentException("one or both object(s) are not of type ColumnSchema");
			}
				
      	}
		#endregion
      	
      	#region Execute sql file

		public void ExecuteSqlInFile(string pathToScriptFile, string connectionString ) 
		{
			SqlConnection connection;

			StreamReader _reader			= null;

			string sql	= "";

			if( false == System.IO.File.Exists( pathToScriptFile )) 
			{
				throw new Exception("File " + pathToScriptFile + " does not exists");
			}
			using( Stream stream = System.IO.File.OpenRead( pathToScriptFile ) ) 
			{
				_reader = new StreamReader( stream );

				connection = new SqlConnection(connectionString);

				SqlCommand	command = new SqlCommand();

				connection.Open();
				command.Connection = connection;
				command.CommandType	= System.Data.CommandType.Text;

				while( null != (sql = ReadNextStatementFromStream( _reader ) )) 
				{
					command.CommandText = sql;

					command.ExecuteNonQuery();
				}

				_reader.Close();
			}
			connection.Close();			
		}


		private static string ReadNextStatementFromStream( StreamReader _reader ) 
		{			
			StringBuilder sb = new StringBuilder();

			string lineOfText;

			while(true) 
			{
				lineOfText = _reader.ReadLine();
				if( lineOfText == null ) 
				{

					if( sb.Length > 0 ) 
					{
						return sb.ToString();
					}
					else 
					{
						return null;
					}
				}

				if( lineOfText.TrimEnd().ToUpper() == "GO" ) 
				{
					break;
				}
			
				sb.Append(lineOfText + Environment.NewLine);
			}

			return sb.ToString();
		}

		#endregion

		#region Children Collections
		
		/////////////////////////////////////////////////////////////////////////////////////
		/// Begin Children Collection 
		/////////////////////////////////////////////////////////////////////////////////////
		
		///<summary>
		///  An ArrayList of all the child collections for this table.
		///</summary>
		private System.Collections.ArrayList _collections = new System.Collections.ArrayList();
		
		///<summary>
		///  An ArrayList of all the properties rendered.  
		///  Eliminate Dupes through common junction tables and fk relationships
		///</summary>
		private System.Collections.ArrayList _renderedChildren = new System.Collections.ArrayList();
		
		///<summary>
		///  Holds the current table of the children collections being collected
		///</summary>
		private string _currentTable = string.Empty;


	
		///<summary>
		///	Returns an array list of Child Collections of the object
		///</summary>
		public System.Collections.ArrayList GetChildrenCollections(SchemaExplorer.TableSchema table, SchemaExplorer.TableSchemaCollection tables) 
		{
			//System.Diagnostics.Debugger.Break();
			//CleanUp
			if(CurrentTable != table.Name)
			{
				_collections.Clear();
				_renderedChildren.Clear();
				CurrentTable = table.Name;
			}
			
			if (_collections.Count > 0)
				return _collections;
			

			//Provides Informatoin about the foreign keys
			TableKeySchemaCollection fkeys = table.ForeignKeys;
			
			//Provides information about the indexes contained in the table. 
			IndexSchemaCollection indexes = table.Indexes;

			TableKeySchemaCollection primaryKeyCollection = table.PrimaryKeys;

			foreach(TableKeySchema keyschema in primaryKeyCollection)
			{
				// add the relationship only if the linked table is part of the selected tables (ie: omit tables without primary key)
				if (!tables.Contains(keyschema.ForeignKeyTable.Owner, keyschema.ForeignKeyTable.Name))
				{
					continue;
				}
						
				//Add 1-1 relations
				if(IsRelationOneToOne(keyschema))
				{
					CollectionInfo collectionInfo = new CollectionInfo();
					collectionInfo.PkColName = table.PrimaryKey.MemberColumns[0].Name;
					collectionInfo.PkIdxName = keyschema.Name;
					collectionInfo.PrimaryTable = table.Name;
					collectionInfo.SecondaryTable = keyschema.ForeignKeyTable.Name;
					collectionInfo.SecondaryTablePkColName = keyschema.ForeignKeyTable.PrimaryKey.MemberColumns[0].Name;
					collectionInfo.CollectionRelationshipType = RelationshipType.OneToOne;
					collectionInfo.CleanName = keyschema.ForeignKeyTable.Name;//GetClassName(keyschema.ForeignKeyTable.Name);		
					collectionInfo.CollectionName = GetCollectionClassName(collectionInfo.CleanName);
					collectionInfo.CallParams = GetFunctionRelationshipCallParameters(keyschema.ForeignKeyMemberColumns);
					collectionInfo.GetByKeysName = "GetBy" + GetKeysName(keyschema.ForeignKeyMemberColumns);
					collectionInfo.TableKey = keyschema;
					
					_collections.Add(collectionInfo);
			  	}
				//Add 1-N,N-1 relations
				else
				{
					CollectionInfo collectionInfo = new CollectionInfo();
					collectionInfo.PkColName = table.PrimaryKey.MemberColumns[0].Name;
					collectionInfo.PkIdxName = keyschema.Name;
					collectionInfo.PrimaryTable = table.Name;
					collectionInfo.SecondaryTable = keyschema.ForeignKeyTable.Name;
					collectionInfo.SecondaryTablePkColName = keyschema.ForeignKeyTable.PrimaryKey.MemberColumns[0].Name;
					collectionInfo.CollectionRelationshipType = RelationshipType.OneToMany;
					collectionInfo.CleanName = keyschema.ForeignKeyTable.Name; //GetClassName(keyschema.ForeignKeyTable.Name);
					collectionInfo.CollectionName = GetCollectionClassName(collectionInfo.CleanName);
					collectionInfo.CallParams = GetFunctionRelationshipCallParameters(table.PrimaryKey.MemberColumns);
					//collectionInfo.CallParams = GetFunctionRelationshipCallParameters(keyschema.ForeignKeyMemberColumns);
					collectionInfo.GetByKeysName = "GetBy" + GetKeysName(keyschema.ForeignKeyMemberColumns);
					collectionInfo.TableKey = keyschema;
					//collectionInfo.GetByKeysName = "GetBy" + GetKeysName(keyschema.ForeignKeyTable.PrimaryKey.MemberColumns);
				
					_collections.Add(collectionInfo);
				}
		    }
			
			//Add N-N relations
			// TODO -> only if option is activated			
			foreach(TableKeySchema key in primaryKeyCollection)
			{
				// Check that the key is related to a junction table and that this key relate a PK in this junction table
				if ( tables.Contains(key.ForeignKeyTable.Owner, key.ForeignKeyTable.Name) &&  IsJunctionTable(key.ForeignKeyTable) && IsJunctionKey(key))
				{
					TableSchema junctionTable = key.ForeignKeyTable;
					
					// Search for the other(s) key(s) of the junction table' primary key
					foreach(TableKeySchema junctionTableKey in junctionTable.ForeignKeys)
					{				
						if ( tables.Contains(junctionTableKey.ForeignKeyTable.Owner, junctionTableKey.ForeignKeyTable.Name) && IsJunctionKey(junctionTableKey) && junctionTableKey.Name != key.Name )
						{
							TableSchema secondaryTable = junctionTableKey.PrimaryKeyTable;
																			
							CollectionInfo collectionInfo = new CollectionInfo();
					
							collectionInfo.PkColName = table.PrimaryKey.MemberColumns[0].Name;
							collectionInfo.PkIdxName = junctionTableKey.Name;
							collectionInfo.PrimaryTable = table.Name;
							collectionInfo.SecondaryTable = junctionTableKey.PrimaryKeyTable.Name;
							collectionInfo.SecondaryTablePkColName = junctionTableKey.PrimaryKeyTable.PrimaryKey.MemberColumns[0].Name;
							collectionInfo.JunctionTable = junctionTable.Name;
							collectionInfo.CollectionName = string.Format("{0}_From_{1}", GetCollectionClassName( collectionInfo.SecondaryTable), GetCleanName(collectionInfo.JunctionTable)); //GetManyToManyName(GetCollectionClassName( collectionInfo.SecondaryTable), collectionInfo.JunctionTable);
							collectionInfo.CollectionRelationshipType = RelationshipType.ManyToMany;
							collectionInfo.CallParams = "entity." + GetPropertyName(collectionInfo.PkColName);
																				
							
							///Find FK junc table key, used for loading scenarios
							if(junctionTable.PrimaryKey.MemberColumns[0] == junctionTableKey.ForeignKeyMemberColumns[0])
							{
								collectionInfo.FkColName = junctionTable.PrimaryKey.MemberColumns[1].Name;
							}
							else
							{
								collectionInfo.FkColName = junctionTable.PrimaryKey.MemberColumns[0].Name;
							}	
							collectionInfo.CallParams = "entity." + GetPropertyName(collectionInfo.PkColName);
							//collectionInfo.GetByKeysName = collectionInfo.PkColName + "From" + GetClassName(junctionTable.Name);							
							
							
							collectionInfo.GetByKeysName = FKColumnName(key) + "From" + GetCleanName(junctionTable.Name);							
							
							collectionInfo.TableKey = key;		
								
							//GetManyToManyName(junctionTable.PrimaryKey.MemberColumns, collectionInfo.JunctionTable);
							//collectionInfo.GetByKeysName = GetManyToManyName(table.PrimaryKey.MemberColumns, GetClassName(junctionTable.Name));;

							collectionInfo.CleanName = string.Format("{0}From{1}", GetCleanName(collectionInfo.SecondaryTable), GetCleanName(junctionTable.Name)); //GetManyToManyName(collectionInfo.SecondaryTable, junctionTable.Name);
							_collections.Add(collectionInfo);
						}
					}
				}
			}// end N-N relations
		return _collections; 
		}

		public string GetFunctionRelationshipCallParameters(ColumnSchemaCollection columns)
		{
			string output = "";
			for (int i = 0; i < columns.Count; i++)
			{
				output +=  "entity." + GetPropertyName(columns[i].Name);
				if (i < columns.Count - 1)
				{
					output += ", ";
				}
			}
			return output;
		}



		///<summary>
		/// returns true all primary key columns have is a foreign key relationship
		/// </summary>
		public bool IsJunctionTable(TableSchema table)
		{
			if (table.PrimaryKey == null || table.PrimaryKey.MemberColumns.Count == 0)
			{
				//Response.WriteLine(string.Format("IsJunctionTable: The table {0} doesn't have a primary key.", table.Name));
				return false;
				
			}
			if (table.PrimaryKey.MemberColumns.Count == 1)
			{
				return false;				
			}
						
			for (int i=0;i < table.PrimaryKey.MemberColumns.Count; i++){
				if (!table.PrimaryKey.MemberColumns[i].IsForeignKeyMember)
					return false;
			}
			return true;			
		}
		
		/*
		
		///<summary>
		/// returns true all primary key columns have is a foreign key relationship
		/// </summary>
		public bool Many2ManyCompliant(TableKeySchema primaryKey)
		{
			// une seul column vers la table pivot
			if (primaryKey.ForeignKeyMemberColumns.Count != 1)
				return false;
			
			// une seul column venant de la table primaire
			if (primaryKey.PrimaryKeyMemberColumns.Count != 1)
				return false;
			
			
			// Junction table require a primary on two columns
			if (primaryKey.ForeignKeyTable.PrimaryKey == null || primaryKey.ForeignKeyTable.PrimaryKey.MemberColumns.Count != 2)
			{
				//Response.WriteLine(string.Format("IsJunctionTable: The table {0} doesn't have a primary key.", table.Name));
				return false;
			}
			
			// And each primary key member columns must be part of relation
			for (int i=0;i < primaryKey.ForeignKeyTable.PrimaryKey.MemberColumns.Count; i++)
			{
				if (!primaryKey.ForeignKeyTable.PrimaryKey.MemberColumns[i].IsForeignKeyMember)
					return false;
				
				//if (!primaryKey.ForeignKeyTable.PrimaryKey.MemberColumns[i].IsPrimaryKeyMember)
				//	return false;
			}
			
			// the foreign column of the relation must be a junction table's primary key member's column
			//if (primaryKey.ForeignKeyTable.PrimaryKey.MemberColumns[0] != primaryKey.ForeignKeyMemberColumns[0] && primaryKey.ForeignKeyTable.PrimaryKey.MemberColumns[1] != primaryKey.ForeignKeyMemberColumns[0])
			//{
			//	return false;
			//}
			
			if (!primaryKey.ForeignKeyMemberColumns[0].IsPrimaryKeyMember)	return false;
			
			return true;			
		}
*/

/*
		public bool IsJunctionTable(TableSchema table)
			{
				bool RetValue;
				ColumnSchemaCollection keys;
				RetValue = false;
				if(table.PrimaryKey.MemberColumns.Count > 1)
				{
					keys = new ColumnSchemaCollection(SourceTable.PrimaryKey.MemberColumns);
					foreach(ColumnSchema primarykey in keys)
					{
						if(primarykey.IsForeignKeyMember)
						{
							RetValue = true;
						}
						else
						{
							RetValue = false;
							break;
						}
					} 
				}
				return RetValue;
			}
*/
		///<summary>
		///	Returns whether or not a table key is a one to one 
		/// relationship with another table.
		/// WARNING: Assumes first column is the FK.
		///</summary>
		public bool IsRelationOneToOne(TableKeySchema keyschema)
		{
			foreach(IndexSchema i in keyschema.ForeignKeyTable.Indexes)
			{
				if((i.MemberColumns[0].Name == keyschema.ForeignKeyMemberColumns[0].Name) && (!IsJunctionTable(keyschema.ForeignKeyTable)))
				{
					if(i.IsUnique || i.IsPrimaryKey)
					{
						return true;
					}
					else
					{
						return false;
					}
				}	
			}
			return false;
		}
		
		public ColumnSchemaCollection GetRelationKeyColumns(TableKeySchemaCollection fkeys, IndexSchemaCollection indexes)
		{
			System.Diagnostics.Debugger.Break();
			for (int j=0; j < fkeys.Count; j++)
			{
				bool skipkey = false;
				foreach(IndexSchema i in indexes)
				{
					if(i.MemberColumns.Contains(fkeys[j].ForeignKeyMemberColumns[0]))
						skipkey = true;			
				}
				if(skipkey)
					continue;

				return fkeys[j].ForeignKeyMemberColumns;
			}
			return new ColumnSchemaCollection();
		}
		
		/*
		///<summary>
		///	TODO : Returns any string mutations that will be used for a string.
		/// Ex. singular string to be used within the template 
		///     All spaces from table or column names removed
		///</summary>
		public static string CleanName(string s){
			return s.Replace(" ", string.Empty);
		}
		*/
		

		///<summary>
		///  Store the most recent SourceTable of the templates,
		///  Used to clean up upon new SourceTable execution.  
		///</summary>
		[BrowsableAttribute(false)]
		public  string CurrentTable {
			get{return _currentTable;}
			set {_currentTable = value;}
		}
		
		///<summary>
		///  Store the most recent
		///  Used to keep track of which childcollections have been rendered
		///  Eliminates the Dupes.
		///</summary>
		[BrowsableAttribute(false)]
		public  System.Collections.ArrayList RenderedChildren {
			get{return _renderedChildren;}
			set {_renderedChildren = value;}
		}
		
		
		///<summary>
		/// Child Collection RelationshipType Enum
		///</summary>
		[BrowsableAttribute(false)]
		public enum RelationshipType{
			None = 0,
			OneToOne = 1,
			OneToMany = 2,
			ManyToOne = 3,
			ManyToMany = 4
		}
		
		///<summary>
		///	Child relationship structure information and their <see cref="RelationshipType" />
		/// to store in the ChildCollections ArrayList
		///</summary>
		public class CollectionInfo {
			public string CleanName;
			public string PkColName;
			public string PkIdxName;
			public string FkColName;
			public string FkIdxName;
			public string PrimaryTable;
			public string SecondaryTable;
			public string SecondaryTablePkColName;
			public string JunctionTable;
			public string CollectionName = string.Empty;
			public string CallParams = string.Empty;
			public string PropertyString = string.Empty;
			public string GetByKeysName = string.Empty;
			public RelationshipType CollectionRelationshipType;	
			public TableKeySchema TableKey = null;
		}
	#endregion
	
		#region generate sentence
		
		#endregion
		
		public string GetCallerParameters( ParameterSchemaCollection parameters) 
		{ 
			string output = ""; 
			for (int i = 0; i < parameters.Count; i++) 
			{ 
				output += GetPrivateName(parameters[i].Name); 
				if (i < parameters.Count - 1) 
				{ 
					output += ", "; 
				} 
			} 
			return output; 
		}
	}
}
