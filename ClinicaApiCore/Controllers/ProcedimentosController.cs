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
            
            return NotFound(new ResponseDTO() { StatusCode = HttpStatusCode.NotFound, Message = "Registro não encontrado" });
        }

        [HttpPost]
        public IActionResult addProcedimento([FromBody] AddEditProcedimentoRequestDTO addEditProcedimentoRequestDTO)
        { 
            if (string.IsNullOrEmpty(addEditProcedimentoRequestDTO.Descricao))
                return BadRequest(new ResponseDTO() { StatusCode = HttpStatusCode.BadRequest, Message = "Campo Descricao deve ser preenchido" });

            ProcedimentosDTO ProcedimentosDTO = _service.Add(addEditProcedimentoRequestDTO);            
            return Created("", ProcedimentosDTO);
        }

        [HttpPut]
        [Route("{Id}")]
        public IActionResult editProcedimento(long Id, [FromBody] AddEditProcedimentoRequestDTO addEditProcedimentoRequestDTO)
        {
            if (string.IsNullOrEmpty(addEditProcedimentoRequestDTO.Descricao))
                return BadRequest(new ResponseDTO() { StatusCode = HttpStatusCode.BadRequest, Message = "Campo Descricao deve ser preenchido" });

            ResponseDTO responseDTO = _service.Edit(Id, addEditProcedimentoRequestDTO);
            return new ResponseEntity().GetResponseEntity(responseDTO.StatusCode, responseDTO);
        }

        [HttpDelete]
        [Route("{Id}")]
        public IActionResult deleteProcedimento(long Id)
        {
            ResponseDTO responseDTO = _service.Delete(Id);
            return new ResponseEntity().GetResponseEntity(responseDTO.StatusCode, responseDTO);
        }
    }
}
