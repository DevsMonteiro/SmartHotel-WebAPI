using System;

namespace SmartHotel.Application.Dtos
{
    public class QueryPendencyDto
    {
        public Guid Id { get; set; }

        public decimal Value { get; set; }

        public Guid GuestId { get; set; }

        public string GuestName { get; set; }

        public string CPF { get; set; }

    }
}