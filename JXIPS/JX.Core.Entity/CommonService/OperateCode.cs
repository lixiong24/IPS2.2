using System;
using System.Collections.Generic;
using System.Text;

namespace JX.Core.Entity
{
	/// <summary>
	/// 权限码
	/// </summary>
	public enum OperateCode
	{
		/// <summary>
		/// 附件管理
		/// </summary>
		AccessoriesManage = 101011000,
		/// <summary>
		/// 广告管理
		/// </summary>
		AdManage = 105001000,
		AdminCategoryManage = 112001003,
		AdminHelpUrlManage = 112001004,
		/// <summary>
		/// 管理员管理
		/// </summary>
		AdministratorManage = 104002010,
		/// <summary>
		/// 管理员管理（全部）
		/// </summary>
		AdministratorSuperManage = 104002000,
		/// <summary>
		/// 作者管理
		/// </summary>
		AuthorManage = 101011040,
		/// <summary>
		/// 银行账户管理
		/// </summary>
		BankAccountManage = 102007070,
		/// <summary>
		/// 资金明细管理、汇款确认
		/// </summary>
		BankrollItemList = 102004010,
		/// <summary>
		/// 缓存管理
		/// </summary>
		CacheManage = 105005000,
		/// <summary>
		/// 添加回访记录
		/// </summary>
		CallAdd = 103005102,
		/// <summary>
		/// 回访管理
		/// </summary>
		CallManage = 103005100,
		/// <summary>
		/// 修改所有回访记录
		/// </summary>
		CallModifyAll = 103005104,
		/// <summary>
		/// 修改属于自己的回访记录
		/// </summary>
		CallModifyOwn = 103005103,
		/// <summary>
		/// 查看回访记录
		/// </summary>
		CallView = 103005101,
		/// <summary>
		/// 充值卡管理
		/// </summary>
		CardManage = 102001010,
		/// <summary>
		/// 就业指导中心
		/// </summary>
		CareersCenter = 106000000,
		/// <summary>
		/// 就业管理
		/// </summary>
		CareersManage = 106003001,
		/// <summary>
		/// 归档内容
		/// </summary>
		CategoryArchivingInfoManage = 101001060,
		/// <summary>
		/// 生成HTML管理
		/// </summary>
		CategoryHtmlInfoManage = 101001040,
		/// <summary>
		/// 内容管理
		/// </summary>
		CategoryInfoManage = 101001010,
		/// <summary>
		/// 高级查询（内容管理）
		/// </summary>
		CategoryInfoSearch = 101001080,
		/// <summary>
		/// 回收站管理（内容管理）
		/// </summary>
		CategoryRecycleInfoManage = 101001030,
		/// <summary>
		/// 签收管理
		/// </summary>
		CategorySigninInfoManage = 101001050,
		/// <summary>
		/// 进入会员中心
		/// </summary>
		ChangeUser = 104010000,
		/// <summary>
		/// 当前节点及子节点管理
		/// </summary>
		ChildNodesManage = 101005002,
		/// <summary>
		/// 数据字典管理（客户关系管理）
		/// </summary>
		ChoicesetCrmManage = 103009000,
		/// <summary>
		/// 数据字典管理（系统设置）
		/// </summary>
		ChoicesetManage = 103005000,
		/// <summary>
		/// 数据字典管理（招聘管理）
		/// </summary>
		ChoicesetRecruitmentManage = 106009000,
		/// <summary>
		/// 类别管理（投诉管理）
		/// </summary>
		ClassManagers = 107003006,
		/// <summary>
		/// 添加客户（客户关系管理）
		/// </summary>
		ClientAdd = 103001102,
		/// <summary>
		/// 添加联系记录（客户关系管理）
		/// </summary>
		ClientAnnalAdd = 103007101,
		/// <summary>
		/// 删除联系记录（客户关系管理）
		/// </summary>
		ClientAnnalDelete = 103007102,
		/// <summary>
		/// 联系记录管理（客户关系管理）
		/// </summary>
		ClientAnnalManage = 103007100,
		/// <summary>
		/// 修改我的联系记录
		/// </summary>
		ClientAnnalUpdate = 103007103,
		/// <summary>
		/// 修改所有联系记录
		/// </summary>
		ClientAnnalUpdateAll = 103007104,
		/// <summary>
		/// 查看联系记录
		/// </summary>
		ClientAnnalView = 103007105,
		/// <summary>
		/// 批量设为我的客户
		/// </summary>
		ClientAssociate = 103001109,
		/// <summary>
		/// 批量关联客户
		/// </summary>
		ClientBatchSetAssociate = 103001110,
		/// <summary>
		/// 删除客户
		/// </summary>
		ClientDelete = 103001105,
		/// <summary>
		/// 删除所有客户
		/// </summary>
		ClientDeleteAll = 103001107,
		/// <summary>
		/// 客户管理
		/// </summary>
		ClientManage = 103001100,
		/// <summary>
		/// 合并客户
		/// </summary>
		ClientMerge = 103001114,
		/// <summary>
		/// 修改所有客户信息
		/// </summary>
		ClientModifyAll = 103001104,
		/// <summary>
		/// 修改公共客户信息
		/// </summary>
		ClientModifyCommon = 103001113,
		/// <summary>
		/// 修改属于自己的客户信息
		/// </summary>
		ClientModifyOwn = 103001103,
		/// <summary>
		/// 客户资金管理
		/// </summary>
		ClientMoneyManage = 103001106,
		/// <summary>
		/// 设置公共客户
		/// </summary>
		ClientSetPublic = 103001108,
		/// <summary>
		/// 查看所有客户信息
		/// </summary>
		ClientView = 103001101,
		/// <summary>
		/// 查看公共客户信息
		/// </summary>
		ClientViewCommon = 103001112,
		/// <summary>
		/// 查看自己的客户信息
		/// </summary>
		ClientViewOwn = 103001111,
		/// <summary>
		/// 
		/// </summary>
		CManager = 107003002,
		/// <summary>
		/// 
		/// </summary>
		CManagers = 107003003,
		/// <summary>
		/// 采集管理
		/// </summary>
		CollectionManage = 101004000,
		/// <summary>
		/// 评论管理
		/// </summary>
		CommentManage = 101002000,
		/// <summary>
		/// 企业管理
		/// </summary>
		CompanyManage = 104009000,
		/// <summary>
		/// 企业扩展字段管理
		/// </summary>
		CompanyOptionModelManage = 105040000,
		/// <summary>
		/// 在线比较网站文件
		/// </summary>
		CompareFilesOnline = 105010020,
		/// <summary>
		/// 添加投诉记录（客户关系管理）
		/// </summary>
		ComplainAdd = 103004102,
		/// <summary>
		/// 删除投诉记录（客户关系管理）
		/// </summary>
		ComplainDelete = 103004105,
		/// <summary>
		/// 投诉管理（客户关系管理）
		/// </summary>
		ComplainManage = 103004100,
		/// <summary>
		/// 修改所有投诉记录（客户关系管理）
		/// </summary>
		ComplainModifyAll = 103004104,
		/// <summary>
		/// 修改属于自己的投诉记录（客户关系管理）
		/// </summary>
		ComplainModifyOwn = 103004103,
		/// <summary>
		/// 投诉管理
		/// </summary>
		ComplaintManager = 107003001,
		/// <summary>
		/// 删除投诉
		/// </summary>
		ComplaintsDelete = 107001003,
		/// <summary>
		/// 
		/// </summary>
		ComplaintsDo = 107001002,
		/// <summary>
		/// 修改投诉
		/// </summary>
		ComplaintsModify = 107001004,
		/// <summary>
		/// 查看投诉
		/// </summary>
		ComplaintsView = 107001001,
		/// <summary>
		/// 查看投诉记录（客户关系管理）
		/// </summary>
		ComplainView = 103004101,
		/// <summary>
		/// 添加联系人
		/// </summary>
		ContacterAdd = 103002102,
		/// <summary>
		/// 删除联系人
		/// </summary>
		ContacterDelete = 103002105,
		/// <summary>
		/// 联系人管理
		/// </summary>
		ContacterManage = 103002100,
		/// <summary>
		/// 修改所有联系人信息
		/// </summary>
		ContacterModifyAll = 103002104,
		/// <summary>
		/// 修改属于自己的联系人信息
		/// </summary>
		ContacterModifyOwn = 103002103,
		/// <summary>
		/// 查看联系人信息
		/// </summary>
		ContacterView = 103002101,
		/// <summary>
		/// 批量替换（信息管理）
		/// </summary>
		ContentBatchModfiy = 101001070,
		/// <summary>
		/// 字段编辑
		/// </summary>
		ContentFieldInput = 101009040,
		/// <summary>
		/// 批量导入（信息管理）
		/// </summary>
		ContentImport = 101001090,
		/// <summary>
		/// 内容管理
		/// </summary>
		ContentManage = 101000000,
		/// <summary>
		/// 内容模型管理（菜单）
		/// </summary>
		ContentModel = 101009010,
		/// <summary>
		/// 内容模型字段管理
		/// </summary>
		ContentModelManage = 101009000,
		/// <summary>
		/// 内容转换
		/// </summary>
		ConvertManage = 101012000,
		/// <summary>
		/// 优惠券管理
		/// </summary>
		Coupon = 102005030,
		/// <summary>
		/// 添加优惠券
		/// </summary>
		CouponAdd = 102005031,
		/// <summary>
		/// 快递公司管理
		/// </summary>
		CourierManage = 102007021,
		/// <summary>
		/// html生成管理
		/// </summary>
		CreateHtmlManage = 101003000,
		/// <summary>
		/// 客户关系管理
		/// </summary>
		Crm = 103000000,
		/// <summary>
		/// 当前节点的管理权限
		/// </summary>
		CurrentNodesManage = 101005001,
		/// <summary>
		/// 自定义表单管理
		/// </summary>
		CustomForm = 111001001,
		/// <summary>
		/// 自定义表单管理（全部）
		/// </summary>
		CustomFormManage = 111001002,
		DeliverItemList = 102004050,
		DeliverType = 102007022,
		DeliverTypeManage = 102007020,
		DetailLog = 102004000,
		DownloadErrorManage = 101011070,
		DownServerManage = 101011060,
		DynamicPageConfig = 101008030,
		ExaminationAdd = 108003001,
		ExaminationDelete = 108003002,
		ExaminationManage = 108003000,
		ExaminationModify = 108003003,
		ExaminationStutusManage = 108003004,
		Exchange = 102005040,
		HelpUrlManage = 112001002,
		HonorTypeManage = 110002001,
		IncludeFileManage = 101008050,
		InfoManage = 101001000,
		InsideLinkManage = 101012010,
		InsideOrderMessage = 105007003,

