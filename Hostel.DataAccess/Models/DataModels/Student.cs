using System;
using AutoMapper;
using Hostel.Common.Models.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Hostel.DataAccess.Models.DataModels
{
    public class Student : IMapFrom<Common.Models.LogicModels.Student>
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Nationality { get; set; }
        public char Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Faculty { get; set; }
        public int Course { get; set; }
        public int Group { get; set; }
        public int OrderNumber { get; set; }
        public DateTime DataIn { get; set; }
        public DateTime DataOut { get; set; }
        public int? RoomId { get; set; }
        public virtual Room Room { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Student, Common.Models.LogicModels.Student>()
                .ForMember(x => x.Id, x => x.MapFrom(z => z.Id))
                .ForMember(x => x.FullName, x => x.MapFrom(z => z.FullName))
                .ForMember(x => x.Nationality, x => x.MapFrom(z => z.Nationality))
                .ForMember(x => x.Gender, x => x.MapFrom(z => z.Gender))
                .ForMember(x => x.PhoneNumber, x => x.MapFrom(z => z.PhoneNumber))
                .ForMember(x => x.Faculty, x => x.MapFrom(z => z.Faculty))
                .ForMember(x => x.Course, x => x.MapFrom(z => z.Course))
                .ForMember(x => x.Group, x => x.MapFrom(z => z.Group))
                .ForMember(x => x.OrderNumber, x => x.MapFrom(z => z.OrderNumber))
                .ForMember(x => x.DataIn, x => x.MapFrom(z => z.DataIn))
                .ForMember(x => x.DataOut, x => x.MapFrom(z => z.DataOut))
                .ForMember(x => x.RoomId, x => x.Ignore());

        }

        public Common.Models.LogicModels.Student ToStudent(Student student)
        {
            return new Common.Models.LogicModels.Student()
            {
                Id = student.Id,
                FullName = student.FullName,
                Nationality = student.Nationality,
                Gender = student.Gender,
                PhoneNumber = student.PhoneNumber,
                Faculty = student.Faculty,
                Course = student.Course,
                Group = student.Group,
                OrderNumber = student.OrderNumber,
                DataIn = student.DataIn,
                DataOut = student.DataOut
            };
        }
    }
}
