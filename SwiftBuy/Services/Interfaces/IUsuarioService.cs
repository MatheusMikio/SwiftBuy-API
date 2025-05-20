using SwiftBuy.DTO;
using SwiftBuy.Model;

namespace SwiftBuy.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<List<UsuarioModel>> GetUsuarios();
        Task<UsuarioModel> GetUsuarioId(int id);
        Task<UsuarioModel> AddUsuario(UsuarioDTO usuario);
        Task<UsuarioModel> UpdateUsuario(UsuarioDTO usuario);
        Task<UsuarioModel> DeleteUsuario(int id);
    }
}
