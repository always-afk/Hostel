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

        public byte MaxStudents { get {
                if (Unit == 'А') return 2;
                else if (Unit == 'Б') return 1;
                else return 0;
            } }

        public List<Student> Students { get; set; }

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
