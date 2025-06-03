using SwiftBuy.Model;

namespace SwiftBuy.DTO
{
    public class PromocaoDTO
    {
        public string Nome { get; set; }
        public int Porcentagem { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int[] ProdutosId { get; set; }
    }
}