		InvoiceItemList = 102004040,
		JobAdd = 106001002,
		JobBack = 106001006,
		JobDel = 106001005,
		JobDelete = 106001003,
		JobManage = 106001000,
		JobModify = 106001004,
		JobRecycle = 106001007,
		JobTypeAdd = 106004001,
		JobTypeDelete = 106004003,
		JobTypeManage = 106030000,
		JobTypeModify = 106004002,
		JobView = 106001001,
		KeyWordManage = 101011030,
		LabelManage = 101008020,
		LogManager = 105006000,
		MailListSend = 105008000,
		MailSubscribe = 1055008001,
		MailSubscriptionConfig = 1055008002,
		MessageManage = 105007001,
		MobileMessage = 102002131,
		ModelManage = 101009050,
		ModelTemplateManage = 101009060,

		NodeCommentCheck = 101005072,
		NodeCommentManage = 101005070,
		NodeCommentReply = 101005071,
		NodeContentCheck = 101005040,
		NodeContentInput = 101005030,
		NodeContentManage = 101005050,
		NodeContentPreview = 101005020,
		NodeContentSkim = 101005010,
		NodeManageSelfInfo = 101005080,
		NodeNoNeedCheck = 101005060,
		NodeSetToNotCheck = 101005090,
		NodesManage = 101005000,
		None = 0,
		OfficialManage = 112001001,

