using System;

namespace advt.Entity
{
    public partial class ExamType
    {

        public string ID { get; set; }

        public string TypeName { get; set; }//������������

        public string CreateUser { get; set; }

        public DateTime? CreateDate { get; set; }
    }
}