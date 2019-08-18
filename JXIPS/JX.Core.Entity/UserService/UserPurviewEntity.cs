using System;
using System.Collections.Generic;
using System.Text;

namespace JX.Core.Entity
{
	/// <summary>
	/// 会员权限信息。
	/// 1、计费方式（只判断金币、只判断有效期、同时判断金币和有效期）。
	/// 2、发表评论的权限。
	/// 3、上传权限。
	/// 4、购物权限（折扣率、透支的最大额度）。
	/// 5、扣金币方式。
	/// 6、发表信息的权限。
	/// 7、收藏信息数量。
	/// 8、发送站内信数量。
	/// 9、能够访问的会员中心页面的权限码。
	/// </summary>
	[Serializable]
	public class UserPurviewEntity
	{
		#region 权限码
		private string m_CheckCode = string.Empty;
		/// <summary>
		/// 会员组或会员能够访问的，会员中心页面的权限码，以“,”分割。
		/// </summary>
		public string AllCheckCode
		{
			get
			{
				return this.m_CheckCode;
			}
			set
			{
				this.m_CheckCode = value;
			}
		}

		private string m_DataCheckCode = string.Empty;
		/// <summary>
		/// 会员组或会员对数据有操作权限的数据权限码，以“,”分割。
		/// </summary>
		public string AllDataCheckCode
		{
			get
			{
				return m_DataCheckCode;
			}
			set
			{
				m_DataCheckCode = value;
			}
		}

		private string m_DataCheckCode1 = string.Empty;
		/// <summary>
		/// 会员组或会员对数据有操作权限的数据权限码，以“,”分割。
		/// </summary>
		public string AllDataCheckCode1
		{
			get
			{
				return m_DataCheckCode1;
			}
			set
			{
				m_DataCheckCode1 = value;
			}
		}

		private string m_DataCheckCode2 = string.Empty;
		/// <summary>
		/// 会员组或会员对数据有操作权限的数据权限码，以“,”分割。
		/// </summary>
		public string AllDataCheckCode2
		{
			get
			{
				return m_DataCheckCode2;
			}
			set
			{
				m_DataCheckCode2 = value;
			}
		}
		#endregion

		#region 计费方式
		private bool m_ChargeByPoint;
		/// <summary>
		/// 计费方式：只判断金币：有金币时，即使有效期已经到期，仍可以查看收费内容；金币用完后，即使有效期没有到期，也不能查看收费内容。
		/// </summary>
		public bool ChargeByPoint
		{
			get
			{
				return this.m_ChargeByPoint;
			}
			set
			{
				this.m_ChargeByPoint = value;
			}
		}

		private bool m_ChargeByPointAndValidDate;
		/// <summary>
		/// 计费方式：同时判断金币和有效期：金币用完并且有效期到期后，才不能查看收费内容。
		/// </summary>
		public bool ChargeByPointAndValidDate
		{
			get
			{
				return this.m_ChargeByPointAndValidDate;
			}
			set
			{
				this.m_ChargeByPointAndValidDate = value;
			}
		}

		private bool m_ChargeByPointOrValidDate;
		/// <summary>
		/// 计费方式：同时判断金币和有效期：金币用完或有效期到期后，就不可查看收费内容。
		/// </summary>
		public bool ChargeByPointOrValidDate
		{
			get
			{
				return this.m_ChargeByPointOrValidDate;
			}
			set
			{
				this.m_ChargeByPointOrValidDate = value;
			}
		}

		private bool m_ChargeByValidDate;
		/// <summary>
		/// 计费方式：只判断有效期：只要在有效期内，金币用完后仍可以查看收费内容；过期后，即使会员有金币也不能查看收费内容。
		/// </summary>
		public bool ChargeByValidDate
		{
			get
			{
				return this.m_ChargeByValidDate;
			}
			set
			{
				this.m_ChargeByValidDate = value;
			}
		}
		#endregion

		#region 评论权限
		private bool m_CommentNeedCheck;
		/// <summary>
		/// 在评论需要审核的栏目里发表评论不需要审核
		/// </summary>
		public bool CommentNeedCheck
		{
			get
			{
				return this.m_CommentNeedCheck;
			}
			set
			{
				this.m_CommentNeedCheck = value;
			}
		}

		private bool m_EnableComment;
		/// <summary>
		/// 在禁止发表评论的栏目里仍然可发表评论
		/// </summary>
		public bool EnableComment
		{
			get
			{
				return this.m_EnableComment;
			}
			set
			{
				this.m_EnableComment = value;
			}
		}
		#endregion

		#region 上传权限
		private bool m_EnableUpload;
		/// <summary>
		/// 允许在开放上传的模型中上传文件
		/// </summary>
		public bool EnableUpload
		{
			get
			{
				return this.m_EnableUpload;
			}
			set
			{
				this.m_EnableUpload = value;
			}
		}

		private int m_UploadSize;
		/// <summary>
		/// 允许上传文件的最大KB数
		/// </summary>
		public int UploadSize
		{
			get
			{
				return this.m_UploadSize;
			}
			set
			{
				this.m_UploadSize = value;
			}
		}

		private bool m_EnableUploadUserPic;
		/// <summary>
		/// 允许上传用户头像
		/// </summary>
		public bool EnableUploadUserPic
		{
			get
			{
				return this.m_EnableUploadUserPic;
			}
			set
			{
				this.m_EnableUploadUserPic = value;
			}
		}

		private int m_UploadCondition;
		/// <summary>
		/// 上传用户头像需要花费的金币数（此数量为消费金币加剩余金币的总和）
		/// </summary>
		public int UploadCondition
		{
			get
			{
				return this.m_UploadCondition;
			}
			set
			{
				this.m_UploadCondition = value;
			}
		}
		#endregion

