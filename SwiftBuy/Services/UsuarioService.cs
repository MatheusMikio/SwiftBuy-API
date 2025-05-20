using SwiftBuy.DTO;
using SwiftBuy.Model;
using SwiftBuy.Repositorio.Interfaces;
using SwiftBuy.Services.Interfaces;

namespace SwiftBuy.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioService(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public Task<UsuarioModel> AddUsuario(UsuarioDTO usuario)
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

        public Task<UsuarioModel> UpdateUsuario(UsuarioDTO usuario)
        {
            throw new NotImplementedException();
        }
    }
}
