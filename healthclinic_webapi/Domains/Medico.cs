using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace healthclinic_webapi.Domains
{
    [Table(nameof(Medico))]
    public class Medico
    {
        [Key]
        public Guid IdMedico { get; set; }

        [Column(TypeName = "VARCHAR(350)")]
        public string? Nome { get; set; }

        //Foreign key

        [Required(ErrorMessage = "IdPerfil obrigatorio")]
        public Guid IdPerfil { get; set; }

        [Required(ErrorMessage = "IdEspecialidade obrigatorio")]
        public Guid IdEspecialidade { get; set; }


        [ForeignKey(nameof(IdEspecialidade))]
        public Especialidade? Especialidade { get; set; }

        [ForeignKey(nameof(IdPerfil))]
        public Perfil? Perfil { get; set; }
    }
}
