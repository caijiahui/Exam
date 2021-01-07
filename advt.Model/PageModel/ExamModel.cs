using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using advt.Entity;

namespace advt.Model.ExamModel
{
    public class ExamModel
    {
       public advt_CMSCategory V_CMSCategory { get; set; }
       public List<advt_topics> L_topics { get; set; }
        public advt_topics V_topics { get; set; }
        public int pageNewsNum { get; set; }
        public string filepath { get; set; }
        public List<KeyValuePair<string, string>> L_state { get; set; }//״̬
        public List<KeyValuePair<int,string>> L_categoryname { get; set; }
        public List<KeyValuePair<string, string>> L_Bit { get; set; }
        public string  username { get; set; }
        public List<advt_users_type> L_usertype { get; set; }
        public advt_users_type V_usertype { get; set; }
        public List<KeyValuePair<string, string>> L_Location { get; set; }//职位
        public List<KeyValuePair<string, string>> L_type { get; set; }//权限
        public bool isAdministrators { get; set; }//是否是管理员
        public string tname { get; set; }


    }
}