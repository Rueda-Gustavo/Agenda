using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Agenda.Security.Database
{
    public class UsuarioDataContextFactory : IDesignTimeDbContextFactory<UsuarioDataContext>
    {
        public UsuarioDataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<UsuarioDataContext>();

            optionsBuilder.UseSqlServer("");

            return new UsuarioDataContext(optionsBuilder.Options);
        }
    }
}