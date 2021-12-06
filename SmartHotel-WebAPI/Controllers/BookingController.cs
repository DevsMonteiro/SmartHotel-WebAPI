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
        private object bookingTeste;

        public BookingController(IApplicationServiceBooking applicationServiceBooking)
        {
            this._applicationServiceBooking = applicationServiceBooking;
        }

        #region [GET]

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

        [HttpGet("DdlRoom")]
        public ActionResult<IEnumerable<string>> GetRoomByBooking(DateTime CheckIn, DateTime Checkout)
        {
            var roomAvailable = _applicationServiceBooking.GetDdlRoom(CheckIn, Checkout);
            return Ok(roomAvailable);
        }

        [HttpGet("ChekDate")]
        public ActionResult BookingSearchByDateRange(DateTime CheckIn, DateTime Checkout)
        {
            bookingTeste = _applicationServiceBooking.BookingSearchByDateRange(CheckIn, Checkout);
            return Ok(bookingTeste);
        }

        [HttpGet("teste")]
        public ActionResult returnByRoom()
        {
            return Ok(_applicationServiceBooking.RetornaQuartosDisponiveis());
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
            catch (Exception)
            {
                throw;
            }
        }


        [HttpDelete("delete/{id}")]
        public ActionResult DeleteById(Guid id)
        {
            try
            {
                _applicationServiceBooking.DeleteById(id);

                return Ok("Deleted");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}