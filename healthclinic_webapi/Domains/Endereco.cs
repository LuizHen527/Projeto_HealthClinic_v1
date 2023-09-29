using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace healthclinic_webapi.Domains
{
    [Table(nameof(Endereco))]
    public class Endereco
    {
        [Key]
        public Guid IdEndereco { get; set; }

        [Column(TypeName = "VARCHAR(300)")]
        [Required(ErrorMessage = "Endereco obrigatorio")]
        public string? Localidade { get; set; }

        //Foreign key

        [Required(ErrorMessage = "Id Clinica obrigatorio")]
        public Guid IdClinica { get; set; }

        [ForeignKey(nameof(IdClinica))]
        public Clinica? Clinica { get; set; }
    }
}
