using System.Security.Claims;

namespace JX.Infrastructure.Framework
{
	/// <summary>
	/// 身份结果类，用于注册、登录后返回结果使用。
	/// </summary>
	public class IdentityResult
	{
		/// <summary>
		/// 是否成功
		/// </summary>
		public bool IsSuccess { get; }
		/// <summary>
		/// 失败后的错误消息
		/// </summary>
		public string ErrorString { get; }
		/// <summary>
		/// 登录成功后的身份类
		/// </summary>
		public ClaimsPrincipal User { get; }

		/// <summary>
		/// 初始构造，根据错误消息，设置属性
		/// </summary>
		/// <param name="error">错误消息</param>
		public IdentityResult(string error)
		{
			IsSuccess = false;
			ErrorString = error;
		}
		/// <summary>
		/// 初始构造，根据证件当事人类来设置属性
		/// </summary>
		/// <param name="user"></param>
		public IdentityResult(ClaimsPrincipal user)
		{
			IsSuccess = true;
			User = user;
		}
	}
}
