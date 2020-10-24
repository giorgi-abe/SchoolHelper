using SchoolHelperDomainModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHelperDomainModels.Abstraction
{
    public interface IAccount 
    {
        string Key { get; set; }
        IUser User { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
        Status Status { get; set; }
        IEnumerable<IToDo> ToDos { get; set; }
    }
}
