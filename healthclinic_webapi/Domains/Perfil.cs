using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace healthclinic_webapi.Domains
{
    [Table(nameof(Perfil))]
    public class Perfil
    {
        [Key]
        public Guid IdPerfil { get; set; }

        [Column(TypeName = "VARCHAR(350)")]
        [Required(ErrorMessage = "Email obrigatorio")]
        public string? Email { get; set; }

        [Column(TypeName = "VARCHAR(350)")]
        [Required(ErrorMessage = "Senha obrigatoria")]
        [StringLength(200, MinimumLength = 6, ErrorMessage = "Senha entre 6 e 60 digitos")]
        public string? Senha { get; set; }

        //Foreign key

        [Required(ErrorMessage = "IdUsuario obrigatorio")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }

        [Required(ErrorMessage = "IdTiposUsuario obrigatorio")]
        public Guid IdTiposUsuario { get; set; }

        [ForeignKey(nameof(IdTiposUsuario))]
        public TiposUsuario? TiposUsuario { get; set; }
    }
}
