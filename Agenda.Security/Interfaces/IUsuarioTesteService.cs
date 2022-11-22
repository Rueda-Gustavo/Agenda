using Agenda.Security.Models;
using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Security.Interfaces
{
    public interface IUsuarioTesteService
    {
        Task<Result<UsuarioTeste>> LoginAsync(string username, string password);
        Task<Result<UsuarioTeste>> TrocarSenha(string username, string password, string newPassword);
        Task<Result<UsuarioTeste>> NovoUsuario(string username, string nomeCompleto, string password);
        Task<Result<UsuarioTeste>> RemoverUsuario(string username, string password, bool confirmacao);
        Task<Result<IEnumerable<UsuarioTeste>>> ListarTodosUsuarios();
    }
}
