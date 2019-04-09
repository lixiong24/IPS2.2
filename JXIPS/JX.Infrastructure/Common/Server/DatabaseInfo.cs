namespace JX.Infrastructure.Common
{
	/// <summary>
	/// SQL数据库信息
	/// </summary>
	public class DataBaseInfo
    {
        private string _DataSource;
        /// <summary>
		/// SQL Server 实例的名称
        /// </summary>
        public string DataSource
        {
            get { return _DataSource; }
            set { _DataSource = value; }
        }

        private string _MachineName;
        /// <summary>
        /// 服务器主机名
        /// </summary>
        public string MachineName
        {
            get { return _MachineName; }
            set { _MachineName = value; }
        }

        private string _LANGUAGE;
        /// <summary>
        /// 数据库语言
        /// </summary>
        public string LANGUAGE
        {
            get { return _LANGUAGE; }
            set { _LANGUAGE = value; }
        }
        
        private string _ServerVersion;
        /// <summary>
        /// SQL数据库版本
        /// </summary>
        public string ServerVersion
        {
            get { return _ServerVersion; }
            set { _ServerVersion = value; }
        }

        private string _ProductLevel;
        /// <summary>
        /// SQL数据库版本级别：补丁
        /// </summary>
        public string ProductLevel
        {
            get { return _ProductLevel; }
            set { _ProductLevel = value; }
        }

        private string _Edition;
        /// <summary>
        /// SQL数据库版本类别：开发版、标准版、企业版
        /// </summary>
        public string Edition
        {
            get { return _Edition; }
            set { _Edition = value; }
        }
        
        private string _InstanceName;
        /// <summary>
        /// 数据库服务实例名
        /// </summary>
        public string InstanceName
        {
            get { return _InstanceName; }
            set { _InstanceName = value; }
        }

        private string _DatabaseName;
        /// <summary>
        /// 数据库名
        /// </summary>
        public string DatabaseName
        {
            get { return _DatabaseName; }
            set { _DatabaseName = value; }
        }

        private string _MaxSize;
        /// <summary>
        /// 数据库最大大小
        /// </summary>
        public string MaxSize
        {
            get { return _MaxSize; }
            set { _MaxSize = value; }
        }

        private string _UseSize;
        /// <summary>
        /// 数据库当前使用大小
        /// </summary>
        public string UseSize
        {
            get { return _UseSize; }
            set { _UseSize = value; }
        }
    }
}
