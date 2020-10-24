using SchoolHelperDomainModels.Abstraction;
using SchoolHelperDomainModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHelperDomainModels.Implementation
{
    public class Account : IAccount
    {
        public string Key { get ; set ; }
        public IUser User { get ; set ; }
        public string UserName { get ; set ; }
        public string Password { get ; set ; }
        public Status Status { get ; set ; }
        public IEnumerable<IToDo> ToDos { get; set; }
    }
}
