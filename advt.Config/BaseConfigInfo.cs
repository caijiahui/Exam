using System;

namespace advt.Config
{
	/// <summary>
	/// 基本设置描述类, 加[Serializable]标记为可序列化
	/// </summary>
	[Serializable]
	public class BaseConfigInfo : IConfigInfo
    {
        public string ReportServicePath { get; set; }
        public string DbconnectstringCTOSCustomer { get; set; }
        public string DbconnectstringDebug { get; set; }
        public string Dbconnectstring { get; set; }
        public string Defaultpath { get; set; }
        public string SMTPServer { get; set; }
        public string Cookiename { get; set; }
        public string Cookiedomain { get; set; }
        public string CompanyInfo { get; set; }
        public string SiteName { get; set; }
        public string Miitbeian { get; set; }
        public string HomeKey { get; set; }
        public string HomeDescription { get; set; }
        public string Passwordkey { get; set; }
        private string m_admin = "jiahui.cai@msa.hinet.net";
        /// <summary>
        /// 管理员信息
        /// </summary>
        public string Admin
        {
            get { return m_admin; }
            set { m_admin = value; }
        }
    }
}
