using BomNegocio.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BomNegocio.Infrastructure.Configuration
{
    public class EvaluetionConfiguration : IEntityTypeConfiguration<EvaluetionEntity>
    {
        public void Configure(EntityTypeBuilder<EvaluetionEntity> builder)
        {
            builder.ToTable("EVALUETION");

            builder.HasKey(x => x.Id);

            builder.Property<int>(x => x.Id)
                .HasColumnName("ID")
                .IsRequired(true)
                .ValueGeneratedOnAdd();

            builder.HasOne(x => x.Announcement)
                .WithMany(x => x.Evaluetions)
                .HasForeignKey(x => x.AnnouncementId)
                .HasConstraintName("FK_EVALUETION_ANNOUNCEMENT")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Client)
                .WithMany(x => x.Evaluetions)
                .HasForeignKey(x => x.ClientId)
                .HasConstraintName("FK_EVALUETION_CLIENT")
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.Note)
                .HasColumnName("NOTE")
                .IsRequired(true);

            builder.Property(x => x.CreationDate)
                .HasColumnName("CREATION_DATE")
                .HasColumnType("date")
                .IsRequired(true);

            builder.Property(x => x.Commenter)
                .HasColumnName("COMMENTER")
                .IsRequired(false)
                .HasDefaultValue(null);
        }
    }
}
