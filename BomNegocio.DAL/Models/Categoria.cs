using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace BomNegocio.DAL.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(60, ErrorMessage = "O campo nome deve ter até {1} caracteres.")]
        public string Nome { get; set; }
        [Required]
        [StringLength(500, ErrorMessage = "O campo descrição deve ter até {1} caracteres.")]
        public string Descricao { get; set; }

        /* EF 1..N */
        public ICollection<Anuncio>? Anuncios { get; set; } = new Collection<Anuncio>();
    }
}
