using SchoolHelperDomainModels.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHelperDomainServices.Abstraction
{
    public interface IStudentService
    {
        Task<bool> AddStudentDbAsync(IStudent student);
        Task<IEnumerable<IStudent>> GetStudentsFromDbAsync();
        Task<bool> DeleteStudentAsync(string key);
        Task<bool> UpdateStudentAsync(string key, IStudent student);
    }
}
