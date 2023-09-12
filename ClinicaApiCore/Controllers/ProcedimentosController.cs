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
        [Route("getAll")]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet]
        [Route("getById")]
        public IActionResult GetById(long Id)
        {
            ProcedimentosDTO ProcedimentosDTO = _service.GetById(Id);
            if (ProcedimentosDTO != null)
                return Ok(ProcedimentosDTO);
            
            return BadRequest(new RequestProcedimentoResultDTO() { Result = "Erro", Message = "Registro não encontrado" });
        }

        [HttpPost]
        [Route("addProcedimento")]
        public IActionResult addProcedimento([FromBody] AddProcedimentoRequestDTO addProcedimentoRequestDTO)
        {
            if (addProcedimentoRequestDTO.Descricao == "")
                return BadRequest(new { Result = "Erro", Message = "Campo Descricao deve ser preenchido" });

            ProcedimentosDTO ProcedimentosDTO = _service.Add(addProcedimentoRequestDTO);
            
            return Ok(ProcedimentosDTO);
        }

        [HttpPut]
        [Route("editProcedimento")]
        public IActionResult editProcedimento([FromBody] EditProcedimentoRequestDTO editProcedimentoRequestDTO)
        {
            if (editProcedimentoRequestDTO.IdProcedimento == 0)
                return BadRequest(new { Result = "Erro", Message = "Campo Id deve ser preenchido" });

            if (editProcedimentoRequestDTO.Descricao == "")
                return BadRequest(new { Result = "Erro", Message = "Campo Descricao deve ser preenchido" });

            RequestProcedimentoResultDTO requestProcedimentoResultDTO = _service.Edit(editProcedimentoRequestDTO);

            if (requestProcedimentoResultDTO.Result == "OK")
                return Ok(requestProcedimentoResultDTO);

            return BadRequest(requestProcedimentoResultDTO);
        }

        [HttpDelete]
        [Route("deleteProcedimento")]
        public IActionResult deleteProcedimento(long Id)
        {
            RequestProcedimentoResultDTO requestProcedimentoResultDTO = _service.Delete(Id);

            if(requestProcedimentoResultDTO.Result == "OK")
                return Ok(requestProcedimentoResultDTO);

            return BadRequest(requestProcedimentoResultDTO);
        }
    }
}
