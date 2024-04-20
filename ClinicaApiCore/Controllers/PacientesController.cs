using ClinicaApiCore.DTOs;
using ClinicaApiCore.DTOs.Pacientes;
using ClinicaApiCore.Services;
using ClinicaApiCore.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ClinicaApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        private readonly IPacientesService _service;

        public PacientesController(IPacientesService service)
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
            PacientesDTO PacientesDTO = _service.GetById(Id);
            if (PacientesDTO != null)
                return Ok(PacientesDTO);

            return NotFound(new ResponseDTO() { StatusCode = HttpStatusCode.NotFound, Message = "Registro não encontrado" });
        }

        [HttpPost]
        public IActionResult addPaciente([FromBody] AddEditPacienteRequestDTO addPacienteRequestDTO)
        {
            if (string.IsNullOrEmpty(addPacienteRequestDTO.Nome))
                return BadRequest(new ResponseDTO() { StatusCode = HttpStatusCode.BadRequest, Message = "Campo Nome deve ser preenchido" });

            if (string.IsNullOrEmpty(addPacienteRequestDTO.CPF))
                return BadRequest(new ResponseDTO() { StatusCode = HttpStatusCode.BadRequest, Message = "Campo CPF deve ser preenchido" });

            PacientesDTO PacientesDTO = _service.Add(addPacienteRequestDTO);
            
            return Created("", PacientesDTO);
        }

        [HttpPut]
        [Route("{Id}")]
        public IActionResult editPaciente(long Id, [FromBody] AddEditPacienteRequestDTO addEditPacienteRequestDTO)
        {
            if (string.IsNullOrEmpty(addEditPacienteRequestDTO.Nome))
                return BadRequest(new ResponseDTO() { StatusCode = HttpStatusCode.BadRequest, Message = "Campo Nome deve ser preenchido" });

            if (string.IsNullOrEmpty(addEditPacienteRequestDTO.CPF))
                return BadRequest(new ResponseDTO() { StatusCode = HttpStatusCode.BadRequest, Message = "Campo CPF deve ser preenchido" });

            ResponseDTO responseDTO = _service.Edit(Id, addEditPacienteRequestDTO);
            return new ResponseEntity().GetResponseEntity(responseDTO.StatusCode, responseDTO);
        }

        [HttpDelete]
        [Route("deletePaciente/{Id}")]
        public IActionResult deletePaciente(long Id)
        {
            ResponseDTO responseDTO = _service.Delete(Id);
            return new ResponseEntity().GetResponseEntity(responseDTO.StatusCode, responseDTO);
        }
    }
}
