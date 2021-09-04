using System;
using System.Reflection;

namespace Hostel.Common.Models.LogicModels
{
    public class Student
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Nationality { get; set; }
        public char Gender { get; set; }
        public string Faculty { get; set; }
        public int Course { get; set; }
        public int Group { get; set; }
        public int OrderNumber { get; set; }
        public DateTime DataIn { get; set; }
        public DateTime DataOut { get; set; }
        public int? RoomId { get; set; }
        public string PhoneNumber { get; set; }

        public Student()
        {

        }
        public Student(string fullName, string nationality, char gender, string faculty, int course, int group, int orderNumber, DateTime dataIn, DateTime dataOut, string phoneNumber, int? roomId)
        {
            FullName = fullName;
            Nationality = nationality;
            Gender = gender;
            PhoneNumber = phoneNumber;
            Faculty = faculty;
            Course = course;
            Group = group;
            OrderNumber = orderNumber;
            DataIn = dataIn;
            DataOut = dataOut;
            RoomId = roomId;
        }

        public string ViewAll()
        {
            PropertyInfo[] propertyInfo;
            Type type = typeof(Student);
            propertyInfo = type.GetProperties();

            string result = "\n";
            for (var i = 0; i < propertyInfo.Length; i++)
            {
                result += propertyInfo[i].Name + ": ";
                result += propertyInfo[i].GetValue(this) + ";  ";
            }
            result += "\n";



            return result;
        }
    }
}
