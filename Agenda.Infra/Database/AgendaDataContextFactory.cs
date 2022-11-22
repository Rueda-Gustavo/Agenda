using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Agenda.Infra.Database
{
    public class AgendaDataContextFactory : IDesignTimeDbContextFactory<AgendaDataContext>
    {
        public AgendaDataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AgendaDataContext>();

            optionsBuilder.UseSqlServer("");

            return new AgendaDataContext(optionsBuilder.Options);
        }

    }
}
