using BomNegocio.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomNegocio.DAL.Configuration
{
    public class DesejoConfiguration : IEntityTypeConfiguration<Desejo>
    {
        public void Configure(EntityTypeBuilder<Desejo> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Cliente)
                .WithMany(x => x.Desejos)
                .HasForeignKey(x => x.ClienteId);

            builder.HasOne(x => x.Anuncio)
                .WithMany(x => x.Desejos)
                .HasForeignKey(x => x.AnuncioId);
        }
    }
}
