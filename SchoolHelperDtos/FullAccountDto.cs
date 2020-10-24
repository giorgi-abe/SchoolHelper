using SchoolHelperDomainModels.Abstraction;
using SchoolHelperDomainModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHelperDtos
{
    public class FullAccountDto
    {
        public string Key { get; set; }
        public IUser User { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Status Status { get; set; }
        public List<IStudent> Students { get; set; } = new List<IStudent>() { };
        public List<ISubject> Subjects { get; set; } = new List<ISubject>() { };
    }
}
