namespace JX.Infrastructure.Field
{
	/// <summary>
	/// 字段类型，用于指定系统中字段用户控件的类型。
	/// </summary>
	public enum FieldType
	{
		/// <summary>
		/// 未设置
		/// </summary>
		None,
		/// <summary>
		/// 单行文本
		/// </summary>
		TextType,
		/// <summary>
		/// 多行文本（不支持HTML）
		/// </summary>
		MultipleTextType,
		/// <summary>
		/// 多行文本（支持HTML）
		/// </summary>
		MultipleHtmlTextType,
		/// <summary>
		/// 选项
		/// </summary>
		ListBoxType,
		/// <summary>
		/// 数字
		/// </summary>
		NumberType,
		/// <summary>
		/// 货币
		/// </summary>
		MoneyType,
		/// <summary>
		/// 日期和时间
		/// </summary>
		DateTimeType,
		/// <summary>
		/// 查阅项
		/// </summary>
		LookType,
		/// <summary>
		/// 超链接
		/// </summary>
		LinkType,
		/// <summary>
		/// 是/否（复选框）
		/// </summary>
		BoolType,
		/// <summary>
		/// 
		/// </summary>
		CountType,
		/// <summary>
		/// 图片
		/// </summary>
		PictureType,
		/// <summary>
		/// 文件
		/// </summary>
		FileType,
		/// <summary>
		/// 大文件
		/// </summary>
		BigFileType,
		/// <summary>
		/// 颜色代码
		/// </summary>
		ColorType,
		/// <summary>
		/// 节点
		/// </summary>
		NodeType,
		/// <summary>
		/// 模板
		/// </summary>
		TemplateType,
		/// <summary>
		/// 虚链接
		/// </summary>
		InfoType,
		/// <summary>
		/// 作者
		/// </summary>
		AuthorType,
		/// <summary>
		/// 来源
		/// </summary>
		SourceType,
		/// <summary>
		/// 关键字
		/// </summary>
		KeywordType,
		/// <summary>
		/// 运行平台
		/// </summary>
		OperatingType,
		/// <summary>
		/// 风格
		/// </summary>
		SkinType,
		/// <summary>
		/// 下载服务器
		/// </summary>
		DownServerType,
		/// <summary>
		/// 专题
		/// </summary>
		SpecialType,
		/// <summary>
		/// 状态
		/// </summary>
		StatusType,
		/// <summary>
		/// 
		/// </summary>
		ProductType,
		/// <summary>
		/// 厂商
		/// </summary>
		Producer,
		/// <summary>
		/// 品牌
		/// </summary>
		Trademark,
		/// <summary>
		/// 内容
		/// </summary>
		ContentType,
		/// <summary>
		/// 标题
		/// </summary>
		TitleType,
		/// <summary>
		/// 多图片
		/// </summary>
		MultiplePhotoType,
		/// <summary>
		/// 商品属性（例：尺寸）
		/// </summary>
		Property,
		/// <summary>
		/// 商品款式（例：颜色）
		/// </summary>
		ProductStyle,
		/// <summary>
		/// 选择用户
		/// </summary>
		SelectUser,
		/// <summary>
		/// IP
		/// </summary>
		IPType,
		/// <summary>
		/// 会员名
		/// </summary>
		UserNameType,
		/// <summary>
		/// 行政区域类型（展示形式：国、省、市、区（DropDownList））
		/// </summary>
		RegionType,
		/// <summary>
		/// 行政区域类型(多选)（展示形式：选择多个省、市、区到一个ListBox中展示）
		/// </summary>
		RegionTypeSelect,
		/// <summary>
		/// 行政区划(关联下拉选项)
		/// </summary>
		RegionTypeDropDown,
		/// <summary>
		/// 行政区域类型（展示形式：国、省、市、区（DropDownList）、地址（TextBox））
		/// </summary>
		RegionTypeText,
		/// <summary>
		/// 行政区划(5级)
		/// </summary>
		RegionTypeFive,
		/// <summary>
		/// 验证码
		/// </summary>
		ValidateCodeType,
		/// <summary>
		/// 行业类别类型
		/// </summary>
		IndustryCategory,
		/// <summary>
		/// 数据绑定选项
		/// </summary>
		ListBoxDataType,
		/// <summary>
		/// 选项(详情)
		/// </summary>
		ListBoxIntroType,
		/// <summary>
		/// 节点（多选）
		/// </summary>
		NodeCategory,
		/// <summary>
		/// 自动编号
		/// </summary>
		NumBuilder,
		/// <summary>
		/// 二维码
		/// </summary>
		QRCodeType
	}
}
