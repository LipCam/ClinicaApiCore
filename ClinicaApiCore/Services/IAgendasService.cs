using ClinicaApiCore.DTOs;
using ClinicaApiCore.DTOs.Agendas;

namespace ClinicaApiCore.Services
{
    public interface IAgendasService
    {
        List<AgendasDTO> GetByLivres(string DataInicio, string HoraInicio, string DataFim, string HoraFim, long IdProcedimento, long IdMedico);
        List<AgendasDTO> GetByPaciente(long IdPaciente);
        ResponseDTO RealizarAgendamento(long IdAgenda, long IdPaciente);
        ResponseDTO CancelarAgendamento(long IdAgenda);
    }
}
