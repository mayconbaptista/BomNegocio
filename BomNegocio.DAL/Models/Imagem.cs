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
        [Key]
        public int Id { get; set; }
        [Required]
        public string Path { get; set; }

        public int AnuncioId;
        public Anuncio? Anuncio { get; set; }
    }
}
