using Hostel.PresentationWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Hostel.Common.Models.LogicModels;
using Hostel.BusinessLogic.Services.Interfaces;

namespace Hostel.PresentationWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStudentsService _studentsService;

        public HomeController(ILogger<HomeController> logger, IStudentsService studentsService)
        {
            _studentsService = studentsService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Message = "Hello!";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

         public IActionResult Students()
        {
            return View(_studentsService.GetAllStudents().ToList());
        }

        [HttpPost]
        public IActionResult Students(List<Student> students)
        {
            _studentsService.SaveStudents(students);

            return Students();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
