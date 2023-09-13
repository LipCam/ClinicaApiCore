using ClinicaApiCore.DTOs.Pacientes;

namespace ClinicaApiCore.Services
{
    public interface IPacientesService
    {
        List<PacientesDTO> GetAll();
        PacientesDTO GetById(long Id);
        PacientesDTO Add(AddPacienteRequestDTO addPacienteRequestDTO);
        RequestPacienteResultDTO Edit(EditPacienteRequestDTO editPacienteRequestDTO);
        RequestPacienteResultDTO Delete(long Id);
    }
}