		//订单管理权限
		OrderSuperManage = 102003000,
		OrderManage = 102003100,
		OrderView = 102003101,
		OrderModify = 102003102,
		OrderConfirm = 102003103,
		OrderDeal = 102003104,
		OrderDel = 102003105,
		OrderRemitAndPay = 102003106,
		OrderVirtualMoneyPayment = 102003107,
		OrderAgentPayment = 102003108,
		OrderInvoice = 102003109,
		OrderDeliver = 102003110,
		OrderRefund = 102003111,
		OrderEnd = 102003112,
		OrderTransfer = 102003113,
		OrderPrint = 102003114,
		OrderMerge = 102003115,
		OrderReceived = 102003116,
		OrderEnableOrCancelDownload = 102003117,
		OrderSendCard = 102003118,
		/// <summary>
		/// 添加订单服务记录
		/// </summary>
		AddService = 102003119,
		/// <summary>
		/// 添加订单投诉记录
		/// </summary>
		AddComplain = 102003120,
		/// <summary>
		/// 指派跟单员
		/// </summary>
		AddFunctionary = 102003121,
		/// <summary>
		/// 修改跟单员
		/// </summary>
		ModifyFunctionary = 102003122,
		OrderSendOrReturnGoods = 102003123,
		OrderMoneyPayment = 102003124,
		OrderViewPart = 102003125,
		OrderViewMy = 102003126,
		/// <summary>
		/// 收货地址管理
		/// </summary>
		AddressManage = 102003127,
		ReturnOrder = 102003129,
		InteriorMessage = 102003130,
		OrderAdd = 102003200,
		/// <summary>
		/// 发货处理
		/// </summary>
		OnsignmentList = 102003300,
		PrintConsignment = 102003301,
		/// <summary>
		/// 订单反馈明细
		/// </summary>
		OrderFeedbackManage = 102003400,
		/// <summary>
		/// 提前还款
		/// </summary>
		EarlyRepayment = 102003401,
		/// <summary>
		/// 确认订单已支付首付金额
		/// </summary>
		OrderConfirmDownPayment = 115000000,
		/// <summary>
		/// 确认客户已收货
		/// </summary>
		OrderConfirmReceipt = 115001000,

