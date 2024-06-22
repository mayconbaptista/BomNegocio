using BomNegocio.DAL.Enums;
using System;

namespace BomNegocio.Domain.Entitys
{
    public class AddressEntity : BaseEntity
    {
        public string Road { get; set; }
        public string Complement { get; set; }
        public string neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode {  get; set; }
        public string Number {  get; set; }

        /* N .. 1 */
        public int UserId { get; set; }
        public virtual UserEntity User { get; set; }

        /* 1..1 */
        public int AnnouncementId { get; set; }
        public virtual AnnouncementEntity Announcement { get; set; }
    }
}
