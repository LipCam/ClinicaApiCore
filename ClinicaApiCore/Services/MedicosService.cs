using ClinicaApiCore.DTOs;
using ClinicaApiCore.Repositories;
using ClinicaApiCore.Services.Imp;

namespace ClinicaApiCore.Services
{
    public class MedicosService : IMedicosService
    {
        private readonly IMedicosRepository _repository;

        public MedicosService(IMedicosRepository repository)
        {
            _repository = repository;
        }

        public List<MedicosDTO> GetAll()
        {
            return _repository.GetAll();
        }

        public MedicosDTO GetById(long Id)
        {
            return _repository.GetById(Id);
        }
    }
}
