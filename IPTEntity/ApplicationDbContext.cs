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
            //modelBuilder.Entity<Organizacion>().Property(t => t.Nombre).HasMaxLength(250);
        }
        public DbSet<Organizacion> Organizaciones { get; set; }
        public DbSet<Vacante> Vacantes { get; set; }
        public DbSet<SolicitudEmpleo> SolicitudEmpleos { get; set; }
    }
}
