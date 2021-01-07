using System;

namespace advt.Config
{

	
	/// <summary>
    /// 基本设置类
	/// </summary>
	public class BaseConfigs
	{

        private static System.Timers.Timer baseConfigTimer = new System.Timers.Timer(60000);

        private static BaseConfigInfo m_configinfo;

		/// <summary>
        /// 静态构造函数初始化相应实例和定时器
		/// </summary>
        static BaseConfigs()
        {
            m_configinfo = BaseConfigFileManager.LoadConfig();
            baseConfigTimer.AutoReset = true;
            baseConfigTimer.Enabled = true;
            baseConfigTimer.Elapsed += new System.Timers.ElapsedEventHandler(Timer_Elapsed); 
            baseConfigTimer.Start();
        }

        private static void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            ResetConfig();
        }
        public static string Admin
        {
            get
            {
                return GetBaseConfig().Admin;
            }
        }
        /// <summary>
        /// 重设配置类实例
        /// </summary>
        public static void ResetConfig()
        {
            m_configinfo = BaseConfigFileManager.LoadConfig();
        }

        /// <summary>
        /// 返回 SMTPServer
        /// </summary>
        public static string GetSMTPServer
        {
            get
            {
                return GetBaseConfig().SMTPServer;
            }
        }

        public static string Passwordkey
        {
            get
            {
                return GetBaseConfig().Passwordkey;
            }
        }

        public static string Miitbeian
        {
            get
            {
                return GetBaseConfig().Miitbeian;
            }
        }
        public static string SiteName
        {
            get
            {
                return GetBaseConfig().SiteName;
            }
        }

        /// <summary>
        /// 返回 SMTPServer
        /// </summary>
        public static string CompanyInfo
        {
            get
            {
                return GetBaseConfig().CompanyInfo;
            }
        }

        /// <summary>
        /// 重设配置类实例
        /// </summary>
        public static void ResetRealConfig()
        {
            m_configinfo = BaseConfigFileManager.LoadRealConfig();
        }

        /// <summary>
        /// 取得BaseConfig配置文件
        /// </summary>
        /// <returns></returns>
		public static BaseConfigInfo GetBaseConfig()
		{
            return m_configinfo;
		}

		/// <summary>
		/// 返回数据库连接串
		/// </summary>
		public static string GetDBConnectString
		{
			get
			{
				return GetBaseConfig().Dbconnectstring;
			}
		}


        /// <summary>
        /// 返回虚拟目录路径
        /// </summary>
        public static string GetDefaultPath
        {
            get
            {
                return GetBaseConfig().Defaultpath;
            }
        }


        /// <summary>
        /// 保存配置实例
        /// </summary>
        /// <param name="baseconfiginfo"></param>
        /// <returns></returns>
        public static bool SaveConfig(BaseConfigInfo baseconfiginfo)
        {
            BaseConfigFileManager acfm = new BaseConfigFileManager();
            BaseConfigFileManager.ConfigInfo = baseconfiginfo;
            return acfm.SaveConfig();
        }

        public static string Cookiename
        {
            get
            {
                return GetBaseConfig().Cookiename;
            }
        }

        public static string Cookiedomain
        {
            get
            {
                return GetBaseConfig().Cookiedomain;
            }
        }

    }
}
