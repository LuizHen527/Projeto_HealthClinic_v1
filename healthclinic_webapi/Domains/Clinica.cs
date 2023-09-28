using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace healthclinic_webapi.Domains
{
    [Table(nameof(Clinica))]
    public class Clinica
    {
        [Key]

        public Guid IdClinica { get; set; }

        [Column(TypeName = "TIME")]
        [Required(ErrorMessage = "Horario de funcionamento obrigatorio")]
        public TimeOnly AbertoEm { get; set; }

        [Column(TypeName = "TIME")]
        [Required(ErrorMessage = "Horario de funcionamento obrigatorio")]
        public TimeOnly FechaEm { get; set; }

        [Column(TypeName = "VARCHAR(175)")]
        [Required(ErrorMessage = "Nome fantasia obrigatorio")]
        public string? NomeFantasia { get; set; }

        [Column(TypeName = "VARCHAR(14)")]
        [Required(ErrorMessage = "CNPJ obrigatorio")]
        public string? CNPJ { get; set; }

        [Column(TypeName = "VARCHAR(175)")]
        [Required(ErrorMessage = "Razao social obrigatorio")]
        public string? RazaoSocial { get; set; }
    }
}
