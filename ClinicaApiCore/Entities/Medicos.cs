using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClinicaApiCore.Entities
{
    [Table("CAD_USUARIOS_TAB")]
    public class Medicos
    {
        [Key]
        public long ID_USUARIO_LONG { get; set; }

        public int ID_EMPRESA_INT { get; set; }

        [MaxLength(150)]
        public string NOME_STR { get; set; }

        [MaxLength(15)]
        public string? CPF_STR { get; set; }

        [MaxLength(50)]
        public string? NUM_REGISTRO_STR { get; set; }

        public bool PROFISSIONAL_BIT { get; set; }
        public bool ATIVO_BIT { get; set; }
        public bool MASTER_ATD_BIT { get; set; }
        public bool VER_TODAS_CONSULTAS_BIT { get; set; }
        public int ID_VINCULO_COL_INT { get; set; }
    }
}
