using Agenda.Security.Database.EntityConfiguration;
using Agenda.Security.Models;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Security.Database
{
    public class UsuarioTesteDataContext : DbContext
    {
        public DbSet<UsuarioTeste> UsuariosTeste { get; set; }

        public UsuarioTesteDataContext(DbContextOptions<UsuarioTesteDataContext> options) : base(options)
        {
            //Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioTesteEntityConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
