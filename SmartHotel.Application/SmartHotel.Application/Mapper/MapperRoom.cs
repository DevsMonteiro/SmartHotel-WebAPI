using SmartHotel.Application.Dtos;
using SmartHotel.Application.Interface.IMapper;
using SmartHotel.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SmartHotel.Application.Mapper
{
    public class MapperRoom : IMapperRoom
    {
        public Room MapperDtoToEntity(RoomDto roomDto)
        {
            var houseRoom = new Room()
            {
                Id = roomDto.Id
               ,Number = roomDto.Number
            };
            return houseRoom;
        }

        public RoomDto MapperEntityToDto(Room room)
        {
            var roomDto = new RoomDto()
            {
                Id = room.Id
               ,Number = room.Number
            };
            return roomDto;
        }

        public IEnumerable<RoomDto> MapperListGuestDto(IEnumerable<Room> room)
        {
            var dto = room.Select(c => new RoomDto{Id = c.Id
                                                  ,Number = c.Number});
            return dto;
        }
    }
}