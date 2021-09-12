using Hostel.Common.Models.LogicModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hostel.PresentationWeb.Models
{
    public class RoomsPageViewModel
    {
        List<Room> roomList;
        List<Student> studentList;

        public List<Room> RoomList { get => roomList; set => roomList = value; }
        public List<Student> StudentList { get => studentList; set => studentList = value; }
    }
}
