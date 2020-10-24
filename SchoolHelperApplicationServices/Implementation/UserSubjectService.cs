using SchoolHelperApplicationServices.Abstraction;
using SchoolHelperDomainModels.Abstraction;
using SchoolHelperDomainServices.Abstraction.ModelServices;
using SchoolHelperDomainServices.Implementation.LoginServices;
using SchoolHelperDomainServices.Implementation.ModelServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHelperApplicationServices.Implementation
{
    public class UserSubjectService : IUserSubjectService
    {
        private readonly ISubjectService _subjectService = default;
        public UserSubjectService()
        {
            _subjectService = new SubjectService();
        }
        public async Task<bool> AddSubjectAsync(ISubject subject)
        {
            try
            {
                var user = await LoginUserHelperManager.GetCurrentUser();
                await _subjectService.AddSubjectAsync(subject);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteSubjectAsync(string Key)
        {
            try
            {

                var user = await LoginUserHelperManager.GetCurrentUser();
                await _subjectService.DeleteSubjectAsync(Key);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<ISubject>> GetSubjectsAsync()
        {
            var user = await LoginUserHelperManager.GetCurrentUser();
            var data = await _subjectService.GetSubjectsFromDBAsync();
            var usersubjects = data.Where(o => o.StudentId == user.Key);
            return user.Subjects;
        }

        public async Task<bool> UpdateSubjectAsync(string key, ISubject subject)
        {
            try
            {

                var user = await LoginUserHelperManager.GetCurrentUser();
                await _subjectService.UpdateSubjectAsync(key, subject);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
