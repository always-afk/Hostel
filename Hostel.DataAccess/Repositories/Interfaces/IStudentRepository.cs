using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hostel.Common.Models.LogicModels;

namespace Hostel.DataAccess.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        public IEnumerable<Student> GetAllStudents();

        public void Add(Student newStudent);
        public void Save(List<Student> students);
    }
}
