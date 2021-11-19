using System;

namespace SmartHotel.Application.Dtos
{
    public class RoomDto
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public Guid RoomTypeId { get; set; }
        public string RoomTypeName { get; set; }
    }
}