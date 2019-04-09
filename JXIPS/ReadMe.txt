JX.Infrastructure								������ʩ��
	Common										һЩ���õĲ���������
		Extensions								ϵͳ��չģ��
			ExtensionsDI							��չDI
			MyHttpContext							��Microsoft.AspNetCore.Http.HttpContext�������չ��
			LambdaExpressionExtensions				��Lambda���ʽ����չ
			RequestExtensions						HttpRequest����չ��

		Files									�ļ�����
			FileHelper								�ļ������ࣺ���ļ���Ŀ¼���в���
			FileMethod								�ļ��������ö��

		Serialize								���л�ģ��
			SerializeType							���л�����
			ISerializer								���л��߽ӿ�
			JsonSerializer							Json ���л�/�����л���
			XmlSerializer							Xml ���л�/�����л���
			SerializerHelper						���л�������

		Config									�����ļ�ģ��
			ConfigHelper							�����ļ���д������:�����ļ�����������վ�����Ŀ¼��configĿ¼��
			IPLockConfig							IP����������
			QAConfig								�ʴ������ļ���
			RedisConfig								Redisʹ�������ļ�
			ScoreRankConfig							���ֵȼ������ļ���
			ServiceCenterConfig						�������������ļ���
			ShopConfig								B2C�̵������ļ���
			SiteConfig								��վ��Ϣ������
			SiteOptionConfig						��վ�������������ļ���
			SmsConfig								�ֻ����������ļ���
			UploadFilesConfig						�ϴ��ļ�������
			UserConfig								��Ա���������ļ���

		Cache									����ģ��
			CacheHelper								���������
			ICacheService							����ӿڣ�����ʵ�ֶ��̳д˽ӿ�
			MemoryCacheService						ͨ��.net core�Դ����ڴ滺��(MemoryCache)ʵ�ֻ���ӿڡ�MemoryCacheΪ�������档
			RedisCacheService						ͨ��redis��ʵ�ֲַ�ʽ����

		Cookie									cookieģ��
			CookieHelper							Cookie������

		CookieShare								cookie����ģ��
			XmlRepository							���ڶ��Ӧ�ó���֮�乲��Cookie

		DataValidate							���ݵ�ת������֤�밲ȫ���
			DataConverter							��������ת����:���ַ��������ת��Ϊָ�����͵ĸ�ʽ,����������Ƿ�Ϊ��,����Ӧ����
			DataSecurity							���ݰ�ȫ��������:ת��JS,��ǩ�ַ�,XML��ʶ��,����SQL�Ƿ��ַ�,SQL�ؼ���,��������ļ���,��ȫȡ����Ԫ��ֵ��.
			DataValidator							������֤��:��֤�ַ����Ƿ�Ϸ�������,IP,�ʱ�,URL,EMAIL,��������

		Encrypt									ϵͳ���ܻ�����
			AesRijndael								Aes����
			HmacSha1								HmacSha1����
			Md5										MD5������
			Sha1									Sha1������

		Enum									ö��ģ��
			EnumHelper								ö�ٹ��ߣ�����ö���������
			EnumItem								ö����

		ImageTools								����ͼ��ˮӡģ��
			Thumbs									��������ͼ��
			ThumbsConfig							����ͼ���������ļ���
			ThumbsMode								����ͼģʽ
			WaterMark								ˮӡ������
			WaterMarkConfig							ˮӡ�����ļ���
			WaterMarkImage							ˮӡͼƬ�������ļ���
			WaterMarkText							ˮӡ���ֵ������ļ���
			VierificationCodeHelper					��֤�������

		IP										IPģ��
			IPHelper								IP����������

		JS										JSģ��
			JavaScriptWriter						ʵ�ֿͻ��˽ű����
			
		Mail									�ʼ�ģ��
			AuthenticationType						�ʼ���֤���� ö��
			MailConfig								�ʼ������ļ���
			MailState								ö�� �ʼ�״̬
			MailSender								�ʼ������࣬�����˷����ʼ������Ժͷ�����ͨ��MailKitʵ�֡�

		Random									�����ģ��
			RandomHelper							�����������ַ�������

		Server									��������Ϣģ��
			DataBaseInfo							SQL���ݿ���Ϣ
			ServerInfo								��������Ϣ
			UserAgentInfo							�ͻ����û�������Ϣ
			WebProcessInfo							web ��������࣬�����˺͵�ǰϵͳ��صĳ������Ժͷ�������CPUʹ���ʡ������ڴ����ȡ�
			ServerHelper							��������Ϣʵ����

		String									�ַ�������ģ��
			SpellOptions							ö�� ����ƴ������
			StringFilterOptions						ö�� �ַ�������ѡ��
			StringHelper							�ַ���������
			ChineseSpell							����ƴ����

		Xml										xml����ģ��
			XmlType									XML�ļ�����
			XmlScheme								�Զ���xml�ڵ�Ԫ��Ϣ��
			XmlHelper								xml�ļ�������

		Zip										ѹ������ѹģ��
			ZipHelper								ѹ��������

		Pager									��ҳģ��
			PagerModel								��ҳ����ģ��

	Field										ϵͳ�л��õ����ֶβ���ģ��
		FieldType									�ֶ����ͣ�����ָ��ϵͳ���ֶ��û��ؼ������͡�
		FieldInfo									�ֶ���Ϣ��ʵ����
		FieldInfoComparer							�ֶ���Ϣ�Ƚ���:���ڷ��ͼ�������

	Data										���ݿ����ģ��
		Parameter									ͨ�����ݷ��ʲ�������
		Parameters									ͨ�����ݷ��ʲ������󼯺�:�Ѿ������˳����б��������
		ListParameters								�б��ѯ����
		DateStrings									���ڲ�ѯ���������������س��õ����ں�����SQL���
		Query										���ݲ�ѯ���������

	Log											��־ģ��
		Enum.cs										������Ҫ�õ��ĸ���ö��
		LogInfo.cs									��־��Ϣ��
		ILog.cs										��־�ӿڣ���Ҫ������ӡ��޸ġ�ɾ����־��Ϣ�͵õ���־��Ϣ�б�
		FileLog										�ı��ļ���־�ֻ࣬ʵ������ӷ�����
		LogFactory.cs								��־�����࣬ͨ��������ƶ�̬�Ĵ�����־��

	Framework									��վϵͳ��ؿ��
		IdentityResult								��ݽ���࣬����ע�ᡢ��¼�󷵻ؽ��ʹ�á�
		Authorize									�����֤���
			AdminAuthorizeAttribute						��̨����Ա��Ȩ����
		Filter										������ģ��
			ModelStateActionFilter						ҳ��ͳһģ����֤����

	TencentCaptcha								��Ѷ��֤����ع�����
		TencentCaptchaConfig						��Ѷ��֤��ʹ�������ļ�
		TencentCaptchaResult						��Ѷ��֤�뷵����Ϣ��
		TencentCaptchaUtility						��Ѷ��֤��ʵ�ù�����

	Utility										���ú���
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
MyADO											ADO.NET���ݲ�����
	INullableReader									�ɿ����ݶ�ȡ���ӿ�
	NullableDataReader								�ɿ����ݶ�ȡ��
	IDBOperator										ͨ�����ݿ�����ӿ�
	SqlDBOperator									ʵ��SQLServer���ݿ����
	DBManagerFactory								���ݿ��������
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
JX.Core.Entity										ʵ����㣬��Ҫͨ���������������ɣ��������õ�ö������
	Entity											ʵ�����ļ���
	CommonService									�����������ʵ�����ļ���
	NodesService									��վ��Ŀ���ʵ�����ļ���
	AdminService									��վ��̨����Ա���ʵ�����ļ���
	UserService										��վǰ̨��Ա���ʵ�����ļ���
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
JX.Core											��ܺ��Ĳ㣬���еĽӿڡ������඼������һ��
	IUnitOfWork										������Ԫ���ṩһ�����淽���������ԶԵ��ò㹫����Ϊ�˼����������
	IRepository										�ִ��ӿ�(����EF)����������ɾ�Ĳ鷽��ǩ��
	IRepositories									ʵ����ִ��ӿ��ļ��У���Ҫͨ����������������
	IRepositoryADO									�ִ��ӿ�(����ADO.NET)����������ɾ�Ĳ鷽��ǩ��
	IRepositoriesADO								ʵ����ִ��ӿ��ļ��У���Ҫͨ����������������
	CommonService									��������ӿ��ļ��У���Ҫ�Ǵ��һЩϵͳ���õķ�����ӿ���չ
	NodesService									��վ��Ŀ��زִ���ӿ���չ�ļ���
	AdminService									��վ��̨����Ա��زִ���ӿ���չ�ļ���
	UserService										��վǰ̨��Ա��زִ���ӿ���չ�ļ���
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
JX.ADO											ͨ��ADO.NET�Բִ��ӿڵ�ʵ�֣�����ģ�鰴�ļ��зֿ�
	RepositoryADO									�ִ��ӿڵľ���ʵ�֣���Ҫͨ����������������
	CommonService									��������ӿ�ʵ�����ļ���
	AdminService									��վ��̨����Ա��ط���ӿ�ʵ�����ļ���
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
JX.EF											ͨ��EF�Բִ��ӿڵ�ʵ�֣�����ģ�鰴�ļ��зֿ�
	ApplicationDbContext.cs							EF���ݲ���������
	UnitOfWork.cs									������Ԫʵ����
	Repository.cs									�ִ�ͨ��ʵ����
	Repository										�ִ��ӿڵľ���ʵ���ļ��У���Ҫͨ����������������
	CommonService									��������ӿ�ʵ�����ļ���
	AdminService									��վ��̨����Ա��ط���ӿ�ʵ�����ļ���
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
JX.Application									Ӧ�ò㣬����ģ�鰴�ļ��зֿ�
	IServiceApp										Ӧ�ò����ͨ�ýӿ�
	IServicesApp									Ӧ�ò����ӿ��ļ��У���Ҫͨ����������������
	ServicesApp										Ӧ�ò����ӿ�ʵ�ֵ��ļ��У���Ҫͨ����������������
	CommonService									Ӧ�ò㹫������ӿ�ʵ�����ļ���
	NodesService									Ӧ�ò����վ�ڵ���ط���ӿ�ʵ�����ļ���
	AdminService									Ӧ�ò����վ��̨����Ա��ط���ӿ�ʵ�����ļ���
	UserService										Ӧ�ò����վǰ̨��Ա��ط���ӿ�ʵ�����ļ���
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
JXWebHost										����չʾ��
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
�ڸ���dotnet core�µ��������г�����ʾ���µĴ���
Can not find runtime target for framework '.NETCoreAPP, Version=v1.0' compatible with one of the target runtimes: 'win10-x64, win81-x64, win8-x64, win7-x64'. Possible causes:
The project has not been restored or restore failed -run 'dotnet restore'
The project does not list one of 'win10-x64, win81-x64, win7-x64' in the 'runtimes'

�������������Ŀ�� project.json �ļ�������µĽڵ� ���±��뼴��:
"runtimes":{
"win10-x64":{}
}
���� �����޸�Microsoft.NETCore.App�ڵ���������£�Version�İ汾���Ӧ���dotnet core�汾��
"Microsoft.NETCore.App":{
"type":"platform",
"version":"1.0.1"
}
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
��nuget����̨��ִ�������������ʵ���ࡣ��Ҫ���ð���Microsoft.EntityFrameworkCore.Tools.DotNet 1.0.0��
Scaffold-DbContext "server=.;database=JXIPS2_1;uid=sa;pwd=abc123!@#;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Data\Entity
