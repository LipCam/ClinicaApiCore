using ClinicaApiCore.DTOs.Medicos;

namespace ClinicaApiCore.Services
{
    public interface IMedicosService
    {
        List<MedicosDTO> GetAll();
        MedicosDTO GetById(long Id);
        MedicosDTO Add(AddMedicoRequestDTO addMedicoRequestDTO);
        RequestMedicoResultDTO Edit(EditMedicoRequestDTO editMedicoRequestDTO);
        RequestMedicoResultDTO Delete(long Id);
    }
}
