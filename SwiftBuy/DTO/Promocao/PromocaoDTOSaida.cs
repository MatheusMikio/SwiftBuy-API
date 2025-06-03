using SwiftBuy.DTO.Produto;
using SwiftBuy.Model;

namespace SwiftBuy.DTO
{
    public class PromocaoDTOSaida
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Porcentagem { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public List<ProdutoDTOSaida> Produtos { get; set; } = new();
    }
}
