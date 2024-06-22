namespace BomNegocio.Domain.Entitys
{
    public class EvaluetionEntity : BaseEntity
    {
        public int Note { get; set; }
        public string Commenter { get; set; }
        public DateTime CreationDate { get; set; }

        /* EF N..1 */ 
        public int AnnouncementId { get; set; }
        public virtual AnnouncementEntity Announcement { get; set; }

        public int ClientId { get; set; }
        public virtual ClientEntity Client { get; set; }
    }
}
