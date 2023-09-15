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

        public ProcedimentosDTO Add(AddEditProcedimentoRequestDTO addEditProcedimentosRequestDTO)
        {
            return _repository.Add(new Procedimentos()
            {
                DESCRICAO_STR = addEditProcedimentosRequestDTO.Descricao,
                VALOR_DEC = addEditProcedimentosRequestDTO.Valor != null ? addEditProcedimentosRequestDTO.Valor.Value : 0
            });
        }

        public RequestProcedimentoResultDTO Edit(long Id, AddEditProcedimentoRequestDTO addEditProcedimentosRequestDTO)
        {
            Procedimentos entity = _repository.GetById(Id);
            if (entity != null)
            {
                entity.DESCRICAO_STR = addEditProcedimentosRequestDTO.Descricao;
                entity.VALOR_DEC = addEditProcedimentosRequestDTO.Valor != null ? addEditProcedimentosRequestDTO.Valor.Value : 0;
                _repository.Edit(entity);

                return new RequestProcedimentoResultDTO() { Result = "OK", Message = "Edição realizada com sucesso" };
            }

            return new RequestProcedimentoResultDTO() { Result = "ERRO", Message = "Registro inexistente" };
        }

        public RequestProcedimentoResultDTO Delete(long Id)
        {
            Procedimentos entity = _repository.GetById(Id);
            if (entity != null)
            {
                _repository.Delete(entity);
                return new RequestProcedimentoResultDTO() { Result = "OK", Message = "Exclusão realizada com sucesso" };
            }

            return new RequestProcedimentoResultDTO() { Result = "ERRO", Message = "Registro inexistente" };
        }

        public List<ProcedimentosDTO> GetAll()
        {
            return _repository.GetAll();
        }

        public ProcedimentosDTO GetById(long Id)
        {
            Procedimentos procedimentos = _repository.GetById(Id);
            if (procedimentos != null)
                return new ProcedimentosDTO()
                {
                    IdProcedimento = procedimentos.ID_PROCEDIMENTO_LONG,
                    Descricao = procedimentos.DESCRICAO_STR,
                    Valor = procedimentos.VALOR_DEC
                };

            return null;
        }
    }
}
