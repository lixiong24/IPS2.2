using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Threading.Tasks;
using Hangfire;
using JX.Application;
using JX.Application.CommonService;
using JX.Core;
using JX.EF;
using JX.EF.Repository;
using JX.Infrastructure.Common;
using JX.Infrastructure.Framework.Authorize;
using JX.Infrastructure.Framework.Filter;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JXWebHost
{
	public class Startup
	{
		public Startup(IConfiguration configuration, IHostingEnvironment env)
		{
			Configuration = configuration;
			m_ContentRoot = env.ContentRootPath;
		}

		public IConfiguration Configuration { get; }
		/// <summary>
		/// 得到应用程序根目录
		/// </summary>
		public string m_ContentRoot = string.Empty;

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			//添加EF，保证上下文线程唯一
			services.AddDbContext<ApplicationDbContext>(options =>
			{
				options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));

			}, ServiceLifetime.Scoped);

			services.AddMyHttpContextAccessor();

			//添加GZIP压缩服务
			services.AddResponseCompression();

			#region 依赖注入
			services.AddScoped<IAddressRepository, AddressRepository>();

			services.AddScoped<IAddressServiceApp, AddressServiceApp>();

			services.AddScoped<IAdminRepository, AdminRepository>();

			services.AddScoped<IAdminServiceApp, AdminServiceApp>();

			services.AddScoped<IAdminRolesRepository, AdminRolesRepository>();

			services.AddScoped<IAdminRolesServiceApp, AdminRolesServiceApp>();

			services.AddScoped<IAdvertisementRepository, AdvertisementRepository>();

			services.AddScoped<IAdvertisementServiceApp, AdvertisementServiceApp>();

			services.AddScoped<IAdvertisementZoneRepository, AdvertisementZoneRepository>();

			services.AddScoped<IAdvertisementZoneServiceApp, AdvertisementZoneServiceApp>();

			services.AddScoped<IAdZoneRepository, AdZoneRepository>();

			services.AddScoped<IAdZoneServiceApp, AdZoneServiceApp>();

			services.AddScoped<IAuthorRepository, AuthorRepository>();

			services.AddScoped<IAuthorServiceApp, AuthorServiceApp>();

			services.AddScoped<IBankRepository, BankRepository>();

			services.AddScoped<IBankServiceApp, BankServiceApp>();

			services.AddScoped<IBankrollLogRepository, BankrollLogRepository>();

			services.AddScoped<IBankrollLogServiceApp, BankrollLogServiceApp>();

			services.AddScoped<ICardsRepository, CardsRepository>();

			services.AddScoped<ICardsServiceApp, CardsServiceApp>();

			services.AddScoped<IClerkRepository, ClerkRepository>();

			services.AddScoped<IClerkServiceApp, ClerkServiceApp>();

			services.AddScoped<IClientRepository, ClientRepository>();

			services.AddScoped<IClientServiceApp, ClientServiceApp>();

			services.AddScoped<IClientLogRepository, ClientLogRepository>();

			services.AddScoped<IClientLogServiceApp, ClientLogServiceApp>();

			services.AddScoped<ICollectionExclosionRepository, CollectionExclosionRepository>();

			services.AddScoped<ICollectionExclosionServiceApp, CollectionExclosionServiceApp>();

			services.AddScoped<ICollectionFieldRulesRepository, CollectionFieldRulesRepository>();

			services.AddScoped<ICollectionFieldRulesServiceApp, CollectionFieldRulesServiceApp>();

			services.AddScoped<ICollectionFilterRulesRepository, CollectionFilterRulesRepository>();

			services.AddScoped<ICollectionFilterRulesServiceApp, CollectionFilterRulesServiceApp>();

			services.AddScoped<ICollectionHistoryRepository, CollectionHistoryRepository>();

			services.AddScoped<ICollectionHistoryServiceApp, CollectionHistoryServiceApp>();

			services.AddScoped<ICollectionItemRepository, CollectionItemRepository>();

			services.AddScoped<ICollectionItemServiceApp, CollectionItemServiceApp>();

			services.AddScoped<ICollectionListRulesRepository, CollectionListRulesRepository>();

			services.AddScoped<ICollectionListRulesServiceApp, CollectionListRulesServiceApp>();

			services.AddScoped<ICollectionPagingRulesRepository, CollectionPagingRulesRepository>();

			services.AddScoped<ICollectionPagingRulesServiceApp, CollectionPagingRulesServiceApp>();

			services.AddScoped<ICommentRepository, CommentRepository>();

			services.AddScoped<ICommentServiceApp, CommentServiceApp>();

			services.AddScoped<ICommentPKRepository, CommentPKRepository>();

			services.AddScoped<ICommentPKServiceApp, CommentPKServiceApp>();

			services.AddScoped<ICommonInfoRepository, CommonInfoRepository>();

			services.AddScoped<ICommonInfoServiceApp, CommonInfoServiceApp>();

			services.AddScoped<ICommonProductRepository, CommonProductRepository>();

			services.AddScoped<ICommonProductServiceApp, CommonProductServiceApp>();

			services.AddScoped<ICompanyRepository, CompanyRepository>();

			services.AddScoped<ICompanyServiceApp, CompanyServiceApp>();

			services.AddScoped<IComplainLogRepository, ComplainLogRepository>();

			services.AddScoped<IComplainLogServiceApp, ComplainLogServiceApp>();

			services.AddScoped<IComplaintsRepository, ComplaintsRepository>();

			services.AddScoped<IComplaintsServiceApp, ComplaintsServiceApp>();

			services.AddScoped<IComplaintsResultsRepository, ComplaintsResultsRepository>();

			services.AddScoped<IComplaintsResultsServiceApp, ComplaintsResultsServiceApp>();

			services.AddScoped<IComplaintsTypeRepository, ComplaintsTypeRepository>();

			services.AddScoped<IComplaintsTypeServiceApp, ComplaintsTypeServiceApp>();

			services.AddScoped<IContacterRepository, ContacterRepository>();

			services.AddScoped<IContacterServiceApp, ContacterServiceApp>();

			services.AddScoped<IContentChargeRepository, ContentChargeRepository>();

			services.AddScoped<IContentChargeServiceApp, ContentChargeServiceApp>();

			services.AddScoped<IContentPermissionRepository, ContentPermissionRepository>();

			services.AddScoped<IContentPermissionServiceApp, ContentPermissionServiceApp>();

			services.AddScoped<ICorrelativeInfoRepository, CorrelativeInfoRepository>();

			services.AddScoped<ICorrelativeInfoServiceApp, CorrelativeInfoServiceApp>();

			services.AddScoped<ICouponRepository, CouponRepository>();

			services.AddScoped<ICouponServiceApp, CouponServiceApp>();

			services.AddScoped<ICouponLogRepository, CouponLogRepository>();

			services.AddScoped<ICouponLogServiceApp, CouponLogServiceApp>();

			services.AddScoped<ICourierRepository, CourierRepository>();

			services.AddScoped<ICourierServiceApp, CourierServiceApp>();

			services.AddScoped<ICreditLinesLogRepository, CreditLinesLogRepository>();

			services.AddScoped<ICreditLinesLogServiceApp, CreditLinesLogServiceApp>();

			services.AddScoped<IDeliverChargeRepository, DeliverChargeRepository>();

			services.AddScoped<IDeliverChargeServiceApp, DeliverChargeServiceApp>();

			services.AddScoped<IDeliverLogRepository, DeliverLogRepository>();

			services.AddScoped<IDeliverLogServiceApp, DeliverLogServiceApp>();

			services.AddScoped<IDeliverTypeRepository, DeliverTypeRepository>();

			services.AddScoped<IDeliverTypeServiceApp, DeliverTypeServiceApp>();

			services.AddScoped<IDictionaryRepository, DictionaryRepository>();

			services.AddScoped<IDictionaryServiceApp, DictionaryServiceApp>();

			services.AddScoped<IDownloadErrorLogRepository, DownloadErrorLogRepository>();

			services.AddScoped<IDownloadErrorLogServiceApp, DownloadErrorLogServiceApp>();

			services.AddScoped<IDownServerRepository, DownServerRepository>();

			services.AddScoped<IDownServerServiceApp, DownServerServiceApp>();

			services.AddScoped<IExpLogRepository, ExpLogRepository>();

			services.AddScoped<IExpLogServiceApp, ExpLogServiceApp>();

			services.AddScoped<IFavoriteRepository, FavoriteRepository>();

			services.AddScoped<IFavoriteServiceApp, FavoriteServiceApp>();

			services.AddScoped<IFileRelationInfoRepository, FileRelationInfoRepository>();

			services.AddScoped<IFileRelationInfoServiceApp, FileRelationInfoServiceApp>();

			services.AddScoped<IFilesRepository, FilesRepository>();

			services.AddScoped<IFilesServiceApp, FilesServiceApp>();

			services.AddScoped<IFlowProcessRepository, FlowProcessRepository>();

			services.AddScoped<IFlowProcessServiceApp, FlowProcessServiceApp>();

			services.AddScoped<IFriendRepository, FriendRepository>();

			services.AddScoped<IFriendServiceApp, FriendServiceApp>();

			services.AddScoped<IGroupFieldPermissionsRepository, GroupFieldPermissionsRepository>();

			services.AddScoped<IGroupFieldPermissionsServiceApp, GroupFieldPermissionsServiceApp>();

			services.AddScoped<IGroupNodePermissionsRepository, GroupNodePermissionsRepository>();

			services.AddScoped<IGroupNodePermissionsServiceApp, GroupNodePermissionsServiceApp>();

			services.AddScoped<IGroupSpecialCategoryPermissionsRepository, GroupSpecialCategoryPermissionsRepository>();

			services.AddScoped<IGroupSpecialCategoryPermissionsServiceApp, GroupSpecialCategoryPermissionsServiceApp>();

			services.AddScoped<IGroupSpecialPermissionsRepository, GroupSpecialPermissionsRepository>();

			services.AddScoped<IGroupSpecialPermissionsServiceApp, GroupSpecialPermissionsServiceApp>();

			services.AddScoped<IHirePurchaseRepository, HirePurchaseRepository>();

			services.AddScoped<IHirePurchaseServiceApp, HirePurchaseServiceApp>();

			services.AddScoped<IIncludeFileRepository, IncludeFileRepository>();

			services.AddScoped<IIncludeFileServiceApp, IncludeFileServiceApp>();

			services.AddScoped<IInfoNextProcessRolesRepository, InfoNextProcessRolesRepository>();

			services.AddScoped<IInfoNextProcessRolesServiceApp, InfoNextProcessRolesServiceApp>();

			services.AddScoped<IIntegralProductRepository, IntegralProductRepository>();

			services.AddScoped<IIntegralProductServiceApp, IntegralProductServiceApp>();

			services.AddScoped<IIntegralProductTypeRepository, IntegralProductTypeRepository>();

			services.AddScoped<IIntegralProductTypeServiceApp, IntegralProductTypeServiceApp>();

			services.AddScoped<IInvoiceLogRepository, InvoiceLogRepository>();

			services.AddScoped<IInvoiceLogServiceApp, InvoiceLogServiceApp>();

			services.AddScoped<IKeywordRelationRepository, KeywordRelationRepository>();

			services.AddScoped<IKeywordRelationServiceApp, KeywordRelationServiceApp>();

			services.AddScoped<IKeywordsRepository, KeywordsRepository>();

			services.AddScoped<IKeywordsServiceApp, KeywordsServiceApp>();

			services.AddScoped<ILogRepository, LogRepository>();

			services.AddScoped<ILogServiceApp, LogServiceApp>();

			services.AddScoped<IMailItemRepository, MailItemRepository>();

			services.AddScoped<IMailItemServiceApp, MailItemServiceApp>();

			services.AddScoped<IMailListRepository, MailListRepository>();

			services.AddScoped<IMailListServiceApp, MailListServiceApp>();

			services.AddScoped<IMentionLogRepository, MentionLogRepository>();

			services.AddScoped<IMentionLogServiceApp, MentionLogServiceApp>();

			services.AddScoped<IMerchantRepository, MerchantRepository>();

			services.AddScoped<IMerchantServiceApp, MerchantServiceApp>();

			services.AddScoped<IModelsRepository, ModelsRepository>();

			services.AddScoped<IModelsServiceApp, ModelsServiceApp>();

			services.AddScoped<IModelTemplatesRepository, ModelTemplatesRepository>();

			services.AddScoped<IModelTemplatesServiceApp, ModelTemplatesServiceApp>();

			services.AddScoped<INodesRepository, NodesRepository>();

			services.AddScoped<INodesServiceApp, NodesServiceApp>();

			services.AddScoped<INodesModelTemplateRepository, NodesModelTemplateRepository>();

			services.AddScoped<INodesModelTemplateServiceApp, NodesModelTemplateServiceApp>();

			services.AddScoped<INodesTemplateRepository, NodesTemplateRepository>();

			services.AddScoped<INodesTemplateServiceApp, NodesTemplateServiceApp>();

			services.AddScoped<IOrderFeedbackRepository, OrderFeedbackRepository>();

			services.AddScoped<IOrderFeedbackServiceApp, OrderFeedbackServiceApp>();

			services.AddScoped<IOrderItemRepository, OrderItemRepository>();

			services.AddScoped<IOrderItemServiceApp, OrderItemServiceApp>();

			services.AddScoped<IOrderLogRepository, OrderLogRepository>();

			services.AddScoped<IOrderLogServiceApp, OrderLogServiceApp>();

			services.AddScoped<IOrdersRepository, OrdersRepository>();

			services.AddScoped<IOrdersServiceApp, OrdersServiceApp>();

			services.AddScoped<IPackageRepository, PackageRepository>();

			services.AddScoped<IPackageServiceApp, PackageServiceApp>();

			services.AddScoped<IPaymentLogRepository, PaymentLogRepository>();

			services.AddScoped<IPaymentLogServiceApp, PaymentLogServiceApp>();

			services.AddScoped<IPaymentTypeRepository, PaymentTypeRepository>();

			services.AddScoped<IPaymentTypeServiceApp, PaymentTypeServiceApp>();

			services.AddScoped<IPayPlatFormRepository, PayPlatFormRepository>();

			services.AddScoped<IPayPlatFormServiceApp, PayPlatFormServiceApp>();

			services.AddScoped<IPointLogRepository, PointLogRepository>();

			services.AddScoped<IPointLogServiceApp, PointLogServiceApp>();

			services.AddScoped<IPresentRepository, PresentRepository>();

			services.AddScoped<IPresentServiceApp, PresentServiceApp>();

			services.AddScoped<IPresentBuyLogRepository, PresentBuyLogRepository>();

			services.AddScoped<IPresentBuyLogServiceApp, PresentBuyLogServiceApp>();

			services.AddScoped<IPresentProjectRepository, PresentProjectRepository>();

			services.AddScoped<IPresentProjectServiceApp, PresentProjectServiceApp>();

			services.AddScoped<IProcessStatusCodeRepository, ProcessStatusCodeRepository>();

			services.AddScoped<IProcessStatusCodeServiceApp, ProcessStatusCodeServiceApp>();

			services.AddScoped<IProducerRepository, ProducerRepository>();

			services.AddScoped<IProducerServiceApp, ProducerServiceApp>();

			services.AddScoped<IProductDataRepository, ProductDataRepository>();

			services.AddScoped<IProductDataServiceApp, ProductDataServiceApp>();

			services.AddScoped<IProductPriceRepository, ProductPriceRepository>();

			services.AddScoped<IProductPriceServiceApp, ProductPriceServiceApp>();

			services.AddScoped<IRegionRepository, RegionRepository>();

			services.AddScoped<IRegionServiceApp, RegionServiceApp>();

			services.AddScoped<IRegion_CRepository, Region_CRepository>();

			services.AddScoped<IRegion_CServiceApp, Region_CServiceApp>();

			services.AddScoped<IRemindItemRepository, RemindItemRepository>();

			services.AddScoped<IRemindItemServiceApp, RemindItemServiceApp>();

			services.AddScoped<IRepaymentRepository, RepaymentRepository>();

			services.AddScoped<IRepaymentServiceApp, RepaymentServiceApp>();

			services.AddScoped<IRoleFieldPermissionsRepository, RoleFieldPermissionsRepository>();

			services.AddScoped<IRoleFieldPermissionsServiceApp, RoleFieldPermissionsServiceApp>();

			services.AddScoped<IRoleNodePermissionsRepository, RoleNodePermissionsRepository>();

			services.AddScoped<IRoleNodePermissionsServiceApp, RoleNodePermissionsServiceApp>();

			services.AddScoped<IRolesRepository, RolesRepository>();

			services.AddScoped<IRolesServiceApp, RolesServiceApp>();

			services.AddScoped<IRoleSpecialPermissionsRepository, RoleSpecialPermissionsRepository>();

			services.AddScoped<IRoleSpecialPermissionsServiceApp, RoleSpecialPermissionsServiceApp>();

			services.AddScoped<IRolesPermissionsRepository, RolesPermissionsRepository>();

			services.AddScoped<IRolesPermissionsServiceApp, RolesPermissionsServiceApp>();

			services.AddScoped<IRolesProcessRepository, RolesProcessRepository>();

			services.AddScoped<IRolesProcessServiceApp, RolesProcessServiceApp>();

			services.AddScoped<IServiceLogRepository, ServiceLogRepository>();

			services.AddScoped<IServiceLogServiceApp, ServiceLogServiceApp>();

			services.AddScoped<IShoppingCartsRepository, ShoppingCartsRepository>();

			services.AddScoped<IShoppingCartsServiceApp, ShoppingCartsServiceApp>();

			services.AddScoped<ISigninContentRepository, SigninContentRepository>();

			services.AddScoped<ISigninContentServiceApp, SigninContentServiceApp>();

			services.AddScoped<ISigninLogRepository, SigninLogRepository>();

			services.AddScoped<ISigninLogServiceApp, SigninLogServiceApp>();

			services.AddScoped<ISiteLinkRepository, SiteLinkRepository>();

			services.AddScoped<ISiteLinkServiceApp, SiteLinkServiceApp>();

			services.AddScoped<ISortingLogRepository, SortingLogRepository>();

			services.AddScoped<ISortingLogServiceApp, SortingLogServiceApp>();

			services.AddScoped<ISourceRepository, SourceRepository>();

			services.AddScoped<ISourceServiceApp, SourceServiceApp>();

			services.AddScoped<ISpecialCategoryRepository, SpecialCategoryRepository>();

			services.AddScoped<ISpecialCategoryServiceApp, SpecialCategoryServiceApp>();

			services.AddScoped<ISpecialInfosRepository, SpecialInfosRepository>();

			services.AddScoped<ISpecialInfosServiceApp, SpecialInfosServiceApp>();

			services.AddScoped<ISpecialsRepository, SpecialsRepository>();

			services.AddScoped<ISpecialsServiceApp, SpecialsServiceApp>();

			services.AddScoped<IStatAddressRepository, StatAddressRepository>();

			services.AddScoped<IStatAddressServiceApp, StatAddressServiceApp>();

			services.AddScoped<IStatBrowserRepository, StatBrowserRepository>();

			services.AddScoped<IStatBrowserServiceApp, StatBrowserServiceApp>();

			services.AddScoped<IStatColorRepository, StatColorRepository>();

			services.AddScoped<IStatColorServiceApp, StatColorServiceApp>();

			services.AddScoped<IStatDayRepository, StatDayRepository>();

			services.AddScoped<IStatDayServiceApp, StatDayServiceApp>();

			services.AddScoped<IStatInfoListRepository, StatInfoListRepository>();

			services.AddScoped<IStatInfoListServiceApp, StatInfoListServiceApp>();

			services.AddScoped<IStatIpRepository, StatIpRepository>();

			services.AddScoped<IStatIpServiceApp, StatIpServiceApp>();

			services.AddScoped<IStatIpInfoRepository, StatIpInfoRepository>();

			services.AddScoped<IStatIpInfoServiceApp, StatIpInfoServiceApp>();

			services.AddScoped<IStatKeywordRepository, StatKeywordRepository>();

			services.AddScoped<IStatKeywordServiceApp, StatKeywordServiceApp>();

			services.AddScoped<IStatMonthRepository, StatMonthRepository>();

			services.AddScoped<IStatMonthServiceApp, StatMonthServiceApp>();

			services.AddScoped<IStatMozillaRepository, StatMozillaRepository>();

			services.AddScoped<IStatMozillaServiceApp, StatMozillaServiceApp>();

			services.AddScoped<IStatOnlineRepository, StatOnlineRepository>();

			services.AddScoped<IStatOnlineServiceApp, StatOnlineServiceApp>();

			services.AddScoped<IStatReferRepository, StatReferRepository>();

			services.AddScoped<IStatReferServiceApp, StatReferServiceApp>();

			services.AddScoped<IStatScreenRepository, StatScreenRepository>();

			services.AddScoped<IStatScreenServiceApp, StatScreenServiceApp>();

			services.AddScoped<IStatSystemRepository, StatSystemRepository>();

			services.AddScoped<IStatSystemServiceApp, StatSystemServiceApp>();

			services.AddScoped<IStatTimezoneRepository, StatTimezoneRepository>();

			services.AddScoped<IStatTimezoneServiceApp, StatTimezoneServiceApp>();

			services.AddScoped<IStatusRepository, StatusRepository>();

			services.AddScoped<IStatusServiceApp, StatusServiceApp>();

			services.AddScoped<IStatVisitRepository, StatVisitRepository>();

			services.AddScoped<IStatVisitServiceApp, StatVisitServiceApp>();

			services.AddScoped<IStatVisitorRepository, StatVisitorRepository>();

			services.AddScoped<IStatVisitorServiceApp, StatVisitorServiceApp>();

			services.AddScoped<IStatWeburlRepository, StatWeburlRepository>();

			services.AddScoped<IStatWeburlServiceApp, StatWeburlServiceApp>();

			services.AddScoped<IStatWeekRepository, StatWeekRepository>();

			services.AddScoped<IStatWeekServiceApp, StatWeekServiceApp>();

			services.AddScoped<IStatYearRepository, StatYearRepository>();

			services.AddScoped<IStatYearServiceApp, StatYearServiceApp>();

			services.AddScoped<IStockRepository, StockRepository>();

			services.AddScoped<IStockServiceApp, StockServiceApp>();

			services.AddScoped<IStockItemRepository, StockItemRepository>();

			services.AddScoped<IStockItemServiceApp, StockItemServiceApp>();

			services.AddScoped<IStockOutRepository, StockOutRepository>();

			services.AddScoped<IStockOutServiceApp, StockOutServiceApp>();

			services.AddScoped<IStoreRepository, StoreRepository>();

			services.AddScoped<IStoreServiceApp, StoreServiceApp>();

			services.AddScoped<ISubscriptionItemsRepository, SubscriptionItemsRepository>();

			services.AddScoped<ISubscriptionItemsServiceApp, SubscriptionItemsServiceApp>();

			services.AddScoped<ISurveyRepository, SurveyRepository>();

			services.AddScoped<ISurveyServiceApp, SurveyServiceApp>();

			services.AddScoped<ISurveyVoteRepository, SurveyVoteRepository>();

			services.AddScoped<ISurveyVoteServiceApp, SurveyVoteServiceApp>();

			services.AddScoped<ITrademarkRepository, TrademarkRepository>();

			services.AddScoped<ITrademarkServiceApp, TrademarkServiceApp>();

			services.AddScoped<ITransferLogRepository, TransferLogRepository>();

			services.AddScoped<ITransferLogServiceApp, TransferLogServiceApp>();

			services.AddScoped<IU_AdviceRepository, U_AdviceRepository>();

			services.AddScoped<IU_AdviceServiceApp, U_AdviceServiceApp>();

			services.AddScoped<IU_AnswerRepository, U_AnswerRepository>();

			services.AddScoped<IU_AnswerServiceApp, U_AnswerServiceApp>();

			services.AddScoped<IU_ArticleRepository, U_ArticleRepository>();

			services.AddScoped<IU_ArticleServiceApp, U_ArticleServiceApp>();

			services.AddScoped<IU_AwardRepository, U_AwardRepository>();

			services.AddScoped<IU_AwardServiceApp, U_AwardServiceApp>();

			services.AddScoped<IU_AwardLogRepository, U_AwardLogRepository>();

			services.AddScoped<IU_AwardLogServiceApp, U_AwardLogServiceApp>();

			services.AddScoped<IU_BuyRepository, U_BuyRepository>();

			services.AddScoped<IU_BuyServiceApp, U_BuyServiceApp>();

			services.AddScoped<IU_BuyingRepository, U_BuyingRepository>();

			services.AddScoped<IU_BuyingServiceApp, U_BuyingServiceApp>();

			services.AddScoped<IU_CompanyTextRepository, U_CompanyTextRepository>();

			services.AddScoped<IU_CompanyTextServiceApp, U_CompanyTextServiceApp>();

			services.AddScoped<IU_FriendSiteRepository, U_FriendSiteRepository>();

			services.AddScoped<IU_FriendSiteServiceApp, U_FriendSiteServiceApp>();

			services.AddScoped<IU_GuestBookRepository, U_GuestBookRepository>();

			services.AddScoped<IU_GuestBookServiceApp, U_GuestBookServiceApp>();

			services.AddScoped<IU_IntegralProductRepository, U_IntegralProductRepository>();

			services.AddScoped<IU_IntegralProductServiceApp, U_IntegralProductServiceApp>();

			services.AddScoped<IU_IntegralProductLogRepository, U_IntegralProductLogRepository>();

			services.AddScoped<IU_IntegralProductLogServiceApp, U_IntegralProductLogServiceApp>();

			services.AddScoped<IU_ManufactureRepository, U_ManufactureRepository>();

			services.AddScoped<IU_ManufactureServiceApp, U_ManufactureServiceApp>();

			services.AddScoped<IU_OrderTextRepository, U_OrderTextRepository>();

			services.AddScoped<IU_OrderTextServiceApp, U_OrderTextServiceApp>();

			services.AddScoped<IU_ProductRepository, U_ProductRepository>();

			services.AddScoped<IU_ProductServiceApp, U_ProductServiceApp>();

			services.AddScoped<IU_ProvideRepository, U_ProvideRepository>();

			services.AddScoped<IU_ProvideServiceApp, U_ProvideServiceApp>();

			services.AddScoped<IU_QuestionRepository, U_QuestionRepository>();

			services.AddScoped<IU_QuestionServiceApp, U_QuestionServiceApp>();

			services.AddScoped<IU_UserTextRepository, U_UserTextRepository>();

			services.AddScoped<IU_UserTextServiceApp, U_UserTextServiceApp>();

			services.AddScoped<IUserGroupsRepository, UserGroupsRepository>();

			services.AddScoped<IUserGroupsServiceApp, UserGroupsServiceApp>();

			services.AddScoped<IUserMessageRepository, UserMessageRepository>();

			services.AddScoped<IUserMessageServiceApp, UserMessageServiceApp>();

			services.AddScoped<IUsersRepository, UsersRepository>();

			services.AddScoped<IUsersServiceApp, UsersServiceApp>();

			services.AddScoped<IValidLogRepository, ValidLogRepository>();

			services.AddScoped<IValidLogServiceApp, ValidLogServiceApp>();

			services.AddScoped<IVoteRepository, VoteRepository>();

			services.AddScoped<IVoteServiceApp, VoteServiceApp>();

			services.AddScoped<IWordReplaceItemRepository, WordReplaceItemRepository>();

			services.AddScoped<IWordReplaceItemServiceApp, WordReplaceItemServiceApp>();

			services.AddScoped<IWorkRepository, WorkRepository>();

			services.AddScoped<IWorkServiceApp, WorkServiceApp>();

			services.AddScoped<IWorkCategoryRepository, WorkCategoryRepository>();

			services.AddScoped<IWorkCategoryServiceApp, WorkCategoryServiceApp>();

			services.AddScoped<IWorkCategorySettingRepository, WorkCategorySettingRepository>();

			services.AddScoped<IWorkCategorySettingServiceApp, WorkCategorySettingServiceApp>();

			services.AddScoped<IWorkFlowsRepository, WorkFlowsRepository>();

			services.AddScoped<IWorkFlowsServiceApp, WorkFlowsServiceApp>();

			services.AddScoped<IWorkNextProcessRolesRepository, WorkNextProcessRolesRepository>();

			services.AddScoped<IWorkNextProcessRolesServiceApp, WorkNextProcessRolesServiceApp>();

			#endregion

			services.AddSession();

			services.AddAuthentication(o =>
			{
				o.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
				o.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
				o.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
			})
			.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
			{
				options.LoginPath = new PathString("/User/Login");
				options.LogoutPath = new PathString("/User/Logout");
				options.AccessDeniedPath = new PathString("/User/Forbidden");
				//options.Cookie.Domain = "domain.com";//设置同一个根域名，可以跨不同的二级域名
				options.Cookie.Path = "/";
				options.Cookie.HttpOnly = true;
				options.Cookie.SameSite = SameSiteMode.Lax;
				//表示创建的Cookie是否应该被限制为HTTPS，HTTP或HTTPS，或与请求相同的协议。
				options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
				//服务端变化反馈，用于数据库中变更了会员状态时，将客户端的Cookies失效
				options.Events = new CookieAuthenticationEvents
				{
					OnValidatePrincipal = UserStatusValidator.ValidateAsync
				};
			})
			.AddCookie(AdminAuthorizeAttribute.AdminAuthenticationScheme, options =>
			{
				options.LoginPath = new PathString("/Admin/Home/Login");
				options.LogoutPath = new PathString("/Admin/Home/Logout");
				options.AccessDeniedPath = new PathString("/Admin/Home/Forbidden");
				//options.Cookie.Domain = "domain.com";//设置同一个根域名，可以跨不同的二级域名
				options.Cookie.Path = "/";
				options.Cookie.HttpOnly = true;
				options.Cookie.SameSite = SameSiteMode.Lax;
				//表示创建的Cookie是否应该被限制为HTTPS，HTTP或HTTPS，或与请求相同的协议。
				options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
				//服务端变化反馈，用于数据库中变更了管理员状态时，将客户端的Cookies失效
				options.Events = new CookieAuthenticationEvents
				{
					OnValidatePrincipal = AdminStatusValidator.ValidateAsync
				};
			});

			//用于分布式共享Cookie，部署于不同服务器
			services.AddDataProtection()
				.SetApplicationName("cookieshare")//多个应用程序之间共享，必须设置成同一个名字
				.AddKeyManagementOptions(options =>
				{
					options.XmlRepository = new XmlRepository(Path.Combine(m_ContentRoot, "Config", "ShareKeys.xml"));
				});

			services.AddAuthorization();

			//处理跨站请求伪造
			services.AddAntiforgery(options =>
			{
				// Set Cookie properties using CookieBuilder properties†.
				options.FormFieldName = "AntiforgeryFieldname";
				options.HeaderName = "X-CSRF-TOKEN-JXWebHost";
				options.SuppressXFrameOptionsHeader = false;
			});

			//添加Hangfire服务，用于定时任务
			services.AddHangfire(x => x.UseSqlServerStorage(Configuration.GetConnectionString("DefaultConnection")));
			services.AddHangfireServer();

			//解决MVC输出中文被编码的问题
			services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.All));
			services.AddMvc(options =>
			{
				options.Filters.Add<ModelStateActionFilter>();
			});

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			//使网站支持中文编码
			Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

			//使用GZIP压缩
			app.UseResponseCompression();

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}

			//添加依赖注入的自定义扩展
			app.UseExtensionsDI();

			//添加对HttpContext的扩展
			app.UseStaticMyHttpContext();

			app.UseStaticFiles();

			//启用Session
			app.UseSession();

			app.UseAuthentication();

			//启用Hangfire仪表盘
			app.UseHangfireDashboard();
			//app.Map("/TimeJob1", r =>
			//{
			//	r.Run(context =>
			//	{
			//		//任务每分钟执行一次
			//		RecurringJob.AddOrUpdate(() => Console.WriteLine($"ASP.NET Core LineZero"), Cron.Minutely());
			//		return context.Response.WriteAsync("ok");
			//	});
			//});
			//app.Map("/TimeJob2", r =>
			//{
			//	r.Run(context =>
			//	{
			//		//任务执行一次
			//		BackgroundJob.Enqueue(() => Console.WriteLine($"ASP.NET Core One Start LineZero{DateTime.Now}"));
			//		return context.Response.WriteAsync("ok");
			//	});
			//});
			//app.Map("/TimeJob3", r =>
			//{
			//	r.Run(context =>
			//	{
			//		//任务延时两分钟执行
			//		BackgroundJob.Schedule(() => Console.WriteLine($"ASP.NET Core await LineZero{DateTime.Now}"), TimeSpan.FromMinutes(2));
			//		return context.Response.WriteAsync("ok");
			//	});
			//});

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					 name: "areaRoute",
					 template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});
			
		}
	}
}
