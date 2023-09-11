using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClinicaApiCore.Entities
{
    [Table("MEDICOS_TAB")]
    public class Medicos
    {
        [Key]
        public long ID_MEDICO_LONG { get; set; }

        [MaxLength(150)]
        public string NOME_STR { get; set; }

        [MaxLength(15)]
        public string? CPF_STR { get; set; }

        [MaxLength(50)]
        public string? NUM_REGISTRO_STR { get; set; }
    }
}
