using System;

namespace advt.Entity
{
    public partial class advt_log
    {
        #region advt_log , (Ver:2.3.8) at: 2018/5/5 17:38:29

        public Guid id { get; set; }

        public byte type { get; set; }

        public int? uid { get; set; }

        public string data { get; set; }

        public string fromip { get; set; }

        public string url { get; set; }

        public string fromurl { get; set; }

        public string description { get; set; }

        public DateTime createdt { get; set; }
        #endregion
    }
}