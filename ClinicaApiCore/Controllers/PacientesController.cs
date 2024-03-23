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
            PacientesDTO PacientesDTO = _service.GetById(IdEmpresa, Id);
            if (PacientesDTO != null)
                return Ok(PacientesDTO);
            
            return BadRequest(new { Result = "Erro", Message = "Registro não encontrado" });
        }

        [HttpPost]
        [Route("{IdEmpresa}")]
        public IActionResult addPaciente(int IdEmpresa, [FromBody] AddEditPacienteRequestDTO addPacienteRequestDTO)
        {
            if (addPacienteRequestDTO.Nome == "")
                return BadRequest(new { Result = "Erro", Message = "Campo Nome deve ser preenchido" });

            if (addPacienteRequestDTO.CPF == "")
                return BadRequest(new { Result = "Erro", Message = "Campo CPF deve ser preenchido" });

            PacientesDTO PacientesDTO = _service.Add(IdEmpresa, addPacienteRequestDTO);
            
            return Ok(PacientesDTO);
        }

        [HttpPut]
        [Route("{IdEmpresa}/{Id}")]
        public IActionResult editPaciente(int IdEmpresa, long Id, [FromBody] AddEditPacienteRequestDTO addEditPacienteRequestDTO)
        {
            if (addEditPacienteRequestDTO.Nome == "")
                return BadRequest(new { Result = "Erro", Message = "Campo Nome deve ser preenchido" });

            if (addEditPacienteRequestDTO.CPF == "")
                return BadRequest(new { Result = "Erro", Message = "Campo CPF deve ser preenchido" });

            PacientesResponseDTO requestPacienteResultDTO = _service.Edit(IdEmpresa, Id, addEditPacienteRequestDTO);

            if (requestPacienteResultDTO.Result == "OK")
                return Ok(requestPacienteResultDTO);

            return BadRequest(requestPacienteResultDTO);
        }

        [HttpDelete]
        [Route("{IdEmpresa}/{Id}")]
        public IActionResult deletePaciente(int IdEmpresa, long Id)
        {
            PacientesResponseDTO requestPacienteResultDTO = _service.Delete(IdEmpresa, Id);

            if(requestPacienteResultDTO.Result == "OK")
                return Ok(requestPacienteResultDTO);

            return BadRequest(requestPacienteResultDTO);
        }
    }
}
