using AutoMapper;
using BomNegocio.API.DTOs;
using BomNegocio.API.Filters;
using BomNegocio.Application.Services.Interface;
using BomNegocio.DAL.Models;
using BomNegocio.DAL.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using X.PagedList;

namespace BomNegocio.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class AdvertiserController : ControllerBase
    {
        private readonly IAdvertiserService _anuncianteService;
        private readonly ILogger <AdvertiserController> _logger;
        private readonly IMapper _mapper;
        public AdvertiserController(IAdvertiserService anuncianteService, 
                                    ILogger<AdvertiserController> logger, 
                                    IMapper mapper) 
        {
            _anuncianteService = anuncianteService;
            _logger = logger;
            _mapper = mapper;
        }


        [HttpGet("{id:int:min(1)}")]
        public async Task<ActionResult<UserDTO>> getByIdAsync([FromRoute] int id)
        {
            _logger.LogInformation("log information");
            
            var anunciante = await this._anuncianteService.GetByIdAsync(id);

            return StatusCode(StatusCodes.Status201Created, _mapper.Map<UserDTO>(anunciante));
        }

        [HttpGet]
        [ServiceFilter(typeof(ApiLoggingFilter))]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAll ([FromQuery] AnuncianteFilterParameters parameters)
        {
            var anunciantes = await _anuncianteService.GetAllAsync(parameters);

            var metadata = new
            {
                anunciantes.Count,
                anunciantes.PageCount,
                anunciantes.PageSize,
                anunciantes.TotalItemCount,
                anunciantes.HasNextPage,
                anunciantes.HasPreviousPage
            };

            Response.Headers.Append("X-Pagination", JsonConvert.SerializeObject(metadata));

            var anunciantesDTO = _mapper.Map<UserDTO>(anunciantes);

            return Ok(anunciantesDTO);
        }


        [HttpPost]
        [Authorize(Policy = "AnuncianteOnly")]
        public async Task<ActionResult<UserDTO>> create ([FromBody] UserDTO newAnunciante)
        {

            var anunciante = _anuncianteService.CreateAsync(_mapper.Map<AdvertiserEntity>(newAnunciante));

            if(anunciante is null)
            {
                return Conflict(newAnunciante);
            }

            return Ok(_mapper.Map<UserDTO>(anunciante));
        }

        [HttpPut]
        [Authorize(Policy = "AnuncianteOnly")]
        public async  Task<ActionResult<UserDTO>> update ([FromBody] UserDTO newAnunciante)
        {
            var anunciante = _anuncianteService.UpdateAsync(_mapper.Map<AdvertiserEntity>(newAnunciante));

            if(anunciante is null)
            {
                return NotFound(newAnunciante);
            }

            return Ok(_mapper.Map<UserDTO>(anunciante));
        }


        [HttpDelete("{id:int:min(1)}")]
        [Authorize(Policy = "AnuncianteOnly")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> Delete([FromRoute] int  id)
        {
            var anunciante = await _anuncianteService.DeleteAsync(id);

            if(anunciante is null)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
