using ClinicaApiCore.DTOs.Procedimentos;
using ClinicaApiCore.Entities;

namespace ClinicaApiCore.Repositories
{
    public interface IProcedimentosRepository
    {
        List<ProcedimentosDTO> GetAll();
        Procedimentos GetById(long Id);
        ProcedimentosDTO Add(Procedimentos entity);
        void Edit(Procedimentos entity);
        void Delete(Procedimentos entity);
    }
}
