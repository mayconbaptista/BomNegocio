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
        public BNContext (DbContextOptions<BNContext> options) : base(options)
        {

        }

        public DbSet<Anunciante> Anunciantes { get; set; }
        public DbSet<Anuncio> Anuncios { get; set;}
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Avaliacao> Interesses { get; set;}

        protected override void OnModelCreating (ModelBuilder builder)
        {
            base.OnModelCreating (builder);
        }
    }
}
