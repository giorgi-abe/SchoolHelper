using HotelAppDomainServices.Mappers;
using SchoolHelperCustomExceptions;
using SchoolHelperDomainModels.Abstraction;
using SchoolHelperDomainServices.Abstraction;
using SchoolHelperDomainServices.Abstraction.LoginServices;
using SchoolHelperDomainServices.Abstraction.ModelServices;
using SchoolHelperDomainServices.Implementation.ModelServices;
using SchoolHelperDtos;
using SchoolHelperDtos.LoginDtos;
using SchoolHelperFIrebase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHelperDomainServices.Implementation.LoginServices
{
    public class SchoolHelperManager : ISchoolHelperManager
    {
        private readonly IStudentAccountService _studentAccountRepository = default;
        private readonly ITeacherAccountService _teacherAccountRepository = default;
        public SchoolHelperManager()
        {
            _studentAccountRepository = new StudentAccountService();
            _teacherAccountRepository = new TeacherAccountService();
        }
        public async Task<FullAccountDto> SearchAccount(string userName)
        {
            var teacherTask = Task.Run(() => _teacherAccountRepository.GetTeacherAccountsFromDbAsync().Result.FirstOrDefault(o => o.UserName == userName));
            var studentTask = Task.Run(() => _studentAccountRepository.GetStudentAccountsFromDbAsync().Result.FirstOrDefault(o => o.UserName == userName));
            var teacherAccount = await teacherTask;
            var studentAccount = await studentTask;
            if (teacherAccount != default)
                return teacherAccount.Map<ITeacherAccount, FullAccountDto>();
            else
                return studentAccount.Map<IStudentAccount, FullAccountDto>();
            
        }

        public async Task SignOutUser()
        {
            await LoginUserHelperManager.LogOutUser();
        }

        public async Task<bool> SingInUser(SignInUserDto obj)
        {
            try
            {
                var Account = await SearchAccount(obj.UserName);
                if (Account.Password == obj.Password) {
                    if (Account != default)
                        await LoginUserHelperManager.LoginUser(Account);
                    else
                        await LoginUserHelperManager.LoginUser(Account);
                    return true;
                }
                else
                {
                    throw new WrongPasswordException();
                }
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
