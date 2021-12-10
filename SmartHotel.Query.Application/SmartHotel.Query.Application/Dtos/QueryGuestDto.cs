using System;

namespace SmartHotel.Query.Application.Dtos
{
    public class QueryGuestDto
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime RegistrationDate { get; set; }
        public Guid? PendencyId { get; set; }
      
    }
} 