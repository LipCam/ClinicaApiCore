using ClinicaApiCore.DTOs;
using ClinicaApiCore.DTOs.Medicos;

namespace ClinicaApiCore.Services
{
    public interface IMedicosService
    {
        List<MedicosDTO> GetAll();
        MedicosDTO GetById(long Id);
        MedicosDTO Add(AddEditMedicoRequestDTO addMedicoRequestDTO);
        ResponseDTO Edit(long Id, AddEditMedicoRequestDTO addEditMedicoRequestDTO);
        ResponseDTO Delete(long Id);
    }
}
