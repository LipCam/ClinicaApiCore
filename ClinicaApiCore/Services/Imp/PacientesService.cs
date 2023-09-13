using ClinicaApiCore.DTOs.Pacientes;
using ClinicaApiCore.Entities;
using ClinicaApiCore.Repositories;

namespace ClinicaApiCore.Services.Imp
{
    public class PacientesService : IPacientesService
    {
        private readonly IPacientesRepository _repository;

        public PacientesService(IPacientesRepository repository)
        {
            _repository = repository;
        }

        public PacientesDTO Add(AddPacienteRequestDTO addEditPacienteRequestDTO)
        {
            return _repository.Add(new Pacientes()
            {
                NOME_STR = addEditPacienteRequestDTO.Nome,
                CPF_STR = addEditPacienteRequestDTO.CPF,
                CELULAR_STR = addEditPacienteRequestDTO.Celular,
            });
        }

        public RequestPacienteResultDTO Edit(EditPacienteRequestDTO editEditPacienteRequestDTO)
        {
            Pacientes entity = _repository.GetById(editEditPacienteRequestDTO.IdPaciente);
            if (entity != null)
            {
                entity.NOME_STR = editEditPacienteRequestDTO.Nome;
                entity.CPF_STR = editEditPacienteRequestDTO.CPF;
                entity.CELULAR_STR = editEditPacienteRequestDTO.Celular;
                _repository.Edit(entity);

                return new RequestPacienteResultDTO() { Result = "OK", Message = "Edição realizada com sucesso" };
            }

            return new RequestPacienteResultDTO() { Result = "ERRO", Message = "Registro inexistente" };
        }

        public RequestPacienteResultDTO Delete(long Id)
        {
            Pacientes entity = _repository.GetById(Id);
            if (entity != null)
            {
                _repository.Delete(entity);
                return new RequestPacienteResultDTO() { Result = "OK", Message = "Exclusão realizada com sucesso" };
            }

            return new RequestPacienteResultDTO() { Result = "ERRO", Message = "Registro inexistente" };
        }

        public List<PacientesDTO> GetAll()
        {
            return _repository.GetAll();
        }

        public PacientesDTO GetById(long Id)
        {
            Pacientes Pacientes = _repository.GetById(Id);
            return new PacientesDTO()
            {
                IdPaciente = Pacientes.ID_PACIENTE_LONG,
                Nome = Pacientes.NOME_STR,
                CPF = Pacientes.CPF_STR,
                Celular = Pacientes.CELULAR_STR
            };
        }
    }
}
