namespace ClinicaApiCore.DTOs.Procedimentos
{
    public class EditProcedimentoRequestDTO
    {
        public long IdProcedimento { get; set; }
        public string? Descricao { get; set; }
        public decimal? Valor { get; set; }
    }
}
