using ClinicaApiCore.DTOs.Agendas;
using ClinicaApiCore.Repositories;
using System.Globalization;

namespace ClinicaApiCore.Services.Imp
{
    public class AgendasService : IAgendasService
    {
        private readonly IAgendasRepository _repository;

        public AgendasService(IAgendasRepository repository)
        {
            _repository = repository;
        }

        public List<AgendasDTO> GetByLivres(string DataInicio, string HoraInicio, string DataFim, string HoraFim, long IdProcedimento, long IdMedico)
        {
            DateTime DtInicio = DateTime.Now;
            DateTime.TryParseExact(DataInicio.Trim() + " " + HoraInicio.Trim(), "dd/MM/yyyy HH:mm", new CultureInfo("pt-BR"), DateTimeStyles.None, out DtInicio);

            DateTime DtFim = DateTime.Now;
            DateTime.TryParseExact(DataFim.Trim() + " " + HoraFim.Trim(), "dd/MM/yyyy HH:mm", new CultureInfo("pt-BR"), DateTimeStyles.None, out DtFim);

            return _repository.GetByLivres(DtInicio, DtFim, IdProcedimento, IdMedico);
        }

        public List<AgendasDTO> GetByPaciente(long IdPaciente)
        {
            return _repository.GetByPaciente(IdPaciente);
        }

        //public AgendasDTO Add(AddEditProcedimentoRequestDTO addEditAgendasRequestDTO)
        //{
        //    return _repository.Add(new Agendas()
        //    {
        //        DESCRICAO_STR = addEditAgendasRequestDTO.Descricao,
        //        VALOR_DEC = addEditAgendasRequestDTO.Valor != null ? addEditAgendasRequestDTO.Valor.Value : 0
        //    });
        //}

        //public RequestProcedimentoResultDTO Edit(long Id, AddEditProcedimentoRequestDTO addEditAgendasRequestDTO)
        //{
        //    Agendas entity = _repository.GetById(Id);
        //    if (entity != null)
        //    {
        //        entity.DESCRICAO_STR = addEditAgendasRequestDTO.Descricao;
        //        entity.VALOR_DEC = addEditAgendasRequestDTO.Valor != null ? addEditAgendasRequestDTO.Valor.Value : 0;
        //        _repository.Edit(entity);

        //        return new RequestProcedimentoResultDTO() { Result = "OK", Message = "Edição realizada com sucesso" };
        //    }

        //    return new RequestProcedimentoResultDTO() { Result = "ERRO", Message = "Registro inexistente" };
        //}

        //public RequestProcedimentoResultDTO Delete(long Id)
        //{
        //    Agendas entity = _repository.GetById(Id);
        //    if (entity != null)
        //    {
        //        _repository.Delete(entity);
        //        return new RequestProcedimentoResultDTO() { Result = "OK", Message = "Exclusão realizada com sucesso" };
        //    }

        //    return new RequestProcedimentoResultDTO() { Result = "ERRO", Message = "Registro inexistente" };
        //}

        //public List<AgendasDTO> GetAll()
        //{
        //    return _repository.GetAll();
        //}

        //public AgendasDTO GetById(long Id)
        //{
        //    Agendas Agendas = _repository.GetById(Id);
        //    if (Agendas != null)
        //        return new AgendasDTO()
        //        {
        //            IdProcedimento = Agendas.ID_PROCEDIMENTO_LONG,
        //            Descricao = Agendas.DESCRICAO_STR,
        //            Valor = Agendas.VALOR_DEC
        //        };

        //    return null;
        //}
    }
}
