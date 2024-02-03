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
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult GetById(long Id)
        {
            ProcedimentosDTO ProcedimentosDTO = _service.GetById(Id);
            if (ProcedimentosDTO != null)
                return Ok(ProcedimentosDTO);
            
            return BadRequest(new ProcedimentosResponseDTO() { Result = "Erro", Message = "Registro não encontrado" });
        }

        [HttpPost]
        public IActionResult addProcedimento([FromBody] AddEditProcedimentoRequestDTO addEditProcedimentoRequestDTO)
        {
            if (addEditProcedimentoRequestDTO.Descricao == "")
                return BadRequest(new { Result = "Erro", Message = "Campo Descricao deve ser preenchido" });

            ProcedimentosDTO ProcedimentosDTO = _service.Add(addEditProcedimentoRequestDTO);
            
            return Ok(ProcedimentosDTO);
        }

        [HttpPut]
        [Route("{Id}")]
        public IActionResult editProcedimento(long Id, [FromBody] AddEditProcedimentoRequestDTO addEditProcedimentoRequestDTO)
        {
            if (addEditProcedimentoRequestDTO.Descricao == "")
                return BadRequest(new { Result = "Erro", Message = "Campo Descricao deve ser preenchido" });

            ProcedimentosResponseDTO requestProcedimentoResultDTO = _service.Edit(Id, addEditProcedimentoRequestDTO);

            if (requestProcedimentoResultDTO.Result == "OK")
                return Ok(requestProcedimentoResultDTO);

            return BadRequest(requestProcedimentoResultDTO);
        }

        [HttpDelete]
        [Route("{Id}")]
        public IActionResult deleteProcedimento(long Id)
        {
            ProcedimentosResponseDTO requestProcedimentoResultDTO = _service.Delete(Id);

            if(requestProcedimentoResultDTO.Result == "OK")
                return Ok(requestProcedimentoResultDTO);

            return BadRequest(requestProcedimentoResultDTO);
        }
    }
}
