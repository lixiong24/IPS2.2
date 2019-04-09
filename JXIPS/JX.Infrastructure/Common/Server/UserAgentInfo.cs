namespace JX.Infrastructure.Common
{
	/// <summary>
	/// 客户端用户代理信息
	/// </summary>
	public class UserAgentInfo
    {
        private string _BrowserName;
        /// <summary>
        /// IIS服务器版本
        /// </summary>
        public string BrowserName
        {
            get { return _BrowserName; }
            set { _BrowserName = value; }
        }

        private string _BrowserVersion;
        /// <summary>
        /// IIS服务器版本
        /// </summary>
        public string BrowserVersion
        {
            get { return _BrowserVersion; }
            set { _BrowserVersion = value; }
        }

        private string _OSVersion;
        /// <summary>
        /// 服务器IP
        /// </summary>
        public string OSVersion
        {
            get { return _OSVersion; }
            set { _OSVersion = value; }
        }

        private string _ServicePack;
        /// <summary>
        /// 服务器次版本
        /// </summary>
        public string ServicePack
        {
            get { return _ServicePack; }
            set { _ServicePack = value; }
        }

        private string _UserIP;
        /// <summary>
        /// 服务器次版本
        /// </summary>
        public string UserIP
        {
            get { return _UserIP; }
            set { _UserIP = value; }
        }
    }
}
