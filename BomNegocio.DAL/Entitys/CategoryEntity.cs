
namespace BomNegocio.Domain.Entitys
{
    public class CategoryEntity : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? IconName { get; set; }

        /* EF 1..N */
        public ICollection<AnnouncementEntity>? Announcements { get; set; }

        public int? ParentCategoryId { get; set; }
        public CategoryEntity? ParentCategory { get; set; }
        public ICollection<CategoryEntity>? SubCategoryes { get; set; }
    }
}
