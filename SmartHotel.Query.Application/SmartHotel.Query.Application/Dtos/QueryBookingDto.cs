using System;

namespace SmartHotel.Query.Application.Dtos
{
    public class QueryBookingDto
    {
        public Guid Id { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public Guid GuestId { get; set; }
        public string NameGuest { get; set; }
        public string CPF { get; set; }
        public Guid RoomId { get; set; }
        public string RoomNumber { get; set; }
        public string RoomType { get; set; }
        public decimal Value { get; set; }
    }
}