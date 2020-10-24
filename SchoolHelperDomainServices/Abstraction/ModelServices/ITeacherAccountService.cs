using SchoolHelperDomainModels.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHelperDomainServices.Abstraction.ModelServices
{
    public interface ITeacherAccountService
    {
        Task<bool> AddTeacherAccountDbAsync(ITeacherAccount account);
        Task<IEnumerable<ITeacherAccount>> GetTeacherAccountsFromDbAsync();
        Task<bool> DeleteTeacherAccountAsync(string key);
        Task<bool> UpdateTeacherAccountAsync(string key, ITeacherAccount account);
    }
}
