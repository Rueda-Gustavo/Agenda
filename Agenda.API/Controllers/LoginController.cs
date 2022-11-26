using Agenda.Security.Interfaces;
using Agenda.Security.Models;
using Agenda.Security.Repositories;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Agenda.API.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioTesteService _usuarioTesteService;    
        private readonly IUsuarioService _usuarioService;

        public LoginController(IUsuarioTesteService usuarioTesteService, IUsuarioService usuarioService)
        {
            _usuarioTesteService = usuarioTesteService;
            _usuarioService = usuarioService;
        }
                
        /*
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Token([FromForm] IFormCollection form)
        {
            if (!form.ContainsKey("username") || !form.ContainsKey("password"))
                return BadRequest("Usuário ou senha não foi informado!");
            Result<TokenDto> result = await _usuarioService.LoginAsync(form["username"], form["password"]);
            return result.IsSuccess ? Ok(result.Value) : Unauthorized(result.Error);
        }

        [HttpPost("refreshtoken")]
        public async Task<IActionResult> RefreshToken(TokenDto tokenDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Result<TokenDto> result = await _usuarioService.RefreshTokenAsync(tokenDto);
            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
        }

        [HttpPatch("revoke/{username}")]
        public async Task<IActionResult> RevokeRefreshToken(string username)
        {
            Result result = await _usuarioService.RevokeAsync(username);
            return result.IsSuccess ? Ok() : BadRequest(result.Error);
        }

        [HttpPatch("revokeall")]
        public async Task<IActionResult> RevokeAll()
        {
            await _usuarioService.RevokeAllAsync();
            return Ok();
        }
        */
        //Usuario teste

        [HttpGet("Get")]
        public async Task<IActionResult> GetUsuario()
        {
            Result<IEnumerable<UsuarioTeste>> result = await _usuarioTesteService.ListarTodosUsuarios();
            if (result.IsFailure)
                return BadRequest(result.Error);
            return Ok(result.Value);
        }

        [HttpGet("Login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            Result<UsuarioTeste> result = await _usuarioTesteService.LoginAsync(username, password);
            if (result.IsFailure)
                return BadRequest(result.Error);
            return Ok(result.Value);
        }

        [HttpPost("Novo usuário")]
        public async Task<IActionResult> InserirUsuario(string username, string nomeCompleto, string password)
        {
            Result<UsuarioTeste> result = await _usuarioTesteService.NovoUsuario(username, nomeCompleto, password);
            if (result.IsFailure)
                return BadRequest(result.Error);
            return Ok(result.Value);
        }

        [HttpPut("Mudar senha")]
        public async Task<IActionResult> MudarSenha(string username, string password, string newPassword)
        {
            Result<UsuarioTeste> result = await _usuarioTesteService.TrocarSenha(username, password, newPassword);
            if (result.IsFailure)
                return BadRequest(result.Error);
            return Ok(result.Value);
        }

        [HttpDelete("Remover usuário")]
        public async Task<IActionResult> RemoverUsuario(string username, string password, bool confirmacao){
            Result<UsuarioTeste> result = await _usuarioTesteService.RemoverUsuario(username, password, confirmacao);
            if (result.IsFailure)
                return BadRequest(result.Error);
            return Ok(result.Value);
        }
    }
}