using ClinicaApiCore.DTOs;
using ClinicaApiCore.DTOs.Procedimentos;
using ClinicaApiCore.Entities;
using ClinicaApiCore.Repositories;
using System.Net;

namespace ClinicaApiCore.Services.Imp
{
    public class ProcedimentosService : IProcedimentosService
    {
        private readonly IProcedimentosRepository _repository;

        public ProcedimentosService(IProcedimentosRepository repository)
        {
            _repository = repository;
        }

        public Result<ProcedimentosDTO> Add(int IdEmpresa, AddEditProcedimentoRequestDTO addEditProcedimentosRequestDTO)
        {
            return Result<ProcedimentosDTO>.Success(_repository.Add(new Procedimentos()
            {
                ID_EMPRESA_INT = IdEmpresa,
                DESCRICAO_STR = addEditProcedimentosRequestDTO.Descricao,
                VALOR_DEC = addEditProcedimentosRequestDTO.Valor != null ? addEditProcedimentosRequestDTO.Valor.Value : 0
            }));
        }

        public Result<string> Edit(int IdEmpresa, long Id, AddEditProcedimentoRequestDTO addEditProcedimentosRequestDTO)
        {
            Procedimentos entity = _repository.GetById(IdEmpresa, Id);
            if (entity != null)
            {
                entity.DESCRICAO_STR = addEditProcedimentosRequestDTO.Descricao;
                entity.VALOR_DEC = addEditProcedimentosRequestDTO.Valor != null ? addEditProcedimentosRequestDTO.Valor.Value : 0;
                _repository.Edit(entity);

                return Result<string>.Success("Edição realizada com sucesso");
            }

            return Result<string>.Failure("Registro inexistente");
        }

        public Result<string> Delete(int IdEmpresa, long Id)
        {
            Procedimentos entity = _repository.GetById(IdEmpresa, Id);
            if (entity != null)
            {
                _repository.Delete(entity);
                return Result<string>.Success("Exclusão realizada com sucesso");
            }

            return Result<string>.Failure("Registro inexistente");
        }

        public Result<List<ProcedimentosDTO>> GetAll(int IdEmpresa)
        {
            return Result<List<ProcedimentosDTO>>.Success(_repository.GetAll(IdEmpresa));
        }

        public Result<ProcedimentosDTO> GetById(int IdEmpresa, long Id)
        {
            Procedimentos procedimentos = _repository.GetById(IdEmpresa, Id);
            if (procedimentos != null)
                return Result<ProcedimentosDTO>.Success(new ProcedimentosDTO()
                {
                    IdProcedimento = procedimentos.ID_PROCEDIMENTO_LONG,
                    Codigo = procedimentos.COD_TUSS_INTER_STR,
                    Descricao = procedimentos.DESCRICAO_STR,
                    Valor = procedimentos.VALOR_DEC
                });

            return Result<ProcedimentosDTO>.Failure("Registro não encontrado");
        }
    }
}
