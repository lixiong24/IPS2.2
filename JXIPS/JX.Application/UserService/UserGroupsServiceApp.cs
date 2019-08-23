using JX.Core;
using JX.Core.Entity;
using JX.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JX.Application
{
	public partial class UserGroupsServiceApp: IUserGroupsServiceApp
	{
		private char[] split = new char[] { ',' };

		#region 仓储接口
		private readonly IUsersRepository _UsersRepository;
		private readonly IGroupFieldPermissionsRepository _GroupFieldPermissionsRepository;
		private readonly IGroupNodePermissionsRepository _GroupNodePermissionsRepository;
		private readonly IGroupSpecialPermissionsRepository _GroupSpecialPermissionsRepository;
		private readonly ILogRepository _LogRepository;
		/// <summary>
		/// 构造器注入
		/// </summary>
		/// <param name="repository"></param>
		/// <param name="usersRepository"></param>
		/// <param name="logRepository"></param>
		public UserGroupsServiceApp(IUserGroupsRepository repository,
			IUsersRepository usersRepository,
			IGroupFieldPermissionsRepository groupFieldPermissionsRepository,
			IGroupNodePermissionsRepository groupNodePermissionsRepository,
			IGroupSpecialPermissionsRepository groupSpecialPermissionsRepository,
			ILogRepository logRepository)
		{
			_repository = repository;
			_UsersRepository = usersRepository;
			_GroupFieldPermissionsRepository = groupFieldPermissionsRepository;
			_GroupNodePermissionsRepository = groupNodePermissionsRepository;
			_GroupSpecialPermissionsRepository = groupSpecialPermissionsRepository;
			_LogRepository = logRepository;
		}
		#endregion

		#region 删除会员组和相关权限
		/// <summary>
		/// 通过主键删除会员组。
		/// 1、删除字段的权限设置。
		/// 2、删除节点的权限设置。
		/// 3、删除专题的权限设置。
		/// 4、删除会员组的权限设置。
		/// </summary>
		/// <param name="groupID"></param>
		/// <returns></returns>
		public async Task<bool> DeleteFullAsync(int groupID)
		{
			if (groupID <= 0)
			{
				return false;
			}
			await DeleteFieldPermissionFromGroup(groupID);
			await DeleteNodePermissionFromGroup(groupID);
			await DeleteSpecialPermissionFromGroup(groupID);
			return await DeleteAsync(p => p.GroupID == groupID);
		}

		/// <summary>
		/// 移除指定会员组的所有模型字段权限
		/// </summary>
		/// <param name="groupID">会员组ID，小于等于0表示所有会员组，-2表示匿名会员组</param>
		/// <param name="idType">权限类型 0：单独设置会员权限；1：继承自会员组权限；</param>
		/// <returns></returns>
		public async Task<bool> DeleteFieldPermissionFromGroup(int groupID = 0, int idType = 1)
		{
			Expression<Func<GroupFieldPermissionsEntity, bool>> predicate = p => true;
			if ((groupID > 0) || (groupID == -2))
			{
				predicate = predicate.And(p => p.GroupID == groupID);
			}
			if (idType >= 0)
			{
				predicate = predicate.And(p => p.IdType == idType);
			}
			return await _GroupFieldPermissionsRepository.DeleteAsync(predicate);
		}

		/// <summary>
		/// 移除指定会员组的所有节点权限
		/// </summary>
		/// <param name="groupID">会员组ID，小于等于0表示所有会员组，-2表示匿名会员组</param>
		/// <param name="nodeId">节点ID，小于等于-3表示所有节点</param>
		/// <param name="operateCode">权限码</param>
		/// <param name="idType">权限类型 0：单独设置会员权限；1：继承自会员组权限；</param>
		/// <returns></returns>
		public async Task<bool> DeleteNodePermissionFromGroup(int groupID = 0, int nodeId = -3, OperateCode operateCode = OperateCode.None, int idType = 1)
		{
			string strCode = "";
			if (operateCode != OperateCode.None)
			{
				strCode = ((int)operateCode).ToString();
			}
			string strNodeID = "";
			if (nodeId > -3)
			{
				strNodeID = nodeId.ToString();
			}
			Expression<Func<GroupNodePermissionsEntity, bool>> predicate = p => true;
			if ((groupID > 0) || (groupID == -2))
			{
				predicate = predicate.And(p => p.GroupID == groupID);
			}
			if (!string.IsNullOrEmpty(strNodeID))
			{
				var arrNodeID = strNodeID.Split(',');
				predicate = predicate.And(p => arrNodeID.Contains(p.NodeID.ToString()));
			}
			if (!string.IsNullOrEmpty(strCode))
			{
				predicate = predicate.And(p => p.OperateCode == strCode);
			}
			return await _GroupNodePermissionsRepository.DeleteAsync(predicate);
		}

		/// <summary>
		/// 移除指定会员组的所有专题权限
		/// </summary>
		/// <param name="groupID">会员组ID，小于等于0表示所有会员组，-2表示匿名会员组</param>
		/// <param name="specialId">专题ID，小于等于0表示所有专题</param>
		/// <param name="operateCode">权限码</param>
		/// <param name="idType">权限类型 0：单独设置会员权限；1：继承自会员组权限；</param>
		/// <returns></returns>
		public async Task<bool> DeleteSpecialPermissionFromGroup(int groupID = 0, int specialId = 0, OperateCode operateCode = OperateCode.None, int idType = 1)
		{
			string strCode = "";
			if (operateCode != OperateCode.None)
			{
				strCode = ((int)operateCode).ToString();
			}
			string strSpecialID = "";
			if (specialId > 0)
			{
				strSpecialID = specialId.ToString();
			}
			Expression<Func<GroupSpecialPermissionsEntity, bool>> predicate = p => true;
			if ((groupID > 0) || (groupID == -2))
			{
				predicate = predicate.And(p => p.GroupID == groupID);
			}
			if (!string.IsNullOrEmpty(strSpecialID))
			{
				var arrNodeID = strSpecialID.Split(',');
				predicate = predicate.And(p => arrNodeID.Contains(p.SpecialID.ToString()));
			}
			if (!string.IsNullOrEmpty(strCode))
			{
				predicate = predicate.And(p => p.OperateCode == strCode);
			}
			return await _GroupSpecialPermissionsRepository.DeleteAsync(predicate);
		}
		#endregion

		#region 会员组－节点权限管理
		/// <summary>
		/// 添加节点权限到会员组
		/// </summary>
		/// <param name="groupId"></param>
		/// <param name="nodeIdAndOperateCode">节点ID与权限码的集合体，多个内容用“,”分隔（例：-2:101005001,-2:101005002）</param>
		/// <param name="idType">权限类型 0：单独设置会员权限；1：继承自会员组权限；</param>
		/// <returns></returns>
		public async Task<bool> AddNodePermissionToUserGroup(int groupId, string nodeIdAndOperateCode, int idType = 1)
		{
			if(groupId <= 0 && groupId != -2)
			{
				return false;
			}
			if (string.IsNullOrWhiteSpace(nodeIdAndOperateCode))
				return false;

			var arrNodeIdAndOperateCode = nodeIdAndOperateCode.Split(split, StringSplitOptions.RemoveEmptyEntries);
			arrNodeIdAndOperateCode = StringHelper.RemoveRepeatItem(arrNodeIdAndOperateCode);
			foreach (string strItem in arrNodeIdAndOperateCode)
			{
				if (!string.IsNullOrWhiteSpace(strItem))
				{
					var arrItem = strItem.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
					var nodeID = DataConverter.CLng(arrItem[0]);
					var operateCodes = arrItem[1];

					await _GroupNodePermissionsRepository.AddAsync(new GroupNodePermissionsEntity() { GroupID = groupId, OperateCode = operateCodes, NodeID = nodeID, IdType = idType });
				}
			}
			return true;
		}
		/// <summary>
		/// 获取指定会员组、指定节点的权限列表
		/// </summary>
		/// <param name="groupId">会员组ID，小于等于0表示所有会员组，-2表示匿名会员组</param>
		/// <param name="nodeId">节点ID，小于等于-3表示所有节点，-2表示首页节点</param>
		/// <param name="operateCode">权限码</param>
		/// <param name="idType">权限类型 0：单独设置会员权限；1：继承自会员组权限；</param>
		/// <returns></returns>
		public async Task<IList<GroupNodePermissionsEntity>> GetNodePermissionsById(int groupId = 0, int nodeId = -3, OperateCode operateCode = OperateCode.None, int idType=1)
		{
			Expression<Func<GroupNodePermissionsEntity, bool>> predicate = p => true;
			if (groupId > 0 || groupId == -2)
			{
				predicate = predicate.And(p => p.GroupID == groupId);
			}
			if (nodeId >= -2)
			{
				predicate = predicate.And(p => p.NodeID == nodeId);
			}
			if(operateCode != OperateCode.None)
			{
				predicate = predicate.And(p => p.OperateCode == ((int)operateCode).ToString());
			}
			if (idType >= 0)
			{
				predicate = predicate.And(p => p.IdType == idType);
			}
			var entityList = await _GroupNodePermissionsRepository.LoadListAllAsync(predicate);
			return entityList;
		}
		#endregion

		#region 会员组－模型字段权限管理
		/// <summary>
		/// 添加模型字段权限到会员组
		/// </summary>
		/// <param name="groupId"></param>
		/// <param name="operateCodes">权限码</param>
		/// <param name="modelIdAndFieldName">模型ID与字段名的集合体，多个内容用“,”分隔（例：11:FieldName,11:FieldName1）</param>
		/// <param name="idType">权限类型 0：单独设置会员权限；1：继承自会员组权限；</param>
		/// <returns></returns>
		public async Task<bool> AddFieldPermissionToUserGroup(int groupId, OperateCode operateCodes, string modelIdAndFieldName, int idType = 1)
		{
			if (groupId <= 0 && groupId != -2)
			{
				return false;
			}
			if (string.IsNullOrWhiteSpace(modelIdAndFieldName))
				return false;

			var arrModelIdAndFieldName = modelIdAndFieldName.Split(split, StringSplitOptions.RemoveEmptyEntries);
			arrModelIdAndFieldName = StringHelper.RemoveRepeatItem(arrModelIdAndFieldName);
			foreach (string strItem in arrModelIdAndFieldName)
			{
				if (!string.IsNullOrEmpty(strItem))
				{
					var arrItem = strItem.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
					var modelID = DataConverter.CLng(arrItem[0]);
					var fieldName = arrItem[1];

					await _GroupFieldPermissionsRepository.AddAsync(new GroupFieldPermissionsEntity() { GroupID = groupId, OperateCode = ((int)operateCodes).ToString(), ModelID = modelID, FieldName = fieldName,IdType=idType });
				}
			}
			return true;
		}
		/// <summary>
		/// 获取指定会员组、指定模型的字段权限列表
		/// </summary>
		/// <param name="groupId">会员组ID，小于等于0表示所有会员组，-2表示匿名会员组</param>
		/// <param name="modelId">模型ID，小于等于0表示所有模型</param>
		/// <param name="idType">权限类型 0：单独设置会员权限；1：继承自会员组权限；</param>
		/// <returns></returns>
		public async Task<IList<GroupFieldPermissionsEntity>> GetFieldPermissionsById(int groupId = 0, int modelId = 0, int idType = 1)
		{
			Expression<Func<GroupFieldPermissionsEntity, bool>> predicate = p => true;
			if (groupId > 0 || groupId == -2)
			{
				predicate = predicate.And(p => p.GroupID == groupId);
			}
			if (modelId > 0)
			{
				predicate = predicate.And(p => p.ModelID == modelId);
			}
			if (idType >= 0)
			{
				predicate = predicate.And(p => p.IdType == idType);
			}
			var entityList = await _GroupFieldPermissionsRepository.LoadListAllAsync(predicate);
			return entityList;
		}
		#endregion

		/// <summary>
		/// 计算会员组集合里的会员总数
		/// </summary>
		/// <param name="userGroupsList"></param>
		public void CountUserNumber(IList<UserGroupsEntity> userGroupsList)
		{
			for (int i = 0; i < userGroupsList.Count; i++)
			{
				userGroupsList[i].UserInGroupNumber = _UsersRepository.GetCount(p=>p.GroupID == userGroupsList[i].GroupID);
			}
		}

		/// <summary>
		/// 判断会员组是否存在
		/// </summary>
		/// <param name="groupName">会员组名称</param>
		/// <returns></returns>
		public bool UserGroupIsExist(string groupName)
		{
			return _repository.IsExist(p => p.GroupName == groupName);
		}

		
	}
}
