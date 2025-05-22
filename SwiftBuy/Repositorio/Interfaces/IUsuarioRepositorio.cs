using SwiftBuy.DTO;
using SwiftBuy.Model;

namespace SwiftBuy.Repositorio.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<List<UsuarioModel>> GetUsuarios();
        Task<UsuarioModel> GetUsuarioId(int id);
        Task<UsuarioModel> AddUsuario(UsuarioModel produto);
        Task<UsuarioModel> UpdateUsuario(UsuarioModel produto);
        Task<UsuarioModel> DeleteUsuario(UsuarioModel usuario);
        Task<bool> ValidaUsuario(UsuarioDTO usuario);
        Task<UsuarioModel> GetUsuarioCpf(string cpf);
        Task<bool> ValidaUsuarioUpdate(UsuarioDTO usuario, int id);
        Task<bool> ValidaUsuarioCpf(UsuarioDTO usuario);
    }
}
