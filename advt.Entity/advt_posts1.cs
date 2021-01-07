using System;

namespace advt.Entity
{
    public partial class advt_posts1
    {
        #region advt_posts1 , (Ver:2.3.8) at: 2018/5/5 17:38:29

        public int id { get; set; }

        public int fid { get; set; }

        public int tid { get; set; }

        public int pid { get; set; }

        public string name { get; set; }

        public string message { get; set; }

        public string ip { get; set; }

        public byte htmlon { get; set; }

        public byte smileon { get; set; }

        public int attachment { get; set; }

        public DateTime createdt { get; set; }

        public int createby { get; set; }

        public byte available { get; set; }
        #endregion
    }
}