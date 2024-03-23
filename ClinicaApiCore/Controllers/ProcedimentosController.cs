using ClinicaApiCore.DTOs.Procedimentos;
using ClinicaApiCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcedimentosController : ControllerBase
    {
        private readonly IProcedimentosService _service;

        public ProcedimentosController(IProcedimentosService service)
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
            ProcedimentosDTO ProcedimentosDTO = _service.GetById(IdEmpresa, Id);
            if (ProcedimentosDTO != null)
                return Ok(ProcedimentosDTO);
            
            return BadRequest(new ProcedimentosResponseDTO() { Result = "Erro", Message = "Registro não encontrado" });
        }

        [HttpPost]
        [Route("{IdEmpresa}")]
        public IActionResult addProcedimento(int IdEmpresa, [FromBody] AddEditProcedimentoRequestDTO addEditProcedimentoRequestDTO)
        {
            if (addEditProcedimentoRequestDTO.Descricao == "")
                return BadRequest(new { Result = "Erro", Message = "Campo Descricao deve ser preenchido" });

            ProcedimentosDTO ProcedimentosDTO = _service.Add(IdEmpresa, addEditProcedimentoRequestDTO);
            
            return Ok(ProcedimentosDTO);
        }

        [HttpPut]
        [Route("{IdEmpresa}/{Id}")]
        public IActionResult editProcedimento(int IdEmpresa, long Id, [FromBody] AddEditProcedimentoRequestDTO addEditProcedimentoRequestDTO)
        {
            if (addEditProcedimentoRequestDTO.Descricao == "")
                return BadRequest(new { Result = "Erro", Message = "Campo Descricao deve ser preenchido" });

            ProcedimentosResponseDTO requestProcedimentoResultDTO = _service.Edit(IdEmpresa, Id, addEditProcedimentoRequestDTO);

            if (requestProcedimentoResultDTO.Result == "OK")
                return Ok(requestProcedimentoResultDTO);

            return BadRequest(requestProcedimentoResultDTO);
        }

        [HttpDelete]
        [Route("{IdEmpresa}/{Id}")]
        public IActionResult deleteProcedimento(int IdEmpresa, long Id)
        {
            ProcedimentosResponseDTO requestProcedimentoResultDTO = _service.Delete(IdEmpresa, Id);

            if(requestProcedimentoResultDTO.Result == "OK")
                return Ok(requestProcedimentoResultDTO);

            return BadRequest(requestProcedimentoResultDTO);
        }
    }
}
