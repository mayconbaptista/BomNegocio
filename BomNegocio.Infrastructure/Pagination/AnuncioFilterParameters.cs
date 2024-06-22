
namespace BomNegocio.Infrastructure.Pagination
{
    public class AnuncioFilterParameters : QueryStringParameters
    {
        public decimal? PrecoMin { get; set; }
        public decimal? PrecoMax { get; set; } 
        public int? CategoriaId { get; set; }
        public int? AnuncianteId { get; set; }
    }
}
