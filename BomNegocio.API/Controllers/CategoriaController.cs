using AutoMapper;
using BomNegocio.API.DTOs;
using BomNegocio.BLL.Services;
using BomNegocio.DAL.Models;
using BomNegocio.DAL.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BomNegocio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;
        private readonly ILogger<CategoriaController> _logger;
        private readonly IMapper _mapper;

        public CategoriaController (ICategoriaService categoriaService, ILogger<CategoriaController> logger, IMapper mapper)
        {
            _categoriaService = categoriaService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost("cadastrar")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<ActionResult<CategoriaDTO>> Create (CategoriaDTO categoriaDTO)
        {
            throw new NotImplementedException();
        }

        [HttpGet("obter")]
        public async Task<ActionResult<CategoriaDTO>> GetAllAsync ()
        {
            var categorias = await _categoriaService.GetCategorias();

            var categoriasDTO = _mapper.Map<IEnumerable<CategoriaDTO>>(categorias);

            return Ok(categoriasDTO);
        }

        [HttpDelete("deletar")]
        [Authorize(Policy = "SuperAdminOnly")]
        public async Task<IActionResult> Delete (int id)
        {
            throw new NotImplementedException ();
        }
    }
}
