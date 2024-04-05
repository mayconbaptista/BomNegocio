using BomNegocio.DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BomNegocio.API.DTOs
{
    public class AnuncioDTO
    {
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public decimal Preco { get; set; }
        public DateTime DataHora { get; set; }
        [Required]
        public string Cep { get; set; }
        [Required]
        public string Bairro { get; set; }
        [Required]
        public string Cidade { get; set; }
        [Required]
        public string Estado { get; set; }
        [Required]
        public int AnuncianteId { get; set; }
        [Required]
        public int CategoriaId { get; set; }
    }
}
