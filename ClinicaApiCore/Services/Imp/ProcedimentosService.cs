using ClinicaApiCore.DTOs.Procedimentos;
using ClinicaApiCore.Entities;
using ClinicaApiCore.Repositories;

namespace ClinicaApiCore.Services.Imp
{
    public class ProcedimentosService : IProcedimentosService
    {
        private readonly IProcedimentosRepository _repository;

        public ProcedimentosService(IProcedimentosRepository repository)
        {
            _repository = repository;
        }

        public ProcedimentosDTO Add(int IdEmpresa, AddEditProcedimentoRequestDTO addEditProcedimentosRequestDTO)
        {
            return _repository.Add(new Procedimentos()
            {
                ID_EMPRESA_INT = IdEmpresa,
                DESCRICAO_STR = addEditProcedimentosRequestDTO.Descricao,
                VALOR_DEC = addEditProcedimentosRequestDTO.Valor != null ? addEditProcedimentosRequestDTO.Valor.Value : 0
            });
        }

        public ProcedimentosResponseDTO Edit(int IdEmpresa, long Id, AddEditProcedimentoRequestDTO addEditProcedimentosRequestDTO)
        {
            Procedimentos entity = _repository.GetById(IdEmpresa, Id);
            if (entity != null)
            {
                entity.DESCRICAO_STR = addEditProcedimentosRequestDTO.Descricao;
                entity.VALOR_DEC = addEditProcedimentosRequestDTO.Valor != null ? addEditProcedimentosRequestDTO.Valor.Value : 0;
                _repository.Edit(entity);

                return new ProcedimentosResponseDTO() { Result = "OK", Message = "Edição realizada com sucesso" };
            }

            return new ProcedimentosResponseDTO() { Result = "ERRO", Message = "Registro inexistente" };
        }

        public ProcedimentosResponseDTO Delete(int IdEmpresa, long Id)
        {
            Procedimentos entity = _repository.GetById(IdEmpresa, Id);
            if (entity != null)
            {
                _repository.Delete(entity);
                return new ProcedimentosResponseDTO() { Result = "OK", Message = "Exclusão realizada com sucesso" };
            }

            return new ProcedimentosResponseDTO() { Result = "ERRO", Message = "Registro inexistente" };
        }

        public List<ProcedimentosDTO> GetAll(int IdEmpresa)
        {
            return _repository.GetAll(IdEmpresa);
        }

        public ProcedimentosDTO GetById(int IdEmpresa, long Id)
        {
            Procedimentos procedimentos = _repository.GetById(IdEmpresa, Id);
            if (procedimentos != null)
                return new ProcedimentosDTO()
                {
                    IdProcedimento = procedimentos.ID_PROCEDIMENTO_LONG,
                    Codigo = procedimentos.COD_TUSS_INTER_STR,
                    Descricao = procedimentos.DESCRICAO_STR,
                    Valor = procedimentos.VALOR_DEC
                };

            return null;
        }
    }
}
