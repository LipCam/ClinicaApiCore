using ClinicaApiCore.DTOs;
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
        [Route("{IdEmpresa}")]
        public IActionResult GetAll(int IdEmpresa)
        {
            return Ok(_service.GetAll(IdEmpresa));
        }

        [HttpGet]
        [Route("{IdEmpresa}/{Id}")]
        public IActionResult GetById(int IdEmpresa, long Id)
        {
            Result<PacientesDTO> result = _service.GetById(IdEmpresa, Id);
            if (result.IsSuccess)
                return Ok(result);
            
            return NotFound(result);
        }

        [HttpPost]
        [Route("{IdEmpresa}")]
        public IActionResult addPaciente(int IdEmpresa, [FromBody] AddEditPacienteRequestDTO addPacienteRequestDTO)
        {
            if (addPacienteRequestDTO.Nome == "")
                return BadRequest(Result<PacientesDTO>.Failure("Campo Nome deve ser preenchido"));

            if (addPacienteRequestDTO.CPF == "")
                return BadRequest(Result<PacientesDTO>.Failure("Campo CPF deve ser preenchido"));

            Result<PacientesDTO> result = _service.Add(IdEmpresa, addPacienteRequestDTO);
            
            return Ok(result);
        }

        [HttpPut]
        [Route("{IdEmpresa}/{Id}")]
        public IActionResult editPaciente(int IdEmpresa, long Id, [FromBody] AddEditPacienteRequestDTO addEditPacienteRequestDTO)
        {
            if (addEditPacienteRequestDTO.Nome == "")
                return BadRequest(Result<string>.Failure("Campo Nome deve ser preenchido"));

            if (addEditPacienteRequestDTO.CPF == "")
                return BadRequest(Result<string>.Failure("Campo CPF deve ser preenchido"));

            Result<string> result = _service.Edit(IdEmpresa, Id, addEditPacienteRequestDTO);

            if (result.IsSuccess)
                return Ok(result);

            return NotFound(result);
        }

        [HttpDelete]
        [Route("{IdEmpresa}/{Id}")]
        public IActionResult deletePaciente(int IdEmpresa, long Id)
        {
            Result<string> result = _service.Delete(IdEmpresa, Id);

            if(result.IsSuccess)
                return Ok(result);

            return NotFound(result);
        }
    }
}
