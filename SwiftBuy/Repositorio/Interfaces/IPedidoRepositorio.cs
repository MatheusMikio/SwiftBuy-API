using SwiftBuy.Model;

namespace SwiftBuy.Repositorio.Interfaces
{
    public interface IPedidoRepositorio
    {
        Task<List<PedidoModel>>GetPedidos();
        Task<PedidoModel>GetPedidoId(int id);
        Task<PedidoModel>AddPedido(PedidoModel pedido);
        Task<PedidoModel>UpdatePedido(PedidoModel pedido);
        Task<bool>DeletePedido(int id);
    }
}
