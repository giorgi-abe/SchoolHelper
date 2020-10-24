using HotelAppDomainServices.Mappers;
using SchoolHelperDomainModels.Abstraction;
using SchoolHelperDomainModels.Enums;
using SchoolHelperDomainServices.Abstraction.ModelServices;
using SchoolHelperDtos;
using SchoolHelperFIrebase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHelperDomainServices.Implementation.ModelServices
{
    public class TeacherAccountService : ITeacherAccountService
    {
        private readonly AccountRepository _accountRepository = default;
        public TeacherAccountService()
        {
            _accountRepository = new AccountRepository();
        }
        public async Task<bool> AddTeacherAccountDbAsync(ITeacherAccount account)
        {
            return await _accountRepository.CreateAsync(account.Map<ITeacherAccount,AccountDto>());
        }

        public async Task<bool> DeleteTeacherAccountAsync(string key)
        {
            return await _accountRepository.DeleteAsync(key);
        }

        public async Task<IEnumerable<ITeacherAccount>> GetTeacherAccountsFromDbAsync()
        {
            var myTask = Task
                .Run(() => _accountRepository
                    .ReadAccountsAsync()
                    .Result
                    .Where(s => s.Status == Status.Teacher)
                    .Select(o => o.Map<AccountDto, ITeacherAccount>())
                    );
            var data = await myTask;
            return data;
        }

        public async Task<bool> UpdateTeacherAccountAsync(string key, ITeacherAccount account)
        {
            return await _accountRepository.UpdateAsync(key, account.Map<ITeacherAccount, AccountDto>());
        }
    }
}
