using System.ComponentModel.DataAnnotations;
namespace SwiftBuy.Model
{
    public class PedidoProdutoModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PedidoId { get; set; }
        public PedidoModel Pedido { get; set; }

        [Required]
        public int ProdutoId { get; set; }
        public ProdutoModel Produto { get; set; }

        [Required]
        public int Quantidade { get; set; }
    }
}