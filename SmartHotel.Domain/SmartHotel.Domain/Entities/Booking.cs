using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartHotel.Domain.Entities
{
    public class Booking
    {
        public Booking()
        {
        }

        public Booking(Guid id, DateTime checkIn, DateTime checkOut, Guid guestId, Guid roomId, decimal value)
        {
            Id = id;
            GuestId = guestId;
            RoomId = roomId;
            CheckIn = checkIn;
            CheckOut = checkOut;
            Value = value;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; private set; }

        public decimal Value { get; private set; }
        public DateTime CheckIn { get; private set; }
        public DateTime CheckOut { get; private set; }

        public Guid GuestId { get; private set; }
        public Guest Guest { get; private set; }
        public Guid RoomId { get; private set; }
        public Room Room { get; private set; }

        public bool IsValid(Booking booking)
        {
            var toDay = DateTime.Today;
            return booking.CheckIn >= toDay && booking.CheckOut > booking.CheckIn;
        }

    }
}