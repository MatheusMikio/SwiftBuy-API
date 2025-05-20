using SwiftBuy.Model;

namespace SwiftBuy.DTO
{
    public class PromocaoProdutoDTO
    {
        public string nome { get; set; }
        public int porcentagem { get; set; }
        public DateTime dataInicio { get; set; }
        public DateTime dataFim { get; set; }
        public int[] produtos { get; set; }
    }
}
