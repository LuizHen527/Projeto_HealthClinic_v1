using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace healthclinic_webapi.Domains
{
    [Table(nameof(Paciente))]
    public class Paciente
    {
        [Key]
        public Guid IdPaciente { get; set; }

        [Column(TypeName = "BIT")]
        [Required(ErrorMessage = "Preencha o campo convenio")]
        public bool Convenio { get; set; }

        //Foreign key

        [Required(ErrorMessage = "IdProntuario obrigatoria")]
        public Guid IdProntuario { get; set; }

        [Required(ErrorMessage = "IdPerfil obrigatoria")]
        public Guid IdPerfil { get; set; }

        [ForeignKey(nameof(IdPerfil))]
        public Perfil Perfil { get; set; }

        [ForeignKey(nameof(IdProntuario))]
        public Prontuario? Prontuario { get; set; }
    }
}
