using Agenda.Security.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Security.Interfaces
{
    public interface IUsuarioTesteRepository
    {
        Task<IEnumerable<UsuarioTeste>> ObterTodosUsuarios();
        Task<IEnumerable<UsuarioTeste>> ObterUsuario(string nomeUsuario);
        Task<UsuarioTeste> ObterUsuario(string nomeUsuario, string password);
        Task InsertUsuario(UsuarioTeste usuario);
        Task UpdateUsuario(UsuarioTeste usuario);
        Task DeleteUsuario(int idUsuario);        
    }
}
