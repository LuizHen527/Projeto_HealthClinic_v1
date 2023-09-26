using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace healthclinic_webapi.Domains
{
    [Table(nameof(Especialidade))]
    public class Especialidade
    {
        [Key]
        public Guid IdEspecialidade { get; set; }

        [Column(TypeName = "VARCHAR (300)")]
        [Required(ErrorMessage = "Especialidade obrigatoria")]
        public string EspecialidadeNome { get; set; }
    }
}
