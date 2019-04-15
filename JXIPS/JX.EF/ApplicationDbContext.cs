using JX.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace JX.EF
{
	/// <summary>
	/// EF数据操作上下文。
	/// 使用方法：在展示层的Startup.cs文件的ConfigureServices方法中，添加services.AddDbContext《ApplicationDbContext》(options =>options.UseSqlServer(Configuration.GetConnectionString("SqlServerConnection")));
	/// </summary>
	public class ApplicationDbContext: DbContext
	{
		/// <summary>
		/// 构造器注入
		/// </summary>
		/// <param name="options"></param>
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}

		#region 数据库表对应属性
		/// <summary>
		/// Address表
		/// </summary>
		public virtual DbSet<AddressEntity> Address { get; set; }
		/// <summary>
		/// Admin表
		/// </summary>
		public virtual DbSet<AdminEntity> Admin { get; set; }
		/// <summary>
		/// AdminRoles表
		/// </summary>
		public virtual DbSet<AdminRolesEntity> AdminRoles { get; set; }
		/// <summary>
		/// Advertisement表
		/// </summary>
		public virtual DbSet<AdvertisementEntity> Advertisement { get; set; }
		/// <summary>
		/// AdvertisementZone表
		/// </summary>
		public virtual DbSet<AdvertisementZoneEntity> AdvertisementZone { get; set; }
		/// <summary>
		/// AdZone表
		/// </summary>
		public virtual DbSet<AdZoneEntity> AdZone { get; set; }
		/// <summary>
		/// Author表
		/// </summary>
		public virtual DbSet<AuthorEntity> Author { get; set; }
		/// <summary>
		/// Bank表
		/// </summary>
		public virtual DbSet<BankEntity> Bank { get; set; }
		/// <summary>
		/// BankrollLog表
		/// </summary>
		public virtual DbSet<BankrollLogEntity> BankrollLog { get; set; }
		/// <summary>
		/// Cards表
		/// </summary>
		public virtual DbSet<CardsEntity> Cards { get; set; }
		/// <summary>
		/// Clerk表
		/// </summary>
		public virtual DbSet<ClerkEntity> Clerk { get; set; }
		/// <summary>
		/// Client表
		/// </summary>
		public virtual DbSet<ClientEntity> Client { get; set; }
		/// <summary>
		/// ClientLog表
		/// </summary>
		public virtual DbSet<ClientLogEntity> ClientLog { get; set; }
		/// <summary>
		/// CollectionExclosion表
		/// </summary>
		public virtual DbSet<CollectionExclosionEntity> CollectionExclosion { get; set; }
		/// <summary>
		/// CollectionFieldRules表
		/// </summary>
		public virtual DbSet<CollectionFieldRulesEntity> CollectionFieldRules { get; set; }
		/// <summary>
		/// CollectionFilterRules表
		/// </summary>
		public virtual DbSet<CollectionFilterRulesEntity> CollectionFilterRules { get; set; }
		/// <summary>
		/// CollectionHistory表
		/// </summary>
		public virtual DbSet<CollectionHistoryEntity> CollectionHistory { get; set; }
		/// <summary>
		/// CollectionItem表
		/// </summary>
		public virtual DbSet<CollectionItemEntity> CollectionItem { get; set; }
		/// <summary>
		/// CollectionListRules表
		/// </summary>
		public virtual DbSet<CollectionListRulesEntity> CollectionListRules { get; set; }
		/// <summary>
		/// CollectionPagingRules表
		/// </summary>
		public virtual DbSet<CollectionPagingRulesEntity> CollectionPagingRules { get; set; }
		/// <summary>
		/// Comment表
		/// </summary>
		public virtual DbSet<CommentEntity> Comment { get; set; }
		/// <summary>
		/// CommentPK表
		/// </summary>
		public virtual DbSet<CommentPKEntity> CommentPK { get; set; }
		/// <summary>
		/// CommonInfo表
		/// </summary>
		public virtual DbSet<CommonInfoEntity> CommonInfo { get; set; }
		/// <summary>
		/// CommonProduct表
		/// </summary>
		public virtual DbSet<CommonProductEntity> CommonProduct { get; set; }
		/// <summary>
		/// Company表
		/// </summary>
		public virtual DbSet<CompanyEntity> Company { get; set; }
		/// <summary>
		/// ComplainLog表
		/// </summary>
		public virtual DbSet<ComplainLogEntity> ComplainLog { get; set; }
		/// <summary>
		/// Complaints表
		/// </summary>
		public virtual DbSet<ComplaintsEntity> Complaints { get; set; }
		/// <summary>
		/// ComplaintsResults表
		/// </summary>
		public virtual DbSet<ComplaintsResultsEntity> ComplaintsResults { get; set; }
		/// <summary>
		/// ComplaintsType表
		/// </summary>
		public virtual DbSet<ComplaintsTypeEntity> ComplaintsType { get; set; }
		/// <summary>
		/// Contacter表
		/// </summary>
		public virtual DbSet<ContacterEntity> Contacter { get; set; }
		/// <summary>
		/// ContentCharge表
		/// </summary>
		public virtual DbSet<ContentChargeEntity> ContentCharge { get; set; }
		/// <summary>
		/// ContentPermission表
		/// </summary>
		public virtual DbSet<ContentPermissionEntity> ContentPermission { get; set; }
		/// <summary>
		/// CorrelativeInfo表
		/// </summary>
		public virtual DbSet<CorrelativeInfoEntity> CorrelativeInfo { get; set; }
		/// <summary>
		/// Coupon表
		/// </summary>
		public virtual DbSet<CouponEntity> Coupon { get; set; }
		/// <summary>
		/// CouponLog表
		/// </summary>
		public virtual DbSet<CouponLogEntity> CouponLog { get; set; }
		/// <summary>
		/// Courier表
		/// </summary>
		public virtual DbSet<CourierEntity> Courier { get; set; }
		/// <summary>
		/// CreditLinesLog表
		/// </summary>
		public virtual DbSet<CreditLinesLogEntity> CreditLinesLog { get; set; }
		/// <summary>
		/// DeliverCharge表
		/// </summary>
		public virtual DbSet<DeliverChargeEntity> DeliverCharge { get; set; }
		/// <summary>
		/// DeliverLog表
		/// </summary>
		public virtual DbSet<DeliverLogEntity> DeliverLog { get; set; }
		/// <summary>
		/// DeliverType表
		/// </summary>
		public virtual DbSet<DeliverTypeEntity> DeliverType { get; set; }
		/// <summary>
		/// Dictionary表
		/// </summary>
		public virtual DbSet<DictionaryEntity> Dictionary { get; set; }
		/// <summary>
		/// DownloadErrorLog表
		/// </summary>
		public virtual DbSet<DownloadErrorLogEntity> DownloadErrorLog { get; set; }
		/// <summary>
		/// DownServer表
		/// </summary>
		public virtual DbSet<DownServerEntity> DownServer { get; set; }
		/// <summary>
		/// ExpLog表
		/// </summary>
		public virtual DbSet<ExpLogEntity> ExpLog { get; set; }
		/// <summary>
		/// Favorite表
		/// </summary>
		public virtual DbSet<FavoriteEntity> Favorite { get; set; }
		/// <summary>
		/// FileRelationInfo表
		/// </summary>
		public virtual DbSet<FileRelationInfoEntity> FileRelationInfo { get; set; }
		/// <summary>
		/// Files表
		/// </summary>
		public virtual DbSet<FilesEntity> Files { get; set; }
		/// <summary>
		/// FlowProcess表
		/// </summary>
		public virtual DbSet<FlowProcessEntity> FlowProcess { get; set; }
		/// <summary>
		/// Friend表
		/// </summary>
		public virtual DbSet<FriendEntity> Friend { get; set; }
		/// <summary>
		/// GroupFieldPermissions表
		/// </summary>
		public virtual DbSet<GroupFieldPermissionsEntity> GroupFieldPermissions { get; set; }
		/// <summary>
		/// GroupNodePermissions表
		/// </summary>
		public virtual DbSet<GroupNodePermissionsEntity> GroupNodePermissions { get; set; }
		/// <summary>
		/// GroupSpecialCategoryPermissions表
		/// </summary>
		public virtual DbSet<GroupSpecialCategoryPermissionsEntity> GroupSpecialCategoryPermissions { get; set; }
		/// <summary>
		/// GroupSpecialPermissions表
		/// </summary>
		public virtual DbSet<GroupSpecialPermissionsEntity> GroupSpecialPermissions { get; set; }
		/// <summary>
		/// HirePurchase表
		/// </summary>
		public virtual DbSet<HirePurchaseEntity> HirePurchase { get; set; }
		/// <summary>
		/// IncludeFile表
		/// </summary>
		public virtual DbSet<IncludeFileEntity> IncludeFile { get; set; }
		/// <summary>
		/// InfoNextProcessRoles表
		/// </summary>
		public virtual DbSet<InfoNextProcessRolesEntity> InfoNextProcessRoles { get; set; }
		/// <summary>
		/// IntegralProduct表
		/// </summary>
		public virtual DbSet<IntegralProductEntity> IntegralProduct { get; set; }
		/// <summary>
		/// IntegralProductType表
		/// </summary>
		public virtual DbSet<IntegralProductTypeEntity> IntegralProductType { get; set; }
		/// <summary>
		/// InvoiceLog表
		/// </summary>
		public virtual DbSet<InvoiceLogEntity> InvoiceLog { get; set; }
		/// <summary>
		/// KeywordRelation表
		/// </summary>
		public virtual DbSet<KeywordRelationEntity> KeywordRelation { get; set; }
		/// <summary>
		/// Keywords表
		/// </summary>
		public virtual DbSet<KeywordsEntity> Keywords { get; set; }
		/// <summary>
		/// Log表
		/// </summary>
		public virtual DbSet<LogEntity> Log { get; set; }
		/// <summary>
		/// MailItem表
		/// </summary>
		public virtual DbSet<MailItemEntity> MailItem { get; set; }
		/// <summary>
		/// MailList表
		/// </summary>
		public virtual DbSet<MailListEntity> MailList { get; set; }
		/// <summary>
		/// MentionLog表
		/// </summary>
		public virtual DbSet<MentionLogEntity> MentionLog { get; set; }
		/// <summary>
		/// Merchant表
		/// </summary>
		public virtual DbSet<MerchantEntity> Merchant { get; set; }
		/// <summary>
		/// Models表
		/// </summary>
		public virtual DbSet<ModelsEntity> Models { get; set; }
		/// <summary>
		/// ModelTemplates表
		/// </summary>
		public virtual DbSet<ModelTemplatesEntity> ModelTemplates { get; set; }
		/// <summary>
		/// Nodes表
		/// </summary>
		public virtual DbSet<NodesEntity> Nodes { get; set; }
		/// <summary>
		/// NodesModelTemplate表
		/// </summary>
		public virtual DbSet<NodesModelTemplateEntity> NodesModelTemplate { get; set; }
		/// <summary>
		/// NodesTemplate表
		/// </summary>
		public virtual DbSet<NodesTemplateEntity> NodesTemplate { get; set; }
		/// <summary>
		/// OrderFeedback表
		/// </summary>
		public virtual DbSet<OrderFeedbackEntity> OrderFeedback { get; set; }
		/// <summary>
		/// OrderItem表
		/// </summary>
		public virtual DbSet<OrderItemEntity> OrderItem { get; set; }
		/// <summary>
		/// OrderLog表
		/// </summary>
		public virtual DbSet<OrderLogEntity> OrderLog { get; set; }
		/// <summary>
		/// Orders表
		/// </summary>
		public virtual DbSet<OrdersEntity> Orders { get; set; }
		/// <summary>
		/// Package表
		/// </summary>
		public virtual DbSet<PackageEntity> Package { get; set; }
		/// <summary>
		/// PaymentLog表
		/// </summary>
		public virtual DbSet<PaymentLogEntity> PaymentLog { get; set; }
		/// <summary>
		/// PaymentType表
		/// </summary>
		public virtual DbSet<PaymentTypeEntity> PaymentType { get; set; }
		/// <summary>
		/// PayPlatForm表
		/// </summary>
		public virtual DbSet<PayPlatFormEntity> PayPlatForm { get; set; }
		/// <summary>
		/// PointLog表
		/// </summary>
		public virtual DbSet<PointLogEntity> PointLog { get; set; }
		/// <summary>
		/// Present表
		/// </summary>
		public virtual DbSet<PresentEntity> Present { get; set; }
		/// <summary>
		/// PresentBuyLog表
		/// </summary>
		public virtual DbSet<PresentBuyLogEntity> PresentBuyLog { get; set; }
		/// <summary>
		/// PresentProject表
		/// </summary>
		public virtual DbSet<PresentProjectEntity> PresentProject { get; set; }
		/// <summary>
		/// ProcessStatusCode表
		/// </summary>
		public virtual DbSet<ProcessStatusCodeEntity> ProcessStatusCode { get; set; }
		/// <summary>
		/// Producer表
		/// </summary>
		public virtual DbSet<ProducerEntity> Producer { get; set; }
		/// <summary>
		/// ProductData表
		/// </summary>
		public virtual DbSet<ProductDataEntity> ProductData { get; set; }
		/// <summary>
		/// ProductPrice表
		/// </summary>
		public virtual DbSet<ProductPriceEntity> ProductPrice { get; set; }
		/// <summary>
		/// Region表
		/// </summary>
		public virtual DbSet<RegionEntity> Region { get; set; }
		/// <summary>
		/// Region_C表
		/// </summary>
		public virtual DbSet<Region_CEntity> Region_C { get; set; }
		/// <summary>
		/// RemindItem表
		/// </summary>
		public virtual DbSet<RemindItemEntity> RemindItem { get; set; }
		/// <summary>
		/// Repayment表
		/// </summary>
		public virtual DbSet<RepaymentEntity> Repayment { get; set; }
		/// <summary>
		/// RoleFieldPermissions表
		/// </summary>
		public virtual DbSet<RoleFieldPermissionsEntity> RoleFieldPermissions { get; set; }
		/// <summary>
		/// RoleNodePermissions表
		/// </summary>
		public virtual DbSet<RoleNodePermissionsEntity> RoleNodePermissions { get; set; }
		/// <summary>
		/// Roles表
		/// </summary>
		public virtual DbSet<RolesEntity> Roles { get; set; }
		/// <summary>
		/// RoleSpecialPermissions表
		/// </summary>
		public virtual DbSet<RoleSpecialPermissionsEntity> RoleSpecialPermissions { get; set; }
		/// <summary>
		/// RolesPermissions表
		/// </summary>
		public virtual DbSet<RolesPermissionsEntity> RolesPermissions { get; set; }
		/// <summary>
		/// RolesProcess表
		/// </summary>
		public virtual DbSet<RolesProcessEntity> RolesProcess { get; set; }
		/// <summary>
		/// ServiceLog表
		/// </summary>
		public virtual DbSet<ServiceLogEntity> ServiceLog { get; set; }
		/// <summary>
		/// ShoppingCarts表
		/// </summary>
		public virtual DbSet<ShoppingCartsEntity> ShoppingCarts { get; set; }
		/// <summary>
		/// SigninContent表
		/// </summary>
		public virtual DbSet<SigninContentEntity> SigninContent { get; set; }
		/// <summary>
		/// SigninLog表
		/// </summary>
		public virtual DbSet<SigninLogEntity> SigninLog { get; set; }
		/// <summary>
		/// SiteLink表
		/// </summary>
		public virtual DbSet<SiteLinkEntity> SiteLink { get; set; }
		/// <summary>
		/// SortingLog表
		/// </summary>
		public virtual DbSet<SortingLogEntity> SortingLog { get; set; }
		/// <summary>
		/// Source表
		/// </summary>
		public virtual DbSet<SourceEntity> Source { get; set; }
		/// <summary>
		/// SpecialCategory表
		/// </summary>
		public virtual DbSet<SpecialCategoryEntity> SpecialCategory { get; set; }
		/// <summary>
		/// SpecialInfos表
		/// </summary>
		public virtual DbSet<SpecialInfosEntity> SpecialInfos { get; set; }
		/// <summary>
		/// Specials表
		/// </summary>
		public virtual DbSet<SpecialsEntity> Specials { get; set; }
		/// <summary>
		/// StatAddress表
		/// </summary>
		public virtual DbSet<StatAddressEntity> StatAddress { get; set; }
		/// <summary>
		/// StatBrowser表
		/// </summary>
		public virtual DbSet<StatBrowserEntity> StatBrowser { get; set; }
		/// <summary>
		/// StatColor表
		/// </summary>
		public virtual DbSet<StatColorEntity> StatColor { get; set; }
		/// <summary>
		/// StatDay表
		/// </summary>
		public virtual DbSet<StatDayEntity> StatDay { get; set; }
		/// <summary>
		/// StatInfoList表
		/// </summary>
		public virtual DbSet<StatInfoListEntity> StatInfoList { get; set; }
		/// <summary>
		/// StatIp表
		/// </summary>
		public virtual DbSet<StatIpEntity> StatIp { get; set; }
		/// <summary>
		/// StatIpInfo表
		/// </summary>
		public virtual DbSet<StatIpInfoEntity> StatIpInfo { get; set; }
		/// <summary>
		/// StatKeyword表
		/// </summary>
		public virtual DbSet<StatKeywordEntity> StatKeyword { get; set; }
		/// <summary>
		/// StatMonth表
		/// </summary>
		public virtual DbSet<StatMonthEntity> StatMonth { get; set; }
		/// <summary>
		/// StatMozilla表
		/// </summary>
		public virtual DbSet<StatMozillaEntity> StatMozilla { get; set; }
		/// <summary>
		/// StatOnline表
		/// </summary>
		public virtual DbSet<StatOnlineEntity> StatOnline { get; set; }
		/// <summary>
		/// StatRefer表
		/// </summary>
		public virtual DbSet<StatReferEntity> StatRefer { get; set; }
		/// <summary>
		/// StatScreen表
		/// </summary>
		public virtual DbSet<StatScreenEntity> StatScreen { get; set; }
		/// <summary>
		/// StatSystem表
		/// </summary>
		public virtual DbSet<StatSystemEntity> StatSystem { get; set; }
		/// <summary>
		/// StatTimezone表
		/// </summary>
		public virtual DbSet<StatTimezoneEntity> StatTimezone { get; set; }
		/// <summary>
		/// Status表
		/// </summary>
		public virtual DbSet<StatusEntity> Status { get; set; }
		/// <summary>
		/// StatVisit表
		/// </summary>
		public virtual DbSet<StatVisitEntity> StatVisit { get; set; }
		/// <summary>
		/// StatVisitor表
		/// </summary>
		public virtual DbSet<StatVisitorEntity> StatVisitor { get; set; }
		/// <summary>
		/// StatWeburl表
		/// </summary>
		public virtual DbSet<StatWeburlEntity> StatWeburl { get; set; }
		/// <summary>
		/// StatWeek表
		/// </summary>
		public virtual DbSet<StatWeekEntity> StatWeek { get; set; }
		/// <summary>
		/// StatYear表
		/// </summary>
		public virtual DbSet<StatYearEntity> StatYear { get; set; }
		/// <summary>
		/// Stock表
		/// </summary>
		public virtual DbSet<StockEntity> Stock { get; set; }
		/// <summary>
		/// StockItem表
		/// </summary>
		public virtual DbSet<StockItemEntity> StockItem { get; set; }
		/// <summary>
		/// StockOut表
		/// </summary>
		public virtual DbSet<StockOutEntity> StockOut { get; set; }
		/// <summary>
		/// Store表
		/// </summary>
		public virtual DbSet<StoreEntity> Store { get; set; }
		/// <summary>
		/// SubscriptionItems表
		/// </summary>
		public virtual DbSet<SubscriptionItemsEntity> SubscriptionItems { get; set; }
		/// <summary>
		/// Survey表
		/// </summary>
		public virtual DbSet<SurveyEntity> Survey { get; set; }
		/// <summary>
		/// SurveyVote表
		/// </summary>
		public virtual DbSet<SurveyVoteEntity> SurveyVote { get; set; }
		/// <summary>
		/// Trademark表
		/// </summary>
		public virtual DbSet<TrademarkEntity> Trademark { get; set; }
		/// <summary>
		/// TransferLog表
		/// </summary>
		public virtual DbSet<TransferLogEntity> TransferLog { get; set; }
		/// <summary>
		/// U_Advice表
		/// </summary>
		public virtual DbSet<U_AdviceEntity> U_Advice { get; set; }
		/// <summary>
		/// U_Answer表
		/// </summary>
		public virtual DbSet<U_AnswerEntity> U_Answer { get; set; }
		/// <summary>
		/// U_Article表
		/// </summary>
		public virtual DbSet<U_ArticleEntity> U_Article { get; set; }
		/// <summary>
		/// U_Award表
		/// </summary>
		public virtual DbSet<U_AwardEntity> U_Award { get; set; }
		/// <summary>
		/// U_AwardLog表
		/// </summary>
		public virtual DbSet<U_AwardLogEntity> U_AwardLog { get; set; }
		/// <summary>
		/// U_Buy表
		/// </summary>
		public virtual DbSet<U_BuyEntity> U_Buy { get; set; }
		/// <summary>
		/// U_Buying表
		/// </summary>
		public virtual DbSet<U_BuyingEntity> U_Buying { get; set; }
		/// <summary>
		/// U_CompanyText表
		/// </summary>
		public virtual DbSet<U_CompanyTextEntity> U_CompanyText { get; set; }
		/// <summary>
		/// U_FriendSite表
		/// </summary>
		public virtual DbSet<U_FriendSiteEntity> U_FriendSite { get; set; }
		/// <summary>
		/// U_GuestBook表
		/// </summary>
		public virtual DbSet<U_GuestBookEntity> U_GuestBook { get; set; }
		/// <summary>
		/// U_IntegralProduct表
		/// </summary>
		public virtual DbSet<U_IntegralProductEntity> U_IntegralProduct { get; set; }
		/// <summary>
		/// U_IntegralProductLog表
		/// </summary>
		public virtual DbSet<U_IntegralProductLogEntity> U_IntegralProductLog { get; set; }
		/// <summary>
		/// U_Manufacture表
		/// </summary>
		public virtual DbSet<U_ManufactureEntity> U_Manufacture { get; set; }
		/// <summary>
		/// U_OrderText表
		/// </summary>
		public virtual DbSet<U_OrderTextEntity> U_OrderText { get; set; }
		/// <summary>
		/// U_Product表
		/// </summary>
		public virtual DbSet<U_ProductEntity> U_Product { get; set; }
		/// <summary>
		/// U_Provide表
		/// </summary>
		public virtual DbSet<U_ProvideEntity> U_Provide { get; set; }
		/// <summary>
		/// U_Question表
		/// </summary>
		public virtual DbSet<U_QuestionEntity> U_Question { get; set; }
		/// <summary>
		/// U_UserText表
		/// </summary>
		public virtual DbSet<U_UserTextEntity> U_UserText { get; set; }
		/// <summary>
		/// UserGroups表
		/// </summary>
		public virtual DbSet<UserGroupsEntity> UserGroups { get; set; }
		/// <summary>
		/// UserMessage表
		/// </summary>
		public virtual DbSet<UserMessageEntity> UserMessage { get; set; }
		/// <summary>
		/// Users表
		/// </summary>
		public virtual DbSet<UsersEntity> Users { get; set; }
		/// <summary>
		/// ValidLog表
		/// </summary>
		public virtual DbSet<ValidLogEntity> ValidLog { get; set; }
		/// <summary>
		/// Vote表
		/// </summary>
		public virtual DbSet<VoteEntity> Vote { get; set; }
		/// <summary>
		/// WordReplaceItem表
		/// </summary>
		public virtual DbSet<WordReplaceItemEntity> WordReplaceItem { get; set; }
		/// <summary>
		/// Work表
		/// </summary>
		public virtual DbSet<WorkEntity> Work { get; set; }
		/// <summary>
		/// WorkCategory表
		/// </summary>
		public virtual DbSet<WorkCategoryEntity> WorkCategory { get; set; }
		/// <summary>
		/// WorkCategorySetting表
		/// </summary>
		public virtual DbSet<WorkCategorySettingEntity> WorkCategorySetting { get; set; }
		/// <summary>
		/// WorkFlows表
		/// </summary>
		public virtual DbSet<WorkFlowsEntity> WorkFlows { get; set; }
		/// <summary>
		/// WorkNextProcessRoles表
		/// </summary>
		public virtual DbSet<WorkNextProcessRolesEntity> WorkNextProcessRoles { get; set; }
		
		#endregion

		/// <summary>
		/// 
		/// </summary>
		/// <param name="modelBuilder"></param>
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			#region 数据库表属性设置
			modelBuilder.Entity<AddressEntity>(entity =>
			{
				entity.HasKey(e => new { e.AddressID });
			});
			modelBuilder.Entity<AdminEntity>(entity =>
			{
				entity.HasKey(e => new { e.AdminID });
			});
			modelBuilder.Entity<AdminRolesEntity>(entity =>
			{
				entity.HasKey(e => new { e.AdminID, e.RoleID });
			});
			modelBuilder.Entity<AdvertisementEntity>(entity =>
			{
				entity.HasKey(e => new { e.ADID });
			});
			modelBuilder.Entity<AdvertisementZoneEntity>(entity =>
			{
				entity.HasKey(e => new { e.ZoneID, e.ADID });
			});
			modelBuilder.Entity<AdZoneEntity>(entity =>
			{
				entity.HasKey(e => new { e.ZoneID });
			});
			modelBuilder.Entity<AuthorEntity>(entity =>
			{
				entity.HasKey(e => new { e.ID });
			});
			modelBuilder.Entity<BankEntity>(entity =>
			{
				entity.HasKey(e => new { e.BankID });
			});
			modelBuilder.Entity<BankrollLogEntity>(entity =>
			{
				entity.HasKey(e => new { e.ItemID });
			});
			modelBuilder.Entity<CardsEntity>(entity =>
			{
				entity.HasKey(e => new { e.CardID });
			});
			modelBuilder.Entity<ClerkEntity>(entity =>
			{
				entity.HasKey(e => new { e.ID });
			});
			modelBuilder.Entity<ClientEntity>(entity =>
			{
				entity.HasKey(e => new { e.ClientID });
			});
			modelBuilder.Entity<ClientLogEntity>(entity =>
			{
				entity.HasKey(e => new { e.ClientLogID });
			});
			modelBuilder.Entity<CollectionExclosionEntity>(entity =>
			{
				entity.HasKey(e => new { e.ExclosionID });
			});
			modelBuilder.Entity<CollectionFieldRulesEntity>(entity =>
			{
				entity.HasKey(e => new { e.FieldRuleID });
			});
			modelBuilder.Entity<CollectionFilterRulesEntity>(entity =>
			{
				entity.HasKey(e => new { e.FilterRuleID });
			});
			modelBuilder.Entity<CollectionHistoryEntity>(entity =>
			{
				entity.HasKey(e => new { e.HistoryID });
			});
			modelBuilder.Entity<CollectionItemEntity>(entity =>
			{
				entity.HasKey(e => new { e.ItemID });
			});
			modelBuilder.Entity<CollectionListRulesEntity>(entity =>
			{
				entity.HasKey(e => new { e.ItemID });
			});
			modelBuilder.Entity<CollectionPagingRulesEntity>(entity =>
			{
				entity.HasKey(e => new { e.PagingRuleID });
			});
			modelBuilder.Entity<CommentEntity>(entity =>
			{
				entity.HasKey(e => new { e.CommentID });
			});
			modelBuilder.Entity<CommentPKEntity>(entity =>
			{
				entity.HasKey(e => new { e.PKID });
			});
			modelBuilder.Entity<CommonInfoEntity>(entity =>
			{
				entity.HasKey(e => new { e.GeneralID });
			});
			modelBuilder.Entity<CommonProductEntity>(entity =>
			{
				entity.HasKey(e => new { e.ProductID });
			});
			modelBuilder.Entity<CompanyEntity>(entity =>
			{
				entity.HasKey(e => new { e.CompanyID });
			});
			modelBuilder.Entity<ComplainLogEntity>(entity =>
			{
				entity.HasKey(e => new { e.ItemID });
			});
			modelBuilder.Entity<ComplaintsEntity>(entity =>
			{
				entity.HasKey(e => new { e.CID });
			});
			modelBuilder.Entity<ComplaintsResultsEntity>(entity =>
			{
				entity.HasKey(e => new { e.RID });
			});
			modelBuilder.Entity<ComplaintsTypeEntity>(entity =>
			{
				entity.HasKey(e => new { e.CID });
			});
			modelBuilder.Entity<ContacterEntity>(entity =>
			{
				entity.HasKey(e => new { e.ContacterID });
			});
			modelBuilder.Entity<ContentChargeEntity>(entity =>
			{
				entity.HasKey(e => new { e.GeneralID });
			});
			modelBuilder.Entity<ContentPermissionEntity>(entity =>
			{
				entity.HasKey(e => new { e.GeneralID });
			});
			modelBuilder.Entity<CorrelativeInfoEntity>(entity =>
			{
				entity.HasKey(e => new { e.ID });
			});
			modelBuilder.Entity<CouponEntity>(entity =>
			{
				entity.HasKey(e => new { e.CouponID });
			});
			modelBuilder.Entity<CouponLogEntity>(entity =>
			{
				entity.HasKey(e => new { e.ID });
			});
			modelBuilder.Entity<CourierEntity>(entity =>
			{
				entity.HasKey(e => new { e.CourierID });
			});
			modelBuilder.Entity<CreditLinesLogEntity>(entity =>
			{
				entity.HasKey(e => new { e.LogID });
			});
			modelBuilder.Entity<DeliverChargeEntity>(entity =>
			{
				entity.HasKey(e => new { e.ID });
			});
			modelBuilder.Entity<DeliverLogEntity>(entity =>
			{
				entity.HasKey(e => new { e.DeliverID });
			});
			modelBuilder.Entity<DeliverTypeEntity>(entity =>
			{
				entity.HasKey(e => new { e.TypeID });
			});
			modelBuilder.Entity<DictionaryEntity>(entity =>
			{
				entity.HasKey(e => new { e.FieldID });
			});
			modelBuilder.Entity<DownloadErrorLogEntity>(entity =>
			{
				entity.HasKey(e => new { e.ErrorID });
			});
			modelBuilder.Entity<DownServerEntity>(entity =>
			{
				entity.HasKey(e => new { e.ServerID });
			});
			modelBuilder.Entity<ExpLogEntity>(entity =>
			{
				entity.HasKey(e => new { e.LogID });
			});
			modelBuilder.Entity<FavoriteEntity>(entity =>
			{
				entity.HasKey(e => new { e.FavoriteID });
			});
			modelBuilder.Entity<FileRelationInfoEntity>(entity =>
			{
				entity.HasKey(e => new { e.ID });
			});
			modelBuilder.Entity<FilesEntity>(entity =>
			{
				entity.HasKey(e => new { e.ID });
			});
			modelBuilder.Entity<FlowProcessEntity>(entity =>
			{
				entity.HasKey(e => new { e.ProcessID });
			});
			modelBuilder.Entity<FriendEntity>(entity =>
			{
				entity.HasKey(e => new { e.ID });
			});
			modelBuilder.Entity<GroupFieldPermissionsEntity>(entity =>
			{
				entity.HasKey(e => new { e.GroupID, e.OperateCode, e.ModelID, e.FieldName, e.IdType });
			});
			modelBuilder.Entity<GroupNodePermissionsEntity>(entity =>
			{
				entity.HasKey(e => new { e.GroupID, e.OperateCode, e.NodeID, e.IdType });
			});
			modelBuilder.Entity<GroupSpecialCategoryPermissionsEntity>(entity =>
			{
				entity.HasKey(e => new { e.GroupID, e.OperateCode, e.SpecialCategoryID, e.IDType });
			});
			modelBuilder.Entity<GroupSpecialPermissionsEntity>(entity =>
			{
				entity.HasKey(e => new { e.GroupID, e.OperateCode, e.SpecialID, e.IDType });
			});
			modelBuilder.Entity<HirePurchaseEntity>(entity =>
			{
				entity.HasKey(e => new { e.ID });
			});
			modelBuilder.Entity<IncludeFileEntity>(entity =>
			{
				entity.HasKey(e => new { e.ID });
			});
			modelBuilder.Entity<InfoNextProcessRolesEntity>(entity =>
			{
				entity.HasKey(e => new { e.GeneralID, e.RoleID });
			});
			modelBuilder.Entity<IntegralProductEntity>(entity =>
			{
				entity.HasKey(e => new { e.ID });
			});
			modelBuilder.Entity<IntegralProductTypeEntity>(entity =>
			{
				entity.HasKey(e => new { e.TypeID });
			});
			modelBuilder.Entity<InvoiceLogEntity>(entity =>
			{
				entity.HasKey(e => new { e.InvoiceID });
			});
			modelBuilder.Entity<KeywordRelationEntity>(entity =>
			{
				entity.HasKey(e => new { e.ID });
			});
			modelBuilder.Entity<KeywordsEntity>(entity =>
			{
				entity.HasKey(e => new { e.KeywordID });
			});
			modelBuilder.Entity<LogEntity>(entity =>
			{
				entity.HasKey(e => new { e.LogID });
			});
			modelBuilder.Entity<MailItemEntity>(entity =>
			{
				entity.HasKey(e => new { e.MailListId, e.SubscriptionItemId });
			});
			modelBuilder.Entity<MailListEntity>(entity =>
			{
				entity.HasKey(e => new { e.ID });
			});
			modelBuilder.Entity<MentionLogEntity>(entity =>
			{
				entity.HasKey(e => new { e.ID });
			});
			modelBuilder.Entity<MerchantEntity>(entity =>
			{
				entity.HasKey(e => new { e.ID });
			});
			modelBuilder.Entity<ModelsEntity>(entity =>
			{
				entity.HasKey(e => new { e.ModelID });
			});
			modelBuilder.Entity<ModelTemplatesEntity>(entity =>
			{
				entity.HasKey(e => new { e.TemplateID });
			});
			modelBuilder.Entity<NodesEntity>(entity =>
			{
				entity.HasKey(e => new { e.NodeID });
			});
			modelBuilder.Entity<NodesModelTemplateEntity>(entity =>
			{
				entity.HasKey(e => new { e.NodeID, e.ModelID });
			});
			modelBuilder.Entity<NodesTemplateEntity>(entity =>
			{
				entity.HasKey(e => new { e.NodeID, e.TemplateID });
			});
			modelBuilder.Entity<OrderFeedbackEntity>(entity =>
			{
				entity.HasKey(e => new { e.ID });
			});
			modelBuilder.Entity<OrderItemEntity>(entity =>
			{
				entity.HasKey(e => new { e.ItemID });
			});
			modelBuilder.Entity<OrderLogEntity>(entity =>
			{
				entity.HasKey(e => new { e.OrderLogID });
			});
			modelBuilder.Entity<OrdersEntity>(entity =>
			{
				entity.HasKey(e => new { e.OrderID });
			});
			modelBuilder.Entity<PackageEntity>(entity =>
			{
				entity.HasKey(e => new { e.PackageID });
			});
			modelBuilder.Entity<PaymentLogEntity>(entity =>
			{
				entity.HasKey(e => new { e.PaymentLogID });
			});
			modelBuilder.Entity<PaymentTypeEntity>(entity =>
			{
				entity.HasKey(e => new { e.TypeID });
			});
			modelBuilder.Entity<PayPlatFormEntity>(entity =>
			{
				entity.HasKey(e => new { e.PayPlatformID });
			});
			modelBuilder.Entity<PointLogEntity>(entity =>
			{
				entity.HasKey(e => new { e.LogID });
			});
			modelBuilder.Entity<PresentEntity>(entity =>
			{
				entity.HasKey(e => new { e.PresentID });
			});
			modelBuilder.Entity<PresentBuyLogEntity>(entity =>
			{
				entity.HasKey(e => new { e.LogID });
			});
			modelBuilder.Entity<PresentProjectEntity>(entity =>
			{
				entity.HasKey(e => new { e.ProjectID });
			});
			modelBuilder.Entity<ProcessStatusCodeEntity>(entity =>
			{
				entity.HasKey(e => new { e.FlowID, e.ProcessID, e.StatusCode });
			});
			modelBuilder.Entity<ProducerEntity>(entity =>
			{
				entity.HasKey(e => new { e.ProducerID });
			});
			modelBuilder.Entity<ProductDataEntity>(entity =>
			{
				entity.HasKey(e => new { e.ID });
			});
			modelBuilder.Entity<ProductPriceEntity>(entity =>
			{
				entity.HasKey(e => new { e.ID });
			});
			modelBuilder.Entity<RegionEntity>(entity =>
			{
				entity.HasKey(e => new { e.RegionID });
			});
			modelBuilder.Entity<Region_CEntity>(entity =>
			{
				entity.HasKey(e => new { e.ID });
			});
			modelBuilder.Entity<RemindItemEntity>(entity =>
			{
				entity.HasKey(e => new { e.RemindID });
			});
			modelBuilder.Entity<RepaymentEntity>(entity =>
			{
				entity.HasKey(e => new { e.ID });
			});
			modelBuilder.Entity<RoleFieldPermissionsEntity>(entity =>
			{
				entity.HasKey(e => new { e.RoleID, e.ModelID, e.FieldName, e.OperateCode });
			});
			modelBuilder.Entity<RoleNodePermissionsEntity>(entity =>
			{
				entity.HasKey(e => new { e.RoleID, e.NodeID, e.OperateCode });
			});
			modelBuilder.Entity<RolesEntity>(entity =>
			{
				entity.HasKey(e => new { e.RoleID });
			});
			modelBuilder.Entity<RoleSpecialPermissionsEntity>(entity =>
			{
				entity.HasKey(e => new { e.RoleID, e.SpecialID, e.OperateCode });
			});
			modelBuilder.Entity<RolesPermissionsEntity>(entity =>
			{
				entity.HasKey(e => new { e.RoleID, e.OperateCode });
			});
			modelBuilder.Entity<RolesProcessEntity>(entity =>
			{
				entity.HasKey(e => new { e.FlowID, e.ProcessID, e.RoleID });
			});
			modelBuilder.Entity<ServiceLogEntity>(entity =>
			{
				entity.HasKey(e => new { e.ItemID });
			});
			modelBuilder.Entity<ShoppingCartsEntity>(entity =>
			{
				entity.HasKey(e => new { e.CartItemID });
			});
			modelBuilder.Entity<SigninContentEntity>(entity =>
			{
				entity.HasKey(e => new { e.GeneralID });
			});
			modelBuilder.Entity<SigninLogEntity>(entity =>
			{
				entity.HasKey(e => new { e.GeneralID, e.UserName });
			});
			modelBuilder.Entity<SiteLinkEntity>(entity =>
			{
				entity.HasKey(e => new { e.InsideLinkID });
			});
			modelBuilder.Entity<SortingLogEntity>(entity =>
			{
				entity.HasKey(e => new { e.ID });
			});
			modelBuilder.Entity<SourceEntity>(entity =>
			{
				entity.HasKey(e => new { e.ID });
			});
			modelBuilder.Entity<SpecialCategoryEntity>(entity =>
			{
				entity.HasKey(e => new { e.SpecialCategoryID });
			});
			modelBuilder.Entity<SpecialInfosEntity>(entity =>
			{
				entity.HasKey(e => new { e.SpecialInfoID, e.SpecialID, e.GeneralID });
			});
			modelBuilder.Entity<SpecialsEntity>(entity =>
			{
				entity.HasKey(e => new { e.SpecialID });
			});
			modelBuilder.Entity<StatAddressEntity>(entity =>
			{
				entity.HasKey(e => new { e.TAddress });
			});
			modelBuilder.Entity<StatBrowserEntity>(entity =>
			{
				entity.HasKey(e => new { e.TBrowser });
			});
			modelBuilder.Entity<StatColorEntity>(entity =>
			{
				entity.HasKey(e => new { e.TColor });
			});
			modelBuilder.Entity<StatDayEntity>(entity =>
			{
				entity.HasKey(e => new { e.TDay });
			});
			modelBuilder.Entity<StatInfoListEntity>(entity =>
			{
				entity.HasKey(e => new { e.ID });
			});
			modelBuilder.Entity<StatIpEntity>(entity =>
			{
				entity.HasKey(e => new { e.TIp });
			});
			modelBuilder.Entity<StatIpInfoEntity>(entity =>
			{
				entity.HasKey(e => new { e.ID });
			});
			modelBuilder.Entity<StatKeywordEntity>(entity =>
			{
				entity.HasKey(e => new { e.TKeyword });
			});
			modelBuilder.Entity<StatMonthEntity>(entity =>
			{
				entity.HasKey(e => new { e.TMonth });
			});
			modelBuilder.Entity<StatMozillaEntity>(entity =>
			{
				entity.HasKey(e => new { e.TMozilla });
			});
			modelBuilder.Entity<StatOnlineEntity>(entity =>
			{
				entity.HasKey(e => new { e.ID });
			});
			modelBuilder.Entity<StatReferEntity>(entity =>
			{
				entity.HasKey(e => new { e.TRefer });
			});
			modelBuilder.Entity<StatScreenEntity>(entity =>
			{
				entity.HasKey(e => new { e.TScreen });
			});
			modelBuilder.Entity<StatSystemEntity>(entity =>
			{
				entity.HasKey(e => new { e.TSystem });
			});
			modelBuilder.Entity<StatTimezoneEntity>(entity =>
			{
				entity.HasKey(e => new { e.TTimezone });
			});
			modelBuilder.Entity<StatusEntity>(entity =>
			{
				entity.HasKey(e => new { e.StatusID });
			});
			modelBuilder.Entity<StatVisitEntity>(entity =>
			{
				entity.HasKey(e => new { e.ID });
			});
			modelBuilder.Entity<StatVisitorEntity>(entity =>
			{
				entity.HasKey(e => new { e.ID });
			});
			modelBuilder.Entity<StatWeburlEntity>(entity =>
			{
				entity.HasKey(e => new { e.TWeburl });
			});
			modelBuilder.Entity<StatWeekEntity>(entity =>
			{
				entity.HasKey(e => new { e.TWeek });
			});
			modelBuilder.Entity<StatYearEntity>(entity =>
			{
				entity.HasKey(e => new { e.TYear });
			});
			modelBuilder.Entity<StockEntity>(entity =>
			{
				entity.HasKey(e => new { e.StockID });
			});
			modelBuilder.Entity<StockItemEntity>(entity =>
			{
				entity.HasKey(e => new { e.ItemID });
			});
			modelBuilder.Entity<StockOutEntity>(entity =>
			{
				entity.HasKey(e => new { e.ID });
			});
			modelBuilder.Entity<StoreEntity>(entity =>
			{
				entity.HasKey(e => new { e.ID });
			});
			modelBuilder.Entity<SubscriptionItemsEntity>(entity =>
			{
				entity.HasKey(e => new { e.Id });
			});
			modelBuilder.Entity<SurveyEntity>(entity =>
			{
				entity.HasKey(e => new { e.SurveyID });
			});
			modelBuilder.Entity<SurveyVoteEntity>(entity =>
			{
				entity.HasKey(e => new { e.ID });
			});
			modelBuilder.Entity<TrademarkEntity>(entity =>
			{
				entity.HasKey(e => new { e.TrademarkID });
			});
			modelBuilder.Entity<TransferLogEntity>(entity =>
			{
				entity.HasKey(e => new { e.TransferLogID });
			});
			modelBuilder.Entity<U_AdviceEntity>(entity =>
			{
				entity.HasKey(e => new { e.ID });
			});
			modelBuilder.Entity<U_AnswerEntity>(entity =>
			{
				entity.HasKey(e => new { e.ID });
			});
			modelBuilder.Entity<U_ArticleEntity>(entity =>
			{
				entity.HasKey(e => new { e.ID });
			});
			modelBuilder.Entity<U_AwardEntity>(entity =>
			{
				entity.HasKey(e => new { e.ID });
			});
			modelBuilder.Entity<U_AwardLogEntity>(entity =>
			{
				entity.HasKey(e => new { e.ID });
			});
			modelBuilder.Entity<U_BuyEntity>(entity =>
			{
				entity.HasKey(e => new { e.ID });
			});
			modelBuilder.Entity<U_BuyingEntity>(entity =>
			{
				entity.HasKey(e => new { e.ID });
			});
			modelBuilder.Entity<U_CompanyTextEntity>(entity =>
			{
				entity.HasKey(e => new { e.ID });
			});
			modelBuilder.Entity<U_FriendSiteEntity>(entity =>
			{
				entity.HasKey(e => new { e.ID });
			});
			modelBuilder.Entity<U_GuestBookEntity>(entity =>
			{
				entity.HasKey(e => new { e.ID });
			});
			modelBuilder.Entity<U_IntegralProductEntity>(entity =>
			{
				entity.HasKey(e => new { e.ID });
			});
			modelBuilder.Entity<U_IntegralProductLogEntity>(entity =>
			{
				entity.HasKey(e => new { e.ID });
			});
			modelBuilder.Entity<U_ManufactureEntity>(entity =>
			{
				entity.HasKey(e => new { e.ID });
			});
			modelBuilder.Entity<U_OrderTextEntity>(entity =>
			{
				entity.HasKey(e => new { e.ID });
			});
			modelBuilder.Entity<U_ProductEntity>(entity =>
			{
				entity.HasKey(e => new { e.ID });
			});
			modelBuilder.Entity<U_ProvideEntity>(entity =>
			{
				entity.HasKey(e => new { e.ID });
			});
			modelBuilder.Entity<U_QuestionEntity>(entity =>
			{
				entity.HasKey(e => new { e.ID });
			});
			modelBuilder.Entity<U_UserTextEntity>(entity =>
			{
				entity.HasKey(e => new { e.ID });
			});
			modelBuilder.Entity<UserGroupsEntity>(entity =>
			{
				entity.HasKey(e => new { e.GroupID });
			});
			modelBuilder.Entity<UserMessageEntity>(entity =>
			{
				entity.HasKey(e => new { e.MessageID });
			});
			modelBuilder.Entity<UsersEntity>(entity =>
			{
				entity.HasKey(e => new { e.UserID });
			});
			modelBuilder.Entity<ValidLogEntity>(entity =>
			{
				entity.HasKey(e => new { e.LogID });
			});
			modelBuilder.Entity<VoteEntity>(entity =>
			{
				entity.HasKey(e => new { e.GeneralId });
			});
			modelBuilder.Entity<WordReplaceItemEntity>(entity =>
			{
				entity.HasKey(e => new { e.ItemID });
			});
			modelBuilder.Entity<WorkEntity>(entity =>
			{
				entity.HasKey(e => new { e.WorkID });
			});
			modelBuilder.Entity<WorkCategoryEntity>(entity =>
			{
				entity.HasKey(e => new { e.ID });
			});
			modelBuilder.Entity<WorkCategorySettingEntity>(entity =>
			{
				entity.HasKey(e => new { e.ID });
			});
			modelBuilder.Entity<WorkFlowsEntity>(entity =>
			{
				entity.HasKey(e => new { e.FlowID });
			});
			modelBuilder.Entity<WorkNextProcessRolesEntity>(entity =>
			{
				entity.HasKey(e => new { e.WorkID, e.RoleID });
			});
			#endregion
			base.OnModelCreating(modelBuilder);
		}
	}
}