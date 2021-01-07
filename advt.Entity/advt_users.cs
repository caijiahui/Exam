using System;

namespace advt.Entity
{
    public partial class advt_users
    {
        #region advt_users , (Ver:2.3.8) at: 2018/5/5 17:38:29

        public int id { get; set; }

        public string username { get; set; }

        public string firstname { get; set; }

        public string lastname { get; set; }

        public string nickname { get; set; }

        public string password { get; set; }

        public byte? sex { get; set; }

        public string lastip { get; set; }

        public string regip { get; set; }

        public string phone { get; set; }

        public string qq { get; set; }

        public string msn { get; set; }

        public string email { get; set; }

        public string description { get; set; }

        public byte? roles { get; set; }

        public int? usergroupid { get; set; }

        public DateTime createdate { get; set; }

        public decimal? extcredits2 { get; set; }

        public decimal? extcredits1 { get; set; }

        public byte status { get; set; }
        #endregion
    }
}