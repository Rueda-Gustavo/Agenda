using Agenda.Security.Interfaces;
using Agenda.Security.Models;
using CSharpFunctionalExtensions;

namespace Agenda.Security.Services
{
    public class UsuarioTesteService : IUsuarioTesteService
    {

        private readonly IUsuarioTesteRepository _usuarioRepository;

        public UsuarioTesteService(IUsuarioTesteRepository usuarioRepository){
            _usuarioRepository = usuarioRepository;            
        }
        public async Task<Result<UsuarioTeste>> LoginAsync(string username, string password)
        {
            UsuarioTeste user = await _usuarioRepository.ObterUsuario(username, password);
            return Result.FailureIf(user is null, user, "Usuario ou senha inválidos");            
        }

        public async Task<Result<UsuarioTeste>> NovoUsuario(string username, string nomeCompleto, string password)
        {                        
            if(await UsuarioJaExiste(username))
                return Result.Failure<UsuarioTeste>("Esse nome de usuário já existe!");
            
            UsuarioTeste user = new() { NomeUsuario = username, NomeCompleto = nomeCompleto, Password = password };
            await _usuarioRepository.InsertUsuario(user);
            return Result.Success(user);
        }
      
        public async Task<Result<UsuarioTeste>> TrocarSenha(string username, string password, string newPassword)
        {            
            if (await CredenciaisCorretas(username, password))
            {
                UsuarioTeste user = await _usuarioRepository.ObterUsuario(username, password);
                user.Password = newPassword;
                await _usuarioRepository.UpdateUsuario(user);                
                return Result.Success(user);
            }
            return Result.Failure<UsuarioTeste>("Credenciais incorretas!");
        }

        public async Task<Result<UsuarioTeste>> RemoverUsuario(string username, string password, bool confirmacao)
        {
            if(await CredenciaisCorretas(username, password))
            {
                UsuarioTeste user = await _usuarioRepository.ObterUsuario(username, password);
                if (confirmacao)
                {
                    int id = user.Id;
                    await _usuarioRepository.DeleteUsuario(id);
                    return Result.Success(user);
                } 
                else
                    return Result.Failure<UsuarioTeste>("Por favor confirme a exclusão.");
            }
            return Result.Failure<UsuarioTeste>("Credenciais incorretas!");
        }

        public async Task<Result<IEnumerable<UsuarioTeste>>> ListarTodosUsuarios()
        {
            return Result.Success(await _usuarioRepository.ObterTodosUsuarios());
        }

        private async Task<bool> UsuarioJaExiste(string nome)
        {
            return (await _usuarioRepository.ObterUsuario(nome)).Any();
        }

        private async Task<bool> CredenciaisCorretas(string username, string password)
        {
            UsuarioTeste user = await _usuarioRepository.ObterUsuario(username, password);
            if (user is not null)
                return true;
            return false;
        }
    }
}
