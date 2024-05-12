using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomNegocio.DAL.Models
{
    public class User
    {
        public int Id { get; set; }

        /* 1..1 */
        public Anunciante? Anunciante { get; set; }
        public Cliente? Cliente { get; set; }
        public Anuncio? Anuncio { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }

        /* 1..N */
        public ICollection<Endereco>? Enderecos { get; set; }
        public ICollection<Imagem>? Imagens { get; set; }
    }
}
