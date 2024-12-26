using ClinicaApiCore.DTOs;
using ClinicaApiCore.DTOs.Agendas;

namespace ClinicaApiCore.Services
{
    public interface IAgendasService
    {
        Result<List<AgendasDTO>> GetByLivres(int IdEmpresa, string DataInicio, string HoraInicio, string DataFim, string HoraFim, long IdProcedimento, long IdMedico);
        Result<List<AgendasDTO>> GetByPaciente(int IdEmpresa, long IdPaciente);
        Result<string> RealizarAgendamento(long IdAgenda, long IdPaciente);
        Result<string> CancelarAgendamento(long IdAgenda);
    }
}
