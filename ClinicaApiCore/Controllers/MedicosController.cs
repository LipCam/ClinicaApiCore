using ClinicaApiCore.DTOs;
using ClinicaApiCore.Services.Imp;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicosController : ControllerBase
    {
        private readonly IMedicosService _service;

        public MedicosController(IMedicosService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("getAll")]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet]
        [Route("getById")]
        public IActionResult GetById(long Id)
        {
            MedicosDTO medicosDTO = _service.GetById(Id);
            if (medicosDTO != null)
                return Ok(medicosDTO);
            
            return BadRequest(new { Result = "Erro", Message = "Registro não encontrado" });
        }
    }
}
