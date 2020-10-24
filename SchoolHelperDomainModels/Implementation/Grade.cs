using SchoolHelperDomainModels.Abstraction;
using SchoolHelperDomainModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHelperDomainModels.Implementation
{
    public class Grade : IGrade
    {
        public DateTime Time { get ; set ; }
        public int Mark { get ; set ; }
        public GradingType grading { get ; set ; }
        public string Info { get; set; }
        public int Id { get; set; }
    }
}
