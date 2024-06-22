using BomNegocio.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BomNegocio.Infrastructure.Configuration
{
    public class AddressConfiguration : IEntityTypeConfiguration<AddressEntity>
    {
        public void Configure(EntityTypeBuilder<AddressEntity> builder)
        {
            builder.ToTable("ADDRESS");
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.User)
                .WithMany(e => e.Addresses)
                .HasForeignKey(e => e.UserId)
                .HasConstraintName("FK_ADDRESS_USER")
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.UserId)
                .HasColumnName("USER_ID")
                .IsRequired(false)
                .HasDefaultValue(null);

            builder.HasOne(a => a.Announcement)
                .WithOne(a => a.Address)
                .HasForeignKey<AddressEntity>(a => a.AnnouncementId)
                .HasConstraintName("FK_ADDRESS_ANNOUNCEMENT")
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
