using SwiftBuy.Model;

namespace SwiftBuy.DTO.Pedido
{
    public class PedidoDTO
    {
        public int UsuarioId { get; set; }
        public List<ProdutoPedido> Produtos { get; set; } = new();
    }
}
