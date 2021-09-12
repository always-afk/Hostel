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
        private readonly IRoomsService _roomsService;
        private readonly IMockService _mockService;
        private readonly IMockRoomService _mockRoomService;

        public HomeController(ILogger<HomeController> logger, IStudentsService studentsService, IRoomsService roomsService, IMockService mockService, IMockRoomService mockRoomService)
        {
            _studentsService = studentsService;
            _roomsService = roomsService;
            _mockService = mockService;
            _mockRoomService = mockRoomService;
            _logger = logger;
        }
        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult Rooms()
        {
            var model = new Models.RoomsPageViewModel()
            {
                RoomList = _roomsService.GetRooms().ToList(),
                StudentList = _studentsService.GetAllStudents().ToList()

            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Rooms(Models.RoomsPageViewModel model)
        {
            _roomsService.Save(model.RoomList);
            return Rooms();
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
