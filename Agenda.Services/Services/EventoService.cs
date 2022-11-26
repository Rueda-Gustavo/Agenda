using Agenda.Infra.Interfaces;
using Agenda.Infra.Models.Eventos;
using Agenda.Security.Interfaces;
using Agenda.Security.Models;
using Agenda.Security.Repositories;
using Agenda.Services.Interfaces;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections;
using System.Reflection;

namespace Agenda.Services.Services
{
    public class EventoService : IEventoService
    {
        private readonly IEventoRepository _eventoRepository;        

        public EventoService(IEventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;            
        }

        public async Task<Result<IEnumerable<Evento>>> ListarTodosEventos(int usuarioId)
        {                        
            return Result.Success(await _eventoRepository.ObterTodosAsync(usuarioId));
        }

        public async Task<Result<IEnumerable<Evento>>> ObterEventoPorData(DateTime dataEvento, int usuarioId)
        {
            IEnumerable<Evento> eventos = await _eventoRepository.ObterPorDataAsync(dataEvento, usuarioId);
            return Result.FailureIf(eventos is null, eventos, $"Não existem eventos na data {dataEvento}");
        }

        public async Task<Result<Evento>> ObterEventoPorNome(string nomeEvento, int usuarioId)
        {
            Evento evento = await _eventoRepository.ObterPorNomeAsync(nomeEvento, usuarioId);
            return Result.FailureIf(evento is null, evento, $"Não existem eventos na data {nomeEvento}");
        }

        public async Task<Result<Evento>> IncluirEvento(Evento evento)
        {            
            //Evento evento = new () { Nome = nomeEvento, Data = dataEvento, Descricao = descricaoEvento, CodigoCorEvento = codigoCor, UsuarioId = usuarioId };
            if (await EventoJaExiste(evento.Nome, evento.UsuarioId))
                return Result.Failure<Evento>("Já existe um evento com esse nome");
            await _eventoRepository.InsertAsync(evento);
            return Result.Success(evento);            
        }

        public async Task<Result<Evento>> AlterarEvento(Evento evento)
        {
            if (!await EventoJaExiste(evento.Id))            
                return Result.Failure<Evento>("Esse evento não existe");
            
            await _eventoRepository.UpdateAsync(evento);
            return Result.Success(evento);
        }
        

        public async Task<Result<Evento>> ExcluirEvento(string nomeEvento, int usuarioId)
        {
            Evento evento = await _eventoRepository.ObterPorNomeAsync(nomeEvento, usuarioId);
            if (evento is null)
                return Result.Failure<Evento>("Não existe um evento com esse nome");
            await _eventoRepository.DeleteAsync(evento);
            return Result.Success(evento);
        }      

        private async Task<bool> EventoJaExiste(string nome, int usuarioId)
        {
            if(await _eventoRepository.ObterPorNomeAsync(nome, usuarioId) is not null)
            {
                return true;
            }
            return false;
        }

        private async Task<bool> EventoJaExiste(int eventoId)
        {
            if (await _eventoRepository.ObterPorIdAsync(eventoId) is not null)
            {
                return true;
            }
            return false;
        }
    }
}
