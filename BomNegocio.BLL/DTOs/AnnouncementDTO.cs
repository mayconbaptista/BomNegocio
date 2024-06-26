using BomNegocio.DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BomNegocio.API.DTOs
{
    public class AnnouncementDTO
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        public DateTime CreationDate { get; set; }
        [Required]
        public int AnuncianteId { get; set; }
        [Required]
        public int CategoriaId { get; set; }
    }
}
