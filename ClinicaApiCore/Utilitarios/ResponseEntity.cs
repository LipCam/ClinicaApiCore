using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ClinicaApiCore.Utilitarios
{
    public class ResponseEntity : ControllerBase
    {
        public IActionResult GetResponseEntity(HttpStatusCode httpStatusCode, object obj)
        {
            switch (httpStatusCode)
            {
                case HttpStatusCode.NotFound:
                    return NotFound(obj);
                case HttpStatusCode.BadRequest:
                    return BadRequest(obj);
                case HttpStatusCode.Created:
                    return Created("", obj);
                default:
                    return Ok(obj);
            }
        }
    }
}
