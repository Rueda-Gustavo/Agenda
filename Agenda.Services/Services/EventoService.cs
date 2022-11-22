using Agenda.Infra.Interfaces;
using Agenda.Infra.Models.Eventos;
using Agenda.Services.Interfaces;
using CSharpFunctionalExtensions;

namespace Agenda.Services.Services
{
    public class EventoService : IEventoService
    {
        private readonly IEventoRepository _eventoRepository;

        public EventoService(IEventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }

        public async Task<Result<IEnumerable<Evento>>> ListarTodosEventos()
        {
            return Result.Success(await _eventoRepository.ObterTodosAsync());
        }

        public async Task<Result<IEnumerable<Evento>>> ObterEventoPorData(DateTime dataEvento)
        {
            IEnumerable<Evento> eventos = await _eventoRepository.ObterPorDataAsync(dataEvento);
            return Result.FailureIf(eventos is null, eventos, $"Não existem eventos na data {dataEvento}");
        }

        public async Task<Result<Evento>> ObterEventoPorNome(string nomeEvento)
        {
            Evento evento = await _eventoRepository.ObterPorNomeAsync(nomeEvento);
            return Result.FailureIf(evento is null, evento, $"Não existem eventos na data {nomeEvento}");
        }

        public async Task<Result<Evento>> IncluirEvento(string nomeEvento, DateTime dataEvento, string descricaoEvento, string codigoCor)
        {
            Evento evento = new () { Nome = nomeEvento, Data = dataEvento, Descricao = descricaoEvento, CodigoCorEvento = codigoCor };
            if (await EventoJaExiste(evento.Nome))
                return Result.Failure<Evento>("Já existe um evento com esse nome");
            await _eventoRepository.InsertAsync(evento);
            return Result.Success(evento);            
        }

        public async Task<Result<Evento>> AlterarEvento(Evento evento)
        {
            if (await EventoJaExiste(evento.Nome))
                return Result.Failure<Evento>("Já existe um evento com esse nome");
            await _eventoRepository.UpdateAsync(evento);
            return Result.Success(evento);
        }

        public async Task<Result<Evento>> ExcluirEvento(string nomeEvento)
        {
            Evento evento = await _eventoRepository.ObterPorNomeAsync(nomeEvento);
            if (evento is null)
                return Result.Failure<Evento>("Não existe um evento com esse nome");
            await _eventoRepository.DeleteAsync(evento);
            return Result.Success(evento);
        }      

        private async Task<bool> EventoJaExiste(string nome)
        {
            if(await _eventoRepository.ObterPorNomeAsync(nome) is not null)
            {
                return true;
            }
            return false;
        }
    }
}
