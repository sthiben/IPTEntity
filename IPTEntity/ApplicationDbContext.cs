using IPTEntity.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IPTEntity
{
    public class ApplicationDbContext : IdentityDbContext

    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<SolicitudEmpleo> SolicitudEmpleos { get; set; }
        public DbSet<Empresas> Empresas { get; set; }
        public DbSet<OfertaLaboral> OfertaLaboral { get; set; }
    }
}
