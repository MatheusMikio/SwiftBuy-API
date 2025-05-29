using SwiftBuy.DTO.Pedido;
using SwiftBuy.Model;

namespace SwiftBuy.Services.Interfaces
{
    public interface IPedidoService
    {
        Task<List<PedidoDTOSaida>> GetPedidos();
        Task<PedidoDTOSaida> GetPedidoId(int id);
        Task<List<PedidoDTOSaida>> GetPedidosPaginacao(int pagina, int quantidade);
        Task<PedidoDTOSaida> AddPedido(PedidoDTO pedido);

        Task<decimal> CalcularValorTotal(List<PedidoProdutoModel> produtos);
    }
}
