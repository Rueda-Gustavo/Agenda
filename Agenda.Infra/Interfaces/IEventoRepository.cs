using Agenda.Infra.Models.Eventos;

namespace Agenda.Infra.Interfaces
{
    public interface IEventoRepository
    {
        Task<IEnumerable<Evento>> ObterTodosAsync();
        Task<Evento> ObterPorNomeAsync(string nomeEvento);        
        Task<IEnumerable<Evento>> ObterPorDataAsync(DateTime dataEvento);        
        Task InsertAsync(Evento evento);
        Task UpdateAsync(Evento evento);
        Task DeleteAsync(Evento evento);

    }
}
