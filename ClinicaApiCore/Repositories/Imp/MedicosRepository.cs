using ClinicaApiCore.DB;
using ClinicaApiCore.DTOs.Medicos;
using ClinicaApiCore.Entities;

namespace ClinicaApiCore.Repositories.Imp
{
    public class MedicosRepository : IMedicosRepository
    {
        private readonly AppDbContext _appDbContext;

        public MedicosRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public MedicosDTO Add(Medicos entity)
        {
            entity.ID_USUARIO_LONG = _appDbContext.Medicos.Count() > 0 ? _appDbContext.Medicos.Max(p=> p.ID_USUARIO_LONG) + 1 : 1;
            _appDbContext.Medicos.Add(entity);
            _appDbContext.SaveChanges();

            return new MedicosDTO() { IdMedico = entity.ID_USUARIO_LONG, Nome = entity.NOME_STR, NumRegistro = entity.NUM_REGISTRO_STR };
        }

        public void Edit(Medicos entity)
        {
            _appDbContext.Medicos.Update(entity);
            _appDbContext.SaveChanges();
        }

        public void Delete(Medicos entity)
        {
            _appDbContext.Medicos.Remove(entity);
            _appDbContext.SaveChanges();
        }        

        public List<MedicosDTO> GetAll(int IdEmpresa)
        {
            return _appDbContext.Medicos.Where(p=> p.ID_EMPRESA_INT == IdEmpresa).Select(p=> 
                new MedicosDTO() { 
                    IdMedico = p.ID_USUARIO_LONG,
                    Nome = p.NOME_STR,
                    NumRegistro = p.NUM_REGISTRO_STR
            }).ToList();
        }

        public Medicos GetById(int IdEmpresa, long Id)
        {
            return _appDbContext.Medicos.FirstOrDefault(p => p.ID_EMPRESA_INT == IdEmpresa && p.ID_USUARIO_LONG == Id);            
        }
    }
}
