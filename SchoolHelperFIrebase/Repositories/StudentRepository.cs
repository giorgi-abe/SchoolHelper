using SchoolHelperDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHelperFIrebase
{
    public class StudentRepository : Repository<StudentDto>
    {
        private static string _tableName = "Students";
        private static string _databaseConnectionString = "https://schoolhelper-b212c.firebaseio.com/";
        public StudentRepository() : base(_databaseConnectionString, _tableName) { }
        public async Task<IEnumerable<StudentDto>> ReadStudentsAsync()
        {
            var myTask = Task.Run(() => base.ReadAsync().Result.Select(o => new StudentDto()
            {
               Surname = o.Object.Surname,
               Address = o.Object.Address,
               BirthDay = o.Object.BirthDay,
               Gender = o.Object.Gender,
               Grades = o.Object.Grades,
               Key = o.Key,
               Img = o.Object.Img,
               Name = o.Object.Name,
               Number = o.Object.Number,
               Mail = o.Object.Mail,
               TeacherID = o.Object.TeacherID
            }));
            var data = await myTask;
            return data;
        }
    }
}
