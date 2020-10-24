using SchoolHelperDomainModels.Abstraction;
using SchoolHelperDomainModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHelperDomainModels.Implementation
{
    public class Student : IStudent
    {
        public string Key { get ; set ; }
        public string Name { get ; set ; }
        public string Surname { get ; set ; }
        public int Number { get ; set ; }
        public string Address { get ; set ; }
        public string Img { get ; set ; }
        public IEnumerable<IGrade> Grades { get ; set ; }
        public Gender Gender { get ; set ; }
        public DateTime BirthDay { get ; set ; }
        public string Mail { get; set; }
        public string TeacherID { get; set; }
    }
}
