using System;

namespace advt.Entity
{
    public partial class ExamSubject
    {

        public string ID { get; set; }

        public string SubjectName { get; set; }//考试类型名称
        public string TypeName { get; set; }//类型ID
        public string ExamRuleId { get; set; }//考试规则

        public string CreateUser { get; set; }

    }
}