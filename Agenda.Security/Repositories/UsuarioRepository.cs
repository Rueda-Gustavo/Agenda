using Agenda.Security.Database;
using Agenda.Security.Interfaces;
using Agenda.Security.Models;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Security.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UsuarioDataContext _context;

        public UsuarioRepository(UsuarioDataContext context)
            => _context = context;

        public async Task<Usuario> ObterUsuario(string NomeUsuario, string Password)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(user => user.NomeUsuario == NomeUsuario
                                                                                 && user.Password == Password);
        }
        public async Task<Usuario> ObterUsuario(string NomeUsuario)
        {            
            return await _context.Usuarios.FirstOrDefaultAsync(user => user.NomeUsuario == NomeUsuario);
        }
        /*
        public async Task<IEnumerable<Usuario>> ObterTodosUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }*/

        public async Task InsertUsuario(Usuario usuario)
        {
            _context.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUsuario(Usuario usuario)
        {
            _context.Update(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUsuario(int idUsuario)
        {            
            Usuario user = new() { Id = idUsuario };
            _context.Attach(user);
            _context.Remove(user);
            await _context.SaveChangesAsync();

        }

        //---------------------Código temporário para apresentação------------------------------------

        public async Task<IEnumerable<Usuario>> ObterTodosUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }


    }
}
