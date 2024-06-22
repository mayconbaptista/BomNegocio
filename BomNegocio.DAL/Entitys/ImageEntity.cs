
namespace BomNegocio.Domain.Entitys
{
    public class ImageEntity : BaseEntity
    {
        public string  Path { get; set; }

        /* 1..n */
        public int AnnouncementId;
        public AnnouncementEntity? Announcement { get; set; }
        public int UserId { get; set; }
        public UserEntity? User { get; set; }
    }
}
