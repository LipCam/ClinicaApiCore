using ClinicaApiCore.DTOs.Pacientes;
using ClinicaApiCore.Services;
using Microsoft.AspNetCore.Mvc;

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
            
            return BadRequest(new { Result = "Erro", Message = "Registro não encontrado" });
        }

        [HttpPost]
        public IActionResult addPaciente([FromBody] AddEditPacienteRequestDTO addPacienteRequestDTO)
        {
            if (addPacienteRequestDTO.Nome == "")
                return BadRequest(new { Result = "Erro", Message = "Campo Nome deve ser preenchido" });

            if (addPacienteRequestDTO.CPF == "")
                return BadRequest(new { Result = "Erro", Message = "Campo CPF deve ser preenchido" });

            PacientesDTO PacientesDTO = _service.Add(addPacienteRequestDTO);
            
            return Ok(PacientesDTO);
        }

        [HttpPut]
        [Route("{Id}")]
        public IActionResult editPaciente(long Id, [FromBody] AddEditPacienteRequestDTO addEditPacienteRequestDTO)
        {
            if (addEditPacienteRequestDTO.Nome == "")
                return BadRequest(new { Result = "Erro", Message = "Campo Nome deve ser preenchido" });

            if (addEditPacienteRequestDTO.CPF == "")
                return BadRequest(new { Result = "Erro", Message = "Campo CPF deve ser preenchido" });

            PacientesResponseDTO requestPacienteResultDTO = _service.Edit(Id, addEditPacienteRequestDTO);

            if (requestPacienteResultDTO.Result == "OK")
                return Ok(requestPacienteResultDTO);

            return BadRequest(requestPacienteResultDTO);
        }

        [HttpDelete]
        [Route("deletePaciente/{Id}")]
        public IActionResult deletePaciente(long Id)
        {
            PacientesResponseDTO requestPacienteResultDTO = _service.Delete(Id);

            if(requestPacienteResultDTO.Result == "OK")
                return Ok(requestPacienteResultDTO);

            return BadRequest(requestPacienteResultDTO);
        }
    }
}
