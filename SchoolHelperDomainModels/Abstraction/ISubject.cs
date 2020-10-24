using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHelperDomainModels.Abstraction
{
    public interface ISubject
    {
        string Key { get; set; }
        string Name { get; set; }
        IEnumerable<IGrade> Grades { get; set; }
        string TeacherName { get; set; }
        string StudentId { get; set; }

    }
}
