using HotelAppDomainServices.Mappers;
using SchoolHelperDomainModels.Abstraction;
using SchoolHelperDomainModels.Enums;
using SchoolHelperDomainServices.Abstraction;
using SchoolHelperDtos;
using SchoolHelperFIrebase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHelperDomainServices.Implementation.ModelServices
{
    public class StudentAccountService : IStudentAccountService
    {
        private readonly AccountRepository _accountRepository = default;
        public StudentAccountService()
        {
            _accountRepository = new AccountRepository();
        }
        public async Task<bool> AddStudentAccountDbAsync(IStudentAccount account)
        {
            return await _accountRepository.CreateAsync(account.Map<IStudentAccount, AccountDto>());
        }

        public async Task<bool> DeleteStudentAccountAsync(string key)
        {
            return await _accountRepository.DeleteAsync(key);
        }

        public async Task<IEnumerable<IStudentAccount>> GetStudentAccountsFromDbAsync()
        {
            var myTask = Task
                .Run(() => _accountRepository
                    .ReadAccountsAsync()
                    .Result
                    .Where(s => s.Status == Status.Student )
                    .Select(o => o.Map<AccountDto, IStudentAccount>())
                    );
            var data = await myTask;
            return data;
        }

        public async Task<bool> UpdateStudentAccountAsync(string key, IStudentAccount account)
        {
            return await _accountRepository.UpdateAsync(key,account.Map<IStudentAccount, AccountDto>());
        }
    }
}
