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

        public MedicosDTO Add(int IdEmpresa, AddEditMedicoRequestDTO addEditMedicoRequestDTO)
        {
            return _repository.Add(new Medicos()
            {
                ID_EMPRESA_INT = IdEmpresa,
                NOME_STR = addEditMedicoRequestDTO.Nome,
                CPF_STR = addEditMedicoRequestDTO.CPF,
                NUM_REGISTRO_STR = addEditMedicoRequestDTO.NumRegistro,
            });
        }

        public MedicosResponseDTO Edit(int IdEmpresa, long Id, AddEditMedicoRequestDTO addEditEditMedicoRequestDTO)
        {
            Medicos entity = _repository.GetById(IdEmpresa, Id);
            if (entity != null)
            {
                entity.ID_EMPRESA_INT = IdEmpresa;
                entity.NOME_STR = addEditEditMedicoRequestDTO.Nome;
                entity.CPF_STR = addEditEditMedicoRequestDTO.CPF;
                entity.NUM_REGISTRO_STR = addEditEditMedicoRequestDTO.NumRegistro;
                _repository.Edit(entity);

                return new MedicosResponseDTO() { Result = "OK", Message = "Edição realizada com sucesso" };
            }

            return new MedicosResponseDTO() { Result = "ERRO", Message = "Registro inexistente" };
        }

        public MedicosResponseDTO Delete(int IdEmpresa, long Id)
        {
            Medicos entity = _repository.GetById(IdEmpresa, Id);
            if (entity != null)
            {
                _repository.Delete(entity);
                return new MedicosResponseDTO() { Result = "OK", Message = "Exclusão realizada com sucesso" };
            }

            return new MedicosResponseDTO() { Result = "ERRO", Message = "Registro inexistente" };
        }

        public List<MedicosDTO> GetAll(int IdEmpresa)
        {
            return _repository.GetAll(IdEmpresa);
        }

        public MedicosDTO GetById(int IdEmpresa, long Id)
        {
            Medicos medicos = _repository.GetById(IdEmpresa, Id);
            if (medicos != null)
                return new MedicosDTO()
                {
                    IdMedico = medicos.ID_USUARIO_LONG,
                    Nome = medicos.NOME_STR,
                    NumRegistro = medicos.NUM_REGISTRO_STR
                };

            return null;
        }
    }
}
