using Microsoft.VisualBasic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BomNegocio.DAL.Models
{
    public class Anuncio
    {

        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        

        /* EF 1..N */
        public int AnuncianteId { get; set; }
        public Anunciante Anunciante { get; set; }
        /* EF 1..N */
        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }
        /* EF 1 .. N */
        public int EnderecoId { get; set; }
        public Endereco? Endereco { get; set; }

        /* EF 1..N */
        public ICollection<Avaliacao>? Avaliacoes { get; set; } = null;
        public ICollection<Imagem>? Imagens { get; set; } = null;
        public ICollection<Desejo>? Desejos { get; set; } = null;
    }
}
