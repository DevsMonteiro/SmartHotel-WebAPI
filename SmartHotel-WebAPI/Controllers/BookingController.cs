using Microsoft.AspNetCore.Mvc;
using SmartHotel.Application.Dtos;
using SmartHotel.Application.Interface;
using System;
using System.Collections.Generic;

namespace SmartHotel_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IApplicationServiceBooking _applicationServiceBooking;

        public BookingController(IApplicationServiceBooking applicationServiceBooking)
        {
            this._applicationServiceBooking = applicationServiceBooking;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetAll()
        {
            return Ok(_applicationServiceBooking.GetAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult GetById(Guid id)
        {
            return Ok(_applicationServiceBooking.GetById(id));
        }

        [HttpGet("ByCpf/{cpf}")]
        public ActionResult GetGuestByCpf(string cpf)
        {
            return Ok(_applicationServiceBooking.GetGuestByCpf(cpf));
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] BookingDto bookingDto)
        {
            try
            {
                if (bookingDto == null) return NotFound();

                _applicationServiceBooking.Add(bookingDto);
                return Ok("Successfully Registered Guest!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}