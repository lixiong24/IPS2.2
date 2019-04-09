using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JX.Infrastructure.Common
{
	/// <summary>
	/// web应用中定义的一些常用配置
	/// </summary>
    public class WebHostConfig
    {
		/// <summary>
		/// 记录日志到数据库的类库名称和程序集名称，用“,”分隔（例：JX.IPS.Biz.LogManager,JX.IPS.Biz）
		/// </summary>
		public string LogFactoryName { get; set; }
		/// <summary>
		/// 程序版本：Base、BaseUser、Industry、Shop
		/// </summary>
		public string Edition { get; set; }
		/// <summary>
		/// 是否启用二级域名功能
		/// </summary>
		public bool EnableSubDomain { get; set; }
		/// <summary>
		/// 是否启用手机端浏览功能
		/// </summary>
		public bool EnableMobileBrowser { get; set; }
		/// <summary>
		/// 是否启用生成静态文件功能
		/// </summary>
		public bool EnableHtml { get; set; }
		/// <summary>
		/// 是否启用评论功能
		/// </summary>
		public bool EnableComment { get; set; }
		/// <summary>
		/// 是否启用CRM功能
		/// </summary>
		public bool EnableCrm { get; set; }
		/// <summary>
		/// 是否启用采集功能
		/// </summary>
		public bool EnableCollection { get; set; }
	}
}
