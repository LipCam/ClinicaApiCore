using ClinicaApiCore.DTOs.Agendas;

namespace ClinicaApiCore.Services
{
    public interface IAgendasService
    {
        List<AgendasDTO> GetByLivres(string DataInicio, string HoraInicio, string DataFim, string HoraFim, long IdProcedimento, long IdMedico);
        List<AgendasDTO> GetByPaciente(long IdPaciente);
        AgendamentodResponse RealizarAgendamento(long IdAgenda, long IdPaciente);
        AgendamentodResponse CancelarAgendamento(long IdAgenda);
    }
}
