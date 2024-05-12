using BomNegocio.DAL.Configuration;
using BomNegocio.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomNegocio.DAL.Context
{
    public class BNContext : IdentityDbContext<ApplicationUser>
    {
        public BNContext (DbContextOptions<BNContext> options) : base(options) { }

        public DbSet<Anunciante> Anunciantes { get; set; }
        public DbSet<Anuncio> Anuncios { get; set;}
        public DbSet<Avaliacao> Avaliacoes { get; set;}
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Desejo> Desejos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Imagem> Imagens { get; set; }

        protected override void OnModelCreating (ModelBuilder builder)
        {
            base.OnModelCreating (builder);

            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new AnuncianteConfiguration());
            builder.ApplyConfiguration(new AnuncioConfiguration());
            builder.ApplyConfiguration(new AvaliacaoConfiguration());
            builder.ApplyConfiguration(new CategoriaConfiguration());
            builder.ApplyConfiguration (new ClienteConfiguration());
            builder.ApplyConfiguration (new DesejoConfiguration());
            builder.ApplyConfiguration(new EnderecoConfiguration());
            builder.ApplyConfiguration(new ImagemConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
