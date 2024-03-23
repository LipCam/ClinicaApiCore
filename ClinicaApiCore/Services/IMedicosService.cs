using ClinicaApiCore.DTOs.Medicos;

namespace ClinicaApiCore.Services
{
    public interface IMedicosService
    {
        List<MedicosDTO> GetAll(int IdEmpresa);
        MedicosDTO GetById(int IdEmpresa, long Id);
        MedicosDTO Add(int IdEmpresa, AddEditMedicoRequestDTO addMedicoRequestDTO);
        MedicosResponseDTO Edit(int IdEmpresa, long Id, AddEditMedicoRequestDTO addEditMedicoRequestDTO);
        MedicosResponseDTO Delete(int IdEmpresa, long Id);
    }
}
