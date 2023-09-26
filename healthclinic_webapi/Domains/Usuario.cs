using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace healthclinic_webapi.Domains
{
    [Table(nameof(Usuario))]
    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; }

        [Column(TypeName = "VARCHAR(11)")]
        [Required(ErrorMessage = "CPF obrigatorio")]
        public string? CPF { get; set; }

        [Column(TypeName = "VARCHAR(350)")]
        [Required(ErrorMessage = "Nome obrigatorio")]
        public string? Nome { get; set; }
    }
}
