using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;

namespace BomNegocio.BLL.Services
{
    public interface ITokenService
    {
        JwtSecurityToken GenerateAccessToken (IEnumerable<Claim> claims, IConfiguration configuration);

        string GenerateRefreshToken();

        ClaimsPrincipal GetPrincipalFromExpiredToken(string token, IConfiguration configuration);
    }
}
