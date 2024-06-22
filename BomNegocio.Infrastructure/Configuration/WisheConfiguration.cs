using BomNegocio.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BomNegocio.Infrastructure.Configuration
{
    public class WisheConfiguration : IEntityTypeConfiguration<WisheEntity>
    {
        public void Configure(EntityTypeBuilder<WisheEntity> builder)
        {
            builder.ToTable("WISHE");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("ID")
                .IsRequired(true)
                .ValueGeneratedOnAdd();

            builder.HasOne(x => x.Client)
                .WithMany(x => x.Wishes)
                .HasForeignKey(x => x.ClientId)
                .HasConstraintName("FK_WISHE_CLIENT")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Announcement)
                .WithMany(x => x.Wishes)
                .HasForeignKey(x => x.AnnouncementId)
                .HasConstraintName("FK_WISHE_ANNOUNCEMENT")
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(c => c.CreationDate)
                .HasColumnName("CREATION_DATE")
                .HasColumnType("date")
                .IsRequired(true);
        }
    }
}
