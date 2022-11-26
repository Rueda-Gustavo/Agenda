using Agenda.Infra.Models.Eventos;
using CSharpFunctionalExtensions;

namespace Agenda.Services.Interfaces
{
    public interface IEventoService
    {
        Task<Result<IEnumerable<Evento>>> ListarTodosEventos(int usuarioId);
        Task<Result<Evento>> ObterEventoPorNome(string nomeEvento, int usuarioId);
        Task<Result<IEnumerable<Evento>>> ObterEventoPorData(DateTime dataEvento, int usuarioId);        
        Task<Result<Evento>> IncluirEvento(Evento evento);
        Task<Result<Evento>> AlterarEvento(Evento evento);
        Task<Result<Evento>> ExcluirEvento(string nomeEvento, int usuarioId);
        
    }
}
