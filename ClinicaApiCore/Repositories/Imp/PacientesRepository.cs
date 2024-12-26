using ClinicaApiCore.DB;
using ClinicaApiCore.DTOs.Pacientes;
using ClinicaApiCore.Entities;

namespace ClinicaApiCore.Repositories.Imp
{
    public class PacientesRepository : IPacientesRepository
    {
        private readonly AppDbContext _appDbContext;

        public PacientesRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public PacientesDTO Add(Pacientes entity)
        {
            _appDbContext.Pacientes.Add(entity);
            _appDbContext.SaveChanges();

            return new PacientesDTO() { IdPaciente = entity.ID_PACIENTE_LONG, Nome = entity.NOME_STR, CPF = entity.CPF_STR, Celular = entity.CELULAR_STR };
        }

        public void Edit(Pacientes entity)
        {
            _appDbContext.Pacientes.Update(entity);
            _appDbContext.SaveChanges();
        }

        public void Delete(Pacientes entity)
        {
            _appDbContext.Pacientes.Remove(entity);
            _appDbContext.SaveChanges();
        }        

        public List<PacientesDTO> GetAll(int IdEmpresa)
        {
            return _appDbContext.Pacientes.Where(p=> p.ID_EMPRESA_INT == IdEmpresa).Select(p=> 
                new PacientesDTO() { 
                    IdPaciente = p.ID_PACIENTE_LONG,
                    Nome = p.NOME_STR,
                    CPF = p.CPF_STR,
                    Celular = p.CELULAR_STR
            }).ToList();
        }

        public Pacientes GetById(int IdEmpresa, long Id)
        {
            return _appDbContext.Pacientes.FirstOrDefault(p => p.ID_EMPRESA_INT == IdEmpresa && p.ID_PACIENTE_LONG == Id);            
        }
    }
}
