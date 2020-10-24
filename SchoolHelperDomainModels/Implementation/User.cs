using SchoolHelperDomainModels.Abstraction;
using SchoolHelperDomainModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHelperDomainModels.Implementation
{
    public class User : IUser
    {
        public string Name { get ; set ; }
        public string Surname { get ; set ; }
        public int Age { get ; set ; }
        public string Mail { get ; set ; }
        public Gender GenderType { get ; set ; }
    }
}
