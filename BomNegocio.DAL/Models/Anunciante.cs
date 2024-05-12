using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace BomNegocio.DAL.Models
{

    public class Anunciante
    {
        public int Id { get; set; }

        /* 1 .. 1*/
        public int UserId { get; set; }
        public User? User { get; set; }

        /* EF 1..N */
        public ICollection<Anuncio>? Anuncios { get; set; }
        public ICollection<Endereco>? Enderecos { get; set;}
    }
}
