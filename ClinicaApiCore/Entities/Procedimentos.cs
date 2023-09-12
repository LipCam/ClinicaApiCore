using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClinicaApiCore.Entities
{
    [Table("PROCEDIMENTOS_TAB")]
    public class Procedimentos
    {
        [Key]
        public long ID_PROCEDIMENTO_LONG { get; set; }

        [MaxLength(150)]
        public string DESCRICAO_STR { get; set; }
                
        public decimal? VALOR_DEC { get; set; }
    }
}
