using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace healthclinic_webapi.Domains
{
    [Table(nameof(Prontuario))]
    public class Prontuario
    {
        [Key]
        public Guid IdProntuario { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "Descricao obrigatoria")]
        public string? Descricao { get; set; }
    }
}
