using Hostel.DataAccess.Models.LogicModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostel.BusinessLogic.Services.Implementation
{
    public class MockService : Interfaces.IMockSrvice
    {
        public IEnumerable<Student> GetAllStudents()
        {
            return new List<Student>()
            {
                new Student()
                {
                    Id = 1,
                    FullName = "Artyom",
                    PhoneNumber = "1234567"
                },
                new Student()
                {
                    Id = 2,
                    FullName = "Vlad",
                    PhoneNumber = "2345671"
                }
            };
        }

        public void Save(IEnumerable<Student> students)
        {
            foreach(var s in students)
            {
                Console.WriteLine($"Name:{s.FullName} - Phone Number:{s.PhoneNumber}");
            }
        }
    }
}
