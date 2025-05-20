using System.ComponentModel.DataAnnotations;

namespace SwiftBuy.Model
{
    public class ProdutoModel
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public List<PedidoModel> PedidoModels { get; set; } = new();
        public List<ImagemModel> ImagemProduto { get; set; }

        public ProdutoModel(){ }
    }
}
