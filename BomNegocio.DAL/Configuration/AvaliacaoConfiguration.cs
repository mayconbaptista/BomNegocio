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
    public class AvaliacaoConfiguration : IEntityTypeConfiguration<Avaliacao>
    {
        public void Configure(EntityTypeBuilder<Avaliacao> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Anuncio)
                .WithMany(x => x.Avaliacoes)
                .HasForeignKey(x => x.AnuncioId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Cliente)
                .WithMany(x => x.Avaliacoes)
                .HasForeignKey(x => x.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
