using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hostel.DataAccess.Models.LogicModels;

namespace Hostel.BusinessLogic.Services.Interfaces
{
    public interface IMockSrvice
    {
        IEnumerable<Student> GetAllStudents();
        void Save(IEnumerable<Student> students);
    }
}
