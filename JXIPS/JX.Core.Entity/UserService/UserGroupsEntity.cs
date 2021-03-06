﻿using JX.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JX.Core.Entity
{
	public partial class UserGroupsEntity
	{
		/// <summary>
		/// 会员组类型名称
		/// </summary>
		[NotMapped]
		public string GroupTypeName
		{
			get
			{
				return EnumHelper.GetDescription((GroupTypeEnum)GroupType);
			}
		}

		private int m_UserInGroupNumber=0;
		/// <summary>
		/// 组会员数
		/// </summary>
		[NotMapped]
		public int UserInGroupNumber
		{
			get
			{
				return this.m_UserInGroupNumber;
			}
			set
			{
				this.m_UserInGroupNumber = value;
			}
		}

		private UserPurviewEntity m_UserPurviewEntity;
		/// <summary>
		/// 用户组权限信息
		/// </summary>
		[NotMapped]
		public UserPurviewEntity UserGroupPurview
		{
			get
			{
				if(m_UserPurviewEntity == null)
				{
					if (!string.IsNullOrEmpty(GroupSetting))
					{
						m_UserPurviewEntity = GroupSetting.ToXmlObject<UserPurviewEntity>();
					}
				}
				return m_UserPurviewEntity;
			}
		}
	}
}
