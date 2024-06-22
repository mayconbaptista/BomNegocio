using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomNegocio.Domain.Entitys
{
    public class UserEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }

        /* 1..1 */
        public AdvertiserEntity? Advertiser { get; set; }
        public ClientEntity? Client { get; set; }
        public AnnouncementEntity? Announcement { get; set; }

        /* 1..N */
        public ICollection<AddressEntity>? Addresses { get; set; }
        public ICollection<ImageEntity>? Images { get; set; }
    }
}
