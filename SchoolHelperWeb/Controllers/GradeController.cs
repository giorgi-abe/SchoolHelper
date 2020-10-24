using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolHelperApplicationServices.Abstraction;
using SchoolHelperDomainModels.Abstraction;
using SchoolHelperDomainModels.Enums;
using SchoolHelperDomainModels.Implementation;
using SchoolHelperDomainServices.Implementation.LoginServices;
using SchoolHelperDtos;

namespace SchoolHelperWeb.Controllers
{
    public class GradeController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Grading(string key)
        {
            ViewBag.Message = key;
            var user = await LoginUserHelperManager.GetCurrentUser();
            ISubject subject = null;
            IStudent student = null;
            if (user.Status == Status.Student)
            {
                subject = user.Subjects.FirstOrDefault(o => o.Key == key);
                if (subject.Grades != null)
                {
                    for (int i = 0; i < subject.Grades.Count(); i++)
                    {
                        subject.Grades.ToList()[i].Id = i;
                    }
                    {
                        subject.Grades = new List<IGrade>();
                    }
                }
            }
            else
            {
                student = user.Students.FirstOrDefault(o => o.Key == key);
                if (student != null)
                {
                    if (student.Grades != null)
                    {
                        for (int i = 0; i < student.Grades.Count(); i++)
                        {
                            student.Grades.ToList()[i].Id = i;
                        }
                    }
                    else
                    {
                        student.Grades = new List<IGrade>();
                    }
                }
            }
            AllGradeDto allGradedto = default;
            if (student != null)
            {
                if (student.Grades == null)
                {
                    allGradedto = new AllGradeDto() { SubjectGrades = subject.Grades };
                }
                else
                {
                    allGradedto = new AllGradeDto() { StudentGrades = student.Grades };
                }
            }else if(student != null)
            {
                allGradedto = new AllGradeDto() { StudentGrades = student.Grades };
            }
            
            return View(allGradedto);
        }
        [HttpPost]
        public async Task<IActionResult> Grading([FromServices] IUserStudentService StudentService, [FromServices] IUserSubjectService SubjectService,string key, string info, int mark, int day, int month, int year, int gradingtype)
        {
            var Subject = await SubjectService.GetSubjectsAsync();
            var students = await StudentService.GetStudentsAsync();

            if (Subject.Count() != 0)
            {
                Subject
                    .FirstOrDefault(o => o.Key == key)
                    .Grades.ToList()
                    .Add(new Grade()
                    {
                        Info = info,
                        grading = (GradingType)gradingtype,
                        Mark = mark,
                        Time = new DateTime(year, month, day)
                    });
            }


            if (students.Count() != 0)
            {
                //var studentsdata = students.ToList();
                //studentsdata
                //    .FirstOrDefault(o => o.Key == key)
                //    .Grades.ToList()
                //    .Add(new Grade()
                //    {
                //        Info = info,
                //        grading = (GradingType)gradingtype,
                //        Mark = mark,
                //        Time = new DateTime(year, month, day)
                //    });
            }
            
            return RedirectToAction("Grading");
        }
        public async Task<IActionResult> Delete(int id, string key)
        {
            var user = await LoginUserHelperManager.GetCurrentUser();
            if (user.Status == Status.Student)
                user.Subjects
                    .FirstOrDefault(o => o.Key == key)
                    .Grades.ToList()
                    .RemoveAt(id);
            else
                user.Students
                    .FirstOrDefault(o => o.Key == key)
                    .Grades.ToList()
                    .RemoveAt(id);
            return RedirectToAction("Grading");
        }
    }
}