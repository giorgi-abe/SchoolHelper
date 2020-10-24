using SchoolHelperDomainModels.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHelperDtos
{
    public class AllGradeDto
    {
        public IEnumerable<IGrade> SubjectGrades { get; set; }
        public IEnumerable<IGrade> StudentGrades { get; set; }
    }
}
