using SwiftBuy.Model;

namespace SwiftBuy.DTO.Promocao
{
    public class PromocaoDTO
    {
        public int Id { get; private set; }
        public string Nome { get; set; }
        public int Porcentagem { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int[]? ProdutosId { get; set; }

        public void SetId(int id)
        {
            Id = id;
        }
    }
}
