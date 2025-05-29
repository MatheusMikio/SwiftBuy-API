using SwiftBuy.DTO.Usuario;
using SwiftBuy.Model;

namespace SwiftBuy.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<List<UsuarioDTOSaida>> GetUsuarios();
        Task<List<UsuarioDTOSaida>> GetUsuariosPaginacao(int pagina, int tamanho);
        Task<UsuarioDTOSaida> GetUsuarioId(int id);
        Task<UsuarioDTOSaida> AddUsuario(UsuarioDTO usuario);
        Task<UsuarioDTOSaida> UpdateUsuario(UsuarioDTO usuario, int id);
        Task<UsuarioDTOSaida> UpdateUsuario(UsuarioDTO usuario);
        Task<UsuarioDTOSaida> DeleteUsuario(string cpf);
        Task<UsuarioDTOSaida> GetUsuarioCpf(UsuarioDTO usuario);

        Task<UsuarioDTOSaida> LoginUsuario(string email, string senha);
    }
}
