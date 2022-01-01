using System;

namespace SmartHotel.Application.Dtos
{
    public class PendencyDto
    {
        public Guid Id { get; set; }

        public decimal Value { get; set; }

        public Guid GuestId { get; set; }
    }
}