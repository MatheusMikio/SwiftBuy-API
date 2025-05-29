using SwiftBuy.DTO.Usuario;
using SwiftBuy.Model;

namespace SwiftBuy.Repositorio.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<List<UsuarioModel>> GetUsuarios();
        Task<List<UsuarioModel>> GetUsuariosPaginacao(int pagina, int quantidade);
        Task<UsuarioModel> GetUsuarioId(int id);
        Task<UsuarioModel> AddUsuario(UsuarioModel produto);
        Task<UsuarioModel> UpdateUsuario(UsuarioModel produto);
        Task<UsuarioModel> DeleteUsuario(UsuarioModel usuario);
        Task<bool> ValidaUsuario(UsuarioDTO usuario);
        Task<UsuarioModel> GetUsuarioCpf(string cpf);

        Task<UsuarioModel> LoginUsuario(string email);
        Task<bool> ValidaUsuarioUpdate(UsuarioDTO usuario, int id);
        Task<bool> ValidaUsuarioCpf(UsuarioDTO usuario);
    }
}
