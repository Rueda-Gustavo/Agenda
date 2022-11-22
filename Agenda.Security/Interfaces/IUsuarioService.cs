using Agenda.Security.Models;
using CSharpFunctionalExtensions;
using System.Collections;

namespace Agenda.Security.Interfaces
{
    public interface IUsuarioService
    {
        Task<Result<TokenDto>> LoginAsync(string username, string password);
        Task<Result<TokenDto>> RefreshTokenAsync(TokenDto tokenDto);
        Task<Result> RevokeAsync(string userName);
        Task RevokeAllAsync();        
    }
}
