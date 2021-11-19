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

        //public bool IsValid(Booking booking)
        //{
        //    var toDay = DateTime.Today;
        //    return booking.CheckIn >= toDay && booking.CheckOut > booking.CheckIn;
        //}

        //public static readonly DateTime MinValue = new DateTime(1900, 1, 1);

        //public Booking(DateTime checkIn, DateTime checkOut)
        //{
        //    if (!IsValidDate(checkIn))
        //        throw new Exception("CheckInDate is invalid");

        //    if (!IsValidDate(checkOut))
        //        throw new Exception("CheckOutDate is invalid");

        //    CheckIn = checkIn;
        //    CheckOut = checkOut;
        //}

        //public static bool IsValid(DateTime checkIn, DateTime checkOut)
        //{
        //    return IsValidDate(checkIn) && IsValidDate(checkOut);
        //}

        //private static bool IsValidDate(DateTime date)
        //{
        //    return date > MinValue;
        //}

        //public override bool Equals(object obj)
        //{
        //    if (obj is not Booking date)
        //        return false;

        //    return CheckIn.Date.Equals(date.CheckIn.Date) && CheckOut.Date.Equals(date.CheckOut.Date);
        //}

        //public override int GetHashCode()
        //{
        //    return GetType().GetHashCode() * 907 + CheckIn.GetHashCode() + CheckOut.GetHashCode();
        //}

        //public override string ToString()
        //{
        //    return $"{CheckIn.Date} of {CheckOut.Date}";
        //}
    }
}