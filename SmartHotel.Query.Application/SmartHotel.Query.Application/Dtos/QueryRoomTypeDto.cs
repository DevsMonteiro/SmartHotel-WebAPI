using System;

namespace SmartHotel.Query.Application.Dtos
{
    public class QueryRoomTypeDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Value { get; set; }
    }
}