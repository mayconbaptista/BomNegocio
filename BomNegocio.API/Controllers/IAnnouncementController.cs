using AutoMapper;
using BomNegocio.API.DTOs;
using BomNegocio.DAL.Models;
using BomNegocio.DAL.Pagination;
using BomNegocio.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using X.PagedList;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json.Linq;
using System.Security.Claims;
using System.Linq;
using BomNegocio.Application.Services.Interface;

namespace BomNegocio.API.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class AnuncioController : ControllerBase
    {
        private readonly IAnuncioService _anuncioService;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AnuncioController> _logger;
        private readonly IMapper _mapper;

        public AnuncioController (IAnuncioService anuncioService, ILogger<AnuncioController> logger, IMapper mapper, ITokenService tokenService, IConfiguration configuration)
        {
            _anuncioService = anuncioService;
            _logger = logger;
            _mapper = mapper;
            _tokenService = tokenService;
            _configuration = configuration;
        }

        [HttpPost]
        [Authorize(Policy = "AnuncianteOnly")]
        public async Task<ActionResult<AnnouncementDTO>> create([FromBody] AnnouncementDTO newAnuncio)
        {
            string token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            ClaimsPrincipal principal = _tokenService.GetPrincipalFromExpiredToken(token, _configuration);

            string email = principal.Claims.FirstOrDefault(a => a.Type == ClaimTypes.Email)?.Value!;

            var anuncio = await _anuncioService.CreateAsync(_mapper.Map<Anuncio>(newAnuncio));

            return StatusCode(StatusCodes.Status201Created, _mapper.Map<AnnouncementDTO>(anuncio));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnnouncementDTO>>> Paginacao ([FromQuery] AnuncioFilterParameters anunciosParams)
        {
            var anuncios = await _anuncioService.GetAllAsync (anunciosParams);

            var metadata = new
            {
                anuncios.Count,
                anuncios.PageCount,
                anuncios.PageSize,
                anuncios.TotalItemCount,
                anuncios.HasNextPage,
                anuncios.HasPreviousPage
            };

            Response.Headers.Append("X-Pagination", JsonConvert.SerializeObject(metadata));

            var anunciosDTO = _mapper.Map<IEnumerable<AnnouncementDTO>>(anuncios);

            return Ok(anunciosDTO);
        }


        [HttpGet("{Id:int:min(1)}")]
        public async Task<ActionResult<AnnouncementDTO>> getByAnuncianteId([FromRoute] int Id)
        {
            var anuncio = await _anuncioService.GetAsync(Id);

            return Ok(_mapper.Map<AnnouncementDTO>(anuncio));
        }

        [HttpPut]
        [Authorize(Policy = "AnuncianteOnly")]
        public async Task<ActionResult<AnnouncementDTO>> update (AnnouncementDTO newAnuncio)
        {
            string token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            ClaimsPrincipal principal = _tokenService.GetPrincipalFromExpiredToken(token, _configuration);

            string email = principal.Claims.FirstOrDefault(a => a.Type == ClaimTypes.Email)?.Value!;

            var anuncio = await _anuncioService.UpdateAsync(_mapper.Map<Anuncio>(newAnuncio));

            return Ok(_mapper.Map<AnnouncementDTO>(anuncio));
        }

        [HttpDelete("{id:int:min(1)}")]
        [Authorize(Policy = "AdminOnly")]
        [Authorize(Policy = "AnuncianteOnly")]
        public async Task<ActionResult> Delete([FromRoute] int id) 
        {
            string token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            ClaimsPrincipal principal = _tokenService.GetPrincipalFromExpiredToken(token, _configuration);

            _ = await _anuncioService.DeleteAsync(id);

            return NoContent();
        }

    }
}
