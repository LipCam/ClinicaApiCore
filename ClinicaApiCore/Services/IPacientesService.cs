using ClinicaApiCore.DTOs.Pacientes;

namespace ClinicaApiCore.Services
{
    public interface IPacientesService
    {
        List<PacientesDTO> GetAll();
        PacientesDTO GetById(long Id);
        PacientesDTO Add(AddEditPacienteRequestDTO addPacienteRequestDTO);
        RequestPacienteResultDTO Edit(long Id, AddEditPacienteRequestDTO addEditPacienteRequestDTO);
        RequestPacienteResultDTO Delete(long Id);
    }
}
