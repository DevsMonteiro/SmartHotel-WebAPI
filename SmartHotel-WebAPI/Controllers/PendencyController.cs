using Microsoft.AspNetCore.Mvc;
using SmartHotel.Application.Dtos;
using SmartHotel.Application.Interface;
using SmartHotel.Query.Application.Interface;
using System;

namespace SmartHotel_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PendencyController : ControllerBase
    {
        private readonly IApplicationServiceQueryPendency _applicationServiceQueryPendency;
        private readonly IApplicationServicePendency _applicationServicePendency;

        public PendencyController(IApplicationServiceQueryPendency applicationServiceQueryPendency,
                                  IApplicationServicePendency applicationServicePendency)
        {
           _applicationServiceQueryPendency = applicationServiceQueryPendency;
            _applicationServicePendency = applicationServicePendency;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var pendency = _applicationServiceQueryPendency.GetAll();
            return Ok(pendency);

        }


        [HttpDelete("delete/{Id}")]
        public ActionResult Delete(Guid id)
        {
            try
            {
                _applicationServicePendency.DeleteById(id);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}