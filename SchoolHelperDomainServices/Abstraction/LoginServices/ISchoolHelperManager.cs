using SchoolHelperDomainModels.Abstraction;
using SchoolHelperDtos;
using SchoolHelperDtos.LoginDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHelperDomainServices.Abstraction.LoginServices
{
    public interface ISchoolHelperManager
    {
        Task<bool> SingInUser(SignInUserDto obj);
        Task<FullAccountDto> SearchAccount(string userName);
        Task SignOutUser();
    }
}
