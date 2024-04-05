using System.ComponentModel.DataAnnotations;

namespace BomNegocio.DAL.Models
{
    public class Avaliacao
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Nota { get; set; }
        [Required]
        [MaxLength(500)]
        public string Comentario { get; set; }
        public DateTime DataHora { get; set; } = DateTime.Now;

        /* EF N..1 */ 
        public int AnuncioId { get; set; }
        public Anuncio? Anuncio { get; set; }
    }
}
