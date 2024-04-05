using System.ComponentModel.DataAnnotations;

namespace BomNegocio.API.DTOs
{
    public class RegisterModelDTO
    {
        [Required(ErrorMessage = "o campo UserName é obrigatório")]
        public string? UserName { get; set; }
        [EmailAddress(ErrorMessage = "Email inválido")]
        [Required]
        public string? Email { get; set;}
        [Required(ErrorMessage = "O campo Password é obrigatório")]
        public string? Password { get; set;}
    }
}
