using ClinicaApiCore.DTOs.Pacientes;

namespace ClinicaApiCore.Services
{
    public interface IPacientesService
    {
        List<PacientesDTO> GetAll();
        PacientesDTO GetById(long Id);
        PacientesDTO Add(AddEditPacienteRequestDTO addPacienteRequestDTO);
        PacientesResponseDTO Edit(long Id, AddEditPacienteRequestDTO addEditPacienteRequestDTO);
        PacientesResponseDTO Delete(long Id);
    }
}
