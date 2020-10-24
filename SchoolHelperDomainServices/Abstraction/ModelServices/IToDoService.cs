using SchoolHelperDomainModels.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHelperDomainServices.Abstraction
{
    public interface IToDoService
    {
        Task<bool> AddToDoAsync(IToDo toDo);
        Task<IEnumerable<IToDo>> GetToDosFromDBAsync();
        Task<bool> UpdateToDoAsync(string key, IToDo toDo);
        Task<bool> DeleteToDOAsync(string Key);
    }
}
