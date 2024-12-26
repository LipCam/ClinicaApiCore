using ClinicaApiCore.DB;
using ClinicaApiCore.DTOs.Procedimentos;
using ClinicaApiCore.Entities;

namespace ClinicaApiCore.Repositories.Imp
{
    public class ProcedimentosRepository : IProcedimentosRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProcedimentosRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public ProcedimentosDTO Add(Procedimentos entity)
        {
            _appDbContext.Procedimentos.Add(entity);
            _appDbContext.SaveChanges();

            return new ProcedimentosDTO() { IdProcedimento = entity.ID_PROCEDIMENTO_LONG, Descricao = entity.DESCRICAO_STR, Valor = entity.VALOR_DEC };
        }

        public void Edit(Procedimentos entity)
        {
            _appDbContext.Procedimentos.Update(entity);
            _appDbContext.SaveChanges();
        }

        public void Delete(Procedimentos entity)
        {
            _appDbContext.Procedimentos.Remove(entity);
            _appDbContext.SaveChanges();
        }        

        public List<ProcedimentosDTO> GetAll(int IdEmpresa)
        {
            return _appDbContext.Procedimentos.Where(p=> p.ID_EMPRESA_INT == IdEmpresa).Select(p=> 
                new ProcedimentosDTO() { 
                    IdProcedimento = p.ID_PROCEDIMENTO_LONG,
                    Codigo = p.COD_TUSS_INTER_STR,
                    Descricao = p.DESCRICAO_STR,
                    Valor = p.VALOR_DEC
            }).ToList();
        }

        public Procedimentos GetById(int IdEmpresa, long Id)
        {
            return _appDbContext.Procedimentos.FirstOrDefault(p => p.ID_EMPRESA_INT == IdEmpresa && p.ID_PROCEDIMENTO_LONG == Id);            
        }
    }
}
