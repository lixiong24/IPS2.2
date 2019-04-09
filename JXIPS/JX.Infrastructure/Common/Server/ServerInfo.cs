namespace JX.Infrastructure.Common
{
	/// <summary>
	/// 服务器信息
	/// </summary>
	public class ServerInfo
    {
        private string _ServerIP;
        /// <summary>
        /// 服务器IP
        /// </summary>
        public string ServerIP
        {
            get { return _ServerIP; }
            set { _ServerIP = value; }
        }

        private string _OSVersion;
        /// <summary>
        /// 服务器OS版本
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

        private string _IISVersion;
        /// <summary>
        /// IIS服务器版本
        /// </summary>
        public string IISVersion
        {
            get { return _IISVersion; }
            set { _IISVersion = value; }
        }

        private string _AspNetVersion;
        /// <summary>
        /// ASP.NET版本
        /// </summary>
        public string AspNetVersion
        {
            get { return _AspNetVersion; }
            set { _AspNetVersion = value; }
        }
    }
}
