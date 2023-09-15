using ClinicaApiCore.DTOs.Medicos;
using ClinicaApiCore.Entities;
using ClinicaApiCore.Repositories;

namespace ClinicaApiCore.Services.Imp
{
    public class MedicosService : IMedicosService
    {
        private readonly IMedicosRepository _repository;

        public MedicosService(IMedicosRepository repository)
        {
            _repository = repository;
        }

        public MedicosDTO Add(AddEditMedicoRequestDTO addEditMedicoRequestDTO)
        {
            return _repository.Add(new Medicos()
            {
                NOME_STR = addEditMedicoRequestDTO.Nome,
                CPF_STR = addEditMedicoRequestDTO.CPF,
                NUM_REGISTRO_STR = addEditMedicoRequestDTO.NumRegistro,
            });
        }

        public RequestMedicoResultDTO Edit(long Id, AddEditMedicoRequestDTO addEditEditMedicoRequestDTO)
        {
            Medicos entity = _repository.GetById(Id);
            if (entity != null)
            {
                entity.NOME_STR = addEditEditMedicoRequestDTO.Nome;
                entity.CPF_STR = addEditEditMedicoRequestDTO.CPF;
                entity.NUM_REGISTRO_STR = addEditEditMedicoRequestDTO.NumRegistro;
                _repository.Edit(entity);

                return new RequestMedicoResultDTO() { Result = "OK", Message = "Edição realizada com sucesso" };
            }

            return new RequestMedicoResultDTO() { Result = "ERRO", Message = "Registro inexistente" };
        }

        public RequestMedicoResultDTO Delete(long Id)
        {
            Medicos entity = _repository.GetById(Id);
            if (entity != null)
            {
                _repository.Delete(entity);
                return new RequestMedicoResultDTO() { Result = "OK", Message = "Exclusão realizada com sucesso" };
            }

            return new RequestMedicoResultDTO() { Result = "ERRO", Message = "Registro inexistente" };
        }

        public List<MedicosDTO> GetAll()
        {
            return _repository.GetAll();
        }

        public MedicosDTO GetById(long Id)
        {
            Medicos medicos = _repository.GetById(Id);
            if (medicos != null)
                return new MedicosDTO()
                {
                    IdMedico = medicos.ID_MEDICO_LONG,
                    Nome = medicos.NOME_STR,
                    NumRegistro = medicos.NUM_REGISTRO_STR
                };

            return null;
        }
    }
}
