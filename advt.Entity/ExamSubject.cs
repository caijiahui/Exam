using System;

namespace advt.Entity
{
    public partial class ExamSubject
    {

        public string ID { get; set; }

        public string SubjectName { get; set; }//������������
        public string TypeId { get; set; }//����ID
        public string ExamRuleId { get; set; }//���Թ���

        public string CreateUser { get; set; }

    }
}