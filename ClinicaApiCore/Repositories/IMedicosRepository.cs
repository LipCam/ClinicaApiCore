using ClinicaApiCore.DTOs;

namespace ClinicaApiCore.Repositories
{
    public interface IMedicosRepository
    {
        List<MedicosDTO> GetAll();
        MedicosDTO GetById(long Id);
    }
}
