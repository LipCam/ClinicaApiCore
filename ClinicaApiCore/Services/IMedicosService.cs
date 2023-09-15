using ClinicaApiCore.DTOs.Medicos;

namespace ClinicaApiCore.Services
{
    public interface IMedicosService
    {
        List<MedicosDTO> GetAll();
        MedicosDTO GetById(long Id);
        MedicosDTO Add(AddEditMedicoRequestDTO addMedicoRequestDTO);
        RequestMedicoResultDTO Edit(long Id, AddEditMedicoRequestDTO addEditMedicoRequestDTO);
        RequestMedicoResultDTO Delete(long Id);
    }
}
