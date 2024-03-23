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

        public PacientesDTO Add(int IdEmpresa, AddEditPacienteRequestDTO addEditPacienteRequestDTO)
        {
            return _repository.Add(new Pacientes()
            {
                ID_EMPRESA_INT = IdEmpresa,
                NOME_STR = addEditPacienteRequestDTO.Nome,
                CPF_STR = addEditPacienteRequestDTO.CPF,
                CELULAR_STR = addEditPacienteRequestDTO.Celular,
            });
        }

        public PacientesResponseDTO Edit(int IdEmpresa, long Id, AddEditPacienteRequestDTO addEditEditPacienteRequestDTO)
        {
            Pacientes entity = _repository.GetById(IdEmpresa, Id);
            if (entity != null)
            {
                entity.ID_EMPRESA_INT = IdEmpresa;
                entity.NOME_STR = addEditEditPacienteRequestDTO.Nome;
                entity.CPF_STR = addEditEditPacienteRequestDTO.CPF;
                entity.CELULAR_STR = addEditEditPacienteRequestDTO.Celular;
                _repository.Edit(entity);

                return new PacientesResponseDTO() { Result = "OK", Message = "Edição realizada com sucesso" };
            }

            return new PacientesResponseDTO() { Result = "ERRO", Message = "Registro inexistente" };
        }

        public PacientesResponseDTO Delete(int IdEmpresa, long Id)
        {
            Pacientes entity = _repository.GetById(IdEmpresa, Id);
            if (entity != null)
            {
                _repository.Delete(entity);
                return new PacientesResponseDTO() { Result = "OK", Message = "Exclusão realizada com sucesso" };
            }

            return new PacientesResponseDTO() { Result = "ERRO", Message = "Registro inexistente" };
        }

        public List<PacientesDTO> GetAll(int IdEmpresa)
        {
            return _repository.GetAll(IdEmpresa);
        }

        public PacientesDTO GetById(int IdEmpresa, long Id)
        {
            Pacientes pacientes = _repository.GetById(IdEmpresa, Id);
            if (pacientes != null)
                return new PacientesDTO()
                {
                    IdPaciente = pacientes.ID_PACIENTE_LONG,
                    Nome = pacientes.NOME_STR,
                    CPF = pacientes.CPF_STR,
                    Celular = pacientes.CELULAR_STR
                };

            return null;
        }
    }
}
