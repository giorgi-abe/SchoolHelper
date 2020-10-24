using SchoolHelperApplicationServices.Abstraction;
using SchoolHelperDomainModels.Abstraction;
using SchoolHelperDomainModels.Implementation;
using SchoolHelperDomainServices.Abstraction;
using SchoolHelperDomainServices.Implementation.LoginServices;
using SchoolHelperDomainServices.Implementation.ModelServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHelperApplicationServices.Implementation
{
    public class UserStudentService : IUserStudentService
    {
        private readonly IStudentService _studentService = default;
        public UserStudentService()
        {
            _studentService = new StudentService();
        }
        public async Task<bool> AddStudentAsync(IStudent student)
        {
            try
            {

                var user = await LoginUserHelperManager.GetCurrentUser();
                await _studentService.AddStudentDbAsync(student);       
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteStudentAsync(string key)
        {
            try
            {

                await _studentService.DeleteStudentAsync(key);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<IStudent>> GetStudentsAsync()
        {
            var user = await LoginUserHelperManager.GetCurrentUser();
            var data = await _studentService.GetStudentsFromDbAsync();
            var UserStudents = data.ToList().Where(o => o.TeacherID == user.Key);
            return UserStudents;
        }

        public async Task<bool> UpdateStudentAsync(string key, IStudent student)
        {
            try
            {

                var user = await LoginUserHelperManager.GetCurrentUser();
                await _studentService.UpdateStudentAsync(key,student);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
