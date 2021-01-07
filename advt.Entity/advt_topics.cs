using System;

namespace advt.Entity
{
    public partial class advt_topics
    {
        public int ids { get; set; }
        public int id { get; set; }

        public int? fid { get; set; }

        public int? tid { get; set; }

        public int? pid { get; set; }

        public DateTime createdt { get; set; }

        public DateTime? updatedt { get; set; }

        public string username { get; set; }

        public string state { get; set; }

        public string attachment { get; set; }

        public string filename { get; set; }

        public string casename { get; set; }

        public string description { get; set; }

        public byte available { get; set; }

        public string item1 { get; set; }

        public string item2 { get; set; }

        public string item3 { get; set; }

        public string item4 { get; set; }

        public string item5 { get; set; }

        public string item6 { get; set; }

        public string item7 { get; set; }

        public string item8 { get; set; }

        public DateTime? item9 { get; set; }

        public string item10 { get; set; }
    }
}