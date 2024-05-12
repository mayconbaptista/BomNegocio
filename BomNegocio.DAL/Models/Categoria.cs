using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace BomNegocio.DAL.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string? Descricao { get; set; }
        public string? IconName { get; set; }

        /* EF 1..N */
        public ICollection<Anuncio>? Anuncios { get; set; }

        public int? CategoriaPaiId { get; set; }
        public Categoria? CategoriaPai { get; set; }
        public ICollection<Categoria>? SubCategorias { get; set; }
    }
}
