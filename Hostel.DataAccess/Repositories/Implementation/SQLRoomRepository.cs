using Hostel.DataAccess.Repositories.Interfaces;
using Hostel.Common.Models.LogicModels;
using Hostel.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostel.DataAccess.Repositories.Implementation
{
    public class SQLRoomRepository : IRoomRepository
    {
        private readonly AppDBContext _context;

        public SQLRoomRepository(AppDBContext context)
        {
            _context = context;
        }

        public void Add(Room r)
        {
            _context.Rooms.Add(new Models.DataModels.Room() 
            {
                Number = r.Number,
                Unit = r.Unit
            });
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var roomToDelete = _context.Rooms.Find(id);

            if(roomToDelete != null)
            {
                _context.Rooms.Remove(roomToDelete);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Room> GetAllRooms()
        {
            return _context.Rooms.Select(r => new Room 
            { 
                Id = r.Id,
                Number = r.Number,
                Unit = r.Unit
                //Students = Enumerable.Range(0,r.Students.ToList().Count).Select(student => new Student() {
                //    FullName = r.Students.ToList()[0].FullName
                //}).ToList()
                
            });
        }

        public void Fill()
        {

        }

        public void Save(List<Room> rooms)
        {
            var newRooms = Convert(rooms);
            foreach(var room in newRooms)
            {
                if(!_context.Rooms.Any(r => r.Number == room.Number && r.Unit == room.Unit))
                {
                    _context.Rooms.Add(room);
                }
            }
            foreach(var room in _context.Rooms)
            {
                if(!newRooms.Any(r => r.Number == room.Number && r.Unit == room.Unit))
                {
                    foreach(var s in room.Students)
                    {
                        s.RoomId = null;
                    }
                    _context.Rooms.Remove(room);
                }
            }
            _context.SaveChanges();
            SetStudents(rooms);
        }

        private bool Check(Models.DataModels.Room droom, Models.DataModels.Room lroom)
        {
            return droom.Number == lroom.Number && droom.Unit == lroom.Unit;
        }

        private List<Models.DataModels.Room> Convert(List<Room> rooms)
        {
            var drooms = new List<Models.DataModels.Room>();
            foreach(var room in rooms)
            {
                drooms.Add(new Models.DataModels.Room()
                {
                    Number = room.Number,
                    Unit = room.Unit
                });
            }
            return drooms;
        }

        private void SetStudents(List<Room> rooms)
        {
            foreach(var room in rooms)
            {
                int id = _context.Rooms.Where(r => r.Number == room.Number && r.Unit == room.Unit).FirstOrDefault().Id;
                foreach(var student in room.Students)
                {
                    _context.Students.Where(s => s.FullName == student.FullName).FirstOrDefault().RoomId = id;
                }
            }
            _context.SaveChanges();
        }
    }
}
