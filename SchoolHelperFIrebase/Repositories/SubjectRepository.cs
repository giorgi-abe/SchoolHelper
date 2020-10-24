using SchoolHelperDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHelperFIrebase.Repositories
{
    public class SubjectRepository : Repository<SubjectDto>
    {
        private static string _tableName = "Subjects";
        private static string _databaseConnectionString = "https://schoolhelper-b212c.firebaseio.com/";
        public SubjectRepository() : base(_databaseConnectionString, _tableName) { }

        public async Task<IEnumerable<SubjectDto>> ReadSubjectsAsync()
        {
            var myTask = Task.Run(() => base.ReadAsync().Result.Select(o => new SubjectDto()
            {
                Key = o.Key,
                Grades = o.Object.Grades,
                Name = o.Object.Name,
                StudentId = o.Object.StudentId,
                TeacherName = o.Object.TeacherName,
            }));
            var data = await myTask;
            return data;
        }
    }
}
