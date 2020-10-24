using SchoolHelperDomainModels.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHelperApplicationServices.Abstraction
{
    public interface IUserSubjectService
    {
        Task<bool> AddSubjectAsync(ISubject subject);
        Task<IEnumerable<ISubject>> GetSubjectsAsync();
        Task<bool> UpdateSubjectAsync(string key, ISubject subject);
        Task<bool> DeleteSubjectAsync(string Key);
    }
}
