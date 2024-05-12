using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomNegocio.DAL.Models
{
    public class Imagem
    {
        public int Id { get; set; }
        public byte[] Img { get; set; }

        /* 1..n */
        public int AnuncioId;
        public Anuncio? Anuncio { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
