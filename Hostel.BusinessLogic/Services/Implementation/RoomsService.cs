using Hostel.Common.Models.LogicModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hostel.DataAccess.Repositories.Interfaces;

namespace Hostel.BusinessLogic.Services.Implementation
{
    public class RoomsService : Interfaces.IRoomsService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomsService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public IEnumerable<Room> GetRooms()
        {
            return _roomRepository.GetAllRooms();
        }

        public void Save(List<Room> rooms)
        {
            _roomRepository.Save(rooms);
        }
    }
}
