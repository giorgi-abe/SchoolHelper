using SchoolHelperDomainModels.Abstraction;
using SchoolHelperDomainModels.Enums;
using SchoolHelperDomainModels.Implementation;
using SchoolHelperDomainServices.Implementation.LoginServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHelper
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IAccount account = new StudentAccount()
            { 
                Status = Status.Student,
                Subjects = new List<ISubject>(){ new Subject { Key = "SortedSet", Name = "Teacher"} },
                Key = "tt",
                Password = "as",
                ToDos = new List<IToDo>() { },
                User = new User() { Age =10},
                UserName = "sasas"
            };
             LoginUserHelperManager.LoginUser(account);
            var user = LoginUserHelperManager.GetCurrentUser();
            var Type = user.GetType();
            Console.WriteLine("heelo");
        }
    }
}
