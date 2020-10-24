using SchoolHelperDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHelperFIrebase
{
    public class AccountRepository : Repository<AccountDto>
    {
        private static string _tableName = "Accounts";
        private static string _databaseConnectionString = "https://schoolhelper-b212c.firebaseio.com/";
        public AccountRepository() : base(_databaseConnectionString, _tableName) { }
        public async Task<IEnumerable<AccountDto>> ReadAccountsAsync()
        {
            var myTask = Task.Run(() => base.ReadAsync().Result.Select(o => new AccountDto()
            {
                Status = o.Object.Status,
                Key = o.Key,
                Password = o.Object.Password,
                User = o.Object.User,
                UserName = o.Object.UserName
            }));
            var data = await myTask;
            return data;
        }
    }
}
