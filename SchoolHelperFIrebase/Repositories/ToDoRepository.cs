using SchoolHelperDomainModels.Abstraction;
using SchoolHelperDomainModels.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHelperFIrebase
{
    public class ToDoRepository : Repository<IToDo>
    {
        private static string _tableName = "ToDos";
        private static string _databaseConnectionString = "https://schoolhelper-b212c.firebaseio.com/";
        public ToDoRepository() : base(_databaseConnectionString, _tableName) { }
        public async Task<IEnumerable<IToDo>> ReadToDosAsync()
        {
            var myTask = Task.Run(() => base.ReadAsync().Result.Select(o => new ToDo()
            {
                Key = o.Key,
                Main = o.Object.Main,
                Time = o.Object.Time,
                Title = o.Object.Title,
                ToDoType = o.Object.ToDoType,
            }));
            var data = await myTask;
            return data;
        }
    }
}
