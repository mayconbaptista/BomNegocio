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
    public class ImagemConfiguration : IEntityTypeConfiguration<Imagem>
    {
        public void Configure(EntityTypeBuilder<Imagem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Anuncio)
                .WithMany(x => x.Imagens)
                .HasForeignKey(x => x.AnuncioId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Imagens)
                .HasForeignKey(x =>x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
