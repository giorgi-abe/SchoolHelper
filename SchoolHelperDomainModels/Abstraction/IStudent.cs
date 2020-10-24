using SchoolHelperDomainModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHelperDomainModels.Abstraction
{
    public interface IStudent
    {
        string Key { get; set; }
        string Name { get; set; }
        string Surname { get; set; }
        int Number { get; set; }
        string Mail { get; set; }
        string Address { get; set; }
        string Img { get; set; }
        string TeacherID { get; set; }
        IEnumerable<IGrade> Grades { get; set; }
        Gender Gender { get; set; }
        DateTime BirthDay { get; set; }
    }
}
