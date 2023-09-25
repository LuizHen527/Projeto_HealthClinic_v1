using System.ComponentModel.DataAnnotations;

namespace healthclinic_webapi.Domains
{
    public class Clinica
    {
        [Key]

        public Guid IdClinica { get; set; } = Guid.NewGuid();


    }
}
