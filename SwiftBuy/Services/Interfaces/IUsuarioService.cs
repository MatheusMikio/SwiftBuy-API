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
        Task<UsuarioModel> UpdateUsuario(UsuarioDTO usuario);
        Task<UsuarioModel> DeleteUsuario(string cpf);
        Task<UsuarioDTOSaida> GetUsuarioCpf(UsuarioDTO usuario);
    }
}
