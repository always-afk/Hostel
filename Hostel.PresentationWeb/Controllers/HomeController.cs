using Hostel.PresentationWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Hostel.DataAccess.Models.LogicModels;
using Hostel.BusinessLogic.Services.Interfaces;

namespace Hostel.PresentationWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMockService _mock;

        public HomeController(ILogger<HomeController> logger,IMockService mock)
        {
            _mock = mock;
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Message = "TEST!";

            Student newStudent = new Student(fullName: "Ерофеенко Владислав Алексеевич", nationality: "Беларусь", gender: 'М',
                faculty: "ФИТР", course: 3, group: 10701218, orderNumber: 1, dataIn: new DateTime(2018, 8, 20), dataOut: new DateTime(2022, 8, 20), "+375441234567", 222);

            return View(newStudent);
        }

        public IActionResult Privacy()
        {
            return View();
        }

         public IActionResult Students()
        {
            ViewBag.test = "TEST button";
            Student newStudent = new Student(fullName: "Ерофеенко Владислав Алексеевич", nationality: "Беларусь", gender: 'М',
                faculty: "ФИТР", course: 3, group: 10701218, orderNumber: 1, dataIn: new DateTime(2018, 8, 20), dataOut: new DateTime(2022, 8, 20), "+375441234567", 222);

            return View(_mock.GetAllStudents().ToList());
        }

        [HttpPost]
        public IActionResult Students(List<Student> students)
        {
            string result = "\n";
            foreach (var student in students)
            {
                result += student.ViewAll();
            }

            return Content(result);
        }

        //[HttpPost]
        //public IActionResult Students(string fullName)
        //{
        //    return Content($"full name: {fullName}");
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
