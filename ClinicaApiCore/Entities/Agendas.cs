using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClinicaApiCore.Entities
{
    [Table("ATE_AGENDAS_TAB")]
    public class Agendas
    {
        [Key]
        public long ID_AGENDA_LONG { get; set; }
        public int ID_EMPRESA_INT { get; set; }
        public DateTime DATA_AGENDA_INICIO_DTI { get; set; }

        /// <summary>
        /// <para>0-Livre</para><para>1-Agendado</para><para>2-Em atendimento</para><para>3-Atendido</para>
        /// </summary>
        public int ID_STATUS_INT { get; set; }
        [ForeignKey("ID_STATUS_INT")]
        public StatusAgenda StatusAgd { get; set; }

        public long? ID_PACIENTE_LONG { get; set; }
        [ForeignKey("ID_PACIENTE_LONG")]
        public Pacientes Pacientes { get; set; }

        public long ID_EXECUTANTE_LONG { get; set; }
        [ForeignKey("ID_EXECUTANTE_LONG")]
        public Medicos Medicos { get; set; }

        public long ID_PROCEDIMENTO_LONG { get; set; }
        [ForeignKey("ID_PROCEDIMENTO_LONG")]
        public Procedimentos Procedimentos { get; set; }
        public DateTime? DATA_AGENDAMENTO_DTI { get; set; }
    }
}
