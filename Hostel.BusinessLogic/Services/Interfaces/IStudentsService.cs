using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hostel.Common.Models.LogicModels;

namespace Hostel.BusinessLogic.Services.Interfaces
{
    public interface IStudentsService
    {
        IEnumerable<Student> GetAllStudents();
        void SaveStudents(List<Student> students);
    }
}
