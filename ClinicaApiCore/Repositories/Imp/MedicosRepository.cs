using ClinicaApiCore.DB;
using ClinicaApiCore.DTOs;

namespace ClinicaApiCore.Repositories.Imp
{
    public class MedicosRepository : IMedicosRepository
    {
        private readonly AppDbContext _appDbContext;

        public MedicosRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<MedicosDTO> GetAll()
        {
            return _appDbContext.Medicos.Select(p=> 
                new MedicosDTO() { 
                    IdMedico = p.ID_MEDICO_LONG,
                    Nome = p.NOME_STR,
                    NumRegistro = p.NUM_REGISTRO_STR
            }).ToList();
        }

        public MedicosDTO GetById(long Id)
        {
            return _appDbContext.Medicos.Select(p =>
                new MedicosDTO()
                {
                    Nome = p.NOME_STR,
                    NumRegistro = p.NUM_REGISTRO_STR
                }).FirstOrDefault(p => p.IdMedico == Id);
        }
    }
}
