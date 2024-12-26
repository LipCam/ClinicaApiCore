using ClinicaApiCore.DTOs;
using ClinicaApiCore.DTOs.Medicos;
using ClinicaApiCore.Services;
using ClinicaApiCore.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ClinicaApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicosController : ControllerBase
    {
        private readonly IMedicosService _service;

        public MedicosController(IMedicosService service)
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
            Result<MedicosDTO> result = _service.GetById(IdEmpresa, Id);
            if (result.IsSuccess)
                return Ok(result);
            
            return NotFound(result);
        }

        [HttpPost]
        [Route("{IdEmpresa}")]
        public IActionResult addMedico(int IdEmpresa, [FromBody] AddEditMedicoRequestDTO addMedicoRequestDTO)
        {
            if (addMedicoRequestDTO.Nome == "")
                return BadRequest(Result<MedicosDTO>.Failure("Campo Nome deve ser preenchido"));

            if (addMedicoRequestDTO.CPF == "")
                return BadRequest(Result<MedicosDTO>.Failure("Campo CPF deve ser preenchido"));

            if (addMedicoRequestDTO.NumRegistro == "")
                return BadRequest(Result<MedicosDTO>.Failure("Campo Número Registro deve ser preenchido"));

            Result<MedicosDTO> result = _service.Add(IdEmpresa, addMedicoRequestDTO);
            
            return Ok(result);
        }

        [HttpPut]
        [Route("{IdEmpresa}/{Id}")]
        public IActionResult editMedico(int IdEmpresa, long Id, [FromBody] AddEditMedicoRequestDTO addEditMedicoRequestDTO)
        {
            if (addEditMedicoRequestDTO.Nome == "")
                return BadRequest(Result<string>.Failure("Campo Nome deve ser preenchido"));

            if (addEditMedicoRequestDTO.CPF == "")
                return BadRequest(Result<string>.Failure("Campo CPF deve ser preenchido"));

            if (addEditMedicoRequestDTO.NumRegistro == "")
                return BadRequest(Result<string>.Failure("Campo Número Registro deve ser preenchido"));

            Result<string> result = _service.Edit(IdEmpresa, Id, addEditMedicoRequestDTO);

            if (result.IsSuccess)
                return Ok(result);

            return NotFound(result);
        }

        [HttpDelete]
        [Route("{IdEmpresa}/{Id}")]
        public IActionResult deleteMedico(int IdEmpresa, long Id)
        {
            Result<string> result = _service.Delete(IdEmpresa, Id);

            if(result.IsSuccess)
                return Ok(result);

            return NotFound(result);
        }
    }
}