		#region 商店权限
		private double m_Discount;
		/// <summary>
		/// 购物时可以享受的折扣率
		/// </summary>
		public double Discount
		{
			get
			{
				return this.m_Discount;
			}
			set
			{
				this.m_Discount = value;
			}
		}

		private double m_Overdraft;
		/// <summary>
		/// 购物时允许透支的最大额度
		/// </summary>
		public double Overdraft
		{
			get
			{
				return this.m_Overdraft;
			}
			set
			{
				this.m_Overdraft = value;
			}
		}

		private bool m_SetEnableSale;
		/// <summary>
		/// 会员中心添加商品时候，是否指定为立即销售
		/// </summary>
		public bool SetEnableSale
		{
			get
			{
				return this.m_SetEnableSale;
			}
			set
			{
				this.m_SetEnableSale = value;
			}
		}
		#endregion

		#region 扣金币方式
		private int m_ViewInfoNumberOneDay;
		/// <summary>
		/// 扣金币方式：有效期内，每天可以查看收费信息的最大数（如果为0，则不限制） 
		/// </summary>
		public int ViewInfoNumberOneDay
		{
			get
			{
				return this.m_ViewInfoNumberOneDay;
			}
			set
			{
				this.m_ViewInfoNumberOneDay = value;
			}
		}

		private bool m_WriteToLog;
		/// <summary>
		/// 扣金币方式：有效期内，查看收费内容不扣金币，但做记录。
		/// </summary>
		public bool WriteToLog
		{
			get
			{
				return this.m_WriteToLog;
			}
			set
			{
				this.m_WriteToLog = value;
			}
		}

		private bool m_MinusPoint;
		/// <summary>
		/// 扣金币方式：有效期内，查看收费内容是否扣金币。
		/// </summary>
		public bool MinusPoint
		{
			get
			{
				return this.m_MinusPoint;
			}
			set
			{
				this.m_MinusPoint = value;
			}
		}

		private bool m_NotMinusPointNotWriteToLog;
		/// <summary>
		/// 扣金币方式：有效期内，查看收费内容不扣金币，也不做记录。
		/// </summary>
		public bool NotMinusPointNotWriteToLog
		{
			get
			{
				return this.m_NotMinusPointNotWriteToLog;
			}
			set
			{
				this.m_NotMinusPointNotWriteToLog = value;
			}
		}

		private int m_TotalViewInfoNumber;
		/// <summary>
		/// 扣金币方式：有效期内，总共可以查看的收费信息最大数量（如果为0，则不限制）
		/// </summary>
		public int TotalViewInfoNumber
		{
			get
			{
				return this.m_TotalViewInfoNumber;
			}
			set
			{
				this.m_TotalViewInfoNumber = value;
			}
		}
		#endregion

		#region 发布权限
		private bool m_SetEditor;
		/// <summary>
		/// 发表信息时HTML编辑器是否为高级模式（默认为简洁模式）
		/// </summary>
		public bool SetEditor
		{
			get
			{
				return this.m_SetEditor;
			}
			set
			{
				this.m_SetEditor = value;
			}
		}

		private bool m_IsXssFilter;
		/// <summary>
		/// 会员发表信息时是否启用防止XSS（跨站攻击）
		/// </summary>
		public bool IsXssFilter
		{
			get
			{
				return this.m_IsXssFilter;
			}
			set
			{
				this.m_IsXssFilter = value;
			}
		}

		private int m_GetExp;
		/// <summary>
		/// 发布信息时获取积分为栏目设置的多少倍
		/// </summary>
		public int GetExp
		{
			get
			{
				return this.m_GetExp;
			}
			set
			{
				this.m_GetExp = value;
			}
		}

		private int m_GetPoint;
		/// <summary>
		/// 发布信息时获取点券为栏目设置的多少倍
		/// </summary>
		public int GetPoint
		{
			get
			{
				return this.m_GetPoint;
			}
			set
			{
				this.m_GetPoint = value;
			}
		}

		private int m_MaxPublicInfoOneDay;
		/// <summary>
		/// 每天发布信息最大数（不想限制请设置为0）
		/// </summary>
		public int MaxPublicInfoOneDay
		{
			get
			{
				return this.m_MaxPublicInfoOneDay;
			}
			set
			{
				this.m_MaxPublicInfoOneDay = value;
			}
		}

		private int m_MaxPublicInfo;
		/// <summary>
		/// 总共发布信息最大数（不想限制请设置为0）
		/// </summary>
		public int MaxPublicInfo
		{
			get
			{
				return this.m_MaxPublicInfo;
			}
			set
			{
				this.m_MaxPublicInfo = value;
			}
		}
		#endregion

		#region 收藏夹与站内信
		private int m_MaxSaveInfos;
		/// <summary>
		/// 会员收藏夹内可收录信息的最大数（如果为0，则没有收藏权限）
		/// </summary>
		public int MaxSaveInfos
		{
			get
			{
				return this.m_MaxSaveInfos;
			}
			set
			{
				this.m_MaxSaveInfos = value;
			}
		}

		private int m_MaxSendToUsers;
		/// <summary>
		/// 每次发送站内信可同时发送的最大人数（如果为0，则不允许发送短消息）
		/// </summary>
		public int MaxSendToUsers
		{
			get
			{
				return this.m_MaxSendToUsers;
			}
			set
			{
				this.m_MaxSendToUsers = value;
			}
		}
		#endregion
	}
}
