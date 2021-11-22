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

        #region HTTPGET
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetAll()
        {
            return Ok(_applicationServiceBooking.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult GetById(Guid id)
        {
            return Ok(_applicationServiceBooking.GetById(id));
        }

        [HttpGet("GetByCpf/{cpf}")]
        public ActionResult GuestSearchByCpf(string cpf)
        {
            return Ok(_applicationServiceBooking.GuestSearchByCpf(cpf));
        }

        [HttpGet("ChekDate")]
        public ActionResult BookingSearchByDateRange(DateTime CheckIn, DateTime Checkout)
        {
            return Ok(_applicationServiceBooking.BookingSearchByDateRange(CheckIn, Checkout));
        }
        #endregion

        [HttpPost]
        public ActionResult Post(BookingDto bookingDto)
        {
            try
            {
                if (bookingDto == null) return NotFound();

                _applicationServiceBooking.Add(bookingDto);
                return Ok(bookingDto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}