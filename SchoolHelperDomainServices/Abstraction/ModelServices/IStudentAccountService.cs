using SchoolHelperDomainModels.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHelperDomainServices.Abstraction
{
    public interface IStudentAccountService
    {
        Task<bool> AddStudentAccountDbAsync(IStudentAccount account);
        Task<IEnumerable<IStudentAccount>> GetStudentAccountsFromDbAsync();
        Task<bool> DeleteStudentAccountAsync(string key);
        Task<bool> UpdateStudentAccountAsync(string key, IStudentAccount account);
    }
}
