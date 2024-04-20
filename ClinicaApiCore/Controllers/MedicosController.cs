using ClinicaApiCore.DTOs;
using ClinicaApiCore.DTOs.Medicos;
using ClinicaApiCore.Services;
using ClinicaApiCore.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult GetById(long Id)
        {
            MedicosDTO medicosDTO = _service.GetById(Id);
            if (medicosDTO != null)
                return Ok(medicosDTO);

            return NotFound(new ResponseDTO() { StatusCode = HttpStatusCode.NotFound, Message = "Registro não encontrado" });
        }

        [HttpPost]
        public IActionResult addMedico([FromBody] AddEditMedicoRequestDTO addMedicoRequestDTO)
        {
            if (string.IsNullOrEmpty(addMedicoRequestDTO.Nome))
                return BadRequest(new ResponseDTO() { StatusCode = HttpStatusCode.BadRequest, Message = "Campo Nome deve ser preenchido" });

            if (string.IsNullOrEmpty(addMedicoRequestDTO.CPF))
                return BadRequest(new ResponseDTO() { StatusCode = HttpStatusCode.BadRequest, Message = "Campo CPF deve ser preenchido" });

            if (string.IsNullOrEmpty(addMedicoRequestDTO.NumRegistro))
                return BadRequest(new ResponseDTO() { StatusCode = HttpStatusCode.BadRequest, Message = "Campo Número Registro deve ser preenchido" });

            MedicosDTO medicosDTO = _service.Add(addMedicoRequestDTO);
            
            return Created("", medicosDTO);
        }

        [HttpPut]
        [Route("{Id}")]
        public IActionResult editMedico(long Id, [FromBody] AddEditMedicoRequestDTO addEditMedicoRequestDTO)
        {
            if (string.IsNullOrEmpty(addEditMedicoRequestDTO.Nome))
                return BadRequest(new ResponseDTO() { StatusCode = HttpStatusCode.BadRequest, Message = "Campo Nome deve ser preenchido" });

            if (string.IsNullOrEmpty(addEditMedicoRequestDTO.CPF))
                return BadRequest(new ResponseDTO() { StatusCode = HttpStatusCode.BadRequest, Message = "Campo CPF deve ser preenchido" });

            if (string.IsNullOrEmpty(addEditMedicoRequestDTO.NumRegistro))
                return BadRequest(new ResponseDTO() { StatusCode = HttpStatusCode.BadRequest, Message = "Campo Número Registro deve ser preenchido" });

            ResponseDTO responseDTO = _service.Edit(Id, addEditMedicoRequestDTO);
            return new ResponseEntity().GetResponseEntity(responseDTO.StatusCode, responseDTO);
        }

        [HttpDelete]
        [Route("{Id}")]
        public IActionResult deleteMedico(long Id)
        {
            ResponseDTO responseDTO = _service.Delete(Id);
            return new ResponseEntity().GetResponseEntity(responseDTO.StatusCode, responseDTO);
        }
    }
}
