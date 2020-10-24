using SchoolHelperDomainModels.Abstraction;
using SchoolHelperDomainModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHelperDomainModels.Implementation
{
    public class ToDo : IToDo
    {
        public string Key { get; set; }
        public ToDoType ToDoType { get ; set ; }
        public string Title { get ; set ; }
        public string Main { get ; set ; }
        public DateTime Time { get ; set ; }
    }
}
