using Agenda.Infra.Database;
using Agenda.Infra.Interfaces;
using Agenda.Infra.Models.Eventos;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Infra.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly AgendaDataContext _context;

        public EventoRepository(AgendaDataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Evento>> ObterTodosAsync()
        {
            return await _context.Eventos.
                ToListAsync();
        }

        public async Task<Evento> ObterPorNomeAsync(string nomeEvento)
        {
            if (nomeEvento is null)
                throw new ArgumentNullException(nameof(nomeEvento), "Nenhum nome para o evento foi informado");
            return await _context.Eventos
                .FirstOrDefaultAsync(evento => evento.Nome == nomeEvento);
        }

        public async Task<IEnumerable<Evento>> ObterPorDataAsync(DateTime dataEvento)
        {            
            return await _context.Eventos
                .Where(evento => evento.Data == dataEvento)
                .ToListAsync();
        }
                
        public async Task InsertAsync(Evento evento)
        {        
            if (evento is null)
                throw new ArgumentNullException(nameof(evento), "Nenhum evento informado");
            _context.Add(evento);
            await _context.SaveChangesAsync();
        }        

        public async Task UpdateAsync(Evento evento)
        {
            if (evento is null)
                throw new ArgumentNullException(nameof(evento), "Nenhum evento informado");
            _context.Update(evento);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Evento evento)
        {
            if (evento is null)
                throw new ArgumentNullException(nameof(evento), "Nenhum evento informado");
            _context.Remove(evento);
            await _context.SaveChangesAsync();
        }
    }
}
