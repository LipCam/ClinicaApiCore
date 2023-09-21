using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClinicaApiCore.Entities
{
    public class AgendasVW
    {
        [Key]
        public long ID_AGENDA_LONG { get; set; }
        public DateTime DATA_DTI { get; set; }

        /// <summary>
        /// <para>0-Livre</para><para>1-Agendado</para><para>2-Em atendimento</para><para>3-Atendido</para><para>4-Cancelado</para>
        /// </summary>
        public int ID_STATUS_INT { get; set; }
        public long ID_MEDICO_LONG { get; set; }
        public string MEDICO_STR { get; set; }
        public long ID_PROCEDIMENTO_LONG { get; set; }
        public string PROCEDIMENTO_STR { get; set; }
    }
}
