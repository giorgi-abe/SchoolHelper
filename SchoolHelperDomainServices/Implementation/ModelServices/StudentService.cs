using HotelAppDomainServices.Mappers;
using SchoolHelperDomainModels.Abstraction;
using SchoolHelperDomainServices.Abstraction;
using SchoolHelperDtos;
using SchoolHelperFIrebase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHelperDomainServices.Implementation.ModelServices
{
    public class StudentService : IStudentService
    {
        private readonly StudentRepository _studentRepository = default;
        public StudentService()
        {
            _studentRepository = new StudentRepository();
        }
        public async Task<bool> AddStudentDbAsync(IStudent student)
        {
            return await _studentRepository.CreateAsync(student.Map<IStudent, StudentDto>());
        }

        public async Task<bool> DeleteStudentAsync(string key)
        {
            return await _studentRepository.DeleteAsync(key);
        }

        public async Task<IEnumerable<IStudent>> GetStudentsFromDbAsync()
        {
            var myTask = Task.Run(() => _studentRepository.ReadStudentsAsync().Result.Select(o => o.Map<StudentDto, IStudent>()));
            var data = await myTask;
            return data;
        }

        public async Task<bool> UpdateStudentAsync(string key, IStudent student)
        {
            return await _studentRepository.UpdateAsync(key, student.Map<IStudent, StudentDto>());
        }
    }
}
