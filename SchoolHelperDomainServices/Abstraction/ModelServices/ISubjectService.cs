using SchoolHelperDomainModels.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHelperDomainServices.Abstraction.ModelServices
{
    public interface ISubjectService
    {
        Task<bool> AddSubjectAsync(ISubject subject);
        Task<IEnumerable<ISubject>> GetSubjectsFromDBAsync();
        Task<bool> UpdateSubjectAsync(string key, ISubject subject);
        Task<bool> DeleteSubjectAsync(string Key);
    }
}
