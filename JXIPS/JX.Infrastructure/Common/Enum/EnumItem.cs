namespace JX.Infrastructure.Common
{
	/// <summary>
	/// 枚举
	/// </summary>
	public class EnumItem
	{
		private int _Value;
		/// <summary>
		/// 枚举值
		/// </summary>
		public int Value
		{
			get { return _Value; }
			set { _Value = value; }
		}

		private string _Name;
		/// <summary>
		/// 枚举名称
		/// </summary>
		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}

		private string _Description;
		/// <summary>
		/// 枚举的描述
		/// </summary>
		public string Description
		{
			get { return _Description; }
			set { _Description = value; }
		}
	}
}
