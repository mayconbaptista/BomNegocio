using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomNegocio.DAL.Pagination
{
    public class AnuncioFilterParameters : QueryStringParameters
    {
        public decimal? PrecoMin { get; set; }
        public decimal? PrecoMax { get; set; } 
        public int? CategoriaId { get; set; }
        public int? AnuncianteId { get; set; }
    }
}
