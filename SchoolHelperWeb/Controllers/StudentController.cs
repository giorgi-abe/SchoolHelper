using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolHelperApplicationServices.Abstraction;
using SchoolHelperDomainModels.Abstraction;
using SchoolHelperDomainModels.Implementation;
using SchoolHelperDomainServices.Implementation.LoginServices;

namespace SchoolHelperWeb.Controllers
{
    public class StudentController : Controller
    {
        public async Task<IActionResult> SubjectsView([FromServices]IUserSubjectService subjectService)
        {
            var data = await subjectService.GetSubjectsAsync();
            return View(data);
        }
        public async Task<IActionResult> AddSubject([FromServices]IUserSubjectService subjectService, string name, string teachername)
        {
            var user = await LoginUserHelperManager.GetCurrentUser();
            ISubject subject = new Subject()
            {
                Name = name,
                TeacherName = teachername,
                StudentId = user.Key,
        };
            await subjectService.AddSubjectAsync(subject);
            return View("SubjectsView");
        }
        public async Task<IActionResult> Delete([FromServices]IUserSubjectService subjectService, string key)
        {
            await subjectService.DeleteSubjectAsync(key);
            return View("SubjectsView");
        }
    }
}