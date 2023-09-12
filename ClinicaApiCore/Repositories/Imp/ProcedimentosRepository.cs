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

        public List<ProcedimentosDTO> GetAll()
        {
            return _appDbContext.Procedimentos.Select(p=> 
                new ProcedimentosDTO() { 
                    IdProcedimento = p.ID_PROCEDIMENTO_LONG,
                    Descricao = p.DESCRICAO_STR,
                    Valor = p.VALOR_DEC
            }).ToList();
        }

        public Procedimentos GetById(long Id)
        {
            return _appDbContext.Procedimentos.FirstOrDefault(p => p.ID_PROCEDIMENTO_LONG == Id);            
        }
    }
}
