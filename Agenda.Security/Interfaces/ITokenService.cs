using Agenda.Security.Models;
using System.Security.Claims;

namespace Agenda.Security.Interfaces
{
    public interface ITokenService
    {
        TokenDto GerarToken(Usuario usuario);

        ClaimsPrincipal ObterClaimsDoJwt(string jwt);
    }
}
