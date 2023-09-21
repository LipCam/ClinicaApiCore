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
        [Route("Paciente/{Id}")]
        public IActionResult GetById(long Id)
        {
            List<AgendasDTO> lstAgendasDTO = _service.GetByPaciente(Id);
            return Ok(lstAgendasDTO);
        }
    }
}
