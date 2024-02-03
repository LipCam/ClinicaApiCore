using ClinicaApiCore.DTOs.Medicos;

namespace ClinicaApiCore.Services
{
    public interface IMedicosService
    {
        List<MedicosDTO> GetAll();
        MedicosDTO GetById(long Id);
        MedicosDTO Add(AddEditMedicoRequestDTO addMedicoRequestDTO);
        MedicosResponseDTO Edit(long Id, AddEditMedicoRequestDTO addEditMedicoRequestDTO);
        MedicosResponseDTO Delete(long Id);
    }
}
