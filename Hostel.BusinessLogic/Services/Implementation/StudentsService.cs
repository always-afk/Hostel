using Hostel.Common.Models.LogicModels;
using Hostel.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostel.BusinessLogic.Services.Implementation
{
    public class StudentsService : Interfaces.IStudentsService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentsService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _studentRepository.GetAllStudents();
        }

        public void SaveStudents(List<Student> students)
        {
            _studentRepository.Save(students);
        }
    }
}
