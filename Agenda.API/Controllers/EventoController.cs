using Agenda.Infra.Interfaces;
using Agenda.Infra.Models.Eventos;
using Agenda.Security.Interfaces;
using Agenda.Security.Models;
using Agenda.Services.Interfaces;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
                Result<IEnumerable<Evento>> result = await _eventoService.ListarTodosEventos();
                if (result.IsFailure)
                    return BadRequest(result.Error);
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
                Result<IEnumerable<Evento>> result = await _eventoService.ObterEventoPorData(dataEvento);
                if (result.IsFailure)
                    return BadRequest(result.Error);
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
                Result<Evento> result = await _eventoService.ObterEventoPorNome(nomeEvento);
                if (result.IsFailure)
                    return BadRequest(result.Error);
                return Ok(result.Value);
            }
        }

        [HttpPost("Novo evento")]
        public async Task<IActionResult> InserirEvento(string username, string password, string nomeEvento, DateTime dataEvento, string descricaoEvento, string codigoCor)
        {
            Result<UsuarioTeste> login = await _usuarioTesteService.LoginAsync(username, password);
            if (login.IsFailure)
                return BadRequest(login.Error);
            else
            {
                if (codigoCor == null)
                    codigoCor = "#000"; //Cor padrão
                Result<Evento> result = await _eventoService.IncluirEvento(nomeEvento, dataEvento, descricaoEvento, codigoCor);
                if (result.IsFailure)
                    return BadRequest(result.Error);
                return Ok(result.Value);
            }
        }

        [HttpPut("Atualizar evento")]
        public async Task<IActionResult> AtualizarEvento(string username, string password, string nomeEvento, DateTime dataEvento, string descricaoEvento, string codigoCor)
        {
            Result<UsuarioTeste> login = await _usuarioTesteService.LoginAsync(username, password);
            if (login.IsFailure)
                return BadRequest(login.Error);
            else
            {
                if (codigoCor == null)
                    codigoCor = "#000"; //Cor padrão
                Evento evento = new() { Nome = nomeEvento, Data = dataEvento, Descricao = descricaoEvento, CodigoCorEvento = codigoCor };
                Result<Evento> result = await _eventoService.AlterarEvento(evento);
                if (result.IsFailure)
                    return BadRequest(result.Error);
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
                Result<Evento> result = await _eventoService.ExcluirEvento(nomeEvento);
                if (result.IsFailure)
                    return BadRequest(result.Error);
                return Ok(result.Value);
            }
        }
    }
}
