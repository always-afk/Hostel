using Hostel.Common.Models.LogicModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostel.BusinessLogic.Services.Implementation
{
    public class MockService : Interfaces.IMockService
    {
        public IEnumerable<Student> GetAllStudents()
        {
            return new List<Student>()
            {
                new Student(fullName:"Ерофеенко Владислав Алексеевич",nationality:"Беларусь",gender:'М',
                    faculty:"ФИТР",course:3,group:10701218,orderNumber:1,dataIn:new DateTime(2018,8,20),dataOut:new DateTime (2022,8,20),"+375441234567",222),

                new Student("Кармальков Артем Витальевич","Беларусь",'М',
                    "ФИТР",3,10701218,2,new DateTime(2018,8,18),new DateTime (2022,8,22),"+375441987567",224),

                new Student("Кузнецов Дмитрий Сергеевич","Россия",'М',
                    "ФИТР",3,10701219,1,new DateTime(2019,7,30),new DateTime (2023,8,26),"+375447751247",225),

                new Student("Лапушко Ирина Валерьевна","Украина",'Ж',
                    "ФММП",3,10701220,1,new DateTime(2020,8,13),new DateTime (2024,9,1),"+375440233567",237),

                new Student("Уайт Уолтер Хартвелл","США",'М',
                    "ИПФ",3,10701218,1,new DateTime(2018,8,22),new DateTime (2022,8,10),"+375441230027",244)
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
