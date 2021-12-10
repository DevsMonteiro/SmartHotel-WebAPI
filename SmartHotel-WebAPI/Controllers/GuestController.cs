using Microsoft.AspNetCore.Mvc;
using SmartHotel.Application.Dtos;
using SmartHotel.Application.Interface;
using SmartHotel.Query.Application.Interface;
using System;


namespace SmartHotel_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GuestController : ControllerBase
    {
        private readonly IApplicationServiceGuest _applicationServiceGuest;
        private readonly IApplicationServiceQueryGuest _applicationServiceQueryGuest;

        public GuestController(IApplicationServiceGuest applicationServiceGuest
                              ,IApplicationServiceQueryGuest applicationServiceQueryGuest)
        {
            _applicationServiceGuest = applicationServiceGuest;
            _applicationServiceQueryGuest = applicationServiceQueryGuest;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var guest = _applicationServiceQueryGuest.GetAll();
            return Ok(guest);

        }

        [HttpGet("{id}")]
        public ActionResult<string> GetById(Guid id)
        {
            var guest = _applicationServiceQueryGuest.GetById(id);
            return Ok(guest);
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
                return Ok(guestDTO);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("delete/{Id}")]
        public ActionResult DeleteById(Guid Id)
        {
            try
            {
                _applicationServiceGuest.DeleteById(Id);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}