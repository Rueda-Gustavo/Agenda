using Agenda.Infra.Database;
using Agenda.Infra.Interfaces;
using Agenda.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Agenda.Infra
{
    public static class AgendaInfraExtensions
    {
        public static IServiceCollection AddAgendaInfra(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<AgendaDataContext>(option => option.UseSqlServer(configuration.GetConnectionString("SqlServer")));
            service.AddScoped<IEventoRepository, EventoRepository>();            
            return service;
        }

    }
}