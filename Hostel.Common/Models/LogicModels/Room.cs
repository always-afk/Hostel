using System;
using System.Collections.Generic;

namespace Hostel.Common.Models.LogicModels
{
    public class Room
    {



        public int Id { get; set; }
        public int Number { get; set; }
        public char Unit { get; set; }
        public int Floor { get { return Number / 100; } }

        public virtual List<Student> Students { get; set; }

        public Room()
        {
            Students = new List<Student>();
        }
        public Room(int number, char unit, List<Student> students)
        {
            Number = number;
            Unit = unit;
            Students = students;

        }
    }

}
