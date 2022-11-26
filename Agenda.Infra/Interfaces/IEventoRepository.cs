using Agenda.Infra.Models.Eventos;

namespace Agenda.Infra.Interfaces
{
    public interface IEventoRepository
    {
        Task<IEnumerable<Evento>> ObterTodosAsync(int usuarioId);
        Task<Evento> ObterPorIdAsync(int eventoId);
        Task<Evento> ObterPorNomeAsync(string nomeEvento, int usuarioId);        
        Task<IEnumerable<Evento>> ObterPorDataAsync(DateTime dataEvento, int usuarioId);        
        Task InsertAsync(Evento evento);
        Task UpdateAsync(Evento evento);
        Task DeleteAsync(Evento evento);

    }
}
