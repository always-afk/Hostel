using System;
using Microsoft.EntityFrameworkCore;

namespace Hostel.DataAccess.Models.LogicModels
{
    public class Student
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Nationality { get; set; }
        public char Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Faculty { get; set; }
        public int Course { get; set; }
        public int Group { get; set; }
        public int OrderNumber { get; set; }
        public DateTime DataIn { get; set; }
        public DateTime DataOut { get; set; }
        public int? RoomId { get; set; }
    }
}
