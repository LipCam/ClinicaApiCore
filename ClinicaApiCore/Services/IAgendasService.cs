using ClinicaApiCore.DTOs.Agendas;

namespace ClinicaApiCore.Services
{
    public interface IAgendasService
    {
        List<AgendasDTO> GetByLivres(string DataInicio, string HoraInicio, string DataFim, string HoraFim, long IdProcedimento, long IdMedico);
        List<AgendasDTO> GetByPaciente(long IdPaciente);
        AgendasResponseDTO RealizarAgendamento(long IdAgenda, long IdPaciente);
        AgendasResponseDTO CancelarAgendamento(long IdAgenda);
    }
}
