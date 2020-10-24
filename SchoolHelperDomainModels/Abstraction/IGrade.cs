using SchoolHelperDomainModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHelperDomainModels.Abstraction
{
    public interface IGrade
    {
        DateTime Time { get; set; }
        int Mark { get; set; }
        GradingType grading { get; set; }
        string Info { get; set; }
        int Id { get; set; }
    }
}
