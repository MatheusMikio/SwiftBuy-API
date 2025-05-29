using SwiftBuy.Model;

namespace SwiftBuy.Repositorio.Interfaces
{
    public interface IPedidoRepositorio
    {
        Task<List<PedidoModel>>GetPedidos();
        Task<PedidoModel>GetPedidoId(int id);
        Task<List<PedidoModel>> GetProdutosPaginacao(int pagina, int quantidade);
        Task<UsuarioModel> GetUser(string cpf);
        Task<PedidoModel>AddPedido(PedidoModel pedido);
        
    }
}
