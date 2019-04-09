// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: Model.cs
// 修改时间：2017/9/9 14:44:22
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：Model 的实体类.
	/// </summary>
	public partial class Model
	{
		#region Properties
		/// <summary>
		/// 模型ID
		/// </summary>
		public System.Int32 ModelID{get;set;}
		/// <summary>
		/// 模型名称
		/// </summary>
		public System.String ModelName{get;set;}
		/// <summary>
		/// 模型类型
		/// </summary>
		public System.Int32 ModelType{get;set;}
		/// <summary>
		/// 模型描述
		/// </summary>
		public System.String Description{get;set;}
		/// <summary>
		/// 模型关联的表名
		/// </summary>
		public System.String TableName{get;set;}
		/// <summary>
		/// 项目名称：如文章、新闻、日志、信息
		/// </summary>
		public System.String ItemName{get;set;}
		/// <summary>
		/// 项目单位：如篇、条、个
		/// </summary>
		public System.String ItemUnit{get;set;}
		/// <summary>
		/// 模型图标
		/// </summary>
		public System.String ItemIcon{get;set;}
		/// <summary>
		/// 是否统计点击数
		/// </summary>
		public System.Boolean IsCountHits{get;set;}
		/// <summary>
		/// 是否禁用
		/// </summary>
		public System.Boolean IsDisabled{get;set;}
		/// <summary>
		/// 字段对象
		/// </summary>
		public System.String Field{get;set;}
		/// <summary>
		/// 内容页模板路径
		/// </summary>
		public System.String DefaultTemplateFile{get;set;}
		/// <summary>
		/// 是否启用收费功能
		/// </summary>
		public System.Boolean IsEnableCharge{get;set;}
		/// <summary>
		/// 是否启用签收功能
		/// </summary>
		public System.Boolean IsEnableSignin{get;set;}
		/// <summary>
		/// 添加程序页面路径
		/// </summary>
		public System.String AddInfoFilePath{get;set;}
		/// <summary>
		/// 管理程序页面路径
		/// </summary>
		public System.String ManageInfoFilePath{get;set;}
		/// <summary>
		/// 预览程序页面路径
		/// </summary>
		public System.String PreviewInfoFilePath{get;set;}
		/// <summary>
		/// 批量程序页面路径
		/// </summary>
		public System.String BatchInfoFilePath{get;set;}
		/// <summary>
		/// 商品性质
		/// </summary>
		public System.Int32 Character{get;set;}
		/// <summary>
		/// 每个用户可以在此内容模型下发表多少篇内容
		/// </summary>
		public System.Int32 MaxPerUser{get;set;}
		/// <summary>
		/// 打印页模板
		/// </summary>
		public System.String PrintTemplate{get;set;}
		/// <summary>
		/// 是否允许投票
		/// </summary>
		public System.Boolean IsEnableVote{get;set;}
		/// <summary>
		/// 搜索页模板
		/// </summary>
		public System.String SearchTemplate{get;set;}
		/// <summary>
		/// 高级搜索表单模板
		/// </summary>
		public System.String AdvanceSearchFormTemplate{get;set;}
		/// <summary>
		/// 高级搜索结果模板
		/// </summary>
		public System.String AdvanceSearchTemplate{get;set;}
		/// <summary>
		/// 生成静态页时模型收费提示
		/// </summary>
		public System.String ChargeTips{get;set;}
		/// <summary>
		/// 模型收费提示
		/// </summary>
		public System.String NeedPointChargeTips{get;set;}
		/// <summary>
		/// 模型收费提示
		/// </summary>
		public System.String OutTimeChargeTips{get;set;}
		/// <summary>
		/// 模型收费提示
		/// </summary>
		public System.String UsePointChargeTips{get;set;}
		/// <summary>
		/// 评论页模板
		/// </summary>
		public System.String CommentManageTemplate{get;set;}
		/// <summary>
		/// 匿名投稿模板
		/// </summary>
		public System.String AnonymouseTemplate{get;set;}
		/// <summary>
		/// 用户添加信息模板
		/// </summary>
		public System.String UserAddContentTemplate{get;set;}
		/// <summary>
		/// 验证码
		/// </summary>
		public System.Boolean IsVerificationCode{get;set;}
		/// <summary>
		/// 是否子母表模型
		/// </summary>
		public System.Boolean IsParentChild{get;set;}
		#endregion
	}
}
