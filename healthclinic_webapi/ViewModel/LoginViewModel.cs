using System.ComponentModel.DataAnnotations;

namespace healthclinic_webapi.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email obrigatoria")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha obrigatoria")]
        public string Senha { get; set; }
    }
}
