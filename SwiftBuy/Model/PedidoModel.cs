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
        public List<ProdutoModel> Produtos { get; set; }  = new();
        public DateTime HoraPedido { get; set; } = DateTime.Now;
        [Required]
        public decimal ValorTotal { get; set; }
        public PedidoModel(){}
        
        
    }
}
