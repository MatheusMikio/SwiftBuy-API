using SwiftBuy.DataBase;
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

        public Task<UsuarioModel> AddUsuario(UsuarioModel produto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUsuario(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioModel> GetUsuarioId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<UsuarioModel>> GetUsuarios()
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioModel> UpdateUsuario(UsuarioModel produto)
        {
            throw new NotImplementedException();
        }
    }
}
