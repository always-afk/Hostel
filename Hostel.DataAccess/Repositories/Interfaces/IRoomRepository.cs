using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hostel.Common.Models.LogicModels;

namespace Hostel.DataAccess.Repositories.Interfaces
{
    public interface IRoomRepository
    {
        public IEnumerable<Room> GetAllRooms();

        public void Add(Room newRoom);
        public void Delete(int id);
    }
}
