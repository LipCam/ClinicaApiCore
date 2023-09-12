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

        public ProcedimentosDTO Add(AddProcedimentoRequestDTO addEditProcedimentosRequestDTO)
        {
            return _repository.Add(new Procedimentos()
            {
                DESCRICAO_STR = addEditProcedimentosRequestDTO.Descricao,
                VALOR_DEC = addEditProcedimentosRequestDTO.Valor != null ? addEditProcedimentosRequestDTO.Valor.Value : 0
            });
        }

        public RequestProcedimentoResultDTO Edit(EditProcedimentoRequestDTO editEditProcedimentosRequestDTO)
        {
            Procedimentos entity = _repository.GetById(editEditProcedimentosRequestDTO.IdProcedimento);
            if (entity != null)
            {
                entity.DESCRICAO_STR = editEditProcedimentosRequestDTO.Descricao;
                entity.VALOR_DEC = editEditProcedimentosRequestDTO.Valor != null ? editEditProcedimentosRequestDTO.Valor.Value : 0;
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
            Procedimentos Procedimentos = _repository.GetById(Id);
            if (Procedimentos != null)
                return new ProcedimentosDTO()
                {
                    IdProcedimento = Procedimentos.ID_PROCEDIMENTO_LONG,
                    Descricao = Procedimentos.DESCRICAO_STR,
                };

            return null;
        }
    }
}
