using System;

namespace SmartHotel.Application.Dtos
{
    public class RoomTypeDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Value { get; set; }
    }
}