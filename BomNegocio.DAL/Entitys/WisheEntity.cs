
namespace BomNegocio.Domain.Entitys
{
    public class WisheEntity : BaseEntity
    {
        public DateTime CreationDate { get; set; }
        /* 1..N */
        public int ClientId { get; set; }
        public ClientEntity? Client { get; set; }
        public int AnnouncementId { get; set; }
        public AnnouncementEntity? Announcement { get; set; }
    }
}
