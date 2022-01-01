using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartHotel.Domain.Entities
{
    public class Booking
    {
        public Booking()
        {
        }

        public Booking(Guid id, DateTime checkIn, DateTime checkOut, DateTime registrationDate, Guid guestId, Guid roomId, decimal value)
        {
            Id = id;
            GuestId = guestId;
            RoomId = roomId;
            CheckIn = checkIn;
            CheckOut = checkOut;
            RegistrationDate = registrationDate;
            Value = value;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public decimal Value { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public DateTime RegistrationDate { get; set; }

        public Guid GuestId { get; set; }
        public Guest Guest { get; set; }
        public Guid RoomId { get; set; }
        public Room Room { get; set; }





        public bool IsValid(Booking booking)
        {
            var toDay = DateTime.Today;
            return booking.CheckIn >= toDay && booking.CheckOut > booking.CheckIn;
        }

    }
}