using SwiftBuy.DTO;
using SwiftBuy.Model;

namespace SwiftBuy.Services.Interfaces
{
    public interface IPedidoService
    {
        Task<List<PedidoModel>> GetPedidos();
        Task<PedidoModel> GetPedidoId(int id);
        Task<PedidoModel> AddPedido(PedidoDTO pedido);
        Task<PedidoModel> UpdatePedido(PedidoDTO pedido);
        Task<bool> DeletePedido(int id);
    }
}