		/// <summary>
		/// 产品销售明细
		/// </summary>
		SaleList = 102004020,
		/// <summary>
		/// 在线支付明细
		/// </summary>
		PaymentLogManage = 102004030,
		TransferLogManage = 102004060,

		/// <summary>
		/// 订单扩展字段
		/// </summary>
		OrderOptionModelManage = 105020000,

		OrganizationAdd = 106005002,
		OrganizationDelete = 106005004,
		OrganizationManage = 106005000,
		OrganizationModify = 106005003,
		OrganizationView = 106005001,
		OtherManage = 105010000,
		OutOfStockLogManage = 102001040,
		PackageManage = 102007050,

		PaymentType = 102007011,
		PaymentTypeManage = 102007010,
		PayPlatformManage = 102007060,
		Plus = 105000000,
		PointLog = 104006000,
		PointLogManage = 110004001,

		ProducerManage = 102007030,
		ProductAdd = 102001001,
		ProductBatchManage = 102001006,
		ProductBatchModify = 102001020,
		ProductDelete = 102001003,
		ProductHtmlInfoManage = 102001060,
		ProductImport = 102001005,
		ProductManage = 102001004,
		ProductModelManage = 102007090,
		ProductModify = 102001002,
		ProductRecycle = 102001050,
		Products = 102001000,
		ProductSpecialInfoManage = 102001030,
		PromotionAdd = 102005011,
		PromotionManage = 102005010,
		PromotionProject = 102005020,
		PromotionProjectAdd = 102005021,
		PromotionSuperManage = 102005000,
		QAModule = 110000000,
		QAQuestionManage = 110003001,
		QAReplyCommentManage = 110006001,
		QAReplyManage = 110005001,
		QuestionCategoryManage = 110001001,
		RegionManage = 102007080,
		ReManager = 107003004,
		ReManagers = 107003005,
		RemindItemAdd = 103006101,
		RemindItemDelete = 103006102,
		RemindItemManage = 103006100,
		RemindItemUpdate = 103006103,
		RemindItemUpdateAll = 103006104,
		RemindItemView = 103006105,
		ReportClass = 107003007,
		ReportDelete = 107002003,
		ReportDo = 107002002,
		ReportModify = 107002004,
		ReportView = 107002001,
		ResumeDelete = 106002003,
		ResumeManage = 106002000,
		ResumeModify = 106002002,
		ResumeView = 106002001,


