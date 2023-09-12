namespace ClinicaApiCore.DTOs.Medicos
{
    public class EditMedicoRequestDTO
    {
        public long IdMedico { get; set; }
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public string? NumRegistro { get; set; }
    }
}
