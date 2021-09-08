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
            });
        }

        public void Fill()
        {

        }
    }
}
