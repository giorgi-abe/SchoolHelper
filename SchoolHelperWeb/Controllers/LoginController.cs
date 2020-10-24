using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelAppDomainServices.Mappers;
using Microsoft.AspNetCore.Mvc;
using SchoolHelperDomainModels.Abstraction;
using SchoolHelperDomainModels.Enums;
using SchoolHelperDomainModels.Implementation;
using SchoolHelperDomainServices.Abstraction;
using SchoolHelperDomainServices.Abstraction.LoginServices;
using SchoolHelperDomainServices.Abstraction.ModelServices;
using SchoolHelperDtos;
using SchoolHelperDtos.LoginDtos;

namespace SchoolHelperWeb.Controllers
{
    public class LoginController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Login([FromServices]ISchoolHelperManager schoolHelperManager, string username, string password)
        {

            var SignUser = new SignInUserDto()
            {
                UserName = username,
                Password = password,
            };
            await schoolHelperManager.SingInUser(SignUser);
            if (schoolHelperManager.SearchAccount(SignUser.UserName).Result.Status == Status.Student)
                return RedirectToAction("SubjectsView", "Student");
            else return RedirectToAction("StudentView", "Teacher");

        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromServices] IStudentAccountService studentAccountService, [FromServices] ITeacherAccountService teacherAccountService, string name, string surname, string email, string username, string password, int age, int gender, int accountType)
        {
            IAccount account = new Account
            {
                Password = password,
                UserName = username,
                Status = (Status)accountType,
                User = new User
                {
                    GenderType = (Gender)gender,
                    Age = age,
                    Surname = surname,
                    Mail = email,
                    Name = name,
                }
                
            };
            if (account.Status == Status.Student)
                await studentAccountService.AddStudentAccountDbAsync(account.Map<IAccount, IStudentAccount>());
            else
                await teacherAccountService.AddTeacherAccountDbAsync(account.Map<IAccount, ITeacherAccount>());

            return RedirectToAction("Login");
        }
        [HttpGet]
        public IActionResult ForgotenPassword()
        {
            return View();
        }
        public  async Task<IActionResult> LogOut([FromServices]ISchoolHelperManager schoolHelperManager)
        {
            await schoolHelperManager.SignOutUser();
            return RedirectToAction("Login");
        }
        public async  Task<IActionResult> ForgotenPassword([FromServices]ISendMailService mailService, [FromServices]ISchoolHelperManager manager , string username)
        {
            var ReceiveAccount = await manager.SearchAccount(username);
            MailUserDto Receiver = new MailUserDto()
            {
                Username = username,
                Mail = ReceiveAccount.User.Mail
            };
            MailUserDto Sender = new MailUserDto()
            {
                Username = "School Helper",
                Mail = "schoolhelperapplication@gmail.com",
            };
            MailMessageDto Message = new MailMessageDto()
            {
                subject = "Password",
                text = $"Your password is {ReceiveAccount.Password}"
            };
            await mailService.SentMail(Sender, Receiver, Message);
            return RedirectToAction("Login");
        }
    }
}