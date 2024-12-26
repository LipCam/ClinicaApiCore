using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClinicaApiCore.Entities
{
    [Table("CAD_PROCEDIMENTOS_TAB")]
    public class Procedimentos
    {
        [Key]
        public long ID_PROCEDIMENTO_LONG { get; set; }

        public int ID_EMPRESA_INT { get; set; }

        public string COD_TUSS_INTER_STR { get; set; }        

        [MaxLength(150)]
        public string DESCRICAO_STR { get; set; }
                
        public decimal? VALOR_DEC { get; set; }
    }
}
