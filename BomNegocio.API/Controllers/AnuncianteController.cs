using AutoMapper;
using BomNegocio.API.DTOs;
using BomNegocio.API.Filters;
using BomNegocio.DAL.Models;
using BomNegocio.DAL.Pagination;
using BomNegocio.DAL.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using X.PagedList;

namespace BomNegocio.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnuncianteController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger <AnuncianteController> _logger;
        private readonly IMapper _mapper; 
        public AnuncianteController(IUnitOfWork unitOfWork, 
                                    ILogger<AnuncianteController> logger, 
                                    IMapper mapper) 
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }


        [HttpGet("obter/{id:int:min(1)}")]
        public async Task<ActionResult<AnuncianteDTO>> getByIdAsync(int id)
        {
            _logger.LogInformation("log information");

            var anunciante = await _unitOfWork.AnuncianteRepository.GetAsync(a => a.Id == id);

            if(anunciante == null)
            {
                return BadRequest();
            }

            return StatusCode(StatusCodes.Status201Created, _mapper.Map<AnuncianteDTO>(anunciante));
        }

        [HttpGet("obter/paginacao")]
        [ServiceFilter(typeof(ApiLoggingFilter))]
        public async Task<ActionResult<IEnumerable<AnuncianteDTO>>> GetAll ([FromQuery] AnuncianteFilterParameters parameters)
        {
            var anunciantes = await  _unitOfWork.AnuncianteRepository.GetAnunciantesAsync (parameters);

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

            var anunciantesDTO = _mapper.Map<AnuncianteDTO>(anunciantes);

            return Ok(anunciantesDTO);
        }


        [HttpPost("cadastrar")]
        [Authorize(Policy = "AnuncianteOnly")]
        public async Task<ActionResult<AnuncianteDTO>> create (AnuncianteDTO newAnunciante)
        {

            var anunciante = _unitOfWork.AnuncianteRepository.Create(_mapper.Map<Anunciante>(newAnunciante));
            await _unitOfWork.CommitAsync();

            if(anunciante is null)
            {
                return Conflict(newAnunciante);
            }

            return Ok(_mapper.Map<AnuncianteDTO>(anunciante));
        }

        [HttpPut("atualizar")]
        [Authorize(Policy = "AnuncianteOnly")]
        public async  Task<ActionResult<AnuncianteDTO>> update (AnuncianteDTO newAnunciante)
        {
            var anunciante = _unitOfWork.AnuncianteRepository.Update(_mapper.Map<Anunciante>(newAnunciante));
            await _unitOfWork.CommitAsync();

            if(anunciante is null)
            {
                return NotFound(newAnunciante);
            }

            return Ok(_mapper.Map<AnuncianteDTO>(anunciante));
        }


        [HttpDelete("deletar/{id:int:min(1)}")]
        [Authorize(Policy = "AnuncianteOnly")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> Delete(int  id)
        {
            var anunciante = await _unitOfWork.AnuncianteRepository.GetAsync (a => a.Id == id);

            if(anunciante is null)
            {
                return NotFound();
            }

            _unitOfWork.AnuncianteRepository.Delete(anunciante);
            await _unitOfWork.CommitAsync();

            return Ok();
        }
    }
}
