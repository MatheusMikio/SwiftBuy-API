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
        public async Task<UsuarioModel> GetUsuarioCpf(string cpf) => await _context.usuarios.FirstOrDefaultAsync(usuario => usuario.CPF == cpf);

        public async Task<UsuarioModel> AddUsuario(UsuarioModel usuario)
        {
            _context.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<UsuarioModel> UpdateUsuario(UsuarioModel usuario)
        {
            _context.Update(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<UsuarioModel> DeleteUsuario(UsuarioModel usuario)
        {
            _context.Remove(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<bool> ValidaUsuario(UsuarioDTO usuario)
        {
            return await _context.usuarios.AnyAsync(userBd => userBd.Email == usuario.Email || userBd.CPF == usuario.CPF);

        }
        public async Task<bool> ValidaUsuarioCpf(UsuarioDTO usuario)
        {
            UsuarioModel usuarioBd = await GetUsuarioCpf(usuario.CPF);

            bool userDuplicado = await _context.usuarios.AnyAsync(user =>(user.CPF == usuario.CPF || user.Email == usuario.Email) && user.Id != usuarioBd.Id);

            return userDuplicado;
        }

        public async Task<bool> ValidaUsuarioUpdate(UsuarioDTO usuario, int id)
        {
            UsuarioModel usuarioBd = await GetUsuarioId(id);

            if (usuarioBd == null) return false;

            bool userDuplicado = await _context.usuarios.AnyAsync(user =>(user.CPF == usuario.CPF || user.Email == usuario.Email) && user.Id != usuarioBd.Id);

            return userDuplicado;
        }
    }
}
