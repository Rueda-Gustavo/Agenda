using Agenda.Infra.Eventos.Models.EntityConfiguration;
using Agenda.Infra.Models.Eventos;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Infra.Database
{
    public class AgendaDataContext : DbContext
    {
        public DbSet<Evento> Eventos { get; set; }

        public AgendaDataContext(DbContextOptions<AgendaDataContext> option) : base(option)
        {
            //Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EventoTypeConfiguration());
            base.OnModelCreating(modelBuilder);
        }        
    }
}
