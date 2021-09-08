﻿using System;
using System.Collections.Generic;

namespace Hostel.DataAccess.Models.DataModels
{
    public class Room
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public char Unit { get; set; }
        public virtual IEnumerable<Student> Students { get; set; }
    }
}
