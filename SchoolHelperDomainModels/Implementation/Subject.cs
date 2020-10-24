using SchoolHelperDomainModels.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHelperDomainModels.Implementation
{
    public class Subject : ISubject
    {
        public string Key { get ; set ; }
        public string Name { get; set; }
        public IEnumerable<IGrade> Grades { get; set; }
        public string TeacherName { get; set; }
        public string StudentId { get; set; }


    }
}
