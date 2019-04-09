JX.Infrastructure								基础设施层
	Common										一些常用的操作帮助类
		Extensions								系统扩展模块
			ExtensionsDI							扩展DI
			MyHttpContext							对Microsoft.AspNetCore.Http.HttpContext对象的扩展。
			LambdaExpressionExtensions				对Lambda表达式的扩展
			RequestExtensions						HttpRequest的扩展类

		Files									文件操作
			FileHelper								文件帮助类：对文件、目录进行操作
			FileMethod								文件操作类别枚举

		Serialize								序列化模块
			SerializeType							序列化类型
			ISerializer								序列化者接口
			JsonSerializer							Json 序列化/反序列化。
			XmlSerializer							Xml 序列化/反序列化。
			SerializerHelper						序列化帮助类

		Config									配置文件模块
			ConfigHelper							配置文件读写帮助类:配置文件必须存放在网站程序根目录的config目录下
			IPLockConfig							IP锁定配置类
			QAConfig								问答配置文件类
			RedisConfig								Redis使用配置文件
			ScoreRankConfig							积分等级配置文件类
			ServiceCenterConfig						服务中心配置文件类
			ShopConfig								B2C商店配置文件类
			SiteConfig								网站信息配置类
			SiteOptionConfig						网站操作参数配置文件类
			SmsConfig								手机短信配置文件类
			UploadFilesConfig						上传文件配置类
			UserConfig								会员参数配置文件类

		Cache									缓存模块
			CacheHelper								缓存帮助类
			ICacheService							缓存接口，所有实现都继承此接口
			MemoryCacheService						通过.net core自带的内存缓存(MemoryCache)实现缓存接口。MemoryCache为单机缓存。
			RedisCacheService						通过redis来实现分布式缓存

		Cookie									cookie模块
			CookieHelper							Cookie帮助类

		CookieShare								cookie共享模块
			XmlRepository							用于多个应用程序之间共享Cookie

		DataValidate							数据的转换、验证与安全检查
			DataConverter							数据类型转换类:将字符串或对象转换为指定类型的格式,并检查输入是否为空,作相应处理
			DataSecurity							数据安全检查相关类:转换JS,标签字符,XML标识符,过滤SQL非法字符,SQL关键字,生成随机文件名,安全取数据元素值等.
			DataValidator							数据验证类:验证字符串是否合法的数字,IP,邮编,URL,EMAIL,城市区域

		Encrypt									系统加密基础库
			AesRijndael								Aes加密
			HmacSha1								HmacSha1加密
			Md5										MD5加密类
			Sha1									Sha1加密类

		Enum									枚举模块
			EnumHelper								枚举工具：生成枚举项的描述
			EnumItem								枚举项

		ImageTools								缩略图、水印模块
			Thumbs									制作缩略图类
			ThumbsConfig							缩略图参数配置文件类
			ThumbsMode								缩略图模式
			WaterMark								水印制作类
			WaterMarkConfig							水印配置文件类
			WaterMarkImage							水印图片的配置文件类
			WaterMarkText							水印文字的配置文件类
			VierificationCodeHelper					验证码帮助类

		IP										IP模块
			IPHelper								IP操作帮助类

		JS										JS模块
			JavaScriptWriter						实现客户端脚本输出
			
		Mail									邮件模块
			AuthenticationType						邮件验证类型 枚举
			MailConfig								邮件配置文件类
			MailState								枚举 邮件状态
			MailSender								邮件发送类，定义了发送邮件的属性和方法。通过MailKit实现。

		Random									随机数模块
			RandomHelper							随机数和随机字符管理类

		Server									服务器信息模块
			DataBaseInfo							SQL数据库信息
			ServerInfo								服务器信息
			UserAgentInfo							客户端用户代理信息
			WebProcessInfo							web 性能诊断类，定义了和当前系统相关的常用属性和方法。如CPU使用率、物理内存量等。
			ServerHelper							服务器信息实用类

		String									字符串操作模块
			SpellOptions							枚举 中文拼音操作
			StringFilterOptions						枚举 字符串过滤选项
			StringHelper							字符串辅助类
			ChineseSpell							中文拼音类

		Xml										xml操作模块
			XmlType									XML文件类型
			XmlScheme								自定义xml节点元信息类
			XmlHelper								xml文件帮助类

		Zip										压缩、解压模块
			ZipHelper								压缩帮助类

		Pager									分页模块
			PagerModel								分页数据模型

	Field										系统中会用到的字段操作模块
		FieldType									字段类型，用于指定系统中字段用户控件的类型。
		FieldInfo									字段信息的实体类
		FieldInfoComparer							字段信息比较器:用于泛型集合排序

	Data										数据库操作模块
		Parameter									通用数据访问参数对象
		Parameters									通用数据访问参数对象集合:已经包含了常规列表参数集合
		ListParameters								列表查询参数
		DateStrings									日期查询函数常量集，返回常用的日期函数的SQL语句
		Query										数据查询语句生成器

	Log											日志模块
		Enum.cs										定义需要用到的各种枚举
		LogInfo.cs									日志信息类
		ILog.cs										日志接口，主要用于添加、修改、删除日志信息和得到日志信息列表。
		FileLog										文本文件日志类，只实现了添加方法。
		LogFactory.cs								日志工厂类，通过反射机制动态的创建日志类

	Framework									网站系统相关框架
		IdentityResult								身份结果类，用于注册、登录后返回结果使用。
		Authorize									身份认证相关
			AdminAuthorizeAttribute						后台管理员授权特性
		Filter										过滤器模块
			ModelStateActionFilter						页面统一模型验证处理

	TencentCaptcha								腾讯验证码相关工具类
		TencentCaptchaConfig						腾讯验证码使用配置文件
		TencentCaptchaResult						腾讯验证码返回信息类
		TencentCaptchaUtility						腾讯验证码实用工具类

	Utility										常用函数
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
MyADO											ADO.NET数据操作类
	INullableReader									可空数据读取器接口
	NullableDataReader								可空数据读取器
	IDBOperator										通用数据库操作接口
	SqlDBOperator									实现SQLServer数据库操作
	DBManagerFactory								数据库管理工厂类
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
JX.Core.Entity										实体类层，主要通过代码生成器生成，包括常用的枚举类型
	Entity											实体类文件夹
	CommonService									公共服务相关实体类文件夹
	NodesService									网站栏目相关实体类文件夹
	AdminService									网站后台管理员相关实体类文件夹
	UserService										网站前台会员相关实体类文件夹
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
JX.Core											框架核心层，所有的接口、抽象类都放在这一层
	IUnitOfWork										工作单元。提供一个保存方法，它可以对调用层公开，为了减少连库次数
	IRepository										仓储接口(基于EF)，定义了增删改查方法签名
	IRepositories									实体类仓储接口文件夹，主要通过代码生成器生成
	IRepositoryADO									仓储接口(基于ADO.NET)，定义了增删改查方法签名
	IRepositoriesADO								实体类仓储接口文件夹，主要通过代码生成器生成
	CommonService									公共服务接口文件夹，主要是存放一些系统公用的服务类接口扩展
	NodesService									网站栏目相关仓储类接口扩展文件夹
	AdminService									网站后台管理员相关仓储类接口扩展文件夹
	UserService										网站前台会员相关仓储类接口扩展文件夹
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
JX.ADO											通过ADO.NET对仓储接口的实现，各个模块按文件夹分开
	RepositoryADO									仓储接口的具体实现，主要通过代码生成器生成
	CommonService									公共服务接口实现类文件夹
	AdminService									网站后台管理员相关服务接口实现类文件夹
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
JX.EF											通过EF对仓储接口的实现，各个模块按文件夹分开
	ApplicationDbContext.cs							EF数据操作上下文
	UnitOfWork.cs									工作单元实现类
	Repository.cs									仓储通用实现类
	Repository										仓储接口的具体实现文件夹，主要通过代码生成器生成
	CommonService									公共服务接口实现类文件夹
	AdminService									网站后台管理员相关服务接口实现类文件夹
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
JX.Application									应用层，各个模块按文件夹分开
	IServiceApp										应用层服务通用接口
	IServicesApp									应用层服务接口文件夹，主要通过代码生成器生成
	ServicesApp										应用层服务接口实现的文件夹，主要通过代码生成器生成
	CommonService									应用层公共服务接口实现类文件夹
	NodesService									应用层对网站节点相关服务接口实现类文件夹
	AdminService									应用层对网站后台管理员相关服务接口实现类文件夹
	UserService										应用层对网站前台会员相关服务接口实现类文件夹
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
JXWebHost										界面展示层
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
在更新dotnet core新的类库后运行程序提示如下的错误：
Can not find runtime target for framework '.NETCoreAPP, Version=v1.0' compatible with one of the target runtimes: 'win10-x64, win81-x64, win8-x64, win7-x64'. Possible causes:
The project has not been restored or restore failed -run 'dotnet restore'
The project does not list one of 'win10-x64, win81-x64, win7-x64' in the 'runtimes'

解决方法：在项目的 project.json 文件添加以下的节点 重新编译即可:
"runtimes":{
"win10-x64":{}
}
或者 可以修改Microsoft.NETCore.App节点的内容如下，Version的版本请对应你的dotnet core版本号
"Microsoft.NETCore.App":{
"type":"platform",
"version":"1.0.1"
}
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
在nuget控制台，执行以下命令，生成实体类。需要引用包“Microsoft.EntityFrameworkCore.Tools.DotNet 1.0.0”
Scaffold-DbContext "server=.;database=JXIPS2_1;uid=sa;pwd=abc123!@#;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Data\Entity
