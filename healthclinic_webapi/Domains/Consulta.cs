using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace healthclinic_webapi.Domains
{
    [Table(nameof(Consulta))]
    public class Consulta
    {
        [Key]
        public Guid IdConsulta { get; set; }

        [Column(TypeName = "TIME")]
        [Required(ErrorMessage = "Data obrigatoria")]
        public DateTime Agendamento { get; set; }

        [Column(TypeName = "BIT")]
        [Required(ErrorMessage = "A consulta esta confirmada?")]
        public bool Status { get; set; }

        //Foreign key

        [Required(ErrorMessage = "IdEndereco obrigatorio")]
        public Guid IdEndereco { get; set; }

        [Required(ErrorMessage = "IdMedico obrigatorio")]
        public Guid IdMedico { get; set; }

        [Required(ErrorMessage = "IdPaciente obrigatorio")]
        public Guid IdPaciente { get; set; }

        [Required(ErrorMessage = "IdFeedback obrigatorio")]
        public Guid IdFeedback { get; set; }


        [ForeignKey(nameof(IdEndereco))]
        public Endereco Endereco { get; set; }

        [ForeignKey(nameof(IdMedico))]
        public Medico Medico { get; set; }

        [ForeignKey(nameof(IdPaciente))]
        public Paciente Paciente { get; set; }

        [ForeignKey(nameof(IdFeedback))]
        public Feedback? Feedback { get; set; }
    }
}
