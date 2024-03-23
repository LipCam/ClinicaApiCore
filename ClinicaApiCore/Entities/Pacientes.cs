using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClinicaApiCore.Entities
{
    [Table("CAD_PACIENTES_TAB")]
    public class Pacientes
    {
        [Key]
        public long ID_PACIENTE_LONG { get; set; }

        public int ID_EMPRESA_INT { get; set; }

        [MaxLength(150)]
        public string NOME_STR { get; set; }

        [MaxLength(15)]
        public string? CPF_STR { get; set; }

        [MaxLength(20)]
        public string? CELULAR_STR { get; set; }
    }
}
