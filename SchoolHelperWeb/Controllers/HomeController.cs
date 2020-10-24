using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolHelperDomainModels.Abstraction;
using SchoolHelperDomainServices.Abstraction;
using SchoolHelperDomainServices.Abstraction.ModelServices;
using SchoolHelperWeb.Models;

namespace SchoolHelperWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index([FromServices] ITeacherAccountService teacherAccountService, [FromServices] IStudentAccountService studentAccountService)
        {
            var TeacherAccs = await teacherAccountService.GetTeacherAccountsFromDbAsync();
            var StudentAccs = await studentAccountService.GetStudentAccountsFromDbAsync();
            int[] numbers = { TeacherAccs.Count(), StudentAccs.Count() };
            ViewBag.Message = numbers;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
