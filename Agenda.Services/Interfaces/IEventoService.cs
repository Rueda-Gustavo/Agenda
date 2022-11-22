using Agenda.Infra.Models.Eventos;
using CSharpFunctionalExtensions;

namespace Agenda.Services.Interfaces
{
    public interface IEventoService
    {
        Task<Result<IEnumerable<Evento>>> ListarTodosEventos();
        Task<Result<Evento>> ObterEventoPorNome(string nomeEvento);
        Task<Result<IEnumerable<Evento>>> ObterEventoPorData(DateTime dataEvento);        
        Task<Result<Evento>> IncluirEvento(string nomeEvento, DateTime dataEvento, string descricaoEvento, string codigoCor);
        Task<Result<Evento>> AlterarEvento(Evento evento);
        Task<Result<Evento>> ExcluirEvento(string nomeEvento);
        
    }
}
