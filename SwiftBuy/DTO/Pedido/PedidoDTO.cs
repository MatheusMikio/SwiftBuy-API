using SwiftBuy.Model;

namespace SwiftBuy.DTO.Pedido
{
    public class PedidoDTO
    {
        public int UsuarioId { get; set; }
        public List<ProdutoPedidoModel> Produtos { get; set; } = new();
    }
}
