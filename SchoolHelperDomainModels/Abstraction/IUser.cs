using SchoolHelperDomainModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHelperDomainModels.Abstraction
{
    public interface IUser
    {
        string Name { get; set; }
        string Surname { get; set; }
        int Age { get; set; }
        string Mail { get; set; }
        Gender GenderType { get; set; }
    }
}
