using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaApiCore.Entities
{
    [Table("SIS_STATUS_AGENDA_TAB")]
    public class StatusAgenda
    {
        [Key]
        public int ID_STATUS_INT { get; set; }
        public string DESCRICAO_STR  { get; set; }
    }
}
