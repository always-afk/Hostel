using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hostel.Common.Models.LogicModels;
using Hostel.DataAccess.Context;

namespace Hostel.DataAccess.Repositories.Implementation
{
    public class SQLStudentRepository : Interfaces.IStudentRepository
    {
        private readonly AppDBContext _context;

        public SQLStudentRepository(AppDBContext context)
        {
            _context = context;
        }

        public void Add(Student s)
        {
            _context.Students.Add(new Models.DataModels.Student() 
            {
                FullName = s.FullName,
                Gender = s.Gender,
                Nationality = s.Nationality,
                PhoneNumber = s.PhoneNumber,
                Faculty = s.Faculty,
                Course = s.Course,
                Group = s.Group,
                OrderNumber = s.OrderNumber,
                DataIn = s.DataIn,
                DataOut = s.DataOut,
                RoomId = s.RoomId
            });
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var studentToDelete = _context.Students.Find(id);

            if(studentToDelete != null)
            {
                _context.Students.Remove(studentToDelete);
                _context.SaveChanges();
            }

        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _context.Students.Select(s => new Student() 
            {
                Id = s.Id,
                FullName = s.FullName,
                Gender = s.Gender,
                Nationality = s.Nationality,
                PhoneNumber = s.PhoneNumber,
                Faculty = s.Faculty,
                Course = s.Course,
                Group = s.Group,
                OrderNumber = s.OrderNumber,
                DataIn = s.DataIn,
                DataOut = s.DataOut,
                RoomId = s.RoomId
            });
        }


        public void ClearDB()
        {
            _context.Database.EnsureDeleted();
        }

        public void Save(List<Student> students)
        {
            var newStudents = ConvertStudents(students);
            foreach(var student in newStudents)
            {
                if (!_context.Students.Contains(student))
                {
                    _context.Students.Add(student);
                }
            }
            foreach(var student in _context.Students)
            {
                if (!newStudents.Contains(student))
                {
                    _context.Students.Remove(student);
                }
            }
            _context.SaveChanges();
        }

        private List<Models.DataModels.Student> ConvertStudents(List<Student> students)
        {
            return students.Select(s => new Models.DataModels.Student()
            {
                Id = s.Id,
                FullName = s.FullName,
                Gender = s.Gender,
                Nationality = s.Nationality,
                PhoneNumber = s.PhoneNumber,
                Faculty = s.Faculty,
                Course = s.Course,
                Group = s.Group,
                OrderNumber = s.OrderNumber,
                DataIn = s.DataIn,
                DataOut = s.DataOut,
                RoomId = s.RoomId
            }).ToList();
        }
    }
}
