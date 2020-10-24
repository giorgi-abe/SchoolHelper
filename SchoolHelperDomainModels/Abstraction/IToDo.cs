using SchoolHelperDomainModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHelperDomainModels.Abstraction
{
    public interface IToDo
    {
        string Key { get; set; }
        ToDoType ToDoType { get; set; }
        string Title { get; set; }
        string Main { get; set; }
        DateTime Time { get; set; }
    }
}
