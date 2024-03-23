using ClinicaApiCore.DTOs.Pacientes;

namespace ClinicaApiCore.Services
{
    public interface IPacientesService
    {
        List<PacientesDTO> GetAll(int IdEmpresa);
        PacientesDTO GetById(int IdEmpresa, long Id);
        PacientesDTO Add(int IdEmpresa, AddEditPacienteRequestDTO addPacienteRequestDTO);
        PacientesResponseDTO Edit(int IdEmpresa, long Id, AddEditPacienteRequestDTO addEditPacienteRequestDTO);
        PacientesResponseDTO Delete(int IdEmpresa, long Id);
    }
}
