using AutoMapper;
using Hostel.Common.Models.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hostel.DataAccess.Models.DataModels
{
    public class Room : IMapFrom<Common.Models.LogicModels.Room>
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public char Unit { get; set; }
        public IEnumerable<Student> Students { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Room, Common.Models.LogicModels.Room>()
                .ForMember(x => x.Id, x => x.MapFrom(z => z.Id))
                .ForMember(x => x.Number, x => x.MapFrom(z => z.Number))
                .ForMember(x => x.Unit, x => x.MapFrom(z => z.Unit))
                .ForMember(x => x.Students, x => x.Ignore())
                .ForMember(x => x.Floor, x => x.Ignore());
        }

        public Common.Models.LogicModels.Room ToRoom(Room room)
        {
            return new Common.Models.LogicModels.Room()
            {
                Id = room.Id,
                Number = room.Number,
                Unit = room.Unit
            };
        }
    }
}
