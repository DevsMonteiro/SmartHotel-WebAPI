using System;

namespace SmartHotel.Application.Dtos
{
    public class GuestDto
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime RegistrationDate { get; set; }
      
    }
} 