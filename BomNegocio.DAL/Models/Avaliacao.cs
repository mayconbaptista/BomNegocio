using System.ComponentModel.DataAnnotations;

namespace BomNegocio.DAL.Models
{
    public class Avaliacao
    {
        public int Id { get; set; }
        public int Nota { get; set; }
        public string Comentario { get; set; }
        public DateTime DataHora { get; set; } = DateTime.Now;

        /* EF N..1 */ 
        public int AnuncioId { get; set; }
        public Anuncio? Anuncio { get; set; }

        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
    }
}
