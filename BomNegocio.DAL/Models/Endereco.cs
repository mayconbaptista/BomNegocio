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
        [Key]
        public int Id { get; set; }
        [Required]
        public string Rua { get; set; }
        public string Complemento { get; set; }
        [Required]
        public string Bairro { get; set; }
        [Required]
        public string Cidade { get; set; }
        [Required]
        public string Estado { get; set; }
        [Required]
        public string Cep {  get; set; }
        [Required]
        public string Numero {  get; set; }

        /* N .. 1 */
        public int ApplicationUserId { get; set; }
        public ApplicationUser? applicationUserId;
    }
}
