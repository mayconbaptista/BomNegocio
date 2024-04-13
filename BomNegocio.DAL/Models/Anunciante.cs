using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace BomNegocio.DAL.Models
{

    public class Anunciante
    {

        [Key]
        public int Id { get; set; }
        public string Email { get; set; }

        /* EF 1..N */
        public ICollection<Anuncio>? Anuncios { get; set; } = null;
        public ICollection<Endereco>? Enderecos { get; set;}
    }
}
