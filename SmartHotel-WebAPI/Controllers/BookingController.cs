using Microsoft.AspNetCore.Mvc;
using SmartHotel.Application.Dtos;
using SmartHotel.Application.Interface;
using SmartHotel.Query.Application.Interface;
using System;
using System.Collections.Generic;

namespace SmartHotel_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IApplicationServiceBooking _applicationServiceBooking;
        private readonly IApplicationServiceQueryBooking _applicationServiceQueryBooking;

        //private object bookingTeste;

        public BookingController(IApplicationServiceBooking applicationServiceBooking
                                , IApplicationServiceQueryBooking applicationServiceQueryBooking)
        {
            _applicationServiceBooking = applicationServiceBooking;
            _applicationServiceQueryBooking = applicationServiceQueryBooking;
        }

        #region [QWERY]

        [HttpGet]
        public ActionResult<IEnumerable<string>> GetAll()
        {
            var bookings = _applicationServiceQueryBooking.GetAll();

            return Ok(bookings);

        }

        [HttpGet("{id}")]
        public ActionResult GetById(Guid id)
        {
            //return Ok(_applicationServiceBooking.GetById(id));
            throw new IndexOutOfRangeException();
        }

        [HttpGet("GetByCpf/{cpf}")]
        public ActionResult GuestSearchByCpf(string cpf)
        {
            var bookings = _applicationServiceQueryBooking.GuestSearchByCpf(cpf);

            return Ok(bookings);

        }

        [HttpGet("DdlRoom")]
        public ActionResult<IEnumerable<string>> GetRoomByBooking(DateTime CheckIn, DateTime Checkout, Guid id)
        {
            var roomAvailable = _applicationServiceQueryBooking.GetDdlRoom(CheckIn, Checkout, id);
            return Ok(roomAvailable);
        }

        [HttpGet("ValueRoom")]
        public ActionResult GetCalcValueRoom(DateTime CheckIn, DateTime Checkout, Guid id)
        {
            var calcValueRoom = _applicationServiceQueryBooking.GetCalcValueRoom(CheckIn, Checkout, id);
            return Ok(calcValueRoom);
        }

        [HttpGet("ChekDate")]
        public ActionResult BookingSearchByDateRange(DateTime CheckIn, DateTime Checkout)
        {
            //bookingTeste = _applicationServiceBooking.BookingSearchByDateRange(CheckIn, Checkout);
            //return Ok(bookingTeste);
            throw new IndexOutOfRangeException();
        }

        #endregion

        #region [COMMAND]
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

        #endregion


    }
}