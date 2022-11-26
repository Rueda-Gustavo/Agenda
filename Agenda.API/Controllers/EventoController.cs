using Agenda.Infra.Interfaces;
using Agenda.Infra.Models.Eventos;
using Agenda.Security.Interfaces;
using Agenda.Security.Models;
using Agenda.Services.Interfaces;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Agenda.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]    
    public class EventoController : ControllerBase
    {        
        private readonly IEventoService _eventoService;
        private readonly IUsuarioTesteService _usuarioTesteService;
        
        public EventoController(IEventoService eventoService, IUsuarioTesteService usuarioTesteService)
        {            
            _eventoService = eventoService;
            _usuarioTesteService = usuarioTesteService;
        }        

        [HttpGet("Listar eventos")]
        public async Task<IActionResult> ObterEventos(string username, string password)
        {
            Result<UsuarioTeste> login = await _usuarioTesteService.LoginAsync(username, password);
            if (login.IsFailure)
                return BadRequest(login.Error);
            else
            {
                int usuarioId = login.Value.Id;
                Result<IEnumerable<Evento>> result = await _eventoService.ListarTodosEventos(usuarioId);
                if (result.IsFailure)
                    return BadRequest(result.Error);
                
                List<Evento> eventos = result.Value.ToList();
                eventos.ForEach(e => e.Usuario = login.Value);                
                return Ok(result.Value);
            }
        }

        [HttpGet("Consultar evento por data")]
        public async Task<IActionResult> ObterEvento(string username, string password, DateTime dataEvento)
        {
            Result<UsuarioTeste> login = await _usuarioTesteService.LoginAsync(username, password);
            if (login.IsFailure)
                return BadRequest(login.Error);
            else
            {
                int usuarioId = login.Value.Id;
                Result<IEnumerable<Evento>> result = await _eventoService.ObterEventoPorData(dataEvento, usuarioId);
                if (result.IsFailure)
                    return BadRequest(result.Error);

                List<Evento> eventos = result.Value.ToList();
                eventos.ForEach(e => e.Usuario = login.Value);
                return Ok(result.Value);
            }
        }

        [HttpGet("Consultar evento por nome")]
        public async Task<IActionResult> ObterEvento(string username, string password, string nomeEvento)
        {
            Result<UsuarioTeste> login = await _usuarioTesteService.LoginAsync(username, password);
            if (login.IsFailure)
                return BadRequest(login.Error);
            else
            {
                int usuarioId = login.Value.Id;
                Result<Evento> result = await _eventoService.ObterEventoPorNome(nomeEvento, usuarioId);
                if (result.IsFailure)
                    return BadRequest(result.Error);

                result.Value.Usuario = login.Value;
                return Ok(result.Value);
            }
        }

        [HttpPost("Novo evento")]
        public async Task<IActionResult> InserirEvento(string username, string password, string nomeEvento, DateTime dataEvento, string descricaoEvento, string? codigoCor)
        {
            Result<UsuarioTeste> login = await _usuarioTesteService.LoginAsync(username, password);
            if (login.IsFailure)
                return BadRequest(login.Error);
            else
            {
                int usuarioId = login.Value.Id;
                Evento evento = new() { Nome = nomeEvento, Data = dataEvento, Descricao = descricaoEvento, CodigoCorEvento = codigoCor, UsuarioId = usuarioId };

                if (evento.CodigoCorEvento == null)
                    evento.CodigoCorEvento = "#000"; //Cor padrão

                Result<Evento> result = await _eventoService.IncluirEvento(evento/*nomeEvento, dataEvento, descricaoEvento, codigoCor, usuarioId*/);
                if (result.IsFailure)
                    return BadRequest(result.Error);

                result.Value.Usuario = login.Value;
                return Ok(result.Value);
            }
        }

        [HttpPut("Atualizar evento")]
        public async Task<IActionResult> AtualizarEvento(string username, string password, int eventoId, string nomeEvento, DateTime dataEvento, string descricaoEvento, string? codigoCor)
        {
            Result<UsuarioTeste> login = await _usuarioTesteService.LoginAsync(username, password);
            if (login.IsFailure)
                return BadRequest(login.Error);
            else
            {
                int usuarioId = login.Value.Id;
                Evento evento = new() { Id = eventoId, Nome = nomeEvento, Data = dataEvento, Descricao = descricaoEvento, CodigoCorEvento = codigoCor, UsuarioId = usuarioId };                

                if (evento.CodigoCorEvento == null)
                    evento.CodigoCorEvento = "#000"; //Cor padrão                
                                
                Result<Evento> result = await _eventoService.AlterarEvento(evento);
                if (result.IsFailure)
                    return BadRequest(result.Error);

                result.Value.Usuario = login.Value;
                return Ok(result.Value);
            }
        }

        [HttpDelete("Remover evento")]
        public async Task<IActionResult> RemoverEvento(string username, string password, string nomeEvento)
        {
            Result<UsuarioTeste> login = await _usuarioTesteService.LoginAsync(username, password);
            if (login.IsFailure)
                return BadRequest(login.Error);
            else
            {
                int usuarioId = login.Value.Id;
                Result<Evento> result = await _eventoService.ExcluirEvento(nomeEvento, usuarioId);
                if (result.IsFailure)
                    return BadRequest(result.Error);

                result.Value.Usuario = login.Value;
                return Ok(result.Value);
            }
        }
    }
}
