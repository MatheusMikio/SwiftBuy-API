using System.ComponentModel.DataAnnotations;

namespace SwiftBuy.Model
{
    public class PedidoModel
    {
        [Key]
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public UsuarioModel Usuario { get; set; }
        public List<ProdutoModel> Produtos { get; set; }  = new();
        public DateTime HoraPedido { get; set; } = DateTime.Now;
        public decimal ValorTotal { get; set; }
        public PedidoModel(){}
        
        
    }
}
