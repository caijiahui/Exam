using System;

namespace advt.Entity
{
    public partial class advt_Category
    {
        #region advt_Category , (Ver:2.3.8) at: 2018/5/5 17:38:29

        public int id { get; set; }

        public string name { get; set; }

        public int pid { get; set; }

        public int? prop { get; set; }

        public byte type { get; set; }

        public string description { get; set; }

        public int displayorder { get; set; }

        public byte available { get; set; }

        public string origin_id { get; set; }

        public int? source { get; set; }

        public int? product_qty { get; set; }

        public string ico_addr { get; set; }

        public string origin_ico_id { get; set; }

        public bool allowdisplay { get; set; }

        public bool allowprominent { get; set; }
        #endregion
    }
}