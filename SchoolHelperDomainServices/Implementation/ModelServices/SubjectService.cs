using HotelAppDomainServices.Mappers;
using SchoolHelperDomainModels.Abstraction;
using SchoolHelperDomainServices.Abstraction.ModelServices;
using SchoolHelperDtos;
using SchoolHelperFIrebase.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHelperDomainServices.Implementation.ModelServices
{
    public class SubjectService : ISubjectService
    {
        private readonly SubjectRepository _subjectRepository = default;
        public SubjectService()
        {
            _subjectRepository = new SubjectRepository();
        }
        public async Task<bool> AddSubjectAsync(ISubject subject)
        {
            return await _subjectRepository.CreateAsync(subject.Map<ISubject, SubjectDto>());
        }

        public async Task<bool> DeleteSubjectAsync(string Key)
        {
            return await _subjectRepository.DeleteAsync(Key);
        }

        public async Task<IEnumerable<ISubject>> GetSubjectsFromDBAsync()
        {
            var myTask = Task.Run(() => _subjectRepository.ReadSubjectsAsync().Result.Select(o => o.Map<SubjectDto, ISubject>()));
            var data = await myTask;
            return data;
        }

        public async Task<bool> UpdateSubjectAsync(string key, ISubject subject)
        {
            return await _subjectRepository.UpdateAsync(key, subject.Map<ISubject, SubjectDto>());
        }
    }
}
