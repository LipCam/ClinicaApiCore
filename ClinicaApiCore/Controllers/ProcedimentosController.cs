using ClinicaApiCore.DTOs;
using ClinicaApiCore.DTOs.Procedimentos;
using ClinicaApiCore.Services;
using ClinicaApiCore.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
            Result<ProcedimentosDTO> result = _service.GetById(IdEmpresa, Id);
            if (result != null)
                return Ok(result);
            
            return NotFound(result);
        }

        [HttpPost]
        [Route("{IdEmpresa}")]
        public IActionResult addProcedimento(int IdEmpresa, [FromBody] AddEditProcedimentoRequestDTO addEditProcedimentoRequestDTO)
        {
            if (addEditProcedimentoRequestDTO.Descricao == "")
                return BadRequest(Result<ProcedimentosDTO>.Failure("Campo Descricao deve ser preenchido"));

            Result<ProcedimentosDTO> result = _service.Add(IdEmpresa, addEditProcedimentoRequestDTO);
            
            return Ok(result);
        }

        [HttpPut]
        [Route("{IdEmpresa}/{Id}")]
        public IActionResult editProcedimento(int IdEmpresa, long Id, [FromBody] AddEditProcedimentoRequestDTO addEditProcedimentoRequestDTO)
        {
            if (addEditProcedimentoRequestDTO.Descricao == "")
                return BadRequest(Result<string>.Failure("Campo Descricao deve ser preenchido"));

            Result<string> result = _service.Edit(IdEmpresa, Id, addEditProcedimentoRequestDTO);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete]
        [Route("{IdEmpresa}/{Id}")]
        public IActionResult deleteProcedimento(int IdEmpresa, long Id)
        {
            Result<string> result = _service.Delete(IdEmpresa, Id);

            if(result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
