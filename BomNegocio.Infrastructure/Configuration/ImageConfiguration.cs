using BomNegocio.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BomNegocio.Infrastructure.Configuration
{
    public class ImageConfiguration : IEntityTypeConfiguration<ImageEntity>
    {
        public void Configure(EntityTypeBuilder<ImageEntity> builder)
        {
            builder.ToTable("IMAGE");
            builder.HasKey(x => x.Id);

            builder.Property<int>(x => x.Id)
                .HasColumnName("ID")
                .IsRequired(true)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Path)
                .HasColumnName("PATH")
                .HasColumnType("date")
                .IsRequired(true);

            builder.HasOne(x => x.Announcement)
                .WithMany(x => x.Images)
                .HasForeignKey(x => x.AnnouncementId)
                .HasConstraintName("FK_IMAGE_ANNOUNCEMENT")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Images)
                .HasForeignKey(x =>x.UserId)
                .HasConstraintName("FK_IMAGE_CLIENT")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
