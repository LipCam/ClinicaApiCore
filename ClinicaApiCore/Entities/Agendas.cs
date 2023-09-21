using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClinicaApiCore.Entities
{
    [Table("AGENDAS_TAB")]
    public class Agendas
    {
        [Key]
        public long ID_AGENDA_LONG { get; set; }
        public DateTime DATA_DTI { get; set; }

        /// <summary>
        /// <para>0-Livre</para><para>1-Agendado</para><para>2-Em atendimento</para><para>3-Atendido</para><para>4-Cancelado</para>
        /// </summary>
        public int ID_STATUS_INT { get; set; }

        public long? ID_PACIENTE_LONG { get; set; }
        [ForeignKey("ID_PACIENTE_LONG")]
        public Pacientes Pacientes { get; set; }

        public long ID_MEDICO_LONG { get; set; }
        [ForeignKey("ID_MEDICO_LONG")]
        public Medicos Medicos { get; set; }

        public long ID_PROCEDIMENTO_LONG { get; set; }
        [ForeignKey("ID_PROCEDIMENTO_LONG")]
        public Procedimentos Procedimentos { get; set; }
    }
}
