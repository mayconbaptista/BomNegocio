using Microsoft.AspNetCore.Identity;

namespace BomNegocio.Domain.Entitys
{
    public class ApplicationUser : IdentityUser
    {
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
