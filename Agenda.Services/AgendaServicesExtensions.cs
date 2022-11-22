using Agenda.Services.Interfaces;
using Agenda.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Agenda.Services
{
    public static class AgendaServicesExtensions
    {    
        public static IServiceCollection AddAgendaService(this IServiceCollection service)
        {
            service.AddScoped<IEventoService, EventoService>();
            return service;
        }
    }
}