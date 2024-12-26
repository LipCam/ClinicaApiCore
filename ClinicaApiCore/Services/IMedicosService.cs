using ClinicaApiCore.DTOs;
using ClinicaApiCore.DTOs.Medicos;

namespace ClinicaApiCore.Services
{
    public interface IMedicosService
    {
        Result<List<MedicosDTO>> GetAll(int IdEmpresa);
        Result<MedicosDTO> GetById(int IdEmpresa, long Id);
        Result<MedicosDTO> Add(int IdEmpresa, AddEditMedicoRequestDTO addMedicoRequestDTO);
        Result<string> Edit(int IdEmpresa, long Id, AddEditMedicoRequestDTO addEditMedicoRequestDTO);
        Result<string> Delete(int IdEmpresa, long Id);
    }
}
