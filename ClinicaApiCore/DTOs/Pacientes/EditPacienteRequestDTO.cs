namespace ClinicaApiCore.DTOs.Pacientes
{
    public class EditPacienteRequestDTO
    {
        public long IdPaciente { get; set; }
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public string? Celular { get; set; }
    }
}
