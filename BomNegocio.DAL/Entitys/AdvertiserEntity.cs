namespace BomNegocio.Domain.Entitys
{

    public class AdvertiserEntity : BaseEntity
    {
        /* 1 .. 1*/
        public int UserId { get; set; }
        public UserEntity? User { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime DeactivationDate { get; set; }

        /* EF 1..N */
        public ICollection<AnnouncementEntity>? Announcements { get; set; }
        public ICollection<AddressEntity>? Enderecos { get; set; }
    }
}
