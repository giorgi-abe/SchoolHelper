using SchoolHelperDomainModels.Abstraction;
using SchoolHelperDomainModels.Implementation;
using SchoolHelperDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHelperDomainServices.Implementation.LoginServices
{
    public static class LoginUserHelperManager
    {
        private static FullAccountDto _loginUser = default;
        public static async Task LoginUser(FullAccountDto obj) => _loginUser = obj;
        public static async Task LogOutUser() => _loginUser = default;
        public static async Task<FullAccountDto> GetCurrentUser() => _loginUser;
    }
}
