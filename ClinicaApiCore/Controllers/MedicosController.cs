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
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult GetById(long Id)
        {
            MedicosDTO medicosDTO = _service.GetById(Id);
            if (medicosDTO != null)
                return Ok(medicosDTO);
            
            return BadRequest(new MedicosResponseDTO() { Result = "Erro", Message = "Registro não encontrado" });
        }

        [HttpPost]
        public IActionResult addMedico([FromBody] AddEditMedicoRequestDTO addMedicoRequestDTO)
        {
            if (addMedicoRequestDTO.Nome == "")
                return BadRequest(new MedicosResponseDTO() { Result = "Erro", Message = "Campo Nome deve ser preenchido" });

            if (addMedicoRequestDTO.CPF == "")
                return BadRequest(new MedicosResponseDTO() { Result = "Erro", Message = "Campo CPF deve ser preenchido" });

            if (addMedicoRequestDTO.NumRegistro == "")
                return BadRequest(new MedicosResponseDTO() { Result = "Erro", Message = "Campo Número Registro deve ser preenchido" });

            MedicosDTO medicosDTO = _service.Add(addMedicoRequestDTO);
            
            return Ok(medicosDTO);
        }

        [HttpPut]
        [Route("{Id}")]
        public IActionResult editMedico(long Id, [FromBody] AddEditMedicoRequestDTO addEditMedicoRequestDTO)
        {
            if (addEditMedicoRequestDTO.Nome == "")
                return BadRequest(new MedicosResponseDTO() { Result = "Erro", Message = "Campo Nome deve ser preenchido" });

            if (addEditMedicoRequestDTO.CPF == "")
                return BadRequest(new MedicosResponseDTO() { Result = "Erro", Message = "Campo CPF deve ser preenchido" });

            if (addEditMedicoRequestDTO.NumRegistro == "")
                return BadRequest(new MedicosResponseDTO() { Result = "Erro", Message = "Campo Número Registro deve ser preenchido" });

            MedicosResponseDTO requestMedicoResultDTO = _service.Edit(Id, addEditMedicoRequestDTO);

            if (requestMedicoResultDTO.Result == "OK")
                return Ok(requestMedicoResultDTO);

            return BadRequest(requestMedicoResultDTO);
        }

        [HttpDelete]
        [Route("{Id}")]
        public IActionResult deleteMedico(long Id)
        {
            MedicosResponseDTO requestMedicoResultDTO = _service.Delete(Id);

            if(requestMedicoResultDTO.Result == "OK")
                return Ok(requestMedicoResultDTO);

            return BadRequest(requestMedicoResultDTO);
        }
    }
}
