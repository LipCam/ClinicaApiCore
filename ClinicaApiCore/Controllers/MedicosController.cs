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
        [Route("{IdEmpresa}")]
        public IActionResult GetAll(int IdEmpresa)
        {
            return Ok(_service.GetAll(IdEmpresa));
        }

        [HttpGet]
        [Route("{IdEmpresa}/{Id}")]
        public IActionResult GetById(int IdEmpresa, long Id)
        {
            MedicosDTO medicosDTO = _service.GetById(IdEmpresa, Id);
            if (medicosDTO != null)
                return Ok(medicosDTO);
            
            return BadRequest(new MedicosResponseDTO() { Result = "Erro", Message = "Registro não encontrado" });
        }

        [HttpPost]
        [Route("{IdEmpresa}")]
        public IActionResult addMedico(int IdEmpresa, [FromBody] AddEditMedicoRequestDTO addMedicoRequestDTO)
        {
            if (addMedicoRequestDTO.Nome == "")
                return BadRequest(new MedicosResponseDTO() { Result = "Erro", Message = "Campo Nome deve ser preenchido" });

            if (addMedicoRequestDTO.CPF == "")
                return BadRequest(new MedicosResponseDTO() { Result = "Erro", Message = "Campo CPF deve ser preenchido" });

            if (addMedicoRequestDTO.NumRegistro == "")
                return BadRequest(new MedicosResponseDTO() { Result = "Erro", Message = "Campo Número Registro deve ser preenchido" });

            MedicosDTO medicosDTO = _service.Add(IdEmpresa, addMedicoRequestDTO);
            
            return Ok(medicosDTO);
        }

        [HttpPut]
        [Route("{IdEmpresa}/{Id}")]
        public IActionResult editMedico(int IdEmpresa, long Id, [FromBody] AddEditMedicoRequestDTO addEditMedicoRequestDTO)
        {
            if (addEditMedicoRequestDTO.Nome == "")
                return BadRequest(new MedicosResponseDTO() { Result = "Erro", Message = "Campo Nome deve ser preenchido" });

            if (addEditMedicoRequestDTO.CPF == "")
                return BadRequest(new MedicosResponseDTO() { Result = "Erro", Message = "Campo CPF deve ser preenchido" });

            if (addEditMedicoRequestDTO.NumRegistro == "")
                return BadRequest(new MedicosResponseDTO() { Result = "Erro", Message = "Campo Número Registro deve ser preenchido" });

            MedicosResponseDTO requestMedicoResultDTO = _service.Edit(IdEmpresa, Id, addEditMedicoRequestDTO);

            if (requestMedicoResultDTO.Result == "OK")
                return Ok(requestMedicoResultDTO);

            return BadRequest(requestMedicoResultDTO);
        }

        [HttpDelete]
        [Route("{IdEmpresa}/{Id}")]
        public IActionResult deleteMedico(int IdEmpresa, long Id)
        {
            MedicosResponseDTO requestMedicoResultDTO = _service.Delete(IdEmpresa, Id);

            if(requestMedicoResultDTO.Result == "OK")
                return Ok(requestMedicoResultDTO);

            return BadRequest(requestMedicoResultDTO);
        }
    }
}
