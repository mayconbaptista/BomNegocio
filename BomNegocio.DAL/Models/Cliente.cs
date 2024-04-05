using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomNegocio.DAL.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        /* 1 .. 1 */
        public int ApplicationUserId;
        public ApplicationUser? ApplicationUser;
    }
}
