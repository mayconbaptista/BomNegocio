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
    public class AnuncianteConfiguration : IEntityTypeConfiguration<Anunciante>
    {
        public void Configure(EntityTypeBuilder<Anunciante> builder)
        {
            builder.HasKey(a => a.Id);
            builder.HasOne(a => a.User)
                .WithOne(a => a.Anunciante)
                .HasForeignKey<Anunciante>(a => a.UserId);
        }
    }
}
