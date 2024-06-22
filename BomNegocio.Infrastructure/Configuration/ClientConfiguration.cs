using BomNegocio.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BomNegocio.Infrastructure.Configuration
{
    public class ClientConfiguration : IEntityTypeConfiguration<ClientEntity>
    {
        public void Configure(EntityTypeBuilder<ClientEntity> builder)
        {
            builder.ToTable("CLIENT");

            builder.HasKey(c => c.Id);
            builder.Property<int>(c => c.Id)
                .HasColumnName("ID")
                .IsRequired(true)
                .ValueGeneratedOnAdd();

            builder.HasOne(c => c.User)
                .WithOne(z => z.Client)
                .HasForeignKey<ClientEntity>(c => c.UserId)
                .HasConstraintName("FK_CLIENT_USER")
                .IsRequired(true);

            builder.Property<int>(c => c.UserId)
                .HasColumnName("USER_ID")
                .IsRequired(true);

            builder.Property(c => c.RegistrationDate)
                .HasColumnName("REGISTRATION_DATE")
                .IsRequired(true);

            builder.Property(c => c.DeactivationDate)
                .HasColumnName("DEACTIVATION_DATE")
                .IsRequired(false)
                .HasDefaultValue(null);
                
        }
    }
}
