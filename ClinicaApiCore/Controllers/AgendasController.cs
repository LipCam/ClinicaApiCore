using ClinicaApiCore.DTOs;
using ClinicaApiCore.DTOs.Agendas;
using ClinicaApiCore.Services;
using ClinicaApiCore.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
        public IActionResult GetByPaciente(long IdPaciente)
        {
            List<AgendasDTO> lstAgendasDTO = _service.GetByPaciente(IdPaciente);
            return Ok(lstAgendasDTO);
        }

        [HttpPost]
        public IActionResult RealizarAgendamento([FromBody] RealizarAgendaRequestDTO realizarAgdRequest)
        {  
            if (realizarAgdRequest.IdAgenda == 0)
                return BadRequest(new ResponseDTO() { StatusCode = HttpStatusCode.BadRequest, Message = "Campo IdAgenda deve ser preenchido" });

            if (realizarAgdRequest.IdPaciente == 0)
                return BadRequest(new ResponseDTO() { StatusCode = HttpStatusCode.BadRequest, Message = "Campo IdPaciente deve ser preenchido" });

            ResponseDTO responseDTO = _service.RealizarAgendamento(realizarAgdRequest.IdAgenda, realizarAgdRequest.IdPaciente);
            return new ResponseEntity().GetResponseEntity(responseDTO.StatusCode, responseDTO);
        }

        [HttpDelete]
        [Route("{IdAgenda}")]
        public IActionResult CancelarAgendamento(long IdAgenda)
        {
            if (IdAgenda == 0)
                return BadRequest(new ResponseDTO() { StatusCode = HttpStatusCode.BadRequest, Message = "Campo IdAgenda deve ser preenchido" });

            ResponseDTO responseDTO = _service.CancelarAgendamento(IdAgenda);
            return new ResponseEntity().GetResponseEntity(responseDTO.StatusCode, responseDTO);
        }
    }
}
