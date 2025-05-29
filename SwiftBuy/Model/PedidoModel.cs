using System.ComponentModel.DataAnnotations;

namespace SwiftBuy.Model
{
    public class PedidoModel
    {
        [Key]
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        [Required]
        public UsuarioModel Usuario { get; set; }
        [Required]
        public List<PedidoProdutoModel> PedidoProdutos { get; set; } = new();
        public DateTime HoraPedido { get; set; }
        [Required]
        public decimal ValorTotal { get; set; }
        public PedidoModel(){}
        
        
    }
}
