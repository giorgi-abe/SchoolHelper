using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolHelperApplicationServices.Abstraction;
using SchoolHelperDomainModels.Abstraction;
using SchoolHelperDomainModels.Enums;
using SchoolHelperDomainModels.Implementation;
using SchoolHelperDomainServices.Abstraction;
using SchoolHelperDomainServices.Implementation.LoginServices;
using SchoolHelperDtos;

namespace SchoolHelperWeb.Controllers
{
    public class TeacherController : Controller
    {
        public async Task<IActionResult> StudentView([FromServices]IUserStudentService studentService)
        {
            var data = await studentService.GetStudentsAsync();
            return View(data);
        }

        [HttpGet]
        public IActionResult Addstudent()
        {
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Addstudent([FromServices]IUserStudentService studentService, [FromServices]IPhotoService photoService, string name, string surname,  int day, int month, int year, int gender, string email, int number, string address, IFormFile image)
        {
            var user = await LoginUserHelperManager.GetCurrentUser();
            IStudent student = new Student()
            {
                Address = address,
                Surname = surname,
                Gender = (Gender)gender,
                Mail = email,
                Name = name,
                Number = number,
                BirthDay = new DateTime(year, month, day),
                TeacherID = user.Key
            };
            if (image != null)
            {
                student.Img = photoService.PhotoLink(image.FileName.Split('\\').LastOrDefault().Split('.').FirstOrDefault());
                photoService.Upload(image.FileName);
            }
            else
            {
                student.Img = photoService.PhotoLink("person2_s1nfj5");
            }
            await studentService.AddStudentAsync(student);
            return RedirectToAction("StudentView");
        }
        public IActionResult UpdateStudent(string id)
        {
            return View();
        }
        public async Task<IActionResult> UpdateStudent()
        {
            return View();
        }
        [HttpGet]

        public IActionResult SendMail(Student student)
        {

            return View(student);
        }
        [HttpPost]
        public async Task<IActionResult> SendMail([FromServices]ISendMailService mailService, string mail,string name,string subject, string maintext)
        {
            var user = await LoginUserHelperManager.GetCurrentUser();
            MailUserDto Receiver = new MailUserDto()
            {
                Mail = mail,
                Username = mail,
            };
            MailUserDto Sender = new MailUserDto()
            {
                Mail = user.User.Mail,
                Username = user.UserName
            };
            MailMessageDto Message = new MailMessageDto
            {
                subject = subject,
                text = maintext,
            };
            await mailService.SentMail(Sender, Receiver, Message);
            return RedirectToAction("StudentView");
        }
        public async Task<IActionResult> DeleteStudent([FromServices]IUserStudentService studentService, string key)
        {
            await studentService.DeleteStudentAsync(key);
            return RedirectToAction("StudentView");
        }

    }
}