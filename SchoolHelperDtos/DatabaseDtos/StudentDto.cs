using SchoolHelperDomainModels.Enums;
using SchoolHelperDomainModels.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHelperDtos
{
    public class StudentDto
    {
        public string Key{ get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Number { get; set; }
        public string Address { get; set; }
        public string Img { get; set; }
        public List<Grade> Grades { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDay { get; set; }
        public string Mail { get; set; }
        public string TeacherID { get; set; }
    }
}
