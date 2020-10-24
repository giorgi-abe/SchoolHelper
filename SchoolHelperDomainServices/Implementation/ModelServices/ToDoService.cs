using SchoolHelperDomainModels.Abstraction;
using SchoolHelperDomainServices.Abstraction;
using SchoolHelperFIrebase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHelperDomainServices.Implementation.ModelServices
{
    public class ToDoService : IToDoService
    {
        private readonly ToDoRepository _toDoRepository = default;
        public ToDoService()
        {
            _toDoRepository = new ToDoRepository();
        }
        public async Task<bool> AddToDoAsync(IToDo toDo)
        {
            return await _toDoRepository.CreateAsync(toDo);
        }

        public async Task<bool> DeleteToDOAsync(string Key)
        {
            return await _toDoRepository.DeleteAsync(Key);
        }

        public async Task<IEnumerable<IToDo>> GetToDosFromDBAsync()
        {
            var myTask = Task.Run(() => _toDoRepository.ReadToDosAsync().Result);
            var data = await myTask;
            return data;
        }

        public async Task<bool> UpdateToDoAsync(string key, IToDo toDo)
        {
            return await _toDoRepository.UpdateAsync(key, toDo);
        }
    }
}
