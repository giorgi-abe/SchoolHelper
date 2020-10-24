using SchoolHelperDomainModels.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHelperDtos
{
    public class SubjectDto
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public List<Grade> Grades { get; set; }
        public string TeacherName { get; set; }
        public string StudentId { get; set; }
    }
}
