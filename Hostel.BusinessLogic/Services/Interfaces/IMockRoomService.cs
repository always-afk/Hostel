using Hostel.Common.Models.LogicModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostel.BusinessLogic.Services.Interfaces
{
    public interface IMockRoomService
    {
        List<Student> GetAllStudents();
    }
}
