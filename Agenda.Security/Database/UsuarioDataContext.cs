using Agenda.Security.Database.EntityConfiguration;
using Agenda.Security.Models;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Security.Database
{
    public class UsuarioDataContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        public UsuarioDataContext(DbContextOptions<UsuarioDataContext> options) : base(options)
        {
            //Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioEntityTypeConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
