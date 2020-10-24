using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHelperDomainModels.Abstraction
{
    public interface ITeacherAccount : IAccount
    {
        IEnumerable<IStudent> Students { get; set; }
    }
}
