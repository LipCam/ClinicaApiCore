using ClinicaApiCore.DTOs.Medicos;
using ClinicaApiCore.Entities;

namespace ClinicaApiCore.Repositories
{
    public interface IMedicosRepository
    {
        List<MedicosDTO> GetAll();
        Medicos GetById(long Id);
        MedicosDTO Add(Medicos entity);
        void Edit(Medicos entity);
        void Delete(Medicos entity);
    }
}
