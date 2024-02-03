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
        [Route("Disponiveis")]
        public IActionResult GetByLivres(string DataInicio = "", string HoraInicio = "", string DataFim = "", string HoraFim = "", long IdProcedimento = 0, long IdMedico = 0)
        {
            List<AgendasDTO> lstAgendasDTO = _service.GetByLivres(DataInicio, HoraInicio, DataFim, HoraFim, IdProcedimento, IdMedico);
            return Ok(lstAgendasDTO);
        }

        [HttpGet]
        [Route("Paciente/{IdPaciente}")]
        public IActionResult GetById(long IdPaciente)
        {
            List<AgendasDTO> lstAgendasDTO = _service.GetByPaciente(IdPaciente);
            return Ok(lstAgendasDTO);
        }

        [HttpPost]
        public IActionResult RealizarAgendamento([FromBody] RealizarAgendaRequestDTO realizarAgdRequest)
        {  
            if (realizarAgdRequest.IdAgenda == 0)
                return BadRequest(new AgendasResponseDTO() { Result = "ERRO", Message = "Campo IdAgenda deve ser preenchido" });

            if (realizarAgdRequest.IdPaciente == 0)
                return BadRequest(new AgendasResponseDTO() { Result = "ERRO", Message = "Campo IdPaciente deve ser preenchido" });

            AgendasResponseDTO objAgendamentodResponse = _service.RealizarAgendamento(realizarAgdRequest.IdAgenda, realizarAgdRequest.IdPaciente);
            if (objAgendamentodResponse.Result == "OK")
                return Ok(objAgendamentodResponse);
            else
                return BadRequest(objAgendamentodResponse);
        }

        [HttpDelete]
        [Route("{IdAgenda}")]
        public IActionResult CancelarAgendamento(long IdAgenda)
        {
            if (IdAgenda == 0)
                return BadRequest(new AgendasResponseDTO() { Result = "ERRO", Message = "Campo IdAgenda deve ser preenchido" });

            AgendasResponseDTO objAgendamentodResponse = _service.CancelarAgendamento(IdAgenda);
            if (objAgendamentodResponse.Result == "OK")
                return Ok(objAgendamentodResponse);
            else
                return BadRequest(objAgendamentodResponse);
        }
    }
}
