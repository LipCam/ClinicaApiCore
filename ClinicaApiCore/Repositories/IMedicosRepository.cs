using ClinicaApiCore.DTOs.Medicos;
using ClinicaApiCore.Entities;

namespace ClinicaApiCore.Repositories
{
    public interface IMedicosRepository
    {
        List<MedicosDTO> GetAll(int IdEmpresa);
        Medicos GetById(int IdEmpresa, long Id);
        MedicosDTO Add(Medicos entity);
        void Edit(Medicos entity);
        void Delete(Medicos entity);
    }
}
