using ClinicaApiCore.DTOs.Procedimentos;
using ClinicaApiCore.Entities;

namespace ClinicaApiCore.Repositories
{
    public interface IProcedimentosRepository
    {
        List<ProcedimentosDTO> GetAll(int IdEmpresa);
        Procedimentos GetById(int IdEmpresa, long Id);
        ProcedimentosDTO Add(Procedimentos entity);
        void Edit(Procedimentos entity);
        void Delete(Procedimentos entity);
    }
}
