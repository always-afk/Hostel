using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hostel.DataAccess.Models.LogicModels;

namespace Hostel.DataAccess.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        public IEnumerable<Student> GetAllStudents();

        public void Add(Student newStudent);
    }
}
