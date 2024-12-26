using ClinicaApiCore.DTOs;
using ClinicaApiCore.DTOs.Pacientes;

namespace ClinicaApiCore.Services
{
    public interface IPacientesService
    {
        Result<List<PacientesDTO>> GetAll(int IdEmpresa);
        Result<PacientesDTO> GetById(int IdEmpresa, long Id);
        Result<PacientesDTO> Add(int IdEmpresa, AddEditPacienteRequestDTO addPacienteRequestDTO);
        Result<string> Edit(int IdEmpresa, long Id, AddEditPacienteRequestDTO addEditPacienteRequestDTO);
        Result<string> Delete(int IdEmpresa, long Id);
    }
}
