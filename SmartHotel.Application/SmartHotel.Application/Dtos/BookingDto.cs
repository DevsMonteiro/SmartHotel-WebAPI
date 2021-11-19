using System;

namespace SmartHotel.Application.Dtos
{
    public class BookingDto
    {
        public Guid Id { get; set; }
        public Guid GuestId { get; set; }
        public string NameGuest { get; set; }
        public string CPF { get; set; }
        public Guid RoomId { get; set; }
        public string RoomNumber { get; set; }
        public string RoomType { get; set; }
        public DateTime CheckIn { get; private set; }
        public DateTime CheckOut { get; private set; }
        public decimal Value { get; set; }
    }
}