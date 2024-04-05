using System.ComponentModel.DataAnnotations;

namespace BomNegocio.API.DTOs
{
    public class LoginModelDTO
    {
        [EmailAddress(ErrorMessage = "Email inválido")]
        [Required(ErrorMessage = "O campo Email é obrigatório")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "O campo Password é obrigatório")]
        public string? Password { get; set; }

    }
}
