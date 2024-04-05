using BomNegocio.DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace BomNegocio.API.DTOs
{
    public class InteresseDTO
    {
        public int Id { get; set; }
        [Required] public string Mensagem { get; set; }
        public DateTime? DataHora { get; set; }
        [Required] public string contato { get; set; }
        [Required] public int AnuncioId { get; set; }
    }
}
