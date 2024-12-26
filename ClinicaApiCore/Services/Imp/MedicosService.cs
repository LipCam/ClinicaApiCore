using ClinicaApiCore.DTOs;
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

        public Result<MedicosDTO> Add(int IdEmpresa, AddEditMedicoRequestDTO addEditMedicoRequestDTO)
        {
            return Result<MedicosDTO>.Success(_repository.Add(new Medicos()
            {
                ID_EMPRESA_INT = IdEmpresa,
                NOME_STR = addEditMedicoRequestDTO.Nome,
                CPF_STR = addEditMedicoRequestDTO.CPF,
                NUM_REGISTRO_STR = addEditMedicoRequestDTO.NumRegistro,
                PROFISSIONAL_BIT = true,
                MASTER_ATD_BIT = false,
                VER_TODAS_CONSULTAS_BIT = false,
                ID_VINCULO_COL_INT = 1
            }));
        }

        public Result<string> Edit(int IdEmpresa, long Id, AddEditMedicoRequestDTO addEditEditMedicoRequestDTO)
        {
            Medicos entity = _repository.GetById(IdEmpresa, Id);
            if (entity != null)
            {
                entity.ID_EMPRESA_INT = IdEmpresa;
                entity.NOME_STR = addEditEditMedicoRequestDTO.Nome;
                entity.CPF_STR = addEditEditMedicoRequestDTO.CPF;
                entity.NUM_REGISTRO_STR = addEditEditMedicoRequestDTO.NumRegistro;
                _repository.Edit(entity);

                return Result<string>.Success("Edição realizada com sucesso");
            }

            return Result<string>.Failure("Registro inexistente");
        }

        public Result<string> Delete(int IdEmpresa, long Id)
        {
            Medicos entity = _repository.GetById(IdEmpresa, Id);
            if (entity != null)
            {
                _repository.Delete(entity);
                return Result<string>.Success("Exclusão realizada com sucesso");
            }

            return Result<string>.Failure("Registro inexistente");
        }

        public Result<List<MedicosDTO>> GetAll(int IdEmpresa)
        {
            return Result<List<MedicosDTO>>.Success(_repository.GetAll(IdEmpresa));
        }

        public Result<MedicosDTO> GetById(int IdEmpresa, long Id)
        {
            Medicos medicos = _repository.GetById(IdEmpresa, Id);
            if (medicos != null)
                return Result<MedicosDTO>.Success(new MedicosDTO()
                {
                    IdMedico = medicos.ID_USUARIO_LONG,
                    Nome = medicos.NOME_STR,
                    NumRegistro = medicos.NUM_REGISTRO_STR
                });

            return Result<MedicosDTO>.Failure("Registro não encontrado");
        }
    }
}
