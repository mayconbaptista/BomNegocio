using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomNegocio.DAL.Models.Exceptions
{
    public class InternServerErrorException : Exception
    {
        public InternServerErrorException(string message) : base(message) { }
    }
}
