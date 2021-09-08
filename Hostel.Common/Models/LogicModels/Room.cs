﻿using System;
using System.Collections.Generic;

namespace Hostel.Common.Models.LogicModels
{
    public class Room
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public char Unit { get; set; }
        public virtual List<Student> Students { get; set; }
    }
}
