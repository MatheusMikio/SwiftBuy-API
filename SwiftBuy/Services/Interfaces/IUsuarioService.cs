using SwiftBuy.DTO;
using SwiftBuy.Model;

namespace SwiftBuy.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<List<UsuarioDTOSaida>> GetUsuarios();
        Task<UsuarioDTOSaida> GetUsuarioId(int id);
        Task<UsuarioModel> AddUsuario(UsuarioDTO usuario);
        Task<UsuarioModel> UpdateUsuario(UsuarioDTO usuario, int id);
        Task<UsuarioModel> DeleteUsuario(int id);
    }
}
