using ClinicaApiCore.DTOs;
using ClinicaApiCore.DTOs.Pacientes;
using ClinicaApiCore.Entities;
using ClinicaApiCore.Repositories;
using System.Net;

namespace ClinicaApiCore.Services.Imp
{
    public class PacientesService : IPacientesService
    {
        private readonly IPacientesRepository _repository;

        public PacientesService(IPacientesRepository repository)
        {
            _repository = repository;
        }

        public PacientesDTO Add(AddEditPacienteRequestDTO addEditPacienteRequestDTO)
        {
            return _repository.Add(new Pacientes()
            {
                NOME_STR = addEditPacienteRequestDTO.Nome,
                CPF_STR = addEditPacienteRequestDTO.CPF,
                CELULAR_STR = addEditPacienteRequestDTO.Celular,
            });
        }

        public ResponseDTO Edit(long Id, AddEditPacienteRequestDTO addEditEditPacienteRequestDTO)
        {
            Pacientes entity = _repository.GetById(Id);
            if (entity != null)
            {
                entity.NOME_STR = addEditEditPacienteRequestDTO.Nome;
                entity.CPF_STR = addEditEditPacienteRequestDTO.CPF;
                entity.CELULAR_STR = addEditEditPacienteRequestDTO.Celular;
                _repository.Edit(entity);

                return new ResponseDTO() { StatusCode = HttpStatusCode.OK, Message = "Edição realizada com sucesso" };
            }

            return new ResponseDTO() { StatusCode = HttpStatusCode.NotFound, Message = "Registro inexistente" };
        }

        public ResponseDTO Delete(long Id)
        {
            Pacientes entity = _repository.GetById(Id);
            if (entity != null)
            {
                _repository.Delete(entity);
                return new ResponseDTO() { StatusCode = HttpStatusCode.OK, Message = "Exclusão realizada com sucesso" };
            }

            return new ResponseDTO() { StatusCode = HttpStatusCode.NotFound, Message = "Registro inexistente" };
        }

        public List<PacientesDTO> GetAll()
        {
            return _repository.GetAll();
        }

        public PacientesDTO GetById(long Id)
        {
            Pacientes pacientes = _repository.GetById(Id);
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
