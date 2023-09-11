using ClinicaApiCore.DTOs;

namespace ClinicaApiCore.Services.Imp
{
    public interface IMedicosService
    {
        List<MedicosDTO> GetAll();
        MedicosDTO GetById(long Id);
    }
}
