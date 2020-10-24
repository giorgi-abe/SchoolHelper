using SchoolHelperDomainModels.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHelperApplicationServices.Abstraction
{
    public interface IUserStudentService
    {
        Task<bool> AddStudentAsync(IStudent student);
        Task<IEnumerable<IStudent>> GetStudentsAsync();
        Task<bool> DeleteStudentAsync(string key);
        Task<bool> UpdateStudentAsync(string key, IStudent student);
    }
}
