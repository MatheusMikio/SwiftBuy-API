using SwiftBuy.Model;

namespace SwiftBuy.Repositorio.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<List<UsuarioModel>> GetUsuarios();
        Task<UsuarioModel> GetUsuarioId(int id);
        Task<UsuarioModel> AddUsuario(UsuarioModel produto);
        Task<UsuarioModel> UpdateUsuario(UsuarioModel produto);
        Task<bool> DeleteUsuario(int id);
    }
}
