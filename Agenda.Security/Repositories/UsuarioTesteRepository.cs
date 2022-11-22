using Agenda.Security.Database;
using Agenda.Security.Interfaces;
using Agenda.Security.Models;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Security.Repositories
{
    public class UsuarioTesteRepository : IUsuarioTesteRepository
    {
        private readonly UsuarioTesteDataContext _context;

        public UsuarioTesteRepository(UsuarioTesteDataContext context)
        {
            _context = context;
        }

        //Consultas
        public async Task<IEnumerable<UsuarioTeste>> ObterTodosUsuarios()
        {
            return await _context.UsuariosTeste
                .ToListAsync();
        }

        public async Task<IEnumerable<UsuarioTeste>> ObterUsuario(string nomeUsuario)
        {
            return await _context.UsuariosTeste
                .Where(user => user.NomeUsuario == nomeUsuario).ToListAsync();
        }

        public async Task<UsuarioTeste> ObterUsuario(string nomeUsuario, string password)
        {
            return await _context.UsuariosTeste
                .FirstOrDefaultAsync(user => user.NomeUsuario == nomeUsuario &&
                                             user.Password == password);
        }

        //Insert, Update, Delete
        public async Task InsertUsuario(UsuarioTeste usuario)
        {
            _context.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUsuario(UsuarioTeste usuario)
        {
            _context.Update(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUsuario(int idUsuario)
        {
            UsuarioTeste usuario = _context.UsuariosTeste.FirstOrDefault(user => user.Id == idUsuario);
            _context.Remove(usuario);
            await _context.SaveChangesAsync();
        }        
    }
}
