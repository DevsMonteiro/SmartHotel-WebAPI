using Microsoft.AspNetCore.Mvc;
using SmartHotel.Application.Dtos;
using SmartHotel.Application.Interface;
using System;

namespace SmartHotel_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GuestController : ControllerBase
    {
        private readonly IApplicationServiceGuest _applicationServiceGuest;

        public GuestController(IApplicationServiceGuest applicationServiceGuest)
        {
            this._applicationServiceGuest = applicationServiceGuest;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            //return Ok(applicationServiceGuest.GetAll());

            var guest = _applicationServiceGuest.ChecktHasPending();
            return Ok(guest);
        }

        [HttpGet("{id}")]
        public ActionResult<string> GetById(Guid id)
        {
            return Ok(_applicationServiceGuest.GetById(id));
        }

        [HttpPost]
        public ActionResult Post(GuestDto guestDTO)
        {
            try
            {
                if (guestDTO == null) return NotFound();

                _applicationServiceGuest.Add(guestDTO);
                return Ok(guestDTO);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
                //throw ex;
            }
        }

        [HttpPut]
        public ActionResult Put(GuestDto guestDTO)
        {
            try
            {
                if (guestDTO == null) return NotFound();

                _applicationServiceGuest.Update(guestDTO);
                return Ok(guestDTO);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
                //throw ex;
            }
        }

        [HttpDelete]
        public ActionResult Delete(GuestDto guestDTO)
        {
            try
            {
                if (guestDTO == null) return NotFound();

                _applicationServiceGuest.Delete(guestDTO);
                return Ok("Guest Successfully Removed!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}