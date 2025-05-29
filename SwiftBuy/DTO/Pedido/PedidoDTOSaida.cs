using SwiftBuy.DTO.Produto;
using SwiftBuy.Model;

namespace SwiftBuy.DTO.Pedido
{
    public class PedidoDTOSaida
    {
        public int UsuarioId { get; set; }
        public List<ProdutoPedidoDTOSaida> Produtos { get; set; }
        public DateTime HoraPedido { get; set; }
        public decimal ValorTotal { get; set; }
    }
}