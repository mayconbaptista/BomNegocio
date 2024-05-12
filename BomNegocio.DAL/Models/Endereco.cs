using BomNegocio.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomNegocio.DAL.Models
{
    public class Endereco
    {
        public int Id { get; set; }
        public string Rua { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep {  get; set; }
        public string Numero {  get; set; }

        /* N .. 1 */
        public int? UserId { get; set; }
        public User? User { get; set; }

        public int AnuncioId { get; set; }
        public Anuncio? Anuncio { get; set; }
    }
}
