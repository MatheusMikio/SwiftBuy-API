using Microsoft.EntityFrameworkCore;
using SwiftBuy.DataBase;
using SwiftBuy.DTO;
using SwiftBuy.Model;
using SwiftBuy.Repositorio.Interfaces;

namespace SwiftBuy.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly SwiftBuyDbContext _context;
        public UsuarioRepositorio(SwiftBuyDbContext context)
        {
            _context = context;
        }

        public async Task<List<UsuarioModel>> GetUsuarios() => await _context.usuarios.OrderBy(usuario => usuario.Nome).ToListAsync();

        public async Task<UsuarioModel> GetUsuarioId(int id) => await _context.usuarios.FindAsync(id);

        public async Task<UsuarioModel> AddUsuario(UsuarioModel usuario)
        {
            _context.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }
        public Task<UsuarioModel> UpdateUsuario(UsuarioModel usuario)
        {
            throw new NotImplementedException();
        }

        public async Task<UsuarioModel> DeleteUsuario(int id)
        {
            UsuarioModel usuario = await GetUsuarioId(id);
            _context.Remove(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<bool> ValidaUsuario(UsuarioDTO usuario)
        {
            return await _context.usuarios.AnyAsync(userBd => userBd.Email == usuario.Email || userBd.CPF == usuario.CPF);

        }
    }
}
