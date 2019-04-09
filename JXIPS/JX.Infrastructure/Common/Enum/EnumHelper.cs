using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace JX.Infrastructure.Common
{
	/// <summary>
	/// 枚举工具：生成枚举项的描述
	/// 需要在枚举项上定义System.ComponentModel.Description属性
	/// 使用 "反射 + 缓存" 实现
	/// </summary>
	public class EnumHelper
	{
		/// <summary>
		/// 按枚举名称生成其描述
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="name"></param>
		/// <returns></returns>
		public static string GetDescription<T>(string name)
		{
			Dictionary<string, EnumItem> items = getCacheEnum(typeof(T));
			return items[name].Description;
		}
		/// <summary>
		/// 按枚举值生成描述，支持复合FLAG枚举值
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string GetDescription(System.Enum value)
		{
			string desc = "";
			Dictionary<string, EnumItem> items = getCacheEnum(value.GetType());
			foreach (string name in value.ToString("f").Split(','))
			{
				if (items.ContainsKey(name))
				{
					desc += items[name.Trim()].Description + ",";
				}
			}
			return desc.TrimEnd(',');
		}
		/// <summary>
		/// 获取指定枚举项的项列表
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public static Dictionary<string, EnumItem> GetItems<T>()
		{
			return getCacheEnum(typeof(T));
		}

		/// <summary>
		/// 从缓存中得到枚举，不存在则创建。
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		private static Dictionary<string, EnumItem> getCacheEnum(Type type)
		{
			string key = "JX.Infrastructure.Common.EnumHelper." + type.FullName;
			object obj = CacheHelper.CacheServiceProvider.Get(key);
			if (obj == null)
			{
				Dictionary<string, EnumItem> items = new Dictionary<string, EnumItem>();
				FieldInfo[] fields = type.GetFields();
				foreach (FieldInfo field in fields)
				{
					DescriptionAttribute[] attributes = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);
					if (attributes.Length > 0)
					{
						EnumItem item = new EnumItem();
						item.Value = (int)(field.GetValue(field.Name));
						item.Name = field.Name;
						item.Description = attributes[0].Description;
						items.Add(field.Name, item);
					}
				}
				CacheHelper.CacheServiceProvider.AddOrUpdate(key, items);
				return items;
			}
			return obj as Dictionary<string, EnumItem>;
		}
	}
}
