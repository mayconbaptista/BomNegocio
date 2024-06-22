
namespace BomNegocio.Domain.Entitys.Exceptions
{
    public class InternServerErrorException : Exception
    {
        public InternServerErrorException(string message) : base(message) { }
    }
}
