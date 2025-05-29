using SwiftBuy.DTO.Usuario;
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
                    Id = userBd.Id,
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
        
        public async Task<List<UsuarioDTOSaida>> GetUsuariosPaginacao(int pagina, int tamanho)
        {
            List<UsuarioModel> usersBd = await _usuarioRepositorio.GetUsuariosPaginacao(pagina, tamanho);
            List<UsuarioDTOSaida> usersDTO = new();
            foreach (UsuarioModel user in usersBd)
            {
                UsuarioDTOSaida usuario = new()
                {
                    Id = user.Id,
                    Nome = user.Nome,
                    Email = user.Email,
                    CPF = user.CPF,
                    Telefone = user.Telefone,
                    Tipo = user.Tipo
                };
                usersDTO.Add(usuario);
            }
            return usersDTO;
        }

        public async Task<UsuarioDTOSaida> GetUsuarioId(int id)
        {
            UsuarioModel userBd = await _usuarioRepositorio.GetUsuarioId(id);

            if (userBd == null) return null;

            UsuarioDTOSaida userDTO = new()
            {
                Id = userBd.Id,
                Nome = userBd.Nome,
                Email = userBd.Email,
                CPF = userBd.CPF,
                Telefone = userBd.Telefone,
                Tipo = userBd.Tipo
            };

            return userDTO;
        }
        public async Task<UsuarioDTOSaida> GetUsuarioCpf(UsuarioDTO usuario)
        {
            UsuarioModel userBd = await _usuarioRepositorio.GetUsuarioCpf(usuario.CPF);
            if (userBd == null) return null;
            UsuarioDTOSaida userDTO = new()
            {
                Id = userBd.Id,
                Nome = userBd.Nome,
                Email = userBd.Email,
                CPF = userBd.CPF,
                Telefone = userBd.Telefone,
                Tipo = userBd.Tipo
            };
            return userDTO;
        }

        public async Task<UsuarioDTOSaida> AddUsuario(UsuarioDTO usuario)
        {
            if (await _usuarioRepositorio.ValidaUsuario(usuario)) return null;

            UsuarioModel usuarioBd = new(usuario);
            usuarioBd.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
            await _usuarioRepositorio.AddUsuario(usuarioBd);

            UsuarioDTOSaida userDTO = new()
            {
                Id = usuarioBd.Id,
                Nome = usuarioBd.Nome,
                Email = usuarioBd.Email,
                CPF = usuarioBd.CPF,
                Telefone = usuarioBd.Telefone,
                Tipo = usuarioBd.Tipo
            };
            return userDTO;
        }

        public async Task<UsuarioDTOSaida> UpdateUsuario(UsuarioDTO usuario, int id)
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

            UsuarioDTOSaida userDTO = new()
            {
                Id = updatedUser.Id,
                Nome = updatedUser.Nome,
                Email = updatedUser.Email,
                CPF = updatedUser.CPF,
                Telefone = updatedUser.Telefone,
                Tipo = updatedUser.Tipo
            };
            return userDTO;
        }

        public async Task<UsuarioDTOSaida> UpdateUsuario(UsuarioDTO usuario)
        {
            bool userDuplicado = await _usuarioRepositorio.ValidaUsuarioCpf(usuario);

            if (userDuplicado) return null;

            UsuarioModel updatedUser = await _usuarioRepositorio.GetUsuarioCpf(usuario.CPF);
            updatedUser.Nome = usuario.Nome;
            updatedUser.Telefone = usuario.Telefone;
            updatedUser.Email = usuario.Email;
            updatedUser.CPF = usuario.CPF;
            updatedUser.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
            updatedUser.Tipo = usuario.Tipo;
            await _usuarioRepositorio.UpdateUsuario(updatedUser);

            UsuarioDTOSaida userDTO = new()
            {
                Id = updatedUser.Id,
                Nome = updatedUser.Nome,
                Email = updatedUser.Email,
                CPF = updatedUser.CPF,
                Telefone = updatedUser.Telefone,
                Tipo = updatedUser.Tipo
            };
            return userDTO;
        }
        public async Task<UsuarioDTOSaida> DeleteUsuario(string cpf)
        {
            UsuarioModel userBd = await _usuarioRepositorio.GetUsuarioCpf(cpf);

            if (userBd == null) return null;

            await _usuarioRepositorio.DeleteUsuario(userBd);

            UsuarioDTOSaida userDTO = new()
            {
                Id = userBd.Id,
                Nome = userBd.Nome,
                Email = userBd.Email,
                CPF = userBd.CPF,
                Telefone = userBd.Telefone,
                Tipo = userBd.Tipo
            };
            return userDTO;
        }

        public async Task<UsuarioDTOSaida> LoginUsuario(string email, string senha)
        {
            UsuarioModel userBd = await _usuarioRepositorio.LoginUsuario(email);
            if (userBd == null) return null;

            bool senhaValida = BCrypt.Net.BCrypt.Verify(senha, userBd.Senha);

            if (!senhaValida) return null;

            return new UsuarioDTOSaida
            {
                Id = userBd.Id,
                Nome = userBd.Nome,
                Email = userBd.Email,
                CPF = userBd.CPF,
                Telefone = userBd.Telefone,
                Tipo = userBd.Tipo
            };
        }
    }
}
