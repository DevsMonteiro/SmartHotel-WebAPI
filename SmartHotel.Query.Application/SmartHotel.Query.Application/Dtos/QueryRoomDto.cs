using System;

namespace SmartHotel.Query.Application.Dtos
{
    public class QueryRoomDto
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public Guid RoomTypeId { get; set; }
        public string RoomTypeName { get; set; }
    }
}