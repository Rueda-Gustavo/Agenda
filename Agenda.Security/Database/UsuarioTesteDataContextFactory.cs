using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Agenda.Security.Database
{
    public class UsuarioTesteDataContextFactory : IDesignTimeDbContextFactory<UsuarioTesteDataContext>
    {
        public UsuarioTesteDataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<UsuarioTesteDataContext>();

            optionsBuilder.UseSqlServer("");

            return new UsuarioTesteDataContext(optionsBuilder.Options);
        }
    }
}
