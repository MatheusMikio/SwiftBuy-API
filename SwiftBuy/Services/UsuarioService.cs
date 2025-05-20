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
        public Task<UsuarioModel> GetUsuarioId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UsuarioModel>> GetUsuarios() => await _usuarioRepositorio.GetUsuarios();

        public async Task<UsuarioModel> AddUsuario(UsuarioDTO usuario)
        {
            if(usuario == null) throw new Exception("Usuário não pode ser nulo");

            if (await _usuarioRepositorio.ValidaUsuario(usuario)) throw new Exception("Já existe um usuario com esse CPF ou email");

            UsuarioModel usuarioBd = new(usuario);
            usuarioBd.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
            await _usuarioRepositorio.AddUsuario(usuarioBd);
            return usuarioBd;
        }
        public Task<UsuarioModel> UpdateUsuario(UsuarioDTO usuario)
        {
            throw new NotImplementedException();
        }

        public async Task<UsuarioModel> DeleteUsuario(int id)
        {
            UsuarioModel userBd = await _usuarioRepositorio.GetUsuarioId(id);

            if (userBd == null) throw new Exception($"Não foi encontrado nenhum usuario com esse Id: {id}");

            await _usuarioRepositorio.DeleteUsuario(id);
            return userBd;
        }
    }
}
