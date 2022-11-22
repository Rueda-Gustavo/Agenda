
using Agenda.Security.Models;

namespace Agenda.Security.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> ObterTodosUsuarios();
        Task<Usuario> ObterUsuario(string nomeUsuario);
        Task<Usuario> ObterUsuario(string nomeUsuario, string password);
        Task InsertUsuario(Usuario usuario);
        Task UpdateUsuario(Usuario usuario);
        Task DeleteUsuario(int idUsuario);                           
    }
}
