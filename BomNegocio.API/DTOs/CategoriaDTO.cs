using BomNegocio.DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace BomNegocio.API.DTOs
{
    public class CategoriaDTO
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Descricao { get; set; }
    }
}
