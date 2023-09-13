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
        [Route("getAll")]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet]
        [Route("getById")]
        public IActionResult GetById(long Id)
        {
            PacientesDTO PacientesDTO = _service.GetById(Id);
            if (PacientesDTO != null)
                return Ok(PacientesDTO);
            
            return BadRequest(new { Result = "Erro", Message = "Registro não encontrado" });
        }

        [HttpPost]
        [Route("addPaciente")]
        public IActionResult addPaciente([FromBody] AddPacienteRequestDTO addPacienteRequestDTO)
        {
            if (addPacienteRequestDTO.Nome == "")
                return BadRequest(new { Result = "Erro", Message = "Campo Nome deve ser preenchido" });

            if (addPacienteRequestDTO.CPF == "")
                return BadRequest(new { Result = "Erro", Message = "Campo CPF deve ser preenchido" });

            PacientesDTO PacientesDTO = _service.Add(addPacienteRequestDTO);
            
            return Ok(PacientesDTO);
        }

        [HttpPut]
        [Route("editPaciente")]
        public IActionResult editPaciente([FromBody] EditPacienteRequestDTO editPacienteRequestDTO)
        {
            if (editPacienteRequestDTO.IdPaciente == 0)
                return BadRequest(new { Result = "Erro", Message = "Campo Id deve ser preenchido" });

            if (editPacienteRequestDTO.Nome == "")
                return BadRequest(new { Result = "Erro", Message = "Campo Nome deve ser preenchido" });

            if (editPacienteRequestDTO.CPF == "")
                return BadRequest(new { Result = "Erro", Message = "Campo CPF deve ser preenchido" });

            RequestPacienteResultDTO requestPacienteResultDTO = _service.Edit(editPacienteRequestDTO);

            if (requestPacienteResultDTO.Result == "OK")
                return Ok(requestPacienteResultDTO);

            return BadRequest(requestPacienteResultDTO);
        }

        [HttpDelete]
        [Route("deletePaciente")]
        public IActionResult deletePaciente(long Id)
        {
            RequestPacienteResultDTO requestPacienteResultDTO = _service.Delete(Id);

            if(requestPacienteResultDTO.Result == "OK")
                return Ok(requestPacienteResultDTO);

            return BadRequest(requestPacienteResultDTO);
        }
    }
}
