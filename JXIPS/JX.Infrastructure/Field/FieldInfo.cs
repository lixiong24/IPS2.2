using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace JX.Infrastructure.Field
{
	/// <summary>
	/// 字段信息的实体类
	/// </summary>
	[XmlRoot("FieldInfo")]
	public class FieldInfo
	{
		/// <summary>
		/// 表示空字段
		/// </summary>
		public static readonly FieldInfo NullFieldInfoOjbect = new NullFieldInfo();

		#region 属性
		private string m_FieldName;
		/// <summary>
		/// 字段名称
		/// </summary>
		public string FieldName
		{
			get
			{
				return this.m_FieldName;
			}
			set
			{
				this.m_FieldName = value;
			}
		}

		private string m_FieldAlias;
		/// <summary>
		/// 字段别名
		/// </summary>
		public string FieldAlias
		{
			get
			{
				return this.m_FieldAlias;
			}
			set
			{
				this.m_FieldAlias = value;
			}
		}

		private string m_Tips;
		/// <summary>
		/// 字段提示
		/// </summary>
		public string Tips
		{
			get
			{
				return this.m_Tips;
			}
			set
			{
				this.m_Tips = value;
			}
		}

		private string m_Description;
		/// <summary>
		/// 字段描述
		/// </summary>
		public string Description
		{
			get
			{
				return this.m_Description;
			}
			set
			{
				this.m_Description = value;
			}
		}

		private bool m_Disabled;
		/// <summary>
		/// 是否禁用
		/// </summary>
		[XmlAttribute("Disabled")]
		public bool Disabled
		{
			get
			{
				return this.m_Disabled;
			}
			set
			{
				this.m_Disabled = value;
			}
		}

		private bool m_EnableNull;
		/// <summary>
		/// 是否允许字段有空值(是否必填)
		/// </summary>
		public bool EnableNull
		{
			get
			{
				return this.m_EnableNull;
			}
			set
			{
				this.m_EnableNull = value;
			}
		}

		private bool m_EnableShowOnSearchForm;
		/// <summary>
		/// 是否在搜索表单显示
		/// </summary>
		public bool EnableShowOnSearchForm
		{
			get
			{
				return this.m_EnableShowOnSearchForm;
			}
			set
			{
				this.m_EnableShowOnSearchForm = value;
			}
		}

		private string m_DefaultValue;
		/// <summary>
		/// 字段默认值
		/// </summary>
		public string DefaultValue
		{
			get
			{
				return this.m_DefaultValue;
			}
			set
			{
				this.m_DefaultValue = value;
			}
		}

		private int m_FieldLevel;
		/// <summary>
		/// 字段等级：0：网站系统内置字段；1：客户自定义字段；
		/// </summary>
		public int FieldLevel
		{
			get
			{
				return this.m_FieldLevel;
			}
			set
			{
				this.m_FieldLevel = value;
			}
		}

		private FieldType m_FieldType;
		/// <summary>
		/// 字段类型
		/// </summary>
		public FieldType FieldType
		{
			get
			{
				return this.m_FieldType;
			}
			set
			{
				this.m_FieldType = value;
			}
		}

		private int m_OrderId;
		/// <summary>
		/// 排序ID
		/// </summary>
		[XmlAttribute("OrderId")]
		public int OrderId
		{
			get
			{
				return this.m_OrderId;
			}
			set
			{
				this.m_OrderId = value;
			}
		}

		private string m_Id;
		/// <summary>
		/// ID
		/// </summary>
		[XmlAttribute("Id")]
		public string Id
		{
			get
			{
				return this.m_Id;
			}
			set
			{
				this.m_Id = value.ToLower();
			}
		}

		private bool m_IsNull;
		/// <summary>
		/// 是否空对象
		/// </summary>
		public bool IsNull
		{
			get
			{
				return this.m_IsNull;
			}
		}

		private Collection<string> m_Settings;
		/// <summary>
		/// 得到用于记录字段的特定信息。
		/// 如：数字字段的最大值、文本字段的文本框长度、上传字段的允许类型等。
		/// </summary>
		public Collection<string> Settings
		{
			get
			{
				return this.m_Settings;
			}
		}
		#endregion

		/// <summary>
		/// 构造:初始化设置集
		/// </summary>
		public FieldInfo()
		{
			if (this.m_Settings == null)
			{
				this.m_Settings = new Collection<string>();
			}
			this.m_IsNull = false;
			this.m_Settings.Clear();
		}

		/// <summary>
		///  拷贝设置
		/// </summary>
		/// <param name="settings"></param>
		public void CopyToSettings(Collection<string> settings)
		{
			this.m_Settings = settings;
		}

		/// <summary>
		/// 表示空字段实体类
		/// </summary>
		private class NullFieldInfo : FieldInfo
		{
			internal NullFieldInfo()
			{
				base.m_IsNull = true;
			}
		}
	}
}
