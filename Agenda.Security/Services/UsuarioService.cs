﻿using Agenda.Security.Interfaces;
using Agenda.Security.Models;
using CSharpFunctionalExtensions;
using System.Collections;
using System.Security.Claims;

namespace Agenda.Security.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly ITokenService _tokenService;
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(ITokenService tokenService, IUsuarioRepository usuarioRepository)
        {
            _tokenService = tokenService;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Result<TokenDto>> LoginAsync(string username, string password)
        {
            Usuario user = await _usuarioRepository.ObterUsuario(username, password);
            return Result.FailureIf(user is null, await GerarToken(user), "Usuário inválido ou senha incorreta!");            
        }

        public async Task<Result<TokenDto>> RefreshTokenAsync(TokenDto tokenDto)
        {
            if(tokenDto == null)
                throw new ArgumentNullException(nameof(tokenDto), "Token não informado!");

            ClaimsPrincipal principal = _tokenService.ObterClaimsDoJwt(tokenDto.AccessToken);
            Usuario user = await _usuarioRepository.ObterUsuario(principal.Identity.Name);

            return Result.FailureIf(user == null || user.RefreshToken != tokenDto.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.Now,
                await GerarToken(user), "Access Token ou Refresh Token inválido!");            
        }

        public async Task RevokeAllAsync()
        {
            foreach (var user in await _usuarioRepository.ObterTodosUsuarios())
                await RevokeAsync(user);
        }

        public async Task<Result> RevokeAsync(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                throw new ArgumentNullException(nameof(userName), "Nome do usuário não informado!");

            Usuario user = await _usuarioRepository.ObterUsuario(userName);
            if (user is null)
                return Result.Failure("Usuário informado não foi localizado!");

            await RevokeAsync(user);
            return Result.Success();
        }      

        private async Task RevokeAsync(Usuario user)
        {
            user.RefreshToken = null;
            user.RefreshTokenExpiryTime = null;
            await _usuarioRepository.UpdateUsuario(user);
        }

        private async Task<TokenDto> GerarToken(Usuario usuario)
        {
            TokenDto dto = _tokenService.GerarToken(usuario);
            await _usuarioRepository.UpdateUsuario(usuario);
            return dto;
        }

        //-------------------------------Código temporário para apresentação------------------------------------------

        public void Login(){

        }

        public void MudarSenha()
        {

        }

        public void ObterTodos()
        {

        } 

        public void AdicionarUsuario()
        {

        }

        public void RemoverUsuario()
        {

        }
    }
}
