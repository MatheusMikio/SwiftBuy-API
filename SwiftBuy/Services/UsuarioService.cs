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

        public async Task<List<UsuarioDTOSaida>> GetUsuarios()
        {
            List<UsuarioModel> usersBd = await _usuarioRepositorio.GetUsuarios();
            List<UsuarioDTOSaida> usersDTO = new();
            foreach (UsuarioModel userBd in usersBd)
            {
                UsuarioDTOSaida usuarioDTO = new()
                {
                    Nome = userBd.Nome,
                    Email = userBd.Email,
                    CPF = userBd.CPF,
                    Telefone = userBd.Telefone,
                    Tipo = userBd.Tipo
                };
                usersDTO.Add(usuarioDTO);
            }
            return usersDTO;
        } 

        public async Task<UsuarioDTOSaida> GetUsuarioId(int id)
        {
            UsuarioModel userBd = await _usuarioRepositorio.GetUsuarioId(id);

            if (userBd == null) return null;

            UsuarioDTOSaida userDTO = new()
            {
                Nome = userBd.Nome,
                Email = userBd.Email,
                CPF = userBd.CPF,
                Telefone = userBd.Telefone,
                Tipo = userBd.Tipo
            };

            return userDTO;
        }

        public async Task<UsuarioModel> AddUsuario(UsuarioDTO usuario)
        {
            if (await _usuarioRepositorio.ValidaUsuario(usuario)) return null;

            UsuarioModel usuarioBd = new(usuario);
            usuarioBd.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
            await _usuarioRepositorio.AddUsuario(usuarioBd);
            return usuarioBd;
        }

        public async Task<UsuarioModel> UpdateUsuario(UsuarioDTO usuario, int id)
        {
            bool userDuplicado = await _usuarioRepositorio.ValidaUsuarioUpdate(usuario, id);

            if (userDuplicado) return null;

            UsuarioModel updatedUser = await _usuarioRepositorio.GetUsuarioId(id);
            updatedUser.Nome = usuario.Nome;
            updatedUser.Telefone = usuario.Telefone;
            updatedUser.Email = usuario.Email;
            updatedUser.CPF = usuario.CPF;
            updatedUser.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
            updatedUser.Tipo = usuario.Tipo;
            await _usuarioRepositorio.UpdateUsuario(updatedUser);
            return updatedUser;
        }


        public async Task<UsuarioModel> DeleteUsuario(int id)
        {
            UsuarioModel userBd = await _usuarioRepositorio.GetUsuarioId(id);

            if (userBd == null) return null;

            await _usuarioRepositorio.DeleteUsuario(id);
            return userBd;
        }
    }
}
