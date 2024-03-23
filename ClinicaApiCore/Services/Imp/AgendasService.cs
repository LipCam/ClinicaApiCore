using ClinicaApiCore.DTOs.Agendas;
using ClinicaApiCore.Entities;
using ClinicaApiCore.Repositories;
using System.Globalization;

namespace ClinicaApiCore.Services.Imp
{
    public class AgendasService : IAgendasService
    {
        private readonly IAgendasRepository _repository;
        private readonly IPacientesRepository _pacientesRepository;

        public AgendasService(IAgendasRepository repository, IPacientesRepository pacientesRepository)
        {
            _repository = repository;
            _pacientesRepository = pacientesRepository;
        }

        public List<AgendasDTO> GetByLivres(int IdEmpresa, string DataInicio, string HoraInicio, string DataFim, string HoraFim, long IdProcedimento, long IdMedico)
        {
            DateTime DtInicio;
            DateTime.TryParseExact(DataInicio.Trim() + " " + HoraInicio.Trim(), "dd/MM/yyyy HH:mm", new CultureInfo("pt-BR"), DateTimeStyles.None, out DtInicio);

            if(DtInicio == DateTime.MinValue)
                DtInicio = DateTime.Now;

            DateTime DtFim;
            DateTime.TryParseExact(DataFim.Trim() + " " + HoraFim.Trim(), "dd/MM/yyyy HH:mm", new CultureInfo("pt-BR"), DateTimeStyles.None, out DtFim);

            if (DtFim == DateTime.MinValue)
                DtFim = DateTime.Now;

            return _repository.GetByLivres(IdEmpresa, DtInicio, DtFim, IdProcedimento, IdMedico);
        }

        public List<AgendasDTO> GetByPaciente(int IdEmpresa, long IdPaciente)
        {
            return _repository.GetByPaciente(IdEmpresa, IdPaciente);
        }

        public AgendasResponseDTO RealizarAgendamento(long IdAgenda, long IdPaciente)
        {
            Agendas objAgendas = _repository.GetById(IdAgenda);
            if (objAgendas == null)
                return new AgendasResponseDTO() { Result = "ERRO", Message = "Agendamento inexente" };

            if(_pacientesRepository.GetById(objAgendas.ID_EMPRESA_INT, IdPaciente) == null)
                return new AgendasResponseDTO() { Result = "ERRO", Message = "Paciente inexente" };

            if (objAgendas.ID_PACIENTE_LONG != null)
                return new AgendasResponseDTO() { Result = "ERRO", Message = "Agendamento já realizado" };

            objAgendas.ID_PACIENTE_LONG = IdPaciente;
            objAgendas.ID_STATUS_INT = 1;
            objAgendas.DATA_AGENDAMENTO_DTI = DateTime.Now;
            _repository.Update(objAgendas);

            return new AgendasResponseDTO() { Result = "OK", Message = "Agendamento realizado" };
        }

        public AgendasResponseDTO CancelarAgendamento(long IdAgenda)
        {
            Agendas objAgendas = _repository.GetById(IdAgenda);
            if (objAgendas == null)
                return new AgendasResponseDTO() { Result = "ERRO", Message = "Agendamento inexente" };

            if (objAgendas.ID_PACIENTE_LONG == null)
                return new AgendasResponseDTO() { Result = "ERRO", Message = "Agendamento já em status livre" };

            objAgendas.ID_PACIENTE_LONG = null;
            objAgendas.ID_STATUS_INT = 0;
            objAgendas.DATA_AGENDAMENTO_DTI = null;
            _repository.Update(objAgendas);

            return new AgendasResponseDTO() { Result = "OK", Message = "Agendamento cancelado" };
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
