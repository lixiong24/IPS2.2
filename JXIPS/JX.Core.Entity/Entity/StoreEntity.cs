// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: StoreEntity.cs
// 修改时间：2019/4/9 17:45:14
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：Store 的实体类.
	/// </summary>
	public partial class StoreEntity
	{
		#region Properties
		private System.Int32 _id = 0;
		/// <summary>
		///  (主键)(自增长)
		/// </summary>
		public System.Int32 ID
		{
			get {return _id;}
			set {_id = value;}
		}
		private System.Int32 _storeMerchantID = 0;
		/// <summary>
		/// 所属商户ID 
		/// </summary>
		public System.Int32 StoreMerchantID
		{
			get {return _storeMerchantID;}
			set {_storeMerchantID = value;}
		}
		private System.String _storeType = string.Empty;
		/// <summary>
		/// 店铺类型 
		/// </summary>
		public System.String StoreType
		{
			get {return _storeType;}
			set {_storeType = value;}
		}
		private System.String _storeName = string.Empty;
		/// <summary>
		/// 店铺名称 
		/// </summary>
		public System.String StoreName
		{
			get {return _storeName;}
			set {_storeName = value;}
		}
		private System.String _storeLinkman = string.Empty;
		/// <summary>
		/// 店铺联系人 
		/// </summary>
		public System.String StoreLinkman
		{
			get {return _storeLinkman;}
			set {_storeLinkman = value;}
		}
		private System.String _storeLinkmanPosition = string.Empty;
		/// <summary>
		/// 店铺联系人职位 
		/// </summary>
		public System.String StoreLinkmanPosition
		{
			get {return _storeLinkmanPosition;}
			set {_storeLinkmanPosition = value;}
		}
		private System.String _storeLinkmanTel = string.Empty;
		/// <summary>
		/// 店铺联系人固话 
		/// </summary>
		public System.String StoreLinkmanTel
		{
			get {return _storeLinkmanTel;}
			set {_storeLinkmanTel = value;}
		}
		private System.String _storeLinkmanMobile = string.Empty;
		/// <summary>
		/// 店铺联系人手机 
		/// </summary>
		public System.String StoreLinkmanMobile
		{
			get {return _storeLinkmanMobile;}
			set {_storeLinkmanMobile = value;}
		}
		private System.Double _storeSize = 0.0f;
		/// <summary>
		/// 店铺面积 
		/// </summary>
		public System.Double StoreSize
		{
			get {return _storeSize;}
			set {_storeSize = value;}
		}
		private System.Int32 _storeNum = 0;
		/// <summary>
		/// 店员人数 
		/// </summary>
		public System.Int32 StoreNum
		{
			get {return _storeNum;}
			set {_storeNum = value;}
		}
		private System.String _businessHours1 = string.Empty;
		/// <summary>
		/// 上班时间 
		/// </summary>
		public System.String BusinessHours1
		{
			get {return _businessHours1;}
			set {_businessHours1 = value;}
		}
		private System.String _businessHours2 = string.Empty;
		/// <summary>
		/// 下班时间 
		/// </summary>
		public System.String BusinessHours2
		{
			get {return _businessHours2;}
			set {_businessHours2 = value;}
		}
		private System.Int32 _estimatedNum = 0;
		/// <summary>
		/// 预计分期数量 
		/// </summary>
		public System.Int32 EstimatedNum
		{
			get {return _estimatedNum;}
			set {_estimatedNum = value;}
		}
		private System.String _storeAccountName = string.Empty;
		/// <summary>
		/// 收款开户名 
		/// </summary>
		public System.String StoreAccountName
		{
			get {return _storeAccountName;}
			set {_storeAccountName = value;}
		}
		private System.String _storeBankHeadOffice = string.Empty;
		/// <summary>
		/// 银行总行名称 
		/// </summary>
		public System.String StoreBankHeadOffice
		{
			get {return _storeBankHeadOffice;}
			set {_storeBankHeadOffice = value;}
		}
		private System.String _storeBankHeadOfficeOther = string.Empty;
		/// <summary>
		/// 银行总行其他 
		/// </summary>
		public System.String StoreBankHeadOfficeOther
		{
			get {return _storeBankHeadOfficeOther;}
			set {_storeBankHeadOfficeOther = value;}
		}
		private System.String _storeBankBranch = string.Empty;
		/// <summary>
		/// 开户行支行 
		/// </summary>
		public System.String StoreBankBranch
		{
			get {return _storeBankBranch;}
			set {_storeBankBranch = value;}
		}
		private System.String _storeBankBranchProvince = string.Empty;
		/// <summary>
		/// 银行支行省份 
		/// </summary>
		public System.String StoreBankBranchProvince
		{
			get {return _storeBankBranchProvince;}
			set {_storeBankBranchProvince = value;}
		}
		private System.String _storeBankBranchCity = string.Empty;
		/// <summary>
		/// 银行支行城市 
		/// </summary>
		public System.String StoreBankBranchCity
		{
			get {return _storeBankBranchCity;}
			set {_storeBankBranchCity = value;}
		}
		private System.String _storeBankBranchArea = string.Empty;
		/// <summary>
		/// 银行支行区域 
		/// </summary>
		public System.String StoreBankBranchArea
		{
			get {return _storeBankBranchArea;}
			set {_storeBankBranchArea = value;}
		}
		private System.String _storeBankAccount = string.Empty;
		/// <summary>
		/// 银行账号 
		/// </summary>
		public System.String StoreBankAccount
		{
			get {return _storeBankAccount;}
			set {_storeBankAccount = value;}
		}
		private System.String _storeZipCode = string.Empty;
		/// <summary>
		/// 邮编 
		/// </summary>
		public System.String StoreZipCode
		{
			get {return _storeZipCode;}
			set {_storeZipCode = value;}
		}
		private System.String _storeProvince = string.Empty;
		/// <summary>
		/// 门店地址省份 
		/// </summary>
		public System.String StoreProvince
		{
			get {return _storeProvince;}
			set {_storeProvince = value;}
		}
		private System.String _storeCity = string.Empty;
		/// <summary>
		/// 门店地址城市 
		/// </summary>
		public System.String StoreCity
		{
			get {return _storeCity;}
			set {_storeCity = value;}
		}
		private System.String _storeArea = string.Empty;
		/// <summary>
		/// 店铺地址区域 
		/// </summary>
		public System.String StoreArea
		{
			get {return _storeArea;}
			set {_storeArea = value;}
		}
		private System.String _storeAddress = string.Empty;
		/// <summary>
		/// 店铺地址详细 
		/// </summary>
		public System.String StoreAddress
		{
			get {return _storeAddress;}
			set {_storeAddress = value;}
		}
		private System.String _storeIDCardPic = string.Empty;
		/// <summary>
		/// 店长身份证图片（多个图片之间用“$$$”分开） 
		/// </summary>
		public System.String StoreIDCardPic
		{
			get {return _storeIDCardPic;}
			set {_storeIDCardPic = value;}
		}
		private System.String _storeFieldPic1 = string.Empty;
		/// <summary>
		/// 实地图片1 
		/// </summary>
		public System.String StoreFieldPic1
		{
			get {return _storeFieldPic1;}
			set {_storeFieldPic1 = value;}
		}
		private System.String _storeFieldPic2 = string.Empty;
		/// <summary>
		/// 实地图片2 
		/// </summary>
		public System.String StoreFieldPic2
		{
			get {return _storeFieldPic2;}
			set {_storeFieldPic2 = value;}
		}
		private System.String _storeConfirmLetterPic = string.Empty;
		/// <summary>
		/// 门店确认函 
		/// </summary>
		public System.String StoreConfirmLetterPic
		{
			get {return _storeConfirmLetterPic;}
			set {_storeConfirmLetterPic = value;}
		}
		private System.String _houseRentalAgreementPic = string.Empty;
		/// <summary>
		/// 房屋租赁合同 
		/// </summary>
		public System.String HouseRentalAgreementPic
		{
			get {return _houseRentalAgreementPic;}
			set {_houseRentalAgreementPic = value;}
		}
		private System.Int32 _storeStatus = 0;
		/// <summary>
		/// 店铺状态（0：未认证；1：已认证；2：未通过；3：已提交；4：待完善；） 
		/// </summary>
		public System.Int32 StoreStatus
		{
			get {return _storeStatus;}
			set {_storeStatus = value;}
		}
		private System.String _storeRemark = string.Empty;
		/// <summary>
		/// 备注 
		/// </summary>
		public System.String StoreRemark
		{
			get {return _storeRemark;}
			set {_storeRemark = value;}
		}
		private System.Int32 _saleID = 0;
		/// <summary>
		/// 所属业务员ID 
		/// </summary>
		public System.Int32 SaleID
		{
			get {return _saleID;}
			set {_saleID = value;}
		}
		private System.Int32 _saleManageID = 0;
		/// <summary>
		/// 所属销售经理ID 
		/// </summary>
		public System.Int32 SaleManageID
		{
			get {return _saleManageID;}
			set {_saleManageID = value;}
		}
		private System.Int32 _saleCityManageID = 0;
		/// <summary>
		/// 城市经理ID 
		/// </summary>
		public System.Int32 SaleCityManageID
		{
			get {return _saleCityManageID;}
			set {_saleCityManageID = value;}
		}
		private System.Int32 _saleLargeAreaManageID = 0;
		/// <summary>
		/// 大区经理 
		/// </summary>
		public System.Int32 SaleLargeAreaManageID
		{
			get {return _saleLargeAreaManageID;}
			set {_saleLargeAreaManageID = value;}
		}
		private System.String _productIDs = string.Empty;
		/// <summary>
		/// 店铺中可以销售的商品ID列表 
		/// </summary>
		public System.String ProductIDs
		{
			get {return _productIDs;}
			set {_productIDs = value;}
		}
		#endregion
	}
}
