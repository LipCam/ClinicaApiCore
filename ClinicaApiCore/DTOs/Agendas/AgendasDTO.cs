namespace ClinicaApiCore.DTOs.Agendas
{
    public class AgendasDTO
    {
        public long IdAgenda { get; set; }
        public DateTime Data { get; set; }
        public int IdStatus { get; set; }
        public string Status { get; set; }
        public long IdMedico { get; set; }
        public string Medico { get; set; }
        public long IdProcedimento { get; set; }
        public string Precedimento { get; set; }
    }
}