		ScheduleManage = 108008000,
		SchedulePartManager = 108008001,
		SchoolAdd = 108001002,
		SchoolAdministratorsManage = 108005000,
		SchoolManage = 108001001,
		SCModifyUserQuestionLevel = 10900301,
		ScoreManage = 108009000,
		ScoreRankConfigManage = 108004000,
		SCQuestionAllot = 10900400,
		SCQuestionLevel = 10900300,
		SCQuestionManage = 10900500,
		SCQuestionOptionModelManage = 10900100,
		SCQuestionsComplexSearch = 10900600,
		SCQuestionTypeManage = 10900200,
		SellCount = 102006000,
		SendInfoManage = 105007000,
		SepcialContentManage = 101006010,
		ServiceAdd = 103003102,
		ServiceCallAdd = 103003106,
		ServiceCallModifyAll = 103003107,
		ServiceCallModifyOwn = 103003108,
		ServiceCenterConfig = 10900700,
		ServiceCenterManage = 10900000,
		ServiceDelete = 103003105,
		ServiceManage = 103003100,
		ServiceModifyAll = 103003104,
		ServiceModifyOwn = 103003103,
		ServiceView = 103003101,
		Shop = 102000000,
		ShopConfig = 102007000,
		ShopParameterConfig = 102007110,
		ShoppingCartManage = 102002000,
		ShopTemplateConfig = 102007111,
		SiteConfig = 105009000,
		SiteCount = 101010000,
		SiteKey = 112001005,
		SiteKeyManage = 112001006,
		SiteKeyManages = 112001007,
		SiteManages = 112001008,
		SmsManage = 105007002,
		SourceManage = 101011050,
		SpecialContentInput = 101006020,
		SpecialInfoManage = 101001020,
		SpecialManage = 101006000,
		StatInfo = 105003001,
		StatInfoList = 105003000,
		StatManage = 105003002,
		StatusManage = 101009030,
		StatusSchoolManage = 108000000,
		StockManage = 102007120,
		StudentRecordsManage = 108001000,
		StyleManage = 101008040,
		SubjectAdd = 108002001,
		SubjectDelete = 108002003,
		SubjectManage = 108002000,
		SubjectModify = 108002004,
		SubjectStatusManage = 108002002,
		SurveyCode = 105002009,
		SurveyCreate = 105002003,
		SurveyManage = 105002000,
		SurveyPreview = 105002002,
		SurveyQuestionExport = 105002007,
		SurveyQuestionImport = 105002006,
		SurveyQuestionListPreview = 105002008,
		SurveyQuestionnaireManage = 105002001,
		SurveyResultPreview = 105002004,
		SurveyTemplateManage = 105002005,
		SystemConfig = 105009001,
		TargetScoreManage = 108006000,
		TargetScoreRankConfig = 108004001,
		TemplateLabelManage = 101008000,
		TemplateManage = 101008010,
		TercherManage = 108007000,
		TermManage = 108008002,
		TrademarkManage = 102007040,

		UploadFiledManage = 101007000,
		User = 104000000,
		UserSuperManage = 104001000,
		UserManage = 104001100,
		UserAdd = 104001101,
		UserView = 104001102,
		UserModify = 104001103,
		UserModifyPermissions = 104001104,
		UserLock = 104001105,
		UserDelete = 104001106,
		UserMove = 104001107,
		UserUpdateToClient = 104001108,
		UserMoneyManage = 104001109,
		UserPointManage = 104001110,
		UserValidDateManage = 104001111,
		UserConsumeLogManage = 104001112,
		UserValidDateLogManage = 104001113,
		UserUpdateToCompany = 104001114,
		UserIDCardSub = 104001115,
		ModifyBankCard = 104001116,
		BindBankCard = 104001117,
		UserGroupManage = 104001200,
		UserRoleManage = 104002020,
		ValidLog = 104007000,
		UserOptionModelManage = 105030000,
		UserQAPointManage = 110007001,
		WordFilterManage = 101013020,
		WorkCategory = 111001003,
		WorkFlowManage = 101009020,
		WorkManage = 111001004,

		//商户管理权限
		MerchantManage = 113000000,
		MerchantList = 113001000,
		MerchantModify = 113001001,
		MerchantDelete = 113001002,
		MerchantLock = 113001003,
		MerchantInfoSubmit = 113001004,
		MerchantCheck = 113001005,
		MerchantAdd = 113001006,
		StoreList = 113002000,
		StoreModify = 113002001,
		StoreDelete = 113002002,
		StoreInfoSubmit = 113002003,
		StoreCheck = 113002004,
		StoreAdd = 113002005,
		ClerkList = 113003000,
		ClerkModify = 113003001,
		ClerkDelete = 113003002,
		ClerkInfoSubmit = 113003003,
		ClerkCheck = 113003004,
		ClerkAdd = 113003005,
		SetClerkByStore = 113004000,
		SetManageByStore = 113004001,
		//分期财务管理
		AccountingManageHP = 114000000,
		StoreOrderList = 114001000,
		RepaymentList = 114001001,
		EarlyRepaymentList = 114001002,
		//催收权限
		PressMoneyManage = 116000000,
		PressMoneyMy = 116000001,
		//贷款客户
		LoanClient = 117000000,
		LoanClientManage = 117000001,
		LoanClientMy = 117000002,
		LoanClientExport = 117000003,
		//贷款客户订单
		LoanOrder = 117001000,
		LoanOrderManage = 117001001,
		LoanOrderAdd = 117001002,
		LoanOrderModify = 117001003,
		LoanOrderDel = 117001004,
		LoanOrderAudit = 117001005,
		LoanOrderExport = 117001006,
		//贷款客户与商户的绑定关系
		DelUserCompanyRelation = 118000000,
		//贷款客户与抢单商户的绑定关系
		DelUserRelationQDC = 118000001,
		//贷款客户与尾单商户的绑定关系
		DelUserRelationSingle = 118000002,
		//渠道过滤
		ChannelFilter = 118000003
	}
}
