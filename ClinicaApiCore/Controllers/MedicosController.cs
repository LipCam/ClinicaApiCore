using ClinicaApiCore.DTOs.Medicos;
using ClinicaApiCore.Services;
using Microsoft.AspNetCore.Mvc;

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
        [Route("getAll")]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet]
        [Route("getById")]
        public IActionResult GetById(long Id)
        {
            MedicosDTO medicosDTO = _service.GetById(Id);
            if (medicosDTO != null)
                return Ok(medicosDTO);
            
            return BadRequest(new { Result = "Erro", Message = "Registro não encontrado" });
        }

        [HttpPost]
        [Route("addMedico")]
        public IActionResult addMedico([FromBody] AddMedicoRequestDTO addMedicoRequestDTO)
        {
            if (addMedicoRequestDTO.Nome == "")
                return BadRequest(new { Result = "Erro", Message = "Campo Nome deve ser preenchido" });

            if (addMedicoRequestDTO.CPF == "")
                return BadRequest(new { Result = "Erro", Message = "Campo CPF deve ser preenchido" });

            if (addMedicoRequestDTO.NumRegistro == "")
                return BadRequest(new { Result = "Erro", Message = "Campo Número Registro deve ser preenchido" });

            MedicosDTO medicosDTO = _service.Add(addMedicoRequestDTO);
            
            return Ok(medicosDTO);
        }

        [HttpPut]
        [Route("editMedico")]
        public IActionResult editMedico([FromBody] EditMedicoRequestDTO editMedicoRequestDTO)
        {
            if (editMedicoRequestDTO.IdMedico == 0)
                return BadRequest(new { Result = "Erro", Message = "Campo Id deve ser preenchido" });

            if (editMedicoRequestDTO.Nome == "")
                return BadRequest(new { Result = "Erro", Message = "Campo Nome deve ser preenchido" });

            if (editMedicoRequestDTO.CPF == "")
                return BadRequest(new { Result = "Erro", Message = "Campo CPF deve ser preenchido" });

            if (editMedicoRequestDTO.NumRegistro == "")
                return BadRequest(new { Result = "Erro", Message = "Campo Número Registro deve ser preenchido" });

            RequestMedicoResultDTO requestMedicoResultDTO = _service.Edit(editMedicoRequestDTO);

            if (requestMedicoResultDTO.Result == "OK")
                return Ok(requestMedicoResultDTO);

            return BadRequest(requestMedicoResultDTO);
        }

        [HttpDelete]
        [Route("deleteMedico")]
        public IActionResult deleteMedico(long Id)
        {
            RequestMedicoResultDTO requestMedicoResultDTO = _service.Delete(Id);

            if(requestMedicoResultDTO.Result == "OK")
                return Ok(requestMedicoResultDTO);

            return BadRequest(requestMedicoResultDTO);
        }
    }
}
