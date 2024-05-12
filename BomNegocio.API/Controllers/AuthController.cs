using BomNegocio.API.DTOs;
using BomNegocio.BLL.Services;
using BomNegocio.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BomNegocio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthController> _logger;

        public AuthController(ITokenService tokenService, 
                            UserManager<ApplicationUser> userManager, 
                            RoleManager<IdentityRole> roleManager, 
                            IConfiguration configuration,
                            ILogger<AuthController> logger)
        {
            _tokenService = tokenService;
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _logger = logger;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login ([FromBody] LoginDTO loginModel)
        {
            var user = await _userManager.FindByEmailAsync(loginModel.Email!);

            if (user is not null && await _userManager.CheckPasswordAsync(user, loginModel.Password!))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName!),
                    new Claim(ClaimTypes.Email, user.Email!),
                    new Claim("id", user.UserName!),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var token = _tokenService.GenerateAccessToken(authClaims,
                                                             _configuration);

                var refreshToken = _tokenService.GenerateRefreshToken();

                _ = int.TryParse(_configuration["JWT:RefreshTokenValidityInMinutes"],
                                   out int refreshTokenValidityInMinutes);

                user.RefreshTokenExpiryTime =
                                DateTime.Now.AddMinutes(refreshTokenValidityInMinutes);

                user.RefreshToken = refreshToken;

                await _userManager.UpdateAsync(user);

                return Ok(new
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    RefreshToken = refreshToken,
                    Expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }

        [HttpPost]
        [Route("registrar")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO modelDTO)
        {
            var userExists = await _userManager.FindByEmailAsync(modelDTO.Email!);

            if (userExists != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                       new Response { Status = "Error", Message = "User already exists!" });
            }

            ApplicationUser user = new()
            {
                Email = modelDTO.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = modelDTO.UserName
            };

            var result = await _userManager.CreateAsync(user, modelDTO.Password!);

            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                       new Response { Status = "Error", Message = $"Falha ao criar usuário {modelDTO.UserName}" });
            }

            return StatusCode(StatusCodes.Status201Created, new Response { Status = "ok", Message = "Usuário criado com sucesso!" });
        }

        [HttpPost]
        [Route("refresh-token")]
        public async Task<IActionResult> RefreshToken (TokenModelDTO modelDTO)
        {
            if(modelDTO is null)
            {
                return BadRequest("Invalid client request");
            }

            string? acessToken = modelDTO.AcessToken ?? throw new ArgumentNullException(nameof(modelDTO));

            string? refreshToken = modelDTO.RefreshToken ?? throw new ArgumentNullException(nameof(modelDTO));

            ClaimsPrincipal principal = _tokenService.GetPrincipalFromExpiredToken(acessToken!, this._configuration);

            if(principal is null)  
            {
                return BadRequest("Acesso inválido token/refresh token");
            }

            string email = principal.Claims.FirstOrDefault(a => a.Type == ClaimTypes.Email)?.Value!;

            // Supondo que userMgr seja um UserManager<ApplicationUser>
            var user1 = await _userManager.GetUserAsync(principal);
            var email2 = user1!.Email!;


            string userName = principal.Identity!.Name!;

            var user = await _userManager.FindByEmailAsync(email);

            if (user is null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
            {
                return BadRequest("Acesso inválido token/refresh token");
            }

            var newAcessToken = _tokenService.GenerateAccessToken(principal.Claims.ToList(), _configuration);

            var newRefreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;

            await _userManager.UpdateAsync(user);

            return new ObjectResult(new
            {
                acessToken = new JwtSecurityTokenHandler().WriteToken(newAcessToken),
                refreshToken = newRefreshToken
            });
        }

        [HttpPost]
        [Route("revoke/{email:minlength(5)}")]
        [Authorize(Policy = "ExclusiveOnly")]
        public async Task<IActionResult> Revoke (string email)
        {
            var user = await _userManager.FindByIdAsync(email);

            if(user is null)
            {
                return BadRequest("Usuário invalido!");
            }

            user.RefreshToken = null;

            await _userManager.UpdateAsync(user);

            return NoContent();
        }

        [HttpPost]
        [Route("createRole")]
        [Authorize(Policy = "ExclusiveOnly")]
        public async Task<IActionResult> CreateRole ([FromQuery] string roleName)
        {
            var roleExist = await _roleManager.RoleExistsAsync(roleName);

            if(!roleExist)
            {

                var roleResult = await _roleManager.CreateAsync(new IdentityRole(roleName));

                if(roleResult.Succeeded)
                {
                    _logger.LogInformation(1, "Roles adicionada");
                    return StatusCode(StatusCodes.Status200OK, new Response {Status = "Ok", Message = $"Role {roleName} criada com sucesso."});
                }
                else
                {
                    _logger.LogInformation(2, "Error");
                    return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Error", Message = "Problema ao adicionar nova role" });
                }
            }

            return StatusCode(StatusCodes.Status400BadRequest , new Response { Status = "Error", Message = $"A role {roleName} já existe" });
        }

        [HttpPost]
        [Route("addUserRole")]
        [Authorize(Policy = "ExclusiveOnly")]
        public async Task<IActionResult> AddUserRoleAsync (string email,string roleName)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if(user != null)
            {
                var result = await _userManager.AddToRoleAsync(user, roleName);

                if(result.Succeeded)
                {
                    _logger.LogInformation(1, $"Usuário {user} adicionado a role {roleName}");
                    return StatusCode(StatusCodes.Status200OK, new Response { Status = "Ok", Message = $"Usuário {user} adicionado a role {roleName} com sucesso!" });
                }
                else
                {
                    _logger.LogInformation (2, $"Error: erro ao adicionar o usuário {user} a role {roleName}");
                    return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Error", Message = $"Erro ao adicionar o usuário {user} a role {roleName}" });
                }
            }

            return BadRequest(new Response { Status = "Error", Message = $"Usuário {email} não encontrado" });
        }
    }
}
