using System.ComponentModel.DataAnnotations;

namespace SwiftBuy.Model
{
    public class PromocaoModel
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Porcentagem { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public List<ProdutoModel> Produtos { get; set; } = new();

        public PromocaoModel(){ }
    }
}
