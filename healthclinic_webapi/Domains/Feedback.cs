using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace healthclinic_webapi.Domains
{
    [Table(nameof(Feedback))]
    public class Feedback
    {
        [Key]
        public Guid IdFeedback { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "Insira seu comentario")]
        public string? Comentario { get; set; }

        //Foreign key

        [Required(ErrorMessage = "IdPaciente obrigatorio")]
        public Guid IdPaciente { get; set; }

        [ForeignKey(nameof(IdPaciente))]
        public Paciente? Paciente { get; set; }
    }
}
