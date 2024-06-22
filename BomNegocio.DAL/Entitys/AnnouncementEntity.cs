
namespace BomNegocio.Domain.Entitys
{
    public class AnnouncementEntity : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime DeactivationDate { get; set; }

        /* EF 1..N */
        public int AdvertiserId { get; set; }
        public AdvertiserEntity Advertiser { get; set; }

        public int CategoryId { get; set; }
        public CategoryEntity? Category { get; set; }

        /* EF 1..1 */
        public AddressEntity? Address { get; set; }

        /* EF N..1 */
        public ICollection<EvaluetionEntity>? Evaluetions { get; set; }
        public ICollection<ImageEntity>? Images { get; set; }
        public ICollection<WisheEntity>? Wishes { get; set; }

    }
}
