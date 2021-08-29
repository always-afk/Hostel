using System;
using System.Collections.Generic;

namespace Hostel.DataAccess.Models.LogicModels
{
    public class Room
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Floor { get; set; }
        public char Unit { get; set; }
        public int MaxStudents { get; set; }
        public virtual IEnumerable<Student> Students { get; set; }
    }
}
