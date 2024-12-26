using ClinicaApiCore.DTOs;
using ClinicaApiCore.DTOs.Agendas;
using ClinicaApiCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendasController : ControllerBase
    {
        private readonly IAgendasService _service;

        public AgendasController(IAgendasService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("Disponiveis/{IdEmpresa}")]
        public IActionResult GetByLivres(int IdEmpresa, string DataInicio = "", string HoraInicio = "", string DataFim = "", string HoraFim = "", long IdProcedimento = 0, long IdMedico = 0)
        {
            Result<List<AgendasDTO>> lstAgendasDTO = _service.GetByLivres(IdEmpresa, DataInicio, HoraInicio, DataFim, HoraFim, IdProcedimento, IdMedico);
            return Ok(lstAgendasDTO);
        }

        [HttpGet]
        [Route("Paciente/{IdEmpresa}/{IdPaciente}")]
        public IActionResult GetById(int IdEmpresa, long IdPaciente)
        {
            Result<List<AgendasDTO>> lstAgendasDTO = _service.GetByPaciente(IdEmpresa, IdPaciente);
            return Ok(lstAgendasDTO);
        }

        [HttpPost]
        public IActionResult RealizarAgendamento([FromBody] RealizarAgendaRequestDTO realizarAgdRequest)
        {  
            if (realizarAgdRequest.IdAgenda == 0)
                return BadRequest(Result<string>.Failure("Campo IdAgenda deve ser preenchido"));

            if (realizarAgdRequest.IdPaciente == 0)
                return BadRequest(Result<string>.Failure("Campo IdPaciente deve ser preenchido"));

            Result<string> objResponseDTO = _service.RealizarAgendamento(realizarAgdRequest.IdAgenda, realizarAgdRequest.IdPaciente);
            if (objResponseDTO.IsSuccess)
                return Ok(objResponseDTO);
            else
                return BadRequest(objResponseDTO);
        }

        [HttpDelete]
        [Route("{IdAgenda}")]
        public IActionResult CancelarAgendamento(long IdAgenda)
        {
            if (IdAgenda == 0)
                return BadRequest(Result<string>.Failure("Campo IdAgenda deve ser preenchido"));

            Result<string> objResponseDTO = _service.CancelarAgendamento(IdAgenda);
            if (objResponseDTO.IsSuccess)
                return Ok(objResponseDTO);
            else
                return BadRequest(objResponseDTO);
        }
    }
}
